using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012AF RID: 4783
	public class MallDataManager : DataManager<MallDataManager>
	{
		// Token: 0x0600B839 RID: 47161 RVA: 0x002A2715 File Offset: 0x002A0B15
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B83A RID: 47162 RVA: 0x002A2719 File Offset: 0x002A0B19
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
		}

		// Token: 0x0600B83B RID: 47163 RVA: 0x002A2728 File Offset: 0x002A0B28
		public override void Clear()
		{
			this._UnBindNetMsg();
			this.HaveGoodsRecommendReq = false;
			this.OnlineTips = false;
			this.HaveTips = false;
			this.GoodsRecommend.Clear();
			this.SortGoods.Clear();
			this.MainTabIndex = -1;
			this.SubTabIndex = -1;
		}

		// Token: 0x0600B83C RID: 47164 RVA: 0x002A2774 File Offset: 0x002A0B74
		private void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(602804U, new Action<MsgDATA>(this._OnWorldMallQueryItemRet));
				NetProcess.AddMsgHandler(602818U, new Action<MsgDATA>(this._OnWorldMallPersonalTailorStateRet));
				NetProcess.AddMsgHandler(504003U, new Action<MsgDATA>(this.OnSyncPayRes));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600B83D RID: 47165 RVA: 0x002A27D8 File Offset: 0x002A0BD8
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(602804U, new Action<MsgDATA>(this._OnWorldMallQueryItemRet));
			NetProcess.RemoveMsgHandler(602818U, new Action<MsgDATA>(this._OnWorldMallPersonalTailorStateRet));
			NetProcess.RemoveMsgHandler(504003U, new Action<MsgDATA>(this.OnSyncPayRes));
			this.m_bNetBind = false;
		}

		// Token: 0x0600B83E RID: 47166 RVA: 0x002A2830 File Offset: 0x002A0C30
		private void _OnWorldMallQueryItemRet(MsgDATA msg)
		{
			WorldMallQueryItemRet worldMallQueryItemRet = new WorldMallQueryItemRet();
			worldMallQueryItemRet.decode(msg.bytes);
			MallItemInfo[] items = worldMallQueryItemRet.items;
			bool isPersonGoods = this.GetIsPersonGoods(items);
			if (isPersonGoods)
			{
				this.GoodsRecommend.Clear();
				for (int i = 0; i < worldMallQueryItemRet.items.Length; i++)
				{
					this.GoodsRecommend.Add(worldMallQueryItemRet.items[i]);
				}
				this.HaveGoodsRecommendReq = true;
				this.SortGoods.Clear();
				this._sortMallItemListByStartTime();
				if (this.SortGoods != null && this.SortGoods.Count > 0)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GoodsRecommend, 1, this.SortGoods[0].id, this.HaveTips, null);
				}
				if (this.HaveTips)
				{
					this.HaveTips = false;
				}
			}
		}

		// Token: 0x0600B83F RID: 47167 RVA: 0x002A2918 File Offset: 0x002A0D18
		private void _OnWorldMallPersonalTailorStateRet(MsgDATA msg)
		{
			WorldSyncMallPersonalTailorState worldSyncMallPersonalTailorState = new WorldSyncMallPersonalTailorState();
			worldSyncMallPersonalTailorState.decode(msg.bytes);
			if (worldSyncMallPersonalTailorState.state == 1 || worldSyncMallPersonalTailorState.state == 3)
			{
				if (worldSyncMallPersonalTailorState.state == 3)
				{
					this.OnlineTips = true;
				}
				if (worldSyncMallPersonalTailorState.state == 1)
				{
					this.OnlineTips = false;
				}
				this.SendGoodsRecommendReq();
				this.HaveTips = true;
			}
			if (worldSyncMallPersonalTailorState.state == 2)
			{
				this.HaveGoodsRecommendReq = false;
				this.SendGoodsRecommendReq();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GoodsRecommend, 2, null, null, null);
			}
		}

		// Token: 0x0600B840 RID: 47168 RVA: 0x002A29B4 File Offset: 0x002A0DB4
		public void SendGoodsRecommendReq()
		{
			WorldMallQueryItemReq worldMallQueryItemReq = new WorldMallQueryItemReq();
			worldMallQueryItemReq.isPersonalTailor = 1;
			worldMallQueryItemReq.tagType = 0;
			worldMallQueryItemReq.type = 0;
			worldMallQueryItemReq.subType = 0;
			worldMallQueryItemReq.moneyType = 0;
			worldMallQueryItemReq.occu = 0;
			worldMallQueryItemReq.updateTime = 0U;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMallQueryItemReq>(ServerType.GATE_SERVER, worldMallQueryItemReq);
		}

		// Token: 0x0600B841 RID: 47169 RVA: 0x002A2A08 File Offset: 0x002A0E08
		public void SendMallQueryItemReq(int MallTableID, int iMallSubTypeIndex = 0, int JobID = 0, int mainTabIndex = -1, int subTabIndex = -1)
		{
			MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(MallTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("MallData is null in [SendMallQueryItemReq], MallTableID = {0}, iMallSubTypeIndex = {1}", new object[]
				{
					MallTableID,
					iMallSubTypeIndex
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
				if (tableItem.MallSubType.Count > 0 && iMallSubTypeIndex < tableItem.MallSubType.Count && tableItem.MallSubType[iMallSubTypeIndex] != MallTypeTable.eMallSubType.MST_NONE)
				{
					worldMallQueryItemReq.subType = (byte)tableItem.MallSubType[iMallSubTypeIndex];
				}
				else if (tableItem.MallSubType != null && tableItem.MallSubType.Count == 1)
				{
					worldMallQueryItemReq.subType = (byte)tableItem.MallSubType[iMallSubTypeIndex];
				}
				if (tableItem.ClassifyJob == 1 && JobID > 0)
				{
					worldMallQueryItemReq.occu = (byte)JobID;
				}
			}
			this.MainTabIndex = mainTabIndex;
			this.SubTabIndex = subTabIndex;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMallQueryItemReq>(ServerType.GATE_SERVER, worldMallQueryItemReq);
		}

		// Token: 0x0600B842 RID: 47170 RVA: 0x002A2B54 File Offset: 0x002A0F54
		public void setFashionDiscount(WorldMallQueryItemRet res, int jobID)
		{
			List<MallItemInfo> list = new List<MallItemInfo>();
			if (list != null)
			{
				list.Clear();
			}
			for (int i = 0; i < res.items.Length; i++)
			{
				list.Add(res.items[i]);
			}
			if (this.jobFashionDic == null)
			{
				Logger.LogErrorFormat("jobFashionDic is null", new object[0]);
			}
			this.jobFashionDic[jobID] = list;
		}

		// Token: 0x0600B843 RID: 47171 RVA: 0x002A2BC4 File Offset: 0x002A0FC4
		public bool haveFashionDiscount(MallItemInfo mallItemInfo)
		{
			bool result = false;
			if (this.jobFashionDic == null)
			{
				return result;
			}
			if (!this.jobFashionDic.ContainsKey((int)mallItemInfo.jobtype))
			{
				return result;
			}
			List<MallItemInfo> list = this.jobFashionDic[(int)mallItemInfo.jobtype];
			for (int i = 0; i < list.Count; i++)
			{
				if (mallItemInfo.goodsSubType == list[i].goodsSubType && list[i].discountRate > 0U)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600B844 RID: 47172 RVA: 0x002A2C50 File Offset: 0x002A1050
		public bool GetIsPersonGoods(MallItemInfo[] mallinfos)
		{
			if (mallinfos.Length <= 0)
			{
				return false;
			}
			for (int i = 0; i < mallinfos.Length; i++)
			{
				if (mallinfos[i].isPersonalTailor > 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B845 RID: 47173 RVA: 0x002A2C90 File Offset: 0x002A1090
		private void _sortMallItemListByStartTime()
		{
			for (int i = 0; i < this.GoodsRecommend.Count; i++)
			{
				MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)DataManager<MallDataManager>.GetInstance().GoodsRecommend[i].id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					int personalTailID = tableItem.PersonalTailID;
					if (personalTailID != 0)
					{
						PersonalTailorTriggerTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PersonalTailorTriggerTable>(personalTailID, string.Empty, string.Empty);
						if (tableItem2 == null)
						{
							Logger.LogErrorFormat("PersonalTailorTriggerTable is null", new object[0]);
						}
						if (tableItem2.TypeID == 5)
						{
							string[] array = tableItem.giftpackitems.Split(new char[]
							{
								'|'
							});
							for (int j = 0; j < array.Length; j++)
							{
								string[] array2 = array[j].Split(new char[]
								{
									':'
								});
								int id = 0;
								int.TryParse(array2[0], out id);
								ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
								if (tableItem3 == null)
								{
									Logger.LogErrorFormat("itemtabledata is null", new object[0]);
									return;
								}
								if (tableItem3.TimeLeft == 604800)
								{
									break;
								}
								if (tableItem3.TimeLeft == 2592000)
								{
									break;
								}
								if (tableItem3.TimeLeft == 0)
								{
									this.SortGoods.Add(this.GoodsRecommend[i]);
									break;
								}
							}
						}
						else
						{
							this.SortGoods.Add(this.GoodsRecommend[i]);
						}
					}
				}
			}
			this.SortGoods.Sort(delegate(MallItemInfo x, MallItemInfo y)
			{
				int result;
				if (x.starttime.CompareTo(y.starttime) > 0)
				{
					result = -1;
				}
				else
				{
					result = 1;
				}
				return result;
			});
		}

		// Token: 0x0600B846 RID: 47174 RVA: 0x002A2E52 File Offset: 0x002A1252
		private void OnSyncPayRes(MsgDATA data)
		{
			if (SDKInterface.instance.IsPayResultNotify())
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPayResultNotify, "0", null, null, null);
			}
		}

		// Token: 0x040067D2 RID: 26578
		public bool HaveGoodsRecommendReq;

		// Token: 0x040067D3 RID: 26579
		private bool m_bNetBind;

		// Token: 0x040067D4 RID: 26580
		private bool HaveTips;

		// Token: 0x040067D5 RID: 26581
		public bool OnlineTips;

		// Token: 0x040067D6 RID: 26582
		public List<MallItemInfo> GoodsRecommend = new List<MallItemInfo>();

		// Token: 0x040067D7 RID: 26583
		private List<MallItemInfo> SortGoods = new List<MallItemInfo>();

		// Token: 0x040067D8 RID: 26584
		public Dictionary<int, List<MallItemInfo>> jobFashionDic = new Dictionary<int, List<MallItemInfo>>();

		// Token: 0x040067D9 RID: 26585
		public bool isInFashionTab;

		// Token: 0x040067DA RID: 26586
		public int MainTabIndex = -1;

		// Token: 0x040067DB RID: 26587
		public int SubTabIndex = -1;
	}
}
