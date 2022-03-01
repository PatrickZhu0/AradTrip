using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012A6 RID: 4774
	internal class JarDataManager : DataManager<JarDataManager>
	{
		// Token: 0x17001AFD RID: 6909
		// (get) Token: 0x0600B79C RID: 47004 RVA: 0x0029EFCB File Offset: 0x0029D3CB
		// (set) Token: 0x0600B79D RID: 47005 RVA: 0x0029EFD3 File Offset: 0x0029D3D3
		public bool isNotify
		{
			get
			{
				return this.m_bNotify;
			}
			set
			{
				this.m_bNotify = value;
			}
		}

		// Token: 0x0600B79E RID: 47006 RVA: 0x0029EFDC File Offset: 0x0029D3DC
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.MagicJarDataManager;
		}

		// Token: 0x0600B79F RID: 47007 RVA: 0x0029EFE0 File Offset: 0x0029D3E0
		public override void Initialize()
		{
			this._InitJarTableData();
			this._InitMagicJar();
			this._InitGoldJar();
			this.m_bNotify = true;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(691, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.m_MagicJarScoreCount = tableItem.Value;
			}
		}

		// Token: 0x0600B7A0 RID: 47008 RVA: 0x0029F032 File Offset: 0x0029D432
		public override void Clear()
		{
			this._ClearJarTableData();
			this._ClearMagicJar();
			this._ClearGoldJar();
			this.m_bNotify = true;
			this.m_MagicJarScoreCount = 0;
		}

		// Token: 0x0600B7A1 RID: 47009 RVA: 0x0029F054 File Offset: 0x0029D454
		public void OnJobChanged()
		{
			this._InitJarTableData();
			this._InitMagicJar();
			this._InitGoldJar();
		}

		// Token: 0x0600B7A2 RID: 47010 RVA: 0x0029F068 File Offset: 0x0029D468
		public JarData GetJarData(int a_nID)
		{
			JarData result = null;
			this.m_dictJarData.TryGetValue(a_nID, out result);
			return result;
		}

		// Token: 0x0600B7A3 RID: 47011 RVA: 0x0029F088 File Offset: 0x0029D488
		public bool ShowJarTips()
		{
			int year = 0;
			int month = 0;
			int num = 0;
			string dateTime = DataManager<AuctionDataManager>.GetInstance().GetDateTime((int)DataManager<TimeManager>.GetInstance().GetServerTime());
			string[] array = dateTime.Split(new char[]
			{
				'-'
			});
			if (array.Length <= 0)
			{
				return false;
			}
			string s = array[0];
			string s2 = array[1];
			string s3 = array[2];
			int.TryParse(s, out year);
			int.TryParse(s2, out month);
			int.TryParse(s3, out num);
			int num2 = DateTime.DaysInMonth(year, month);
			int num3 = num2 - num;
			return num3 <= 2 && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Jar);
		}

		// Token: 0x0600B7A4 RID: 47012 RVA: 0x0029F128 File Offset: 0x0029D528
		public bool CheckRedPoint(JarBonus.eType a_eType)
		{
			foreach (KeyValuePair<int, JarData> keyValuePair in this.m_dictJarData)
			{
				JarData value = keyValuePair.Value;
				if (value != null && value.eType == a_eType)
				{
					for (int i = 0; i < value.arrBuyInfos.Count; i++)
					{
						if (this.CheckRedPoint(value, value.arrBuyInfos[i]))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B7A5 RID: 47013 RVA: 0x0029F1AB File Offset: 0x0029D5AB
		public bool CheckRedPoint(JarData a_data, JarBuyInfo a_buyInfo)
		{
			return a_buyInfo.nFreeCount > 0 || (a_buyInfo.arrCosts.Count > 0 && a_buyInfo.arrCosts[0].item.Count < 1);
		}

		// Token: 0x0600B7A6 RID: 47014 RVA: 0x0029F1EC File Offset: 0x0029D5EC
		public void RequestBuyJar(JarData a_data, JarBuyInfo a_buyInfo, uint opActId = 0U, uint useDiscountItemId = 0U)
		{
			SceneUseMagicJarReq sceneUseMagicJarReq = new SceneUseMagicJarReq();
			sceneUseMagicJarReq.type = (uint)a_data.nID;
			sceneUseMagicJarReq.combo = (byte)a_buyInfo.nBuyCount;
			sceneUseMagicJarReq.opActId = opActId;
			sceneUseMagicJarReq.param = useDiscountItemId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneUseMagicJarReq>(ServerType.GATE_SERVER, sceneUseMagicJarReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(500943U, delegate(MsgDATA data)
			{
				if (data == null)
				{
					return;
				}
				SceneUseMagicJarRet sceneUseMagicJarRet = new SceneUseMagicJarRet();
				int num = 0;
				sceneUseMagicJarRet.decode(data.bytes, ref num);
				List<Item> list = ItemDecoder.Decode(data.bytes, ref num, data.bytes.Length, false);
				if (sceneUseMagicJarRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)sceneUseMagicJarRet.code, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MagicJarUseFail, null, null, null, null);
				}
				else
				{
					DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
					List<JarBonus> list2 = new List<JarBonus>();
					list2.Add(new JarBonus
					{
						nBonusID = 0,
						item = ItemDataManager.CreateItemDataFromTable((int)sceneUseMagicJarRet.baseItem.id, 100, 0),
						item = 
						{
							Count = (int)sceneUseMagicJarRet.baseItem.num
						},
						bHighValue = false
					});
					for (int i = 0; i < sceneUseMagicJarRet.getItems.Length; i++)
					{
						OpenJarResult openJarResult = sceneUseMagicJarRet.getItems[i];
						if (openJarResult != null)
						{
							JarBonus jarBonus = new JarBonus();
							jarBonus.nBonusID = (int)openJarResult.jarItemId;
							JarItemPool tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JarItemPool>((int)openJarResult.jarItemId, string.Empty, string.Empty);
							if (tableItem != null)
							{
								ItemData itemData = null;
								for (int j = 0; j < list.Count; j++)
								{
									if ((long)tableItem.ItemID == (long)((ulong)list[j].dataid))
									{
										Item item = list[j];
										item.num -= (ushort)tableItem.ItemNum;
										itemData = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(list[j]);
										itemData.Count = tableItem.ItemNum;
										if (list[j].num <= 0)
										{
											list.RemoveAt(j);
										}
										break;
									}
								}
								if (itemData == null)
								{
									itemData = ItemDataManager.CreateItemDataFromTable(tableItem.ItemID, 100, 0);
									itemData.Count = tableItem.ItemNum;
								}
								jarBonus.item = itemData;
								jarBonus.bHighValue = (tableItem.ShowEffect == 1);
								list2.Add(jarBonus);
							}
							else
							{
								Logger.LogErrorFormat("JarItemPool表格数据为null, jarItemId = {0}", new object[]
								{
									(int)openJarResult.jarItemId
								});
							}
						}
						else
						{
							Logger.LogErrorFormat("RequestBuyJar的OpenJarResult为null, i ={0}", new object[]
							{
								i
							});
						}
					}
					ShowItemsFrameData showItemsFrameData = new ShowItemsFrameData();
					showItemsFrameData.data = a_data;
					showItemsFrameData.items = list2;
					showItemsFrameData.buyInfo = a_buyInfo;
					showItemsFrameData.scoreItemData = ItemDataManager.CreateItemDataFromTable((int)sceneUseMagicJarRet.getPointId, 100, 0);
					if (showItemsFrameData.scoreItemData != null)
					{
						showItemsFrameData.scoreItemData.Count = (int)sceneUseMagicJarRet.getPoint;
					}
					showItemsFrameData.scoreRate = (int)sceneUseMagicJarRet.crit;
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<JarBuyResultFrame>(FrameLayer.Middle, showItemsFrameData, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MagicJarUseSuccess, showItemsFrameData, null, null, null);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.EquipRecovery, null, null, null);
				}
			}, true, -1f, null);
		}

		// Token: 0x0600B7A7 RID: 47015 RVA: 0x0029F278 File Offset: 0x0029D678
		public void RequestQuaryJarShopSocre()
		{
			SceneJarPointReq cmd = new SceneJarPointReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneJarPointReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneJarPointRes>(delegate(SceneJarPointRes msgRet)
			{
				DataManager<PlayerBaseData>.GetInstance().GoldJarScore = (ulong)msgRet.goldPoint;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GoldJarScoreChanged, null, null, null, null);
				DataManager<PlayerBaseData>.GetInstance().MagicJarScore = (ulong)msgRet.magPoint;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MagicJarScoreChanged, null, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x0600B7A8 RID: 47016 RVA: 0x0029F2CC File Offset: 0x0029D6CC
		public void RequestJarBuyRecord(int a_nJarID)
		{
			WorldOpenJarRecordReq worldOpenJarRecordReq = new WorldOpenJarRecordReq();
			worldOpenJarRecordReq.jarId = (uint)a_nJarID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldOpenJarRecordReq>(ServerType.GATE_SERVER, worldOpenJarRecordReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldOpenJarRecordRes>(delegate(WorldOpenJarRecordRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.JarOpenRecordUpdate, msgRet, null, null, null);
			}, false, 15f, null);
		}

		// Token: 0x0600B7A9 RID: 47017 RVA: 0x0029F324 File Offset: 0x0029D724
		protected JarBuyCost _CreateJarBuyCost(JarBonus a_table, bool a_bIsNeedExItem, bool a_bBuyOne)
		{
			JarBonus.eType type = a_table.Type;
			if (type == JarBonus.eType.FashionJar || type == JarBonus.eType.WingJar || type == JarBonus.eType.EquipJar)
			{
				if (!a_bIsNeedExItem)
				{
					return new ActivityJarBuyCost
					{
						nJarID = a_table.ID,
						nRemainDiscountTime = 0,
						bDisTimeReset = (a_table.ActJarDisReset != 0),
						item = ItemDataManager.CreateItemDataFromTable(a_table.BuyMoneyType, 100, 0),
						item = 
						{
							Count = a_table.MoneyValue
						},
						fDiscount = (float)a_table.SingleBuyDiscount / 100f
					};
				}
			}
			if (a_bIsNeedExItem)
			{
				JarBuyCost jarBuyCost = new JarBuyCost();
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(a_table.ExItemID, 100, 0);
				if (itemData == null)
				{
					Logger.LogErrorFormat("道具表没有id={0}的道具，JarBonus表id={1},策划检查道具表和罐子表所填道具id是否匹配", new object[]
					{
						a_table.ExItemID,
						a_table.ID
					});
				}
				else
				{
					jarBuyCost.item = itemData;
					jarBuyCost.item.Count = a_table.ExItemCostNum;
					jarBuyCost.fDiscount = 1f;
					jarBuyCost.nRemainDiscountTime = -1;
					jarBuyCost.bDisTimeReset = false;
				}
				return jarBuyCost;
			}
			ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(a_table.BuyMoneyType, 100, 0);
			if (itemData2 != null)
			{
				return new JarBuyCost
				{
					item = itemData2,
					item = 
					{
						Count = a_table.MoneyValue
					},
					fDiscount = ((!a_bBuyOne) ? ((float)a_table.ComboBuyDiscount / 100f) : 1f),
					nRemainDiscountTime = -1,
					bDisTimeReset = false
				};
			}
			return null;
		}

		// Token: 0x0600B7AA RID: 47018 RVA: 0x0029F4BC File Offset: 0x0029D8BC
		protected void _InitJarTableData()
		{
			this.m_dictJarData.Clear();
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			Dictionary<int, List<ItemSimpleData>> dictionary = new Dictionary<int, List<ItemSimpleData>>();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<JarItemShowPool>())
			{
				JarItemShowPool jarItemShowPool = keyValuePair.Value as JarItemShowPool;
				if (jarItemShowPool.Visible.Count >= 1)
				{
					for (int i = 0; i < jarItemShowPool.Visible.Count; i++)
					{
						if (jarItemShowPool.Visible[i] == jobTableID || jarItemShowPool.Visible[i] == 0)
						{
							ItemSimpleData itemSimpleData = new ItemSimpleData();
							itemSimpleData.ItemID = jarItemShowPool.ItemID;
							itemSimpleData.Count = jarItemShowPool.ItemNum;
							if (!dictionary.ContainsKey(jarItemShowPool.JarType))
							{
								dictionary.Add(jarItemShowPool.JarType, new List<ItemSimpleData>());
							}
							dictionary[jarItemShowPool.JarType].Add(itemSimpleData);
						}
					}
				}
			}
			Dictionary<int, List<ItemSimpleData>> dictionary2 = new Dictionary<int, List<ItemSimpleData>>();
			foreach (KeyValuePair<int, object> keyValuePair2 in Singleton<TableManager>.GetInstance().GetTable<JarItemPool>())
			{
				JarItemPool jarItemPool = keyValuePair2.Value as JarItemPool;
				ItemSimpleData itemSimpleData2 = new ItemSimpleData();
				itemSimpleData2.ItemID = jarItemPool.ItemID;
				itemSimpleData2.Count = jarItemPool.ItemNum;
				if (!dictionary2.ContainsKey(jarItemPool.JarType))
				{
					dictionary2.Add(jarItemPool.JarType, new List<ItemSimpleData>());
				}
				dictionary2[jarItemPool.JarType].Add(itemSimpleData2);
			}
			foreach (KeyValuePair<int, object> keyValuePair3 in Singleton<TableManager>.GetInstance().GetTable<JarBonus>())
			{
				JarBonus jarBonus = keyValuePair3.Value as JarBonus;
				if (jarBonus != null)
				{
					JarData jarData = new JarData();
					jarData.nID = jarBonus.ID;
					jarData.eType = jarBonus.Type;
					jarData.strName = jarBonus.Name;
					jarData.arrFilters = jarBonus.Filter;
					jarData.strJarImagePath = jarBonus.JarImage;
					jarData.strJarModelPath = jarBonus.JarEffect;
					if (dictionary.ContainsKey(jarData.nID))
					{
						jarData.arrBonusItems = dictionary[jarData.nID];
					}
					else
					{
						jarData.arrBonusItems = new List<ItemSimpleData>();
					}
					if (dictionary2.ContainsKey(jarData.nID))
					{
						jarData.arrRealBonusItems = dictionary2[jarData.nID];
					}
					else
					{
						jarData.arrRealBonusItems = new List<ItemSimpleData>();
					}
					jarData.arrBuyInfos = new List<JarBuyInfo>();
					if (jarBonus.ComboBuyNum > 0)
					{
						JarBuyInfo jarBuyInfo;
						if (jarBonus.Type == JarBonus.eType.MagicJar || jarBonus.Type == JarBonus.eType.MagicJar_Lv55)
						{
							jarBuyInfo = new MagicJarBuyInfo(jarBonus.ID);
						}
						else
						{
							jarBuyInfo = new JarBuyInfo();
						}
						jarBuyInfo.nMaxFreeCount = jarBonus.MaxFreeCount;
						jarBuyInfo.nFreeCD = jarBonus.FreeCD;
						jarBuyInfo.nBuyCount = 1;
						jarBuyInfo.arrCosts = new List<JarBuyCost>();
						if (jarBonus.NeedExItem == 1)
						{
							JarBuyCost jarBuyCost = this._CreateJarBuyCost(jarBonus, true, true);
							if (jarBuyCost != null)
							{
								jarBuyInfo.arrCosts.Add(jarBuyCost);
							}
						}
						JarBuyCost jarBuyCost2 = this._CreateJarBuyCost(jarBonus, false, true);
						if (jarBuyCost2 != null)
						{
							jarBuyInfo.arrCosts.Add(jarBuyCost2);
						}
						jarData.arrBuyInfos.Add(jarBuyInfo);
						JarBuyInfo jarBuyInfo2 = new JarBuyInfo();
						jarBuyInfo2.nBuyCount = jarBonus.ComboBuyNum;
						jarBuyInfo2.arrCosts = new List<JarBuyCost>();
						if (jarBonus.NeedExItem == 1)
						{
							JarBuyCost jarBuyCost3 = this._CreateJarBuyCost(jarBonus, true, false);
							if (jarBuyCost3 != null)
							{
								jarBuyInfo2.arrCosts.Add(jarBuyCost3);
							}
						}
						JarBuyCost jarBuyCost4 = this._CreateJarBuyCost(jarBonus, false, false);
						if (jarBuyCost4 != null)
						{
							jarBuyInfo2.arrCosts.Add(jarBuyCost4);
						}
						jarData.arrBuyInfos.Add(jarBuyInfo2);
					}
					jarData.arrBuyItems = new List<ItemData>();
					for (int j = 0; j < jarBonus.GetItemsAndNum.Count; j++)
					{
						string[] array = jarBonus.GetItemsAndNum[j].Split(new char[]
						{
							','
						});
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array[0]), 100, 0);
						if (itemData != null)
						{
							itemData.Count = int.Parse(array[1]);
							jarData.arrBuyItems.Add(itemData);
						}
						else
						{
							Logger.LogErrorFormat("[罐子] {0} {1} 格式解析出错 {2}, 无法找到 {3} 的道具", new object[]
							{
								jarBonus.ID,
								jarBonus.Name,
								jarBonus.GetItemsAndNum[j],
								(array.Length <= 0) ? "数组为空" : array[0]
							});
						}
					}
					this.m_dictJarData.Add(jarData.nID, jarData);
				}
			}
		}

		// Token: 0x0600B7AB RID: 47019 RVA: 0x0029F9C4 File Offset: 0x0029DDC4
		protected void _ClearJarTableData()
		{
			this.m_dictJarData.Clear();
		}

		// Token: 0x0600B7AC RID: 47020 RVA: 0x0029F9D1 File Offset: 0x0029DDD1
		public JarData GetMagicJarData()
		{
			return this.m_magicJarData;
		}

		// Token: 0x0600B7AD RID: 47021 RVA: 0x0029F9D9 File Offset: 0x0029DDD9
		public JarData GetMagicJarData_Lv55()
		{
			return this.m_magicJarData_Lv55;
		}

		// Token: 0x0600B7AE RID: 47022 RVA: 0x0029F9E4 File Offset: 0x0029DDE4
		protected void _InitMagicJar()
		{
			if (this.m_dictJarData == null)
			{
				return;
			}
			this.m_magicJarData = null;
			this.m_magicJarData_Lv55 = null;
			foreach (KeyValuePair<int, JarData> keyValuePair in this.m_dictJarData)
			{
				if (keyValuePair.Value.eType == JarBonus.eType.MagicJar)
				{
					Dictionary<int, JarData>.Enumerator enumerator;
					KeyValuePair<int, JarData> keyValuePair2 = enumerator.Current;
					this.m_magicJarData = keyValuePair2.Value;
				}
				else
				{
					Dictionary<int, JarData>.Enumerator enumerator;
					KeyValuePair<int, JarData> keyValuePair3 = enumerator.Current;
					if (keyValuePair3.Value.eType == JarBonus.eType.MagicJar_Lv55)
					{
						KeyValuePair<int, JarData> keyValuePair4 = enumerator.Current;
						this.m_magicJarData_Lv55 = keyValuePair4.Value;
					}
				}
			}
		}

		// Token: 0x0600B7AF RID: 47023 RVA: 0x0029FA8C File Offset: 0x0029DE8C
		protected void _ClearMagicJar()
		{
			this.m_magicJarData = null;
			this.m_magicJarData_Lv55 = null;
		}

		// Token: 0x0600B7B0 RID: 47024 RVA: 0x0029FA9C File Offset: 0x0029DE9C
		public int GetMagicPotDiscountCount()
		{
			List<ItemData> list = new List<ItemData>();
			list = this.GetMagicPotDiscountItemData();
			list.Sort(new Comparison<ItemData>(this.Sort));
			if (list.Count > 0)
			{
				return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(list[0].TableID, true);
			}
			return 0;
		}

		// Token: 0x0600B7B1 RID: 47025 RVA: 0x0029FAF0 File Offset: 0x0029DEF0
		public ItemTable GetMagicPotDiscountTableData()
		{
			List<ItemData> list = new List<ItemData>();
			list = this.GetMagicPotDiscountItemData();
			list.Sort(new Comparison<ItemData>(this.Sort));
			if (list.Count > 0)
			{
				return list[0].TableData;
			}
			return null;
		}

		// Token: 0x0600B7B2 RID: 47026 RVA: 0x0029FB38 File Offset: 0x0029DF38
		private List<ItemData> GetMagicPotDiscountItemData()
		{
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (item.SubType == 142)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B7B3 RID: 47027 RVA: 0x0029FBA8 File Offset: 0x0029DFA8
		private int Sort(ItemData left, ItemData right)
		{
			if (left.TableData.DiscountCouponProp != right.TableData.DiscountCouponProp)
			{
				return left.TableData.DiscountCouponProp - right.TableData.DiscountCouponProp;
			}
			return left.TableID - right.TableID;
		}

		// Token: 0x0600B7B4 RID: 47028 RVA: 0x0029FBF8 File Offset: 0x0029DFF8
		public int GetMagicPotCredentialsCount(JarBuyInfo buyInfo)
		{
			if (buyInfo == null || buyInfo.arrCosts == null)
			{
				return 0;
			}
			for (int i = 0; i < buyInfo.arrCosts.Count; i++)
			{
				if (buyInfo.arrCosts[i].item.Type == ItemTable.eType.MATERIAL)
				{
					return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(buyInfo.arrCosts[i].item.TableID, true);
				}
			}
			return 0;
		}

		// Token: 0x0600B7B5 RID: 47029 RVA: 0x0029FC74 File Offset: 0x0029E074
		public JarData GetGoldJarData(int a_nfilterType, int a_nFilterLevel)
		{
			JarTreeNode jarTreeNode = this._GetChildTreeNode(this.m_goldJarTreeRoot, a_nfilterType);
			if (jarTreeNode != null)
			{
				jarTreeNode = this._GetChildTreeNode(jarTreeNode, a_nFilterLevel);
				if (jarTreeNode != null)
				{
					return jarTreeNode.value as JarData;
				}
			}
			return null;
		}

		// Token: 0x0600B7B6 RID: 47030 RVA: 0x0029FCB4 File Offset: 0x0029E0B4
		public bool CheckGoldJarLevelRedPoint(int a_nSubType, int a_nLevel)
		{
			JarData goldJarData = this.GetGoldJarData(a_nSubType, a_nLevel);
			for (int i = 0; i < goldJarData.arrBuyInfos.Count; i++)
			{
				if (this.CheckRedPoint(goldJarData, goldJarData.arrBuyInfos[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B7B7 RID: 47031 RVA: 0x0029FD04 File Offset: 0x0029E104
		public List<JarTreeNode> GetGoldJarLevels(int a_nfilterType)
		{
			JarTreeNode jarTreeNode = this._GetChildTreeNode(this.m_goldJarTreeRoot, a_nfilterType);
			if (jarTreeNode != null)
			{
				return jarTreeNode.children;
			}
			return null;
		}

		// Token: 0x0600B7B8 RID: 47032 RVA: 0x0029FD30 File Offset: 0x0029E130
		public string GetGoldJarMainTypeDesc(int a_nType)
		{
			int num = a_nType - 1;
			if (num >= 0 && num < this.m_arrMainTypeDescs.Length)
			{
				return TR.Value(this.m_arrMainTypeDescs[num]);
			}
			return string.Empty;
		}

		// Token: 0x0600B7B9 RID: 47033 RVA: 0x0029FD6C File Offset: 0x0029E16C
		public string GetGoldJarSubTypeDesc(int a_nType)
		{
			int num = a_nType - 1;
			if (num >= 0 && num < this.m_arrSubTypeDescs.Length)
			{
				return TR.Value(this.m_arrSubTypeDescs[num]);
			}
			return string.Empty;
		}

		// Token: 0x0600B7BA RID: 47034 RVA: 0x0029FDA8 File Offset: 0x0029E1A8
		protected void _InitGoldJar()
		{
			if (this.m_dictJarData == null)
			{
				return;
			}
			this.m_goldJarTreeRoot = new JarTreeNode();
			foreach (KeyValuePair<int, JarData> keyValuePair in this.m_dictJarData)
			{
				JarData value = keyValuePair.Value;
				if (value.eType == JarBonus.eType.GoldJar)
				{
					JarTreeNode jarTreeNode = this.m_goldJarTreeRoot;
					for (int i = 0; i < value.arrFilters.Count; i++)
					{
						JarTreeNode jarTreeNode2 = jarTreeNode.GetChild(value.arrFilters[i]);
						if (jarTreeNode2 == null)
						{
							jarTreeNode2 = new JarTreeNode();
							jarTreeNode2.parent = jarTreeNode;
							jarTreeNode2.children = null;
							jarTreeNode2.nKey = value.arrFilters[i];
							jarTreeNode2.value = ((i != value.arrFilters.Count - 1) ? null : value);
							jarTreeNode.AddChild(jarTreeNode2);
						}
						else if (i < value.arrFilters.Count - 1)
						{
							jarTreeNode2.value = null;
						}
						jarTreeNode = jarTreeNode2;
					}
				}
			}
		}

		// Token: 0x0600B7BB RID: 47035 RVA: 0x0029FEC1 File Offset: 0x0029E2C1
		private void _ClearGoldJar()
		{
			this.m_goldJarTreeRoot = null;
		}

		// Token: 0x0600B7BC RID: 47036 RVA: 0x0029FECC File Offset: 0x0029E2CC
		private JarTreeNode _GetChildTreeNode(JarTreeNode a_parentNode, int a_nKey)
		{
			if (a_parentNode != null && a_parentNode.children != null)
			{
				for (int i = 0; i < a_parentNode.children.Count; i++)
				{
					if (a_parentNode.children[i].nKey == a_nKey)
					{
						return a_parentNode.children[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600B7BD RID: 47037 RVA: 0x0029FF2C File Offset: 0x0029E32C
		public bool HasActivityJar()
		{
			Dictionary<int, object>.Enumerator enumerator = Singleton<TableManager>.GetInstance().GetTable<ActivityJarTable>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				ActivityInfo activityInfo = null;
				Dictionary<int, ActivityInfo> allActivities = DataManager<ActiveManager>.GetInstance().allActivities;
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				allActivities.TryGetValue(keyValuePair.Key, out activityInfo);
				if (activityInfo != null && activityInfo.state != 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B7BE RID: 47038 RVA: 0x0029FF94 File Offset: 0x0029E394
		public bool IsActivityJar(int a_nActivityID)
		{
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<ActivityJarTable>())
			{
				if (a_nActivityID == keyValuePair.Key)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B7BF RID: 47039 RVA: 0x0029FFDC File Offset: 0x0029E3DC
		public bool IsRedPointShow()
		{
			if (!this.HasRedPointFirstShowedToday())
			{
				CurrencyQuickTipsTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CurrencyQuickTipsTable>(600000065, string.Empty, string.Empty);
				if (tableItem != null && DataManager<DeadLineReminderDataManager>.GetInstance()._IsOwnedCurrency(tableItem.ID, this.m_MagicJarScoreCount))
				{
					return DataManager<DeadLineReminderDataManager>.GetInstance()._IsInDeadline(tableItem);
				}
			}
			return false;
		}

		// Token: 0x0600B7C0 RID: 47040 RVA: 0x002A0040 File Offset: 0x0029E440
		public bool HasRedPointFirstShowedToday()
		{
			int tempTimeStamp = this.GetTempTimeStamp();
			int refreshTimeStamp = this.GetRefreshTimeStamp();
			return tempTimeStamp >= refreshTimeStamp;
		}

		// Token: 0x0600B7C1 RID: 47041 RVA: 0x002A0065 File Offset: 0x0029E465
		private int GetTempTimeStamp()
		{
			return Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.MagicJarScoreRedPoint, new object[0]);
		}

		// Token: 0x0600B7C2 RID: 47042 RVA: 0x002A007C File Offset: 0x0029E47C
		public void SaveCurrTimeStamp()
		{
			int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.MagicJarScoreRedPoint, serverTime, new object[0]);
		}

		// Token: 0x0600B7C3 RID: 47043 RVA: 0x002A00A8 File Offset: 0x0029E4A8
		private int GetRefreshTimeStamp()
		{
			int currTimeHour = this.GetCurrTimeHour();
			DateTime currDateTime = this.GetCurrDateTime();
			DateTime time;
			if (this.m_RedPointUpdateHour >= currTimeHour)
			{
				time = Function.GetYesterdayGivenHourTime(this.m_RedPointUpdateHour);
			}
			else
			{
				time = Function.GetTodayGivenHourTime(this.m_RedPointUpdateHour);
			}
			return Convert.ToInt32(Function.ConvertDateTimeInt(time));
		}

		// Token: 0x0600B7C4 RID: 47044 RVA: 0x002A00FC File Offset: 0x0029E4FC
		private int GetCurrTimeHour()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime).Hour;
		}

		// Token: 0x0600B7C5 RID: 47045 RVA: 0x002A0124 File Offset: 0x0029E524
		private DateTime GetCurrDateTime()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime);
		}

		// Token: 0x04006797 RID: 26519
		private Dictionary<int, JarData> m_dictJarData = new Dictionary<int, JarData>();

		// Token: 0x04006798 RID: 26520
		private JarData m_magicJarData;

		// Token: 0x04006799 RID: 26521
		private JarData m_magicJarData_Lv55;

		// Token: 0x0400679A RID: 26522
		private JarTreeNode m_goldJarTreeRoot;

		// Token: 0x0400679B RID: 26523
		private string[] m_arrMainTypeDescs = new string[]
		{
			"goldjar_main_type_weapon",
			"goldjar_main_type_armor",
			"goldjar_main_type_jewelry"
		};

		// Token: 0x0400679C RID: 26524
		private string[] m_arrSubTypeDescs = new string[]
		{
			"goldjar_sub_type_huge_sword",
			"goldjar_sub_type_revolver",
			"goldjar_sub_type_staff",
			"goldjar_sub_type_cloth",
			"goldjar_sub_type_skin",
			"goldjar_sub_type_lightd",
			"goldjar_sub_type_heavy",
			"goldjar_sub_type_plate",
			"goldjar_sub_type_ring",
			"goldjar_sub_type_necklase",
			"goldjar_sub_type_bracelet"
		};

		// Token: 0x0400679D RID: 26525
		private bool m_bNotify = true;

		// Token: 0x0400679E RID: 26526
		private int m_RedPointUpdateHour = 6;

		// Token: 0x0400679F RID: 26527
		private int m_MagicJarScoreCount;
	}
}
