using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019B1 RID: 6577
	public class JoinPK3v3CrossFrame : ClientFrame
	{
		// Token: 0x06010105 RID: 65797 RVA: 0x00476702 File Offset: 0x00474B02
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/JoinPk3v3Cross";
		}

		// Token: 0x06010106 RID: 65798 RVA: 0x0047670C File Offset: 0x00474B0C
		private void ExitTeamAndEnterPk3v3Cross()
		{
			DataManager<TeamDataManager>.GetInstance().QuitTeam(DataManager<PlayerBaseData>.GetInstance().RoleID);
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(true);
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = 5007,
				targetDoorID = 0
			}, false));
		}

		// Token: 0x06010107 RID: 65799 RVA: 0x004767E4 File Offset: 0x00474BE4
		protected override void _OnOpenFrame()
		{
			if (this.m_btnJoin != null)
			{
				this.m_btnJoin.onClick.RemoveAllListeners();
				this.m_btnJoin.onClick.AddListener(delegate()
				{
					if (this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
					{
						SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
					if (scoreWarStatus != ScoreWarStatus.SWS_PREPARE && scoreWarStatus != ScoreWarStatus.SWS_BATTLE)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("活动未开始或者已结束，无法进入活动场景", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					if (DataManager<TeamDataManager>.GetInstance().HasTeam())
					{
						SystemNotifyManager.SysNotifyMsgBoxOkCancel("进入积分赛场景会退出当前所在队伍，是否确认进入？", delegate()
						{
							this.ExitTeamAndEnterPk3v3Cross();
							this.frameMgr.CloseFrame<JoinPK3v3CrossFrame>(this, false);
						}, null, 0f, false);
					}
					else
					{
						ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
						if (clientSystemTown == null)
						{
							return;
						}
						if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
						{
							return;
						}
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
						if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
						{
							ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
							clientSystemTownFrame.SetForbidFadeIn(true);
						}
						MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
						{
							currSceneID = clientSystemTown.CurrentSceneID,
							currDoorID = 0,
							targetSceneID = 5007,
							targetDoorID = 0
						}, false));
						this.frameMgr.CloseFrame<JoinPK3v3CrossFrame>(this, false);
					}
				});
			}
			if (this.m_btnClose != null)
			{
				this.m_btnClose.onClick.RemoveAllListeners();
				this.m_btnClose.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<JoinPK3v3CrossFrame>(this, false);
				});
			}
			int id = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ScoreWarRewardTable>();
			if (table == null)
			{
				Logger.LogErrorFormat("TableManager.instance.GetTable<ScoreWarRewardTable>() error!!!", new object[0]);
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ScoreWarRewardTable scoreWarRewardTable = keyValuePair.Value as ScoreWarRewardTable;
				if (scoreWarRewardTable != null)
				{
					if (scoreWarRewardTable.RewardPreview.Count > 1)
					{
						id = scoreWarRewardTable.ID;
						break;
					}
				}
			}
			ScoreWarRewardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ScoreWarRewardTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.RewardPreview.Count; i++)
				{
					string text = tableItem.RewardPreviewArray(i);
					string[] array = text.Split(new char[]
					{
						'_'
					});
					if (array.Length >= 2)
					{
						int tableId = int.Parse(array[0]);
						int count = int.Parse(array[1]);
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
						if (itemData != null)
						{
							itemData.Count = count;
							if (i < 4)
							{
								ComItem com = this.mBind.GetCom<ComItem>(string.Format("Item{0}", i));
								if (com != null)
								{
									com.Setup(itemData, delegate(GameObject var1, ItemData var2)
									{
										DataManager<ItemTipManager>.GetInstance().CloseAll();
										DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
									});
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06010108 RID: 65800 RVA: 0x004769D8 File Offset: 0x00474DD8
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x06010109 RID: 65801 RVA: 0x004769DA File Offset: 0x00474DDA
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x0601010A RID: 65802 RVA: 0x004769DD File Offset: 0x00474DDD
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0400A22F RID: 41519
		[UIControl("Join", null, 0)]
		private Button m_btnJoin;

		// Token: 0x0400A230 RID: 41520
		[UIControl("Close", null, 0)]
		private Button m_btnClose;

		// Token: 0x0400A231 RID: 41521
		private const int ITEM_NUM = 4;
	}
}
