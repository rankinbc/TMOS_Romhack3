using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}
