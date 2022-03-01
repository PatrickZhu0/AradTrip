using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200193D RID: 6461
	public class ZillionaireGameView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600FB24 RID: 64292 RVA: 0x0044CF28 File Offset: 0x0044B328
		private void Awake()
		{
			if (this.turnTableBtn != null)
			{
				this.turnTableBtn.onClick.RemoveAllListeners();
				this.turnTableBtn.onClick.AddListener(new UnityAction(this.OnTurnBtnClick));
			}
			if (this.helpBtn != null)
			{
				this.helpBtn.onClick.RemoveAllListeners();
				this.helpBtn.onClick.AddListener(new UnityAction(this.OnHelpBtnClick));
			}
			if (this.shopBtn != null)
			{
				this.shopBtn.onClick.RemoveAllListeners();
				this.shopBtn.onClick.AddListener(new UnityAction(this.OnShopBtnClick));
			}
			if (this.buffInfoBtn != null)
			{
				this.buffInfoBtn.onClick.RemoveAllListeners();
				this.buffInfoBtn.onClick.AddListener(new UnityAction(this.OnBuffInfoBtnClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonopolyRollResSuccessed, new ClientEventSystem.UIEventHandler(this.OnMonopolyRollResSuccessed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnZillionaireGameInfoChanged, new ClientEventSystem.UIEventHandler(this.OnZillionaireGameInfoChanged));
		}

		// Token: 0x0600FB25 RID: 64293 RVA: 0x0044D060 File Offset: 0x0044B460
		private void OnDestroy()
		{
			if (this.turnTableBtn != null)
			{
				this.turnTableBtn.onClick.RemoveListener(new UnityAction(this.OnTurnBtnClick));
			}
			if (this.helpBtn != null)
			{
				this.helpBtn.onClick.RemoveListener(new UnityAction(this.OnHelpBtnClick));
			}
			if (this.shopBtn != null)
			{
				this.shopBtn.onClick.RemoveListener(new UnityAction(this.OnShopBtnClick));
			}
			if (this.buffInfoBtn != null)
			{
				this.buffInfoBtn.onClick.RemoveListener(new UnityAction(this.OnBuffInfoBtnClick));
			}
			this.bIsStartTurn = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonopolyRollResSuccessed, new ClientEventSystem.UIEventHandler(this.OnMonopolyRollResSuccessed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnZillionaireGameInfoChanged, new ClientEventSystem.UIEventHandler(this.OnZillionaireGameInfoChanged));
		}

		// Token: 0x0600FB26 RID: 64294 RVA: 0x0044D160 File Offset: 0x0044B560
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (this.time != null)
			{
				this.time.text = Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime);
			}
			this.InitMap();
			this.RefreshInfo();
			this.RefreshTurnCount();
			this.Show();
		}

		// Token: 0x0600FB27 RID: 64295 RVA: 0x0044D1B4 File Offset: 0x0044B5B4
		private void InitMap()
		{
			List<MapGridItemData> gridItemDataList = DataManager<ZillionaireGameDataManager>.GetInstance().GetGridItemDataList(DataManager<ZillionaireGameDataManager>.GetInstance().Turn);
			if (this.gridMapController != null)
			{
				this.gridMapController.InitMap(gridItemDataList, new OnMoveTargetItemClick(this.OnMoveTargetItemClick), DataManager<ZillionaireGameDataManager>.GetInstance().CurrentGrid);
			}
		}

		// Token: 0x0600FB28 RID: 64296 RVA: 0x0044D20C File Offset: 0x0044B60C
		private void RefreshMap(int iCylinderNumber = 1, int position = 0)
		{
			List<MapGridItemData> gridItemDataList = DataManager<ZillionaireGameDataManager>.GetInstance().GetGridItemDataList(iCylinderNumber);
			if (this.gridMapController != null)
			{
				this.gridMapController.RefreshGridMap(gridItemDataList, position);
			}
		}

		// Token: 0x0600FB29 RID: 64297 RVA: 0x0044D244 File Offset: 0x0044B644
		private void OnMoveTargetItemClick(MapGridItemData mapGridItemData)
		{
			if (mapGridItemData == null)
			{
				return;
			}
			List<ItemData> list = new List<ItemData>();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < DataManager<ZillionaireGameDataManager>.GetInstance().realRewardList.Count; i++)
			{
				RealRewardData realRewardData = DataManager<ZillionaireGameDataManager>.GetInstance().realRewardList[i];
				if (realRewardData != null)
				{
					MonopolyRandomTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MonopolyRandomTable>(realRewardData.tableId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						int.TryParse(tableItem.param, out num);
						if (mapGridItemData.gridType != 5)
						{
							int.TryParse(tableItem.num, out num2);
							num3 = 0;
							if (tableItem.type == 4)
							{
								num3 = realRewardData.cardId;
							}
							else if (tableItem.type == 1)
							{
								if (DataManager<ZillionaireGameDataManager>.GetInstance().BeforeBuff > 0)
								{
									num2 += (int)((float)(DataManager<ZillionaireGameDataManager>.GetInstance().BeforeBuff * num2) / 100f);
									DataManager<ZillionaireGameDataManager>.GetInstance().BeforeBuff = 0;
								}
							}
							else if (tableItem.type == 2)
							{
								num2 = 1;
							}
							ItemData itemData;
							if (num3 > 0)
							{
								itemData = ItemDataManager.CreateItemDataFromTable(num3, 100, 0);
							}
							else
							{
								itemData = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
							}
							if (itemData != null)
							{
								itemData.Count = num2;
								list.Add(itemData);
							}
						}
					}
				}
			}
			if (mapGridItemData.gridType == 11)
			{
				List<JarBonus> list2 = new List<JarBonus>();
				list2.Add(new JarBonus
				{
					nBonusID = 0,
					item = ItemDataManager.CreateItemDataFromTable(600000007, 100, 0),
					item = 
					{
						Count = 2
					},
					bHighValue = false
				});
				JarBonus jarBonus = new JarBonus();
				jarBonus.nBonusID = num;
				jarBonus.item = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
				if (jarBonus.item != null)
				{
					jarBonus.item.Count = num2;
				}
				jarBonus.bHighValue = false;
				list2.Add(jarBonus);
				ShowItemsFrameData showItemsFrameData = new ShowItemsFrameData();
				showItemsFrameData.data = DataManager<JarDataManager>.GetInstance().GetJarData(this.iJarId);
				showItemsFrameData.items = list2;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShowItemsFrame>(FrameLayer.Middle, showItemsFrameData, string.Empty);
			}
			else if (mapGridItemData.gridType == 4)
			{
				ZillionaireGameTurntableData zillionaireGameTurntableData = new ZillionaireGameTurntableData();
				zillionaireGameTurntableData.itemSimpleDataList = new List<ItemSimpleData>();
				zillionaireGameTurntableData.itemSimpleDataList.AddRange(mapGridItemData.rewardList);
				zillionaireGameTurntableData.rewardItemId = num;
				zillionaireGameTurntableData.rewardCount = num2;
				zillionaireGameTurntableData.realRewardItemId = num3;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ZillionaireGameTurntableFrame>(FrameLayer.Middle, zillionaireGameTurntableData, string.Empty);
			}
			else if (mapGridItemData.gridType == 5)
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
				if (clientSystemTown != null)
				{
					SceneDungeonStartReq cmd = new SceneDungeonStartReq
					{
						dungeonId = (uint)num
					};
					NetManager.Instance().SendCommand<SceneDungeonStartReq>(ServerType.GATE_SERVER, cmd);
				}
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
			}
			else if (mapGridItemData.gridType == 2)
			{
				this.RefreshMap(DataManager<ZillionaireGameDataManager>.GetInstance().Turn, DataManager<ZillionaireGameDataManager>.GetInstance().CurrentGrid);
				this.SysNotifyGetNewItemEffect(list);
			}
			else
			{
				this.SysNotifyGetNewItemEffect(list);
			}
			this.bIsStartTurn = false;
			this.RefreshInfo();
			DataManager<ZillionaireGameDataManager>.GetInstance().ClearRealRewardList();
		}

		// Token: 0x0600FB2A RID: 64298 RVA: 0x0044D58C File Offset: 0x0044B98C
		private void SysNotifyGetNewItemEffect(List<ItemData> itemDataList)
		{
			if (itemDataList == null)
			{
				return;
			}
			for (int i = 0; i < itemDataList.Count; i++)
			{
				SystemNotifyManager.SysNotifyGetNewItemEffect(itemDataList[i], false, string.Empty);
			}
		}

		// Token: 0x0600FB2B RID: 64299 RVA: 0x0044D5CC File Offset: 0x0044B9CC
		private void RefreshInfo()
		{
			if (this.coinCount != null)
			{
				this.coinCount.text = string.Format("x{0}", DataManager<ZillionaireGameDataManager>.GetInstance().CoinCount);
			}
			if (this.buffInfo != null)
			{
				this.buffInfo.text = string.Format("{0}%", DataManager<ZillionaireGameDataManager>.GetInstance().Buff);
			}
		}

		// Token: 0x0600FB2C RID: 64300 RVA: 0x0044D643 File Offset: 0x0044BA43
		private void RefreshTurnCount()
		{
			if (this.turnTableCount != null)
			{
				this.turnTableCount.text = string.Format("x{0}", DataManager<ZillionaireGameDataManager>.GetInstance().RollTimes);
			}
		}

		// Token: 0x0600FB2D RID: 64301 RVA: 0x0044D67C File Offset: 0x0044BA7C
		private void OnTurnBtnClick()
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SysNotifyFloatingEffect("组队状态无法参与此活动", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.bIsStartTurn)
			{
				return;
			}
			if (DataManager<ZillionaireGameDataManager>.GetInstance().RollTimes <= 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("轮盘数量不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.bIsStartTurn = true;
			DataManager<ZillionaireGameDataManager>.GetInstance().ClearRealRewardList();
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyRollReq();
		}

		// Token: 0x0600FB2E RID: 64302 RVA: 0x0044D6E9 File Offset: 0x0044BAE9
		private void OnHelpBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ZillionaireGameRuleFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600FB2F RID: 64303 RVA: 0x0044D6FD File Offset: 0x0044BAFD
		private void OnShopBtnClick()
		{
			DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(this.iShopId, 0, 0, -1);
		}

		// Token: 0x0600FB30 RID: 64304 RVA: 0x0044D714 File Offset: 0x0044BB14
		private void OnBuffInfoBtnClick()
		{
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(this.iBuffItemID, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600FB31 RID: 64305 RVA: 0x0044D740 File Offset: 0x0044BB40
		private void OnMonopolyRollResSuccessed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null)
			{
				return;
			}
			int pos = (int)uiEvent.Param1;
			if (this.gridMapController != null)
			{
				this.gridMapController.OnSetMaskGo(true);
			}
			if (this.theLuckyRoller != null)
			{
				this.theLuckyRoller.RotateUp(this.iDiceAllCount, this.iDiceAllCount - pos, true, delegate
				{
					int num = DataManager<ZillionaireGameDataManager>.GetInstance().CurrentGrid;
					if (DataManager<ZillionaireGameDataManager>.GetInstance().CurrentGrid == 0)
					{
						num = this.allGridCount - 1;
					}
					int curPosition = num - pos;
					if (this.gridMapController != null)
					{
						this.gridMapController.StartMovePosition(curPosition, num);
					}
				});
			}
		}

		// Token: 0x0600FB32 RID: 64306 RVA: 0x0044D7D7 File Offset: 0x0044BBD7
		private void OnZillionaireGameInfoChanged(UIEvent uiEvent)
		{
			if (!this.bIsStartTurn)
			{
				this.RefreshInfo();
			}
			this.RefreshTurnCount();
		}

		// Token: 0x0600FB33 RID: 64307 RVA: 0x0044D7F0 File Offset: 0x0044BBF0
		public void UpdateData(ILimitTimeActivityModel data)
		{
		}

		// Token: 0x0600FB34 RID: 64308 RVA: 0x0044D7F2 File Offset: 0x0044BBF2
		public void Close()
		{
		}

		// Token: 0x0600FB35 RID: 64309 RVA: 0x0044D7F4 File Offset: 0x0044BBF4
		public void Dispose()
		{
		}

		// Token: 0x0600FB36 RID: 64310 RVA: 0x0044D7F6 File Offset: 0x0044BBF6
		public void Hide()
		{
		}

		// Token: 0x0600FB37 RID: 64311 RVA: 0x0044D7F8 File Offset: 0x0044BBF8
		public void Show()
		{
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyCoinReq();
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyStatusReq();
		}

		// Token: 0x0600FB38 RID: 64312 RVA: 0x0044D810 File Offset: 0x0044BC10
		public void OnEnterDungeon()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown != null)
			{
				SceneDungeonStartReq cmd = new SceneDungeonStartReq
				{
					dungeonId = (uint)this.iDungeonID
				};
				NetManager.Instance().SendCommand<SceneDungeonStartReq>(ServerType.GATE_SERVER, cmd);
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
		}

		// Token: 0x04009CEE RID: 40174
		[SerializeField]
		private Text time;

		// Token: 0x04009CEF RID: 40175
		[SerializeField]
		private Text buffInfo;

		// Token: 0x04009CF0 RID: 40176
		[SerializeField]
		private Text coinCount;

		// Token: 0x04009CF1 RID: 40177
		[SerializeField]
		private Text turnTableCount;

		// Token: 0x04009CF2 RID: 40178
		[SerializeField]
		private Button helpBtn;

		// Token: 0x04009CF3 RID: 40179
		[SerializeField]
		private Button shopBtn;

		// Token: 0x04009CF4 RID: 40180
		[SerializeField]
		private Button turnTableBtn;

		// Token: 0x04009CF5 RID: 40181
		[SerializeField]
		private Button buffInfoBtn;

		// Token: 0x04009CF6 RID: 40182
		[SerializeField]
		private GridMapController gridMapController;

		// Token: 0x04009CF7 RID: 40183
		[SerializeField]
		private TheLuckyRoller theLuckyRoller;

		// Token: 0x04009CF8 RID: 40184
		[Header("罐子表Id")]
		[SerializeField]
		private int iJarId = 10001;

		// Token: 0x04009CF9 RID: 40185
		[Header("总格子数量")]
		[SerializeField]
		private int allGridCount = 32;

		// Token: 0x04009CFA RID: 40186
		[Header("商店id")]
		[SerializeField]
		private int iShopId = 38;

		// Token: 0x04009CFB RID: 40187
		[Header("地下城ID")]
		[SerializeField]
		private int iDungeonID = 2005000;

		// Token: 0x04009CFC RID: 40188
		[Header("骰子总数量")]
		[SerializeField]
		private int iDiceAllCount = 6;

		// Token: 0x04009CFD RID: 40189
		[Header("buff道具ID")]
		[SerializeField]
		private int iBuffItemID = 800005000;

		// Token: 0x04009CFE RID: 40190
		private bool bIsStartTurn;
	}
}
