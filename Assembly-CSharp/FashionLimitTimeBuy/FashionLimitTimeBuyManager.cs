using System;
using System.Collections.Generic;
using GameClient;
using LimitTimeGift;
using Parser;
using Protocol;
using ProtoTable;
using UnityEngine.UI;

namespace FashionLimitTimeBuy
{
	// Token: 0x02001729 RID: 5929
	public class FashionLimitTimeBuyManager : DataManager<FashionLimitTimeBuyManager>
	{
		// Token: 0x0600E8D7 RID: 59607 RVA: 0x003D9E15 File Offset: 0x003D8215
		public Dictionary<int, List<MallItemInfo>> GetAllLimtTimeFashionInfosByType()
		{
			return this.allLimitTimeFashionByTypeDic;
		}

		// Token: 0x0600E8D8 RID: 59608 RVA: 0x003D9E1D File Offset: 0x003D821D
		public Dictionary<uint, MallItemInfo> GetAllLimitTimeFashionById()
		{
			return this.allLimitTimeFashionByIdDic;
		}

		// Token: 0x0600E8D9 RID: 59609 RVA: 0x003D9E25 File Offset: 0x003D8225
		public Dictionary<int, List<MallItemInfo>> GetAllFashionSuitsByType()
		{
			return this.allFashionSuitByTypeDic;
		}

		// Token: 0x0600E8DA RID: 59610 RVA: 0x003D9E2D File Offset: 0x003D822D
		public Dictionary<uint, MallItemInfo> GetAllFashionSuitsById()
		{
			return this.allFashionSuitByIdDic;
		}

		// Token: 0x0600E8DB RID: 59611 RVA: 0x003D9E35 File Offset: 0x003D8235
		public Dictionary<int, LimitTimeGiftData> GetMallFashionSuitsByOccIdDic()
		{
			return this.mallFashionSuitsByOccIdDic;
		}

		// Token: 0x0600E8DC RID: 59612 RVA: 0x003D9E40 File Offset: 0x003D8240
		public uint[] TryGetItemIdsInMallItemInfo(MallItemInfo itemInfo, int getIndex = 0)
		{
			uint[] array = new uint[1];
			if (itemInfo == null)
			{
				return array;
			}
			if (itemInfo.itemid != 0U)
			{
				return new uint[]
				{
					itemInfo.itemid
				};
			}
			if (itemInfo.giftItems == null)
			{
				return array;
			}
			int num = itemInfo.giftItems.Length;
			array = new uint[num];
			if (getIndex < num)
			{
				if (getIndex == 0)
				{
					for (int i = 0; i < num; i++)
					{
						ItemReward itemReward = itemInfo.giftItems[i];
						if (itemReward != null)
						{
							array[i] = itemReward.id;
						}
					}
					return array;
				}
				if (getIndex > 0)
				{
					return new uint[]
					{
						itemInfo.itemid
					};
				}
			}
			return array;
		}

		// Token: 0x0600E8DD RID: 59613 RVA: 0x003D9EEC File Offset: 0x003D82EC
		public uint TryGetItemIdInMallItemInfo(MallItemInfo itemInfo, int getIndex = 0)
		{
			if (itemInfo == null)
			{
				return 0U;
			}
			if (itemInfo.itemid != 0U)
			{
				return itemInfo.itemid;
			}
			if (itemInfo.giftItems == null)
			{
				return 0U;
			}
			int num = itemInfo.giftItems.Length;
			if (getIndex < num)
			{
				if (getIndex == 0)
				{
					ItemReward itemReward = itemInfo.giftItems[getIndex];
					if (itemReward != null)
					{
						return itemReward.id;
					}
				}
				else if (getIndex > 0)
				{
					return itemInfo.itemid;
				}
			}
			return 0U;
		}

		// Token: 0x0600E8DE RID: 59614 RVA: 0x003D9F60 File Offset: 0x003D8360
		public override void Initialize()
		{
			this.typeLimitTimeFashionInfoList = new List<MallItemInfo>();
			this.typeLimitTimeFashionInfoDic = new Dictionary<int, List<MallItemInfo>>();
			this.allLimitTimeFashionByIdDic = new Dictionary<uint, MallItemInfo>();
			this.allLimitTimeFashionByTypeDic = new Dictionary<int, List<MallItemInfo>>();
			this.allFashionSuitByIdDic = new Dictionary<uint, MallItemInfo>();
			this.allFashionSuitByTypeDic = new Dictionary<int, List<MallItemInfo>>();
			this.typeFashionSuitInfoList = new List<MallItemInfo>();
			this.typeFashionSuitInfoDic = new Dictionary<int, List<MallItemInfo>>();
			this.mallFashionSuitsByOccIdDic = new Dictionary<int, LimitTimeGiftData>();
		}

		// Token: 0x0600E8DF RID: 59615 RVA: 0x003D9FD0 File Offset: 0x003D83D0
		public override void Clear()
		{
			if (this.typeLimitTimeFashionInfoList != null)
			{
				this.typeLimitTimeFashionInfoList.Clear();
				this.typeLimitTimeFashionInfoList = null;
			}
			if (this.typeLimitTimeFashionInfoDic != null)
			{
				this.typeLimitTimeFashionInfoDic.Clear();
				this.typeLimitTimeFashionInfoDic = null;
			}
			if (this.allLimitTimeFashionByTypeDic != null)
			{
				this.allLimitTimeFashionByTypeDic.Clear();
				this.allLimitTimeFashionByTypeDic = null;
			}
			if (this.allLimitTimeFashionByIdDic != null)
			{
				this.allLimitTimeFashionByIdDic.Clear();
				this.allLimitTimeFashionByIdDic = null;
			}
			if (this.typeFashionSuitInfoList != null)
			{
				this.typeFashionSuitInfoList.Clear();
				this.typeFashionSuitInfoList = null;
			}
			if (this.typeFashionSuitInfoDic != null)
			{
				this.typeFashionSuitInfoDic.Clear();
				this.typeFashionSuitInfoDic = null;
			}
			if (this.allFashionSuitByIdDic != null)
			{
				this.allFashionSuitByIdDic.Clear();
				this.allFashionSuitByIdDic = null;
			}
			if (this.allFashionSuitByTypeDic != null)
			{
				this.allFashionSuitByTypeDic.Clear();
				this.allFashionSuitByTypeDic = null;
			}
			if (this.mallFashionSuitsByOccIdDic != null)
			{
				this.mallFashionSuitsByOccIdDic.Clear();
				this.mallFashionSuitsByOccIdDic = null;
			}
		}

		// Token: 0x0600E8E0 RID: 59616 RVA: 0x003DA0E4 File Offset: 0x003D84E4
		public uint TryGetUpWearItemIdInFashionSuit(MallItemInfo itemInfo, FashionMallMainIndex fashionTypeIndex)
		{
			if (itemInfo == null)
			{
				return 0U;
			}
			if (fashionTypeIndex == FashionMallMainIndex.FashionAll && itemInfo != null && itemInfo.giftItems != null && itemInfo.giftItems.Length == 5)
			{
				int num = 1;
				return itemInfo.giftItems[num].id;
			}
			return itemInfo.itemid;
		}

		// Token: 0x0600E8E1 RID: 59617 RVA: 0x003DA134 File Offset: 0x003D8534
		public void ResetItemNameColor(ItemTable item, Text text)
		{
			if (text == null)
			{
				return;
			}
			string arg = "white";
			if (item != null)
			{
				arg = ItemParser.GetItemColor(item);
			}
			string text2 = text.text;
			text.text = string.Format("<color={0}>", arg) + text2 + "</color>";
		}

		// Token: 0x0600E8E2 RID: 59618 RVA: 0x003DA184 File Offset: 0x003D8584
		public override EEnterGameOrder GetOrder()
		{
			return base.GetOrder();
		}

		// Token: 0x0600E8E3 RID: 59619 RVA: 0x003DA18C File Offset: 0x003D858C
		public MallItemInfo[] FashionLimitTimeFilter(MallItemInfo[] allMallItems)
		{
			if (allMallItems == null)
			{
				return allMallItems;
			}
			if (allMallItems.Length <= 0)
			{
				return allMallItems;
			}
			if (allMallItems[0].gift != 4)
			{
				return allMallItems;
			}
			if (allMallItems[0].itemid == 0U)
			{
				return this.FashionSuitFilter(allMallItems);
			}
			if (this.typeLimitTimeFashionInfoList == null || this.typeLimitTimeFashionInfoDic == null)
			{
				return null;
			}
			this.typeLimitTimeFashionInfoList.Clear();
			this.typeLimitTimeFashionInfoDic.Clear();
			List<MallItemInfo> list = new List<MallItemInfo>(allMallItems);
			for (int i = 0; i < list.Count; i++)
			{
				MallItemInfo mallItemInfo = list[i];
				if (mallItemInfo != null && mallItemInfo.gift == 4)
				{
					this.typeLimitTimeFashionInfoList.Add(mallItemInfo);
					if (this.allLimitTimeFashionByIdDic != null)
					{
						if (this.allLimitTimeFashionByIdDic.ContainsKey(mallItemInfo.id))
						{
							this.allLimitTimeFashionByIdDic[mallItemInfo.id] = mallItemInfo;
						}
						else
						{
							this.allLimitTimeFashionByIdDic.Add(mallItemInfo.id, mallItemInfo);
						}
					}
				}
			}
			if (this.typeLimitTimeFashionInfoList != null)
			{
				for (int j = 0; j < this.typeLimitTimeFashionInfoList.Count; j++)
				{
					MallItemInfo mallItemInfo2 = this.typeLimitTimeFashionInfoList[j];
					int goodsSubType = (int)mallItemInfo2.goodsSubType;
					if (this.typeLimitTimeFashionInfoDic.ContainsKey(goodsSubType))
					{
						List<MallItemInfo> list2 = this.typeLimitTimeFashionInfoDic[goodsSubType];
						if (list2 != null)
						{
							if (list2.Contains(mallItemInfo2))
							{
								list2.Remove(mallItemInfo2);
							}
							list2.Add(mallItemInfo2);
						}
					}
					else
					{
						this.typeLimitTimeFashionInfoDic.Add(goodsSubType, new List<MallItemInfo>
						{
							mallItemInfo2
						});
					}
					if (this.allLimitTimeFashionByTypeDic != null)
					{
						if (this.allLimitTimeFashionByTypeDic.ContainsKey(goodsSubType))
						{
							this.allLimitTimeFashionByTypeDic[goodsSubType] = this.typeLimitTimeFashionInfoDic[goodsSubType];
						}
						else
						{
							this.allLimitTimeFashionByTypeDic.Add(goodsSubType, this.typeLimitTimeFashionInfoDic[goodsSubType]);
						}
					}
				}
			}
			List<MallItemInfo> list3 = new List<MallItemInfo>();
			if (this.typeLimitTimeFashionInfoDic != null)
			{
				foreach (KeyValuePair<int, List<MallItemInfo>> keyValuePair in this.typeLimitTimeFashionInfoDic)
				{
					if (!keyValuePair.Equals(default(KeyValuePair<int, List<MallItemInfo>>)))
					{
						List<MallItemInfo> value = keyValuePair.Value;
						if (value != null)
						{
							for (int k = 0; k < value.Count; k++)
							{
								MallItemInfo mallItemInfo3 = this.FilterNotShowItemByTimeLimit(value[k]);
								if (mallItemInfo3 != null)
								{
									list3.Add(mallItemInfo3);
								}
							}
						}
					}
				}
			}
			if (list3.Count > 0)
			{
				for (int l = 0; l < list3.Count; l++)
				{
					for (int m = 0; m < list.Count; m++)
					{
						if (list[m].id.Equals(list3[l].id))
						{
							list.RemoveAt(m);
							break;
						}
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x0600E8E4 RID: 59620 RVA: 0x003DA4B8 File Offset: 0x003D88B8
		private MallItemInfo FilterNotShowItemByTimeLimit(MallItemInfo item)
		{
			if (item != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)item.itemid, string.Empty, string.Empty);
				if (tableItem != null && tableItem.TimeLeft != 604800)
				{
					return item;
				}
			}
			return null;
		}

		// Token: 0x0600E8E5 RID: 59621 RVA: 0x003DA500 File Offset: 0x003D8900
		private MallItemInfo[] FashionSuitFilter(MallItemInfo[] mallItems)
		{
			if (mallItems == null)
			{
				return mallItems;
			}
			if (mallItems.Length <= 0)
			{
				return mallItems;
			}
			if (mallItems[0].gift != 4)
			{
				return mallItems;
			}
			if (this.typeFashionSuitInfoList == null || this.typeFashionSuitInfoDic == null)
			{
				return null;
			}
			this.typeFashionSuitInfoList.Clear();
			this.typeFashionSuitInfoDic.Clear();
			List<MallItemInfo> list = new List<MallItemInfo>(mallItems);
			for (int i = 0; i < list.Count; i++)
			{
				MallItemInfo mallItemInfo = list[i];
				if (mallItemInfo != null && mallItemInfo.gift == 4)
				{
					this.typeFashionSuitInfoList.Add(mallItemInfo);
					if (this.allFashionSuitByIdDic != null)
					{
						if (this.allFashionSuitByIdDic.ContainsKey(mallItemInfo.id))
						{
							this.allFashionSuitByIdDic[mallItemInfo.id] = mallItemInfo;
						}
						else
						{
							this.allFashionSuitByIdDic.Add(mallItemInfo.id, mallItemInfo);
						}
					}
				}
			}
			if (this.typeFashionSuitInfoList != null)
			{
				for (int j = 0; j < this.typeFashionSuitInfoList.Count; j++)
				{
					MallItemInfo mallItemInfo2 = this.typeFashionSuitInfoList[j];
					int goodsSubType = (int)mallItemInfo2.goodsSubType;
					if (this.typeFashionSuitInfoDic.ContainsKey(goodsSubType))
					{
						List<MallItemInfo> list2 = this.typeFashionSuitInfoDic[goodsSubType];
						if (list2 != null)
						{
							if (list2.Contains(mallItemInfo2))
							{
								list2.Remove(mallItemInfo2);
							}
							list2.Add(mallItemInfo2);
						}
					}
					else
					{
						this.typeFashionSuitInfoDic.Add(goodsSubType, new List<MallItemInfo>
						{
							mallItemInfo2
						});
					}
					if (this.allFashionSuitByTypeDic != null)
					{
						if (this.allFashionSuitByTypeDic.ContainsKey(goodsSubType))
						{
							this.allFashionSuitByTypeDic[goodsSubType] = this.typeFashionSuitInfoDic[goodsSubType];
						}
						else
						{
							this.allFashionSuitByTypeDic.Add(goodsSubType, this.typeFashionSuitInfoDic[goodsSubType]);
						}
					}
				}
			}
			List<MallItemInfo> list3 = new List<MallItemInfo>();
			if (this.typeFashionSuitInfoDic != null)
			{
				foreach (KeyValuePair<int, List<MallItemInfo>> keyValuePair in this.typeFashionSuitInfoDic)
				{
					if (!keyValuePair.Equals(default(KeyValuePair<int, List<MallItemInfo>>)))
					{
						List<MallItemInfo> value = keyValuePair.Value;
						if (value != null)
						{
							for (int k = 0; k < value.Count; k++)
							{
								MallItemInfo mallItemInfo3 = this.FilterNotShowItem(value[k]);
								if (mallItemInfo3 != null)
								{
									list3.Add(mallItemInfo3);
								}
							}
						}
					}
				}
			}
			if (list3.Count > 0)
			{
				for (int l = 0; l < list3.Count; l++)
				{
					for (int m = 0; m < list.Count; m++)
					{
						if (list[m].id.Equals(list3[l].id))
						{
							list.RemoveAt(m);
							break;
						}
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x0600E8E6 RID: 59622 RVA: 0x003DA810 File Offset: 0x003D8C10
		private MallItemInfo FilterNotShowItem(MallItemInfo item)
		{
			if (item != null)
			{
				ItemReward[] giftItems = item.giftItems;
				ItemReward itemReward = null;
				if (giftItems != null && giftItems.Length == 5)
				{
					itemReward = giftItems[1];
				}
				if (itemReward != null)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)itemReward.id, string.Empty, string.Empty);
					if (tableItem != null && tableItem.TimeLeft != 604800)
					{
						return item;
					}
				}
			}
			return null;
		}

		// Token: 0x04008D3D RID: 36157
		private Dictionary<uint, MallItemInfo> allLimitTimeFashionByIdDic;

		// Token: 0x04008D3E RID: 36158
		private Dictionary<int, List<MallItemInfo>> allLimitTimeFashionByTypeDic;

		// Token: 0x04008D3F RID: 36159
		private List<MallItemInfo> typeLimitTimeFashionInfoList;

		// Token: 0x04008D40 RID: 36160
		private Dictionary<int, List<MallItemInfo>> typeLimitTimeFashionInfoDic;

		// Token: 0x04008D41 RID: 36161
		private Dictionary<uint, MallItemInfo> allFashionSuitByIdDic;

		// Token: 0x04008D42 RID: 36162
		private Dictionary<int, List<MallItemInfo>> allFashionSuitByTypeDic;

		// Token: 0x04008D43 RID: 36163
		private List<MallItemInfo> typeFashionSuitInfoList;

		// Token: 0x04008D44 RID: 36164
		private Dictionary<int, List<MallItemInfo>> typeFashionSuitInfoDic;

		// Token: 0x04008D45 RID: 36165
		private Dictionary<int, LimitTimeGiftData> mallFashionSuitsByOccIdDic;

		// Token: 0x04008D46 RID: 36166
		public bool haveFashionDiscount;
	}
}
