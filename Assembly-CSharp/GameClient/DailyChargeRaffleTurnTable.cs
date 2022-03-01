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
	// Token: 0x0200137C RID: 4988
	internal class DailyChargeRaffleTurnTable : ClientFrame
	{
		// Token: 0x0600C178 RID: 49528 RVA: 0x002E1874 File Offset: 0x002DFC74
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/DailyChargeTurnTable";
		}

		// Token: 0x0600C179 RID: 49529 RVA: 0x002E187C File Offset: 0x002DFC7C
		public static void OpenLinkFrame(string strParam)
		{
			int num = -1;
			int.TryParse(strParam, out num);
			if (num != -1)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<DailyChargeRaffleTurnTable>(FrameLayer.Middle, num, string.Empty);
			}
		}

		// Token: 0x0600C17A RID: 49530 RVA: 0x002E18B4 File Offset: 0x002DFCB4
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				Logger.LogErrorFormat("需要传入抽奖表id", new object[0]);
				return;
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this.OnUpdateItemList));
			this.tableID = (int)this.userData;
			this.initdata();
		}

		// Token: 0x0600C17B RID: 49531 RVA: 0x002E192A File Offset: 0x002DFD2A
		private void initdata()
		{
			this.rewardPoolTableId.Clear();
			this.InitIcon();
			this.UpdateTime();
		}

		// Token: 0x0600C17C RID: 49532 RVA: 0x002E1944 File Offset: 0x002DFD44
		private void InitIcon()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<RewardPoolTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				RewardPoolTable rewardPoolTable = keyValuePair.Value as RewardPoolTable;
				if (rewardPoolTable.DrawPrizeTableID == this.tableID)
				{
					this.rewardPoolTableId.Add(rewardPoolTable.ID);
				}
			}
			if (this.rewardPoolTableId.Count == 0)
			{
				Logger.LogErrorFormat("奖池表格数据出错", new object[0]);
			}
			else
			{
				for (int i = 0; i < this.rewardPoolTableId.Count; i++)
				{
					if (i < this.rewardGo.Length)
					{
						RewardPoolTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<RewardPoolTable>(this.rewardPoolTableId[i], string.Empty, string.Empty);
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableItem.ItemID, 100, 0);
						if (itemData == null)
						{
							Logger.LogErrorFormat("ItemData is null", new object[0]);
							return;
						}
						itemData.Count = tableItem.ItemNum;
						ComItem comItem = base.CreateComItem(this.rewardGo[i]);
						int result = tableItem.ItemID;
						comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
						{
							this.OnShowTips(result);
						});
					}
				}
			}
		}

		// Token: 0x0600C17D RID: 49533 RVA: 0x002E1AA4 File Offset: 0x002DFEA4
		private void UpdateTime()
		{
			DrawPrizeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DrawPrizeTable>(this.tableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.mLotteryNum)
			{
				int num = -1;
				int.TryParse(tableItem.Prams, out num);
				if (num != -1)
				{
					this.mLotteryNum.text = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num, true).ToString();
				}
			}
			if (this.mTicketsIcon)
			{
				ETCImageLoader.LoadSprite(ref this.mTicketsIcon, tableItem.RaffleTicketIconPath, true);
			}
			if (this.mTicketsNickName)
			{
				this.mTicketsNickName.text = tableItem.RaffleTicketNickName;
			}
		}

		// Token: 0x0600C17E RID: 49534 RVA: 0x002E1B64 File Offset: 0x002DFF64
		private void OnShowTips(int result)
		{
			Utility.DoStartFrameOperation("DailyChargeTurnTable", string.Format("ItemID/{0}", result));
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600C17F RID: 49535 RVA: 0x002E1BA5 File Offset: 0x002DFFA5
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this.OnUpdateItemList));
			this.clearData();
		}

		// Token: 0x0600C180 RID: 49536 RVA: 0x002E1BE3 File Offset: 0x002DFFE3
		private void OnCountValueChanged(UIEvent uiEvent)
		{
			this.UpdateTime();
		}

		// Token: 0x0600C181 RID: 49537 RVA: 0x002E1BEB File Offset: 0x002DFFEB
		private void OnUpdateItemList(UIEvent uiEvent)
		{
			this.UpdateTime();
		}

		// Token: 0x0600C182 RID: 49538 RVA: 0x002E1BF3 File Offset: 0x002DFFF3
		private void clearData()
		{
			this.rewardPoolTableId.Clear();
		}

		// Token: 0x0600C183 RID: 49539 RVA: 0x002E1C00 File Offset: 0x002E0000
		private void SendSceneDrawPrizeReq()
		{
			this.mStartGray.enabled = true;
			this.mStart.interactable = false;
			SceneDrawPrizeReq sceneDrawPrizeReq = new SceneDrawPrizeReq();
			sceneDrawPrizeReq.id = (uint)this.tableID;
			NetManager.Instance().SendCommand<SceneDrawPrizeReq>(ServerType.GATE_SERVER, sceneDrawPrizeReq);
		}

		// Token: 0x0600C184 RID: 49540 RVA: 0x002E1C44 File Offset: 0x002E0044
		[MessageHandle(501007U, false, 0)]
		private void OnSceneDrawPrizeRes(MsgDATA data)
		{
			SceneDrawPrizeRes sceneDrawPrizeRes = new SceneDrawPrizeRes();
			sceneDrawPrizeRes.decode(data.bytes);
			if (sceneDrawPrizeRes.retCode == 0U)
			{
				this.tempRewardIndex = (int)sceneDrawPrizeRes.rewardId;
				int num = -1;
				for (int i = 0; i < this.rewardPoolTableId.Count; i++)
				{
					if (this.rewardPoolTableId[i] == this.tempRewardIndex)
					{
						num = i;
					}
				}
				if (num != -1)
				{
					this.mBgBtn.interactable = false;
					this.mLuckyRoller.RotateUp(8, num, true, new Action(this.GetItem));
				}
			}
			else
			{
				this.mStartGray.enabled = false;
				this.mStart.interactable = true;
			}
		}

		// Token: 0x0600C185 RID: 49541 RVA: 0x002E1D00 File Offset: 0x002E0100
		private void GetItem()
		{
			this.mBgBtn.interactable = true;
			this.mStartGray.enabled = false;
			this.mStart.interactable = true;
			RewardPoolTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<RewardPoolTable>(this.tempRewardIndex, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem.ItemID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect(tableItem2.Name + "*" + tableItem.ItemNum, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600C186 RID: 49542 RVA: 0x002E1D98 File Offset: 0x002E0198
		protected override void _bindExUI()
		{
			this.rewardGo[0] = this.mBind.GetGameObject("pos0");
			this.rewardGo[1] = this.mBind.GetGameObject("pos1");
			this.rewardGo[2] = this.mBind.GetGameObject("pos2");
			this.rewardGo[3] = this.mBind.GetGameObject("pos3");
			this.rewardGo[4] = this.mBind.GetGameObject("pos4");
			this.rewardGo[5] = this.mBind.GetGameObject("pos5");
			this.rewardGo[6] = this.mBind.GetGameObject("pos6");
			this.rewardGo[7] = this.mBind.GetGameObject("pos7");
			this.mStart = this.mBind.GetCom<Button>("start");
			this.mStart.onClick.AddListener(new UnityAction(this._onStartButtonClick));
			this.mStartGray = this.mBind.GetCom<UIGray>("startGray");
			this.mLuckyRoller = this.mBind.GetCom<TheLuckyRoller>("LuckyRoller");
			this.mLotteryNum = this.mBind.GetCom<Text>("LotteryNum");
			this.mTicketsIcon = this.mBind.GetCom<Image>("TicketsIcon");
			this.mTicketsNickName = this.mBind.GetCom<Text>("TicketsNickName");
			this.mBgBtn = this.mBind.GetCom<Button>("bgBtn");
			if (null != this.mBgBtn)
			{
				this.mBgBtn.onClick.AddListener(new UnityAction(this._onBgBtnButtonClick));
			}
		}

		// Token: 0x0600C187 RID: 49543 RVA: 0x002E1F48 File Offset: 0x002E0348
		protected override void _unbindExUI()
		{
			this.rewardGo[0] = null;
			this.rewardGo[1] = null;
			this.rewardGo[2] = null;
			this.rewardGo[3] = null;
			this.rewardGo[4] = null;
			this.rewardGo[5] = null;
			this.rewardGo[6] = null;
			this.rewardGo[7] = null;
			this.mStart.onClick.RemoveListener(new UnityAction(this._onStartButtonClick));
			this.mStart = null;
			this.mLuckyRoller = null;
			this.mStartGray = null;
			this.mLotteryNum = null;
			this.mTicketsIcon = null;
			this.mTicketsNickName = null;
			if (null != this.mBgBtn)
			{
				this.mBgBtn.onClick.RemoveListener(new UnityAction(this._onBgBtnButtonClick));
			}
			this.mBgBtn = null;
		}

		// Token: 0x0600C188 RID: 49544 RVA: 0x002E2017 File Offset: 0x002E0417
		private void _onStartButtonClick()
		{
			this.SendSceneDrawPrizeReq();
		}

		// Token: 0x0600C189 RID: 49545 RVA: 0x002E201F File Offset: 0x002E041F
		private void _onBgBtnButtonClick()
		{
			this.frameMgr.CloseFrame<DailyChargeRaffleTurnTable>(this, false);
		}

		// Token: 0x04006D83 RID: 28035
		private int tableID = -1;

		// Token: 0x04006D84 RID: 28036
		private int tempRewardIndex = -1;

		// Token: 0x04006D85 RID: 28037
		private List<int> rewardPoolTableId = new List<int>();

		// Token: 0x04006D86 RID: 28038
		private GameObject[] rewardGo = new GameObject[8];

		// Token: 0x04006D87 RID: 28039
		private Button mStart;

		// Token: 0x04006D88 RID: 28040
		private TheLuckyRoller mLuckyRoller;

		// Token: 0x04006D89 RID: 28041
		private UIGray mStartGray;

		// Token: 0x04006D8A RID: 28042
		private Text mLotteryNum;

		// Token: 0x04006D8B RID: 28043
		private Image mTicketsIcon;

		// Token: 0x04006D8C RID: 28044
		private Text mTicketsNickName;

		// Token: 0x04006D8D RID: 28045
		private Button mBgBtn;
	}
}
