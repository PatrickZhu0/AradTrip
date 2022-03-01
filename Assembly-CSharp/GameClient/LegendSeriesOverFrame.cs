using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200171E RID: 5918
	internal class LegendSeriesOverFrame : ClientFrame
	{
		// Token: 0x0600E88C RID: 59532 RVA: 0x003D80C2 File Offset: 0x003D64C2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LegendFrame/LegendSeriesOverFrame";
		}

		// Token: 0x0600E88D RID: 59533 RVA: 0x003D80CC File Offset: 0x003D64CC
		public static void OpenLinkFrame(string strParam)
		{
			int id = 0;
			if (!int.TryParse(strParam, out id))
			{
				return;
			}
			LegendMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LegendMainTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<LegendSeriesOverFrame>(FrameLayer.Middle, new LegendSeriesOverFrameData
			{
				mainItem = tableItem
			}, string.Empty);
		}

		// Token: 0x0600E88E RID: 59534 RVA: 0x003D8128 File Offset: 0x003D6528
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as LegendSeriesOverFrameData);
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<LegendSeriesOverFrame>(this, false);
			});
			GameObject parent = Utility.FindChild(this.frame, "AwardArray");
			GameObject gameObject = Utility.FindChild(this.frame, "AwardArray/Item");
			gameObject.CustomActive(false);
			StateController component = this.frame.GetComponent<StateController>();
			for (int i = 0; i < this.data.mainItem.missionIds.Count; i++)
			{
				MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.data.mainItem.missionIds[i], string.Empty, string.Empty);
				if (tableItem != null && tableItem.MissionOnOff == 1)
				{
					List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(tableItem.ID, -1);
					if (missionAwards != null)
					{
						for (int j = 0; j < missionAwards.Count; j++)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(missionAwards[j].ID, 100, 0);
							if (itemData != null && missionAwards[j].Num > 0)
							{
								itemData.Count = missionAwards[j].Num;
								GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
								if (null != gameObject2)
								{
									Utility.AttachTo(gameObject2, parent, false);
									gameObject2.CustomActive(true);
									ComItem comItem = base.CreateComItem(Utility.FindChild(gameObject2, "ItemParent").gameObject);
									comItem.Setup(itemData, null);
									Text text = Utility.FindComponent<Text>(gameObject2, "Name", true);
									text.text = itemData.GetColorName(string.Empty, false);
								}
							}
						}
					}
				}
			}
			if (null != component)
			{
				component.Key = this.data.mainItem.ID.ToString();
			}
		}

		// Token: 0x0600E88F RID: 59535 RVA: 0x003D8314 File Offset: 0x003D6714
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x04008CF6 RID: 36086
		private LegendSeriesOverFrameData data;
	}
}
