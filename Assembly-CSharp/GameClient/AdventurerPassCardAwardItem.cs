using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200142D RID: 5165
	public class AdventurerPassCardAwardItem : MonoBehaviour
	{
		// Token: 0x0600C857 RID: 51287 RVA: 0x003099A5 File Offset: 0x00307DA5
		private void Start()
		{
		}

		// Token: 0x0600C858 RID: 51288 RVA: 0x003099A7 File Offset: 0x00307DA7
		private void Update()
		{
		}

		// Token: 0x0600C859 RID: 51289 RVA: 0x003099AC File Offset: 0x00307DAC
		private void UpdateAwardItemList(ComUIListScript comUIListScript, List<AdventurerPassCardDataManager.ItemInfo> rewardItems)
		{
			if (comUIListScript == null || rewardItems == null)
			{
				return;
			}
			comUIListScript.Initialize();
			comUIListScript.onBindItem = ((GameObject go) => go);
			comUIListScript.onItemVisiable = delegate(ComUIListElementScript go)
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
				if (rewardItems == null)
				{
					return;
				}
				if (go.m_index >= rewardItems.Count)
				{
					return;
				}
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(rewardItems[go.m_index].itemID, 100, 0);
				if (itemData == null)
				{
					return;
				}
				if (itemData.TableData != null && itemData.TableData.ExpireTime > 0)
				{
					itemData.DeadTimestamp = itemData.TableData.ExpireTime;
				}
				itemData.Count = rewardItems[go.m_index].itemNum;
				com.Setup(itemData, delegate(GameObject var1, ItemData var2)
				{
					DataManager<ItemTipManager>.GetInstance().CloseAll();
					DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
				});
			};
			comUIListScript.SetElementAmount(rewardItems.Count);
		}

		// Token: 0x0600C85A RID: 51290 RVA: 0x00309A2C File Offset: 0x00307E2C
		public void SetUp(object data, bool bShowMode = false)
		{
			if (data == null)
			{
				return;
			}
			if (!(data is AdventurerPassCardDataManager.AwardItemInfo))
			{
				return;
			}
			AdventurerPassCardDataManager.AwardItemInfo awardItemInfo = data as AdventurerPassCardDataManager.AwardItemInfo;
			this.lv.SafeSetText(TR.Value("adventurer_pass_card_lv", awardItemInfo.lv));
			this.btnGetAward.SafeSetOnClickListener(delegate
			{
				DataManager<AdventurerPassCardDataManager>.GetInstance().SendWorldAventurePassRewardReq((uint)awardItemInfo.lv);
			});
			if ((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv < (ulong)((long)awardItemInfo.lv))
			{
				this.lv.CustomActive(true);
				this.btnGetAward.CustomActive(false);
				this.getMarkNormal.CustomActive(false);
				this.getMarkHigh.CustomActive(false);
			}
			else
			{
				bool flag = DataManager<AdventurerPassCardDataManager>.GetInstance().IsNormalAwardReceived(awardItemInfo.lv);
				this.lv.CustomActive(flag);
				this.getMarkNormal.CustomActive(flag);
				if (awardItemInfo.normalAwards != null && awardItemInfo.normalAwards.Count == 0)
				{
					this.getMarkNormal.CustomActive(false);
				}
				bool flag2 = DataManager<AdventurerPassCardDataManager>.GetInstance().IsHighAwardReceived(awardItemInfo.lv);
				this.btnGetAward.CustomActive(!flag || (DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType > AdventurerPassCardDataManager.PassCardType.Normal && !flag2));
				this.getMarkHigh.CustomActive(flag2);
				if (DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType == AdventurerPassCardDataManager.PassCardType.Normal)
				{
					this.getMarkHigh.CustomActive(false);
				}
			}
			if (bShowMode)
			{
				this.lv.CustomActive(true);
				this.btnGetAward.CustomActive(false);
			}
			int num = 0;
			if (DataManager<AdventurerPassCardDataManager>.GetInstance().GetPassCardType != AdventurerPassCardDataManager.PassCardType.Normal)
			{
				num = DataManager<AdventurerPassCardDataManager>.GetInstance().GetCanGetHighAwardItemCopies(awardItemInfo.lv);
			}
			this.countImgRoot.CustomActive(num > 1);
			if (num > 1 && this.copyNum != null)
			{
				Utility.SetImageIcon(this.copyNum.gameObject, string.Format("{0}{1}", "UI/Image/Packed/p_UI_ZhanLing.png:UI_Zhanling_Shuzi_", num), true);
			}
			this.UpdateAwardItemList(this.normalAwards, awardItemInfo.normalAwards);
			this.UpdateAwardItemList(this.highAwards, awardItemInfo.highAwards);
		}

		// Token: 0x0400736C RID: 29548
		[SerializeField]
		private Text lv;

		// Token: 0x0400736D RID: 29549
		[SerializeField]
		private Button btnGetAward;

		// Token: 0x0400736E RID: 29550
		[SerializeField]
		private Image getMarkNormal;

		// Token: 0x0400736F RID: 29551
		[SerializeField]
		private ComUIListScript normalAwards;

		// Token: 0x04007370 RID: 29552
		[SerializeField]
		private ComUIListScript highAwards;

		// Token: 0x04007371 RID: 29553
		[SerializeField]
		private Image getMarkHigh;

		// Token: 0x04007372 RID: 29554
		[SerializeField]
		private GameObject countImgRoot;

		// Token: 0x04007373 RID: 29555
		[SerializeField]
		private Image copyNum;

		// Token: 0x04007374 RID: 29556
		private const string copyNumPathForamt = "UI/Image/Packed/p_UI_ZhanLing.png:UI_Zhanling_Shuzi_";
	}
}
