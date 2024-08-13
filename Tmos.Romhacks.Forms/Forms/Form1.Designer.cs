using System.Windows.Forms;
using Tmos.Romhacks.Forms.Controls;

namespace Tmos.Romhacks.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			ListViewGroup listViewGroup1 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Center);
			ListViewItem listViewItem1 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "ParentWorld", System.Drawing.Color.Black, System.Drawing.Color.LightGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem2 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "Ambient Sound"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem3 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "Content"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem4 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "ObjectSet"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem5 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "ScreenIndexRight"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem6 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "ScreenIndexLeft"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem7 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "ScreenIndexDown"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem8 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "ScreenIndexUp"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem9 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "DataPointer"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem10 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "ExitPosition"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem11 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "TopTiles"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem12 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "BottomTiles"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem13 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "WorldScreenColor"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem14 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "SpriteColor"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem15 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "Unknown"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			ListViewItem listViewItem16 = new ListViewItem(new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(null, "Event"), new ListViewItem.ListViewSubItem(null, "0x00", System.Drawing.SystemColors.ButtonFace, System.Drawing.Color.DimGray, new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)), new ListViewItem.ListViewSubItem(null, "") }, -1);
			openFileDialog1 = new OpenFileDialog();
			tb_output = new RichTextBox();
			lb_tileSection_top = new ListBox();
			lb_tileSection_bottom = new ListBox();
			groupBox1 = new GroupBox();
			btnlbl_worldSection_bottomTiles_view = new Label();
			btnlbl_worldSection_topTiles_view = new Label();
			lbl_worldScreenTileDataOffsets = new Label();
			label2 = new Label();
			label1 = new Label();
			lv_worldScreens = new ListView();
			col_WorldScreenId = new ColumnHeader();
			col_ParentWorld = new ColumnHeader();
			col_AmbientSound = new ColumnHeader();
			col_Content = new ColumnHeader();
			col_ObjectSet = new ColumnHeader();
			col_ScreenIndexRight = new ColumnHeader();
			col_ScreenIndexLeft = new ColumnHeader();
			col_ScreenIndexDown = new ColumnHeader();
			col_ScreenIndexUp = new ColumnHeader();
			col_DataPointer = new ColumnHeader();
			col_ExitPosition = new ColumnHeader();
			col_TopTiles = new ColumnHeader();
			col_BottomTiles = new ColumnHeader();
			col_WorldScreenColor = new ColumnHeader();
			col_SpritesColor = new ColumnHeader();
			col_Unknown = new ColumnHeader();
			col_Event = new ColumnHeader();
			tb_direction_up = new TextBox();
			tb_direction_left = new TextBox();
			tb_direction_right = new TextBox();
			btn_move_right = new Button();
			btn_move_left = new Button();
			groupBox2 = new GroupBox();
			btn_move_down = new Button();
			tb_direction_down = new TextBox();
			btn_move_up = new Button();
			saveFileDialog1 = new SaveFileDialog();
			cb_link_back = new CheckBox();
			button1 = new Button();
			btn_testDirections = new Button();
			tabControl1 = new TabControl();
			tab_map = new TabPage();
			groupBox4 = new GroupBox();
			label27 = new Label();
			tb_map_area_update_AmbientSound = new TextBox();
			label25 = new Label();
			tb_map_area_update_WorldColor = new TextBox();
			label26 = new Label();
			tb_map_area_update_SpriteColor = new TextBox();
			label24 = new Label();
			tb_map_area_update_DataPointer = new TextBox();
			btn_map_saveAreaScreens = new Button();
			label23 = new Label();
			tb_map_area_update_ParentWorld = new TextBox();
			btn_map_fix_screen_references = new Button();
			pb_worldMap = new TmosPictureBox();
			tab_worldScreen = new TabPage();
			pb_worldScreen = new TmosPictureBox();
			gb_worldScreen = new GroupBox();
			tb_worldScreen_selectedWorldScreen_data = new RichTextBox();
			label16 = new Label();
			btn_worldScreen_save = new Button();
			comboBox_worldScreen_content = new ComboBox();
			tab_tileSection = new TabPage();
			gb_tileSection = new GroupBox();
			label7 = new Label();
			lb_tileSection = new ListBox();
			label6 = new Label();
			btn_tileSection_data_save = new Button();
			lv_tileSection_values = new ListView();
			rtb_tileSection_data = new RichTextBox();
			gb_microTile = new GroupBox();
			label10 = new Label();
			gb_miniTile = new GroupBox();
			btn_miniTile_save = new Button();
			label9 = new Label();
			tb_miniTile_data_byte4 = new TextBox();
			tb_miniTile_data_byte3 = new TextBox();
			tb_miniTile_data_byte2 = new TextBox();
			tb_miniTile_data_byte1 = new TextBox();
			lb_miniTile = new ListBox();
			groupBox5 = new GroupBox();
			label5 = new Label();
			tb_worldScreenTile = new TextBox();
			lb_worldScreenTiles = new ListBox();
			gb_tile = new GroupBox();
			label3 = new Label();
			label13 = new Label();
			btn_tile_save = new Button();
			label8 = new Label();
			pb_tile_Image = new PictureBox();
			tb_tile_data_byte4 = new TextBox();
			tb_tile_data_byte3 = new TextBox();
			tb_tile_data_byte2 = new TextBox();
			tb_tile_data_byte1 = new TextBox();
			lb_tile = new ListBox();
			tab_encounters = new TabPage();
			gb_encounterLineups = new GroupBox();
			btn_encounterLineup_save = new Button();
			label12 = new Label();
			rtb_encounterLineups_data = new RichTextBox();
			lb_encounterLinups = new ListBox();
			gb_encounterGroups = new GroupBox();
			btn_encounterGroup_save = new Button();
			label15 = new Label();
			rtb_encounterGroups_data = new RichTextBox();
			lb_encounterGroups = new ListBox();
			tab_variables = new TabPage();
			label19 = new Label();
			groupBox3 = new GroupBox();
			btn_knownVariables_selectedVariable_save = new Button();
			label20 = new Label();
			label22 = new Label();
			tb_knownVariables_selectedVariable_description = new TextBox();
			label21 = new Label();
			lbl_knownVariables_selectedVariable_variableName = new Label();
			tb_knownVariables_selectedVariable_value = new TextBox();
			label18 = new Label();
			label17 = new Label();
			lv_knownVariables = new ListView();
			lv_knownVariables_col_name = new ColumnHeader();
			lv_knownVariables_col_value = new ColumnHeader();
			menu_pb_worldMap_rightClick = new ContextMenuStrip(components);
			menu_pb_worldMap_moveWorldScreen = new ToolStripMenuItem();
			menu_pb_worldMap_copyWorldSceen = new ToolStripMenuItem();
			menu_pb_worldMap_pasteWorldSceen = new ToolStripMenuItem();
			lbl_worldScreen_info = new Label();
			lbl_worldScreen_relativeIndex = new Label();
			label14 = new Label();
			tb_selectedWorldScreenIndex = new TextBox();
			btn_refreshWorldScreenList = new Button();
			gb_drawOptions = new GroupBox();
			groupBox9 = new GroupBox();
			label11 = new Label();
			nud_drawOptions_map_tileSize = new NumericUpDown();
			groupBox8 = new GroupBox();
			cb_drawOptions_worldScreen_showInfo = new CheckBox();
			cb_drawOptions_worldScreen_showBorders = new CheckBox();
			label4 = new Label();
			nud_drawOptions_worldScreen_showTileImages = new NumericUpDown();
			groupBox7 = new GroupBox();
			cb_drawOptions_worldScreenTile_showCollision = new CheckBox();
			cb_drawOptions_worldScreenTile_showImage = new CheckBox();
			cb_drawOptions_worldScreenTile_showInfo = new CheckBox();
			btn_redraw_worldScreen = new Button();
			bindingSource1 = new BindingSource(components);
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			menu_loadDefaultRom = new ToolStripMenuItem();
			menu_loadRom = new ToolStripMenuItem();
			menu_saveRom = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			exitToolStripMenuItem = new ToolStripMenuItem();
			worldScreenToolStripMenuItem = new ToolStripMenuItem();
			menu_shuffleWSTileSections = new ToolStripMenuItem();
			shuffleTileSectionsKeepCompatableToolStripMenuItem = new ToolStripMenuItem();
			shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem = new ToolStripMenuItem();
			btn_loadDefaultRom = new Button();
			col_name = new ColumnHeader();
			col_value = new ColumnHeader();
			col_hint = new ColumnHeader();
			lv_variables = new ListView();
			timer_shuffle = new Timer(components);
			cb_shuffling = new CheckBox();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			tabControl1.SuspendLayout();
			tab_map.SuspendLayout();
			groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb_worldMap).BeginInit();
			tab_worldScreen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb_worldScreen).BeginInit();
			gb_worldScreen.SuspendLayout();
			tab_tileSection.SuspendLayout();
			gb_tileSection.SuspendLayout();
			gb_microTile.SuspendLayout();
			gb_miniTile.SuspendLayout();
			groupBox5.SuspendLayout();
			gb_tile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb_tile_Image).BeginInit();
			tab_encounters.SuspendLayout();
			gb_encounterLineups.SuspendLayout();
			gb_encounterGroups.SuspendLayout();
			tab_variables.SuspendLayout();
			groupBox3.SuspendLayout();
			menu_pb_worldMap_rightClick.SuspendLayout();
			gb_drawOptions.SuspendLayout();
			groupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nud_drawOptions_map_tileSize).BeginInit();
			groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nud_drawOptions_worldScreen_showTileImages).BeginInit();
			groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// tb_output
			// 
			tb_output.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			tb_output.ForeColor = System.Drawing.Color.Gainsboro;
			tb_output.Location = new System.Drawing.Point(0, 932);
			tb_output.Margin = new Padding(4, 3, 4, 3);
			tb_output.Name = "tb_output";
			tb_output.Size = new System.Drawing.Size(489, 86);
			tb_output.TabIndex = 1;
			tb_output.Text = "";
			// 
			// lb_tileSection_top
			// 
			lb_tileSection_top.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			lb_tileSection_top.ForeColor = System.Drawing.SystemColors.HotTrack;
			lb_tileSection_top.FormattingEnabled = true;
			lb_tileSection_top.ItemHeight = 13;
			lb_tileSection_top.Location = new System.Drawing.Point(5, 91);
			lb_tileSection_top.Margin = new Padding(2);
			lb_tileSection_top.Name = "lb_tileSection_top";
			lb_tileSection_top.Size = new System.Drawing.Size(149, 238);
			lb_tileSection_top.TabIndex = 4;
			lb_tileSection_top.SelectedIndexChanged += lb_tileSection_top_SelectedIndexChanged;
			// 
			// lb_tileSection_bottom
			// 
			lb_tileSection_bottom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			lb_tileSection_bottom.ForeColor = System.Drawing.SystemColors.HotTrack;
			lb_tileSection_bottom.FormattingEnabled = true;
			lb_tileSection_bottom.ItemHeight = 13;
			lb_tileSection_bottom.Location = new System.Drawing.Point(159, 91);
			lb_tileSection_bottom.Margin = new Padding(2);
			lb_tileSection_bottom.Name = "lb_tileSection_bottom";
			lb_tileSection_bottom.Size = new System.Drawing.Size(149, 238);
			lb_tileSection_bottom.TabIndex = 5;
			lb_tileSection_bottom.SelectedIndexChanged += lb_tileSection_bottom_SelectedIndexChanged;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnlbl_worldSection_bottomTiles_view);
			groupBox1.Controls.Add(btnlbl_worldSection_topTiles_view);
			groupBox1.Controls.Add(lbl_worldScreenTileDataOffsets);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(lb_tileSection_bottom);
			groupBox1.Controls.Add(lb_tileSection_top);
			groupBox1.Location = new System.Drawing.Point(512, 7);
			groupBox1.Margin = new Padding(2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(2);
			groupBox1.Size = new System.Drawing.Size(314, 355);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "Tile Sections";
			// 
			// btnlbl_worldSection_bottomTiles_view
			// 
			btnlbl_worldSection_bottomTiles_view.AutoSize = true;
			btnlbl_worldSection_bottomTiles_view.BorderStyle = BorderStyle.FixedSingle;
			btnlbl_worldSection_bottomTiles_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnlbl_worldSection_bottomTiles_view.Location = new System.Drawing.Point(275, 75);
			btnlbl_worldSection_bottomTiles_view.Margin = new Padding(4, 0, 4, 0);
			btnlbl_worldSection_bottomTiles_view.Name = "btnlbl_worldSection_bottomTiles_view";
			btnlbl_worldSection_bottomTiles_view.Size = new System.Drawing.Size(36, 15);
			btnlbl_worldSection_bottomTiles_view.TabIndex = 20;
			btnlbl_worldSection_bottomTiles_view.Text = "View";
			btnlbl_worldSection_bottomTiles_view.Click += btnlbl_worldSection_bottomTiles_view_Click;
			// 
			// btnlbl_worldSection_topTiles_view
			// 
			btnlbl_worldSection_topTiles_view.AutoSize = true;
			btnlbl_worldSection_topTiles_view.BorderStyle = BorderStyle.FixedSingle;
			btnlbl_worldSection_topTiles_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnlbl_worldSection_topTiles_view.Location = new System.Drawing.Point(121, 75);
			btnlbl_worldSection_topTiles_view.Margin = new Padding(4, 0, 4, 0);
			btnlbl_worldSection_topTiles_view.Name = "btnlbl_worldSection_topTiles_view";
			btnlbl_worldSection_topTiles_view.Size = new System.Drawing.Size(36, 15);
			btnlbl_worldSection_topTiles_view.TabIndex = 19;
			btnlbl_worldSection_topTiles_view.Text = "View";
			btnlbl_worldSection_topTiles_view.Click += btnlbl_worldSection_topTiles_view_Click_1;
			// 
			// lbl_worldScreenTileDataOffsets
			// 
			lbl_worldScreenTileDataOffsets.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_worldScreenTileDataOffsets.Location = new System.Drawing.Point(6, 18);
			lbl_worldScreenTileDataOffsets.Margin = new Padding(4, 0, 4, 0);
			lbl_worldScreenTileDataOffsets.Name = "lbl_worldScreenTileDataOffsets";
			lbl_worldScreenTileDataOffsets.Size = new System.Drawing.Size(148, 55);
			lbl_worldScreenTileDataOffsets.TabIndex = 18;
			lbl_worldScreenTileDataOffsets.Text = "DataPointer:\r\nTop Tiles Offset:\r\nBottom TIles Offset:";
			lbl_worldScreenTileDataOffsets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(159, 74);
			label2.Margin = new Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 15);
			label2.TabIndex = 8;
			label2.Text = "Bottom";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(5, 75);
			label1.Margin = new Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(26, 15);
			label1.TabIndex = 7;
			label1.Text = "Top";
			// 
			// lv_worldScreens
			// 
			lv_worldScreens.Alignment = ListViewAlignment.SnapToGrid;
			lv_worldScreens.Columns.AddRange(new ColumnHeader[] { col_WorldScreenId, col_ParentWorld, col_AmbientSound, col_Content, col_ObjectSet, col_ScreenIndexRight, col_ScreenIndexLeft, col_ScreenIndexDown, col_ScreenIndexUp, col_DataPointer, col_ExitPosition, col_TopTiles, col_BottomTiles, col_WorldScreenColor, col_SpritesColor, col_Unknown, col_Event });
			lv_worldScreens.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lv_worldScreens.FullRowSelect = true;
			lv_worldScreens.GridLines = true;
			lv_worldScreens.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			lv_worldScreens.Location = new System.Drawing.Point(6, 65);
			lv_worldScreens.Margin = new Padding(4, 3, 4, 3);
			lv_worldScreens.MultiSelect = false;
			lv_worldScreens.Name = "lv_worldScreens";
			lv_worldScreens.Size = new System.Drawing.Size(474, 303);
			lv_worldScreens.TabIndex = 14;
			lv_worldScreens.UseCompatibleStateImageBehavior = false;
			lv_worldScreens.View = View.Details;
			lv_worldScreens.SelectedIndexChanged += lv_worldScreens_SelectedIndexChanged;
			// 
			// col_WorldScreenId
			// 
			col_WorldScreenId.Text = "ScreenID";
			col_WorldScreenId.Width = 55;
			// 
			// col_ParentWorld
			// 
			col_ParentWorld.Text = "ParentWorld";
			col_ParentWorld.TextAlign = HorizontalAlignment.Center;
			col_ParentWorld.Width = 25;
			// 
			// col_AmbientSound
			// 
			col_AmbientSound.Text = "AmbientSound";
			col_AmbientSound.TextAlign = HorizontalAlignment.Center;
			col_AmbientSound.Width = 25;
			// 
			// col_Content
			// 
			col_Content.Text = "Content";
			col_Content.TextAlign = HorizontalAlignment.Center;
			col_Content.Width = 25;
			// 
			// col_ObjectSet
			// 
			col_ObjectSet.Text = "ObjectSet";
			col_ObjectSet.TextAlign = HorizontalAlignment.Center;
			col_ObjectSet.Width = 25;
			// 
			// col_ScreenIndexRight
			// 
			col_ScreenIndexRight.Text = "ScreenIndexRight";
			col_ScreenIndexRight.TextAlign = HorizontalAlignment.Center;
			col_ScreenIndexRight.Width = 25;
			// 
			// col_ScreenIndexLeft
			// 
			col_ScreenIndexLeft.Text = "ScreenIndexLeft";
			col_ScreenIndexLeft.TextAlign = HorizontalAlignment.Center;
			col_ScreenIndexLeft.Width = 25;
			// 
			// col_ScreenIndexDown
			// 
			col_ScreenIndexDown.Text = "ScreenIndexDown";
			col_ScreenIndexDown.TextAlign = HorizontalAlignment.Center;
			col_ScreenIndexDown.Width = 25;
			// 
			// col_ScreenIndexUp
			// 
			col_ScreenIndexUp.Text = "ScreenIndexUp";
			col_ScreenIndexUp.TextAlign = HorizontalAlignment.Center;
			col_ScreenIndexUp.Width = 25;
			// 
			// col_DataPointer
			// 
			col_DataPointer.Text = "DataPointer";
			col_DataPointer.TextAlign = HorizontalAlignment.Center;
			col_DataPointer.Width = 25;
			// 
			// col_ExitPosition
			// 
			col_ExitPosition.Text = "ExitPosition";
			col_ExitPosition.TextAlign = HorizontalAlignment.Center;
			col_ExitPosition.Width = 25;
			// 
			// col_TopTiles
			// 
			col_TopTiles.Text = "TopTiles";
			col_TopTiles.TextAlign = HorizontalAlignment.Center;
			col_TopTiles.Width = 25;
			// 
			// col_BottomTiles
			// 
			col_BottomTiles.Text = "BottomTiles";
			col_BottomTiles.TextAlign = HorizontalAlignment.Center;
			col_BottomTiles.Width = 25;
			// 
			// col_WorldScreenColor
			// 
			col_WorldScreenColor.Text = "WorldScreenColor";
			col_WorldScreenColor.TextAlign = HorizontalAlignment.Center;
			col_WorldScreenColor.Width = 25;
			// 
			// col_SpritesColor
			// 
			col_SpritesColor.Text = "SpritesColor";
			col_SpritesColor.TextAlign = HorizontalAlignment.Center;
			col_SpritesColor.Width = 25;
			// 
			// col_Unknown
			// 
			col_Unknown.Text = "Unknown";
			col_Unknown.TextAlign = HorizontalAlignment.Center;
			col_Unknown.Width = 25;
			// 
			// col_Event
			// 
			col_Event.Text = "Event";
			col_Event.TextAlign = HorizontalAlignment.Center;
			col_Event.Width = 25;
			// 
			// tb_direction_up
			// 
			tb_direction_up.BorderStyle = BorderStyle.FixedSingle;
			tb_direction_up.Location = new System.Drawing.Point(79, 13);
			tb_direction_up.Margin = new Padding(2);
			tb_direction_up.Name = "tb_direction_up";
			tb_direction_up.Size = new System.Drawing.Size(33, 23);
			tb_direction_up.TabIndex = 7;
			tb_direction_up.TextChanged += tb_direction_up_TextChanged;
			// 
			// tb_direction_left
			// 
			tb_direction_left.BorderStyle = BorderStyle.FixedSingle;
			tb_direction_left.Cursor = Cursors.IBeam;
			tb_direction_left.Location = new System.Drawing.Point(5, 51);
			tb_direction_left.Margin = new Padding(2);
			tb_direction_left.Name = "tb_direction_left";
			tb_direction_left.Size = new System.Drawing.Size(35, 23);
			tb_direction_left.TabIndex = 8;
			tb_direction_left.TextChanged += tb_direction_left_TextChanged;
			// 
			// tb_direction_right
			// 
			tb_direction_right.BorderStyle = BorderStyle.FixedSingle;
			tb_direction_right.Location = new System.Drawing.Point(152, 52);
			tb_direction_right.Margin = new Padding(2);
			tb_direction_right.Name = "tb_direction_right";
			tb_direction_right.Size = new System.Drawing.Size(35, 23);
			tb_direction_right.TabIndex = 9;
			tb_direction_right.TextChanged += tb_direction_right_TextChanged;
			// 
			// btn_move_right
			// 
			btn_move_right.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
			btn_move_right.Location = new System.Drawing.Point(114, 51);
			btn_move_right.Margin = new Padding(2);
			btn_move_right.Name = "btn_move_right";
			btn_move_right.Size = new System.Drawing.Size(35, 23);
			btn_move_right.TabIndex = 11;
			btn_move_right.Text = "→";
			btn_move_right.UseVisualStyleBackColor = true;
			btn_move_right.Click += btn_move_right_Click;
			// 
			// btn_move_left
			// 
			btn_move_left.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
			btn_move_left.Location = new System.Drawing.Point(42, 50);
			btn_move_left.Margin = new Padding(2);
			btn_move_left.Name = "btn_move_left";
			btn_move_left.Size = new System.Drawing.Size(35, 23);
			btn_move_left.TabIndex = 12;
			btn_move_left.Text = "←";
			btn_move_left.UseVisualStyleBackColor = true;
			btn_move_left.Click += btn_move_left_Click;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btn_move_down);
			groupBox2.Controls.Add(tb_direction_down);
			groupBox2.Controls.Add(btn_move_up);
			groupBox2.Controls.Add(tb_direction_left);
			groupBox2.Controls.Add(btn_move_right);
			groupBox2.Controls.Add(btn_move_left);
			groupBox2.Controls.Add(tb_direction_up);
			groupBox2.Controls.Add(tb_direction_right);
			groupBox2.Location = new System.Drawing.Point(6, 242);
			groupBox2.Margin = new Padding(2);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(2);
			groupBox2.Size = new System.Drawing.Size(195, 120);
			groupBox2.TabIndex = 13;
			groupBox2.TabStop = false;
			groupBox2.Text = "Directions";
			// 
			// btn_move_down
			// 
			btn_move_down.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
			btn_move_down.Location = new System.Drawing.Point(78, 62);
			btn_move_down.Margin = new Padding(2);
			btn_move_down.Name = "btn_move_down";
			btn_move_down.Size = new System.Drawing.Size(34, 24);
			btn_move_down.TabIndex = 15;
			btn_move_down.Text = "↓";
			btn_move_down.UseVisualStyleBackColor = true;
			btn_move_down.Click += btn_move_down_Click;
			// 
			// tb_direction_down
			// 
			tb_direction_down.BorderStyle = BorderStyle.FixedSingle;
			tb_direction_down.Location = new System.Drawing.Point(78, 88);
			tb_direction_down.Margin = new Padding(2);
			tb_direction_down.Name = "tb_direction_down";
			tb_direction_down.Size = new System.Drawing.Size(35, 23);
			tb_direction_down.TabIndex = 14;
			tb_direction_down.TextChanged += tb_direction_down_TextChanged;
			// 
			// btn_move_up
			// 
			btn_move_up.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_move_up.Location = new System.Drawing.Point(78, 35);
			btn_move_up.Margin = new Padding(2);
			btn_move_up.Name = "btn_move_up";
			btn_move_up.Size = new System.Drawing.Size(34, 23);
			btn_move_up.TabIndex = 13;
			btn_move_up.Text = "↑";
			btn_move_up.UseVisualStyleBackColor = true;
			btn_move_up.Click += btn_move_up_Click;
			// 
			// cb_link_back
			// 
			cb_link_back.AutoSize = true;
			cb_link_back.Checked = true;
			cb_link_back.CheckState = CheckState.Checked;
			cb_link_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_link_back.Location = new System.Drawing.Point(208, 348);
			cb_link_back.Margin = new Padding(2);
			cb_link_back.Name = "cb_link_back";
			cb_link_back.Size = new System.Drawing.Size(95, 16);
			cb_link_back.TabIndex = 16;
			cb_link_back.Text = "Link Screen Back";
			cb_link_back.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.SystemColors.HotTrack;
			button1.Location = new System.Drawing.Point(206, 324);
			button1.Margin = new Padding(2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(85, 23);
			button1.TabIndex = 16;
			button1.Text = "Save Directions";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// btn_testDirections
			// 
			btn_testDirections.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_testDirections.Location = new System.Drawing.Point(206, 299);
			btn_testDirections.Margin = new Padding(2);
			btn_testDirections.Name = "btn_testDirections";
			btn_testDirections.Size = new System.Drawing.Size(85, 23);
			btn_testDirections.TabIndex = 17;
			btn_testDirections.Text = "Test Directions";
			btn_testDirections.UseVisualStyleBackColor = true;
			btn_testDirections.Click += btn_testDirections_Click;
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tab_map);
			tabControl1.Controls.Add(tab_worldScreen);
			tabControl1.Controls.Add(tab_tileSection);
			tabControl1.Controls.Add(tab_encounters);
			tabControl1.Controls.Add(tab_variables);
			tabControl1.Location = new System.Drawing.Point(488, 14);
			tabControl1.Margin = new Padding(4, 3, 4, 3);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(890, 1005);
			tabControl1.TabIndex = 19;
			tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
			// 
			// tab_map
			// 
			tab_map.Controls.Add(groupBox4);
			tab_map.Controls.Add(btn_map_fix_screen_references);
			tab_map.Controls.Add(pb_worldMap);
			tab_map.Location = new System.Drawing.Point(4, 24);
			tab_map.Margin = new Padding(4, 3, 4, 3);
			tab_map.Name = "tab_map";
			tab_map.Padding = new Padding(4, 3, 4, 3);
			tab_map.Size = new System.Drawing.Size(882, 977);
			tab_map.TabIndex = 0;
			tab_map.Text = "Map";
			tab_map.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(label27);
			groupBox4.Controls.Add(tb_map_area_update_AmbientSound);
			groupBox4.Controls.Add(label25);
			groupBox4.Controls.Add(tb_map_area_update_WorldColor);
			groupBox4.Controls.Add(label26);
			groupBox4.Controls.Add(tb_map_area_update_SpriteColor);
			groupBox4.Controls.Add(label24);
			groupBox4.Controls.Add(tb_map_area_update_DataPointer);
			groupBox4.Controls.Add(btn_map_saveAreaScreens);
			groupBox4.Controls.Add(label23);
			groupBox4.Controls.Add(tb_map_area_update_ParentWorld);
			groupBox4.Location = new System.Drawing.Point(415, 7);
			groupBox4.Margin = new Padding(4, 3, 4, 3);
			groupBox4.Name = "groupBox4";
			groupBox4.Padding = new Padding(4, 3, 4, 3);
			groupBox4.Size = new System.Drawing.Size(458, 83);
			groupBox4.TabIndex = 10;
			groupBox4.TabStop = false;
			groupBox4.Text = "Area";
			// 
			// label27
			// 
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(138, 18);
			label27.Margin = new Padding(4, 0, 4, 0);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(87, 15);
			label27.TabIndex = 27;
			label27.Text = "AmbientSound";
			// 
			// tb_map_area_update_AmbientSound
			// 
			tb_map_area_update_AmbientSound.BorderStyle = BorderStyle.FixedSingle;
			tb_map_area_update_AmbientSound.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_map_area_update_AmbientSound.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_map_area_update_AmbientSound.Location = new System.Drawing.Point(230, 16);
			tb_map_area_update_AmbientSound.Margin = new Padding(2);
			tb_map_area_update_AmbientSound.Name = "tb_map_area_update_AmbientSound";
			tb_map_area_update_AmbientSound.Size = new System.Drawing.Size(33, 20);
			tb_map_area_update_AmbientSound.TabIndex = 26;
			// 
			// label25
			// 
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(141, 46);
			label25.Margin = new Padding(4, 0, 4, 0);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(68, 15);
			label25.TabIndex = 25;
			label25.Text = "WorldColor";
			// 
			// tb_map_area_update_WorldColor
			// 
			tb_map_area_update_WorldColor.BorderStyle = BorderStyle.FixedSingle;
			tb_map_area_update_WorldColor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_map_area_update_WorldColor.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_map_area_update_WorldColor.Location = new System.Drawing.Point(230, 44);
			tb_map_area_update_WorldColor.Margin = new Padding(2);
			tb_map_area_update_WorldColor.Name = "tb_map_area_update_WorldColor";
			tb_map_area_update_WorldColor.Size = new System.Drawing.Size(33, 20);
			tb_map_area_update_WorldColor.TabIndex = 24;
			// 
			// label26
			// 
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(7, 46);
			label26.Margin = new Padding(4, 0, 4, 0);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(66, 15);
			label26.TabIndex = 23;
			label26.Text = "SpriteColor";
			// 
			// tb_map_area_update_SpriteColor
			// 
			tb_map_area_update_SpriteColor.BorderStyle = BorderStyle.FixedSingle;
			tb_map_area_update_SpriteColor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_map_area_update_SpriteColor.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_map_area_update_SpriteColor.Location = new System.Drawing.Point(90, 44);
			tb_map_area_update_SpriteColor.Margin = new Padding(2);
			tb_map_area_update_SpriteColor.Name = "tb_map_area_update_SpriteColor";
			tb_map_area_update_SpriteColor.Size = new System.Drawing.Size(33, 20);
			tb_map_area_update_SpriteColor.TabIndex = 22;
			// 
			// label24
			// 
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(289, 18);
			label24.Margin = new Padding(4, 0, 4, 0);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(69, 15);
			label24.TabIndex = 21;
			label24.Text = "DataPointer";
			// 
			// tb_map_area_update_DataPointer
			// 
			tb_map_area_update_DataPointer.BorderStyle = BorderStyle.FixedSingle;
			tb_map_area_update_DataPointer.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_map_area_update_DataPointer.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_map_area_update_DataPointer.Location = new System.Drawing.Point(369, 16);
			tb_map_area_update_DataPointer.Margin = new Padding(2);
			tb_map_area_update_DataPointer.Name = "tb_map_area_update_DataPointer";
			tb_map_area_update_DataPointer.Size = new System.Drawing.Size(33, 20);
			tb_map_area_update_DataPointer.TabIndex = 20;
			// 
			// btn_map_saveAreaScreens
			// 
			btn_map_saveAreaScreens.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_map_saveAreaScreens.ForeColor = System.Drawing.SystemColors.HotTrack;
			btn_map_saveAreaScreens.Location = new System.Drawing.Point(356, 46);
			btn_map_saveAreaScreens.Margin = new Padding(2);
			btn_map_saveAreaScreens.Name = "btn_map_saveAreaScreens";
			btn_map_saveAreaScreens.Size = new System.Drawing.Size(97, 23);
			btn_map_saveAreaScreens.TabIndex = 19;
			btn_map_saveAreaScreens.Text = "Save Area Screens";
			btn_map_saveAreaScreens.UseVisualStyleBackColor = true;
			btn_map_saveAreaScreens.Click += btn_map_saveAreaScreens_Click;
			// 
			// label23
			// 
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(7, 18);
			label23.Margin = new Padding(4, 0, 4, 0);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(73, 15);
			label23.TabIndex = 9;
			label23.Text = "ParentWorld";
			// 
			// tb_map_area_update_ParentWorld
			// 
			tb_map_area_update_ParentWorld.BorderStyle = BorderStyle.FixedSingle;
			tb_map_area_update_ParentWorld.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_map_area_update_ParentWorld.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_map_area_update_ParentWorld.Location = new System.Drawing.Point(90, 16);
			tb_map_area_update_ParentWorld.Margin = new Padding(2);
			tb_map_area_update_ParentWorld.Name = "tb_map_area_update_ParentWorld";
			tb_map_area_update_ParentWorld.Size = new System.Drawing.Size(33, 20);
			tb_map_area_update_ParentWorld.TabIndex = 8;
			// 
			// btn_map_fix_screen_references
			// 
			btn_map_fix_screen_references.Location = new System.Drawing.Point(12, 7);
			btn_map_fix_screen_references.Margin = new Padding(4, 3, 4, 3);
			btn_map_fix_screen_references.Name = "btn_map_fix_screen_references";
			btn_map_fix_screen_references.Size = new System.Drawing.Size(184, 27);
			btn_map_fix_screen_references.TabIndex = 4;
			btn_map_fix_screen_references.Text = "Fix WS Neighbor Reference";
			btn_map_fix_screen_references.UseVisualStyleBackColor = true;
			btn_map_fix_screen_references.Visible = false;
			btn_map_fix_screen_references.Click += btn_map_fix_screen_references_Click;
			// 
			// pb_worldMap
			// 
			pb_worldMap.BackColor = System.Drawing.Color.Gainsboro;
			pb_worldMap.DrawOptions = null;
			pb_worldMap.Location = new System.Drawing.Point(12, 97);
			pb_worldMap.Margin = new Padding(4, 3, 4, 3);
			pb_worldMap.Name = "pb_worldMap";
			pb_worldMap.Size = new System.Drawing.Size(866, 878);
			pb_worldMap.TabIndex = 3;
			pb_worldMap.TabStop = false;
			pb_worldMap.UserControlState = null;
			pb_worldMap.WorldScreen = null;
			pb_worldMap.WorldScreenGrid = null;
			pb_worldMap.Click += pb_worldMap_Click;
			// 
			// tab_worldScreen
			// 
			tab_worldScreen.Controls.Add(pb_worldScreen);
			tab_worldScreen.Controls.Add(gb_worldScreen);
			tab_worldScreen.Controls.Add(cb_link_back);
			tab_worldScreen.Controls.Add(button1);
			tab_worldScreen.Controls.Add(btn_testDirections);
			tab_worldScreen.Controls.Add(groupBox2);
			tab_worldScreen.Controls.Add(groupBox1);
			tab_worldScreen.Location = new System.Drawing.Point(4, 24);
			tab_worldScreen.Margin = new Padding(4, 3, 4, 3);
			tab_worldScreen.Name = "tab_worldScreen";
			tab_worldScreen.Padding = new Padding(4, 3, 4, 3);
			tab_worldScreen.Size = new System.Drawing.Size(882, 977);
			tab_worldScreen.TabIndex = 1;
			tab_worldScreen.Text = "WorldScreen";
			tab_worldScreen.UseVisualStyleBackColor = true;
			// 
			// pb_worldScreen
			// 
			pb_worldScreen.BackColor = System.Drawing.Color.Gainsboro;
			pb_worldScreen.DrawOptions = null;
			pb_worldScreen.Location = new System.Drawing.Point(6, 365);
			pb_worldScreen.Margin = new Padding(4, 3, 4, 3);
			pb_worldScreen.Name = "pb_worldScreen";
			pb_worldScreen.Size = new System.Drawing.Size(875, 603);
			pb_worldScreen.TabIndex = 2;
			pb_worldScreen.TabStop = false;
			pb_worldScreen.UserControlState = null;
			pb_worldScreen.WorldScreen = null;
			pb_worldScreen.WorldScreenGrid = null;
			// 
			// gb_worldScreen
			// 
			gb_worldScreen.Controls.Add(tb_worldScreen_selectedWorldScreen_data);
			gb_worldScreen.Controls.Add(label16);
			gb_worldScreen.Controls.Add(btn_worldScreen_save);
			gb_worldScreen.Controls.Add(comboBox_worldScreen_content);
			gb_worldScreen.Location = new System.Drawing.Point(7, 7);
			gb_worldScreen.Margin = new Padding(2);
			gb_worldScreen.Name = "gb_worldScreen";
			gb_worldScreen.Padding = new Padding(2);
			gb_worldScreen.Size = new System.Drawing.Size(499, 216);
			gb_worldScreen.TabIndex = 22;
			gb_worldScreen.TabStop = false;
			gb_worldScreen.Text = "WorldScreen";
			// 
			// tb_worldScreen_selectedWorldScreen_data
			// 
			tb_worldScreen_selectedWorldScreen_data.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			tb_worldScreen_selectedWorldScreen_data.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_worldScreen_selectedWorldScreen_data.Location = new System.Drawing.Point(6, 16);
			tb_worldScreen_selectedWorldScreen_data.Margin = new Padding(4, 3, 4, 3);
			tb_worldScreen_selectedWorldScreen_data.Name = "tb_worldScreen_selectedWorldScreen_data";
			tb_worldScreen_selectedWorldScreen_data.Size = new System.Drawing.Size(133, 191);
			tb_worldScreen_selectedWorldScreen_data.TabIndex = 3;
			tb_worldScreen_selectedWorldScreen_data.Text = "";
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(164, 48);
			label16.Margin = new Padding(4, 0, 4, 0);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(50, 15);
			label16.TabIndex = 21;
			label16.Text = "Content";
			label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btn_worldScreen_save
			// 
			btn_worldScreen_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_worldScreen_save.ForeColor = System.Drawing.SystemColors.HotTrack;
			btn_worldScreen_save.Location = new System.Drawing.Point(161, 15);
			btn_worldScreen_save.Margin = new Padding(2);
			btn_worldScreen_save.Name = "btn_worldScreen_save";
			btn_worldScreen_save.Size = new System.Drawing.Size(97, 23);
			btn_worldScreen_save.TabIndex = 18;
			btn_worldScreen_save.Text = "Save WorldScreen";
			btn_worldScreen_save.UseVisualStyleBackColor = true;
			btn_worldScreen_save.Click += btn_worldScreen_save_Click;
			// 
			// comboBox_worldScreen_content
			// 
			comboBox_worldScreen_content.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			comboBox_worldScreen_content.ForeColor = System.Drawing.SystemColors.HotTrack;
			comboBox_worldScreen_content.FormattingEnabled = true;
			comboBox_worldScreen_content.Location = new System.Drawing.Point(216, 44);
			comboBox_worldScreen_content.Margin = new Padding(2);
			comboBox_worldScreen_content.Name = "comboBox_worldScreen_content";
			comboBox_worldScreen_content.Size = new System.Drawing.Size(279, 21);
			comboBox_worldScreen_content.TabIndex = 20;
			comboBox_worldScreen_content.SelectedIndexChanged += comboBox_worldScreen_content_SelectedIndexChanged;
			// 
			// tab_tileSection
			// 
			tab_tileSection.Controls.Add(gb_tileSection);
			tab_tileSection.Controls.Add(gb_microTile);
			tab_tileSection.Controls.Add(gb_miniTile);
			tab_tileSection.Controls.Add(gb_tile);
			tab_tileSection.Location = new System.Drawing.Point(4, 24);
			tab_tileSection.Margin = new Padding(4, 3, 4, 3);
			tab_tileSection.Name = "tab_tileSection";
			tab_tileSection.Size = new System.Drawing.Size(882, 977);
			tab_tileSection.TabIndex = 2;
			tab_tileSection.Text = "TileSection";
			tab_tileSection.UseVisualStyleBackColor = true;
			// 
			// gb_tileSection
			// 
			gb_tileSection.Controls.Add(label7);
			gb_tileSection.Controls.Add(lb_tileSection);
			gb_tileSection.Controls.Add(label6);
			gb_tileSection.Controls.Add(btn_tileSection_data_save);
			gb_tileSection.Controls.Add(lv_tileSection_values);
			gb_tileSection.Controls.Add(rtb_tileSection_data);
			gb_tileSection.Location = new System.Drawing.Point(4, 3);
			gb_tileSection.Margin = new Padding(4, 3, 4, 3);
			gb_tileSection.Name = "gb_tileSection";
			gb_tileSection.Padding = new Padding(4, 3, 4, 3);
			gb_tileSection.Size = new System.Drawing.Size(738, 542);
			gb_tileSection.TabIndex = 22;
			gb_tileSection.TabStop = false;
			gb_tileSection.Text = "TileSection";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.ForeColor = System.Drawing.SystemColors.HotTrack;
			label7.Location = new System.Drawing.Point(163, 227);
			label7.Margin = new Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(31, 15);
			label7.TabIndex = 34;
			label7.Text = "Data";
			// 
			// lb_tileSection
			// 
			lb_tileSection.FormattingEnabled = true;
			lb_tileSection.ItemHeight = 15;
			lb_tileSection.Location = new System.Drawing.Point(16, 32);
			lb_tileSection.Margin = new Padding(2);
			lb_tileSection.Name = "lb_tileSection";
			lb_tileSection.Size = new System.Drawing.Size(140, 499);
			lb_tileSection.TabIndex = 8;
			lb_tileSection.SelectedIndexChanged += lb_tileSection_SelectedIndexChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(164, 6);
			label6.Margin = new Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(90, 15);
			label6.TabIndex = 18;
			label6.Text = "TileSection Tiles";
			// 
			// btn_tileSection_data_save
			// 
			btn_tileSection_data_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_tileSection_data_save.ForeColor = System.Drawing.SystemColors.HotTrack;
			btn_tileSection_data_save.Location = new System.Drawing.Point(524, 242);
			btn_tileSection_data_save.Margin = new Padding(4, 3, 4, 3);
			btn_tileSection_data_save.Name = "btn_tileSection_data_save";
			btn_tileSection_data_save.Size = new System.Drawing.Size(105, 27);
			btn_tileSection_data_save.TabIndex = 17;
			btn_tileSection_data_save.Text = "Save TileSection Tile";
			btn_tileSection_data_save.UseVisualStyleBackColor = true;
			btn_tileSection_data_save.Click += btn_tileSection_data_save_Click;
			// 
			// lv_tileSection_values
			// 
			lv_tileSection_values.Activation = ItemActivation.TwoClick;
			lv_tileSection_values.BackColor = System.Drawing.Color.Gainsboro;
			lv_tileSection_values.BorderStyle = BorderStyle.FixedSingle;
			lv_tileSection_values.GridLines = true;
			lv_tileSection_values.HeaderStyle = ColumnHeaderStyle.None;
			lv_tileSection_values.Location = new System.Drawing.Point(163, 22);
			lv_tileSection_values.Margin = new Padding(4, 3, 4, 3);
			lv_tileSection_values.MultiSelect = false;
			lv_tileSection_values.Name = "lv_tileSection_values";
			lv_tileSection_values.Size = new System.Drawing.Size(350, 202);
			lv_tileSection_values.TabIndex = 15;
			lv_tileSection_values.TileSize = new System.Drawing.Size(50, 30);
			lv_tileSection_values.UseCompatibleStateImageBehavior = false;
			lv_tileSection_values.View = View.SmallIcon;
			lv_tileSection_values.SelectedIndexChanged += lv_tileSection_values_SelectedIndexChanged;
			// 
			// rtb_tileSection_data
			// 
			rtb_tileSection_data.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			rtb_tileSection_data.ForeColor = System.Drawing.SystemColors.HotTrack;
			rtb_tileSection_data.Location = new System.Drawing.Point(163, 242);
			rtb_tileSection_data.Margin = new Padding(4, 3, 4, 3);
			rtb_tileSection_data.Name = "rtb_tileSection_data";
			rtb_tileSection_data.Size = new System.Drawing.Size(350, 106);
			rtb_tileSection_data.TabIndex = 16;
			rtb_tileSection_data.Text = "";
			// 
			// gb_microTile
			// 
			gb_microTile.Controls.Add(label10);
			gb_microTile.Enabled = false;
			gb_microTile.Location = new System.Drawing.Point(566, 553);
			gb_microTile.Margin = new Padding(4, 3, 4, 3);
			gb_microTile.Name = "gb_microTile";
			gb_microTile.Padding = new Padding(4, 3, 4, 3);
			gb_microTile.Size = new System.Drawing.Size(128, 89);
			gb_microTile.TabIndex = 21;
			gb_microTile.TabStop = false;
			gb_microTile.Text = "MicroTile";
			// 
			// label10
			// 
			label10.Location = new System.Drawing.Point(19, 32);
			label10.Margin = new Padding(4, 0, 4, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(77, 35);
			label10.TabIndex = 0;
			label10.Text = "Unknown";
			// 
			// gb_miniTile
			// 
			gb_miniTile.Controls.Add(btn_miniTile_save);
			gb_miniTile.Controls.Add(label9);
			gb_miniTile.Controls.Add(tb_miniTile_data_byte4);
			gb_miniTile.Controls.Add(tb_miniTile_data_byte3);
			gb_miniTile.Controls.Add(tb_miniTile_data_byte2);
			gb_miniTile.Controls.Add(tb_miniTile_data_byte1);
			gb_miniTile.Controls.Add(lb_miniTile);
			gb_miniTile.Controls.Add(groupBox5);
			gb_miniTile.Location = new System.Drawing.Point(315, 553);
			gb_miniTile.Margin = new Padding(4, 3, 4, 3);
			gb_miniTile.Name = "gb_miniTile";
			gb_miniTile.Padding = new Padding(4, 3, 4, 3);
			gb_miniTile.Size = new System.Drawing.Size(244, 384);
			gb_miniTile.TabIndex = 12;
			gb_miniTile.TabStop = false;
			gb_miniTile.Text = "MiniTile";
			// 
			// btn_miniTile_save
			// 
			btn_miniTile_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_miniTile_save.ForeColor = System.Drawing.SystemColors.HotTrack;
			btn_miniTile_save.Location = new System.Drawing.Point(152, 90);
			btn_miniTile_save.Margin = new Padding(2);
			btn_miniTile_save.Name = "btn_miniTile_save";
			btn_miniTile_save.Size = new System.Drawing.Size(88, 23);
			btn_miniTile_save.TabIndex = 34;
			btn_miniTile_save.Text = "Save MiniTile";
			btn_miniTile_save.UseVisualStyleBackColor = true;
			btn_miniTile_save.Click += btn_miniTile_save_Click;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.ForeColor = System.Drawing.SystemColors.HotTrack;
			label9.Location = new System.Drawing.Point(153, 13);
			label9.Margin = new Padding(4, 0, 4, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(31, 15);
			label9.TabIndex = 33;
			label9.Text = "Data";
			// 
			// tb_miniTile_data_byte4
			// 
			tb_miniTile_data_byte4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_miniTile_data_byte4.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_miniTile_data_byte4.Location = new System.Drawing.Point(200, 61);
			tb_miniTile_data_byte4.Margin = new Padding(4, 3, 4, 3);
			tb_miniTile_data_byte4.Name = "tb_miniTile_data_byte4";
			tb_miniTile_data_byte4.Size = new System.Drawing.Size(39, 20);
			tb_miniTile_data_byte4.TabIndex = 27;
			// 
			// tb_miniTile_data_byte3
			// 
			tb_miniTile_data_byte3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_miniTile_data_byte3.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_miniTile_data_byte3.Location = new System.Drawing.Point(153, 61);
			tb_miniTile_data_byte3.Margin = new Padding(4, 3, 4, 3);
			tb_miniTile_data_byte3.Name = "tb_miniTile_data_byte3";
			tb_miniTile_data_byte3.Size = new System.Drawing.Size(39, 20);
			tb_miniTile_data_byte3.TabIndex = 26;
			// 
			// tb_miniTile_data_byte2
			// 
			tb_miniTile_data_byte2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_miniTile_data_byte2.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_miniTile_data_byte2.Location = new System.Drawing.Point(200, 31);
			tb_miniTile_data_byte2.Margin = new Padding(4, 3, 4, 3);
			tb_miniTile_data_byte2.Name = "tb_miniTile_data_byte2";
			tb_miniTile_data_byte2.Size = new System.Drawing.Size(39, 20);
			tb_miniTile_data_byte2.TabIndex = 25;
			// 
			// tb_miniTile_data_byte1
			// 
			tb_miniTile_data_byte1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_miniTile_data_byte1.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_miniTile_data_byte1.Location = new System.Drawing.Point(153, 31);
			tb_miniTile_data_byte1.Margin = new Padding(4, 3, 4, 3);
			tb_miniTile_data_byte1.Name = "tb_miniTile_data_byte1";
			tb_miniTile_data_byte1.Size = new System.Drawing.Size(39, 20);
			tb_miniTile_data_byte1.TabIndex = 24;
			// 
			// lb_miniTile
			// 
			lb_miniTile.FormattingEnabled = true;
			lb_miniTile.ItemHeight = 15;
			lb_miniTile.Location = new System.Drawing.Point(6, 16);
			lb_miniTile.Margin = new Padding(2);
			lb_miniTile.Name = "lb_miniTile";
			lb_miniTile.Size = new System.Drawing.Size(140, 364);
			lb_miniTile.TabIndex = 14;
			lb_miniTile.SelectedIndexChanged += lb_miniTile_SelectedIndexChanged;
			// 
			// groupBox5
			// 
			groupBox5.Controls.Add(label5);
			groupBox5.Controls.Add(tb_worldScreenTile);
			groupBox5.Controls.Add(lb_worldScreenTiles);
			groupBox5.Enabled = false;
			groupBox5.Location = new System.Drawing.Point(162, 343);
			groupBox5.Margin = new Padding(4, 3, 4, 3);
			groupBox5.Name = "groupBox5";
			groupBox5.Padding = new Padding(4, 3, 4, 3);
			groupBox5.Size = new System.Drawing.Size(108, 51);
			groupBox5.TabIndex = 14;
			groupBox5.TabStop = false;
			groupBox5.Text = "WorldScreen Tile";
			groupBox5.Visible = false;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(202, 166);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(100, 15);
			label5.TabIndex = 15;
			label5.Text = "Associated Image";
			// 
			// tb_worldScreenTile
			// 
			tb_worldScreenTile.Location = new System.Drawing.Point(191, 31);
			tb_worldScreenTile.Margin = new Padding(4, 3, 4, 3);
			tb_worldScreenTile.Name = "tb_worldScreenTile";
			tb_worldScreenTile.Size = new System.Drawing.Size(116, 23);
			tb_worldScreenTile.TabIndex = 14;
			// 
			// lb_worldScreenTiles
			// 
			lb_worldScreenTiles.FormattingEnabled = true;
			lb_worldScreenTiles.ItemHeight = 15;
			lb_worldScreenTiles.Location = new System.Drawing.Point(6, 31);
			lb_worldScreenTiles.Margin = new Padding(2);
			lb_worldScreenTiles.Name = "lb_worldScreenTiles";
			lb_worldScreenTiles.Size = new System.Drawing.Size(179, 349);
			lb_worldScreenTiles.TabIndex = 13;
			lb_worldScreenTiles.SelectedIndexChanged += lb_worldScreenTile_SelectedIndexChanged;
			// 
			// gb_tile
			// 
			gb_tile.Controls.Add(label3);
			gb_tile.Controls.Add(label13);
			gb_tile.Controls.Add(btn_tile_save);
			gb_tile.Controls.Add(label8);
			gb_tile.Controls.Add(pb_tile_Image);
			gb_tile.Controls.Add(tb_tile_data_byte4);
			gb_tile.Controls.Add(tb_tile_data_byte3);
			gb_tile.Controls.Add(tb_tile_data_byte2);
			gb_tile.Controls.Add(tb_tile_data_byte1);
			gb_tile.Controls.Add(lb_tile);
			gb_tile.Location = new System.Drawing.Point(19, 553);
			gb_tile.Margin = new Padding(4, 3, 4, 3);
			gb_tile.Name = "gb_tile";
			gb_tile.Padding = new Padding(4, 3, 4, 3);
			gb_tile.Size = new System.Drawing.Size(289, 384);
			gb_tile.TabIndex = 9;
			gb_tile.TabStop = false;
			gb_tile.Text = "Tile";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(152, 222);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(40, 15);
			label3.TabIndex = 35;
			label3.Text = "Image";
			// 
			// label13
			// 
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label13.ForeColor = System.Drawing.SystemColors.GrayText;
			label13.Location = new System.Drawing.Point(161, 114);
			label13.Margin = new Padding(4, 0, 4, 0);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(174, 55);
			label13.TabIndex = 34;
			label13.Text = "Byte 0: TopLeft MiniTile\r\nByte 1: TopRight MiniTile\r\nByte 2: BottomLeft MiniTile\r\nByte 3: BottomRight MiniTile\r\n";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_tile_save
			// 
			btn_tile_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_tile_save.ForeColor = System.Drawing.SystemColors.HotTrack;
			btn_tile_save.Location = new System.Drawing.Point(162, 89);
			btn_tile_save.Margin = new Padding(2);
			btn_tile_save.Name = "btn_tile_save";
			btn_tile_save.Size = new System.Drawing.Size(88, 23);
			btn_tile_save.TabIndex = 33;
			btn_tile_save.Text = "Save Tile";
			btn_tile_save.UseVisualStyleBackColor = true;
			btn_tile_save.Click += btn_tile_save_Click;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.ForeColor = System.Drawing.SystemColors.HotTrack;
			label8.Location = new System.Drawing.Point(160, 12);
			label8.Margin = new Padding(4, 0, 4, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(31, 15);
			label8.TabIndex = 32;
			label8.Text = "Data";
			// 
			// pb_tile_Image
			// 
			pb_tile_Image.BackColor = System.Drawing.Color.Gainsboro;
			pb_tile_Image.BorderStyle = BorderStyle.FixedSingle;
			pb_tile_Image.Location = new System.Drawing.Point(152, 239);
			pb_tile_Image.Margin = new Padding(4, 3, 4, 3);
			pb_tile_Image.Name = "pb_tile_Image";
			pb_tile_Image.Size = new System.Drawing.Size(132, 140);
			pb_tile_Image.TabIndex = 14;
			pb_tile_Image.TabStop = false;
			// 
			// tb_tile_data_byte4
			// 
			tb_tile_data_byte4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_tile_data_byte4.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_tile_data_byte4.Location = new System.Drawing.Point(210, 60);
			tb_tile_data_byte4.Margin = new Padding(4, 3, 4, 3);
			tb_tile_data_byte4.Name = "tb_tile_data_byte4";
			tb_tile_data_byte4.Size = new System.Drawing.Size(39, 20);
			tb_tile_data_byte4.TabIndex = 31;
			tb_tile_data_byte4.DoubleClick += tb_tile_data_byte4_DoubleClick;
			// 
			// tb_tile_data_byte3
			// 
			tb_tile_data_byte3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_tile_data_byte3.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_tile_data_byte3.Location = new System.Drawing.Point(163, 60);
			tb_tile_data_byte3.Margin = new Padding(4, 3, 4, 3);
			tb_tile_data_byte3.Name = "tb_tile_data_byte3";
			tb_tile_data_byte3.Size = new System.Drawing.Size(39, 20);
			tb_tile_data_byte3.TabIndex = 30;
			tb_tile_data_byte3.DoubleClick += tb_tile_data_byte3_DoubleClick;
			// 
			// tb_tile_data_byte2
			// 
			tb_tile_data_byte2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_tile_data_byte2.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_tile_data_byte2.Location = new System.Drawing.Point(210, 30);
			tb_tile_data_byte2.Margin = new Padding(4, 3, 4, 3);
			tb_tile_data_byte2.Name = "tb_tile_data_byte2";
			tb_tile_data_byte2.Size = new System.Drawing.Size(39, 20);
			tb_tile_data_byte2.TabIndex = 29;
			tb_tile_data_byte2.DoubleClick += tb_tile_data_byte2_DoubleClick;
			// 
			// tb_tile_data_byte1
			// 
			tb_tile_data_byte1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			tb_tile_data_byte1.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_tile_data_byte1.Location = new System.Drawing.Point(163, 30);
			tb_tile_data_byte1.Margin = new Padding(4, 3, 4, 3);
			tb_tile_data_byte1.Name = "tb_tile_data_byte1";
			tb_tile_data_byte1.Size = new System.Drawing.Size(39, 20);
			tb_tile_data_byte1.TabIndex = 28;
			tb_tile_data_byte1.DoubleClick += tb_tile_data_byte1_DoubleClick;
			// 
			// lb_tile
			// 
			lb_tile.FormattingEnabled = true;
			lb_tile.ItemHeight = 15;
			lb_tile.Location = new System.Drawing.Point(6, 16);
			lb_tile.Margin = new Padding(2);
			lb_tile.Name = "lb_tile";
			lb_tile.Size = new System.Drawing.Size(140, 364);
			lb_tile.TabIndex = 13;
			lb_tile.SelectedIndexChanged += lb_tile_SelectedIndexChanged;
			// 
			// tab_encounters
			// 
			tab_encounters.Controls.Add(gb_encounterLineups);
			tab_encounters.Controls.Add(gb_encounterGroups);
			tab_encounters.Location = new System.Drawing.Point(4, 24);
			tab_encounters.Margin = new Padding(4, 3, 4, 3);
			tab_encounters.Name = "tab_encounters";
			tab_encounters.Size = new System.Drawing.Size(882, 977);
			tab_encounters.TabIndex = 3;
			tab_encounters.Text = "Encounters";
			tab_encounters.UseVisualStyleBackColor = true;
			// 
			// gb_encounterLineups
			// 
			gb_encounterLineups.Controls.Add(btn_encounterLineup_save);
			gb_encounterLineups.Controls.Add(label12);
			gb_encounterLineups.Controls.Add(rtb_encounterLineups_data);
			gb_encounterLineups.Controls.Add(lb_encounterLinups);
			gb_encounterLineups.Location = new System.Drawing.Point(15, 480);
			gb_encounterLineups.Margin = new Padding(4, 3, 4, 3);
			gb_encounterLineups.Name = "gb_encounterLineups";
			gb_encounterLineups.Padding = new Padding(4, 3, 4, 3);
			gb_encounterLineups.Size = new System.Drawing.Size(540, 459);
			gb_encounterLineups.TabIndex = 1;
			gb_encounterLineups.TabStop = false;
			gb_encounterLineups.Text = "Encounter Lineup";
			// 
			// btn_encounterLineup_save
			// 
			btn_encounterLineup_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_encounterLineup_save.ForeColor = System.Drawing.SystemColors.HotTrack;
			btn_encounterLineup_save.Location = new System.Drawing.Point(425, 68);
			btn_encounterLineup_save.Margin = new Padding(2);
			btn_encounterLineup_save.Name = "btn_encounterLineup_save";
			btn_encounterLineup_save.Size = new System.Drawing.Size(111, 23);
			btn_encounterLineup_save.TabIndex = 34;
			btn_encounterLineup_save.Text = "Save EncounterLineup";
			btn_encounterLineup_save.UseVisualStyleBackColor = true;
			btn_encounterLineup_save.Click += btn_encounterLineup_save_Click;
			// 
			// label12
			// 
			label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.ForeColor = System.Drawing.SystemColors.GrayText;
			label12.Location = new System.Drawing.Point(163, 72);
			label12.Margin = new Padding(4, 0, 4, 0);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(132, 55);
			label12.TabIndex = 33;
			label12.Text = "Byte 0: StartByte\r\nBytes 1-7: Enemy Slots\r\n\r\n";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rtb_encounterLineups_data
			// 
			rtb_encounterLineups_data.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			rtb_encounterLineups_data.ForeColor = System.Drawing.SystemColors.HotTrack;
			rtb_encounterLineups_data.Location = new System.Drawing.Point(163, 21);
			rtb_encounterLineups_data.Margin = new Padding(4, 3, 4, 3);
			rtb_encounterLineups_data.Name = "rtb_encounterLineups_data";
			rtb_encounterLineups_data.Size = new System.Drawing.Size(372, 47);
			rtb_encounterLineups_data.TabIndex = 31;
			rtb_encounterLineups_data.Text = "";
			// 
			// lb_encounterLinups
			// 
			lb_encounterLinups.FormattingEnabled = true;
			lb_encounterLinups.ItemHeight = 15;
			lb_encounterLinups.Location = new System.Drawing.Point(16, 21);
			lb_encounterLinups.Margin = new Padding(2);
			lb_encounterLinups.Name = "lb_encounterLinups";
			lb_encounterLinups.Size = new System.Drawing.Size(140, 424);
			lb_encounterLinups.TabIndex = 30;
			lb_encounterLinups.SelectedIndexChanged += lb_encounterLinups_SelectedIndexChanged;
			// 
			// gb_encounterGroups
			// 
			gb_encounterGroups.Controls.Add(btn_encounterGroup_save);
			gb_encounterGroups.Controls.Add(label15);
			gb_encounterGroups.Controls.Add(rtb_encounterGroups_data);
			gb_encounterGroups.Controls.Add(lb_encounterGroups);
			gb_encounterGroups.Location = new System.Drawing.Point(15, 14);
			gb_encounterGroups.Margin = new Padding(4, 3, 4, 3);
			gb_encounterGroups.Name = "gb_encounterGroups";
			gb_encounterGroups.Padding = new Padding(4, 3, 4, 3);
			gb_encounterGroups.Size = new System.Drawing.Size(386, 459);
			gb_encounterGroups.TabIndex = 0;
			gb_encounterGroups.TabStop = false;
			gb_encounterGroups.Text = "Encounter Groups";
			// 
			// btn_encounterGroup_save
			// 
			btn_encounterGroup_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_encounterGroup_save.ForeColor = System.Drawing.SystemColors.HotTrack;
			btn_encounterGroup_save.Location = new System.Drawing.Point(276, 68);
			btn_encounterGroup_save.Margin = new Padding(2);
			btn_encounterGroup_save.Name = "btn_encounterGroup_save";
			btn_encounterGroup_save.Size = new System.Drawing.Size(104, 25);
			btn_encounterGroup_save.TabIndex = 32;
			btn_encounterGroup_save.Text = "Save EncounterGroup";
			btn_encounterGroup_save.UseVisualStyleBackColor = true;
			btn_encounterGroup_save.Click += btn_encounterGroup_save_Click;
			// 
			// label15
			// 
			label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label15.ForeColor = System.Drawing.SystemColors.GrayText;
			label15.Location = new System.Drawing.Point(163, 85);
			label15.Margin = new Padding(4, 0, 4, 0);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(174, 55);
			label15.TabIndex = 31;
			label15.Text = "Byte 0: WorldScreen\r\nByte 1: MonsterGroup (EncounterLinup)\r\nByte 2: Unknown";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rtb_encounterGroups_data
			// 
			rtb_encounterGroups_data.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			rtb_encounterGroups_data.ForeColor = System.Drawing.SystemColors.HotTrack;
			rtb_encounterGroups_data.Location = new System.Drawing.Point(164, 21);
			rtb_encounterGroups_data.Margin = new Padding(4, 3, 4, 3);
			rtb_encounterGroups_data.Name = "rtb_encounterGroups_data";
			rtb_encounterGroups_data.Size = new System.Drawing.Size(215, 47);
			rtb_encounterGroups_data.TabIndex = 29;
			rtb_encounterGroups_data.Text = "";
			// 
			// lb_encounterGroups
			// 
			lb_encounterGroups.FormattingEnabled = true;
			lb_encounterGroups.ItemHeight = 15;
			lb_encounterGroups.Location = new System.Drawing.Point(18, 21);
			lb_encounterGroups.Margin = new Padding(2);
			lb_encounterGroups.Name = "lb_encounterGroups";
			lb_encounterGroups.Size = new System.Drawing.Size(140, 424);
			lb_encounterGroups.TabIndex = 28;
			lb_encounterGroups.SelectedIndexChanged += lb_encounterGroups_SelectedIndexChanged;
			// 
			// tab_variables
			// 
			tab_variables.Controls.Add(label19);
			tab_variables.Controls.Add(groupBox3);
			tab_variables.Controls.Add(lv_knownVariables);
			tab_variables.Location = new System.Drawing.Point(4, 24);
			tab_variables.Margin = new Padding(2);
			tab_variables.Name = "tab_variables";
			tab_variables.Size = new System.Drawing.Size(882, 977);
			tab_variables.TabIndex = 4;
			tab_variables.Text = "Variables";
			tab_variables.UseVisualStyleBackColor = true;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(19, 9);
			label19.Margin = new Padding(2, 0, 2, 0);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(127, 15);
			label19.TabIndex = 2;
			label19.Text = "Known Game Variables";
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(btn_knownVariables_selectedVariable_save);
			groupBox3.Controls.Add(label20);
			groupBox3.Controls.Add(label22);
			groupBox3.Controls.Add(tb_knownVariables_selectedVariable_description);
			groupBox3.Controls.Add(label21);
			groupBox3.Controls.Add(lbl_knownVariables_selectedVariable_variableName);
			groupBox3.Controls.Add(tb_knownVariables_selectedVariable_value);
			groupBox3.Controls.Add(label18);
			groupBox3.Controls.Add(label17);
			groupBox3.Location = new System.Drawing.Point(436, 28);
			groupBox3.Margin = new Padding(2);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(2);
			groupBox3.Size = new System.Drawing.Size(399, 276);
			groupBox3.TabIndex = 1;
			groupBox3.TabStop = false;
			groupBox3.Text = "Variable";
			// 
			// btn_knownVariables_selectedVariable_save
			// 
			btn_knownVariables_selectedVariable_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_knownVariables_selectedVariable_save.ForeColor = System.Drawing.SystemColors.HotTrack;
			btn_knownVariables_selectedVariable_save.Location = new System.Drawing.Point(161, 233);
			btn_knownVariables_selectedVariable_save.Margin = new Padding(2);
			btn_knownVariables_selectedVariable_save.Name = "btn_knownVariables_selectedVariable_save";
			btn_knownVariables_selectedVariable_save.Size = new System.Drawing.Size(97, 23);
			btn_knownVariables_selectedVariable_save.TabIndex = 36;
			btn_knownVariables_selectedVariable_save.Text = "Save Variable value";
			btn_knownVariables_selectedVariable_save.UseVisualStyleBackColor = true;
			btn_knownVariables_selectedVariable_save.Click += btn_knownVariables_selectedVariable_save_Click;
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label20.Location = new System.Drawing.Point(85, 60);
			label20.Margin = new Padding(2, 0, 2, 0);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(38, 16);
			label20.TabIndex = 35;
			label20.Text = "Byte";
			// 
			// label22
			// 
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(38, 60);
			label22.Margin = new Padding(2, 0, 2, 0);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(34, 15);
			label22.TabIndex = 34;
			label22.Text = "Type:";
			// 
			// tb_knownVariables_selectedVariable_description
			// 
			tb_knownVariables_selectedVariable_description.Location = new System.Drawing.Point(88, 91);
			tb_knownVariables_selectedVariable_description.Margin = new Padding(2);
			tb_knownVariables_selectedVariable_description.Multiline = true;
			tb_knownVariables_selectedVariable_description.Name = "tb_knownVariables_selectedVariable_description";
			tb_knownVariables_selectedVariable_description.ReadOnly = true;
			tb_knownVariables_selectedVariable_description.Size = new System.Drawing.Size(288, 63);
			tb_knownVariables_selectedVariable_description.TabIndex = 33;
			tb_knownVariables_selectedVariable_description.Visible = false;
			// 
			// label21
			// 
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(14, 91);
			label21.Margin = new Padding(2, 0, 2, 0);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(70, 15);
			label21.TabIndex = 31;
			label21.Text = "Description:";
			label21.Visible = false;
			// 
			// lbl_knownVariables_selectedVariable_variableName
			// 
			lbl_knownVariables_selectedVariable_variableName.AutoSize = true;
			lbl_knownVariables_selectedVariable_variableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lbl_knownVariables_selectedVariable_variableName.Location = new System.Drawing.Point(85, 31);
			lbl_knownVariables_selectedVariable_variableName.Margin = new Padding(2, 0, 2, 0);
			lbl_knownVariables_selectedVariable_variableName.Name = "lbl_knownVariables_selectedVariable_variableName";
			lbl_knownVariables_selectedVariable_variableName.Size = new System.Drawing.Size(39, 16);
			lbl_knownVariables_selectedVariable_variableName.TabIndex = 30;
			lbl_knownVariables_selectedVariable_variableName.Text = "Var1";
			// 
			// tb_knownVariables_selectedVariable_value
			// 
			tb_knownVariables_selectedVariable_value.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			tb_knownVariables_selectedVariable_value.ForeColor = System.Drawing.SystemColors.HotTrack;
			tb_knownVariables_selectedVariable_value.Location = new System.Drawing.Point(88, 173);
			tb_knownVariables_selectedVariable_value.Margin = new Padding(4, 3, 4, 3);
			tb_knownVariables_selectedVariable_value.Name = "tb_knownVariables_selectedVariable_value";
			tb_knownVariables_selectedVariable_value.Size = new System.Drawing.Size(288, 25);
			tb_knownVariables_selectedVariable_value.TabIndex = 29;
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(40, 179);
			label18.Margin = new Padding(2, 0, 2, 0);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(38, 15);
			label18.TabIndex = 1;
			label18.Text = "Value:";
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(38, 31);
			label17.Margin = new Padding(2, 0, 2, 0);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(42, 15);
			label17.TabIndex = 0;
			label17.Text = "Name:";
			// 
			// lv_knownVariables
			// 
			lv_knownVariables.Columns.AddRange(new ColumnHeader[] { lv_knownVariables_col_name, lv_knownVariables_col_value });
			lv_knownVariables.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			lv_knownVariables.Location = new System.Drawing.Point(22, 28);
			lv_knownVariables.Margin = new Padding(2);
			lv_knownVariables.Name = "lv_knownVariables";
			lv_knownVariables.Size = new System.Drawing.Size(398, 891);
			lv_knownVariables.TabIndex = 0;
			lv_knownVariables.UseCompatibleStateImageBehavior = false;
			lv_knownVariables.View = View.Details;
			lv_knownVariables.SelectedIndexChanged += lv_knownVariables_SelectedIndexChanged;
			// 
			// lv_knownVariables_col_name
			// 
			lv_knownVariables_col_name.Width = 159;
			// 
			// lv_knownVariables_col_value
			// 
			lv_knownVariables_col_value.Width = 265;
			// 
			// menu_pb_worldMap_rightClick
			// 
			menu_pb_worldMap_rightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
			menu_pb_worldMap_rightClick.Items.AddRange(new ToolStripItem[] { menu_pb_worldMap_moveWorldScreen, menu_pb_worldMap_copyWorldSceen, menu_pb_worldMap_pasteWorldSceen });
			menu_pb_worldMap_rightClick.Name = "menu_pb_worldMap_rightClick";
			menu_pb_worldMap_rightClick.Size = new System.Drawing.Size(175, 70);
			menu_pb_worldMap_rightClick.Text = "Select WS";
			// 
			// menu_pb_worldMap_moveWorldScreen
			// 
			menu_pb_worldMap_moveWorldScreen.Name = "menu_pb_worldMap_moveWorldScreen";
			menu_pb_worldMap_moveWorldScreen.Size = new System.Drawing.Size(174, 22);
			menu_pb_worldMap_moveWorldScreen.Text = "Move WorldScreen";
			menu_pb_worldMap_moveWorldScreen.Click += menu_pb_worldMap_moveWorldScreen_Click;
			// 
			// menu_pb_worldMap_copyWorldSceen
			// 
			menu_pb_worldMap_copyWorldSceen.Name = "menu_pb_worldMap_copyWorldSceen";
			menu_pb_worldMap_copyWorldSceen.Size = new System.Drawing.Size(174, 22);
			menu_pb_worldMap_copyWorldSceen.Text = "Copy WorldScreen";
			menu_pb_worldMap_copyWorldSceen.Click += menu_pb_worldMap_copyWorldSceen_Click;
			// 
			// menu_pb_worldMap_pasteWorldSceen
			// 
			menu_pb_worldMap_pasteWorldSceen.Name = "menu_pb_worldMap_pasteWorldSceen";
			menu_pb_worldMap_pasteWorldSceen.Size = new System.Drawing.Size(174, 22);
			menu_pb_worldMap_pasteWorldSceen.Text = "Paste WorldScreen";
			menu_pb_worldMap_pasteWorldSceen.Click += menu_pb_worldMap_pasteWorldSceen_Click;
			// 
			// lbl_worldScreen_info
			// 
			lbl_worldScreen_info.AutoSize = true;
			lbl_worldScreen_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_worldScreen_info.Location = new System.Drawing.Point(4, 388);
			lbl_worldScreen_info.Margin = new Padding(4, 0, 4, 0);
			lbl_worldScreen_info.Name = "lbl_worldScreen_info";
			lbl_worldScreen_info.Size = new System.Drawing.Size(60, 24);
			lbl_worldScreen_info.TabIndex = 21;
			lbl_worldScreen_info.Text = "Chapter:\r\nGrid Position:";
			lbl_worldScreen_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_worldScreen_relativeIndex
			// 
			lbl_worldScreen_relativeIndex.AutoSize = true;
			lbl_worldScreen_relativeIndex.Location = new System.Drawing.Point(342, 373);
			lbl_worldScreen_relativeIndex.Margin = new Padding(4, 0, 4, 0);
			lbl_worldScreen_relativeIndex.Name = "lbl_worldScreen_relativeIndex";
			lbl_worldScreen_relativeIndex.Size = new System.Drawing.Size(83, 15);
			lbl_worldScreen_relativeIndex.TabIndex = 20;
			lbl_worldScreen_relativeIndex.Text = "Relative Index:";
			lbl_worldScreen_relativeIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label14.Location = new System.Drawing.Point(2, 373);
			label14.Margin = new Padding(4, 0, 4, 0);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(142, 13);
			label14.TabIndex = 19;
			label14.Text = "Selected World Screen:";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tb_selectedWorldScreenIndex
			// 
			tb_selectedWorldScreenIndex.Location = new System.Drawing.Point(175, 369);
			tb_selectedWorldScreenIndex.Margin = new Padding(4, 3, 4, 3);
			tb_selectedWorldScreenIndex.Name = "tb_selectedWorldScreenIndex";
			tb_selectedWorldScreenIndex.ReadOnly = true;
			tb_selectedWorldScreenIndex.Size = new System.Drawing.Size(55, 23);
			tb_selectedWorldScreenIndex.TabIndex = 18;
			// 
			// btn_refreshWorldScreenList
			// 
			btn_refreshWorldScreenList.Location = new System.Drawing.Point(369, 14);
			btn_refreshWorldScreenList.Margin = new Padding(4, 3, 4, 3);
			btn_refreshWorldScreenList.Name = "btn_refreshWorldScreenList";
			btn_refreshWorldScreenList.Size = new System.Drawing.Size(112, 27);
			btn_refreshWorldScreenList.TabIndex = 19;
			btn_refreshWorldScreenList.Text = "Refresh WS List";
			btn_refreshWorldScreenList.UseVisualStyleBackColor = true;
			btn_refreshWorldScreenList.Visible = false;
			// 
			// gb_drawOptions
			// 
			gb_drawOptions.Controls.Add(groupBox9);
			gb_drawOptions.Controls.Add(groupBox8);
			gb_drawOptions.Controls.Add(groupBox7);
			gb_drawOptions.Controls.Add(btn_redraw_worldScreen);
			gb_drawOptions.Location = new System.Drawing.Point(0, 801);
			gb_drawOptions.Margin = new Padding(4, 3, 4, 3);
			gb_drawOptions.Name = "gb_drawOptions";
			gb_drawOptions.Padding = new Padding(4, 3, 4, 3);
			gb_drawOptions.Size = new System.Drawing.Size(485, 130);
			gb_drawOptions.TabIndex = 19;
			gb_drawOptions.TabStop = false;
			gb_drawOptions.Text = "Draw Options";
			// 
			// groupBox9
			// 
			groupBox9.Controls.Add(label11);
			groupBox9.Controls.Add(nud_drawOptions_map_tileSize);
			groupBox9.Location = new System.Drawing.Point(10, 22);
			groupBox9.Margin = new Padding(4, 3, 4, 3);
			groupBox9.Name = "groupBox9";
			groupBox9.Padding = new Padding(4, 3, 4, 3);
			groupBox9.Size = new System.Drawing.Size(198, 102);
			groupBox9.TabIndex = 23;
			groupBox9.TabStop = false;
			groupBox9.Text = "Map";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(7, 18);
			label11.Margin = new Padding(4, 0, 4, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(27, 15);
			label11.TabIndex = 5;
			label11.Text = "Size";
			// 
			// nud_drawOptions_map_tileSize
			// 
			nud_drawOptions_map_tileSize.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			nud_drawOptions_map_tileSize.Location = new System.Drawing.Point(46, 16);
			nud_drawOptions_map_tileSize.Margin = new Padding(4, 3, 4, 3);
			nud_drawOptions_map_tileSize.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
			nud_drawOptions_map_tileSize.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
			nud_drawOptions_map_tileSize.Name = "nud_drawOptions_map_tileSize";
			nud_drawOptions_map_tileSize.Size = new System.Drawing.Size(50, 23);
			nud_drawOptions_map_tileSize.TabIndex = 4;
			nud_drawOptions_map_tileSize.Value = new decimal(new int[] { 60, 0, 0, 0 });
			nud_drawOptions_map_tileSize.ValueChanged += nud_drawOptions_map_tileSize_ValueChanged;
			// 
			// groupBox8
			// 
			groupBox8.Controls.Add(cb_drawOptions_worldScreen_showInfo);
			groupBox8.Controls.Add(cb_drawOptions_worldScreen_showBorders);
			groupBox8.Controls.Add(label4);
			groupBox8.Controls.Add(nud_drawOptions_worldScreen_showTileImages);
			groupBox8.Location = new System.Drawing.Point(203, 21);
			groupBox8.Margin = new Padding(4, 3, 4, 3);
			groupBox8.Name = "groupBox8";
			groupBox8.Padding = new Padding(4, 3, 4, 3);
			groupBox8.Size = new System.Drawing.Size(114, 103);
			groupBox8.TabIndex = 22;
			groupBox8.TabStop = false;
			groupBox8.Text = "WorldScreen";
			// 
			// cb_drawOptions_worldScreen_showInfo
			// 
			cb_drawOptions_worldScreen_showInfo.AutoSize = true;
			cb_drawOptions_worldScreen_showInfo.Checked = true;
			cb_drawOptions_worldScreen_showInfo.CheckState = CheckState.Checked;
			cb_drawOptions_worldScreen_showInfo.Location = new System.Drawing.Point(8, 22);
			cb_drawOptions_worldScreen_showInfo.Margin = new Padding(4, 3, 4, 3);
			cb_drawOptions_worldScreen_showInfo.Name = "cb_drawOptions_worldScreen_showInfo";
			cb_drawOptions_worldScreen_showInfo.Size = new System.Drawing.Size(79, 19);
			cb_drawOptions_worldScreen_showInfo.TabIndex = 0;
			cb_drawOptions_worldScreen_showInfo.Text = "Show Info";
			cb_drawOptions_worldScreen_showInfo.UseVisualStyleBackColor = true;
			// 
			// cb_drawOptions_worldScreen_showBorders
			// 
			cb_drawOptions_worldScreen_showBorders.AutoSize = true;
			cb_drawOptions_worldScreen_showBorders.Checked = true;
			cb_drawOptions_worldScreen_showBorders.CheckState = CheckState.Checked;
			cb_drawOptions_worldScreen_showBorders.Location = new System.Drawing.Point(8, 40);
			cb_drawOptions_worldScreen_showBorders.Margin = new Padding(4, 3, 4, 3);
			cb_drawOptions_worldScreen_showBorders.Name = "cb_drawOptions_worldScreen_showBorders";
			cb_drawOptions_worldScreen_showBorders.Size = new System.Drawing.Size(98, 19);
			cb_drawOptions_worldScreen_showBorders.TabIndex = 1;
			cb_drawOptions_worldScreen_showBorders.Text = "Show Borders";
			cb_drawOptions_worldScreen_showBorders.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(7, 67);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(27, 15);
			label4.TabIndex = 4;
			label4.Text = "Size";
			// 
			// nud_drawOptions_worldScreen_showTileImages
			// 
			nud_drawOptions_worldScreen_showTileImages.Increment = new decimal(new int[] { 5, 0, 0, 0 });
			nud_drawOptions_worldScreen_showTileImages.Location = new System.Drawing.Point(46, 65);
			nud_drawOptions_worldScreen_showTileImages.Margin = new Padding(4, 3, 4, 3);
			nud_drawOptions_worldScreen_showTileImages.Maximum = new decimal(new int[] { 150, 0, 0, 0 });
			nud_drawOptions_worldScreen_showTileImages.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
			nud_drawOptions_worldScreen_showTileImages.Name = "nud_drawOptions_worldScreen_showTileImages";
			nud_drawOptions_worldScreen_showTileImages.Size = new System.Drawing.Size(50, 23);
			nud_drawOptions_worldScreen_showTileImages.TabIndex = 3;
			nud_drawOptions_worldScreen_showTileImages.Value = new decimal(new int[] { 80, 0, 0, 0 });
			nud_drawOptions_worldScreen_showTileImages.ValueChanged += nud_drawOptions_worldScreen_showTileImages_ValueChanged;
			// 
			// groupBox7
			// 
			groupBox7.Controls.Add(cb_drawOptions_worldScreenTile_showCollision);
			groupBox7.Controls.Add(cb_drawOptions_worldScreenTile_showImage);
			groupBox7.Controls.Add(cb_drawOptions_worldScreenTile_showInfo);
			groupBox7.Location = new System.Drawing.Point(318, 21);
			groupBox7.Margin = new Padding(4, 3, 4, 3);
			groupBox7.Name = "groupBox7";
			groupBox7.Padding = new Padding(4, 3, 4, 3);
			groupBox7.Size = new System.Drawing.Size(120, 81);
			groupBox7.TabIndex = 21;
			groupBox7.TabStop = false;
			groupBox7.Text = "Tile";
			// 
			// cb_drawOptions_worldScreenTile_showCollision
			// 
			cb_drawOptions_worldScreenTile_showCollision.AutoSize = true;
			cb_drawOptions_worldScreenTile_showCollision.Checked = true;
			cb_drawOptions_worldScreenTile_showCollision.CheckState = CheckState.Checked;
			cb_drawOptions_worldScreenTile_showCollision.Location = new System.Drawing.Point(7, 48);
			cb_drawOptions_worldScreenTile_showCollision.Margin = new Padding(4, 3, 4, 3);
			cb_drawOptions_worldScreenTile_showCollision.Name = "cb_drawOptions_worldScreenTile_showCollision";
			cb_drawOptions_worldScreenTile_showCollision.Size = new System.Drawing.Size(104, 19);
			cb_drawOptions_worldScreenTile_showCollision.TabIndex = 3;
			cb_drawOptions_worldScreenTile_showCollision.Text = "Show Collision";
			cb_drawOptions_worldScreenTile_showCollision.UseVisualStyleBackColor = true;
			// 
			// cb_drawOptions_worldScreenTile_showImage
			// 
			cb_drawOptions_worldScreenTile_showImage.AutoSize = true;
			cb_drawOptions_worldScreenTile_showImage.Checked = true;
			cb_drawOptions_worldScreenTile_showImage.CheckState = CheckState.Checked;
			cb_drawOptions_worldScreenTile_showImage.Location = new System.Drawing.Point(7, 31);
			cb_drawOptions_worldScreenTile_showImage.Margin = new Padding(4, 3, 4, 3);
			cb_drawOptions_worldScreenTile_showImage.Name = "cb_drawOptions_worldScreenTile_showImage";
			cb_drawOptions_worldScreenTile_showImage.Size = new System.Drawing.Size(91, 19);
			cb_drawOptions_worldScreenTile_showImage.TabIndex = 2;
			cb_drawOptions_worldScreenTile_showImage.Text = "Show Image";
			cb_drawOptions_worldScreenTile_showImage.UseVisualStyleBackColor = true;
			// 
			// cb_drawOptions_worldScreenTile_showInfo
			// 
			cb_drawOptions_worldScreenTile_showInfo.AutoSize = true;
			cb_drawOptions_worldScreenTile_showInfo.Checked = true;
			cb_drawOptions_worldScreenTile_showInfo.CheckState = CheckState.Checked;
			cb_drawOptions_worldScreenTile_showInfo.Location = new System.Drawing.Point(7, 14);
			cb_drawOptions_worldScreenTile_showInfo.Margin = new Padding(4, 3, 4, 3);
			cb_drawOptions_worldScreenTile_showInfo.Name = "cb_drawOptions_worldScreenTile_showInfo";
			cb_drawOptions_worldScreenTile_showInfo.Size = new System.Drawing.Size(79, 19);
			cb_drawOptions_worldScreenTile_showInfo.TabIndex = 1;
			cb_drawOptions_worldScreenTile_showInfo.Text = "Show Info";
			cb_drawOptions_worldScreenTile_showInfo.UseVisualStyleBackColor = true;
			// 
			// btn_redraw_worldScreen
			// 
			btn_redraw_worldScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_redraw_worldScreen.Location = new System.Drawing.Point(345, 21);
			btn_redraw_worldScreen.Margin = new Padding(2);
			btn_redraw_worldScreen.Name = "btn_redraw_worldScreen";
			btn_redraw_worldScreen.Size = new System.Drawing.Size(74, 23);
			btn_redraw_worldScreen.TabIndex = 20;
			btn_redraw_worldScreen.Text = "Redraw";
			btn_redraw_worldScreen.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, worldScreenToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(7, 2, 0, 2);
			menuStrip1.Size = new System.Drawing.Size(1373, 24);
			menuStrip1.TabIndex = 21;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menu_loadDefaultRom, menu_loadRom, menu_saveRom, toolStripSeparator1, exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// menu_loadDefaultRom
			// 
			menu_loadDefaultRom.Name = "menu_loadDefaultRom";
			menu_loadDefaultRom.Size = new System.Drawing.Size(171, 22);
			menu_loadDefaultRom.Text = "Load Default ROM";
			menu_loadDefaultRom.Click += menu_loadDefaultRom_Click;
			// 
			// menu_loadRom
			// 
			menu_loadRom.Name = "menu_loadRom";
			menu_loadRom.Size = new System.Drawing.Size(171, 22);
			menu_loadRom.Text = "Load ROM";
			menu_loadRom.Click += menu_loadRom_Click;
			// 
			// menu_saveRom
			// 
			menu_saveRom.Name = "menu_saveRom";
			menu_saveRom.Size = new System.Drawing.Size(171, 22);
			menu_saveRom.Text = "Save ROM";
			menu_saveRom.Click += menu_saveRom_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			exitToolStripMenuItem.Text = "Exit";
			// 
			// worldScreenToolStripMenuItem
			// 
			worldScreenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menu_shuffleWSTileSections, shuffleTileSectionsKeepCompatableToolStripMenuItem, shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem });
			worldScreenToolStripMenuItem.Name = "worldScreenToolStripMenuItem";
			worldScreenToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
			worldScreenToolStripMenuItem.Text = "WorldScreen";
			// 
			// menu_shuffleWSTileSections
			// 
			menu_shuffleWSTileSections.Name = "menu_shuffleWSTileSections";
			menu_shuffleWSTileSections.Size = new System.Drawing.Size(338, 22);
			menu_shuffleWSTileSections.Text = "Shuffle TileSections";
			menu_shuffleWSTileSections.Click += menu_shuffleWSTileSections_Click;
			// 
			// shuffleTileSectionsKeepCompatableToolStripMenuItem
			// 
			shuffleTileSectionsKeepCompatableToolStripMenuItem.Name = "shuffleTileSectionsKeepCompatableToolStripMenuItem";
			shuffleTileSectionsKeepCompatableToolStripMenuItem.Size = new System.Drawing.Size(338, 22);
			shuffleTileSectionsKeepCompatableToolStripMenuItem.Text = "Shuffle TileSections Keep Compatable";
			shuffleTileSectionsKeepCompatableToolStripMenuItem.Click += shuffleTileSectionsKeepCompatableToolStripMenuItem_Click;
			// 
			// shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem
			// 
			shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem.Name = "shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem";
			shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem.Size = new System.Drawing.Size(338, 22);
			shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem.Text = "Shuffle TileSections Keep Compatable Multiscreen";
			shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem.Click += shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem_Click;
			// 
			// btn_loadDefaultRom
			// 
			btn_loadDefaultRom.Location = new System.Drawing.Point(14, 31);
			btn_loadDefaultRom.Margin = new Padding(4, 3, 4, 3);
			btn_loadDefaultRom.Name = "btn_loadDefaultRom";
			btn_loadDefaultRom.Size = new System.Drawing.Size(134, 27);
			btn_loadDefaultRom.TabIndex = 22;
			btn_loadDefaultRom.Text = "Load Default ROM";
			btn_loadDefaultRom.UseVisualStyleBackColor = true;
			btn_loadDefaultRom.Click += btn_loadDefaultRom_Click;
			// 
			// col_name
			// 
			col_name.Text = "";
			col_name.Width = 125;
			// 
			// col_value
			// 
			col_value.Text = "";
			col_value.TextAlign = HorizontalAlignment.Center;
			// 
			// col_hint
			// 
			col_hint.Text = "";
			col_hint.Width = 300;
			// 
			// lv_variables
			// 
			lv_variables.BackColor = System.Drawing.Color.LightGray;
			lv_variables.BorderStyle = BorderStyle.FixedSingle;
			lv_variables.Columns.AddRange(new ColumnHeader[] { col_name, col_value, col_hint });
			lv_variables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lv_variables.FullRowSelect = true;
			lv_variables.GridLines = true;
			listViewGroup1.Header = "ListViewGroup";
			listViewGroup1.HeaderAlignment = HorizontalAlignment.Center;
			listViewGroup1.Name = "listViewGroup1";
			lv_variables.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });
			lv_variables.HeaderStyle = ColumnHeaderStyle.None;
			listViewItem1.IndentCount = 1;
			listViewItem1.UseItemStyleForSubItems = false;
			listViewItem2.UseItemStyleForSubItems = false;
			listViewItem3.UseItemStyleForSubItems = false;
			listViewItem4.UseItemStyleForSubItems = false;
			listViewItem5.UseItemStyleForSubItems = false;
			listViewItem6.UseItemStyleForSubItems = false;
			listViewItem7.UseItemStyleForSubItems = false;
			listViewItem8.UseItemStyleForSubItems = false;
			listViewItem9.UseItemStyleForSubItems = false;
			listViewItem10.UseItemStyleForSubItems = false;
			listViewItem11.UseItemStyleForSubItems = false;
			listViewItem12.UseItemStyleForSubItems = false;
			listViewItem13.UseItemStyleForSubItems = false;
			listViewItem14.UseItemStyleForSubItems = false;
			listViewItem15.UseItemStyleForSubItems = false;
			listViewItem16.UseItemStyleForSubItems = false;
			lv_variables.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8, listViewItem9, listViewItem10, listViewItem11, listViewItem12, listViewItem13, listViewItem14, listViewItem15, listViewItem16 });
			lv_variables.Location = new System.Drawing.Point(7, 440);
			lv_variables.Margin = new Padding(4, 3, 4, 3);
			lv_variables.MultiSelect = false;
			lv_variables.Name = "lv_variables";
			lv_variables.Scrollable = false;
			lv_variables.ShowGroups = false;
			lv_variables.Size = new System.Drawing.Size(490, 354);
			lv_variables.TabIndex = 18;
			lv_variables.UseCompatibleStateImageBehavior = false;
			lv_variables.View = View.Details;
			// 
			// timer_shuffle
			// 
			timer_shuffle.Interval = 10000;
			timer_shuffle.Tick += timer_shuffle_Tick;
			// 
			// cb_shuffling
			// 
			cb_shuffling.AutoSize = true;
			cb_shuffling.Location = new System.Drawing.Point(163, 8);
			cb_shuffling.Margin = new Padding(4, 3, 4, 3);
			cb_shuffling.Name = "cb_shuffling";
			cb_shuffling.Size = new System.Drawing.Size(74, 19);
			cb_shuffling.TabIndex = 23;
			cb_shuffling.Text = "Shuffling";
			cb_shuffling.UseVisualStyleBackColor = true;
			cb_shuffling.CheckedChanged += cb_shuffling_CheckedChanged;
			// 
			// Form1
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1373, 1018);
			Controls.Add(cb_shuffling);
			Controls.Add(lbl_worldScreen_relativeIndex);
			Controls.Add(lbl_worldScreen_info);
			Controls.Add(label14);
			Controls.Add(tb_selectedWorldScreenIndex);
			Controls.Add(tb_output);
			Controls.Add(btn_loadDefaultRom);
			Controls.Add(gb_drawOptions);
			Controls.Add(btn_refreshWorldScreenList);
			Controls.Add(tabControl1);
			Controls.Add(lv_variables);
			Controls.Add(lv_worldScreens);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Margin = new Padding(4, 3, 4, 3);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			tabControl1.ResumeLayout(false);
			tab_map.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pb_worldMap).EndInit();
			tab_worldScreen.ResumeLayout(false);
			tab_worldScreen.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pb_worldScreen).EndInit();
			gb_worldScreen.ResumeLayout(false);
			gb_worldScreen.PerformLayout();
			tab_tileSection.ResumeLayout(false);
			gb_tileSection.ResumeLayout(false);
			gb_tileSection.PerformLayout();
			gb_microTile.ResumeLayout(false);
			gb_miniTile.ResumeLayout(false);
			gb_miniTile.PerformLayout();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			gb_tile.ResumeLayout(false);
			gb_tile.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pb_tile_Image).EndInit();
			tab_encounters.ResumeLayout(false);
			gb_encounterLineups.ResumeLayout(false);
			gb_encounterGroups.ResumeLayout(false);
			tab_variables.ResumeLayout(false);
			tab_variables.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			menu_pb_worldMap_rightClick.ResumeLayout(false);
			gb_drawOptions.ResumeLayout(false);
			groupBox9.ResumeLayout(false);
			groupBox9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nud_drawOptions_map_tileSize).EndInit();
			groupBox8.ResumeLayout(false);
			groupBox8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nud_drawOptions_worldScreen_showTileImages).EndInit();
			groupBox7.ResumeLayout(false);
			groupBox7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox tb_output;
        private System.Windows.Forms.ListBox lb_tileSection_top;
        private System.Windows.Forms.ListBox lb_tileSection_bottom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_direction_up;
        private System.Windows.Forms.TextBox tb_direction_left;
        private System.Windows.Forms.TextBox tb_direction_right;
        private System.Windows.Forms.Button btn_move_right;
        private System.Windows.Forms.Button btn_move_left;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_move_down;
        private System.Windows.Forms.TextBox tb_direction_down;
        private System.Windows.Forms.Button btn_move_up;
        public System.Windows.Forms.ListView lv_worldScreens;
        private System.Windows.Forms.ColumnHeader col_WorldScreenId;
        private System.Windows.Forms.ColumnHeader col_ParentWorld;
        private System.Windows.Forms.ColumnHeader col_AmbientSound;
        private System.Windows.Forms.ColumnHeader col_Content;
        private System.Windows.Forms.ColumnHeader col_ObjectSet;
        private System.Windows.Forms.ColumnHeader col_ScreenIndexRight;
        private System.Windows.Forms.ColumnHeader col_ScreenIndexLeft;
        private System.Windows.Forms.ColumnHeader col_ScreenIndexDown;
        private System.Windows.Forms.ColumnHeader col_ScreenIndexUp;
        private System.Windows.Forms.ColumnHeader col_DataPointer;
        private System.Windows.Forms.ColumnHeader col_ExitPosition;
        private System.Windows.Forms.ColumnHeader col_TopTiles;
        private System.Windows.Forms.ColumnHeader col_BottomTiles;
        private System.Windows.Forms.ColumnHeader col_WorldScreenColor;
        private System.Windows.Forms.ColumnHeader col_SpritesColor;
        private System.Windows.Forms.ColumnHeader col_Unknown;
        private System.Windows.Forms.ColumnHeader col_Event;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox cb_link_back;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_testDirections;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tab_map;
		private System.Windows.Forms.TabPage tab_worldScreen;
		private TmosPictureBox pb_worldMap;
		private TmosPictureBox pb_worldScreen;
		private System.Windows.Forms.TabPage tab_tileSection;
		private System.Windows.Forms.GroupBox gb_tile;
		private System.Windows.Forms.ListBox lb_tileSection;
		private System.Windows.Forms.GroupBox gb_miniTile;
		private System.Windows.Forms.ListBox lb_tile;
		private System.Windows.Forms.ListBox lb_miniTile;
		private System.Windows.Forms.RichTextBox tb_worldScreen_selectedWorldScreen_data;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tb_worldScreenTile;
        private System.Windows.Forms.ListBox lb_worldScreenTiles;
        private System.Windows.Forms.TabPage tab_encounters;
        private System.Windows.Forms.PictureBox pb_tile_Image;
        private System.Windows.Forms.GroupBox gb_drawOptions;
        private System.Windows.Forms.CheckBox cb_drawOptions_worldScreen_showBorders;
        private System.Windows.Forms.CheckBox cb_drawOptions_worldScreen_showInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_drawOptions_worldScreen_showTileImages;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btn_redraw_worldScreen;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cb_drawOptions_worldScreenTile_showInfo;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox cb_drawOptions_worldScreenTile_showCollision;
        private System.Windows.Forms.CheckBox cb_drawOptions_worldScreenTile_showImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_loadRom;
        private System.Windows.Forms.ToolStripMenuItem menu_saveRom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_loadDefaultRom;
        private System.Windows.Forms.ListView lv_tileSection_values;
        private Button btn_tileSection_data_save;
        private RichTextBox rtb_tileSection_data;
        private Label label6;
        private Button btn_refreshWorldScreenList;
        private TextBox tb_miniTile_data_byte4;
        private TextBox tb_miniTile_data_byte3;
        private TextBox tb_miniTile_data_byte2;
        private TextBox tb_miniTile_data_byte1;
        private TextBox tb_tile_data_byte4;
        private TextBox tb_tile_data_byte3;
        private TextBox tb_tile_data_byte2;
        private TextBox tb_tile_data_byte1;
        private Button btn_loadDefaultRom;
        private GroupBox gb_microTile;
        private Label label10;
        private Label label9;
        private Label label8;
        private GroupBox gb_encounterLineups;
        private RichTextBox rtb_encounterLineups_data;
        private ListBox lb_encounterLinups;
        private GroupBox gb_encounterGroups;
        private RichTextBox rtb_encounterGroups_data;
        private ListBox lb_encounterGroups;
        private Label label11;
        private NumericUpDown nud_drawOptions_map_tileSize;
        private Label lbl_worldScreenTileDataOffsets;
        private Label btnlbl_worldSection_topTiles_view;
        private ColumnHeader col_name;
        private ColumnHeader col_value;
        private ColumnHeader col_hint;
        private ListView lv_variables;
        private Label btnlbl_worldSection_bottomTiles_view;
        private Label lbl_worldScreen_relativeIndex;
        private Label label14;
        private TextBox tb_selectedWorldScreenIndex;
        private Label lbl_worldScreen_info;
        private Button btn_worldScreen_save;
        private ToolStripMenuItem worldScreenToolStripMenuItem;
        private ToolStripMenuItem menu_shuffleWSTileSections;
        private ToolStripMenuItem shuffleTileSectionsKeepCompatableToolStripMenuItem;
        private ToolStripMenuItem shuffleTileSectionsKeepCompatableMultiscreenToolStripMenuItem;
        private Timer timer_shuffle;
        private CheckBox cb_shuffling;
        private Label label12;
        private Label label15;
        private Button btn_encounterLineup_save;
        private Button btn_encounterGroup_save;
        private Label label13;
        private Button btn_tile_save;
        private Button btn_miniTile_save;
        private GroupBox gb_tileSection;
        private Label label7;
        private Label label3;
		private Label label16;
		private ComboBox comboBox_worldScreen_content;
		private GroupBox gb_worldScreen;
		private TabPage tab_variables;
		private ListView lv_knownVariables;
		private ColumnHeader lv_knownVariables_col_name;
		private ColumnHeader lv_knownVariables_col_value;
		private GroupBox groupBox3;
		private Label label18;
		private Label label17;
		private TextBox tb_knownVariables_selectedVariable_value;
		private Label lbl_knownVariables_selectedVariable_variableName;
		private Label label19;
		private Label label20;
		private Label label22;
		private TextBox tb_knownVariables_selectedVariable_description;
		private Label label21;
		private Button btn_knownVariables_selectedVariable_save;
		private ContextMenuStrip menu_pb_worldMap_rightClick;
		private ToolStripMenuItem menu_pb_worldMap_moveWorldScreen;
		private Button btn_map_fix_screen_references;
		private GroupBox groupBox4;
		private Label label24;
		private TextBox tb_map_area_update_DataPointer;
		private Button btn_map_saveAreaScreens;
		private Label label23;
		private TextBox tb_map_area_update_ParentWorld;
		private Label label25;
		private TextBox tb_map_area_update_WorldColor;
		private Label label26;
		private TextBox tb_map_area_update_SpriteColor;
		private Label label27;
		private TextBox tb_map_area_update_AmbientSound;
		private ToolStripMenuItem menu_pb_worldMap_copyWorldSceen;
		private ToolStripMenuItem menu_pb_worldMap_pasteWorldSceen;
	}
}

