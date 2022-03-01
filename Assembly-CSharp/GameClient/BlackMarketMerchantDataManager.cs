using System;
using System.Collections.Generic;
using Network;
using Parser;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A36 RID: 6710
	public class BlackMarketMerchantDataManager : DataManager<BlackMarketMerchantDataManager>
	{
		// Token: 0x17001D4B RID: 7499
		// (get) Token: 0x060107B1 RID: 67505 RVA: 0x004A4477 File Offset: 0x004A2877
		// (set) Token: 0x060107B2 RID: 67506 RVA: 0x004A447E File Offset: 0x004A287E
		public static BlackMarketType BlackMarketType
		{
			get
			{
				return BlackMarketMerchantDataManager.blackMarketType;
			}
			set
			{
				BlackMarketMerchantDataManager.blackMarketType = value;
			}
		}

		// Token: 0x17001D4C RID: 7500
		// (get) Token: 0x060107B3 RID: 67507 RVA: 0x004A4486 File Offset: 0x004A2886
		// (set) Token: 0x060107B4 RID: 67508 RVA: 0x004A448D File Offset: 0x004A288D
		public static float BlackMarketMerchantBornPos
		{
			get
			{
				return BlackMarketMerchantDataManager.mBlackMarketMerchantBornPos;
			}
			set
			{
				BlackMarketMerchantDataManager.mBlackMarketMerchantBornPos = value;
			}
		}

		// Token: 0x17001D4D RID: 7501
		// (get) Token: 0x060107B5 RID: 67509 RVA: 0x004A4495 File Offset: 0x004A2895
		// (set) Token: 0x060107B6 RID: 67510 RVA: 0x004A449C File Offset: 0x004A289C
		public static float BlackMarketMerchantEndPos
		{
			get
			{
				return BlackMarketMerchantDataManager.mBlackMarketMerchantEndPos;
			}
			set
			{
				BlackMarketMerchantDataManager.mBlackMarketMerchantEndPos = value;
			}
		}

		// Token: 0x17001D4E RID: 7502
		// (get) Token: 0x060107B7 RID: 67511 RVA: 0x004A44A4 File Offset: 0x004A28A4
		// (set) Token: 0x060107B8 RID: 67512 RVA: 0x004A44AB File Offset: 0x004A28AB
		public static float BlackMarketMerchantRandomPlayerNextAniamtionMinTime
		{
			get
			{
				return BlackMarketMerchantDataManager.mBlackMarketMerchantRandomPlayerNextAnimationMinTime;
			}
			set
			{
				BlackMarketMerchantDataManager.mBlackMarketMerchantRandomPlayerNextAnimationMinTime = value;
			}
		}

		// Token: 0x17001D4F RID: 7503
		// (get) Token: 0x060107B9 RID: 67513 RVA: 0x004A44B3 File Offset: 0x004A28B3
		// (set) Token: 0x060107BA RID: 67514 RVA: 0x004A44BA File Offset: 0x004A28BA
		public static float BlackMarketMerchantRandomPlayerNextAniamtionMaxTime
		{
			get
			{
				return BlackMarketMerchantDataManager.mBlackMarketMerchantRandomPlayerNextAnimationMaxTime;
			}
			set
			{
				BlackMarketMerchantDataManager.mBlackMarketMerchantRandomPlayerNextAnimationMaxTime = value;
			}
		}

		// Token: 0x060107BB RID: 67515 RVA: 0x004A44C2 File Offset: 0x004A28C2
		public sealed override EEnterGameOrder GetOrder()
		{
			return base.GetOrder();
		}

		// Token: 0x060107BC RID: 67516 RVA: 0x004A44CA File Offset: 0x004A28CA
		public BlackMarketMerchantDataModel GetBlackMarketMerchantDataModel()
		{
			return this.mBlackMarketMerchantDataModel;
		}

		// Token: 0x060107BD RID: 67517 RVA: 0x004A44D2 File Offset: 0x004A28D2
		public sealed override void Initialize()
		{
			this.mBlackMarketMerchantDataModel = new BlackMarketMerchantDataModel();
			BlackMarketMerchantDataManager.blackMarketType = BlackMarketType.BmtInvalid;
			int.TryParse(TR.Value("BlackMarketMerchantSceneID"), out this.mSceneID);
			this.InitLocalData();
			this._RegisterNetHandler();
		}

		// Token: 0x060107BE RID: 67518 RVA: 0x004A4507 File Offset: 0x004A2907
		public sealed override void Clear()
		{
			this._UnRegisterNetHandler();
			if (this.mBlackMarketMerchantDataModel != null)
			{
				if (this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList != null)
				{
					this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList.Clear();
				}
				this.mBlackMarketMerchantDataModel = null;
			}
		}

		// Token: 0x060107BF RID: 67519 RVA: 0x004A4544 File Offset: 0x004A2944
		private void InitLocalData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(541, string.Empty, string.Empty);
			if (tableItem != null)
			{
				BlackMarketMerchantDataManager.mBlackMarketMerchantBornPos = (float)tableItem.Value;
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(542, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				BlackMarketMerchantDataManager.mBlackMarketMerchantEndPos = (float)tableItem2.Value / 10000f;
			}
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(543, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				BlackMarketMerchantDataManager.mBlackMarketMerchantRandomPlayerNextAnimationMinTime = (float)tableItem3.Value;
			}
			SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(544, string.Empty, string.Empty);
			if (tableItem4 != null)
			{
				BlackMarketMerchantDataManager.mBlackMarketMerchantRandomPlayerNextAnimationMaxTime = (float)tableItem4.Value;
			}
		}

		// Token: 0x060107C0 RID: 67520 RVA: 0x004A4608 File Offset: 0x004A2A08
		private void _RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(609003U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketAuctionListRes));
			NetProcess.AddMsgHandler(609001U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketSyncType));
			NetProcess.AddMsgHandler(609005U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketAuctionRes));
			NetProcess.AddMsgHandler(609008U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketNotifyRefresh));
			NetProcess.AddMsgHandler(609007U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketAuctionCancelRes));
		}

		// Token: 0x060107C1 RID: 67521 RVA: 0x004A4684 File Offset: 0x004A2A84
		private void _UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(609003U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketAuctionListRes));
			NetProcess.RemoveMsgHandler(609001U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketSyncType));
			NetProcess.RemoveMsgHandler(609005U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketAuctionRes));
			NetProcess.RemoveMsgHandler(609008U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketNotifyRefresh));
			NetProcess.RemoveMsgHandler(609007U, new Action<MsgDATA>(this.OnSyncWorldBlackMarketAuctionCancelRes));
		}

		// Token: 0x060107C2 RID: 67522 RVA: 0x004A4700 File Offset: 0x004A2B00
		private void OnSyncWorldBlackMarketAuctionListRes(MsgDATA msg)
		{
			WorldBlackMarketAuctionListRes worldBlackMarketAuctionListRes = new WorldBlackMarketAuctionListRes();
			worldBlackMarketAuctionListRes.decode(msg.bytes);
			this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList = new List<BlackMarketAuctionInfo>();
			if (worldBlackMarketAuctionListRes.items.Length > 0)
			{
				for (int i = 0; i < worldBlackMarketAuctionListRes.items.Length; i++)
				{
					BlackMarketAuctionInfo item = worldBlackMarketAuctionListRes.items[i];
					this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList.Add(item);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BlackMarketMerchanRetSuccess, null, null, null, null);
		}

		// Token: 0x060107C3 RID: 67523 RVA: 0x004A4784 File Offset: 0x004A2B84
		private void OnSyncWorldBlackMarketSyncType(MsgDATA msg)
		{
			WorldBlackMarketSyncType worldBlackMarketSyncType = new WorldBlackMarketSyncType();
			worldBlackMarketSyncType.decode(msg.bytes);
			this.mBlackMarketMerchantDataModel.mBlackMarketType = (BlackMarketType)worldBlackMarketSyncType.type;
			BlackMarketMerchantDataManager.blackMarketType = (BlackMarketType)worldBlackMarketSyncType.type;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SyncBlackMarketMerchantNPCType, null, null, null, null);
		}

		// Token: 0x060107C4 RID: 67524 RVA: 0x004A47D4 File Offset: 0x004A2BD4
		private void OnSyncWorldBlackMarketAuctionRes(MsgDATA msg)
		{
			WorldBlackMarketAuctionRes worldBlackMarketAuctionRes = new WorldBlackMarketAuctionRes();
			worldBlackMarketAuctionRes.decode(msg.bytes);
			if (worldBlackMarketAuctionRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldBlackMarketAuctionRes.code, string.Empty);
			}
			else
			{
				if (this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList != null)
				{
					int index = 0;
					for (int i = 0; i < this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList.Count; i++)
					{
						BlackMarketAuctionInfo blackMarketAuctionInfo = this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList[i];
						if (blackMarketAuctionInfo.guid == worldBlackMarketAuctionRes.item.guid)
						{
							index = i;
						}
					}
					this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList[index] = worldBlackMarketAuctionRes.item;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BlackMarketMerchantItemUpdate, null, null, null, null);
			}
		}

		// Token: 0x060107C5 RID: 67525 RVA: 0x004A48A0 File Offset: 0x004A2CA0
		private void OnSyncWorldBlackMarketAuctionCancelRes(MsgDATA msg)
		{
			WorldBlackMarketAuctionCancelRes worldBlackMarketAuctionCancelRes = new WorldBlackMarketAuctionCancelRes();
			worldBlackMarketAuctionCancelRes.decode(msg.bytes);
			if (worldBlackMarketAuctionCancelRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldBlackMarketAuctionCancelRes.code, string.Empty);
			}
			else
			{
				if (this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList != null)
				{
					int index = 0;
					for (int i = 0; i < this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList.Count; i++)
					{
						BlackMarketAuctionInfo blackMarketAuctionInfo = this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList[i];
						if (blackMarketAuctionInfo.guid == worldBlackMarketAuctionCancelRes.item.guid)
						{
							index = i;
						}
					}
					this.mBlackMarketMerchantDataModel.mBlackMarketAuctionInfoList[index] = worldBlackMarketAuctionCancelRes.item;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BlackMarketMerchantItemUpdate, null, null, null, null);
			}
		}

		// Token: 0x060107C6 RID: 67526 RVA: 0x004A496C File Offset: 0x004A2D6C
		private void OnSyncWorldBlackMarketNotifyRefresh(MsgDATA msg)
		{
			WorldBlackMarketNotifyRefresh stream = new WorldBlackMarketNotifyRefresh();
			stream.decode(msg.bytes);
			this.OnSendWorldBlackMarketAuctionListReq();
		}

		// Token: 0x060107C7 RID: 67527 RVA: 0x004A4994 File Offset: 0x004A2D94
		public void OnSendWorldBlackMarketAuctionListReq()
		{
			WorldBlackMarketAuctionListReq cmd = new WorldBlackMarketAuctionListReq();
			NetManager.Instance().SendCommand<WorldBlackMarketAuctionListReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x060107C8 RID: 67528 RVA: 0x004A49B4 File Offset: 0x004A2DB4
		public void OnSendWorldBlackMarketAuctionReq(ulong auction_guid, ulong item_guid, uint auction_price)
		{
			WorldBlackMarketAuctionReq worldBlackMarketAuctionReq = new WorldBlackMarketAuctionReq();
			worldBlackMarketAuctionReq.auction_guid = auction_guid;
			worldBlackMarketAuctionReq.item_guid = item_guid;
			worldBlackMarketAuctionReq.auction_price = auction_price;
			NetManager.Instance().SendCommand<WorldBlackMarketAuctionReq>(ServerType.GATE_SERVER, worldBlackMarketAuctionReq);
		}

		// Token: 0x060107C9 RID: 67529 RVA: 0x004A49EC File Offset: 0x004A2DEC
		public void OnSendWorldBlackMarketAuctionCancelReq(ulong auction_guid)
		{
			WorldBlackMarketAuctionCancelReq worldBlackMarketAuctionCancelReq = new WorldBlackMarketAuctionCancelReq();
			worldBlackMarketAuctionCancelReq.auction_guid = auction_guid;
			NetManager.Instance().SendCommand<WorldBlackMarketAuctionCancelReq>(ServerType.GATE_SERVER, worldBlackMarketAuctionCancelReq);
		}

		// Token: 0x060107CA RID: 67530 RVA: 0x004A4A14 File Offset: 0x004A2E14
		public string SwichQuestionMarkCharacter(int count)
		{
			string result = string.Empty;
			switch (count)
			{
			case 1:
				result = "?";
				break;
			case 2:
				result = "??";
				break;
			case 3:
				result = "???";
				break;
			case 4:
				result = "????";
				break;
			case 5:
				result = "?????";
				break;
			case 6:
				result = "??????";
				break;
			case 7:
				result = "???????";
				break;
			case 8:
				result = "????????";
				break;
			case 9:
				result = "?????????";
				break;
			case 10:
				result = "??????????";
				break;
			}
			return result;
		}

		// Token: 0x060107CB RID: 67531 RVA: 0x004A4ACC File Offset: 0x004A2ECC
		public bool FindBackPackBuyBackItem(int tableId)
		{
			bool result = false;
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			if (itemsByPackageType != null)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ulong id = itemsByPackageType[i];
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
					if (item.TableID == tableId)
					{
						result = true;
						break;
					}
				}
			}
			List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Material);
			if (itemsByPackageType2 != null)
			{
				for (int j = 0; j < itemsByPackageType2.Count; j++)
				{
					ulong id2 = itemsByPackageType2[j];
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(id2);
					if (item2.TableID == tableId)
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x060107CC RID: 67532 RVA: 0x004A4B98 File Offset: 0x004A2F98
		public List<ItemData> GetBackPackAllItem(int tableId)
		{
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			if (itemsByPackageType != null)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ulong id = itemsByPackageType[i];
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
					if (item.TableID == tableId)
					{
						list.Add(item);
					}
				}
			}
			List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Material);
			if (itemsByPackageType2 != null)
			{
				for (int j = 0; j < itemsByPackageType2.Count; j++)
				{
					ulong id2 = itemsByPackageType2[j];
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(id2);
					if (item2.TableID == tableId)
					{
						list.Add(item2);
					}
				}
			}
			return list;
		}

		// Token: 0x060107CD RID: 67533 RVA: 0x004A4C68 File Offset: 0x004A3068
		public bool CreatBlackMarketMerchantNPC(int currentSceneID)
		{
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(currentSceneID, string.Empty, string.Empty);
			return tableItem != null && tableItem.ID == this.mSceneID;
		}

		// Token: 0x060107CE RID: 67534 RVA: 0x004A4CA8 File Offset: 0x004A30A8
		public Vector3 GetBlackMarketMerchantPostion(NpcTable npcTable)
		{
			if (npcTable == null)
			{
				return Vector3.zero;
			}
			float num = -30000f;
			Vector3 result;
			result..ctor(BlackMarketMerchantDataManager.BlackMarketMerchantBornPos / 10000f, 0f, num / 10000f);
			return result;
		}

		// Token: 0x060107CF RID: 67535 RVA: 0x004A4CE8 File Offset: 0x004A30E8
		public static void OnClickLinkByNpcId(string param)
		{
			BlackMarketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BlackMarketTable>((int)BlackMarketMerchantDataManager.BlackMarketType, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			NpcParser.OnClickLinkByNpcId(tableItem.NpcID);
		}

		// Token: 0x0400A799 RID: 42905
		private BlackMarketMerchantDataModel mBlackMarketMerchantDataModel = new BlackMarketMerchantDataModel();

		// Token: 0x0400A79A RID: 42906
		private int mSceneID;

		// Token: 0x0400A79B RID: 42907
		private const float NpcPositionCoefficient = 10000f;

		// Token: 0x0400A79C RID: 42908
		private static BlackMarketType blackMarketType;

		// Token: 0x0400A79D RID: 42909
		private static float mBlackMarketMerchantBornPos;

		// Token: 0x0400A79E RID: 42910
		private static float mBlackMarketMerchantEndPos;

		// Token: 0x0400A79F RID: 42911
		private static float mBlackMarketMerchantRandomPlayerNextAnimationMinTime;

		// Token: 0x0400A7A0 RID: 42912
		private static float mBlackMarketMerchantRandomPlayerNextAnimationMaxTime;
	}
}
