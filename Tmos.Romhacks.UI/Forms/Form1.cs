using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Core.TmosRomDataObjects;
using Tmos.Romhacks.Core.TmosRomInfo;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.Enum.KnownValueLibrary;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using Tmos.Romhacks.Mods.Utility;
using Tmos.Romhacks.UI.Drawers;
using Tmos.Romhacks.UI.Images;
using TMOS_Romhack.DataViewer;
using static Tmos.Romhacks.Core.TmosData;
using static Tmos.Romhacks.Mods.TmosModWorldScreen;
using static Tmos.Romhacks.UI.Drawers.TmosDrawer;

namespace Tmos.Romhacks.UI
{


    public partial class Form1 : Form
    {

		private const string DefaultRomPath = "ROMS\\TMOS.nes";
		TmosDrawer _drawer;// = new TmosDrawer();

        //IModifier _modifier = new RandomizerModifier()

        TmosModRom _tmosMod;// = new TmosModRom();

		ImageList imageList;

		int _selectedWorldScreenIndex;
        int _selectedWorldScreenTileIndex;
        int _selectedTileSectionIndex;
        int _selectedTileIndex;
        int _selectedMiniTileIndex;
        int _selectedRandomEncounterGroupIndex;
        int _selectedRandomEncounterLineupIndex;

        bool _renderingEnabled = true;

        int _previousChapter = 0;

        public Form1()
        {

            InitializeComponent();

			ClearForm();
        }

        private void FinishLoadRom()
        {
            UpdateWorldScreenTileListBox();
            UpdateWorldScreenListView();
            UpdateTileListBox();
            UpdateMiniTileListBox();
            UpdateRandomEncounterGroupsListBox();
            UpdateRandomEncounterLineupsListListBox();

            UpdateTileSectionListBox();
            SelectWorldScreen(0);
        }

		#region InitializeFormItems

		private void InitializeForm()
		{
			_drawer = new TmosDrawer();
			_tmosMod = new TmosModRom();

			ClearSelectedIndexes();
			InitializePictureBoxes();
			InitializeEvents();
			InitializeTileSections();
		}

		private void InitializePictureBoxes()
		{
			pb_worldScreen.Image = new Bitmap(pb_worldScreen.Width, pb_worldScreen.Height);
			pb_worldMap.Image = new Bitmap(pb_worldMap.Width, pb_worldMap.Height);
		}

		private void ClearSelectedIndexes()
        {
			_selectedWorldScreenIndex = 0;
			_selectedWorldScreenTileIndex = 0;
			_selectedTileSectionIndex = 0;
			_selectedTileIndex = 0;
			_selectedMiniTileIndex = 0;
			_selectedRandomEncounterGroupIndex = 0;
			_selectedRandomEncounterLineupIndex = 0;
		}

		private void InitializeEvents()
		{
			//Set drawing related controls to trigger a re-draw
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

		

		private void ClearForm()
        {
           _drawer = new TmosDrawer();

            //IModifier _modifier = new RandomizerModifier()

            _tmosMod = new TmosModRom();

            ClearSelectedIndexes();


			pb_worldScreen.Image = new Bitmap(pb_worldScreen.Width, pb_worldScreen.Height);
           pb_worldMap.Image = new Bitmap(pb_worldMap.Width, pb_worldMap.Height);

            //InitForm_TileSectionsListboxItems();
        }
        

		private void InitializeTileSections()
		{
            //var imageList = new ImageList();
            //for (int i = 0; i < 255; i++)
            //{
            //	AddTileImageToList(imageList, i);
            //}
            PopulateWSTileSectionsListboxItems();
			ConfigureTileSectionListView(imageList);
			PopulateTileSectionListView();
		}

		//private void AddTileImageToList(ImageList imageList, int tileIndex)
		//{
		//	string imagePath = ImageFileManager.GetTileImagePath((byte)tileIndex);
		//	if (File.Exists(imagePath))
		//	{
		//		using (var bmp = new Bitmap(Image.FromFile(imagePath), new Size(40, 40)))
		//		{
		//			string key = Path.GetFileNameWithoutExtension(imagePath);
		//			imageList.Images.Add(key, bmp);
		//		}
		//	}
		//}

		private void PopulateWSTileSectionsListboxItems()
        {

            imageList = new ImageList();
            for (int i = 0; i < 255; i++)
            {
                string imagePath = ImageFileManager.GetTileImagePath((byte)i);

                if (File.Exists(imagePath))
                {
                    Bitmap bmp = new Bitmap(Image.FromFile(imagePath), new Size(40, 40));
                    string key = ImageFileManager.GetTileImagePath((byte)i).Replace(".png", "");
                    imageList.Images.Add(key, bmp);
                }
            }


            for (int i = 0; i < 24; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { $"{0} (0x00)", $"{i}", $"0x00" });
                item.ImageKey = ImageFileManager.GetTileImagePath((byte)i).Replace(".png", "");
                item.ToolTipText = $"Tile Index:0x00";
                lv_tileSection_values.Items.Add(item);
            }
         //   lv_worldScreens.Refresh();
        }

		private void ConfigureTileSectionListView(ImageList imageList)
		{
			lv_tileSection_values.TileSize = new Size(40, 40);
			lv_tileSection_values.LabelEdit = false;
			lv_tileSection_values.FullRowSelect = false;
			lv_tileSection_values.GridLines = true;
			lv_tileSection_values.ShowItemToolTips = true;
			lv_tileSection_values.SmallImageList = imageList;
			lv_tileSection_values.StateImageList = imageList;
			lv_tileSection_values.LargeImageList = imageList;
			lv_tileSection_values.View = View.Tile;
		}

		private void PopulateTileSectionListView()
		{
			for (int i = 0; i < 24; i++)
			{
				var item = new ListViewItem(new[] { $"{0} (0x00)", $"{i}", "0x00" })
				{
					ImageKey = ImageFileManager.GetTileImagePath((byte)i).Replace(".png", ""),
					ToolTipText = $"Tile Index:0x00"
				};
				lv_tileSection_values.Items.Add(item);
			}
			lv_tileSection_values.Refresh();
		}


      

        #endregion InitializeForm

        private void DrawOptionControl_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            Draw();
        }

        private void nud_drawOptions_worldScreen_showTileImages_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }
        private void nud_drawOptions_map_tileSize_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        #region File IO
      

		private void menu_loadDefaultRom_Click(object sender, EventArgs e)
		{
			LoadRom(DefaultRomPath);
		}

		private void btn_loadDefaultRom_Click(object sender, EventArgs e)
		{
			LoadRom(DefaultRomPath);
		}
		private void menu_loadRom_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
			{
				LoadRom(openFileDialog1.FileName);
			}
		}

		private void menu_saveRom_Click(object sender, EventArgs e)
		{
			DialogResult result = saveFileDialog1.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
			{
				SaveRom(saveFileDialog1.FileName);
			}
		}

		private void LoadRom(string filePath = null)
		{
			InitializeForm();
			try
			{
				if (filePath == null) { filePath = DefaultRomPath; }

				TmosRom _currentRom = new TmosRom();
				_currentRom.LoadRom(filePath);

				_tmosMod = new TmosModRom();
				_tmosMod.LoadDataFromRom(_currentRom);

				Output("Loaded Rom file: " + filePath);

				FinishLoadRom();
			}
			catch (Exception wx)
			{
				Output("Error loading rom file: " + wx.Message);
			}
		}

		private void SaveRom(string path)
		{
			_tmosMod.SaveDataToRom(path);
			Output("Rom file saved.");
			MessageBox.Show("Rom file saved.");
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

        private void UpdateTileSectionListBox()
        {
            lb_tileSection.Items.Clear();
            for (int i = 0; i < _tmosMod.TileSections.Length; i++)
            {
                lb_tileSection.Items.Add(ByteDisplayUtility.ToDecimalAndHexDisplayValue(i));
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
                    ListViewItem item = new ListViewItem(new string[] { $"0x{hexValue} ({tmosTileSectionValues[i]})", $"{tmosTileSectionValues[i]}", $"0x{hexValue}" });
                    item.ImageKey = ImageFileManager.GetTileImagePath((byte)tmosTileSectionValues[i]).Replace(".png", "");
                    item.ToolTipText = $"Tile Index:0x{tmosTileSectionValues[i].ToString("X2")}";
                    lv_tileSection_values.Items.Add(item);
                }

                rtb_tileSection_data.Clear();
                byte[,] byteGrid = tmosTileSection.GetTileSectionGrid();
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        rtb_tileSection_data.Text += $"0x{byteGrid[x, y].ToString("X2")} ";
                    }
                    rtb_tileSection_data.Text += Environment.NewLine;
                }
            }
        }

        private void UpdateWorldScreenTileListBox()
        {
            lb_worldScreenTiles.Items.Clear();
            for (int i = 0; i < _tmosMod.WorldScreenTiles.Length; i++)
            {
                lb_worldScreenTiles.Items.Add($"{i} (0x{i.ToString("X2")}) Val: 0x" + _tmosMod.WorldScreenTiles[i].TileIndexValue.ToString("X2"));
            }
        }

        private void UpdateTileListBox()
        {
            lb_tile.Items.Clear();
            for (int i = 0; i < _tmosMod.Tiles.Length; i++)
            {
                lb_tile.Items.Add(ByteDisplayUtility.ToDecimalAndHexDisplayValue(i));
            }
        }

        private void UpdateMiniTileListBox()
        {
            lb_miniTile.Items.Clear();
            for (int i = 0; i < _tmosMod.MiniTiles.Length; i++)
            {
                lb_miniTile.Items.Add(ByteDisplayUtility.ToDecimalAndHexDisplayValue(i));
            }
        }

        private void UpdateRandomEncounterGroupsListBox()
        {
            lb_encounterGroups.Items.Clear();
            for (int i = 0; i < _tmosMod.RandomEncounterGroups.Length; i++)
            {
                lb_encounterGroups.Items.Add(ByteDisplayUtility.ToDecimalAndHexDisplayValue(i));
            }
        }

        private void UpdateRandomEncounterLineupsListListBox()
        {
            lb_encounterLinups.Items.Clear();
            for (int i = 0; i < _tmosMod.RandomEncounterLineups.Length; i++)
            {
                lb_encounterLinups.Items.Add(ByteDisplayUtility.ToDecimalAndHexDisplayValue(i));
            }
        }

        #endregion ListBox Updating

        #region ListBox Item Selecting
        private void SelectWorldScreenTile(int worldScreenTileIndex)
        {
            _selectedWorldScreenTileIndex = worldScreenTileIndex;
            TmosModWorldScreenTile selectedWorldScreenTile = _tmosMod.WorldScreenTiles[worldScreenTileIndex];
            tb_worldScreenTile.Text = selectedWorldScreenTile.TileIndexValue.ToString("X2");
            lb_tile.SelectedIndex = selectedWorldScreenTile.TileIndexValue;
        }

        private void SelectTile(int tileIndex)
        {
            _selectedTileIndex = tileIndex;
            TmosModTile selectedTile = _tmosMod.GetTmosModTile(tileIndex);

            tb_tile_data_byte1.Text = selectedTile.MiniTile_TopLeft.ToString("X2");
            tb_tile_data_byte2.Text = selectedTile.MiniTile2_TopRight.ToString("X2");
            tb_tile_data_byte3.Text = selectedTile.MiniTile3_BottomLeft.ToString("X2");
            tb_tile_data_byte4.Text = selectedTile.MiniTile4_BottomRight.ToString("X2");

            try
            {
                string tileImagePath = ImageFileManager.GetTileImagePath(tileIndex);
                Image image = new Bitmap(tileImagePath);
                Size tileImageSize = new Size(pb_tile_Image.Width, pb_tile_Image.Height);
                Bitmap bmp = new Bitmap(image, tileImageSize);
                pb_tile_Image.Image = bmp;
            }
            catch (Exception ex)
            {
                Output(ex.Message);
            }

            SelectMiniTile(selectedTile.MiniTile_TopLeft);
        }
        private void SelectMiniTile(int miniTileIndex)
        {
            _selectedMiniTileIndex = miniTileIndex;
            TmosMiniTile selectedMiniTile = _tmosMod.MiniTiles[miniTileIndex];
            tb_miniTile_data_byte1.Text = selectedMiniTile.MicroTile1Value.ToString("X2");
            tb_miniTile_data_byte2.Text = selectedMiniTile.MicroTile2Value.ToString("X2");
            tb_miniTile_data_byte3.Text = selectedMiniTile.MicroTile3Value.ToString("X2");
            tb_miniTile_data_byte4.Text = selectedMiniTile.MicroTile4Value.ToString("X2");
        }

        private void SelectRandomEncounterGroup(int randomEncounterGroupIndex)
        {
            TmosRandomEncounterGroup selectedRandomEncounterGroup = _tmosMod.RandomEncounterGroups[randomEncounterGroupIndex];

            rtb_encounterGroups_data.Clear();

            foreach (var rg in new byte[]{ 
                selectedRandomEncounterGroup.WorldScreen, 
                selectedRandomEncounterGroup.MonsterGroup, 
                selectedRandomEncounterGroup.Unknown 
            })
            {
                rtb_encounterGroups_data.Text += rg.ToString("X2") + " ";
            }
        }
        private void SelectRandomEncounterLinuep(int randomEncounterLineupIndex)
        {
            TmosRandomEncounterLineup selectedRandomEncounterLineup = _tmosMod.RandomEncounterLineups[randomEncounterLineupIndex];
            rtb_encounterLineups_data.Clear();

            foreach (var rg in new byte[]
            {
                selectedRandomEncounterLineup.Startbyte,
                selectedRandomEncounterLineup.Slot1,
                selectedRandomEncounterLineup.Slot2,
                selectedRandomEncounterLineup.Slot3,
                selectedRandomEncounterLineup.Slot4,
                selectedRandomEncounterLineup.Slot5,
                selectedRandomEncounterLineup.Slot6,
                selectedRandomEncounterLineup.Slot7,
            })
            {
                rtb_encounterLineups_data.Text += rg.ToString("X2") + " ";
            }
        }


        private void SelectWorldScreen(int absoluteWorldScreenIndex)
        {
         //   List<TmosChapter> chapters = TmosChapterDefinitions.GetTmosChapters();
            TmosChapter chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex);
            if (_previousChapter != chapter.ChapterNumber)
            {
				//Chapter changed
				//UpdateWorldScreenContentSelectionComboBox(chapter.ChapterNumber);
			}

            int relativeWorldScreenIndex = WSIndexUtility.GetChapterRelativeWorldScreenIndex(absoluteWorldScreenIndex);

            _selectedWorldScreenIndex = absoluteWorldScreenIndex;

            TmosModWorldScreen selectedScreen = _tmosMod.GetTmosModWorldScreen(absoluteWorldScreenIndex);

            UpdateWorldScreenContentSelectionComboBox(selectedScreen, chapter.ChapterNumber);
            //UpdateWorldScreenDataDisplayTextbox(selectedScreen);
            UpdateWorldScreenDataListView(selectedScreen);
            UpdateWorldScreenDataEditTextbox(selectedScreen);

			tb_selectedWorldScreenIndex.Text = absoluteWorldScreenIndex.ToString();

            lbl_worldScreen_info.Text = $"Chapter: {chapter.ChapterNumber}{Environment.NewLine};" +
                $"Relative WSIndex: 0x{relativeWorldScreenIndex.ToString("X2")}{Environment.NewLine}";

			if ( _drawer.Map != null)
            {
                lbl_worldScreen_info.Text += $"Grid Position:{_drawer.Map.GetWorldScreenGridPosition(absoluteWorldScreenIndex)}";
            }
    
            UpdateDirectionSection(selectedScreen);
            UpdateTileSectionListBoxes(selectedScreen);

            Draw();
        }


        private void SelectTileSection(int tileSectionIndex)
        {
            TmosTileSection tmosTileSection = _tmosMod.GetTmosModTileSection(tileSectionIndex);

            int firstTileOfTileSectionOffset = GetTmosRomObjectOffset(TmosRomObjectType.TileSection, _selectedTileSectionIndex);
            _selectedWorldScreenTileIndex = firstTileOfTileSectionOffset;

            UpdateTileSectionDataListView(tmosTileSection);

        }

		#endregion ListBox Item Selecting

		private void UpdateWorldScreenContentSelectionComboBox(TmosModWorldScreen selectedScreen, int chapter)
		{
			comboBox_worldScreen_content.Items.Clear();
			for (int i = 0; i <= 255; i++)  // Changed to int and included 255
			{
				WSContent wsContent = WSContentDefinitions.GetWSContentDefinition(chapter, (byte)i);
				comboBox_worldScreen_content.Items.Add($"0x{i.ToString("X2")} {wsContent.Name} ({wsContent.Description})");
			}

			// Safely set the SelectedIndex
			if (selectedScreen.WSContent.Value >= 0 && selectedScreen.WSContent.Value <= 255)
			{
				comboBox_worldScreen_content.SelectedIndex = selectedScreen.WSContent.Value;
			}
			else
			{
				Console.WriteLine($"Invalid WSContent value: {selectedScreen.WSContent.Value}");
				comboBox_worldScreen_content.SelectedIndex = -1;
			}
		}


		private void UpdateWorldScreenDataListView(TmosModWorldScreen worldScreen)
        {
            int currentChapter = ChapterUtility.GetChapterOfWorldScreen(_selectedWorldScreenIndex).ChapterNumber;

            lv_variables.Items[0].SubItems[1].Text = worldScreen.ParentWorld.ToString("X2");
            lv_variables.Items[1].SubItems[1].Text = worldScreen.AmbientSound.ToString("X2");
            lv_variables.Items[2].SubItems[1].Text = worldScreen.Content.ToString("X2");

            lv_variables.Items[2].SubItems[2].Text = $"{worldScreen.WSContent.Name} - {worldScreen.WSContent.Description}";

            lv_variables.Items[3].SubItems[1].Text = worldScreen.ObjectSet.ToString("X2");

            lv_variables.Items[4].SubItems[1].Text = worldScreen.ScreenIndexRight.ToString("X2");
            lv_variables.Items[4].SubItems[2].Text = worldScreen.ScreenIndexRight.Equals(0xFF) ? "" : $"WS {WSIndexUtility.GetAbsoluteWorldScreenIndex(currentChapter, worldScreen.ScreenIndexRight)}";

            lv_variables.Items[5].SubItems[1].Text = worldScreen.ScreenIndexLeft.ToString("X2");
            lv_variables.Items[5].SubItems[2].Text = worldScreen.ScreenIndexLeft.Equals(0xFF) ? "" : $"WS {WSIndexUtility.GetAbsoluteWorldScreenIndex(currentChapter, worldScreen.ScreenIndexLeft)}";

            lv_variables.Items[6].SubItems[1].Text = worldScreen.ScreenIndexDown.ToString("X2");
            lv_variables.Items[6].SubItems[2].Text = worldScreen.ScreenIndexDown.Equals(0xFF) ? "" : $"WS {WSIndexUtility.GetAbsoluteWorldScreenIndex(currentChapter, worldScreen.ScreenIndexDown)}";

            lv_variables.Items[7].SubItems[1].Text = worldScreen.ScreenIndexUp.ToString("X2");
            lv_variables.Items[7].SubItems[2].Text = worldScreen.ScreenIndexUp.Equals(0xFF) ? "" : $"WS {WSIndexUtility.GetAbsoluteWorldScreenIndex(currentChapter, worldScreen.ScreenIndexUp)}";

            lv_variables.Items[8].SubItems[1].Text = worldScreen.DataPointer.ToString("X2");
            lv_variables.Items[9].SubItems[1].Text = worldScreen.ExitPosition.ToString("X2");
            lv_variables.Items[10].SubItems[1].Text = worldScreen.TopTiles.ToString("X2");
            lv_variables.Items[11].SubItems[1].Text = worldScreen.BottomTiles.ToString("X2");
            lv_variables.Items[12].SubItems[1].Text = worldScreen.WorldScreenColor.ToString("X2");
            lv_variables.Items[13].SubItems[1].Text = worldScreen.SpritesColor.ToString("X2");
            lv_variables.Items[14].SubItems[1].Text = worldScreen.Unknown.ToString("X2");
            lv_variables.Items[15].SubItems[1].Text = worldScreen.Event.ToString("X2");

        }

        private void UpdateWorldScreenDataEditTextbox(TmosModWorldScreen worldScreen)
        {
            tb_worldScreen_selectedWorldScreen_data.Clear();
            string wsDataString = "";
            foreach (var wsDataByte in worldScreen.GetBytes())
            {
                wsDataString += $"0x{wsDataByte.ToString("X2")} ";       
            }
            tb_worldScreen_selectedWorldScreen_data.Text = wsDataString;
        }


            private void UpdateTileSectionListBoxes(TmosModWorldScreen worldScreen)
        {
            int tileSectionOffsetTop = TileDataUtility.GetTopTileSectionTileDataOffset(worldScreen.DataPointer);
            int tileSectionOffsetBottom = TileDataUtility.GetBottomTileSectionTileDataOffset(worldScreen.DataPointer);

            lbl_worldScreenTileDataOffsets.Text = $"DataPointer: 0x{worldScreen.DataPointer.ToString("X2")}{Environment.NewLine}" +
                $"Top Tile Offset: 0x{tileSectionOffsetTop.ToString("X2")}{Environment.NewLine}" + 
                $"Bottom Tile Offset: 0x{tileSectionOffsetBottom.ToString("X2")}{Environment.NewLine}";

            lb_tileSection_top.Items.Clear();
            lb_tileSection_bottom.Items.Clear();
            for (int i = 0; i < 255; i++)
            {
                int absoluteTileSectionIndexTop = TileDataUtility.GetTmosModTileSectionAbsoluteIndex(i, worldScreen.DataPointer, true);
                int absoluteTileSectionIndexBottom = TileDataUtility.GetTmosModTileSectionAbsoluteIndex(i, worldScreen.DataPointer, false);
                
                if (absoluteTileSectionIndexTop < TmosRomDataObjectDefinitions.RomInfo_TileSection.Count)
                {
                    lb_tileSection_top.Items.Add($"{ByteDisplayUtility.ToHexDisplayValue(i)} - TS#{absoluteTileSectionIndexTop}");
                }
                if (absoluteTileSectionIndexBottom < TmosRomDataObjectDefinitions.RomInfo_TileSection.Count)
                {
                    lb_tileSection_bottom.Items.Add($"{ByteDisplayUtility.ToHexDisplayValue(i)} - TS#{absoluteTileSectionIndexBottom}");
                }
                
            }

            lb_tileSection_top.SelectedIndex = worldScreen.TopTiles;
            lb_tileSection_bottom.SelectedIndex = worldScreen.BottomTiles;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            //if (_selectedWorldScreenTileIndex != lb_worldScreenTiles.SelectedIndex)
            //{
            //    _selectedWorldScreenTileIndex = lb_worldScreenTiles.SelectedIndex;
            //    SelectWorldScreenTile(_selectedWorldScreenTileIndex);
            //}
        }

        private void lv_tileSection_values_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lv_tileSection_values.SelectedIndices.Count > 0)
            {

                int selectedIndex = lv_tileSection_values.SelectedIndices[0];

                ListViewItem selectedItem = lv_tileSection_values.Items[selectedIndex];

                int valueOfSelectedTileSectionTile = Convert.ToInt32(selectedItem.SubItems[1].Text);

                int tileSectionStartAddress = (_selectedTileSectionIndex * TmosRomDataObjectDefinitions.RomInfo_TileSection.ObjectSize);
                int wsTileOffset = tileSectionStartAddress + selectedIndex;

                lb_worldScreenTiles.SelectedIndex = wsTileOffset;

                lb_tile.SelectedIndex = valueOfSelectedTileSectionTile;
            }
        }

		private void comboBox_worldScreen_content_SelectedIndexChanged(object sender, EventArgs e)
		{
			//var ws = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
   //         if (ws.Content != comboBox_worldScreen_content.SelectedIndex)
   //         {
   //             ws.Content = (byte)comboBox_worldScreen_content.SelectedIndex;
   //             _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, ws);
   //         }
		}

		#region WorldScreenNavigation

		private void btn_move_up_Click(object sender, EventArgs e)
        {
            int chapter = _tmosMod.GetTmosWorldScreenChapter(_selectedWorldScreenIndex);
            int relativeWorldScreenIndex = ByteDisplayUtility.HexStringToInt(tb_direction_up.Text);
            int neightborWSIndex = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(chapter, relativeWorldScreenIndex, Direction.Up);

            lv_worldScreens.SelectedIndices.Clear();
            lv_worldScreens.SelectedIndices.Add(neightborWSIndex);
            lv_worldScreens.Focus();
        }

        private void btn_move_right_Click(object sender, EventArgs e)
        {
            int chapter = _tmosMod.GetTmosWorldScreenChapter(_selectedWorldScreenIndex);
            int relativeWorldScreenIndex = ByteDisplayUtility.HexStringToInt(tb_direction_right.Text);
            int neightborWSIndex = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(chapter, relativeWorldScreenIndex, Direction.Right);

            lv_worldScreens.SelectedIndices.Clear();
            lv_worldScreens.SelectedIndices.Add(neightborWSIndex);
            lv_worldScreens.Focus();
        }

        private void btn_move_left_Click(object sender, EventArgs e)
        {
            int chapter = _tmosMod.GetTmosWorldScreenChapter(_selectedWorldScreenIndex);
            int relativeWorldScreenIndex = ByteDisplayUtility.HexStringToInt(tb_direction_left.Text);
            int neightborWSIndex = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(chapter, relativeWorldScreenIndex, Direction.Left);

            lv_worldScreens.SelectedIndices.Clear();
            lv_worldScreens.SelectedIndices.Add(neightborWSIndex);
            lv_worldScreens.Focus();
        }

        private void btn_move_down_Click(object sender, EventArgs e)
        {
            int chapter = _tmosMod.GetTmosWorldScreenChapter(_selectedWorldScreenIndex);
            int relativeWorldScreenIndex = ByteDisplayUtility.HexStringToInt(tb_direction_down.Text);
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
            // Save Modified WS Directions
            int chapter=  ChapterUtility.GetChapterOfWorldScreen(_selectedWorldScreenIndex).ChapterNumber;
            try
            {
                TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
                currentWS.ScreenIndexUp = Convert.ToByte(tb_direction_up.Text);
                TmosModWorldScreen destinationWS = _tmosMod.GetTmosModWorldScreen(currentWS.ScreenIndexUp);

                if (cb_link_back.Checked)
                {
                    destinationWS.ScreenIndexDown = (byte)_selectedWorldScreenIndex;
                }

                int screenIndexUpAbsoluteWorldScreenIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, currentWS.ScreenIndexUp);
                _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, currentWS);
                _tmosMod.UpdateTmosModWorldScreen(screenIndexUpAbsoluteWorldScreenIndex, destinationWS);
            }
            catch { }

            try
            {
                TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
                currentWS.ScreenIndexDown = Convert.ToByte(tb_direction_down.Text);
                TmosModWorldScreen destinationWS = _tmosMod.GetTmosModWorldScreen(currentWS.ScreenIndexDown);

                if (cb_link_back.Checked)
                {
                    destinationWS.ScreenIndexUp = (byte)_selectedWorldScreenIndex;
                }

                int screenIndexDownAbsoluteWorldScreenIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, currentWS.ScreenIndexDown);
                _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, currentWS);
                _tmosMod.UpdateTmosModWorldScreen(screenIndexDownAbsoluteWorldScreenIndex, destinationWS);
            }
            catch { }

            try
            {
                TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
                currentWS.ScreenIndexRight = Convert.ToByte(tb_direction_right.Text);
                TmosModWorldScreen destinationWS = _tmosMod.GetTmosModWorldScreen(currentWS.ScreenIndexRight);

                if (cb_link_back.Checked)
                {
                    destinationWS.ScreenIndexLeft = (byte)_selectedWorldScreenIndex;
                }

                int screenIndexRightAbsoluteWorldScreenIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, currentWS.ScreenIndexRight);

                _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, currentWS);
                _tmosMod.UpdateTmosModWorldScreen(screenIndexRightAbsoluteWorldScreenIndex, destinationWS);

            }
            catch { }

            try
            {
                TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
                currentWS.ScreenIndexLeft = Convert.ToByte(tb_direction_left.Text);
                TmosModWorldScreen destinationWS = _tmosMod.GetTmosModWorldScreen(currentWS.ScreenIndexLeft);

                if (cb_link_back.Checked)
                {
                    destinationWS.ScreenIndexRight = (byte)_selectedWorldScreenIndex;
                }

                int screenIndexLeftAbsoluteWorldScreenIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, currentWS.ScreenIndexLeft);

                _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, currentWS);
                _tmosMod.UpdateTmosModWorldScreen(screenIndexLeftAbsoluteWorldScreenIndex, destinationWS);
            }
            catch { }

            }
        
        private void btn_testDirections_Click(object sender, EventArgs e)
        {
            TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
            int index_rightWS = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(_selectedWorldScreenIndex, Direction.Right);
            int index_leftWS = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(_selectedWorldScreenIndex, Direction.Left);
            int index_topWS = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(_selectedWorldScreenIndex, Direction.Up);
            int index_bottomWS =_tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(_selectedWorldScreenIndex, Direction.Down);


            TmosModWorldScreen rightWS = _tmosMod.GetTmosModWorldScreen(index_rightWS);
            TmosModWorldScreen leftWS = _tmosMod.GetTmosModWorldScreen(index_leftWS);
            TmosModWorldScreen topWS = _tmosMod.GetTmosModWorldScreen(index_topWS);
            TmosModWorldScreen bottomWS = _tmosMod.GetTmosModWorldScreen(index_bottomWS);

            bool rightScreenIsCompatable = currentWS.CollisionTest_Right_IsCompatable(rightWS);
            bool leftScreenIsCompatable = currentWS.CollisionTest_Left_IsCompatable(leftWS);
            bool topScreenIsCompatable = currentWS.CollisionTest_Up_IsCompatable(topWS);
            bool bottomScreenIsCompatable = currentWS.CollisionTest_Down_IsCompatable(bottomWS);

            if (!rightScreenIsCompatable) tb_direction_right.BackColor = Color.Red;
            if (!leftScreenIsCompatable) tb_direction_left.BackColor = Color.Red;
            if (!topScreenIsCompatable) tb_direction_up.BackColor = Color.Red;
            if (!bottomScreenIsCompatable) tb_direction_down.BackColor = Color.Red;

        }

        public void UpdateDirectionSection(TmosModWorldScreen worldScreen)
        {
            int chapter = _tmosMod.GetTmosWorldScreenChapter(_selectedWorldScreenIndex);
            int absoluteIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, _selectedWorldScreenIndex);
            tb_direction_up.Text = worldScreen.ScreenIndexUp.ToString("X2");// ByteDisplayUtility.ToAbsoluteAndRelativeDisplayValue(worldScreen.ScreenIndexUp.ToString("X2");
            tb_direction_down.Text = worldScreen.ScreenIndexDown.ToString("X2");
            tb_direction_left.Text = worldScreen.ScreenIndexLeft.ToString("X2");
            tb_direction_right.Text = worldScreen.ScreenIndexRight.ToString("X2");
        }

        #endregion WorldScreenNavigation

        private void lb_tileSection_top_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ws = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
            if (ws.TopTiles != lb_tileSection_top.SelectedIndex)
            {
                ws.TopTiles = (byte)lb_tileSection_top.SelectedIndex; //chapter offset?
                _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, ws);

                SelectWorldScreen(_selectedWorldScreenIndex);

                Draw();
            }
          
        }

        private void btnlbl_worldSection_topTiles_view_Click_1(object sender, EventArgs e)
        {
            TmosModWorldScreen ws = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
           
            lb_tileSection.SelectedIndex = TileDataUtility.GetTmosModTileSectionAbsoluteIndex(ws.TopTiles, ws.DataPointer, true);

            tabControl1.SelectedTab = tab_tileSection;
        }

        private void btnlbl_worldSection_bottomTiles_view_Click(object sender, EventArgs e)
        {
            TmosModWorldScreen ws = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
           
            lb_tileSection.SelectedIndex = TileDataUtility.GetTmosModTileSectionAbsoluteIndex(ws.BottomTiles, ws.DataPointer, false);

            tabControl1.SelectedTab = tab_tileSection;
        }

        private void lb_tileSection_bottom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ws = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);

            if (ws.BottomTiles != lb_tileSection_bottom.SelectedIndex)
            {
                ws.BottomTiles = (byte)lb_tileSection_bottom.SelectedIndex; //chapter offset?
                _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, ws);

                SelectWorldScreen(_selectedWorldScreenIndex);
                Draw();

            }

        }

        private void btn_worldScreen_save_Click(object sender, EventArgs e)
        {
            byte[] newWorldScreenData = tb_worldScreen_selectedWorldScreen_data.Text.Replace("0x", "").Split().Select(b => Convert.ToByte(b, 16)).ToArray();
            TmosModWorldScreen updatedWorldScreen = new TmosModWorldScreen(newWorldScreenData);
            _tmosMod.UpdateTmosModWorldScreen(_selectedWorldScreenIndex, updatedWorldScreen);
        }


        #region Drawing

        private void SetDrawOptions()
        {
            _drawer.BaseBrush = Pens.Black.Brush; 
            _drawer.BaseFont = new Font("Arial", 7);
          
        }
        private TmosWorldScreenDrawOptions GetDrawOptions()
        {
            
            return new TmosWorldScreenDrawOptions()
            {
                ShowBorders = cb_drawOptions_worldScreen_showBorders.Checked,
                //ShowTileImages = cb_drawOptions_worldScreen_showTileImages.Checked,
                ShowInfo = cb_drawOptions_worldScreen_showInfo.Checked,
                TileSize = Convert.ToInt32(nud_drawOptions_worldScreen_showTileImages.Value),


                TileDrawOptions = new TileDrawOptions()
                {
                    ShowInfo = cb_drawOptions_worldScreenTile_showInfo.Checked,
                    ShowCollision = cb_drawOptions_worldScreenTile_showCollision.Checked,
                    ShowImage = cb_drawOptions_worldScreenTile_showImage.Checked,
                    ImageOpacity = 100,

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
            if (_renderingEnabled)
            {
                var wsDrawOptions = GetDrawOptions();
                //  wsDrawOptions. = true;
                wsDrawOptions.ShowInfo = false;
                //wsDrawOptions.TileDrawOptions.ShowInfo = false;

                var mapDrawOptions = new MapDrawOptions()
                {
                    WorldScreenDrawOptions = wsDrawOptions,
                    TileSize = (int)nud_drawOptions_map_tileSize.Value,
                    TileDrawOptions = wsDrawOptions.TileDrawOptions
                };

                //Clear graphics on pb_worldmap
                pb_worldMap.Image = new Bitmap(pb_worldMap.Width, pb_worldMap.Height);

                _drawer.DrawMap(pb_worldMap, _tmosMod.GetTmosModWorldScreens(false), mapDrawOptions, _selectedWorldScreenIndex);
                pb_worldMap.Refresh();
            }
        }
        private void DrawWorldScreen()
        {
            if (_renderingEnabled)
            {
                TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);

                pb_worldScreen.Image = new Bitmap(pb_worldScreen.Width, pb_worldScreen.Height);


                _drawer.DrawWorldScreen(pb_worldScreen, currentWS, GetDrawOptions(), _selectedWorldScreenIndex);
                pb_worldScreen.Refresh();
            }
        }
        private void btn_redraw_worldScreen_Click(object sender, EventArgs e)
        {
            DrawWorldScreen();
            DrawMap();
        }

        #endregion Drawing

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

        private void lb_encounterGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedRandomEncounterGroupIndex != lb_encounterGroups.SelectedIndex)
            {
                _selectedRandomEncounterGroupIndex = lb_encounterGroups.SelectedIndex;
                SelectRandomEncounterGroup(_selectedRandomEncounterGroupIndex);
            }
        }


        private void lb_encounterLinups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedRandomEncounterLineupIndex != lb_encounterLinups.SelectedIndex)
            {
                _selectedRandomEncounterLineupIndex = lb_encounterLinups.SelectedIndex;
                SelectRandomEncounterLinuep(_selectedRandomEncounterLineupIndex);
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

        private void btn_tileSection_data_save_Click(object sender, EventArgs e)
        {
            int tileSectionSizeBytes = 32;
            byte[] updatedTileSectionData = new byte[tileSectionSizeBytes];
            string[] stringValues = rtb_tileSection_data.Text.Replace("0x", "").Split().Where(sv => sv.Length == 2).ToArray(); ;
            byte[] newData = new byte[tileSectionSizeBytes];
            for (int i = 0; i < tileSectionSizeBytes; i++)
            {
                string stringValue = stringValues[i].Trim().Replace(Environment.NewLine, "");
                newData[i] = Convert.ToByte(stringValue, 16);
            }
            _tmosMod.UpdateTmosModTileSection(_selectedTileSectionIndex, newData);

            SelectWorldScreen (_selectedWorldScreenIndex);    
        }

        private void btn_tile_save_Click(object sender, EventArgs e)
        {
            //WSIndex needed on updatedTile?
            TmosModTile updatedTile = new TmosModTile((byte)_selectedTileIndex,
                new byte[]
                {
                    Convert.ToByte(tb_tile_data_byte1.Text, 16) ,
                    Convert.ToByte(tb_tile_data_byte2.Text, 16) ,
                    Convert.ToByte(tb_tile_data_byte3.Text, 16) ,
                    Convert.ToByte(tb_tile_data_byte4.Text, 16)
                });

            _tmosMod.UpdateTmosModTile(_selectedTileIndex, updatedTile.GetBytes());
        }

        private void btn_miniTile_save_Click(object sender, EventArgs e)
        {
			//WSIndex needed on updatedTile?
			TmosModMiniTile updatedTile = new TmosModMiniTile(new byte[]
			{
				Convert.ToByte(tb_miniTile_data_byte1.Text, 16),
				Convert.ToByte(tb_miniTile_data_byte2.Text, 16),
				Convert.ToByte(tb_miniTile_data_byte3.Text, 16),
				Convert.ToByte(tb_miniTile_data_byte4.Text, 16)
			});
			
			_tmosMod.UpdateMiniTile(_selectedTileIndex, updatedTile.GetBytes());
		}

        private void btn_encounterGroup_save_Click(object sender, EventArgs e)
        {
			TmosRandomEncounterGroup updatedEncounterGroup = new TmosRandomEncounterGroup(
								new byte[]
								{
					Convert.ToByte(rtb_encounterGroups_data.Text.Split()[0], 16),
					Convert.ToByte(rtb_encounterGroups_data.Text.Split()[1], 16),
					Convert.ToByte(rtb_encounterGroups_data.Text.Split()[2], 16)
				});

			_tmosMod.UpdateEncounterGroup(_selectedRandomEncounterGroupIndex, updatedEncounterGroup);
		}

        private void btn_encounterLineup_save_Click(object sender, EventArgs e)
        {
			TmosRandomEncounterLineup updatedEncounterLineup = new TmosRandomEncounterLineup(
                new byte[]
				{
					Convert.ToByte(rtb_encounterLineups_data.Text.Split()[0], 16),
					Convert.ToByte(rtb_encounterLineups_data.Text.Split()[1], 16),
					Convert.ToByte(rtb_encounterLineups_data.Text.Split()[2], 16),
					Convert.ToByte(rtb_encounterLineups_data.Text.Split()[3], 16),
					Convert.ToByte(rtb_encounterLineups_data.Text.Split()[4], 16),
					Convert.ToByte(rtb_encounterLineups_data.Text.Split()[5], 16),
					Convert.ToByte(rtb_encounterLineups_data.Text.Split()[6], 16),
					Convert.ToByte(rtb_encounterLineups_data.Text.Split()[7], 16)
				});

			_tmosMod.UpdateEncounterLineup(_selectedRandomEncounterLineupIndex, updatedEncounterLineup);
		}

        private void btn_refreshWorldScreenList_Click(object sender, EventArgs e)
        {
            _tmosMod.GetTmosModWorldScreens(true);
            _selectedWorldScreenIndex = 0;
            SelectWorldScreen(0);
        }
        public void Output(string s)
        {
            tb_output.Text += s + Environment.NewLine;
        }

       
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pb_worldMap_Click(object sender, EventArgs e)
        {
            
            Point mousePosition = pb_worldMap.PointToClient(Cursor.Position);

            int tileX = mousePosition.X / (int)nud_drawOptions_map_tileSize.Value;
            int tileY = mousePosition.Y / (int)nud_drawOptions_map_tileSize.Value;

            Point worldScreenCoords = _drawer.Map.GetWorldScreenCoordsFromGrid(tileX, tileY);

            if (lv_worldScreens.Items.Count > 0)
            {
				
				if (_drawer.Map._trimmedWorldScreenIds.GetLength(0) > worldScreenCoords.X && _drawer.Map._trimmedWorldScreenIds.GetLength(1) > worldScreenCoords.Y && worldScreenCoords.X >= 0 && worldScreenCoords.Y >= 0)
                {
                    int selectedWorldIndex = _drawer.Map._trimmedWorldScreenIds[worldScreenCoords.X, worldScreenCoords.Y];

                    if (selectedWorldIndex > -1)
                    {
                        lv_worldScreens.Items[selectedWorldIndex].Selected = true;
                        lv_worldScreens.Items[selectedWorldIndex].Focused = true;
                        lv_worldScreens.TopItem = lv_worldScreens.Items[selectedWorldIndex];
                        lv_worldScreens.Select();
                    }
                }
            }
                //MouseEventArgs me = (MouseEventArgs)e;
                //if (me.Button == System.Windows.Forms.MouseButtons.Right)
                //{
                //    tb_screencollect.Text += "0x" + selectedWorldIndex.ToString("X2") + ",";
                //}
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl != null && tabControl.SelectedTab == tab_worldScreen)
            {
                pb_worldScreen.Refresh();       
            }
            else if (tabControl != null && tabControl.SelectedTab == tab_map)
            {
                pb_worldMap.Refresh();
            }
            Draw();
        }

        private void menu_shuffleWSTileSections_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            _renderingEnabled = false;
            lb_tileSection_top.SelectedIndex = new Random().Next(lb_tileSection_top.Items.Count);

            lb_tileSection_bottom.SelectedIndex = new Random().Next(lb_tileSection_bottom.Items.Count);

            _renderingEnabled = true;

            Draw();

        }

        private void shuffleTileSectionsKeepCompatableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            _renderingEnabled = false;

          

            TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);
            byte originalTopTiles = currentWS.TopTiles;
            byte originalBottomTiles = currentWS.BottomTiles;


          bool complete = false;
            int tries = 0;
            while(!complete)
            {
                lb_tileSection_top.SelectedIndex = random.Next(lb_tileSection_top.Items.Count);
                lb_tileSection_bottom.SelectedIndex = new Random().Next(lb_tileSection_bottom.Items.Count);

                currentWS = _tmosMod.GetTmosModWorldScreen(_selectedWorldScreenIndex);

                int index_rightWS = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(_selectedWorldScreenIndex, Direction.Right);
                int index_leftWS = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(_selectedWorldScreenIndex, Direction.Left);
                int index_topWS = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(_selectedWorldScreenIndex, Direction.Up);
                int index_bottomWS = _tmosMod.GetTmosWorldScreenNeighborAbsoluteIndex(_selectedWorldScreenIndex, Direction.Down);

                TmosModWorldScreen rightWS = _tmosMod.GetTmosModWorldScreen(index_rightWS);
                TmosModWorldScreen leftWS = _tmosMod.GetTmosModWorldScreen(index_leftWS);
                TmosModWorldScreen topWS = _tmosMod.GetTmosModWorldScreen(index_topWS);
              TmosModWorldScreen bottomWS = _tmosMod.GetTmosModWorldScreen(index_bottomWS);

                bool rightScreenIsCompatable = currentWS.CollisionTest_Right_IsCompatable(rightWS);
                bool leftScreenIsCompatable = currentWS.CollisionTest_Left_IsCompatable(leftWS);
                bool topScreenIsCompatable = currentWS.CollisionTest_Up_IsCompatable(topWS);
                bool bottomScreenIsCompatable = currentWS.CollisionTest_Down_IsCompatable(bottomWS);

                Console.WriteLine($"{leftScreenIsCompatable} {topScreenIsCompatable} {rightScreenIsCompatable} {bottomScreenIsCompatable}");

                 if (rightScreenIsCompatable && leftScreenIsCompatable && topScreenIsCompatable && bottomScreenIsCompatable)
               // if (rightScreenIsCompatable) 
                {
                    complete = true;
                    Output("Succeeded shuffling");
                    
                }
                else
                {
                    tries++;
                }

                if (tries > 2000)
                {
                    Output("Failed to shuffle and be compatible");
                    currentWS.TopTiles = originalTopTiles;
                    currentWS.BottomTiles = originalBottomTiles;
                    _tmosMod.RefreshWorldScreen(currentWS);
                    complete = true;

                }
            }

          

            //lb_tileSection_top.SelectedIndex = new Random().Next(lb_tileSection_top.Items.Count);

            //lb_tileSection_bottom.SelectedIndex = new Random().Next(lb_tileSection_bottom.Items.Count);

            _renderingEnabled = true;

            Draw();
        }

        private void shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer_shuffle.Start();
         
        }

        private void timer_shuffle_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int gridDimensionX = _drawer.Map._trimmedWorldScreenIds.GetLength(0);
            int gridDimensionY = _drawer.Map._trimmedWorldScreenIds.GetLength(1);

            int randomlyPickedWSIndex = _drawer.Map._trimmedWorldScreenIds[random.Next(gridDimensionX), random.Next(gridDimensionY)];
            if (randomlyPickedWSIndex != 0)
            {
                Output("Selected WS " + randomlyPickedWSIndex);
                lv_worldScreens.Items[randomlyPickedWSIndex].Selected = true;
                lv_worldScreens.Items[randomlyPickedWSIndex].Focused = true;
                lv_worldScreens.TopItem = lv_worldScreens.Items[randomlyPickedWSIndex];
                lv_worldScreens.Select();
            }
            shuffleTileSectionsKeepCompatableToolStripMenuItem.PerformClick();
        }

        private void cb_shuffling_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_shuffling.Checked)
            {
                timer_shuffle.Start();
            }
            else
            {
                timer_shuffle.Stop();
            }
        }

        private void tb_worldScreen_selectedWorldScreen_data_TextChanged(object sender, EventArgs e)
        {
            btn_worldScreen_save.Enabled = true;
        }

		private void tb_tile_data_byte1_DoubleClick(object sender, EventArgs e)
		{
   //         TmosModTile selectedTile = _tmosMod.Get(_selectedTileIndex);
			//lb_miniTile.SelectedIndex = 
   //         SelectMiniTile()
		}

		private void tb_tile_data_byte2_DoubleClick(object sender, EventArgs e)
		{

		}

		private void tb_tile_data_byte3_DoubleClick(object sender, EventArgs e)
		{

		}

		private void tb_tile_data_byte4_DoubleClick(object sender, EventArgs e)
		{

		}

		private void label16_VisibleChanged(object sender, EventArgs e)
		{

		}
	}
}
