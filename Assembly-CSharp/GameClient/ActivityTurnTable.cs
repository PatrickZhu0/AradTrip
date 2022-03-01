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
	// Token: 0x0200186F RID: 6255
	public class ActivityTurnTable : MonoBehaviour
	{
		// Token: 0x0600F50F RID: 62735 RVA: 0x00421A9F File Offset: 0x0041FE9F
		public void Init(int tableID)
		{
			this._bindExUI();
			NetProcess.AddMsgHandler(501007U, new Action<MsgDATA>(this.OnSceneDrawPrizeRes));
			this.mTableID = tableID;
			this.initdata();
		}

		// Token: 0x0600F510 RID: 62736 RVA: 0x00421ACA File Offset: 0x0041FECA
		private void initdata()
		{
			this.rewardPoolTableId.Clear();
			this.InitIcon();
		}

		// Token: 0x0600F511 RID: 62737 RVA: 0x00421AE0 File Offset: 0x0041FEE0
		private void InitIcon()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<RewardPoolTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				RewardPoolTable rewardPoolTable = keyValuePair.Value as RewardPoolTable;
				if (rewardPoolTable.DrawPrizeTableID == this.mTableID)
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
						ComItem comItem = ComItemManager.Create(this.rewardGo[i]);
						int result = tableItem.ItemID;
						comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
						{
							this.OnShowTips(result);
						});
					}
				}
			}
		}

		// Token: 0x0600F512 RID: 62738 RVA: 0x00421C40 File Offset: 0x00420040
		private void OnShowTips(int result)
		{
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600F513 RID: 62739 RVA: 0x00421C67 File Offset: 0x00420067
		private void OnDestroy()
		{
			NetProcess.RemoveMsgHandler(501007U, new Action<MsgDATA>(this.OnSceneDrawPrizeRes));
			this.clearData();
		}

		// Token: 0x0600F514 RID: 62740 RVA: 0x00421C85 File Offset: 0x00420085
		private void clearData()
		{
			this.rewardPoolTableId.Clear();
		}

		// Token: 0x0600F515 RID: 62741 RVA: 0x00421C94 File Offset: 0x00420094
		private void SendSceneDrawPrizeReq()
		{
			this.mStartGray.enabled = true;
			this.mStart.interactable = false;
			SceneDrawPrizeReq sceneDrawPrizeReq = new SceneDrawPrizeReq();
			sceneDrawPrizeReq.id = (uint)this.mTableID;
			NetManager.Instance().SendCommand<SceneDrawPrizeReq>(ServerType.GATE_SERVER, sceneDrawPrizeReq);
		}

		// Token: 0x0600F516 RID: 62742 RVA: 0x00421CD8 File Offset: 0x004200D8
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
				this.mStartGray.enabled = false;
				this.mStart.interactable = true;
			}
		}

		// Token: 0x0600F517 RID: 62743 RVA: 0x00421D88 File Offset: 0x00420188
		private void GetItem()
		{
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

		// Token: 0x0600F518 RID: 62744 RVA: 0x00421E14 File Offset: 0x00420214
		protected void _bindExUI()
		{
			ComCommonBind component = base.GetComponent<ComCommonBind>();
			this.rewardGo[0] = component.GetGameObject("pos0");
			this.rewardGo[1] = component.GetGameObject("pos1");
			this.rewardGo[2] = component.GetGameObject("pos2");
			this.rewardGo[3] = component.GetGameObject("pos3");
			this.rewardGo[4] = component.GetGameObject("pos4");
			this.rewardGo[5] = component.GetGameObject("pos5");
			this.rewardGo[6] = component.GetGameObject("pos6");
			this.rewardGo[7] = component.GetGameObject("pos7");
			this.mStart = component.GetCom<Button>("start");
			this.mStart.onClick.AddListener(new UnityAction(this._onStartButtonClick));
			this.mStartGray = component.GetCom<UIGray>("startGray");
			this.mLuckyRoller = component.GetCom<TheLuckyRoller>("LuckyRoller");
		}

		// Token: 0x0600F519 RID: 62745 RVA: 0x00421F10 File Offset: 0x00420310
		protected void _unbindExUI()
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
		}

		// Token: 0x0600F51A RID: 62746 RVA: 0x00421F96 File Offset: 0x00420396
		private void _onStartButtonClick()
		{
			this.SendSceneDrawPrizeReq();
		}

		// Token: 0x04009648 RID: 38472
		private int mTableID = -1;

		// Token: 0x04009649 RID: 38473
		private int tempRewardIndex = -1;

		// Token: 0x0400964A RID: 38474
		private List<int> rewardPoolTableId = new List<int>();

		// Token: 0x0400964B RID: 38475
		private GameObject[] rewardGo = new GameObject[8];

		// Token: 0x0400964C RID: 38476
		private Button mStart;

		// Token: 0x0400964D RID: 38477
		private TheLuckyRoller mLuckyRoller;

		// Token: 0x0400964E RID: 38478
		private UIGray mStartGray;
	}
}
