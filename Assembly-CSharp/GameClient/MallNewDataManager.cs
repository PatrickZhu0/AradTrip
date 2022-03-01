using System;
using System.Collections.Generic;
using ActivityLimitTime;
using FashionLimitTimeBuy;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012AD RID: 4781
	public class MallNewDataManager : DataManager<MallNewDataManager>
	{
		// Token: 0x17001B0D RID: 6925
		// (get) Token: 0x0600B817 RID: 47127 RVA: 0x002A1B30 File Offset: 0x0029FF30
		// (set) Token: 0x0600B818 RID: 47128 RVA: 0x002A1B38 File Offset: 0x0029FF38
		public MallItemInfo QueryMallItemInfo
		{
			get
			{
				return this.queryMallItemInfo;
			}
			set
			{
				this.queryMallItemInfo = value;
			}
		}

		// Token: 0x0600B819 RID: 47129 RVA: 0x002A1B41 File Offset: 0x0029FF41
		public override void Initialize()
		{
			this.InitData();
			this.BindNetEvents();
		}

		// Token: 0x0600B81A RID: 47130 RVA: 0x002A1B4F File Offset: 0x0029FF4F
		private void InitData()
		{
			this.InitMallShopMultilTable();
		}

		// Token: 0x0600B81B RID: 47131 RVA: 0x002A1B58 File Offset: 0x0029FF58
		public MallItemMultipleIntegralData CheckMallItemMultipleIntegral(int itemId)
		{
			MallItemMultipleIntegralData result = null;
			if (this.mallItemMultipleIntergralDict.TryGetValue(itemId, out result))
			{
			}
			return result;
		}

		// Token: 0x0600B81C RID: 47132 RVA: 0x002A1B7C File Offset: 0x0029FF7C
		private void InitMallShopMultilTable()
		{
			if (this.mallItemMultipleIntergralDict == null)
			{
				this.mallItemMultipleIntergralDict = new Dictionary<int, MallItemMultipleIntegralData>();
			}
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<MallShopMultiITable>())
			{
				MallShopMultiITable mallShopMultiITable = keyValuePair.Value as MallShopMultiITable;
				if (mallShopMultiITable != null)
				{
					string[] array = mallShopMultiITable.Malls.Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						int key = int.Parse(array[i]);
						DateTime time = DateTime.Parse(mallShopMultiITable.EndTime);
						int endTime = (int)Function.ConvertDateTimeInt(time);
						MallItemMultipleIntegralData value = new MallItemMultipleIntegralData
						{
							multiple = mallShopMultiITable.Multiple,
							endTime = endTime
						};
						this.mallItemMultipleIntergralDict.Add(key, value);
					}
				}
			}
		}

		// Token: 0x0600B81D RID: 47133 RVA: 0x002A1C64 File Offset: 0x002A0064
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(602804U, new Action<MsgDATA>(this.OnSyncWorldMallQueryItemRet));
			NetProcess.AddMsgHandler(602813U, new Action<MsgDATA>(this.OnSyncMallBatchBuyRes));
			NetProcess.AddMsgHandler(602802U, new Action<MsgDATA>(this.OnSyncWorldMallBuyRet));
		}

		// Token: 0x0600B81E RID: 47134 RVA: 0x002A1CB3 File Offset: 0x002A00B3
		public override void Clear()
		{
			this.ClearData();
			this.UnBindNetEvents();
			this.bItemMallIntergralMallScoreIsExceed = false;
			this.bItemMallIntergralMallScoreIsEqual = false;
			if (this.mallItemMultipleIntergralDict != null)
			{
				this.mallItemMultipleIntergralDict.Clear();
			}
		}

		// Token: 0x0600B81F RID: 47135 RVA: 0x002A1CE8 File Offset: 0x002A00E8
		public void ClearData()
		{
			for (int i = 0; i < this._mallNewQueryItemList.Count; i++)
			{
				if (this._mallNewQueryItemList[i].Items != null)
				{
					this._mallNewQueryItemList[i].Items.Clear();
				}
			}
			this._mallNewQueryItemList.Clear();
		}

		// Token: 0x0600B820 RID: 47136 RVA: 0x002A1D48 File Offset: 0x002A0148
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(602804U, new Action<MsgDATA>(this.OnSyncWorldMallQueryItemRet));
			NetProcess.RemoveMsgHandler(602813U, new Action<MsgDATA>(this.OnSyncMallBatchBuyRes));
			NetProcess.RemoveMsgHandler(602802U, new Action<MsgDATA>(this.OnSyncWorldMallBuyRet));
		}

		// Token: 0x0600B821 RID: 47137 RVA: 0x002A1D98 File Offset: 0x002A0198
		private void OnSyncWorldMallBuyRet(MsgDATA msg)
		{
			if (msg == null)
			{
				return;
			}
			WorldMallBuyRet worldMallBuyRet = new WorldMallBuyRet();
			worldMallBuyRet.decode(msg.bytes);
			if (worldMallBuyRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMallBuyRet.code, string.Empty);
				return;
			}
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager != null)
			{
				List<MallItemInfo> petPushItemInfo = DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.GetPetPushItemInfo();
				if (petPushItemInfo != null)
				{
					for (int i = 0; i < petPushItemInfo.Count; i++)
					{
						MallItemInfo mallItemInfo = petPushItemInfo[i];
						if (mallItemInfo.id == worldMallBuyRet.mallitemid)
						{
							mallItemInfo.limittotalnum = (ushort)worldMallBuyRet.restLimitNum;
						}
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSyncWorldBuyPetSucceed, petPushItemInfo, null, null, null);
				}
			}
			this.UpdateMallItemInfoAccountLeftNumber(worldMallBuyRet.mallitemid, worldMallBuyRet.accountRestBuyNum);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSyncWorldMallBuySucceed, worldMallBuyRet.mallitemid, worldMallBuyRet.restLimitNum, (int)worldMallBuyRet.accountRestBuyNum, null);
		}

		// Token: 0x0600B822 RID: 47138 RVA: 0x002A1E98 File Offset: 0x002A0298
		private void OnSyncMallBatchBuyRes(MsgDATA msg)
		{
			if (msg == null)
			{
				return;
			}
			SCMallBatchBuyRes scmallBatchBuyRes = new SCMallBatchBuyRes();
			scmallBatchBuyRes.decode(msg.bytes);
			if (scmallBatchBuyRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)scmallBatchBuyRes.code, string.Empty);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSyncMallBatchBuySucceed, scmallBatchBuyRes, null, null, null);
		}

		// Token: 0x0600B823 RID: 47139 RVA: 0x002A1EF0 File Offset: 0x002A02F0
		private void AdjustMallItems(List<MallItemInfo> mallItems)
		{
			if (mallItems == null || mallItems.Count <= 0)
			{
				return;
			}
			int type = (int)mallItems[0].type;
			int subtype = (int)mallItems[0].subtype;
			if (type != 4 || subtype != 6)
			{
				return;
			}
			byte isRecommend = mallItems[0].isRecommend;
			int num = 0;
			for (int i = 0; i < mallItems.Count; i++)
			{
				if (mallItems[i].isRecommend > isRecommend)
				{
					isRecommend = mallItems[i].isRecommend;
					num = i;
				}
			}
			if (num != 0)
			{
				MallItemInfo item = mallItems[num];
				mallItems.RemoveAt(num);
				mallItems.Insert(0, item);
			}
		}

		// Token: 0x0600B824 RID: 47140 RVA: 0x002A1FA8 File Offset: 0x002A03A8
		private void OnSyncWorldMallQueryItemRet(MsgDATA msg)
		{
			WorldMallQueryItemRet worldMallQueryItemRet = new WorldMallQueryItemRet();
			worldMallQueryItemRet.decode(msg.bytes);
			worldMallQueryItemRet.items = DataManager<FashionLimitTimeBuyManager>.GetInstance().FashionLimitTimeFilter(worldMallQueryItemRet.items);
			if (worldMallQueryItemRet.items == null)
			{
				return;
			}
			List<MallItemInfo> list = new List<MallItemInfo>();
			for (int i = 0; i < worldMallQueryItemRet.items.Length; i++)
			{
				list.Add(worldMallQueryItemRet.items[i]);
			}
			if (list.Count > 0)
			{
				MallTypeTable.eMallType type = (MallTypeTable.eMallType)worldMallQueryItemRet.type;
				if (type == MallTypeTable.eMallType.SN_GIFT)
				{
					list.Sort((MallItemInfo x, MallItemInfo y) => x.endtime.CompareTo(y.endtime));
				}
				else if (type == MallTypeTable.eMallType.SN_RECOMMEND || type == MallTypeTable.eMallType.SN_MATERIAL || type == MallTypeTable.eMallType.SN_COST || type == MallTypeTable.eMallType.SN_GOLD)
				{
					list.Sort((MallItemInfo x, MallItemInfo y) => x.sortIdx.CompareTo(y.sortIdx));
				}
				else
				{
					list.Sort((MallItemInfo x, MallItemInfo y) => x.sortIdx.CompareTo(y.sortIdx));
				}
			}
			this.AdjustMallItems(list);
			int type2 = (int)worldMallQueryItemRet.type;
			int num = 0;
			int num2 = 0;
			if (worldMallQueryItemRet.type == 4 && list.Count > 0)
			{
				num = (int)list[0].subtype;
				num2 = (int)list[0].jobtype;
			}
			bool flag = false;
			for (int j = 0; j < this._mallNewQueryItemList.Count; j++)
			{
				MallNewQueryItem mallNewQueryItem = this._mallNewQueryItemList[j];
				if (mallNewQueryItem.MallType == type2 && mallNewQueryItem.SubType == num && mallNewQueryItem.JobId == num2)
				{
					flag = true;
					mallNewQueryItem.Items = list;
					break;
				}
			}
			if (!flag)
			{
				MallNewQueryItem item = new MallNewQueryItem
				{
					MallType = type2,
					SubType = num,
					JobId = num2,
					Items = list
				};
				this._mallNewQueryItemList.Add(item);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSyncWorldMallQueryItems, type2, num, num2, null);
		}

		// Token: 0x0600B825 RID: 47141 RVA: 0x002A21E0 File Offset: 0x002A05E0
		public void SendWorldMallQueryItemReq(int mallTableId, int mallSubTypeIndex = 0, int jobId = 0)
		{
			MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(mallTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("The mallData is null and mallTableId is {0}", new object[]
				{
					mallTableId
				});
				return;
			}
			WorldMallQueryItemReq worldMallQueryItemReq = new WorldMallQueryItemReq();
			if (tableItem.MoneyID != 0)
			{
				worldMallQueryItemReq.moneyType = (byte)tableItem.MoneyID;
			}
			if (tableItem.MallType == MallTypeTable.eMallType.SN_HOT)
			{
				worldMallQueryItemReq.tagType = 1;
			}
			else
			{
				worldMallQueryItemReq.tagType = 0;
				worldMallQueryItemReq.type = (byte)tableItem.MallType;
				if (tableItem.MallSubType != null)
				{
					if (tableItem.MallSubType.Count == 1)
					{
						worldMallQueryItemReq.subType = (byte)tableItem.MallSubType[0];
					}
					else if (tableItem.MallSubType.Count > 0 && mallSubTypeIndex >= 1 && mallSubTypeIndex <= tableItem.MallSubType.Count && tableItem.MallSubType[mallSubTypeIndex - 1] != MallTypeTable.eMallSubType.MST_NONE)
					{
						worldMallQueryItemReq.subType = (byte)tableItem.MallSubType[mallSubTypeIndex - 1];
					}
				}
				if (tableItem.ClassifyJob == 1 && jobId > 0)
				{
					worldMallQueryItemReq.occu = (byte)jobId;
				}
			}
			NetManager.Instance().SendCommand<WorldMallQueryItemReq>(ServerType.GATE_SERVER, worldMallQueryItemReq);
		}

		// Token: 0x0600B826 RID: 47142 RVA: 0x002A231C File Offset: 0x002A071C
		public List<MallItemInfo> GetMallItemInfoList(int mallType, int subType = 0, int jobId = 0)
		{
			if (this._mallNewQueryItemList == null || this._mallNewQueryItemList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < this._mallNewQueryItemList.Count; i++)
			{
				MallNewQueryItem mallNewQueryItem = this._mallNewQueryItemList[i];
				if (mallNewQueryItem.MallType == mallType && mallNewQueryItem.SubType == subType && mallNewQueryItem.JobId == jobId)
				{
					return mallNewQueryItem.Items;
				}
			}
			return null;
		}

		// Token: 0x0600B827 RID: 47143 RVA: 0x002A239C File Offset: 0x002A079C
		private void UpdateMallItemInfoAccountLeftNumber(uint mallItemInfoId, uint accountLeftNumber)
		{
			if (this._mallNewQueryItemList == null || this._mallNewQueryItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._mallNewQueryItemList.Count; i++)
			{
				MallNewQueryItem mallNewQueryItem = this._mallNewQueryItemList[i];
				if (mallNewQueryItem != null && mallNewQueryItem.Items != null && mallNewQueryItem.Items.Count > 0)
				{
					for (int j = 0; j < mallNewQueryItem.Items.Count; j++)
					{
						MallItemInfo mallItemInfo = mallNewQueryItem.Items[j];
						if (mallItemInfo != null && mallItemInfo.id == mallItemInfoId)
						{
							mallItemInfo.accountRestBuyNum = accountLeftNumber;
						}
					}
				}
			}
		}

		// Token: 0x0600B828 RID: 47144 RVA: 0x002A2454 File Offset: 0x002A0854
		public int GetFashionItemId(MallItemInfo itemInfo, FashionMallClothTabType clothTabType)
		{
			if (itemInfo == null)
			{
				return 0;
			}
			if (clothTabType == FashionMallClothTabType.Suit && itemInfo.giftItems != null && itemInfo.giftItems.Length == 5)
			{
				int num = 1;
				return (int)itemInfo.giftItems[num].id;
			}
			return (int)itemInfo.itemid;
		}

		// Token: 0x0600B829 RID: 47145 RVA: 0x002A24A0 File Offset: 0x002A08A0
		public ItemTable GetCostItemTableByCostType(byte costType)
		{
			int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType((ItemTable.eSubType)costType);
			return Singleton<TableManager>.instance.GetTableItem<ItemTable>(moneyIDByType, string.Empty, string.Empty);
		}

		// Token: 0x0600B82A RID: 47146 RVA: 0x002A24D0 File Offset: 0x002A08D0
		public void ReqQueryMallItemInfo(int itemId)
		{
			WorldGetMallItemByItemIdReq worldGetMallItemByItemIdReq = new WorldGetMallItemByItemIdReq();
			worldGetMallItemByItemIdReq.itemId = (uint)itemId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGetMallItemByItemIdReq>(ServerType.GATE_SERVER, worldGetMallItemByItemIdReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGetMallItemByItemIdRes>(delegate(WorldGetMallItemByItemIdRes msgRet)
			{
				if (msgRet.retCode != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.retCode, string.Empty);
					return;
				}
				this.queryMallItemInfo = msgRet.mallItem;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnQueryMallItenInfoSuccess, null, null, null, null);
			}, false, 15f, null);
		}

		// Token: 0x040067C8 RID: 26568
		private Dictionary<int, MallItemMultipleIntegralData> mallItemMultipleIntergralDict = new Dictionary<int, MallItemMultipleIntegralData>();

		// Token: 0x040067C9 RID: 26569
		public const int FashionMallType = 4;

		// Token: 0x040067CA RID: 26570
		public const int FashionSuitType = 6;

		// Token: 0x040067CB RID: 26571
		private List<MallNewQueryItem> _mallNewQueryItemList = new List<MallNewQueryItem>();

		// Token: 0x040067CC RID: 26572
		public bool bItemMallIntergralMallScoreIsExceed;

		// Token: 0x040067CD RID: 26573
		public bool bItemMallIntergralMallScoreIsEqual;

		// Token: 0x040067CE RID: 26574
		private MallItemInfo queryMallItemInfo;
	}
}
