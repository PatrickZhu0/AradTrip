using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001956 RID: 6486
	public class PayManager : Singleton<PayManager>
	{
		// Token: 0x0600FC10 RID: 64528 RVA: 0x00452D77 File Offset: 0x00451177
		public override void Init()
		{
			this.InitPayReturnDisplayTable();
		}

		// Token: 0x0600FC11 RID: 64529 RVA: 0x00452D7F File Offset: 0x0045117F
		public override void UnInit()
		{
			this.ClearPayReturnDisplayTable();
			this.ClearCurrVipPrivilegeDescList();
		}

		// Token: 0x0600FC12 RID: 64530 RVA: 0x00452D8D File Offset: 0x0045118D
		public string GetFirstWeaponPath()
		{
			return this.weaponPath;
		}

		// Token: 0x0600FC13 RID: 64531 RVA: 0x00452D95 File Offset: 0x00451195
		public int GetFirstWeaponStrengthLevel()
		{
			return this.weaponStrengthLevel;
		}

		// Token: 0x0600FC14 RID: 64532 RVA: 0x00452DA0 File Offset: 0x004511A0
		public int GetCurrentRolePayMoney()
		{
			int result = 0;
			List<ActiveManager.ActivityData> consumeItems = this.GetConsumeItems(true);
			if (consumeItems == null)
			{
				return result;
			}
			if (consumeItems.Count <= 0)
			{
				return result;
			}
			ActiveManager.ActivityData activityData = consumeItems[consumeItems.Count - 1];
			if (activityData == null)
			{
				return result;
			}
			List<TaskPair> akActivityValues = activityData.akActivityValues;
			if (akActivityValues == null || akActivityValues.Count <= 0 || int.TryParse(akActivityValues[0].value, out result))
			{
			}
			return result;
		}

		// Token: 0x0600FC15 RID: 64533 RVA: 0x00452E18 File Offset: 0x00451218
		public bool HasFirstPayFinish()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(8300);
			return activeData != null && activeData.akChildItems[0].status > 2;
		}

		// Token: 0x0600FC16 RID: 64534 RVA: 0x00452E54 File Offset: 0x00451254
		public bool HasFirstPay()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(8300);
			return activeData == null || activeData.akChildItems[0].status < 4;
		}

		// Token: 0x0600FC17 RID: 64535 RVA: 0x00452E90 File Offset: 0x00451290
		public bool HasSecondPay()
		{
			List<ActiveManager.ActivityData> consumeItems = Singleton<PayManager>.GetInstance().GetConsumeItems(false);
			if (consumeItems == null)
			{
				Logger.LogErrorFormat("Item is null", new object[0]);
				return false;
			}
			if (consumeItems.Count <= 0)
			{
				Logger.LogError("items count is zero");
				return false;
			}
			return consumeItems[4].status < 4;
		}

		// Token: 0x0600FC18 RID: 64536 RVA: 0x00452EE8 File Offset: 0x004512E8
		public bool HasConsumePay()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(8400);
			if (activeData != null)
			{
				for (int i = 0; i < activeData.akChildItems.Count; i++)
				{
					if (activeData.akChildItems[i].status < 4)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600FC19 RID: 64537 RVA: 0x00452F44 File Offset: 0x00451344
		public bool HasBoughtMonthCard()
		{
			bool result = false;
			ActiveManager.ActivityData childActiveData = DataManager<ActiveManager>.GetInstance().GetChildActiveData(2500);
			if (childActiveData != null && childActiveData.status != 1 && childActiveData.status != 0)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600FC1A RID: 64538 RVA: 0x00452F84 File Offset: 0x00451384
		public bool HasMonthCardEnabled()
		{
			bool result = false;
			ActiveManager.ActivityData childActiveData = DataManager<ActiveManager>.GetInstance().GetChildActiveData(2500);
			if (childActiveData != null && childActiveData.status != 1 && childActiveData.status != 0)
			{
				int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(2500, "rd", 0);
				if (activeItemValue > 0 || DataManager<PlayerBaseData>.GetInstance().MonthCardLv > DataManager<TimeManager>.GetInstance().GetServerTime())
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600FC1B RID: 64539 RVA: 0x00452FFC File Offset: 0x004513FC
		private void GetExclusiveItems()
		{
			this.exclusiveItems.Clear();
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.PayItems.Count >= 1 && tableItem.PayItems[0].Length > 1)
				{
					for (int i = 0; i < tableItem.PayItems.Count; i++)
					{
						string[] array = tableItem.PayItems[i].Split(new char[]
						{
							'-'
						});
						if (array.Length == 2)
						{
							int key = 0;
							try
							{
								key = Convert.ToInt32(array[0], 10);
							}
							catch (Exception ex)
							{
								Logger.LogErrorFormat("err:{0}", new object[]
								{
									ex
								});
							}
							Dictionary<uint, int> dictionary = new Dictionary<uint, int>();
							string[] array2 = array[1].Split(new char[]
							{
								','
							});
							for (int j = 0; j < array2.Length; j++)
							{
								string[] array3 = array2[j].Split(new char[]
								{
									'_'
								});
								uint key2 = Convert.ToUInt32(array3[0], 10);
								int value = Convert.ToInt32(array3[1], 10);
								dictionary.Add(key2, value);
							}
							this.exclusiveItems.Add(key, dictionary);
						}
					}
				}
				if (tableItem.FirstPayWeapon.Length > 1)
				{
					string[] array4 = tableItem.FirstPayWeapon.Split(new char[]
					{
						'_'
					});
					uint itemID = Convert.ToUInt32(array4[0], 10);
					this.weaponStrengthLevel = Convert.ToInt32(array4[1], 10);
					this.weaponPath = Utility.GetItemModulePath((int)itemID);
					this.weaponItemID = itemID;
				}
			}
		}

		// Token: 0x0600FC1C RID: 64540 RVA: 0x004531BC File Offset: 0x004515BC
		public Dictionary<uint, int> GetAwardItems(ActiveManager.ActivityData activity)
		{
			if (this.savedOccu != DataManager<PlayerBaseData>.GetInstance().JobTableID)
			{
				this.savedOccu = DataManager<PlayerBaseData>.GetInstance().JobTableID;
				this.GetExclusiveItems();
			}
			int id = activity.ID;
			Dictionary<uint, int> awards = activity.GetAwards();
			if (awards != null && this.exclusiveItems.ContainsKey(id))
			{
				foreach (KeyValuePair<uint, int> keyValuePair in this.exclusiveItems[id])
				{
					uint key = keyValuePair.Key;
					Dictionary<uint, int>.Enumerator enumerator;
					KeyValuePair<uint, int> keyValuePair2 = enumerator.Current;
					int value = keyValuePair2.Value;
					if (awards.ContainsKey(key))
					{
						Dictionary<uint, int> dictionary;
						uint key2;
						(dictionary = awards)[key2 = key] = dictionary[key2] + value;
					}
					else
					{
						awards.Add(key, value);
					}
				}
			}
			return awards;
		}

		// Token: 0x0600FC1D RID: 64541 RVA: 0x00453298 File Offset: 0x00451698
		public Dictionary<uint, int> GetFirstPayItems()
		{
			Dictionary<uint, int> result = null;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(8300);
			if (activeData != null && activeData.akChildItems[0] != null)
			{
				result = this.GetAwardItems(activeData.akChildItems[0]);
			}
			return result;
		}

		// Token: 0x0600FC1E RID: 64542 RVA: 0x004532E4 File Offset: 0x004516E4
		public List<ActiveManager.ActivityData> GetConsumeItems(bool includeFirst = false)
		{
			List<ActiveManager.ActivityData> list = new List<ActiveManager.ActivityData>();
			if (includeFirst)
			{
				ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(8300);
				if (activeData != null && activeData.akChildItems[0] != null)
				{
					list.Add(activeData.akChildItems[0]);
				}
			}
			ActiveManager.ActiveData activeData2 = DataManager<ActiveManager>.GetInstance().GetActiveData(8400);
			if (activeData2 != null)
			{
				for (int i = 0; i < activeData2.akChildItems.Count; i++)
				{
					list.Add(activeData2.akChildItems[i]);
				}
			}
			return list;
		}

		// Token: 0x0600FC1F RID: 64543 RVA: 0x0045337C File Offset: 0x0045177C
		public void GetRewards(int activity)
		{
			DataManager<ActiveManager>.GetInstance().SendSubmitActivity(activity, 0U);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(1000, delegate
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPayResultNotify, "10", null, null, null);
			}, 0, 0, false);
		}

		// Token: 0x0600FC20 RID: 64544 RVA: 0x004533CC File Offset: 0x004517CC
		public bool CanGetRewards(int activity = 0)
		{
			for (int i = 0; i < this.ids.Length; i++)
			{
				int iTemplateID = this.ids[i];
				ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(iTemplateID);
				if (activeData != null && activeData.akChildItems != null)
				{
					for (int j = 0; j < activeData.akChildItems.Count; j++)
					{
						if ((activity == 0 || activity == activeData.akChildItems[j].ID) && activeData.akChildItems[j].status == 2)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600FC21 RID: 64545 RVA: 0x00453478 File Offset: 0x00451878
		private int GetFinishActivityNum()
		{
			int num = 0;
			for (int i = 0; i < this.ids.Length; i++)
			{
				int iTemplateID = this.ids[i];
				ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(iTemplateID);
				if (activeData != null)
				{
					for (int j = 0; j < activeData.akChildItems.Count; j++)
					{
						if (activeData.akChildItems[j].status >= 2)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600FC22 RID: 64546 RVA: 0x004534F8 File Offset: 0x004518F8
		public void RecordActivity()
		{
			this.canGetActivityCount = this.GetFinishActivityNum();
		}

		// Token: 0x0600FC23 RID: 64547 RVA: 0x00453508 File Offset: 0x00451908
		public bool HasNewActivityFinish()
		{
			int finishActivityNum = this.GetFinishActivityNum();
			return finishActivityNum > this.canGetActivityCount;
		}

		// Token: 0x0600FC24 RID: 64548 RVA: 0x00453525 File Offset: 0x00451925
		public int GetCurrFinishActivityNum()
		{
			return this.GetFinishActivityNum();
		}

		// Token: 0x0600FC25 RID: 64549 RVA: 0x00453530 File Offset: 0x00451930
		public void InitPayReturnDisplayTable()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChargeDisplayTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			while (enumerator.MoveNext())
			{
				PayReturnSpeacialItem payReturnSpeacialItem = new PayReturnSpeacialItem();
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				ChargeDisplayTable chargeDisplayTable = keyValuePair.Value as ChargeDisplayTable;
				if (chargeDisplayTable != null)
				{
					int activityID = chargeDisplayTable.ActivityID;
					payReturnSpeacialItem.payReturnActivityId = activityID;
					ChargeDisplayTable.eType type = chargeDisplayTable.Type;
					string itemID = chargeDisplayTable.ItemID;
					if (!string.IsNullOrEmpty(itemID))
					{
						if (payReturnSpeacialItem.resPaths == null)
						{
							payReturnSpeacialItem.resPaths = new List<PayReturnSpeacialItem.ResPath>();
						}
						string[] array = itemID.Split(new char[]
						{
							'|'
						});
						if (array == null || array.Length == 0)
						{
							payReturnSpeacialItem.bSplit = false;
							PayReturnSpeacialItem.ResPath payReturnResPathItem = this.GetPayReturnResPathItem(itemID, type, chargeDisplayTable.IconPath, chargeDisplayTable.ModelPath);
							payReturnSpeacialItem.resPaths = new List<PayReturnSpeacialItem.ResPath>
							{
								payReturnResPathItem
							};
						}
						else
						{
							payReturnSpeacialItem.bSplit = true;
							List<PayReturnSpeacialItem.ResPath> list = new List<PayReturnSpeacialItem.ResPath>();
							for (int i = 0; i < array.Length; i++)
							{
								PayReturnSpeacialItem.ResPath payReturnResPathItem2 = this.GetPayReturnResPathItem(array[i], type, chargeDisplayTable.IconPath, chargeDisplayTable.ModelPath);
								if (!payReturnSpeacialItem.resPaths.Contains(payReturnResPathItem2))
								{
									payReturnSpeacialItem.resPaths.Add(payReturnResPathItem2);
								}
							}
						}
						if (this.mPayReturnSpecialItemDic == null)
						{
							return;
						}
						if (this.mPayReturnSpecialItemDic.ContainsKey(activityID))
						{
							List<PayReturnSpeacialItem.ResPath> resPaths = this.mPayReturnSpecialItemDic[activityID].resPaths;
							if (resPaths != null && payReturnSpeacialItem.resPaths != null)
							{
								resPaths.AddRange(payReturnSpeacialItem.resPaths);
							}
						}
						else
						{
							this.mPayReturnSpecialItemDic.Add(activityID, payReturnSpeacialItem);
						}
					}
				}
			}
		}

		// Token: 0x0600FC26 RID: 64550 RVA: 0x004536F4 File Offset: 0x00451AF4
		private PayReturnSpeacialItem.ResPath GetPayReturnResPathItem(string itemIdStr, ChargeDisplayTable.eType resType, string iconPath, string modelPath)
		{
			PayReturnSpeacialItem.ResPath resPath = new PayReturnSpeacialItem.ResPath();
			int num = -1;
			if (int.TryParse(itemIdStr, out num) && num > 0)
			{
				resPath.awardItemId = num;
				if (resType == ChargeDisplayTable.eType.Texture)
				{
					resPath.iconPath = iconPath;
				}
				else if (resType == ChargeDisplayTable.eType.Model)
				{
					resPath.modelPath = modelPath;
				}
			}
			return resPath;
		}

		// Token: 0x0600FC27 RID: 64551 RVA: 0x00453748 File Offset: 0x00451B48
		public void ClearPayReturnDisplayTable()
		{
			if (this.mPayReturnSpecialItemDic != null)
			{
				foreach (KeyValuePair<int, PayReturnSpeacialItem> keyValuePair in this.mPayReturnSpecialItemDic)
				{
					PayReturnSpeacialItem value = keyValuePair.Value;
					if (value != null)
					{
						value.Clear();
					}
				}
				this.mPayReturnSpecialItemDic.Clear();
			}
		}

		// Token: 0x0600FC28 RID: 64552 RVA: 0x004537C8 File Offset: 0x00451BC8
		public string GetPayReturnSpecialResPath(int payReturnActivityId, List<AwardItemData> totalAwardItemdataList)
		{
			if (this.mPayReturnSpecialItemDic == null)
			{
				Logger.LogError("Pay Return Special Display Item Dictionary is null");
				return string.Empty;
			}
			if (totalAwardItemdataList == null)
			{
				return string.Empty;
			}
			if (!this.mPayReturnSpecialItemDic.ContainsKey(payReturnActivityId))
			{
				Logger.LogErrorFormat("Pay Return Special Display Item Dictionary can not find activity id  : {0}", new object[]
				{
					payReturnActivityId
				});
				return string.Empty;
			}
			PayReturnSpeacialItem payReturnSpeacialItem = this.mPayReturnSpecialItemDic[payReturnActivityId];
			if (payReturnSpeacialItem == null)
			{
				Logger.LogErrorFormat("Pay Return Special Display Item Dictionary activity id : {0} . value is null", new object[]
				{
					payReturnActivityId
				});
				return string.Empty;
			}
			if (payReturnSpeacialItem.resPaths == null)
			{
				Logger.LogErrorFormat("Pay Return Special Display Item Dictionary activity id : {0} . value awardItem is null", new object[]
				{
					payReturnActivityId
				});
				return string.Empty;
			}
			int count = payReturnSpeacialItem.resPaths.Count;
			for (int i = 0; i < count; i++)
			{
				PayReturnSpeacialItem.ResPath resPath = payReturnSpeacialItem.resPaths[i];
				if (resPath != null)
				{
					int awardItemId = resPath.awardItemId;
					for (int j = 0; j < totalAwardItemdataList.Count; j++)
					{
						int id = totalAwardItemdataList[j].ID;
						if (awardItemId == id)
						{
							string text = resPath.modelPath;
							string text2 = resPath.iconPath;
							if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
							{
								Logger.LogErrorFormat("Charge Display Table is error , iconPath is {0} , modelPath is {1}, should one is null", new object[]
								{
									text,
									text2
								});
								return string.Empty;
							}
							if (!string.IsNullOrEmpty(text))
							{
								if (count > 1 && i + 1 <= count && payReturnSpeacialItem.bSplit)
								{
									text = string.Format(text, i + 1, i + 1);
								}
								else if (!payReturnSpeacialItem.bSplit)
								{
									return text;
								}
								return text;
							}
							if (!string.IsNullOrEmpty(text2))
							{
								if (count > 1 && i + 1 <= count && payReturnSpeacialItem.bSplit)
								{
									text2 = string.Format(text2, i + 1, i + 1);
								}
								else if (!payReturnSpeacialItem.bSplit)
								{
									return text2;
								}
								return text2;
							}
						}
					}
				}
			}
			return string.Empty;
		}

		// Token: 0x0600FC29 RID: 64553 RVA: 0x004539F4 File Offset: 0x00451DF4
		public int GetPayReturnSpecialResID(int payReturnActivityId, List<AwardItemData> totalAwardItemdataList)
		{
			if (this.mPayReturnSpecialItemDic == null)
			{
				Logger.LogError("Pay Return Special Display Item Dictionary is null");
				return -1;
			}
			if (totalAwardItemdataList == null)
			{
				return -1;
			}
			if (!this.mPayReturnSpecialItemDic.ContainsKey(payReturnActivityId))
			{
				Logger.LogErrorFormat("Pay Return Special Display Item Dictionary can not find activity id  : {0}", new object[]
				{
					payReturnActivityId
				});
				return -1;
			}
			PayReturnSpeacialItem payReturnSpeacialItem = this.mPayReturnSpecialItemDic[payReturnActivityId];
			if (payReturnSpeacialItem == null)
			{
				Logger.LogErrorFormat("Pay Return Special Display Item Dictionary activity id : {0} . value is null", new object[]
				{
					payReturnActivityId
				});
				return -1;
			}
			if (payReturnSpeacialItem.resPaths == null)
			{
				Logger.LogErrorFormat("Pay Return Special Display Item Dictionary activity id : {0} . value awardItem Ids is null", new object[]
				{
					payReturnActivityId
				});
				return -1;
			}
			int count = payReturnSpeacialItem.resPaths.Count;
			for (int i = 0; i < count; i++)
			{
				List<PayReturnSpeacialItem.ResPath> resPaths = payReturnSpeacialItem.resPaths;
				if (resPaths != null)
				{
					int awardItemId = resPaths[i].awardItemId;
					for (int j = 0; j < totalAwardItemdataList.Count; j++)
					{
						int id = totalAwardItemdataList[j].ID;
						if (awardItemId == id)
						{
							return id;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x0600FC2A RID: 64554 RVA: 0x00453B18 File Offset: 0x00451F18
		public List<VipDescData> GetPrivilegeDescDataListByVipLevel(int vipLevel)
		{
			this.ClearCurrVipPrivilegeDescList();
			int num = -1;
			if (vipLevel > 0)
			{
				num = vipLevel - 1;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(7, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return this.currVipDescDataList;
			}
			if (vipLevel > tableItem.Value)
			{
				Logger.LogErrorFormat("[PayManager GetPrivilegeDescDataListByVipLevel] - vip level is more than system max vip level !!!", new object[0]);
				return this.currVipDescDataList;
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<VipPrivilegeTable>();
			if (table == null)
			{
				return this.currVipDescDataList;
			}
			ExpTable expTableByMaxLevelInAccount = PlayerUtility.GetExpTableByMaxLevelInAccount();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				VipPrivilegeTable vipPrivilegeTable = keyValuePair.Value as VipPrivilegeTable;
				if (vipPrivilegeTable != null)
				{
					VipDescData vipDescData = null;
					if (num >= 0)
					{
						vipDescData = this.ReadVipPrivilegeDesdByVipLevel(vipPrivilegeTable, num, expTableByMaxLevelInAccount);
					}
					VipDescData vipDescData2 = this.ReadVipPrivilegeDesdByVipLevel(vipPrivilegeTable, vipLevel, expTableByMaxLevelInAccount);
					if (!string.IsNullOrEmpty(vipDescData2.desc))
					{
						bool flag = false;
						if (vipDescData != null && !string.IsNullOrEmpty(vipDescData.desc) && vipDescData.desc.Equals(vipDescData2.desc) && !vipDescData2.bSpecialDisplay)
						{
							flag = true;
						}
						if (this.currVipDescDataList != null && !this.currVipDescDataList.Contains(vipDescData2) && !flag)
						{
							this.currVipDescDataList.Add(vipDescData2);
						}
					}
				}
			}
			return this.currVipDescDataList;
		}

		// Token: 0x0600FC2B RID: 64555 RVA: 0x00453C8C File Offset: 0x0045208C
		private VipDescData ReadVipPrivilegeDesdByVipLevel(VipPrivilegeTable vipPrivilegeTableItem, int vipLevel, ExpTable expTableByMaxLevelInAccount = null)
		{
			VipDescData vipDescData = new VipDescData();
			PropertyInfo property = vipPrivilegeTableItem.GetType().GetProperty(string.Format("VIP{0}", vipLevel), BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				return vipDescData;
			}
			int num = (int)property.GetValue(vipPrivilegeTableItem, null);
			if (num <= 0)
			{
				return vipDescData;
			}
			if (vipLevel > 0)
			{
				if (vipPrivilegeTableItem.Type == VipPrivilegeTable.eType.PK_MONEY_LIMIT)
				{
					SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(2, string.Empty, string.Empty);
					if (tableItem != null)
					{
						num += tableItem.Value;
					}
				}
				else if (vipPrivilegeTableItem.Type == VipPrivilegeTable.eType.MYSTERIOUS_SHOP_REFRESH_NUM)
				{
					SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(4, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						num += tableItem2.Value;
					}
				}
				else if (vipPrivilegeTableItem.Type == VipPrivilegeTable.eType.CREDIT_POINT_MONTH_GET_NUM)
				{
					if (expTableByMaxLevelInAccount != null && expTableByMaxLevelInAccount.CreditPointMonthGetNum > num)
					{
						num = expTableByMaxLevelInAccount.CreditPointMonthGetNum;
					}
				}
				else if (vipPrivilegeTableItem.Type == VipPrivilegeTable.eType.CREDIT_POINT_OWN_NUM)
				{
					if (expTableByMaxLevelInAccount != null && expTableByMaxLevelInAccount.CreditPointOwnNum > num)
					{
						num = expTableByMaxLevelInAccount.CreditPointOwnNum;
					}
				}
				else if (vipPrivilegeTableItem.Type == VipPrivilegeTable.eType.CREDIT_POINT_MONTH_CONVERSION_NUM)
				{
					if (expTableByMaxLevelInAccount != null && expTableByMaxLevelInAccount.CreditPointMonthConversionNum > num)
					{
						num = expTableByMaxLevelInAccount.CreditPointMonthConversionNum;
					}
				}
				else if (vipPrivilegeTableItem.Type == VipPrivilegeTable.eType.None)
				{
					num--;
				}
			}
			if (vipDescData == null)
			{
				return vipDescData;
			}
			if (vipPrivilegeTableItem.DataType == VipPrivilegeTable.eDataType.FLOAT)
			{
				vipDescData.desc = string.Format(vipPrivilegeTableItem.Description, (float)num / 10f) + "%";
			}
			else
			{
				vipDescData.desc = string.Format(vipPrivilegeTableItem.Description, num);
			}
			vipDescData.icon = vipPrivilegeTableItem.IconPath;
			if (this.CheckVipPrivilegeDescToDisplay(vipPrivilegeTableItem.VIPDisplay, vipLevel))
			{
				vipDescData.bSpecialDisplay = true;
			}
			vipDescData.index = vipPrivilegeTableItem.DisplayIndex;
			return vipDescData;
		}

		// Token: 0x0600FC2C RID: 64556 RVA: 0x00453E6D File Offset: 0x0045226D
		private void ClearCurrVipPrivilegeDescList()
		{
			if (this.currVipDescDataList != null)
			{
				this.currVipDescDataList.Clear();
			}
			if (this.preVipDescDataList != null)
			{
				this.preVipDescDataList.Clear();
			}
		}

		// Token: 0x0600FC2D RID: 64557 RVA: 0x00453E9C File Offset: 0x0045229C
		private bool CheckVipPrivilegeDescToDisplay(string displayVipLevels, int vipLevel)
		{
			if (vipLevel < 0)
			{
				return false;
			}
			if (string.IsNullOrEmpty(displayVipLevels))
			{
				return false;
			}
			string value = vipLevel.ToString();
			string[] array = displayVipLevels.Split(new char[]
			{
				'|'
			});
			if ((array == null || array.Length == 0) && displayVipLevels.Equals(value))
			{
				return true;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Equals(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600FC2E RID: 64558 RVA: 0x00453F20 File Offset: 0x00452320
		public void DoPay(int payItemID, int price, ChargeMallType mallType = ChargeMallType.Charge)
		{
			string text = "是否花费";
			text += price;
			text += "充值点支付？";
			SystemNotifyManager.BaseMsgBoxOkCancel(text, delegate
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.Pay(payItemID, price, mallType));
			}, delegate
			{
			}, "确定", "取消");
		}

		// Token: 0x0600FC2F RID: 64559 RVA: 0x00453FAC File Offset: 0x004523AC
		public IEnumerator Pay(int payItemID, int price, ChargeMallType mallType = ChargeMallType.Charge)
		{
			MessageEvents msgEvent = new MessageEvents();
			WorldBillingChargeReq req = new WorldBillingChargeReq();
			req.mallType = (byte)mallType;
			req.goodsId = (uint)payItemID;
			WorldBillingChargeRes res = new WorldBillingChargeRes();
			yield return MessageUtility.Wait<WorldBillingChargeReq, WorldBillingChargeRes>(ServerType.GATE_SERVER, msgEvent, req, res, true, 20f);
			if (msgEvent.IsAllMessageReceived())
			{
				if (res.result == 0U)
				{
					this._DoPay(payItemID, price, mallType);
				}
				else if (res.result / 1000000U == 998U)
				{
					uint num = res.result % 998000000U;
					Debug.LogError("PontEx:" + num);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPayResultNotify, "0", null, null, null);
					SystemNotifyManager.SystemNotify(8001, "支付成功，充值点剩余" + num.ToString());
				}
				else if (res.result / 1000000U == 993U)
				{
					int num2 = (int)(res.result % 993000000U);
					int num3 = price - num2;
					if (price <= num2 || num3 <= 0 || num3 >= 10000)
					{
						SystemNotifyManager.SystemNotify(8001, "交易失败，数据异常：" + num2.ToString());
					}
					else
					{
						string text = "当前充值点剩余" + num2.ToString();
						text += "， 是否前往充值平台充值？";
						SystemNotifyManager.BaseMsgBoxOkCancel(text, delegate
						{
							string text2 = ClientApplication.questionnaireUrl;
							string text3 = string.Format("order_{0}_{1}", ClientApplication.playerinfo.accid, ClientApplication.playerinfo.cpsaccount, Random.Range(1, 9999));
							string arg = ClientApplication.playerinfo.accid.ToString();
							string text4 = ClientApplication.playerinfo.cpsaccount.ToString();
							string text5 = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
							text2 = string.Format("http://{0}/pay/index.php?Usname={1}", ClientApplication.questionnaireUrl, arg);
							Application.OpenURL(text2);
						}, delegate
						{
						}, "确定", "取消");
					}
				}
				else if (res.result == 2600003U)
				{
					if (mallType == ChargeMallType.Charge)
					{
						SystemNotifyManager.SystemNotify(1121, string.Empty);
					}
					else if (mallType == ChargeMallType.Packet)
					{
						SystemNotifyManager.SystemNotify(1204, string.Empty);
					}
				}
				else if (mallType == ChargeMallType.Charge)
				{
					SystemNotifyManager.SystemNotify(2600002, string.Empty);
				}
				else if (mallType == ChargeMallType.Packet)
				{
					SystemNotifyManager.SystemNotify(1039, string.Empty);
				}
			}
			yield break;
		}

		// Token: 0x0600FC30 RID: 64560 RVA: 0x00453FDC File Offset: 0x004523DC
		private void _DoPay(int payItemID, int price, ChargeMallType mallType = ChargeMallType.Charge)
		{
			this.RecordActivity();
			string strRoleId = ClientApplication.playerinfo.roleinfo[ClientApplication.playerinfo.curSelectedRoleIdx].strRoleId;
			string extra = string.Format("{0},{1},{2}", (int)mallType, payItemID, strRoleId);
			string price2 = price.ToString();
			if (Global.Settings.isUsingSDK)
			{
			}
			if (!SDKInterface.IsNewSDKChannelPay())
			{
				SDKInterface.instance.Pay(price2, extra, (int)ClientApplication.playerinfo.serverID, ClientApplication.playerinfo.openuid);
			}
			else
			{
				extra = string.Format("{0},{1},{2},{3},{4}", new object[]
				{
					(int)mallType,
					payItemID,
					strRoleId,
					ClientApplication.playerinfo.openuid,
					(int)ClientApplication.playerinfo.serverID
				});
				this.SetPayItemNameAndDesc(payItemID, mallType);
				string requestId = SDKInterface.instance.GenerateRequestPayID(strRoleId, string.Empty, string.Empty, -1);
				SDKInterface.instance.Pay(requestId, price2, (int)ClientApplication.playerinfo.serverID, ClientApplication.playerinfo.openuid, strRoleId, (int)mallType, payItemID, this.PAY_APP_NAME, this.PAY_APP_DESC, extra);
			}
			if (!Global.Settings.isUsingSDK || Application.platform == 7)
			{
				SceneChat sceneChat = new SceneChat();
				sceneChat.channel = 1;
				sceneChat.targetId = 0UL;
				sceneChat.voiceKey = string.Empty;
				sceneChat.word = string.Format("!!charge order={0} id={1} money={2} mallType={3}", new object[]
				{
					Random.Range(1f, 1E+10f),
					payItemID,
					price,
					(int)mallType
				});
				MonoSingleton<NetManager>.instance.SendCommand<SceneChat>(ServerType.GATE_SERVER, sceneChat);
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(500, delegate
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPayResultNotify, "0", null, null, null);
				}, 0, 0, false);
			}
		}

		// Token: 0x0600FC31 RID: 64561 RVA: 0x004541D0 File Offset: 0x004525D0
		private void SetPayItemNameAndDesc(int payItemId, ChargeMallType mallType)
		{
			ChargeMallTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChargeMallTable>(payItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.PAY_APP_NAME = tableItem.Name;
				this.PAY_APP_DESC = tableItem.Desc;
			}
			else
			{
				this.PAY_APP_NAME = "商城礼包";
				this.PAY_APP_DESC = "购买可获得商城大礼包";
			}
		}

		// Token: 0x04009DD2 RID: 40402
		public const int FIRST_PAY_ID = 8300;

		// Token: 0x04009DD3 RID: 40403
		public const int CONSUME_PAY_ID = 8400;

		// Token: 0x04009DD4 RID: 40404
		public const int FIRSY_PAY_SUB_ID = 8301;

		// Token: 0x04009DD5 RID: 40405
		public const int MONTH_CARD_ACTIVITY_ID = 2500;

		// Token: 0x04009DD6 RID: 40406
		public const int MONTH_CARD_TEMPLATE_ID = 6000;

		// Token: 0x04009DD7 RID: 40407
		public const int MONTH_CARD_TYPE_CONFIG_ID = 9380;

		// Token: 0x04009DD8 RID: 40408
		public const byte STATUS_TASK_INIT = 0;

		// Token: 0x04009DD9 RID: 40409
		public const byte STATUS_TASK_UNFINISH = 1;

		// Token: 0x04009DDA RID: 40410
		public const byte STATUS_TASK_CANGET = 2;

		// Token: 0x04009DDB RID: 40411
		public const byte STATUS_TASK_OVER = 4;

		// Token: 0x04009DDC RID: 40412
		private string PAY_APP_NAME = "商城礼包";

		// Token: 0x04009DDD RID: 40413
		private string PAY_APP_DESC = "购买可获得商城大礼包";

		// Token: 0x04009DDE RID: 40414
		public const int FIRST_PAT_RMB_NUM = 6;

		// Token: 0x04009DDF RID: 40415
		private Dictionary<int, Dictionary<uint, int>> exclusiveItems = new Dictionary<int, Dictionary<uint, int>>();

		// Token: 0x04009DE0 RID: 40416
		private int[] ids = new int[]
		{
			8300,
			8400
		};

		// Token: 0x04009DE1 RID: 40417
		private int canGetActivityCount;

		// Token: 0x04009DE2 RID: 40418
		private int savedOccu = -1;

		// Token: 0x04009DE3 RID: 40419
		public string weaponPath = string.Empty;

		// Token: 0x04009DE4 RID: 40420
		public int weaponStrengthLevel;

		// Token: 0x04009DE5 RID: 40421
		public uint weaponItemID;

		// Token: 0x04009DE6 RID: 40422
		public bool lastPayIsMonthCard;

		// Token: 0x04009DE7 RID: 40423
		public bool lastMontchCardNeedOpenWindow;

		// Token: 0x04009DE8 RID: 40424
		private Dictionary<int, PayReturnSpeacialItem> mPayReturnSpecialItemDic = new Dictionary<int, PayReturnSpeacialItem>();

		// Token: 0x04009DE9 RID: 40425
		private List<VipDescData> preVipDescDataList = new List<VipDescData>();

		// Token: 0x04009DEA RID: 40426
		private List<VipDescData> currVipDescDataList = new List<VipDescData>();
	}
}
