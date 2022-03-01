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
	// Token: 0x0200191B RID: 6427
	internal class TurnTable : ClientFrame
	{
		// Token: 0x0600FA26 RID: 64038 RVA: 0x004478D6 File Offset: 0x00445CD6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Turntable";
		}

		// Token: 0x0600FA27 RID: 64039 RVA: 0x004478E0 File Offset: 0x00445CE0
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				Logger.LogErrorFormat("需要传入抽奖表id", new object[0]);
				return;
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			this.tableID = (int)this.userData;
			this.initdata();
		}

		// Token: 0x0600FA28 RID: 64040 RVA: 0x0044793B File Offset: 0x00445D3B
		private void initdata()
		{
			this.rewardPoolTableId.Clear();
			this.InitIcon();
			this.UpdateTime();
		}

		// Token: 0x0600FA29 RID: 64041 RVA: 0x00447954 File Offset: 0x00445D54
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

		// Token: 0x0600FA2A RID: 64042 RVA: 0x00447AB4 File Offset: 0x00445EB4
		private void UpdateTime()
		{
			DrawPrizeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DrawPrizeTable>(this.tableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.mLotteryNum.text = DataManager<CountDataManager>.GetInstance().GetCount(tableItem.GetCountKey).ToString();
		}

		// Token: 0x0600FA2B RID: 64043 RVA: 0x00447B0C File Offset: 0x00445F0C
		private void OnShowTips(int result)
		{
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600FA2C RID: 64044 RVA: 0x00447B33 File Offset: 0x00445F33
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			this.clearData();
		}

		// Token: 0x0600FA2D RID: 64045 RVA: 0x00447B56 File Offset: 0x00445F56
		private void OnCountValueChanged(UIEvent uiEvent)
		{
			this.UpdateTime();
		}

		// Token: 0x0600FA2E RID: 64046 RVA: 0x00447B5E File Offset: 0x00445F5E
		private void clearData()
		{
			this.rewardPoolTableId.Clear();
		}

		// Token: 0x0600FA2F RID: 64047 RVA: 0x00447B6C File Offset: 0x00445F6C
		private void SendSceneDrawPrizeReq()
		{
			if (this.mStartGray != null)
			{
				this.mStartGray.enabled = true;
			}
			if (this.mStart != null)
			{
				this.mStart.interactable = false;
			}
			SceneDrawPrizeReq sceneDrawPrizeReq = new SceneDrawPrizeReq();
			sceneDrawPrizeReq.id = (uint)this.tableID;
			NetManager.Instance().SendCommand<SceneDrawPrizeReq>(ServerType.GATE_SERVER, sceneDrawPrizeReq);
		}

		// Token: 0x0600FA30 RID: 64048 RVA: 0x00447BD4 File Offset: 0x00445FD4
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
					this.mLuckyRoller.RotateUp(8, num, true, new Action(this.GetItem));
				}
			}
			else
			{
				if (this.mStartGray != null)
				{
					this.mStartGray.enabled = false;
				}
				if (this.mStart != null)
				{
					this.mStart.interactable = true;
				}
			}
		}

		// Token: 0x0600FA31 RID: 64049 RVA: 0x00447CA8 File Offset: 0x004460A8
		private void GetItem()
		{
			if (this.mStartGray != null)
			{
				this.mStartGray.enabled = false;
			}
			if (this.mStart != null)
			{
				this.mStart.interactable = true;
			}
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

		// Token: 0x0600FA32 RID: 64050 RVA: 0x00447D58 File Offset: 0x00446158
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
		}

		// Token: 0x0600FA33 RID: 64051 RVA: 0x00447E9C File Offset: 0x0044629C
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
		}

		// Token: 0x0600FA34 RID: 64052 RVA: 0x00447F29 File Offset: 0x00446329
		private void _onStartButtonClick()
		{
			this.SendSceneDrawPrizeReq();
		}

		// Token: 0x04009C33 RID: 39987
		private int tableID = -1;

		// Token: 0x04009C34 RID: 39988
		private int tempRewardIndex = -1;

		// Token: 0x04009C35 RID: 39989
		private List<int> rewardPoolTableId = new List<int>();

		// Token: 0x04009C36 RID: 39990
		private GameObject[] rewardGo = new GameObject[8];

		// Token: 0x04009C37 RID: 39991
		private Button mStart;

		// Token: 0x04009C38 RID: 39992
		private TheLuckyRoller mLuckyRoller;

		// Token: 0x04009C39 RID: 39993
		private UIGray mStartGray;

		// Token: 0x04009C3A RID: 39994
		private Text mLotteryNum;
	}
}
