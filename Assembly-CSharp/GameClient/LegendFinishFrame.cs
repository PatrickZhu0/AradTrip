using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001712 RID: 5906
	internal class LegendFinishFrame : ClientFrame
	{
		// Token: 0x0600E82D RID: 59437 RVA: 0x003D5756 File Offset: 0x003D3B56
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LegendFrame/LegendFinishFrame";
		}

		// Token: 0x0600E82E RID: 59438 RVA: 0x003D5760 File Offset: 0x003D3B60
		public static void OpenLinkFrame(string strParam)
		{
			string[] array = strParam.Split(new char[]
			{
				'|'
			});
			if (array.Length < 2)
			{
				return;
			}
			int id = 0;
			if (!int.TryParse(array[0], out id))
			{
				return;
			}
			int iSeriesID = 0;
			if (!int.TryParse(array[1], out iSeriesID))
			{
				return;
			}
			LinkTable linkItem = null;
			if (array.Length == 3)
			{
				int id2 = 0;
				if (int.TryParse(array[1], out id2))
				{
					linkItem = Singleton<TableManager>.GetInstance().GetTableItem<LinkTable>(id2, string.Empty, string.Empty);
				}
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<LegendFinishFrame>(FrameLayer.Middle, new LegendFinishFrameData
			{
				missionItem = tableItem,
				linkItem = linkItem,
				iSeriesID = iSeriesID
			}, string.Empty);
		}

		// Token: 0x0600E82F RID: 59439 RVA: 0x003D5834 File Offset: 0x003D3C34
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as LegendFinishFrameData);
			base._AddButton("Bg/BG/Close", delegate
			{
				this.frameMgr.CloseFrame<LegendFinishFrame>(this, false);
			});
			if (this.data != null)
			{
				GameObject goParent = Utility.FindChild(this.frame, "Bg/BG/ItemParent");
				ComItem comItem = base.CreateComItem(goParent);
				List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(this.data.missionItem.ID, -1);
				ItemData itemData = null;
				if (missionAwards != null && missionAwards.Count > 0)
				{
					itemData = ItemDataManager.CreateItemDataFromTable(missionAwards[0].ID, 100, 0);
					itemData.Count = missionAwards[0].Num;
				}
				if (null != comItem)
				{
					comItem.Setup(itemData, delegate(GameObject obj, ItemData item)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
					});
				}
				Text text = Utility.FindComponent<Text>(this.frame, "Bg/BG/Name", true);
				if (itemData != null)
				{
					text.text = itemData.GetColorName(string.Empty, false);
				}
				Text text2 = Utility.FindComponent<Text>(this.frame, "Bg/BG/Desc", true);
				text2.text = TR.Value("legend_mission_finish_hint", this.data.missionItem.TaskName);
			}
		}

		// Token: 0x0600E830 RID: 59440 RVA: 0x003D5974 File Offset: 0x003D3D74
		protected override void _OnCloseFrame()
		{
			if (this.data.linkItem != null && this.data.missionItem != null && Utility.IsLegendSeriesOverOnce(this.data.iSeriesID, this.data.missionItem.ID))
			{
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(this.data.linkItem.LinkInfo, null, false);
			}
			this.data = null;
		}

		// Token: 0x04008CC4 RID: 36036
		private LegendFinishFrameData data;
	}
}
