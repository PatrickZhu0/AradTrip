using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200457D RID: 17789
	internal class FashionMergeManager : DataManager<FashionMergeManager>
	{
		// Token: 0x06018D06 RID: 101638 RVA: 0x007C1A90 File Offset: 0x007BFE90
		private int _getFashionKey(FashionType type, int Occu, int SuitId, ItemTable.eSubType subType)
		{
			int num = 0;
			num |= (int)((int)(type & (FashionType)255) << 24);
			num |= (Occu & 255) << 16;
			num |= (SuitId & 255) << 8;
			return num | (int)((int)(subType & (ItemTable.eSubType)255) << 0);
		}

		// Token: 0x06018D07 RID: 101639 RVA: 0x007C1AD3 File Offset: 0x007BFED3
		public FashionType generateEnumValue(int iType)
		{
			switch (iType)
			{
			case 0:
				return FashionType.FT_NORMAL;
			case 1:
				return FashionType.FT_SKY;
			case 2:
				return FashionType.FT_GOLD_SKY;
			case 3:
				return FashionType.FT_LUCENCY_SKY;
			default:
				if (iType != 10000)
				{
					return FashionType.FT_NORMAL;
				}
				return FashionType.FT_NATIONALDAY;
			}
		}

		// Token: 0x1700206E RID: 8302
		// (get) Token: 0x06018D08 RID: 101640 RVA: 0x007C1B0A File Offset: 0x007BFF0A
		// (set) Token: 0x06018D09 RID: 101641 RVA: 0x007C1B12 File Offset: 0x007BFF12
		public bool ChangeFashionIsAllMerged
		{
			get
			{
				return this.m_bChangeFashionIsAllMerged;
			}
			set
			{
				this.m_bChangeFashionIsAllMerged = value;
			}
		}

		// Token: 0x06018D0A RID: 101642 RVA: 0x007C1B1C File Offset: 0x007BFF1C
		protected void _LoadType2OccuToFashions()
		{
			if (!this.m_bLoadType2OccuToFashions)
			{
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<FashionComposeSkyTable>();
				Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TableManager instance = Singleton<TableManager>.GetInstance();
					KeyValuePair<int, object> keyValuePair = enumerator.Current;
					ItemTable tableItem = instance.GetTableItem<ItemTable>(keyValuePair.Key, string.Empty, string.Empty);
					KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
					FashionComposeSkyTable fashionComposeSkyTable = keyValuePair2.Value as FashionComposeSkyTable;
					if (tableItem != null && fashionComposeSkyTable != null)
					{
						FashionType type = this.generateEnumValue(fashionComposeSkyTable.Type);
						int key = this._getFashionKey(type, fashionComposeSkyTable.Occu, fashionComposeSkyTable.SuitID, tableItem.SubType);
						if (this.m_key2Fashions.ContainsKey(key))
						{
							Logger.LogErrorFormat("error key repeated !!! for ProtoTable.FashionComposeSkyTable !!! id = {0} <color=#ffff00>name = {1}</color>", new object[]
							{
								tableItem.ID,
								tableItem.Name
							});
						}
						else
						{
							this.m_key2Fashions[key] = tableItem.ID;
						}
					}
				}
				Dictionary<int, object> table2 = Singleton<TableManager>.GetInstance().GetTable<FashionComposeTable>();
				Dictionary<int, object>.Enumerator enumerator2 = table2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					TableManager instance2 = Singleton<TableManager>.GetInstance();
					KeyValuePair<int, object> keyValuePair3 = enumerator2.Current;
					ItemTable tableItem2 = instance2.GetTableItem<ItemTable>(keyValuePair3.Key, string.Empty, string.Empty);
					KeyValuePair<int, object> keyValuePair4 = enumerator2.Current;
					FashionComposeTable fashionComposeTable = keyValuePair4.Value as FashionComposeTable;
					if (tableItem2 != null && fashionComposeTable != null)
					{
						FashionType type2 = FashionType.FT_NORMAL;
						int key2 = this._getFashionKey(type2, fashionComposeTable.Occu, fashionComposeTable.SuitID, tableItem2.SubType);
						if (this.m_key2Fashions.ContainsKey(key2))
						{
							Logger.LogErrorFormat("error key repeated !!! for ProtoTable.FashionComposeSkyTable !!! id = {0} <color=#ffff00>name = {1}</color>", new object[]
							{
								tableItem2.ID,
								tableItem2.Name
							});
						}
						else
						{
							this.m_key2Fashions[key2] = tableItem2.ID;
						}
					}
				}
				this.m_bLoadType2OccuToFashions = true;
			}
		}

		// Token: 0x06018D0B RID: 101643 RVA: 0x007C1D0C File Offset: 0x007C010C
		public sealed override void Initialize()
		{
			if (this.m_dicOccuToFashion.Count == 0)
			{
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<FashionComposeSkyTable>();
				Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TableManager instance = Singleton<TableManager>.GetInstance();
					KeyValuePair<int, object> keyValuePair = enumerator.Current;
					ItemTable tableItem = instance.GetTableItem<ItemTable>(keyValuePair.Key, string.Empty, string.Empty);
					KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
					FashionComposeSkyTable fashionComposeSkyTable = keyValuePair2.Value as FashionComposeSkyTable;
					if (tableItem != null && fashionComposeSkyTable != null)
					{
						if (!this.m_dicOccuToFashion.ContainsKey(fashionComposeSkyTable.Occu))
						{
							this.m_dicOccuToFashion.Add(fashionComposeSkyTable.Occu, new List<int>());
						}
						this.m_dicOccuToFashion[fashionComposeSkyTable.Occu].Add(tableItem.ID);
					}
				}
				Dictionary<int, object> table2 = Singleton<TableManager>.GetInstance().GetTable<FashionComposeTable>();
				Dictionary<int, object>.Enumerator enumerator2 = table2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					TableManager instance2 = Singleton<TableManager>.GetInstance();
					KeyValuePair<int, object> keyValuePair3 = enumerator2.Current;
					ItemTable tableItem2 = instance2.GetTableItem<ItemTable>(keyValuePair3.Key, string.Empty, string.Empty);
					KeyValuePair<int, object> keyValuePair4 = enumerator2.Current;
					FashionComposeTable fashionComposeTable = keyValuePair4.Value as FashionComposeTable;
					if (tableItem2 != null && fashionComposeTable != null)
					{
						if (!this.m_dicOccuToFashion.ContainsKey(fashionComposeTable.Occu))
						{
							this.m_dicOccuToFashion.Add(fashionComposeTable.Occu, new List<int>());
						}
						this.m_dicOccuToFashion[fashionComposeTable.Occu].Add(tableItem2.ID);
					}
				}
			}
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVICE_FASHION_MERGO, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServerSwitchFunc));
		}

		// Token: 0x06018D0C RID: 101644 RVA: 0x007C1EB7 File Offset: 0x007C02B7
		public List<int> GetFashionItemsByOccu(int occu)
		{
			if (this.m_dicOccuToFashion.ContainsKey(occu / 10))
			{
				return this.m_dicOccuToFashion[occu / 10];
			}
			return null;
		}

		// Token: 0x06018D0D RID: 101645 RVA: 0x007C1EE0 File Offset: 0x007C02E0
		public int GetFashionByKey(FashionType eFashionType, int occu, int suit, ItemTable.eSubType subType)
		{
			occu /= 10;
			int key = this._getFashionKey(eFashionType, occu, suit, subType);
			if (!this.m_bLoadType2OccuToFashions)
			{
				this._LoadType2OccuToFashions();
			}
			if (this.m_key2Fashions.ContainsKey(key))
			{
				return this.m_key2Fashions[key];
			}
			return 0;
		}

		// Token: 0x06018D0E RID: 101646 RVA: 0x007C1F30 File Offset: 0x007C0330
		public void GetFashionItemsByTypeAndOccu(FashionType eFashionType, int occu, int suit, ref List<int> ids)
		{
			if (!this.m_bLoadType2OccuToFashions)
			{
				this._LoadType2OccuToFashions();
			}
			if (ids != null)
			{
				ids.Clear();
				for (int i = 0; i < this.mSubTypes.Length; i++)
				{
					int fashionByKey = this.GetFashionByKey(eFashionType, occu, suit, this.mSubTypes[i]);
					if (fashionByKey != 0)
					{
						ids.Add(fashionByKey);
					}
				}
			}
		}

		// Token: 0x06018D0F RID: 101647 RVA: 0x007C1F98 File Offset: 0x007C0398
		public override void Clear()
		{
			this.data.bOk = false;
			this.data.datas.Clear();
			this.data.eFashionMergeResultType = FashionMergeResultType.FMRT_NORMAL;
			this._skySuitId = 1;
			this._normalSuitId = 1;
			this._fashionType = FashionType.FT_SKY;
			this._recordNomalFashionType = FashionType.FT_SKY;
			this._FashionPart = ItemTable.eSubType.ST_NONE;
			this.mSkyGuids.Clear();
			this.ChangeFashionIsAllMerged = false;
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVICE_FASHION_MERGO, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServerSwitchFunc));
		}

		// Token: 0x06018D10 RID: 101648 RVA: 0x007C201D File Offset: 0x007C041D
		private void _OnServerSwitchFunc(ServerSceneFuncSwitch funcSwitch)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionMergeSwich, null, null, null, null);
		}

		// Token: 0x1700206F RID: 8303
		// (get) Token: 0x06018D11 RID: 101649 RVA: 0x007C2032 File Offset: 0x007C0432
		public int redCount
		{
			get
			{
				return this.mSkyGuids.Count;
			}
		}

		// Token: 0x06018D12 RID: 101650 RVA: 0x007C203F File Offset: 0x007C043F
		public void ClearRedPoit()
		{
			this.mSkyGuids.Clear();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionMergeRedCounChanged, null, null, null, null);
		}

		// Token: 0x17002070 RID: 8304
		// (get) Token: 0x06018D13 RID: 101651 RVA: 0x007C205F File Offset: 0x007C045F
		// (set) Token: 0x06018D14 RID: 101652 RVA: 0x007C2067 File Offset: 0x007C0467
		public int SkySuitID
		{
			get
			{
				return this._skySuitId;
			}
			set
			{
				this._skySuitId = value;
			}
		}

		// Token: 0x17002071 RID: 8305
		// (get) Token: 0x06018D15 RID: 101653 RVA: 0x007C2070 File Offset: 0x007C0470
		// (set) Token: 0x06018D16 RID: 101654 RVA: 0x007C2078 File Offset: 0x007C0478
		public int NormalSuitID
		{
			get
			{
				return this._normalSuitId;
			}
			set
			{
				this._normalSuitId = value;
			}
		}

		// Token: 0x17002072 RID: 8306
		// (get) Token: 0x06018D17 RID: 101655 RVA: 0x007C2081 File Offset: 0x007C0481
		// (set) Token: 0x06018D18 RID: 101656 RVA: 0x007C2089 File Offset: 0x007C0489
		public FashionType FashionType
		{
			get
			{
				return this._fashionType;
			}
			set
			{
				if (this._fashionType != value)
				{
					this.ClearRedPoit();
				}
				this._fashionType = value;
			}
		}

		// Token: 0x17002073 RID: 8307
		// (get) Token: 0x06018D19 RID: 101657 RVA: 0x007C20A4 File Offset: 0x007C04A4
		// (set) Token: 0x06018D1A RID: 101658 RVA: 0x007C20AC File Offset: 0x007C04AC
		public FashionType RecordNomalFashionType
		{
			get
			{
				return this._recordNomalFashionType;
			}
			set
			{
				this._recordNomalFashionType = value;
			}
		}

		// Token: 0x17002074 RID: 8308
		// (get) Token: 0x06018D1B RID: 101659 RVA: 0x007C20B5 File Offset: 0x007C04B5
		// (set) Token: 0x06018D1C RID: 101660 RVA: 0x007C20BD File Offset: 0x007C04BD
		public ItemTable.eSubType FashionPart
		{
			get
			{
				return this._FashionPart;
			}
			set
			{
				this._FashionPart = value;
			}
		}

		// Token: 0x06018D1D RID: 101661 RVA: 0x007C20C8 File Offset: 0x007C04C8
		public bool HasSkyFashion(ItemTable.eSubType sub)
		{
			List<ulong> itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Fashion, sub);
			itemsByPackageSubType.InsertRange(itemsByPackageSubType.Count, DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.WearFashion, sub));
			for (int i = 0; i < itemsByPackageSubType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageSubType[i]);
				if (item != null)
				{
					if (item.SubType == (int)sub)
					{
						if (item.FixTimeLeft <= 0)
						{
							FashionComposeSkyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(item.TableID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								FashionType type = (FashionType)tableItem.Type;
								if (type == this.FashionType)
								{
									if (tableItem.Occu == DataManager<PlayerBaseData>.GetInstance().JobTableID / 10)
									{
										return true;
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06018D1E RID: 101662 RVA: 0x007C21B0 File Offset: 0x007C05B0
		public ItemTable.eSubType GetDefaultFashionPart()
		{
			ItemTable.eSubType result = ItemTable.eSubType.FASHION_HEAD;
			int num = 0;
			for (int i = 0; i < this.pools.Length; i++)
			{
				if (this.HasSkyFashion(this.pools[i]))
				{
					num |= 1 << i;
				}
			}
			for (int j = 0; j < this.pools.Length; j++)
			{
				if ((num & 1 << j) == 0)
				{
					result = this.pools[j];
					break;
				}
			}
			return result;
		}

		// Token: 0x17002075 RID: 8309
		// (get) Token: 0x06018D1F RID: 101663 RVA: 0x007C222C File Offset: 0x007C062C
		public FashionResultData FashionResultData
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x17002076 RID: 8310
		// (get) Token: 0x06018D20 RID: 101664 RVA: 0x007C2234 File Offset: 0x007C0634
		public int FashionMergeMaterialID
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(134, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x06018D21 RID: 101665 RVA: 0x007C226C File Offset: 0x007C066C
		public void SendFashionMerge(ulong left, ulong right, ulong mergeBoxID, int skySuitID, int skyFashionID)
		{
			SceneFashionMergeReq sceneFashionMergeReq = new SceneFashionMergeReq();
			sceneFashionMergeReq.leftid = left;
			sceneFashionMergeReq.rightid = right;
			sceneFashionMergeReq.composer = mergeBoxID;
			sceneFashionMergeReq.skySuitID = (uint)skySuitID;
			sceneFashionMergeReq.selFashionID = (uint)skyFashionID;
			NetManager.Instance().SendCommand<SceneFashionMergeReq>(ServerType.GATE_SERVER, sceneFashionMergeReq);
		}

		// Token: 0x06018D22 RID: 101666 RVA: 0x007C22B4 File Offset: 0x007C06B4
		public void SendChangeFashionMerge(ulong left, ulong changeTicketID, uint mergeFashionID)
		{
			SceneFashionChangeActiveMergeReq sceneFashionChangeActiveMergeReq = new SceneFashionChangeActiveMergeReq();
			sceneFashionChangeActiveMergeReq.fashionId = left;
			sceneFashionChangeActiveMergeReq.ticketId = changeTicketID;
			sceneFashionChangeActiveMergeReq.choiceComFashionId = mergeFashionID;
			NetManager.Instance().SendCommand<SceneFashionChangeActiveMergeReq>(ServerType.GATE_SERVER, sceneFashionChangeActiveMergeReq);
		}

		// Token: 0x06018D23 RID: 101667 RVA: 0x007C22EC File Offset: 0x007C06EC
		public void OnRecvSceneFashionMergeRes(MsgDATA msg)
		{
			SceneFashionMergeRes sceneFashionMergeRes = new SceneFashionMergeRes();
			sceneFashionMergeRes.decode(msg.bytes);
			if (sceneFashionMergeRes.result == 0)
			{
				this.data.bOk = true;
				this.data.eFashionMergeResultType = ((sceneFashionMergeRes.itemB != 0U) ? FashionMergeResultType.FMRT_SPECIAL : FashionMergeResultType.FMRT_NORMAL);
				this.data.datas.Clear();
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)sceneFashionMergeRes.itemA, 100, 0);
				if (itemData != null)
				{
					itemData.Count = sceneFashionMergeRes.numA;
					this.data.datas.Add(itemData);
				}
				itemData = ItemDataManager.CreateItemDataFromTable((int)sceneFashionMergeRes.itemB, 100, 0);
				if (itemData != null)
				{
					itemData.Count = sceneFashionMergeRes.numB;
					this.data.datas.Add(itemData);
				}
				itemData = ItemDataManager.CreateItemDataFromTable((int)sceneFashionMergeRes.itemC, 100, 0);
				if (itemData != null)
				{
					itemData.Count = 1;
					this.data.datas.Add(itemData);
				}
				if (this.data.datas.Count > 0)
				{
					FashionMergeResultFrame.Open(this.data);
				}
				if (this.data.datas.Count >= 2)
				{
					for (int i = 1; i < this.data.datas.Count; i++)
					{
						ItemData itemData2 = this.data.datas[i];
						if (itemData2 != null)
						{
							FashionComposeSkyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(itemData2.TableID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								if (tableItem.Type != (int)this._fashionType)
								{
									if (!this.mSkyGuids.Contains(itemData2.TableID))
									{
										this.mSkyGuids.Add(itemData2.TableID);
									}
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionMergeRedCounChanged, null, null, null, null);
								}
							}
						}
					}
				}
			}
			else
			{
				this.data.datas.Clear();
				this.data.eFashionMergeResultType = FashionMergeResultType.FMRT_NORMAL;
				this.data.bOk = false;
				SystemNotifyManager.SystemNotify(sceneFashionMergeRes.result, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionMergeNotify, this.data, null, null, null);
		}

		// Token: 0x06018D24 RID: 101668 RVA: 0x007C2524 File Offset: 0x007C0924
		public void OnRecvSceneFashionChangeActiveMergeRet(MsgDATA msg)
		{
			SceneFashionChangeActiveMergeRet sceneFashionChangeActiveMergeRet = new SceneFashionChangeActiveMergeRet();
			sceneFashionChangeActiveMergeRet.decode(msg.bytes);
			if (sceneFashionChangeActiveMergeRet.ret == 0U)
			{
				this.ChangeFashionIsAllMerged = (sceneFashionChangeActiveMergeRet.allMerged == 1);
				this.data.bOk = true;
				this.data.eFashionMergeResultType = ((sceneFashionChangeActiveMergeRet.advanceId != 0U) ? FashionMergeResultType.FMRT_SPECIAL : FashionMergeResultType.FMRT_NORMAL);
				this.data.datas.Clear();
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)sceneFashionChangeActiveMergeRet.commonId, 100, 0);
				if (itemData != null)
				{
					this.data.datas.Add(itemData);
				}
				itemData = ItemDataManager.CreateItemDataFromTable((int)sceneFashionChangeActiveMergeRet.advanceId, 100, 0);
				if (itemData != null)
				{
					this.data.datas.Add(itemData);
				}
				if (this.data.datas.Count > 0)
				{
					FashionMergeResultFrame.Open(this.data);
				}
			}
			else
			{
				this.data.datas.Clear();
				this.data.eFashionMergeResultType = FashionMergeResultType.FMRT_NORMAL;
				this.data.bOk = false;
				SystemNotifyManager.SystemNotify((int)sceneFashionChangeActiveMergeRet.ret, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionMergeNotify, this.data, null, null, null);
		}

		// Token: 0x17002077 RID: 8311
		// (get) Token: 0x06018D25 RID: 101669 RVA: 0x007C2658 File Offset: 0x007C0A58
		public TipFuncButon MergeFunction
		{
			get
			{
				if (this.mMergeFunction == null)
				{
					this.mMergeFunction = new TipFuncButon();
					this.mMergeFunction.text = TR.Value("tip_fashion_merge");
					this.mMergeFunction.name = "fashion_merge";
					this.mMergeFunction.callback = new OnTipFuncClicked(this._OnFashionMergeSelItem);
				}
				return this.mMergeFunction;
			}
		}

		// Token: 0x06018D26 RID: 101670 RVA: 0x007C26C0 File Offset: 0x007C0AC0
		private void _OnFashionMergeSelItem(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				if (a_item.bFashionItemLocked)
				{
					SystemNotifyManager.SystemNotify(1000107, string.Empty);
					return;
				}
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionMergeNewFrame>(null, false);
				this._FashionPart = (ItemTable.eSubType)a_item.SubType;
				FashionMergeNewFrame.OpenLinkFrame(string.Format("0|0|{0}|{1}|{2}", (int)DataManager<FashionMergeManager>.GetInstance().FashionType, (int)DataManager<FashionMergeManager>.GetInstance().FashionPart, a_item.GUID));
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x06018D27 RID: 101671 RVA: 0x007C2748 File Offset: 0x007C0B48
		public void SetAutoEquipState(int state)
		{
			SceneFashionMergeRecordReq sceneFashionMergeRecordReq = new SceneFashionMergeRecordReq();
			sceneFashionMergeRecordReq.handleType = (uint)state;
			NetManager.Instance().SendCommand<SceneFashionMergeRecordReq>(ServerType.GATE_SERVER, sceneFashionMergeRecordReq);
		}

		// Token: 0x06018D28 RID: 101672 RVA: 0x007C276F File Offset: 0x007C0B6F
		public bool IsChangeSectionActivity(FashionType type)
		{
			return type == FashionType.FT_NATIONALDAY;
		}

		// Token: 0x04011E16 RID: 73238
		private Dictionary<int, List<int>> m_dicOccuToFashion = new Dictionary<int, List<int>>();

		// Token: 0x04011E17 RID: 73239
		private Dictionary<int, int> m_key2Fashions = new Dictionary<int, int>();

		// Token: 0x04011E18 RID: 73240
		private bool m_bChangeFashionIsAllMerged;

		// Token: 0x04011E19 RID: 73241
		private bool m_bLoadType2OccuToFashions;

		// Token: 0x04011E1A RID: 73242
		private ItemTable.eSubType[] mSubTypes = new ItemTable.eSubType[]
		{
			ItemTable.eSubType.FASHION_HEAD,
			ItemTable.eSubType.FASHION_CHEST,
			ItemTable.eSubType.FASHION_EPAULET,
			ItemTable.eSubType.FASHION_LEG,
			ItemTable.eSubType.FASHION_SASH,
			ItemTable.eSubType.FASHION_HAIR
		};

		// Token: 0x04011E1B RID: 73243
		private List<int> mSkyGuids = new List<int>();

		// Token: 0x04011E1C RID: 73244
		public FashionMergeManager.OnFashionMergeChanged onFashionMergeChanged;

		// Token: 0x04011E1D RID: 73245
		private FashionResultData data = new FashionResultData
		{
			bOk = false,
			datas = new List<ItemData>(),
			eFashionMergeResultType = FashionMergeResultType.FMRT_NORMAL
		};

		// Token: 0x04011E1E RID: 73246
		private int _skySuitId = 1;

		// Token: 0x04011E1F RID: 73247
		private int _normalSuitId = 1;

		// Token: 0x04011E20 RID: 73248
		private FashionType _fashionType = FashionType.FT_SKY;

		// Token: 0x04011E21 RID: 73249
		private FashionType _recordNomalFashionType = FashionType.FT_SKY;

		// Token: 0x04011E22 RID: 73250
		private ItemTable.eSubType _FashionPart;

		// Token: 0x04011E23 RID: 73251
		private ItemTable.eSubType[] pools = new ItemTable.eSubType[]
		{
			ItemTable.eSubType.FASHION_HEAD,
			ItemTable.eSubType.FASHION_CHEST,
			ItemTable.eSubType.FASHION_EPAULET,
			ItemTable.eSubType.FASHION_LEG,
			ItemTable.eSubType.FASHION_SASH
		};

		// Token: 0x04011E24 RID: 73252
		private TipFuncButon mMergeFunction;

		// Token: 0x0200457E RID: 17790
		// (Invoke) Token: 0x06018D2A RID: 101674
		public delegate void OnFashionMergeChanged(FashionResultData data);
	}
}
