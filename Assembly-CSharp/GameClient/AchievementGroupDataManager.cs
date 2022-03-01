using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011A6 RID: 4518
	public class AchievementGroupDataManager : DataManager<AchievementGroupDataManager>
	{
		// Token: 0x0600AD47 RID: 44359 RVA: 0x0025AEE4 File Offset: 0x002592E4
		public override void Initialize()
		{
			NetProcess.RemoveMsgHandler(501157U, new Action<MsgDATA>(this._OnRecvSceneAchievementScoreRewardRes));
		}

		// Token: 0x0600AD48 RID: 44360 RVA: 0x0025AEFC File Offset: 0x002592FC
		public override void Clear()
		{
			NetProcess.AddMsgHandler(501157U, new Action<MsgDATA>(this._OnRecvSceneAchievementScoreRewardRes));
		}

		// Token: 0x0600AD49 RID: 44361 RVA: 0x0025AF14 File Offset: 0x00259314
		private void _OnRecvSceneAchievementScoreRewardRes(MsgDATA msg)
		{
			SceneAchievementScoreRewardRes sceneAchievementScoreRewardRes = new SceneAchievementScoreRewardRes();
			sceneAchievementScoreRewardRes.decode(msg.bytes);
			if (sceneAchievementScoreRewardRes.result != 0U)
			{
			}
		}

		// Token: 0x0600AD4A RID: 44362 RVA: 0x0025AF40 File Offset: 0x00259340
		public static void OnLink2FixedAchievementItem(string param)
		{
			if (!string.IsNullOrEmpty(param))
			{
				int iId = 0;
				if (int.TryParse(param, out iId))
				{
					AchievementGroupDataManager.OnLink2FixedAchievementItemById(iId);
				}
			}
		}

		// Token: 0x0600AD4B RID: 44363 RVA: 0x0025AF70 File Offset: 0x00259370
		public static void OnLink2FixedAchievementItemById(int iId)
		{
			if (Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSubItemTable>(iId, string.Empty, string.Empty) == null)
			{
				return;
			}
			int belongTabByID = DataManager<AchievementGroupDataManager>.GetInstance().GetBelongTabByID(iId);
			if (belongTabByID == 0)
			{
				return;
			}
			ActiveGroupMainFrame.CommandOpen(new ActiveGroupMainFrameData
			{
				iTabID = belongTabByID
			});
		}

		// Token: 0x0600AD4C RID: 44364 RVA: 0x0025AFC0 File Offset: 0x002593C0
		public int GetBelongTabByID(int iId)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AchievementGroupSecondMenuTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AchievementGroupSecondMenuTable achievementGroupSecondMenuTable = keyValuePair.Value as AchievementGroupSecondMenuTable;
					if (achievementGroupSecondMenuTable != null)
					{
						for (int i = 0; i < achievementGroupSecondMenuTable.SubItemID.Count; i++)
						{
							if (iId == achievementGroupSecondMenuTable.SubItemID[i])
							{
								return achievementGroupSecondMenuTable.ID;
							}
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600AD4D RID: 44365 RVA: 0x0025B04C File Offset: 0x0025944C
		public void GetSubItemsByTag(AchievementGroupMainItemTable mainItem, AchievementGroupSecondMenuTable menuItem, ref List<AchievementGroupSubItemTable> subItems)
		{
			if (subItems == null)
			{
				subItems = new List<AchievementGroupSubItemTable>(32);
			}
			subItems.Clear();
			if (menuItem != null)
			{
				for (int i = 0; i < menuItem.SubItemID.Count; i++)
				{
					AchievementGroupSubItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSubItemTable>(menuItem.SubItemID[i], string.Empty, string.Empty);
					if (tableItem != null)
					{
						subItems.Add(tableItem);
					}
				}
			}
			else if (mainItem != null)
			{
				if (mainItem.ChildTabs.Count <= 0 || (mainItem.ChildTabs.Count == 1 && mainItem.ChildTabs[0] == 0))
				{
					Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AchievementGroupSecondMenuTable>();
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						menuItem = (keyValuePair.Value as AchievementGroupSecondMenuTable);
						if (menuItem != null)
						{
							for (int j = 0; j < menuItem.SubItemID.Count; j++)
							{
								AchievementGroupSubItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSubItemTable>(menuItem.SubItemID[j], string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									subItems.Add(tableItem2);
								}
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < mainItem.ChildTabs.Count; k++)
					{
						menuItem = Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSecondMenuTable>(mainItem.ChildTabs[k], string.Empty, string.Empty);
						if (menuItem != null)
						{
							for (int l = 0; l < menuItem.SubItemID.Count; l++)
							{
								AchievementGroupSubItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSubItemTable>(menuItem.SubItemID[l], string.Empty, string.Empty);
								if (tableItem3 != null)
								{
									subItems.Add(tableItem3);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600AD4E RID: 44366 RVA: 0x0025B234 File Offset: 0x00259634
		public int GetSubItemsAValue(AchievementGroupMainItemTable mainItem, AchievementGroupSecondMenuTable menuItem, bool bFinish)
		{
			int num = 0;
			List<AchievementGroupSubItemTable> list = null;
			if (mainItem == null)
			{
				if (this.mListItems == null)
				{
					this._InitAllListItems();
				}
				list = this.mListItems;
			}
			else
			{
				this.GetSubItemsByTag(mainItem, menuItem, ref list);
			}
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (bFinish)
					{
						MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)list[i].ID);
						if (mission != null && mission.missionItem != null && mission.status == 5)
						{
							num += mission.missionItem.IntParam0;
						}
					}
					else
					{
						MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(list[i].ID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							num += tableItem.IntParam0;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600AD4F RID: 44367 RVA: 0x0025B310 File Offset: 0x00259710
		private void _InitAllListItems()
		{
			if (this.mListItems == null)
			{
				this.mListItems = new List<AchievementGroupSubItemTable>(32);
				foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<AchievementGroupSubItemTable>())
				{
					AchievementGroupSubItemTable item = keyValuePair.Value as AchievementGroupSubItemTable;
					this.mListItems.Add(item);
				}
			}
		}

		// Token: 0x0600AD50 RID: 44368 RVA: 0x0025B377 File Offset: 0x00259777
		public void GetAllItems(ref List<AchievementGroupSubItemTable> items)
		{
			if (this.mListItems == null)
			{
				this._InitAllListItems();
			}
			if (items == null)
			{
				items = new List<AchievementGroupSubItemTable>();
			}
			items.Clear();
			items.AddRange(this.mListItems);
		}

		// Token: 0x0600AD51 RID: 44369 RVA: 0x0025B3AC File Offset: 0x002597AC
		public AchievementLevelInfoTable GetAchievementLevelByPoint(int iPoint)
		{
			AchievementLevelInfoTable result = null;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AchievementLevelInfoTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AchievementLevelInfoTable achievementLevelInfoTable = keyValuePair.Value as AchievementLevelInfoTable;
					result = achievementLevelInfoTable;
					if (achievementLevelInfoTable != null && achievementLevelInfoTable.Min <= iPoint && achievementLevelInfoTable.Max >= iPoint)
					{
						return achievementLevelInfoTable;
					}
				}
			}
			return result;
		}

		// Token: 0x0600AD52 RID: 44370 RVA: 0x0025B41D File Offset: 0x0025981D
		private int _SortItemByFlag(AchievementGroupSubItemTable left, AchievementGroupSubItemTable right)
		{
			return left.sort1 - right.sort1;
		}

		// Token: 0x0600AD53 RID: 44371 RVA: 0x0025B42C File Offset: 0x0025982C
		private int _SortItemByAll(AchievementGroupSubItemTable left, AchievementGroupSubItemTable right)
		{
			return left.sort0 - right.sort0;
		}

		// Token: 0x0600AD54 RID: 44372 RVA: 0x0025B43C File Offset: 0x0025983C
		public void SendGetAward(int id)
		{
			SceneAchievementScoreRewardReq sceneAchievementScoreRewardReq = new SceneAchievementScoreRewardReq();
			sceneAchievementScoreRewardReq.rewardId = (uint)id;
			NetManager.Instance().SendCommand<SceneAchievementScoreRewardReq>(ServerType.GATE_SERVER, sceneAchievementScoreRewardReq);
		}

		// Token: 0x0600AD55 RID: 44373 RVA: 0x0025B464 File Offset: 0x00259864
		public int GetFirstUnAcquiredID()
		{
			AchievementMaskProperty achievementMaskProperty = DataManager<PlayerBaseData>.GetInstance().AchievementMaskProperty;
			if (achievementMaskProperty != null)
			{
				int count = Singleton<TableManager>.GetInstance().GetTable<AchievementLevelInfoTable>().Count;
				uint num = 0U;
				while (num < achievementMaskProperty.maskSize && (ulong)num < (ulong)((long)count))
				{
					int num2 = (int)(num + 1U);
					if (Singleton<TableManager>.GetInstance().GetTableItem<AchievementLevelInfoTable>(num2, string.Empty, string.Empty) != null)
					{
						if (!achievementMaskProperty.CheckMask((uint)num2))
						{
							return num2;
						}
					}
					num += 1U;
				}
			}
			return 0;
		}

		// Token: 0x0600AD56 RID: 44374 RVA: 0x0025B4E8 File Offset: 0x002598E8
		public int GetLastAcquiredID()
		{
			if (this._LastId == 0)
			{
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AchievementLevelInfoTable>();
				if (table != null)
				{
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						AchievementLevelInfoTable achievementLevelInfoTable = keyValuePair.Value as AchievementLevelInfoTable;
						if (achievementLevelInfoTable != null)
						{
							this._LastId = achievementLevelInfoTable.ID;
						}
					}
				}
			}
			return this._LastId;
		}

		// Token: 0x0600AD57 RID: 44375 RVA: 0x0025B558 File Offset: 0x00259958
		public bool IsAchievementFinished(int iId)
		{
			if (Singleton<TableManager>.GetInstance().GetTableItem<AchievementLevelInfoTable>(iId, string.Empty, string.Empty) == null)
			{
				return false;
			}
			AchievementMaskProperty achievementMaskProperty = DataManager<PlayerBaseData>.GetInstance().AchievementMaskProperty;
			return achievementMaskProperty != null && achievementMaskProperty.CheckMask((uint)iId);
		}

		// Token: 0x0600AD58 RID: 44376 RVA: 0x0025B5A5 File Offset: 0x002599A5
		public bool IsAllAchievementFinished()
		{
			return 0 == this.GetFirstUnAcquiredID();
		}

		// Token: 0x04006110 RID: 24848
		private List<AchievementGroupSubItemTable> mListItems;

		// Token: 0x04006111 RID: 24849
		private int _LastId;
	}
}
