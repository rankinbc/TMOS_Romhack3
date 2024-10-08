﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.Mods.Map;

namespace Tmos.Romhacks.UI.Forms
{
	public  class FormUserControlState
	{
		public FormUserActionState CurrentUserAction { get; set; }
 
		public int SelectedWorldScreenIndex { get; set; }
		public int SelectedWorldScreenTileIndex { get; set; }
		public int SelectedTileSectionIndex { get; set; }
		public int SelectedTileIndex { get; set; }
		public int SelectedMiniTileIndex { get; set; }
		public int SelectedRandomEncounterGroupIndex { get; set; }
		public int SelectedRandomEncounterLineupIndex { get; set; }
		public Point SelectedWorldMapGridCell { get; set; }
		public Point SelectedWorldMapGridCell_Secondary { get; set; }

		private byte[] WorldScreenClipBoard { get; set; }

		public FormUserControlState()
		{
			CurrentUserAction = FormUserActionState.None;
			SelectedWorldScreenIndex = -1;
			SelectedWorldScreenTileIndex = -1;
			SelectedTileSectionIndex = -1;
			SelectedTileIndex = -1;
			SelectedMiniTileIndex = -1;
			SelectedRandomEncounterGroupIndex = -1;
			SelectedRandomEncounterLineupIndex = -1;
			SelectedWorldMapGridCell = new Point(-1, -1);
			SelectedWorldMapGridCell_Secondary = new Point(-1, -1);
		}

		public void CopyWorldScreen(TmosModWorldScreen tmosWorldScreen)
		{
			WorldScreenClipBoard = tmosWorldScreen.GetBytes();
		}
		public TmosModWorldScreen GetWorldScreenInClipboard()
		{
			return new TmosModWorldScreen(WorldScreenClipBoard);
		}

		public void SelectWorldMapGridCell(int x, int y, ref WorldAreaGrid grid)
		{
			if (x > grid.GetGridSizeX() || x < 0)
			{
				throw new IndexOutOfRangeException($"X coordinate {x} is outsite the X range of {grid.GetGridSizeX()}");
			}
			if (y > grid.GetGridSizeY() || y < 0)
			{
				throw new IndexOutOfRangeException($"Y coordinate {y} is outisde the Y range of {grid.GetGridSizeY()}");
			}


			SelectedWorldMapGridCell = new Point(x, y);
			WSGridCell selectedCell = grid.GetCell(x, y);
			if (grid.GetCell(x, y).IsEmpty())
			{
				SelectedWorldScreenIndex = -1;
			}
			else
			{
				SelectedWorldScreenIndex = (int)selectedCell.WorldScreenIndex ;
			}
		}

	}
}
