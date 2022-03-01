using System;
using System.Collections.Generic;
using System.Text;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02004575 RID: 17781
	internal class EnchantmentsCardManager : DataManager<EnchantmentsCardManager>
	{
		// Token: 0x1700206B RID: 8299
		// (get) Token: 0x06018CC1 RID: 101569 RVA: 0x007BF0F5 File Offset: 0x007BD4F5
		public List<EnchantmentsCardData> EnchantmentsCardDataList
		{
			get
			{
				return this.m_akTableGroup.Values.ToList<EnchantmentsCardData>();
			}
		}

		// Token: 0x06018CC2 RID: 101570 RVA: 0x007BF108 File Offset: 0x007BD508
		private void _InitEnchantmentsCard()
		{
			this.m_akEnchantmentsCardDataDic.Clear();
			this.m_akQuality2CardDic.Clear();
			this.m_akTableID2CardDic.Clear();
			this.m_akTableGroup.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MagicCardTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				EnchantmentsCardData enchantmentsCardData = this.CreateEnchantmentsCardFromTable(keyValuePair.Key);
				if (enchantmentsCardData != null)
				{
					if (enchantmentsCardData.item != null)
					{
						if (enchantmentsCardData.item.Owner == ItemTable.eOwner.NOTBIND)
						{
							this.m_akTableGroup.Add((ulong)((long)enchantmentsCardData.itemData.TableID), enchantmentsCardData);
							this._AddQualityCard(enchantmentsCardData);
						}
					}
				}
			}
		}

		// Token: 0x06018CC3 RID: 101571 RVA: 0x007BF1C8 File Offset: 0x007BD5C8
		private void _AddQualityCard(EnchantmentsCardData data)
		{
			EnchantmentsType quality = EnchantmentsCardManager.GetQuality(data.itemData.Quality);
			List<EnchantmentsCardData> list = null;
			if (!this.m_akQuality2CardDic.TryGetValue(quality, out list))
			{
				list = new List<EnchantmentsCardData>();
				this.m_akQuality2CardDic.Add(quality, list);
			}
			list.RemoveAll((EnchantmentsCardData x) => x.itemData.TableID == data.itemData.TableID);
			list.Add(data);
		}

		// Token: 0x06018CC4 RID: 101572 RVA: 0x007BF240 File Offset: 0x007BD640
		private void _AddCard(EnchantmentsCardData data)
		{
			if (!this.m_akEnchantmentsCardDataDic.ContainsKey(data.itemData.GUID))
			{
				this.m_akEnchantmentsCardDataDic.Add(data.itemData.GUID, data);
				List<EnchantmentsCardData> list = null;
				if (!this.m_akTableID2CardDic.TryGetValue((ulong)((long)data.itemData.TableID), out list))
				{
					list = new List<EnchantmentsCardData>();
					this.m_akTableID2CardDic.Add((ulong)((long)data.itemData.TableID), list);
				}
				list.Add(data);
				if (this.m_akTableGroup.ContainsKey((ulong)((long)data.itemData.TableID)))
				{
					this.m_akTableGroup.Remove((ulong)((long)data.itemData.TableID));
				}
				this.m_akTableGroup.Add((ulong)((long)data.itemData.TableID), data);
				this._AddQualityCard(data);
			}
		}

		// Token: 0x06018CC5 RID: 101573 RVA: 0x007BF31C File Offset: 0x007BD71C
		private void _RemoveCard(EnchantmentsCardData data)
		{
			if (this.m_akEnchantmentsCardDataDic.ContainsKey(data.itemData.GUID))
			{
				this.m_akEnchantmentsCardDataDic.Remove(data.itemData.GUID);
				List<EnchantmentsCardData> list = null;
				if (this.m_akTableID2CardDic.TryGetValue((ulong)((long)data.itemData.TableID), out list))
				{
					bool flag = false;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].itemData.GUID == data.itemData.GUID)
						{
							list.RemoveAt(i--);
							if (this.m_akTableGroup.ContainsKey((ulong)((long)data.itemData.TableID)))
							{
								this.m_akTableGroup.Remove((ulong)((long)data.itemData.TableID));
							}
							else
							{
								Logger.LogError("m_akTableGroup erase error!");
							}
							if (list.Count <= 0)
							{
								EnchantmentsCardData enchantmentsCardData = this.CreateEnchantmentsCardFromTable(data.itemData.TableID);
								if (enchantmentsCardData != null)
								{
									this.m_akTableGroup.Add((ulong)((long)enchantmentsCardData.itemData.TableID), enchantmentsCardData);
								}
								else
								{
									Logger.LogErrorFormat("CreateEnchantmentsCardFromTable id = {0} failed !", new object[]
									{
										data.itemData.TableID
									});
								}
							}
							else
							{
								this.m_akTableGroup.Add((ulong)((long)data.itemData.TableID), list[0]);
							}
							this._AddQualityCard(this.m_akTableGroup[(ulong)((long)data.itemData.TableID)]);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Logger.LogError("m_akTableID2CardDic erase error!");
					}
				}
				else
				{
					Logger.LogError("m_akTableID2CardDic erase error!");
				}
			}
		}

		// Token: 0x06018CC6 RID: 101574 RVA: 0x007BF4D4 File Offset: 0x007BD8D4
		public bool HasNewCard()
		{
			for (int i = 0; i < 6; i++)
			{
				if (this.HasNewQualityCard((EnchantmentsType)i))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06018CC7 RID: 101575 RVA: 0x007BF502 File Offset: 0x007BD902
		public bool HasQualityCard(EnchantmentsType eEnchantmentsType)
		{
			return this.m_akQuality2CardDic.ContainsKey(eEnchantmentsType) && this.m_akQuality2CardDic[eEnchantmentsType].Count > 0;
		}

		// Token: 0x06018CC8 RID: 101576 RVA: 0x007BF52C File Offset: 0x007BD92C
		public bool HasNewQualityCard(EnchantmentsType eEnchantmentsType)
		{
			if (this.HasQualityCard(eEnchantmentsType))
			{
				List<EnchantmentsCardData> list = this.m_akQuality2CardDic[eEnchantmentsType];
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].itemData.IsNew)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06018CC9 RID: 101577 RVA: 0x007BF588 File Offset: 0x007BD988
		public void RemoveNewMark(ulong iTableID)
		{
			if (this.m_akTableGroup.ContainsKey(iTableID))
			{
				EnchantmentsCardData enchantmentsCardData = this.m_akTableGroup[iTableID];
				enchantmentsCardData.itemData.IsNew = false;
				if (this.onTabMarkChanged != null)
				{
					this.onTabMarkChanged(iTableID);
				}
			}
		}

		// Token: 0x06018CCA RID: 101578 RVA: 0x007BF5D6 File Offset: 0x007BD9D6
		public override void Initialize()
		{
			this.RegisterNetHandler();
			this._InitEnchantmentsCard();
			this.InitMagicCardProbabilityTable();
			this.UnBindDelegate();
			this.BindDelegate();
		}

		// Token: 0x06018CCB RID: 101579 RVA: 0x007BF5F8 File Offset: 0x007BD9F8
		protected void BindDelegate()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06018CCC RID: 101580 RVA: 0x007BF678 File Offset: 0x007BDA78
		protected void UnBindDelegate()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06018CCD RID: 101581 RVA: 0x007BF6F8 File Offset: 0x007BDAF8
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(500947U, new Action<MsgDATA>(this.OnRecvSceneMagicCardCompRet));
			NetProcess.AddMsgHandler(500945U, new Action<MsgDATA>(this.OnRecvSceneAddMagicRet));
			NetProcess.AddMsgHandler(501056U, new Action<MsgDATA>(this.OnSceneMagicCardUpgradeRes));
		}

		// Token: 0x06018CCE RID: 101582 RVA: 0x007BF748 File Offset: 0x007BDB48
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(500947U, new Action<MsgDATA>(this.OnRecvSceneMagicCardCompRet));
			NetProcess.RemoveMsgHandler(500945U, new Action<MsgDATA>(this.OnRecvSceneAddMagicRet));
			NetProcess.RemoveMsgHandler(501056U, new Action<MsgDATA>(this.OnSceneMagicCardUpgradeRes));
		}

		// Token: 0x06018CCF RID: 101583 RVA: 0x007BF798 File Offset: 0x007BDB98
		public override void Clear()
		{
			this.UnRegisterNetHandler();
			this.m_akEnchantmentsCardDataDic.Clear();
			this.m_akQuality2CardDic.Clear();
			this.m_akTableID2CardDic.Clear();
			this.m_akTableGroup.Clear();
			this.mEnchantmentCardProbabilityDataList.Clear();
			this.UnBindDelegate();
			this.IsNotShowGoldCoinTip = false;
			this.IsShowBindTip = false;
			this.IsShowQualityTip = false;
			this.IsShowLevelTip = false;
		}

		// Token: 0x06018CD0 RID: 101584 RVA: 0x007BF804 File Offset: 0x007BDC04
		private void OnAddNewItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null && item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 25)
				{
					EnchantmentsCardData enchantmentsCardData = this.CreateEnchantmentsCardFromNet(item.GUID);
					if (enchantmentsCardData != null)
					{
						if (enchantmentsCardData.item != null)
						{
							if (enchantmentsCardData.item.Owner == ItemTable.eOwner.NOTBIND)
							{
								this._AddCard(enchantmentsCardData);
								if (this.onUpdateCard != null)
								{
									this.onUpdateCard(enchantmentsCardData);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06018CD1 RID: 101585 RVA: 0x007BF8B8 File Offset: 0x007BDCB8
		private void OnRemoveItem(ItemData itemData)
		{
			if (this.m_akEnchantmentsCardDataDic.ContainsKey(itemData.GUID))
			{
				this._RemoveCard(this.m_akEnchantmentsCardDataDic[itemData.GUID]);
				if (this.onUpdateCard != null)
				{
					this.onUpdateCard(this.m_akTableGroup[(ulong)((long)itemData.TableID)]);
				}
			}
		}

		// Token: 0x06018CD2 RID: 101586 RVA: 0x007BF920 File Offset: 0x007BDD20
		private void OnUpdateItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null && item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 25)
				{
					EnchantmentsCardData enchantmentsCardData = this.CreateEnchantmentsCardFromNet(item.GUID);
					if (enchantmentsCardData != null)
					{
						if (enchantmentsCardData.item != null)
						{
							if (enchantmentsCardData.item.Owner == ItemTable.eOwner.NOTBIND)
							{
								this._RemoveCard(enchantmentsCardData);
								this._AddCard(enchantmentsCardData);
								if (this.onUpdateCard != null)
								{
									this.onUpdateCard(enchantmentsCardData);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06018CD3 RID: 101587 RVA: 0x007BF9D8 File Offset: 0x007BDDD8
		public static EnchantmentsType GetQuality(ItemTable.eColor eColor)
		{
			for (int i = 0; i < 6; i++)
			{
				Type typeFromHandle = typeof(EnchantmentsType);
				MapIndex enumAttribute = Utility.GetEnumAttribute<EnchantmentsType, MapIndex>((EnchantmentsType)i);
				if (enumAttribute.Index == (int)eColor)
				{
					return (EnchantmentsType)i;
				}
			}
			return EnchantmentsType.ET_NORMAL;
		}

		// Token: 0x06018CD4 RID: 101588 RVA: 0x007BFA18 File Offset: 0x007BDE18
		public EnchantmentsCardData CreateEnchantmentsCardFromTable(int iTableID)
		{
			EnchantmentsCardData enchantmentsCardData = null;
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(iTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(iTableID, 100, 0);
				if (itemData != null)
				{
					enchantmentsCardData = new EnchantmentsCardData();
					enchantmentsCardData.Count = 0;
					enchantmentsCardData.guid = (ulong)((long)iTableID);
					enchantmentsCardData.itemData = itemData;
					enchantmentsCardData.magicItem = tableItem;
					enchantmentsCardData.item = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(iTableID, string.Empty, string.Empty);
				}
				else
				{
					Logger.LogErrorFormat("iTableID = {0} can not find in table itemTable!", new object[]
					{
						iTableID
					});
				}
			}
			return enchantmentsCardData;
		}

		// Token: 0x06018CD5 RID: 101589 RVA: 0x007BFAB0 File Offset: 0x007BDEB0
		public EnchantmentsCardData CreateEnchantmentsCardFromNet(ulong guid)
		{
			EnchantmentsCardData enchantmentsCardData = null;
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (item != null)
			{
				enchantmentsCardData = this.CreateEnchantmentsCardFromTable(item.TableID);
				if (enchantmentsCardData != null)
				{
					enchantmentsCardData.itemData.GUID = item.GUID;
					enchantmentsCardData.itemData.Count = item.Count;
					enchantmentsCardData.Count = enchantmentsCardData.itemData.Count;
				}
			}
			if (enchantmentsCardData == null)
			{
				Logger.LogErrorFormat("CreateEnchantmentsCardFromNet guid = {0} failed!", new object[]
				{
					guid
				});
			}
			return enchantmentsCardData;
		}

		// Token: 0x06018CD6 RID: 101590 RVA: 0x007BFB38 File Offset: 0x007BDF38
		public string GetAttributesDesc(int iID)
		{
			string empty = string.Empty;
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(iID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return empty;
			}
			return this.MagicCardAndBeadCardGetAttributesDesc(tableItem.PropType, tableItem.PropValue, tableItem.BuffID, tableItem.SkillAttributes, empty, false, false);
		}

		// Token: 0x06018CD7 RID: 101591 RVA: 0x007BFB8C File Offset: 0x007BDF8C
		public string MagicCardAndBeadCardGetAttributesDesc(IList<int> iPropType, IList<int> iPropValue, IList<int> iBuffID, string sStrSkillAttributes, string ret, bool mProminentAtt = false, bool isSubstitutionBox = false)
		{
			bool flag = false;
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			if (iPropType.Count == iPropValue.Count)
			{
				if (iPropType.Count > 0)
				{
					stringBuilder.AppendFormat("<color={0}>", TR.Value("enchant_attribute_color"));
				}
				for (int i = 0; i < iPropType.Count; i++)
				{
					if (iPropValue[i] != 0)
					{
						EServerProp enumValue = (EServerProp)iPropType[i];
						MapEnum mapEnum = Utility.GetEnumAttribute<EServerProp, MapEnum>(enumValue);
						if (mapEnum == null && iPropType[i] >= 18 && iPropType[i] <= 21)
						{
							mapEnum = new MapEnum((EEquipProp)(iPropType[i] - 18));
						}
						if (mapEnum == null && iPropType[i] >= 22 && iPropType[i] <= 25)
						{
							mapEnum = new MapEnum(EEquipProp.Elements);
						}
						if (mapEnum != null)
						{
							EEquipProp prop = mapEnum.Prop;
							string eequipProDesc = Utility.GetEEquipProDesc(prop, iPropValue[i], string.Empty);
							if (flag)
							{
								stringBuilder.Append("\n");
							}
							stringBuilder.Append(eequipProDesc);
							flag = true;
						}
					}
				}
				if (iPropType.Count > 0)
				{
					stringBuilder.Append("</color>");
				}
			}
			if (!string.IsNullOrEmpty(sStrSkillAttributes))
			{
				if (flag)
				{
					stringBuilder.Append("\n");
				}
				stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_skills_color"), sStrSkillAttributes);
				flag = true;
			}
			int num = 0;
			if (mProminentAtt)
			{
				if (DataManager<BeadCardManager>.GetInstance().FindProminentAttID(iBuffID, ref num))
				{
					BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(num, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Description.Count > 0)
					{
						if (flag)
						{
							stringBuilder.Append("\n");
						}
						stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_skills_color"), tableItem.Description[0]);
						flag = true;
					}
				}
				if (!isSubstitutionBox)
				{
					for (int j = 0; j < iBuffID.Count; j++)
					{
						if (num != iBuffID[j])
						{
							BuffInfoTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(iBuffID[j], string.Empty, string.Empty);
							if (tableItem2 != null && tableItem2.Description.Count > 0)
							{
								if (flag)
								{
									stringBuilder.Append("\n");
								}
								stringBuilder.AppendFormat(TR.Value("color_grey", tableItem2.Description[0]), new object[0]);
								flag = true;
							}
						}
					}
				}
			}
			else
			{
				for (int k = 0; k < iBuffID.Count; k++)
				{
					BuffInfoTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(iBuffID[k], string.Empty, string.Empty);
					if (tableItem3 != null && tableItem3.Description.Count > 0)
					{
						if (flag)
						{
							stringBuilder.Append("\n");
						}
						stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_skills_color"), tableItem3.Description[0]);
						flag = true;
					}
				}
			}
			ret = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return ret;
		}

		// Token: 0x06018CD8 RID: 101592 RVA: 0x007BFECF File Offset: 0x007BE2CF
		public string GetAttributesDesc(EnchantmentsCardData data)
		{
			return this.GetAttributesDesc(data.magicItem.ID);
		}

		// Token: 0x06018CD9 RID: 101593 RVA: 0x007BFEE4 File Offset: 0x007BE2E4
		public string GetCondition(int iMagicCard)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.AppendFormat("<color={0}>", TR.Value("enchant_condition_color"));
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(iMagicCard, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.Parts.Count; i++)
				{
					string enumDescription = Utility.GetEnumDescription<EEquipWearSlotType>((EEquipWearSlotType)tableItem.Parts[i]);
					stringBuilder.Append(TR.Value(enumDescription));
					if (i != tableItem.Parts.Count - 1)
					{
						stringBuilder.Append("、");
					}
				}
			}
			stringBuilder.Append("</color>");
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018CDA RID: 101594 RVA: 0x007BFFA4 File Offset: 0x007BE3A4
		public string GetCondition(EnchantmentsCardData data)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("<color={0}>", TR.Value("enchant_condition_color"));
			for (int i = 0; i < data.magicItem.Parts.Count; i++)
			{
				string enumDescription = Utility.GetEnumDescription<EEquipWearSlotType>((EEquipWearSlotType)data.magicItem.Parts[i]);
				stringBuilder.Append(TR.Value(enumDescription));
				if (i != data.magicItem.Parts.Count - 1)
				{
					stringBuilder.Append("、");
				}
			}
			stringBuilder.Append("</color>");
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018CDB RID: 101595 RVA: 0x007C005C File Offset: 0x007BE45C
		public string GetDefaultDescribe(EnchantmentsCardData data)
		{
			string condition = this.GetCondition(data);
			string enchantmentCardAttributesDesc = this.GetEnchantmentCardAttributesDesc(data.magicItem.ID, data.itemData.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
			string text = condition;
			if (!string.IsNullOrEmpty(enchantmentCardAttributesDesc) && !string.IsNullOrEmpty(text))
			{
				return text + "\n" + enchantmentCardAttributesDesc;
			}
			if (!string.IsNullOrEmpty(enchantmentCardAttributesDesc))
			{
				return enchantmentCardAttributesDesc;
			}
			return text;
		}

		// Token: 0x06018CDC RID: 101596 RVA: 0x007C00CC File Offset: 0x007BE4CC
		public void SendAddMagic(ulong cardid, ulong itemid)
		{
			SceneAddMagicReq sceneAddMagicReq = new SceneAddMagicReq();
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(cardid);
			ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemid);
			if (item != null && item2 != null)
			{
				sceneAddMagicReq.cardUid = item.GUID;
				sceneAddMagicReq.itemUid = item2.GUID;
				NetManager.Instance().SendCommand<SceneAddMagicReq>(ServerType.GATE_SERVER, sceneAddMagicReq);
			}
		}

		// Token: 0x06018CDD RID: 101597 RVA: 0x007C0128 File Offset: 0x007BE528
		public void SendMergeCard(ulong leftcardid, ulong rightcardid)
		{
			SceneMagicCardCompReq sceneMagicCardCompReq = new SceneMagicCardCompReq();
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(leftcardid);
			ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(rightcardid);
			if (item != null && item2 != null)
			{
				sceneMagicCardCompReq.cardA = item.GUID;
				sceneMagicCardCompReq.cardB = item2.GUID;
				NetManager.Instance().SendCommand<SceneMagicCardCompReq>(ServerType.GATE_SERVER, sceneMagicCardCompReq);
			}
		}

		// Token: 0x06018CDE RID: 101598 RVA: 0x007C0184 File Offset: 0x007BE584
		private void OnRecvSceneMagicCardCompRet(MsgDATA msgData)
		{
			SceneMagicCardCompRet sceneMagicCardCompRet = new SceneMagicCardCompRet();
			sceneMagicCardCompRet.decode(msgData.bytes);
			if (sceneMagicCardCompRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneMagicCardCompRet.code, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMergeSuccess, null, null, null, null);
				EnchantResultFrame.EnchantResultFrameData enchantResultFrameData = new EnchantResultFrame.EnchantResultFrameData();
				enchantResultFrameData.bMerge = true;
				enchantResultFrameData.iCardTableID = (int)sceneMagicCardCompRet.cardId;
				enchantResultFrameData.iCardLevel = (int)sceneMagicCardCompRet.cardLev;
				enchantResultFrameData.itemData = ItemDataManager.CreateItemDataFromTable((int)sceneMagicCardCompRet.cardId, 100, 0);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<EnchantResultFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<EnchantResultFrame>(null, false);
				}
				ClientFrame.OpenTargetFrame<EnchantResultFrame>(FrameLayer.Middle, enchantResultFrameData);
			}
		}

		// Token: 0x06018CDF RID: 101599 RVA: 0x007C0234 File Offset: 0x007BE634
		private void OnRecvSceneAddMagicRet(MsgDATA msgData)
		{
			SceneAddMagicRet sceneAddMagicRet = new SceneAddMagicRet();
			sceneAddMagicRet.decode(msgData.bytes);
			if (sceneAddMagicRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneAddMagicRet.code, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAddMagicSuccess, null, null, null, null);
				EnchantResultFrame.EnchantResultFrameData enchantResultFrameData = new EnchantResultFrame.EnchantResultFrameData();
				enchantResultFrameData.bMerge = false;
				enchantResultFrameData.iCardTableID = (int)sceneAddMagicRet.cardId;
				enchantResultFrameData.iCardLevel = (int)sceneAddMagicRet.cardLev;
				enchantResultFrameData.itemData = DataManager<ItemDataManager>.GetInstance().GetItem(sceneAddMagicRet.itemUid);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<EnchantResultFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<EnchantResultFrame>(null, false);
				}
				ClientFrame.OpenTargetFrame<EnchantResultFrame>(FrameLayer.Middle, enchantResultFrameData);
			}
		}

		// Token: 0x06018CE0 RID: 101600 RVA: 0x007C02E8 File Offset: 0x007BE6E8
		private void InitMagicCardProbabilityTable()
		{
			this.mEnchantmentCardProbabilityDataList.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<MagicCardProbabilityTable>())
			{
				MagicCardProbabilityTable magicCardProbabilityTable = keyValuePair.Value as MagicCardProbabilityTable;
				if (magicCardProbabilityTable != null)
				{
					EnchantmentCardProbabilityData enchantmentCardProbabilityData = new EnchantmentCardProbabilityData();
					enchantmentCardProbabilityData.iMinProbability = magicCardProbabilityTable.MinProbability;
					enchantmentCardProbabilityData.iMaxProbability = magicCardProbabilityTable.MaxProbability;
					enchantmentCardProbabilityData.sSuccessRateDesc = magicCardProbabilityTable.SuccessName;
					this.mEnchantmentCardProbabilityDataList.Add(enchantmentCardProbabilityData);
				}
			}
		}

		// Token: 0x06018CE1 RID: 101601 RVA: 0x007C0378 File Offset: 0x007BE778
		public string GetEnchantmentCardProbabilityDesc(int currentRate)
		{
			string empty = string.Empty;
			for (int i = 0; i < this.mEnchantmentCardProbabilityDataList.Count; i++)
			{
				EnchantmentCardProbabilityData enchantmentCardProbabilityData = this.mEnchantmentCardProbabilityDataList[i];
				if (enchantmentCardProbabilityData.iMinProbability < currentRate && currentRate <= enchantmentCardProbabilityData.iMaxProbability)
				{
					return enchantmentCardProbabilityData.sSuccessRateDesc;
				}
			}
			return empty;
		}

		// Token: 0x06018CE2 RID: 101602 RVA: 0x007C03D4 File Offset: 0x007BE7D4
		public List<EnchantmentCardItemDataModel> LoadEnchantmentCardItems()
		{
			List<EnchantmentCardItemDataModel> list = new List<EnchantmentCardItemDataModel>();
			List<EnchantmentCardItemDataModel> collection = this.AddEnchantmentCardItems(EPackageType.Equip);
			List<EnchantmentCardItemDataModel> collection2 = this.AddEnchantmentCardItems(EPackageType.WearEquip);
			List<EnchantmentCardItemDataModel> list2 = this.AddEnchantmentCardItems(EPackageType.Consumable);
			list.AddRange(collection);
			list.AddRange(collection2);
			list.Sort(new Comparison<EnchantmentCardItemDataModel>(this.SortEnchantmentCardItems));
			list2.Sort(new Comparison<EnchantmentCardItemDataModel>(this.SortEnchantmentCardItems));
			list.AddRange(list2);
			return list;
		}

		// Token: 0x06018CE3 RID: 101603 RVA: 0x007C043C File Offset: 0x007BE83C
		public List<EnchantmentCardItemDataModel> AddEnchantmentCardItems(EPackageType ePackageType)
		{
			List<EnchantmentCardItemDataModel> list = new List<EnchantmentCardItemDataModel>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(ePackageType);
			if (ePackageType == EPackageType.Equip || ePackageType == EPackageType.WearEquip)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null)
					{
						if (item.mPrecEnchantmentCard != null)
						{
							if (item.mPrecEnchantmentCard.iEnchantmentCardID != 0)
							{
								if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.mPrecEnchantmentCard.iEnchantmentCardID, string.Empty, string.Empty) != null)
								{
									MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(item.mPrecEnchantmentCard.iEnchantmentCardID, string.Empty, string.Empty);
									if (tableItem != null)
									{
										if (tableItem.MaxLevel > 0)
										{
											EnchantmentCardItemDataModel enchantmentCardItemDataModel = new EnchantmentCardItemDataModel();
											enchantmentCardItemDataModel.mUpgradePrecType = UpgradePrecType.Mounted;
											enchantmentCardItemDataModel.mEquipItemData = item;
											enchantmentCardItemDataModel.mEnchantmentCardItemData = ItemDataManager.CreateItemDataFromTable(item.mPrecEnchantmentCard.iEnchantmentCardID, 100, 0);
											enchantmentCardItemDataModel.mEnchantmentCardItemData.mPrecEnchantmentCard = item.mPrecEnchantmentCard;
											enchantmentCardItemDataModel.mConsumableMaterialData = this.GetConsumableMaterialData(enchantmentCardItemDataModel.mEnchantmentCardItemData);
											list.Add(enchantmentCardItemDataModel);
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < itemsByPackageType.Count; j++)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
					if (item2 != null)
					{
						if (item2.SubType == 25)
						{
							if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item2.TableID, string.Empty, string.Empty) != null)
							{
								MagicCardTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(item2.TableID, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									if (tableItem2.MaxLevel > 0)
									{
										EnchantmentCardItemDataModel enchantmentCardItemDataModel2 = new EnchantmentCardItemDataModel();
										enchantmentCardItemDataModel2.mUpgradePrecType = UpgradePrecType.UnMounted;
										enchantmentCardItemDataModel2.mEquipItemData = null;
										enchantmentCardItemDataModel2.mEnchantmentCardItemData = item2;
										enchantmentCardItemDataModel2.mEnchantmentCardItemData.mPrecEnchantmentCard.iEnchantmentCardID = item2.TableID;
										enchantmentCardItemDataModel2.mEnchantmentCardCount = item2.Count;
										enchantmentCardItemDataModel2.mConsumableMaterialData = this.GetConsumableMaterialData(enchantmentCardItemDataModel2.mEnchantmentCardItemData);
										list.Add(enchantmentCardItemDataModel2);
									}
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06018CE4 RID: 101604 RVA: 0x007C06A8 File Offset: 0x007BEAA8
		private ItemSimpleData GetConsumableMaterialData(ItemData itemData)
		{
			MagicCardUpdateTable magicCardUpdateTable = this.GetMagicCardUpdateTable(itemData);
			if (magicCardUpdateTable == null)
			{
				return null;
			}
			int itemID = 0;
			int count = 0;
			string[] array = magicCardUpdateTable.UpConsume.Split(new char[]
			{
				'_'
			});
			if (array.Length >= 2)
			{
				int.TryParse(array[0], out itemID);
				int.TryParse(array[1], out count);
			}
			return new ItemSimpleData
			{
				ItemID = itemID,
				Count = count
			};
		}

		// Token: 0x06018CE5 RID: 101605 RVA: 0x007C0718 File Offset: 0x007BEB18
		private List<EnchatmentCardViceCardStageData> GetViceCardStageDataList(IList<string> stageList)
		{
			List<EnchatmentCardViceCardStageData> list = new List<EnchatmentCardViceCardStageData>();
			for (int i = 0; i < stageList.Count; i++)
			{
				int iQuality = 0;
				int iStage = 0;
				int iNumber = 0;
				string[] array = stageList[i].Split(new char[]
				{
					'_'
				});
				if (array.Length >= 3)
				{
					int.TryParse(array[0], out iQuality);
					int.TryParse(array[1], out iStage);
					int.TryParse(array[2], out iNumber);
					list.Add(new EnchatmentCardViceCardStageData
					{
						iQuality = iQuality,
						iStage = iStage,
						iNumber = iNumber
					});
				}
			}
			return list;
		}

		// Token: 0x06018CE6 RID: 101606 RVA: 0x007C07BC File Offset: 0x007BEBBC
		private Dictionary<int, int> GetEnchantmentCardLevelCorrespondingSuccessRateDict(IList<string> levelSuccessRateList)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			for (int i = 0; i < levelSuccessRateList.Count; i++)
			{
				int key = 0;
				int value = 0;
				string[] array = levelSuccessRateList[i].Split(new char[]
				{
					'_'
				});
				if (array.Length >= 2)
				{
					int.TryParse(array[0], out key);
					int.TryParse(array[1], out value);
					dictionary.Add(key, value);
				}
			}
			return dictionary;
		}

		// Token: 0x06018CE7 RID: 101607 RVA: 0x007C0830 File Offset: 0x007BEC30
		public MagicCardUpdateTable GetMagicCardUpdateTable(ItemData MainCardItemData)
		{
			MagicCardUpdateTable result = null;
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<MagicCardUpdateTable>())
			{
				MagicCardUpdateTable magicCardUpdateTable = keyValuePair.Value as MagicCardUpdateTable;
				if (magicCardUpdateTable != null)
				{
					if (magicCardUpdateTable.MagicCardID == MainCardItemData.mPrecEnchantmentCard.iEnchantmentCardID)
					{
						if (MainCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel >= magicCardUpdateTable.MinLevel)
						{
							if (MainCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel <= magicCardUpdateTable.MaxLevel)
							{
								result = magicCardUpdateTable;
								break;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06018CE8 RID: 101608 RVA: 0x007C08DC File Offset: 0x007BECDC
		public List<EnchantmentCardViceCardData> GetEnchantmentCardViceCardDatas(ItemData MainCardItemData, UpgradePrecType precType)
		{
			List<EnchatmentCardViceCardStageData> list = new List<EnchatmentCardViceCardStageData>();
			List<EnchatmentCardViceCardStageData> list2 = new List<EnchatmentCardViceCardStageData>();
			List<EnchatmentCardViceCardStageData> list3 = new List<EnchatmentCardViceCardStageData>();
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			List<EnchantmentCardViceCardData> list4 = new List<EnchantmentCardViceCardData>();
			MagicCardUpdateTable magicCardUpdateTable = this.GetMagicCardUpdateTable(MainCardItemData);
			if (magicCardUpdateTable != null)
			{
				dictionary = this.GetEnchantmentCardLevelCorrespondingSuccessRateDict(magicCardUpdateTable.SameCardID);
				list = this.GetViceCardStageDataList(magicCardUpdateTable.UpgradeMaterials_1);
				list2 = this.GetViceCardStageDataList(magicCardUpdateTable.UpgradeMaterials_2);
				list3 = this.GetViceCardStageDataList(magicCardUpdateTable.UpgradeMaterials_3);
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (item.SubType == 25)
					{
						bool flag = false;
						bool flag2 = false;
						int num = 0;
						if (dictionary.TryGetValue(item.TableID, out num))
						{
							flag2 = true;
						}
						if (!flag2 || item.mPrecEnchantmentCard.iEnchantmentCardLevel <= MainCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel)
						{
							MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(item.TableID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								int num2 = 0;
								for (int j = 0; j < list.Count; j++)
								{
									EnchatmentCardViceCardStageData enchatmentCardViceCardStageData = list[j];
									if (enchatmentCardViceCardStageData.iQuality == tableItem.Color)
									{
										if (enchatmentCardViceCardStageData.iStage == tableItem.Stage)
										{
											num2 = enchatmentCardViceCardStageData.iNumber;
											flag = true;
										}
									}
								}
								for (int k = 0; k < list2.Count; k++)
								{
									EnchatmentCardViceCardStageData enchatmentCardViceCardStageData2 = list2[k];
									if (enchatmentCardViceCardStageData2.iQuality == tableItem.Color)
									{
										if (enchatmentCardViceCardStageData2.iStage == tableItem.Stage)
										{
											num2 = enchatmentCardViceCardStageData2.iNumber;
											flag = true;
										}
									}
								}
								for (int l = 0; l < list3.Count; l++)
								{
									EnchatmentCardViceCardStageData enchatmentCardViceCardStageData3 = list3[l];
									if (enchatmentCardViceCardStageData3.iQuality == tableItem.Color)
									{
										if (enchatmentCardViceCardStageData3.iStage == tableItem.Stage)
										{
											num2 = enchatmentCardViceCardStageData3.iNumber;
											flag = true;
										}
									}
								}
								if (flag || flag2)
								{
									EnchantmentCardViceCardData enchantmentCardViceCardData = new EnchantmentCardViceCardData();
									enchantmentCardViceCardData.mViceCardItemData = item;
									enchantmentCardViceCardData.mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardID = item.TableID;
									enchantmentCardViceCardData.mAllSuccessRate = this.GetAllSuccessRate(MainCardItemData, item);
									enchantmentCardViceCardData.mConsumViceCardCount = ((!flag2) ? num2 : num);
									if (precType == UpgradePrecType.Mounted)
									{
										enchantmentCardViceCardData.mViceCardCount = item.Count;
									}
									else if (MainCardItemData.GUID == item.GUID)
									{
										enchantmentCardViceCardData.mViceCardCount = item.Count - 1;
									}
									else
									{
										enchantmentCardViceCardData.mViceCardCount = item.Count;
									}
									if (enchantmentCardViceCardData.mViceCardCount > 0)
									{
										list4.Add(enchantmentCardViceCardData);
									}
								}
							}
						}
					}
				}
			}
			return list4;
		}

		// Token: 0x06018CE9 RID: 101609 RVA: 0x007C0C14 File Offset: 0x007BF014
		private int GetAllSuccessRate(ItemData MainCardItemData, ItemData ViceCardItemDate)
		{
			if (MainCardItemData == null || ViceCardItemDate == null)
			{
				return 0;
			}
			List<EnchatmentCardViceCardStageData> stageDataList = new List<EnchatmentCardViceCardStageData>();
			List<EnchatmentCardViceCardStageData> stageDataList2 = new List<EnchatmentCardViceCardStageData>();
			List<EnchatmentCardViceCardStageData> stageDataList3 = new List<EnchatmentCardViceCardStageData>();
			List<int> list = new List<int>();
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
			Dictionary<int, int> stageRateDict = new Dictionary<int, int>();
			Dictionary<int, int> stageRateDict2 = new Dictionary<int, int>();
			Dictionary<int, int> stageRateDict3 = new Dictionary<int, int>();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			MagicCardUpdateTable magicCardUpdateTable = this.GetMagicCardUpdateTable(MainCardItemData);
			if (magicCardUpdateTable == null)
			{
				return 0;
			}
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(ViceCardItemDate.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			stageDataList = this.GetViceCardStageDataList(magicCardUpdateTable.UpgradeMaterials_1);
			stageDataList2 = this.GetViceCardStageDataList(magicCardUpdateTable.UpgradeMaterials_2);
			stageDataList3 = this.GetViceCardStageDataList(magicCardUpdateTable.UpgradeMaterials_3);
			for (int i = 0; i < magicCardUpdateTable.SameCardID.Length; i++)
			{
				int item = 0;
				string[] array = magicCardUpdateTable.SameCardID[i].Split(new char[]
				{
					'_'
				});
				if (array.Length >= 2)
				{
					int.TryParse(array[0], out item);
					list.Add(item);
				}
			}
			dictionary = this.GetEnchantmentCardLevelCorrespondingSuccessRateDict(magicCardUpdateTable.SameCardAddRate);
			dictionary2 = this.GetEnchantmentCardLevelCorrespondingSuccessRateDict(magicCardUpdateTable.LevelAddRate);
			stageRateDict = this.GetEnchantmentCardLevelCorrespondingSuccessRateDict(magicCardUpdateTable.BaseRate_1);
			stageRateDict2 = this.GetEnchantmentCardLevelCorrespondingSuccessRateDict(magicCardUpdateTable.BaseRate_2);
			stageRateDict3 = this.GetEnchantmentCardLevelCorrespondingSuccessRateDict(magicCardUpdateTable.BaseRate_3);
			bool flag = false;
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j] == ViceCardItemDate.TableID)
				{
					flag = true;
				}
			}
			if (flag)
			{
				if (dictionary.TryGetValue(MainCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel, out num2))
				{
					num += num2;
				}
			}
			else
			{
				num += this.GetStageSuccessRate(stageDataList, stageRateDict, tableItem, MainCardItemData);
				num += this.GetStageSuccessRate(stageDataList2, stageRateDict2, tableItem, MainCardItemData);
				num += this.GetStageSuccessRate(stageDataList3, stageRateDict3, tableItem, MainCardItemData);
			}
			if (dictionary2.TryGetValue(ViceCardItemDate.mPrecEnchantmentCard.iEnchantmentCardLevel, out num3))
			{
				num += num3;
			}
			return num;
		}

		// Token: 0x06018CEA RID: 101610 RVA: 0x007C0E3C File Offset: 0x007BF23C
		private int GetStageSuccessRate(List<EnchatmentCardViceCardStageData> stageDataList, Dictionary<int, int> stageRateDict, MagicCardTable viceCardMagicCardTable, ItemData mainCardItemData)
		{
			if (stageDataList == null || stageRateDict == null || viceCardMagicCardTable == null || mainCardItemData == null)
			{
				return 0;
			}
			int result = 0;
			for (int i = 0; i < stageDataList.Count; i++)
			{
				EnchatmentCardViceCardStageData enchatmentCardViceCardStageData = stageDataList[i];
				if (enchatmentCardViceCardStageData.iQuality == viceCardMagicCardTable.Color)
				{
					if (enchatmentCardViceCardStageData.iStage == viceCardMagicCardTable.Stage)
					{
						if (stageRateDict.TryGetValue(mainCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel, out result))
						{
						}
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06018CEB RID: 101611 RVA: 0x007C0ED0 File Offset: 0x007BF2D0
		private int SortEnchantmentCardItems(EnchantmentCardItemDataModel left, EnchantmentCardItemDataModel right)
		{
			if (left.mEnchantmentCardItemData.Quality != right.mEnchantmentCardItemData.Quality)
			{
				return right.mEnchantmentCardItemData.Quality - left.mEnchantmentCardItemData.Quality;
			}
			return right.mEnchantmentCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel - left.mEnchantmentCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel;
		}

		// Token: 0x06018CEC RID: 101612 RVA: 0x007C0F34 File Offset: 0x007BF334
		public bool CheckEnchantmentCardLevelIsFull(EnchantmentCardItemDataModel currentEnchantmentCardData)
		{
			bool result = false;
			if (currentEnchantmentCardData == null)
			{
				result = false;
			}
			int id;
			if (currentEnchantmentCardData.mUpgradePrecType == UpgradePrecType.Mounted)
			{
				id = currentEnchantmentCardData.mEnchantmentCardItemData.mPrecEnchantmentCard.iEnchantmentCardID;
			}
			else
			{
				id = currentEnchantmentCardData.mEnchantmentCardItemData.TableID;
			}
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				result = false;
			}
			if (currentEnchantmentCardData.mEnchantmentCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel >= tableItem.MaxLevel)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06018CED RID: 101613 RVA: 0x007C0FB8 File Offset: 0x007BF3B8
		public string GetEnchantmentCardAttributesDesc(int enchantmentCardID, int enchantmentCardLevel, bool isShowCeil = false)
		{
			string result = string.Empty;
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(enchantmentCardID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return result;
			}
			bool flag = false;
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			if (tableItem.PropType.Count == tableItem.PropValue.Count)
			{
				if (tableItem.PropType.Count > 0)
				{
					stringBuilder.AppendFormat("<color={0}>", TR.Value("enchant_attribute_color"));
				}
				FlatBufferArray<int> propValue = tableItem.PropValue;
				FlatBufferArray<int> upValue = tableItem.UpValue;
				for (int i = 0; i < tableItem.PropType.Count; i++)
				{
					if (propValue[i] != 0)
					{
						EServerProp enumValue = (EServerProp)tableItem.PropType[i];
						MapEnum mapEnum = Utility.GetEnumAttribute<EServerProp, MapEnum>(enumValue);
						if (mapEnum == null && tableItem.PropType[i] >= 18 && tableItem.PropType[i] <= 21)
						{
							mapEnum = new MapEnum((EEquipProp)(tableItem.PropType[i] - 18));
						}
						if (mapEnum == null && tableItem.PropType[i] >= 22 && tableItem.PropType[i] <= 25)
						{
							mapEnum = new MapEnum(EEquipProp.Elements);
						}
						if (mapEnum != null)
						{
							EEquipProp prop = mapEnum.Prop;
							int attrValue = propValue[i] + upValue[i] * enchantmentCardLevel;
							string eequipProDesc = Utility.GetEEquipProDesc(prop, attrValue, string.Empty);
							if (flag)
							{
								stringBuilder.Append("\n");
							}
							stringBuilder.Append(eequipProDesc);
							if (isShowCeil && tableItem.MaxLevel > 0 && enchantmentCardLevel < tableItem.MaxLevel)
							{
								int attrValue2 = propValue[i] + upValue[i] * tableItem.MaxLevel;
								string equipProCeilValueDesc = Utility.GetEquipProCeilValueDesc(prop, attrValue2);
								stringBuilder.AppendFormat("<color={0}>(上限：{1})</color>", TR.Value("Bead_White_color"), equipProCeilValueDesc);
							}
							flag = true;
						}
					}
				}
				if (tableItem.PropType.Count > 0)
				{
					stringBuilder.Append("</color>");
				}
			}
			if (!string.IsNullOrEmpty(tableItem.SkillAttributes))
			{
				if (flag)
				{
					stringBuilder.Append("\n");
				}
				stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_skills_color"), tableItem.SkillAttributes);
				flag = true;
			}
			if (enchantmentCardLevel > 0)
			{
				BuffInfoTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(tableItem.UpBuffID[enchantmentCardLevel - 1], string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.Description.Count > 0)
				{
					if (flag)
					{
						stringBuilder.Append("\n");
					}
					stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_skills_color"), tableItem2.Description[0]);
				}
			}
			else
			{
				for (int j = 0; j < tableItem.BuffID.Count; j++)
				{
					BuffInfoTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(tableItem.BuffID[j], string.Empty, string.Empty);
					if (tableItem3 != null && tableItem3.Description.Count > 0)
					{
						if (flag)
						{
							stringBuilder.Append("\n");
						}
						stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_skills_color"), tableItem3.Description[0]);
						flag = true;
					}
				}
			}
			result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018CEE RID: 101614 RVA: 0x007C1344 File Offset: 0x007BF744
		public void OnSceneMagicCardUpgradeReq(EnchantmentCardItemDataModel enchantmentCardItem, EnchantmentCardViceCardData viceCardItem)
		{
			if (enchantmentCardItem == null || viceCardItem == null)
			{
				return;
			}
			if (enchantmentCardItem.mUpgradePrecType == UpgradePrecType.Mounted && enchantmentCardItem.mEquipItemData == null)
			{
				Logger.LogErrorFormat("EnchantmentsCardManager [OnSceneMagicCardUpgradeReq] enchantmentCardItem.mEquipItemData = null", new object[0]);
				return;
			}
			if (enchantmentCardItem.mEnchantmentCardItemData == null)
			{
				Logger.LogErrorFormat("EnchantmentsCardManager [OnSceneMagicCardUpgradeReq] enchantmentCardItem.mEnchantmentCardItemData = null", new object[0]);
				return;
			}
			if (viceCardItem.mViceCardItemData == null)
			{
				Logger.LogErrorFormat("EnchantmentsCardManager [OnSceneMagicCardUpgradeReq] viceCardItem.mViceCardItemData = null", new object[0]);
				return;
			}
			SceneMagicCardUpgradeReq sceneMagicCardUpgradeReq = new SceneMagicCardUpgradeReq();
			if (enchantmentCardItem.mUpgradePrecType == UpgradePrecType.Mounted)
			{
				sceneMagicCardUpgradeReq.equipUid = enchantmentCardItem.mEquipItemData.GUID;
				sceneMagicCardUpgradeReq.cardId = (uint)enchantmentCardItem.mEnchantmentCardItemData.TableID;
			}
			else
			{
				sceneMagicCardUpgradeReq.upgradeUid = enchantmentCardItem.mEnchantmentCardItemData.GUID;
			}
			sceneMagicCardUpgradeReq.materialUid = viceCardItem.mViceCardItemData.GUID;
			MonoSingleton<NetManager>.instance.SendCommand<SceneMagicCardUpgradeReq>(ServerType.GATE_SERVER, sceneMagicCardUpgradeReq);
		}

		// Token: 0x06018CEF RID: 101615 RVA: 0x007C1428 File Offset: 0x007BF828
		private void OnSceneMagicCardUpgradeRes(MsgDATA msg)
		{
			SceneMagicCardUpgradeRes sceneMagicCardUpgradeRes = new SceneMagicCardUpgradeRes();
			sceneMagicCardUpgradeRes.decode(msg.bytes);
			EnchantmentCardUpgradeSuccessData enchantmentCardUpgradeSuccessData = null;
			if (sceneMagicCardUpgradeRes.code != 0U)
			{
				if (sceneMagicCardUpgradeRes.code == 1000111U)
				{
					enchantmentCardUpgradeSuccessData = new EnchantmentCardUpgradeSuccessData();
					enchantmentCardUpgradeSuccessData.isSuccess = false;
					enchantmentCardUpgradeSuccessData.mEnchantmentCardID = (int)sceneMagicCardUpgradeRes.cardTypeId;
					enchantmentCardUpgradeSuccessData.mEnchantmentCardLevel = (int)sceneMagicCardUpgradeRes.cardLev;
					this.OpenEquipUpgradeResutFrame(enchantmentCardUpgradeSuccessData);
				}
				else
				{
					SystemNotifyManager.SystemNotify((int)sceneMagicCardUpgradeRes.code, string.Empty);
				}
			}
			else
			{
				enchantmentCardUpgradeSuccessData = new EnchantmentCardUpgradeSuccessData();
				enchantmentCardUpgradeSuccessData.isSuccess = true;
				enchantmentCardUpgradeSuccessData.mEnchantmentCardID = (int)sceneMagicCardUpgradeRes.cardTypeId;
				enchantmentCardUpgradeSuccessData.mEnchantmentCardLevel = (int)sceneMagicCardUpgradeRes.cardLev;
				enchantmentCardUpgradeSuccessData.mEnchantmentCardGUID = sceneMagicCardUpgradeRes.cardGuid;
				enchantmentCardUpgradeSuccessData.mEquipGUID = sceneMagicCardUpgradeRes.equipUid;
				this.OpenEquipUpgradeResutFrame(enchantmentCardUpgradeSuccessData);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnEnchantmentCardUpgradeRetun, enchantmentCardUpgradeSuccessData, null, null, null);
		}

		// Token: 0x06018CF0 RID: 101616 RVA: 0x007C1501 File Offset: 0x007BF901
		private void OpenEquipUpgradeResutFrame(EnchantmentCardUpgradeSuccessData mData)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<EquipUpgradeResultFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<EquipUpgradeResultFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipUpgradeResultFrame>(FrameLayer.Middle, mData, string.Empty);
		}

		// Token: 0x06018CF1 RID: 101617 RVA: 0x007C1534 File Offset: 0x007BF934
		public bool CheckEnchantmentCardIsUpgrade(ItemData item)
		{
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(item.TableID, string.Empty, string.Empty);
			return tableItem != null && tableItem.MaxLevel > 0 && item.mPrecEnchantmentCard.iEnchantmentCardLevel < tableItem.MaxLevel;
		}

		// Token: 0x06018CF2 RID: 101618 RVA: 0x007C1588 File Offset: 0x007BF988
		public bool CheckMainEnchantmentCardIsOnlyUseSameCard(ItemData mainCard)
		{
			MagicCardUpdateTable magicCardUpdateTable = this.GetMagicCardUpdateTable(mainCard);
			return magicCardUpdateTable != null && magicCardUpdateTable.UpgradeMaterials_1.Length <= 0 && magicCardUpdateTable.UpgradeMaterials_2.Length <= 0 && magicCardUpdateTable.UpgradeMaterials_3.Length <= 0 && magicCardUpdateTable.SameCardID.Length > 0;
		}

		// Token: 0x04011DFA RID: 73210
		private List<EnchantmentCardProbabilityData> mEnchantmentCardProbabilityDataList = new List<EnchantmentCardProbabilityData>();

		// Token: 0x04011DFB RID: 73211
		public bool IsNotShowGoldCoinTip;

		// Token: 0x04011DFC RID: 73212
		public bool IsShowBindTip;

		// Token: 0x04011DFD RID: 73213
		public bool IsShowQualityTip;

		// Token: 0x04011DFE RID: 73214
		public bool IsShowLevelTip;

		// Token: 0x04011DFF RID: 73215
		public EnchantmentsCardManager.OnUpdateCard onUpdateCard;

		// Token: 0x04011E00 RID: 73216
		public EnchantmentsCardManager.OnTabMarkChanged onTabMarkChanged;

		// Token: 0x04011E01 RID: 73217
		private Dictionary<ulong, EnchantmentsCardData> m_akEnchantmentsCardDataDic = new Dictionary<ulong, EnchantmentsCardData>();

		// Token: 0x04011E02 RID: 73218
		private Dictionary<EnchantmentsType, List<EnchantmentsCardData>> m_akQuality2CardDic = new Dictionary<EnchantmentsType, List<EnchantmentsCardData>>();

		// Token: 0x04011E03 RID: 73219
		private Dictionary<ulong, List<EnchantmentsCardData>> m_akTableID2CardDic = new Dictionary<ulong, List<EnchantmentsCardData>>();

		// Token: 0x04011E04 RID: 73220
		private Dictionary<ulong, EnchantmentsCardData> m_akTableGroup = new Dictionary<ulong, EnchantmentsCardData>();

		// Token: 0x02004576 RID: 17782
		// (Invoke) Token: 0x06018CF4 RID: 101620
		public delegate void OnUpdateCard(EnchantmentsCardData data);

		// Token: 0x02004577 RID: 17783
		// (Invoke) Token: 0x06018CF8 RID: 101624
		public delegate void OnTabMarkChanged(ulong guid);
	}
}
