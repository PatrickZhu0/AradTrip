using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200135C RID: 4956
	public class ZillionaireGameDataManager : DataManager<ZillionaireGameDataManager>
	{
		// Token: 0x17001BA8 RID: 7080
		// (get) Token: 0x0600C017 RID: 49175 RVA: 0x002D3DB8 File Offset: 0x002D21B8
		// (set) Token: 0x0600C018 RID: 49176 RVA: 0x002D3DC0 File Offset: 0x002D21C0
		public int CoinCount
		{
			get
			{
				return this.coinCount;
			}
			set
			{
				this.coinCount = value;
			}
		}

		// Token: 0x17001BA9 RID: 7081
		// (get) Token: 0x0600C019 RID: 49177 RVA: 0x002D3DC9 File Offset: 0x002D21C9
		// (set) Token: 0x0600C01A RID: 49178 RVA: 0x002D3DD1 File Offset: 0x002D21D1
		public int Turn
		{
			get
			{
				return this.turn;
			}
			set
			{
				this.turn = value;
			}
		}

		// Token: 0x17001BAA RID: 7082
		// (get) Token: 0x0600C01B RID: 49179 RVA: 0x002D3DDA File Offset: 0x002D21DA
		// (set) Token: 0x0600C01C RID: 49180 RVA: 0x002D3DE2 File Offset: 0x002D21E2
		public int CurrentGrid
		{
			get
			{
				return this.currentGrid;
			}
			set
			{
				this.currentGrid = value;
			}
		}

		// Token: 0x17001BAB RID: 7083
		// (get) Token: 0x0600C01D RID: 49181 RVA: 0x002D3DEB File Offset: 0x002D21EB
		// (set) Token: 0x0600C01E RID: 49182 RVA: 0x002D3DF3 File Offset: 0x002D21F3
		public int RollTimes
		{
			get
			{
				return this.rollTimes;
			}
			set
			{
				this.rollTimes = value;
			}
		}

		// Token: 0x17001BAC RID: 7084
		// (get) Token: 0x0600C01F RID: 49183 RVA: 0x002D3DFC File Offset: 0x002D21FC
		// (set) Token: 0x0600C020 RID: 49184 RVA: 0x002D3E04 File Offset: 0x002D2204
		public int BeforeBuff
		{
			get
			{
				return this.beforeBuff;
			}
			set
			{
				this.beforeBuff = value;
			}
		}

		// Token: 0x17001BAD RID: 7085
		// (get) Token: 0x0600C021 RID: 49185 RVA: 0x002D3E0D File Offset: 0x002D220D
		// (set) Token: 0x0600C022 RID: 49186 RVA: 0x002D3E15 File Offset: 0x002D2215
		public int Buff
		{
			get
			{
				return this.buff;
			}
			set
			{
				if (value != this.buff)
				{
					this.BeforeBuff = this.buff;
					this.buff = value;
				}
			}
		}

		// Token: 0x0600C023 RID: 49187 RVA: 0x002D3E36 File Offset: 0x002D2236
		public void ClearRealRewardList()
		{
			if (this.realRewardList != null)
			{
				this.realRewardList.Clear();
			}
		}

		// Token: 0x0600C024 RID: 49188 RVA: 0x002D3E50 File Offset: 0x002D2250
		public override void Clear()
		{
			if (this.monopolyMapTableList != null)
			{
				this.monopolyMapTableList.Clear();
			}
			if (this.monopolyRandomTableList != null)
			{
				this.monopolyRandomTableList.Clear();
			}
			if (this.monopolyCardTableList != null)
			{
				this.monopolyCardTableList.Clear();
			}
			if (this.cardExchangeDataList != null)
			{
				this.cardExchangeDataList.Clear();
			}
			if (this.monpolyCardList != null)
			{
				this.monpolyCardList.Clear();
			}
			this.ClearRealRewardList();
			this.coinCount = 0;
			this.turn = 0;
			this.currentGrid = 0;
			this.rollTimes = 0;
			this.buff = 0;
			this.beforeBuff = 0;
			this.UnBindNetMsg();
		}

		// Token: 0x0600C025 RID: 49189 RVA: 0x002D3F01 File Offset: 0x002D2301
		public override void Initialize()
		{
			this.BindNetMsg();
			this.InitMonopolyMapTable();
			this.InitMonopolyRandomTable();
			this.InitMonopolyCardTable();
			this.InitCardExchangeData();
		}

		// Token: 0x0600C026 RID: 49190 RVA: 0x002D3F24 File Offset: 0x002D2324
		private void BindNetMsg()
		{
			NetProcess.AddMsgHandler(610202U, new Action<MsgDATA>(this.OnWorldMonopolyCoinRes));
			NetProcess.AddMsgHandler(610204U, new Action<MsgDATA>(this.OnWorldMonopolyStatusRes));
			NetProcess.AddMsgHandler(610206U, new Action<MsgDATA>(this.OnWorldMonopolyRollRes));
			NetProcess.AddMsgHandler(610210U, new Action<MsgDATA>(this.OnWorldMonopolyCardListRes));
			NetProcess.AddMsgHandler(610208U, new Action<MsgDATA>(this.OnWorldMonopolyCardExchangeRes));
			NetProcess.AddMsgHandler(610212U, new Action<MsgDATA>(this.OnWorldMonopolySellCardRes));
			NetProcess.AddMsgHandler(610213U, new Action<MsgDATA>(this.OnWorldMonopolyNotifyResult));
			NetProcess.AddMsgHandler(610215U, new Action<MsgDATA>(this.OnWorldMonopolyCardExchangedListRes));
		}

		// Token: 0x0600C027 RID: 49191 RVA: 0x002D3FE4 File Offset: 0x002D23E4
		private void UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(610202U, new Action<MsgDATA>(this.OnWorldMonopolyCoinRes));
			NetProcess.RemoveMsgHandler(610204U, new Action<MsgDATA>(this.OnWorldMonopolyStatusRes));
			NetProcess.RemoveMsgHandler(610206U, new Action<MsgDATA>(this.OnWorldMonopolyRollRes));
			NetProcess.RemoveMsgHandler(610210U, new Action<MsgDATA>(this.OnWorldMonopolyCardListRes));
			NetProcess.RemoveMsgHandler(610208U, new Action<MsgDATA>(this.OnWorldMonopolyCardExchangeRes));
			NetProcess.RemoveMsgHandler(610212U, new Action<MsgDATA>(this.OnWorldMonopolySellCardRes));
			NetProcess.RemoveMsgHandler(610213U, new Action<MsgDATA>(this.OnWorldMonopolyNotifyResult));
			NetProcess.RemoveMsgHandler(610215U, new Action<MsgDATA>(this.OnWorldMonopolyCardExchangedListRes));
		}

		// Token: 0x0600C028 RID: 49192 RVA: 0x002D40A4 File Offset: 0x002D24A4
		private void OnWorldMonopolyCoinRes(MsgDATA msg)
		{
			WorldMonopolyCoinRes worldMonopolyCoinRes = new WorldMonopolyCoinRes();
			worldMonopolyCoinRes.decode(msg.bytes);
			this.coinCount = (int)worldMonopolyCoinRes.num;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnZillionaireGameInfoChanged, null, null, null, null);
		}

		// Token: 0x0600C029 RID: 49193 RVA: 0x002D40E4 File Offset: 0x002D24E4
		private void OnWorldMonopolyStatusRes(MsgDATA msg)
		{
			WorldMonopolyStatusRes worldMonopolyStatusRes = new WorldMonopolyStatusRes();
			worldMonopolyStatusRes.decode(msg.bytes);
			this.turn = (int)worldMonopolyStatusRes.turn;
			this.currentGrid = (int)worldMonopolyStatusRes.currentGrid;
			this.rollTimes = (int)worldMonopolyStatusRes.rollTimes;
			this.Buff = (int)worldMonopolyStatusRes.buff;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnZillionaireGameInfoChanged, null, null, null, null);
		}

		// Token: 0x0600C02A RID: 49194 RVA: 0x002D4148 File Offset: 0x002D2548
		private void OnWorldMonopolyRollRes(MsgDATA msg)
		{
			WorldMonopolyRollRes worldMonopolyRollRes = new WorldMonopolyRollRes();
			worldMonopolyRollRes.decode(msg.bytes);
			if (worldMonopolyRollRes.errorCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMonopolyRollRes.errorCode, string.Empty);
			}
			else
			{
				int step = (int)worldMonopolyRollRes.step;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMonopolyRollResSuccessed, step, null, null, null);
			}
		}

		// Token: 0x0600C02B RID: 49195 RVA: 0x002D41A8 File Offset: 0x002D25A8
		private void OnWorldMonopolyCardListRes(MsgDATA msg)
		{
			WorldMonopolyCardListRes worldMonopolyCardListRes = new WorldMonopolyCardListRes();
			worldMonopolyCardListRes.decode(msg.bytes);
			if (worldMonopolyCardListRes.cardList != null)
			{
				for (int i = 0; i < worldMonopolyCardListRes.cardList.Length; i++)
				{
					MonpolyCard data = worldMonopolyCardListRes.cardList[i];
					if (data != null)
					{
						MonpolyCard monpolyCard = this.monpolyCardList.Find((MonpolyCard x) => x.id == data.id);
						if (monpolyCard == null)
						{
							this.monpolyCardList.Add(data);
						}
						else
						{
							monpolyCard.num = data.num;
						}
					}
				}
				for (int j = 0; j < this.cardExchangeDataList.Count; j++)
				{
					this.cardExchangeDataList[j].RefreshState();
				}
				this.OnSendWorldMonopolyCardExchangedListReq();
			}
		}

		// Token: 0x0600C02C RID: 49196 RVA: 0x002D428C File Offset: 0x002D268C
		private void OnWorldMonopolyCardExchangeRes(MsgDATA msg)
		{
			WorldMonopolyCardExchangeRes stream = new WorldMonopolyCardExchangeRes();
			stream.decode(msg.bytes);
		}

		// Token: 0x0600C02D RID: 49197 RVA: 0x002D42AC File Offset: 0x002D26AC
		private void OnWorldMonopolySellCardRes(MsgDATA msg)
		{
			WorldMonopolySellCardRes stream = new WorldMonopolySellCardRes();
			stream.decode(msg.bytes);
		}

		// Token: 0x0600C02E RID: 49198 RVA: 0x002D42CC File Offset: 0x002D26CC
		private void OnWorldMonopolyNotifyResult(MsgDATA msg)
		{
			WorldMonopolyNotifyResult worldMonopolyNotifyResult = new WorldMonopolyNotifyResult();
			worldMonopolyNotifyResult.decode(msg.bytes);
			RealRewardData realRewardData = new RealRewardData();
			realRewardData.tableId = (int)worldMonopolyNotifyResult.resultId;
			realRewardData.cardId = (int)worldMonopolyNotifyResult.param;
			if (this.realRewardList != null)
			{
				this.realRewardList.Add(realRewardData);
			}
		}

		// Token: 0x0600C02F RID: 49199 RVA: 0x002D4324 File Offset: 0x002D2724
		private void OnWorldMonopolyCardExchangedListRes(MsgDATA msg)
		{
			WorldMonopolyCardExchangedListRes worldMonopolyCardExchangedListRes = new WorldMonopolyCardExchangedListRes();
			worldMonopolyCardExchangedListRes.decode(msg.bytes);
			if (worldMonopolyCardExchangedListRes.cardList != null)
			{
				for (int i = 0; i < worldMonopolyCardExchangedListRes.cardList.Length; i++)
				{
					MonpolyCard data = worldMonopolyCardExchangedListRes.cardList[i];
					if (data != null)
					{
						CardExchangeData cardExchangeData = this.cardExchangeDataList.Find((CardExchangeData x) => (long)x.tableId == (long)((ulong)data.id));
						if (cardExchangeData != null && (long)cardExchangeData.limitCount - (long)((ulong)data.num) <= 0L)
						{
							cardExchangeData.state = 5;
						}
					}
				}
				for (int j = 0; j < this.cardExchangeDataList.Count; j++)
				{
					CardExchangeData cardExchangeData2 = this.cardExchangeDataList[j];
					if (cardExchangeData2 != null)
					{
						if (cardExchangeData2.type == 2)
						{
							if (cardExchangeData2.state == 5)
							{
								break;
							}
							bool flag = false;
							foreach (CardExchangeData cardExchangeData3 in this.cardExchangeDataList)
							{
								if (cardExchangeData3.type != 2)
								{
									if (cardExchangeData3.state != 5)
									{
										flag = false;
										break;
									}
									flag = true;
								}
							}
							cardExchangeData2.state = ((!flag) ? 1 : 2);
						}
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnBlessingCardChanged, null, null, null, null);
			}
		}

		// Token: 0x0600C030 RID: 49200 RVA: 0x002D44CC File Offset: 0x002D28CC
		public void OnSendWorldMonopolyCoinReq()
		{
			WorldMonopolyCoinReq cmd = new WorldMonopolyCoinReq();
			NetManager.Instance().SendCommand<WorldMonopolyCoinReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600C031 RID: 49201 RVA: 0x002D44EC File Offset: 0x002D28EC
		public void OnSendWorldMonopolyStatusReq()
		{
			WorldMonopolyStatusReq cmd = new WorldMonopolyStatusReq();
			NetManager.Instance().SendCommand<WorldMonopolyStatusReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600C032 RID: 49202 RVA: 0x002D450C File Offset: 0x002D290C
		public void OnSendWorldMonopolyRollReq()
		{
			WorldMonopolyRollReq cmd = new WorldMonopolyRollReq();
			NetManager.Instance().SendCommand<WorldMonopolyRollReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600C033 RID: 49203 RVA: 0x002D452C File Offset: 0x002D292C
		public void OnSendWorldMonopolyCardListReq()
		{
			WorldMonopolyCardListReq cmd = new WorldMonopolyCardListReq();
			NetManager.Instance().SendCommand<WorldMonopolyCardListReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600C034 RID: 49204 RVA: 0x002D454C File Offset: 0x002D294C
		public void OnSendWorldMonopolyCardExchangeReq(int cardId)
		{
			WorldMonopolyCardExchangeReq worldMonopolyCardExchangeReq = new WorldMonopolyCardExchangeReq();
			worldMonopolyCardExchangeReq.id = (uint)cardId;
			NetManager.Instance().SendCommand<WorldMonopolyCardExchangeReq>(ServerType.GATE_SERVER, worldMonopolyCardExchangeReq);
		}

		// Token: 0x0600C035 RID: 49205 RVA: 0x002D4574 File Offset: 0x002D2974
		public void OnSendWorldMonopolySellCardReq(int id, int num)
		{
			WorldMonopolySellCardReq worldMonopolySellCardReq = new WorldMonopolySellCardReq();
			worldMonopolySellCardReq.id = (uint)id;
			worldMonopolySellCardReq.num = (uint)num;
			NetManager.Instance().SendCommand<WorldMonopolySellCardReq>(ServerType.GATE_SERVER, worldMonopolySellCardReq);
		}

		// Token: 0x0600C036 RID: 49206 RVA: 0x002D45A4 File Offset: 0x002D29A4
		public void OnSendWorldMonopolyCardExchangedListReq()
		{
			WorldMonopolyCardExchangedListReq cmd = new WorldMonopolyCardExchangedListReq();
			NetManager.Instance().SendCommand<WorldMonopolyCardExchangedListReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600C037 RID: 49207 RVA: 0x002D45C4 File Offset: 0x002D29C4
		private void InitMonopolyMapTable()
		{
			if (this.monopolyMapTableList == null)
			{
				this.monopolyMapTableList = new List<MonopolyMapTable>();
			}
			this.monopolyMapTableList.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<MonopolyMapTable>())
			{
				MonopolyMapTable monopolyMapTable = keyValuePair.Value as MonopolyMapTable;
				if (monopolyMapTable != null)
				{
					this.monopolyMapTableList.Add(monopolyMapTable);
				}
			}
		}

		// Token: 0x0600C038 RID: 49208 RVA: 0x002D4640 File Offset: 0x002D2A40
		private void InitMonopolyRandomTable()
		{
			if (this.monopolyRandomTableList == null)
			{
				this.monopolyRandomTableList = new List<MonopolyRandomTable>();
			}
			this.monopolyRandomTableList.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<MonopolyRandomTable>())
			{
				MonopolyRandomTable monopolyRandomTable = keyValuePair.Value as MonopolyRandomTable;
				if (monopolyRandomTable != null)
				{
					this.monopolyRandomTableList.Add(monopolyRandomTable);
				}
			}
			this.InitRuleDescList();
		}

		// Token: 0x0600C039 RID: 49209 RVA: 0x002D46C4 File Offset: 0x002D2AC4
		private void InitMonopolyCardTable()
		{
			if (this.monopolyCardTableList == null)
			{
				this.monopolyCardTableList = new List<MonopolyCardTable>();
			}
			this.monopolyCardTableList.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<MonopolyCardTable>())
			{
				MonopolyCardTable monopolyCardTable = keyValuePair.Value as MonopolyCardTable;
				if (monopolyCardTable != null)
				{
					this.monopolyCardTableList.Add(monopolyCardTable);
				}
			}
		}

		// Token: 0x0600C03A RID: 49210 RVA: 0x002D4740 File Offset: 0x002D2B40
		private void InitCardExchangeData()
		{
			if (this.cardExchangeDataList == null)
			{
				this.cardExchangeDataList = new List<CardExchangeData>();
			}
			this.cardExchangeDataList.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<MonopolyCardRewardTable>())
			{
				MonopolyCardRewardTable monopolyCardRewardTable = keyValuePair.Value as MonopolyCardRewardTable;
				if (monopolyCardRewardTable != null)
				{
					CardExchangeData cardExchangeData = new CardExchangeData();
					cardExchangeData.tableId = monopolyCardRewardTable.ID;
					cardExchangeData.type = monopolyCardRewardTable.type;
					cardExchangeData.limitCount = monopolyCardRewardTable.time;
					cardExchangeData.costCardList = CommonUtility.GetItemSimpleDataListByTwoSplitChar(monopolyCardRewardTable.costCard, ',', '_');
					cardExchangeData.reward = CommonUtility.GetItemSimpleDataByOneSplitChar(monopolyCardRewardTable.reward, '_');
					this.cardExchangeDataList.Add(cardExchangeData);
				}
			}
		}

		// Token: 0x0600C03B RID: 49211 RVA: 0x002D4810 File Offset: 0x002D2C10
		public List<MapGridItemData> GetGridItemDataList(int cylinderNumber)
		{
			List<MapGridItemData> list = new List<MapGridItemData>();
			MonopolyMapTable monopolyMapTable = null;
			for (int i = 0; i < this.monopolyMapTableList.Count; i++)
			{
				MonopolyMapTable monopolyMapTable2 = this.monopolyMapTableList[i];
				if (monopolyMapTable2 != null)
				{
					if (monopolyMapTable2.turn == cylinderNumber)
					{
						monopolyMapTable = monopolyMapTable2;
						break;
					}
				}
			}
			if (monopolyMapTable != null)
			{
				for (int j = 0; j < monopolyMapTable.content.Length; j++)
				{
					int gridIndex = j;
					int num = monopolyMapTable.content[j];
					for (int k = 0; k < this.monopolyRandomTableList.Count; k++)
					{
						MonopolyRandomTable monopolyRandomTable = this.monopolyRandomTableList[k];
						if (monopolyRandomTable != null)
						{
							if (num == monopolyRandomTable.gridType)
							{
								MapGridItemData mapGridItemData = list.Find((MapGridItemData x) => x.gridIndex == gridIndex);
								if (mapGridItemData == null)
								{
									MapGridItemData mapGridItemData2 = new MapGridItemData();
									mapGridItemData2.gridIndex = gridIndex;
									mapGridItemData2.gridType = monopolyRandomTable.gridType;
									mapGridItemData2.randomType = monopolyRandomTable.randomType;
									mapGridItemData2.gridIconPath = monopolyRandomTable.image;
									mapGridItemData2.gridName = monopolyRandomTable.title;
									mapGridItemData2.gridDesc = monopolyRandomTable.describe;
									if (mapGridItemData2.gridType != 1 && mapGridItemData2.gridType != 5)
									{
										int.TryParse(monopolyRandomTable.num, out mapGridItemData2.itemCount);
									}
									mapGridItemData2.rewardList = new List<ItemSimpleData>();
									if (mapGridItemData2.gridType != 1)
									{
										if (mapGridItemData2.gridType == 5)
										{
											mapGridItemData2.rewardList = CommonUtility.GetItemSimpleDataListByTwoSplitChar(monopolyRandomTable.num, '|', '_');
										}
										else if (mapGridItemData2.gridType == 3)
										{
											for (int l = 0; l < this.monopolyCardTableList.Count; l++)
											{
												MonopolyCardTable monopolyCardTable = this.monopolyCardTableList[l];
												if (monopolyCardTable != null)
												{
													ItemSimpleData itemSimpleData = new ItemSimpleData();
													itemSimpleData.ItemID = monopolyCardTable.card;
													mapGridItemData2.rewardList.Add(itemSimpleData);
												}
											}
										}
										else
										{
											ItemSimpleData item;
											if (monopolyRandomTable.type == 2)
											{
												item = new ItemSimpleData(int.Parse(monopolyRandomTable.param), 1);
											}
											else
											{
												item = new ItemSimpleData(int.Parse(monopolyRandomTable.param), int.Parse(monopolyRandomTable.num));
											}
											mapGridItemData2.rewardList.Add(item);
										}
									}
									list.Add(mapGridItemData2);
								}
								else if (mapGridItemData.gridType != 1)
								{
									if (mapGridItemData.gridType != 5)
									{
										if (mapGridItemData.gridType != 3)
										{
											ItemSimpleData item2;
											if (monopolyRandomTable.type == 2)
											{
												item2 = new ItemSimpleData(int.Parse(monopolyRandomTable.param), 1);
											}
											else
											{
												item2 = new ItemSimpleData(int.Parse(monopolyRandomTable.param), int.Parse(monopolyRandomTable.num));
											}
											mapGridItemData.rewardList.Add(item2);
										}
									}
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600C03C RID: 49212 RVA: 0x002D4B48 File Offset: 0x002D2F48
		public void InitRuleDescList()
		{
			if (this.ruleDescList == null)
			{
				this.ruleDescList = new List<MapGridItemData>();
			}
			this.ruleDescList.Clear();
			for (int i = 0; i < this.monopolyRandomTableList.Count; i++)
			{
				MonopolyRandomTable monopolyRandomTable = this.monopolyRandomTableList[i];
				if (monopolyRandomTable != null)
				{
					if (this.ruleDescList.Find((MapGridItemData x) => x.gridType == monopolyRandomTable.gridType) == null)
					{
						MapGridItemData mapGridItemData = new MapGridItemData();
						mapGridItemData.gridType = monopolyRandomTable.gridType;
						mapGridItemData.gridIconPath = monopolyRandomTable.image;
						mapGridItemData.gridName = monopolyRandomTable.title;
						mapGridItemData.gridDesc = monopolyRandomTable.describe;
						if (mapGridItemData.gridType == 6 || mapGridItemData.gridType == 7 || mapGridItemData.gridType == 8 || mapGridItemData.gridType == 9)
						{
							mapGridItemData.itemCount = int.Parse(monopolyRandomTable.num);
						}
						this.ruleDescList.Add(mapGridItemData);
					}
				}
			}
		}

		// Token: 0x0600C03D RID: 49213 RVA: 0x002D4C78 File Offset: 0x002D3078
		public bool FindBlessingCard(int id)
		{
			for (int i = 0; i < this.monopolyCardTableList.Count; i++)
			{
				MonopolyCardTable monopolyCardTable = this.monopolyCardTableList[i];
				if (monopolyCardTable != null)
				{
					if (monopolyCardTable.card == id)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600C03E RID: 49214 RVA: 0x002D4CD0 File Offset: 0x002D30D0
		public int FindBlessingCardCount(int id)
		{
			for (int i = 0; i < this.monpolyCardList.Count; i++)
			{
				MonpolyCard monpolyCard = this.monpolyCardList[i];
				if (monpolyCard != null)
				{
					if ((ulong)monpolyCard.id == (ulong)((long)id))
					{
						return (int)monpolyCard.num;
					}
				}
			}
			return 0;
		}

		// Token: 0x04006C81 RID: 27777
		public List<MonopolyMapTable> monopolyMapTableList = new List<MonopolyMapTable>();

		// Token: 0x04006C82 RID: 27778
		public List<MonopolyRandomTable> monopolyRandomTableList = new List<MonopolyRandomTable>();

		// Token: 0x04006C83 RID: 27779
		public List<MonopolyCardTable> monopolyCardTableList = new List<MonopolyCardTable>();

		// Token: 0x04006C84 RID: 27780
		public List<MapGridItemData> ruleDescList = new List<MapGridItemData>();

		// Token: 0x04006C85 RID: 27781
		public List<CardExchangeData> cardExchangeDataList = new List<CardExchangeData>();

		// Token: 0x04006C86 RID: 27782
		public List<MonpolyCard> monpolyCardList = new List<MonpolyCard>();

		// Token: 0x04006C87 RID: 27783
		public List<RealRewardData> realRewardList = new List<RealRewardData>();

		// Token: 0x04006C88 RID: 27784
		private int coinCount;

		// Token: 0x04006C89 RID: 27785
		private int turn;

		// Token: 0x04006C8A RID: 27786
		private int currentGrid;

		// Token: 0x04006C8B RID: 27787
		private int rollTimes;

		// Token: 0x04006C8C RID: 27788
		private int beforeBuff;

		// Token: 0x04006C8D RID: 27789
		private int buff;
	}
}
