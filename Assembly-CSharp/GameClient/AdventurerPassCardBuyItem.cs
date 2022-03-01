using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200142E RID: 5166
	public class AdventurerPassCardBuyItem : MonoBehaviour
	{
		// Token: 0x0600C85D RID: 51293 RVA: 0x00309DC0 File Offset: 0x003081C0
		private void Start()
		{
			this.InitAwardItems();
		}

		// Token: 0x0600C85E RID: 51294 RVA: 0x00309DC8 File Offset: 0x003081C8
		private void OnDestroy()
		{
		}

		// Token: 0x0600C85F RID: 51295 RVA: 0x00309DCA File Offset: 0x003081CA
		private void Update()
		{
		}

		// Token: 0x0600C860 RID: 51296 RVA: 0x00309DCC File Offset: 0x003081CC
		private void InitAwardItems()
		{
			if (this.awardItems == null)
			{
				return;
			}
			this.awardItems.Initialize();
			this.awardItems.onBindItem = ((GameObject go) => go);
			this.awardItems.onItemVisiable = delegate(ComUIListElementScript go)
			{
				if (go == null)
				{
					return;
				}
				ComCommonBind component = go.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				ComItem com = component.GetCom<ComItem>("item");
				if (com == null)
				{
					return;
				}
				if (this.rewardItems == null)
				{
					return;
				}
				if (go.m_index >= this.rewardItems.Count)
				{
					return;
				}
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.rewardItems[go.m_index].itemID, 100, 0);
				if (itemData == null)
				{
					return;
				}
				if (itemData.TableData != null && itemData.TableData.ExpireTime > 0)
				{
					itemData.DeadTimestamp = itemData.TableData.ExpireTime;
				}
				itemData.Count = this.rewardItems[go.m_index].itemNum;
				com.Setup(itemData, delegate(GameObject var1, ItemData var2)
				{
					DataManager<ItemTipManager>.GetInstance().CloseAll();
					DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
				});
			};
		}

		// Token: 0x0600C861 RID: 51297 RVA: 0x00309E35 File Offset: 0x00308235
		private void UpdateAwardItems(int buyLv)
		{
			if (this.awardItems == null)
			{
				return;
			}
			if (this.rewardItems == null)
			{
				return;
			}
			this.awardItems.SetElementAmount(this.rewardItems.Count);
		}

		// Token: 0x0600C862 RID: 51298 RVA: 0x00309E6C File Offset: 0x0030826C
		private List<AdventurerPassCardDataManager.ItemInfo> GetUnlockAwardItems(int buyLv)
		{
			List<AdventurerPassCardDataManager.ItemInfo> items = new List<AdventurerPassCardDataManager.ItemInfo>();
			if (items == null)
			{
				return null;
			}
			int adventurerPassCardMaxLv = DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurerPassCardMaxLv(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID);
			int cardLv = (int)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv;
			int num = Math.Min(adventurerPassCardMaxLv, cardLv + buyLv);
			bool flag = DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType > AdventurerPassCardDataManager.PassCardType.Normal;
			Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo> adventurePassAwardsBySeasonID = DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurePassAwardsBySeasonID(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID);
			if (adventurePassAwardsBySeasonID != null)
			{
				Action<List<AdventurerPassCardDataManager.ItemInfo>> action = delegate(List<AdventurerPassCardDataManager.ItemInfo> awards)
				{
					if (awards == null)
					{
						return;
					}
					for (int j = 0; j < awards.Count; j++)
					{
						AdventurerPassCardDataManager.ItemInfo itemInfo = awards[j];
						if (itemInfo != null)
						{
							AdventurerPassCardDataManager.ItemInfo itemInfo2 = new AdventurerPassCardDataManager.ItemInfo();
							if (itemInfo2 != null)
							{
								itemInfo2.itemID = itemInfo.itemID;
								itemInfo2.itemNum = itemInfo.itemNum;
								itemInfo2.highValue = itemInfo.highValue;
								items.Add(itemInfo2);
							}
						}
					}
				};
				for (int i = cardLv + 1; i <= num; i++)
				{
					if (adventurePassAwardsBySeasonID.ContainsKey(i))
					{
						action(adventurePassAwardsBySeasonID[i].normalAwards);
						if (flag)
						{
							action(adventurePassAwardsBySeasonID[i].highAwards);
						}
					}
				}
			}
			items.Sort((AdventurerPassCardDataManager.ItemInfo a, AdventurerPassCardDataManager.ItemInfo b) => 0);
			return items;
		}

		// Token: 0x0600C863 RID: 51299 RVA: 0x00309F88 File Offset: 0x00308388
		private string GetMoneyIconPath(ItemTable.eSubType eSubType)
		{
			if (eSubType != ItemTable.eSubType.GOLD && eSubType != ItemTable.eSubType.POINT && eSubType != ItemTable.eSubType.BindGOLD && eSubType != ItemTable.eSubType.BindPOINT)
			{
				return string.Empty;
			}
			int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(eSubType);
			ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(moneyIDByType, true, true);
			if (itemByTableID == null)
			{
				return string.Empty;
			}
			return itemByTableID.Icon;
		}

		// Token: 0x0600C864 RID: 51300 RVA: 0x00309FEC File Offset: 0x003083EC
		public void SetUp(object data)
		{
			if (data == null)
			{
				return;
			}
			if (!(data is int))
			{
				return;
			}
			int nBuyLv = (int)data;
			AdventurePassBuyLevelTable adventurePassBuyLevelTable = Singleton<TableManager>.GetInstance().GetTableItem<AdventurePassBuyLevelTable>(nBuyLv, string.Empty, string.Empty);
			if (adventurePassBuyLevelTable == null)
			{
				return;
			}
			int num = nBuyLv / 10;
			int num2 = nBuyLv % 10;
			Utility.SetImageIcon(this.lv0.gameObject, string.Format("{0}{1}", "UI/Image/Packed/p_UI_ZhanLing.png:UI_ZhanLing_DengJi_Number_", num), true);
			Utility.SetImageIcon(this.lv1.gameObject, string.Format("{0}{1}", "UI/Image/Packed/p_UI_ZhanLing.png:UI_ZhanLing_DengJi_Number_", num2), true);
			this.lv0.CustomActive(num > 0);
			long nToLv = Math.Min((long)nBuyLv + (long)((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv), (long)DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurerPassCardMaxLv(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID));
			this.fromLv.SafeSetText(TR.Value("adventurer_pass_card_from_lv", DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv));
			this.toLv.SafeSetText(TR.Value("adventurer_pass_card_to_lv", nToLv));
			this.rewardItems = this.GetUnlockAwardItems(nBuyLv);
			this.rewardItems.Sort(delegate(AdventurerPassCardDataManager.ItemInfo a, AdventurerPassCardDataManager.ItemInfo b)
			{
				if (a == null || b == null)
				{
					return 0;
				}
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(a.itemID, string.Empty, string.Empty);
				ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(b.itemID, string.Empty, string.Empty);
				if (tableItem2 == null || tableItem3 == null)
				{
					return 0;
				}
				if (tableItem2.Color != tableItem3.Color)
				{
					return tableItem3.Color.CompareTo(tableItem2.Color);
				}
				if (a.itemNum != b.itemNum)
				{
					return b.itemNum.CompareTo(a.itemNum);
				}
				return tableItem2.ID.CompareTo(tableItem3.ID);
			});
			this.awardItemNumInfo.SafeSetText(TR.Value("adventurer_pass_card_unlock_award", (this.rewardItems == null) ? 0 : this.rewardItems.Count));
			this.InitAwardItems();
			this.UpdateAwardItems(nBuyLv);
			this.moneyIcon.SafeSetImage(this.GetMoneyIconPath(ItemTable.eSubType.POINT), false);
			if (this.moneyNum != null)
			{
				this.moneyNum.SafeSetText(adventurePassBuyLevelTable.PointCost.ToString());
				this.moneyNum.color = ((adventurePassBuyLevelTable.PointCost <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT), true)) ? Color.green : Color.red);
			}
			this.btnBuy.SafeSetOnClickListener(delegate
			{
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
				{
					nMoneyID = moneyIDByType,
					nCount = adventurePassBuyLevelTable.PointCost
				}, delegate
				{
					LoginToggleMsgBoxOKCancelFrame.TryShowMsgBox(LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgType.AdventurerPassCardBuyLevel, TR.Value("adventurer_pass_card_buy_lv_tip", adventurePassBuyLevelTable.PointCost, nToLv, this.rewardItems.Count), delegate
					{
						DataManager<AdventurerPassCardDataManager>.GetInstance().SendWorldAventurePassBuyLvReq((uint)nBuyLv);
					}, delegate
					{
					}, TR.Value("adventurer_pass_card_buy_lv_tip_ok"), TR.Value("adventurer_pass_card_buy_lv_tip_cancel"));
				}, "common_money_cost", null);
			});
			this.btnBuy.SafeSetGray((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv >= (ulong)((long)DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurerPassCardMaxLv(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID)) || (long)nBuyLv + (long)((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv) > (long)DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurerPassCardMaxLv(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID), true);
			AdventurePassBuyLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AdventurePassBuyLevelTable>(1, string.Empty, string.Empty);
			if (tableItem != null)
			{
				float num3 = (float)tableItem.PointCost * (float)nBuyLv / (float)adventurePassBuyLevelTable.PointCost;
				string text = Math.Round((double)(num3 * 10f), 1).ToString();
				if (text.Length == 3)
				{
					this.num0.SafeSetImage(string.Format("{0}{1}", "UI/Image/Packed/p_UI_ZhanLing.png:UI_ZhanLing_ZheKou_Number_", Utility.ToInt(text[0].ToString())), false);
					this.num1.SafeSetImage(string.Format("{0}{1}", "UI/Image/Packed/p_UI_ZhanLing.png:UI_ZhanLing_ZheKou_Number_", Utility.ToInt(text[2].ToString())), false);
				}
				this.discountRoot.CustomActive(num3 < 1f);
			}
		}

		// Token: 0x04007376 RID: 29558
		[SerializeField]
		private Image lv0;

		// Token: 0x04007377 RID: 29559
		[SerializeField]
		private Image lv1;

		// Token: 0x04007378 RID: 29560
		[SerializeField]
		private Text fromLv;

		// Token: 0x04007379 RID: 29561
		[SerializeField]
		private Text toLv;

		// Token: 0x0400737A RID: 29562
		[SerializeField]
		private Text awardItemNumInfo;

		// Token: 0x0400737B RID: 29563
		[SerializeField]
		private ComUIListScript awardItems;

		// Token: 0x0400737C RID: 29564
		[SerializeField]
		private Text moneyNum;

		// Token: 0x0400737D RID: 29565
		[SerializeField]
		private Image moneyIcon;

		// Token: 0x0400737E RID: 29566
		[SerializeField]
		private Button btnBuy;

		// Token: 0x0400737F RID: 29567
		[SerializeField]
		private Image num0;

		// Token: 0x04007380 RID: 29568
		[SerializeField]
		private Image num1;

		// Token: 0x04007381 RID: 29569
		[SerializeField]
		private GameObject discountRoot;

		// Token: 0x04007382 RID: 29570
		private List<AdventurerPassCardDataManager.ItemInfo> rewardItems;

		// Token: 0x04007383 RID: 29571
		private const string numberPathFormat = "UI/Image/Packed/p_UI_ZhanLing.png:UI_ZhanLing_DengJi_Number_";

		// Token: 0x04007384 RID: 29572
		private const string discountNumPathFormat = "UI/Image/Packed/p_UI_ZhanLing.png:UI_ZhanLing_ZheKou_Number_";
	}
}
