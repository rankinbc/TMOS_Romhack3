using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Core.TmosRomInfo;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using Tmos.Romhacks.UI.Drawers;
using TMOS_Romhack.DataViewer;
using static Tmos.Romhacks.Core.TmosData;
using static Tmos.Romhacks.Mods.TmosModWorldScreen;
using static Tmos.Romhacks.UI.Drawers.TmosDrawer;

namespace Tmos.Romhacks.UI
{


    public partial class Form1 : Form
    {
        TmosDrawer _drawer = new TmosDrawer();

        //IModifier _modifier = new RandomizerModifier()

        TmosModRom _tmosMod = new TmosModRom();

        int _selectedWorldScreenIndex;
        int _selectedWorldScreenTileIndex;
        int _selectedTileSectionIndex;
        int _selectedTileIndex;
        int _selectedMiniTileIndex;

        public Form1()
        {

            InitializeComponent();

            _selectedWorldScreenIndex = 0;
            _selectedWorldScreenTileIndex = 0;
            _selectedTileSectionIndex = 0;
            _selectedTileIndex = 0;
            _selectedMiniTileIndex = 0;

            pb_worldScreen.Image = new Bitmap(pb_worldScreen.Width, pb_worldScreen.Height);
            pb_worldMap.Image = new Bitmap(pb_worldMap.Width, pb_worldMap.Height);

            InitializeFormItems();
        }

        private void FinishLoadRom()
        {
            UpdateWorldScreenTileListBox();
            UpdateWorldScreenListView();
            UpdateTileListBox();
            UpdateMiniTileListBox();

            UpdateTileSectionListBoxes();
            SelectWorldScreen(0);
        }

        #region InitializeFormItems
        private void InitializeFormItems()
        {
            InitForm_Events_Redraw();
            InitForm_TileSectionsListboxItems();
        }
        ImageList imageList;
        private void InitForm_TileSectionsListboxItems()
        {
           
             imageList = new ImageList();
            for (int i = 0; i < 255; i++)
            {
                string imagePath = $"TileImages/{GetTileImage((byte)i)}";

                if (File.Exists(imagePath))
                    {
                    Bitmap bmp = new Bitmap(Image.FromFile(imagePath), new Size(64, 64));
                    string key = GetTileImage((byte)i).Replace(".png","");
                    imageList.Images.Add(key, bmp);
                }
            }

            lv_tileSection_values.Columns.Add("x1");
            lv_tileSection_values.Columns.Add("x2");
            lv_tileSection_values.Columns.Add("x3");
            lv_tileSection_values.Columns.Add("x4");
            lv_tileSection_values.Columns.Add("x5");
            lv_tileSection_values.Columns.Add("x6");
          
            lv_tileSection_values.TileSize = new Size(128, 128);
            lv_tileSection_values.LabelEdit = false;
            lv_tileSection_values.FullRowSelect = false;
            lv_tileSection_values.GridLines = true;
            lv_tileSection_values.SmallImageList = imageList;
            lv_tileSection_values.StateImageList = imageList;
            lv_tileSection_values.LargeImageList = imageList;
            lv_tileSection_values.View = View.SmallIcon;

            for (int i = 0; i < 24; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { $"{0} (0x00)", $"{i}", $"0x00" });
                item.ImageKey = GetTileImage((byte)i).Replace(".png", ""); 
                lv_tileSection_values.Items.Add(item);
            }
       
        }

        private void UpdateTileSectionDataListView(TmosTileSection tmosTileSection)
        {
            if (tmosTileSection != null)
            {
                lv_tileSection_values.Clear();
                var tmosTileSectionValues = tmosTileSection.GetBytes();
                for (int i = 0; i < tmosTileSection.GetBytes().Length; i++)
                {
                    string hexValue = tmosTileSectionValues[i].ToString("X2").ToUpper();
                    ListViewItem item = new ListViewItem(new string[] { $"0x{hexValue} ({tmosTileSectionValues[i].ToString()})", $"{i}", $"0x{hexValue}"});
                    item.ImageKey = GetTileImage((byte)tmosTileSectionValues[i]).Replace(".png", "");
                    lv_tileSection_values.Items.Add(item);
                }

                rtb_tileSection_data.Clear();
                byte[,] byteGrid = tmosTileSection.GetTileSectionGrid();
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        rtb_tileSection_data.Text += $"0x{byteGrid[x, y].ToString("X2")}";
                        rtb_tileSection_data.Text += "  ";
                    }
                    rtb_tileSection_data.Text += Environment.NewLine;
                }

            }
        }

            private void InitForm_Events_Redraw()
        {
            //Init redraw event for buttons that trigger redraw
            foreach (var childControl in gb_drawOptions.Controls)
            {
                if (childControl is GroupBox groupBox)
                {
                    foreach (Control childControl2 in groupBox.Controls)
                    {
                        if (childControl2 is CheckBox cb2)
                        {
                            cb2.CheckedChanged += DrawOptionControl_Click;
                        }
                        else if (childControl2 is TextBox tb2)
                        {
                            tb2.Leave += DrawOptionControl_Click;
                        }
                    }

                }
            }
        }

        private void nud_drawOptions_worldScreen_showTileImages_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        //private void InitFormEvents_Redraw()
        //{
        //    //Init redraw event for buttons that trigger redraw
        //    foreach (var childGroupBox in new GroupBox[] { tabPage7, tabPage8 })
        //    {
        //    }
        //}



        #endregion InitializeFormItems

        private void DrawOptionControl_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            // Button clickedButton = sender as Button;
            if (sender is CheckBox cb2)
            {
                Draw();
            }
            else
            {
                Draw();
            }
         
        }

        #region File IO
        private void HandleLoadRom(string filePath = null)
        {
            if (filePath == null){ filePath=  "ROMS\\TMOS.nes"; }

            TmosRom _currentRom = new TmosRom();
            _currentRom.LoadRom(filePath);

            _tmosMod = new TmosModRom();
            _tmosMod.LoadDataFromRom(_currentRom);

            //  _randomizerMod.Randomize();

            FinishLoadRom();
        }

        private void SaveRom(string path)
        {
            
            ////Update _currentRom
            //for (int i = 0; i < _tmosMod.WorldScreens.Length; i++)
            //{
            //    TmosModWorldScreen ws = _tmosMod.WorldScreens[i];
            //    _currentRom.SaveWorldScreen(i, TmosModRom.RandomizerWorldScreenToTmosWorldScreen(ws));
            //}
            //_currentRom.WriteRom(path);

            //FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        }
        private void fileToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            if (item != null)
            {
                switch (item.Name)
                {
                    case "menu_loadRom":
                        {
                            DialogResult result = openFileDialog1.ShowDialog();
                            if (result == System.Windows.Forms.DialogResult.OK)
                            {
                                HandleLoadRom(openFileDialog1.FileName);
                            }
                        }; 
                        break;
                    case "menu_loadDefaultRom":
                        {
                            HandleLoadRom("ROMS\\TMOS.nes");
                        }; 
                        break;
                    case "menu_saveRom":
                        {
                            DialogResult result = saveFileDialog1.ShowDialog();
                            if (result == System.Windows.Forms.DialogResult.OK)
                            {
                                SaveRom(saveFileDialog1.FileName);
                            }
                        }; 
                        break;

                }
            }
        }

        private void btn_loadDefaultRom_Click(object sender, EventArgs e)
        {
            HandleLoadRom("ROMS\\TMOS.nes");
        }

        #endregion File IO

      
        #region ListBox Updating

        private void UpdateWorldScreenListView()
        {
            var worldScreens = _tmosMod.GetTmosModWorldScreens(false);
            for (int i = 0; i < worldScreens.Length; i++)
            {
                TmosModWorldScreen ws = worldScreens[i];
                string[] data = ws.GetBytes().Select(b => b.ToString("X2")).ToArray();
                lv_worldScreens.Items.Add(i.ToString() + " (" + i.ToString("X2") + ")").SubItems.AddRange(data);
            }
        }

        private void UpdateWorldScreenTileListBox()
        {
            lb_worldScreenTiles.Items.Clear();
            for (int i = 0; i < _tmosMod.WorldScreenTiles.Length; i++)
            {
                lb_worldScreenTiles.Items.Add(Utility.ToDecimalAndHexDisplayValue(i));
            }
        }
        private void UpdateTileSectionListBoxes()
        {   
            lb_tileSection_top.Items.Clear();
            lb_tileSection_bottom.Items.Clear();
            for (int i = 0; i < _tmosMod.TileSections.Length; i++)
            {
                lb_tileSection_top.Items.Add(Utility.ToDecimalAndHexDisplayValue(i));
                lb_tileSection_bottom.Items.Add(Utility.ToDecimalAndHexDisplayValue(i));
            }

            lb_tileSection.Items.Clear();
            for (int i = 0; i < _tmosMod.TileSections.Length; i++)
            {
                lb_tileSection.Items.Add(Utility.ToDecimalAndHexDisplayValue(i));
            }
        }

        private void UpdateTileListBox()
        {
            lb_tile.Items.Clear();
            for (int i = 0; i < _tmosMod.Tiles.Length; i++)
            {
                lb_tile.Items.Add(Utility.ToDecimalAndHexDisplayValue(i));
            }
        }

        private void UpdateMiniTileListBox()
        {
            lb_miniTile.Items.Clear();
            for (int i = 0; i < _tmosMod.MiniTiles.Length; i++)
            {
                lb_miniTile.Items.Add(Utility.ToDecimalAndHexDisplayValue(i));
            }
        }

        #endregion ListBox Updating

        #region ListBox Item Selecting
        private void SelectWorldScreenTile(int worldScreenTileIndex)
        {
            TmosModWorldScreenTile selectedWorldScreenTile = _tmosMod.WorldScreenTiles[worldScreenTileIndex];
            tb_worldScreenTile.Text = selectedWorldScreenTile.TileIndex.ToString("X2");

            try
            {
                string tileImagePath = $"TileImages/{selectedWorldScreenTile.TileIndex.ToString("X2")}.png";
                Bitmap bmp = new Bitmap(Image.FromFile(tileImagePath), new Size(pb_tile_Image.Width, pb_tile_Image.Height));
                pb_tile_Image.Image = bmp;
            }
            catch { }

            //TODO: Show Tile info
            //TOOD: Show Tile Minitile info
        }

        private void SelectTile(int tileIndex)
        {
            TmosTile selectedTile = _tmosMod.Tiles[tileIndex];
            tb_tile_data_byte1.Text = selectedTile.MiniTile1Value.ToString("X2");
            tb_tile_data_byte2.Text = selectedTile.MiniTile2Value.ToString("X2");
            tb_tile_data_byte3.Text = selectedTile.MiniTile3Value.ToString("X2");
            tb_tile_data_byte4.Text = selectedTile.MiniTile4Value.ToString("X2");

            //TODO: Show image
            //TOOD: Show Tile Minitile info
        }
        private void SelectMiniTile(int miniTileIndex)
        {
            TmosMiniTile selectedMiniTile = _tmosMod.MiniTiles[miniTileIndex];
            tb_miniTile_data_byte1.Text = selectedMiniTile.MicroTile1Value.ToString("X2");
            tb_miniTile_data_byte2.Text = selectedMiniTile.MicroTile2Value.ToString("X2");
            tb_miniTile_data_byte3.Text = selectedMiniTile.MicroTile3Value.ToString("X2");
            tb_miniTile_data_byte4.Text = selectedMiniTile.MicroTile4Value.ToString("X2");

        }
        private void SelectWorldScreen(int absoluteWorldScreenIndex)
        {
            List<TmosChapter> chapters = TmosChapterDefinitions.GetTmosChapters();
            TmosChapter chapter = TmosChapterDefinitions.GetChapterOfWorldScreen(absoluteWorldScreenIndex);

            int adjustedWorldScreenIndex = absoluteWorldScreenIndex;


            for (int i = 0; i < chapter.ChapterNumber; i++)
            {
                adjustedWorldScreenIndex -= TmosChapterDefinitions.CalculateWorldScreenCount(chapters[i], chapters);
            }

            TmosModWorldScreen selectedScreen = _tmosMod.GetTmosModWorldScreen(absoluteWorldScreenIndex);

             UpdateWorldScreenDataTextbox(selectedScreen);

            UpdateWorldScreenDataListView(selectedScreen);

            UpdateDirectionSection(selectedScreen);

            UpdateTileSectionListBoxesSelection(selectedScreen);

           // _tmosMod.LoadWorldScreenTileGrid(selectedScreen);

            if (tabControl1.SelectedTab == tab_worldScreen)
            {
                _drawer.DrawWorldScreen(pb_worldScreen, selectedScreen, GetDrawOptions(), _selectedWorldScreenIndex);
            }
            else if (tabControl1.SelectedTab == tab_map)
            {
                var ddo = GetDrawOptions();
                var mdo = new MapDrawOptions() { TileDrawOptions = ddo.TileDrawOptions, TileSize = 20, WorldScreenDrawOptions=ddo };
          
   
                _drawer.DrawMap(pb_worldMap, _tmosMod.GetTmosModWorldScreens(false), mdo, _selectedWorldScreenIndex);

            }
        //    _drawer.DrawWorldScreen(pb_worldScreen, selectedScreen, GetDrawOptions(), _selectedWorldScreenIndex);


        
        }

        private void SelectTileSection(int tileSectionIndex)
        {
            Output("SelectTileSection " + tileSectionIndex);
               TmosTileSection tmosTileSection = _tmosMod.GetTmosModTileSection(tileSectionIndex);
                    
            UpdateTileSectionDataListView(tmosTileSection);

        
        }

        #endregion ListBox Item Selecting


        private void UpdateWorldScreenDataListView(TmosModWorldScreen worldScreen)
            {

                lv_variables.Items[0].SubItems[1].Text = worldScreen.ParentWorld.ToString("X2");
                lv_variables.Items[1].SubItems[1].Text = worldScreen.AmbientSound.ToString("X2");
                lv_variables.Items[2].SubItems[1].Text = worldScreen.WSContent.Value.ToString("X2");
                lv_variables.Items[3].SubItems[1].Text = worldScreen.ObjectSet.ToString("X2");
                lv_variables.Items[4].SubItems[1].Text = worldScreen.ScreenIndexRight.ToString("X2");
                lv_variables.Items[5].SubItems[1].Text = worldScreen.ScreenIndexLeft.ToString("X2");
                lv_variables.Items[6].SubItems[1].Text = worldScreen.ScreenIndexDown.ToString("X2");
                lv_variables.Items[7].SubItems[1].Text = worldScreen.ScreenIndexUp.ToString("X2");
                lv_variables.Items[8].SubItems[1].Text = worldScreen.DataPointer.ToString("X2");
                lv_variables.Items[9].SubItems[1].Text = worldScreen.ExitPosition.ToString("X2");
                lv_variables.Items[10].SubItems[1].Text = worldScreen.TopTiles.ToString("X2");
                lv_variables.Items[11].SubItems[1].Text = worldScreen.BottomTiles.ToString("X2");
                lv_variables.Items[12].SubItems[1].Text = worldScreen.WorldScreenColor.ToString("X2");
                lv_variables.Items[13].SubItems[1].Text = worldScreen.SpritesColor.ToString("X2");
                lv_variables.Items[14].SubItems[1].Text = worldScreen.Unknown.ToString("X2");
                lv_variables.Items[15].SubItems[1].Text = worldScreen.Event.ToString("X2");

        }

        private void UpdateWorldScreenDataTextbox(TmosModWorldScreen worldScreen)
        {
            tb_output.Clear();

            tb_output.Text += "ParentWorld: " + worldScreen.ParentWorld + Environment.NewLine;
            tb_output.Text += "AmbientSound: " + worldScreen.AmbientSound + Environment.NewLine;
            tb_output.Text += $"Content: {worldScreen.WSContent.Value} ({worldScreen.WSContent.Name})" + Environment.NewLine;
            tb_output.Text += "ObjectSet: " + worldScreen.ObjectSet + Environment.NewLine;
            tb_output.Text += "ScreenIndexRight: " + worldScreen.ScreenIndexRight + Environment.NewLine;
            tb_output.Text += "ScreenIndexLeft: " + worldScreen.ScreenIndexLeft + Environment.NewLine;
            tb_output.Text += "ScreenIndexDown: " + worldScreen.ScreenIndexDown + Environment.NewLine;
            tb_output.Text += "ScreenIndexUp: " + worldScreen.ScreenIndexUp + Environment.NewLine;
            tb_output.Text += "DataPointer: " + worldScreen.DataPointer + Environment.NewLine;
            tb_output.Text += "ExitPosition: " + worldScreen.ExitPosition + Environment.NewLine;
            tb_output.Text += "TopTiles: " + worldScreen.TopTiles + Environment.NewLine; //Showing just the byte value here, even though we have the TileSection objects which can give more info
            tb_output.Text += "BottomTiles: " + worldScreen.BottomTiles + Environment.NewLine;//Showing just the byte value here, even though we have the TileSection objects which can give more info
            tb_output.Text += "WorldScreenColor: " + worldScreen.WorldScreenColor + Environment.NewLine;
            tb_output.Text += "SpritesColor: " + worldScreen.SpritesColor + Environment.NewLine;
            tb_output.Text += "Unknown: " + worldScreen.Unknown + Environment.NewLine;
            tb_output.Text += "Event: " + worldScreen.Event + Environment.NewLine;
        }


       
        private void UpdateTileSectionListBoxesSelection(TmosModWorldScreen worldScreen)
        {
            //Calculate offset
            //string relativeTopTileScreenIndexDisplay = worldScreen.TopTiles.ToString("X2");
            //int absoluteTopTileSectionIndex = _tmosMod.GetTmosModTileSectionAbsoluteIndex(worldScreen.TopTiles, worldScreen.DataPointer, true);

            //string relativeBottomTileScreenIndexDisplay = worldScreen.BottomTiles.ToString("X2");
            //int absoluteBottomTileSectionIndex = _tmosMod.GetTmosModTileSectionAbsoluteIndex(worldScreen.BottomTiles, worldScreen.DataPointer, false);

            //string topTileSectionItemDisplay = $"{relativeTopTileScreenIndexDisplay} (*{absoluteTopTileSectionIndex.ToString()}*)";
            //string bottomTileSectionItemDisplay = $"{relativeBottomTileScreenIndexDisplay} (*{absoluteBottomTileSectionIndex.ToString()}*)";

            //lb_tileSection_top.SelectedIndex = absoluteTopTileSectionIndex;
            //lb_tileSection_bottom.SelectedIndex = absoluteBottomTileSectionIndex;

            lb_tileSection_top.SelectedIndex = worldScreen.TopTiles;
            lb_tileSection_bottom.SelectedIndex = worldScreen.BottomTiles;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lb_worldScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_selectedWorldScreenIndex != lb_worldScreens.SelectedIndex)
            //{
            //    _selectedWorldScreenIndex = lb_worldScreens.SelectedIndex;
            //    SelectWorldScreen(_selectedWorldScreenIndex);
            //}

            ////temp
             
        }
        private void lv_worldScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_worldScreens.SelectedIndices.Count != 0 && _selectedWorldScreenIndex != lv_worldScreens.SelectedIndices[0])
            {
                _selectedWorldScreenIndex = lv_worldScreens.SelectedIndices[0];
                SelectWorldScreen(_selectedWorldScreenIndex);
            }
        }

        private void lb_worldScreenTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedWorldScreenTileIndex != lb_worldScreenTiles.SelectedIndex)
            {
                _selectedWorldScreenTileIndex = lb_worldScreenTiles.SelectedIndex;
                SelectWorldScreenTile(_selectedWorldScreenTileIndex);
            }

        }

        #region WorldScreenNavigation

        private void btn_move_up_Click(object sender, EventArgs e)
        {
            int chapter = _tmosMod.GetTmosWorldScreenChapter(_selectedWorldScreenIndex);
            int relativeWorldScreenIndex = Utility.HexStringToInt(tb_direction_up.Text);
            int neightborWSIndex = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(chapter, relativeWorldScreenIndex, Direction.Up);

            lv_worldScreens.SelectedIndices.Clear();
            lv_worldScreens.SelectedIndices.Add(neightborWSIndex);
            lv_worldScreens.Focus();
        }

        private void btn_move_right_Click(object sender, EventArgs e)
        {
            int chapter = _tmosMod.GetTmosWorldScreenChapter(_selectedWorldScreenIndex);
            int relativeWorldScreenIndex = Utility.HexStringToInt(tb_direction_right.Text);
            int neightborWSIndex = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(chapter, relativeWorldScreenIndex, Direction.Right);

            lv_worldScreens.SelectedIndices.Clear();
            lv_worldScreens.SelectedIndices.Add(neightborWSIndex);
            lv_worldScreens.Focus();
        }

        private void btn_move_left_Click(object sender, EventArgs e)
        {
            int chapter = _tmosMod.GetTmosWorldScreenChapter(_selectedWorldScreenIndex);
            int relativeWorldScreenIndex = Utility.HexStringToInt(tb_direction_left.Text);
            int neightborWSIndex = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(chapter, relativeWorldScreenIndex, Direction.Left);

            lv_worldScreens.SelectedIndices.Clear();
            lv_worldScreens.SelectedIndices.Add(neightborWSIndex);
            lv_worldScreens.Focus();
        }

        private void btn_move_down_Click(object sender, EventArgs e)
        {
            int chapter = _tmosMod.GetTmosWorldScreenChapter(_selectedWorldScreenIndex);
            int relativeWorldScreenIndex = Utility.HexStringToInt(tb_direction_down.Text);
            int neightborWSIndex = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(chapter, relativeWorldScreenIndex, Direction.Down);

            lv_worldScreens.SelectedIndices.Clear();
            lv_worldScreens.SelectedIndices.Add(neightborWSIndex);
            lv_worldScreens.Focus();
        }

        private void tb_direction_up_TextChanged(object sender, EventArgs e)
        {

            tb_direction_up.BackColor = Color.White;
        }

        private void tb_direction_down_TextChanged(object sender, EventArgs e)
        {
            tb_direction_down.BackColor = Color.White;
        }

        private void tb_direction_right_TextChanged(object sender, EventArgs e)
        {
            tb_direction_right.BackColor = Color.White;
        }

        private void tb_direction_left_TextChanged(object sender, EventArgs e)
        {
            tb_direction_left.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Save Modified WS Directions
            try
            {
                TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);

                currentWS.ScreenIndexUp = Convert.ToByte(tb_direction_up.Text);
                int screenIndexUpWorldScreenIndex = currentWS.ScreenIndexUp; //TODO: Account for chapter ws offset

                TmosModWorldScreen destinationWS = _tmosMod.GetTmosModWorldScreen(screenIndexUpWorldScreenIndex);

                if (cb_link_back.Checked)
                {
                    destinationWS.ScreenIndexDown = (byte)_selectedWorldScreenIndex;
                }
                _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, destinationWS);
            }
            catch { }

            //try
            //{
            //    TmosModWorldScreen currentWS = _randomizerMod.WorldScreens[_selectedWorldScreenIndex];

            //    currentWS.ScreenIndexDown = Convert.ToByte(tb_direction_down.Text);
            //    int screenIndexUpWorldScreenIndex = currentWS.ScreenIndexUp;
            //    TmosModWorldScreen destinationWS = _randomizerMod.WorldScreens[currentWS.ScreenIndexDown];

            //    if (cb_link_back.Checked)
            //    {
            //        destinationWS.ScreenIndexUp = (byte)_selectedWorldScreenIndex;
            //    }
            //}
            //catch { }

            //try
            //{
            //    TmosModWorldScreen currentWS = _randomizerMod.WorldScreens[_selectedWorldScreenIndex];

            //    currentWS.ScreenIndexRight = Convert.ToByte(tb_direction_right.Text);

            //    TmosModWorldScreen destinationWS = _randomizerMod.WorldScreens[currentWS.ScreenIndexRight];

            //    if (cb_link_back.Checked)
            //    {
            //        destinationWS.ScreenIndexLeft = (byte)_selectedWorldScreenIndex;
            //    }
            //}
            //catch { }

            //try
            //{
            //    TmosModWorldScreen currentWS = _randomizerMod.WorldScreens[_selectedWorldScreenIndex];

            //    currentWS.ScreenIndexLeft = Convert.ToByte(tb_direction_left.Text);

            //    TmosModWorldScreen destinationWS = _randomizerMod.WorldScreens[currentWS.ScreenIndexLeft];

            //    if (cb_link_back.Checked)
            //    {
            //        destinationWS.ScreenIndexRight = (byte)_selectedWorldScreenIndex;
            //    }
            //}
            //catch { }
        }

        private void btn_testDirections_Click(object sender, EventArgs e)
        {
            //TmosModWorldScreen currentWS = _randomizerMod.WorldScreens[_selectedWorldScreenIndex];
            //TmosModWorldScreen rightWS = _randomizerMod.WorldScreens[currentWS.ScreenIndexRight];
            //TmosModWorldScreen leftWS = _randomizerMod.WorldScreens[currentWS.ScreenIndexLeft];
            //TmosModWorldScreen topWS = _randomizerMod.WorldScreens[currentWS.ScreenIndexUp];
            //TmosModWorldScreen bottomWS = _randomizerMod.WorldScreens[currentWS.ScreenIndexDown];

            //bool rightScreenIsCompatable = currentWS.CollisionTest_Right_IsCompatable(rightWS);
            //bool leftScreenIsCompatable = currentWS.CollisionTest_Left_IsCompatable(leftWS);
            //bool topScreenIsCompatable = currentWS.CollisionTest_Up_IsCompatable(topWS);
            //bool bottomScreenIsCompatable = currentWS.CollisionTest_Down_IsCompatable(bottomWS);

            //if (!rightScreenIsCompatable) tb_direction_right.BackColor = Color.Red;

            //if (!leftScreenIsCompatable) tb_direction_left.BackColor = Color.Red;

            //if (!topScreenIsCompatable) tb_direction_up.BackColor = Color.Red;

            //if (!bottomScreenIsCompatable) tb_direction_down.BackColor = Color.Red;



        }

        public void UpdateDirectionSection(TmosModWorldScreen worldScreen)
        {
            tb_direction_up.Text = worldScreen.ScreenIndexUp.ToString("X2");
            tb_direction_down.Text = worldScreen.ScreenIndexDown.ToString("X2");
            tb_direction_left.Text = worldScreen.ScreenIndexLeft.ToString("X2");
            tb_direction_right.Text = worldScreen.ScreenIndexRight.ToString("X2");
        }

        #endregion WorldScreenNavigation

        private void lb_tileSection_top_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ws = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);

            ws.TopTiles = (byte)lb_tileSection_top.SelectedIndex; //chapter offset?
            _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, ws);

            //int topTileSectionAbsoluteIndex = _tmosMod.GetWSTileSectionTopAbsoluteIndex(_selectedWorldScreenIndex);
            //SelectTileSection(topTileSectionAbsoluteIndex);

            DrawWorldScreen();
        }

        private void lb_tileSection_bottom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ws = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);

            ws.BottomTiles = (byte)lb_tileSection_bottom.SelectedIndex; //chapter offset?
            _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, ws);

            //int bottomTileSectionAbsoluteIndex = _tmosMod.GetWSTileSectionBottomAbsoluteIndex(_selectedWorldScreenIndex);
            //SelectTileSection(bottomTileSectionAbsoluteIndex);

            DrawWorldScreen();

            //_tmosMod.UpdateWorldScreenBottomTileSection(_selectedWorldScreenIndex, lb_tileSection_bottom.SelectedIndex);
            //RefreshWorldScreenDrawing();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        #region Drawing
        private TmosWorldScreenDrawOptions GetDrawOptions()
        {
            Font font = new Font("Arial", 7);
            Brush brush = Pens.Black.Brush;
            return new TmosWorldScreenDrawOptions()
            {
                ShowBorders = cb_drawOptions_worldScreen_showBorders.Checked,
                //ShowTileImages = cb_drawOptions_worldScreen_showTileImages.Checked,
                ShowInfo = cb_drawOptions_worldScreen_showInfo.Checked,
                TileSize = Convert.ToInt32(nud_drawOptions_worldScreen_showTileImages.Value),
                BaseFont = font,
                BaseBrush = brush,

                TileDrawOptions = new TileDrawOptions()
                {
                    ShowInfo = cb_drawOptions_worldScreenTile_showInfo.Checked,
                    ShowCollision = cb_drawOptions_worldScreenTile_showCollision.Checked,
                    ShowImage = cb_drawOptions_worldScreenTile_showImage.Checked,
                    ImageOpacity = 100,
                    BaseBrush = brush,
                    BaseFont = font
                }
            };
        }

        private void Draw()
        {
            if (tabControl1.SelectedTab == tab_worldScreen)
            {
                DrawWorldScreen();
            }
            else if (tabControl1.SelectedTab == tab_map)
            {
                DrawMap();
            }
            


        }

        private void DrawMap()
        {
            var wsDrawOptions = GetDrawOptions();
            wsDrawOptions.TileSize = wsDrawOptions.TileSize / 4;
            //wsDrawOptions.ShowTileImages = true;
            wsDrawOptions.ShowInfo = false;
            //wsDrawOptions.TileDrawOptions.ShowInfo = false;

            var o = new MapDrawOptions()
            {
                WorldScreenDrawOptions = wsDrawOptions,

                TileDrawOptions = wsDrawOptions.TileDrawOptions
            };

            //sloppy map draw torn from tmos randomizer 1 - need to do new one 
            var drawoptios = GetDrawOptions();
            drawoptios.TileSize = drawoptios.TileSize / 4;

            var tiledrawopts = drawoptios.TileDrawOptions;
            _drawer.DrawMap(pb_worldMap, _tmosMod.GetTmosModWorldScreens(true), new MapDrawOptions() { TileDrawOptions = tiledrawopts, TileSize = 100, WorldScreenDrawOptions = drawoptios }, _selectedWorldScreenIndex);

        }
        private void DrawWorldScreen()
        {
            TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
            _drawer.DrawWorldScreen(pb_worldScreen, currentWS, GetDrawOptions(), _selectedWorldScreenIndex);
        }
        private void btn_redraw_worldScreen_Click(object sender, EventArgs e)
        {
            DrawWorldScreen();
            DrawMap();
        }

        #endregion Drawing

        private void menu_loadDefaultRom_Click(object sender, EventArgs e)
        {

        }

        private void lb_tileSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedTileSectionIndex != lb_tileSection.SelectedIndex)
            {
                _selectedTileSectionIndex = lb_tileSection.SelectedIndex;
                SelectTileSection(_selectedTileSectionIndex);
            }
        }
        private void lb_tile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedTileIndex != lb_tile.SelectedIndex)
            {
                _selectedTileIndex = lb_tile.SelectedIndex;
                SelectTile(_selectedTileIndex);
            }
        }
        private void lb_miniTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedMiniTileIndex != lb_miniTile.SelectedIndex)
            {
                _selectedMiniTileIndex = lb_miniTile.SelectedIndex;
                SelectMiniTile(_selectedMiniTileIndex);
            }
        }

        private void pb_tileSection_Click(object sender, EventArgs e)
        {
            if (_selectedTileSectionIndex != lb_tileSection.SelectedIndex)
            {
                _selectedTileSectionIndex = lb_tileSection.SelectedIndex;
                SelectTileSection(_selectedTileSectionIndex);
            }
        }

        private void lv_tileSection_values_SelectedIndexChanged(object sender, EventArgs e)
        {
            // _selectedWorldScreenTileIndex = lv_tileSection_values.SelectedIndices[0];
            //  _selectedTileIndex = lv_tileSection_values.Items[lv_tileSection_values.SelectedIndex].SubItems[2];
            //Get the value of the item selected
            if (lv_tileSection_values.SelectedIndices.Count > 0 )//&&  != lb_tileSection.SelectedIndex)
            {
                _selectedTileIndex = lv_tileSection_values.SelectedIndices[0];
                Output(_selectedTileIndex.ToString());
                _selectedWorldScreenTileIndex = lv_tileSection_values.SelectedIndices[0];
            }
            }

        private void btn_tileSection_data_save_Click(object sender, EventArgs e)
        {
            int tileSectionSizeBytes = 32;
            byte[] updatedTileSectionData = new byte[tileSectionSizeBytes];
            string[] stringValues = rtb_tileSection_data.Text.Replace("0x", "").Split().Where(sv => sv.Length == 2).ToArray(); ;
            byte[] newData = new byte[tileSectionSizeBytes];
            for (int i = 0; i < tileSectionSizeBytes; i++)
            {
                string stringValue = stringValues[i].Trim().Replace(Environment.NewLine, "");
                newData[i] = Convert.ToByte(stringValue);
            }
            _tmosMod.UpdateTmosModTileSection(_selectedTileSectionIndex, newData);
        }

        private void btn_refreshWorldScreenList_Click(object sender, EventArgs e)
        {
            _tmosMod.GetTmosModWorldScreens(true);
            _selectedWorldScreenIndex = 0;
            SelectWorldScreen(0);
        }
        public void Output(string s)
        {
            Console.WriteLine(s += Environment.NewLine);
        }

       
    }
}
