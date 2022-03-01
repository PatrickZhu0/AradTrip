using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A8B RID: 6795
	public class AccumulativeSignInItem : MonoBehaviour
	{
		// Token: 0x06010AE4 RID: 68324 RVA: 0x004BA918 File Offset: 0x004B8D18
		private void Start()
		{
		}

		// Token: 0x06010AE5 RID: 68325 RVA: 0x004BA91A File Offset: 0x004B8D1A
		private void OnDestroy()
		{
		}

		// Token: 0x06010AE6 RID: 68326 RVA: 0x004BA91C File Offset: 0x004B8D1C
		private void Update()
		{
		}

		// Token: 0x06010AE7 RID: 68327 RVA: 0x004BA91E File Offset: 0x004B8D1E
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().CloseAll();
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x06010AE8 RID: 68328 RVA: 0x004BA940 File Offset: 0x004B8D40
		private void SetComItemData(ComItem comItem, AwardItemData uIItemData)
		{
			if (comItem == null || uIItemData == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(uIItemData.ID, 100, 0);
			if (itemData != null)
			{
				itemData.Count = uIItemData.Num;
				comItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTip));
			}
		}

		// Token: 0x06010AE9 RID: 68329 RVA: 0x004BA994 File Offset: 0x004B8D94
		private string GetColorName(AwardItemData uIItemData)
		{
			if (uIItemData == null)
			{
				return string.Empty;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(uIItemData.ID, 100, 0);
			if (itemData != null)
			{
				return itemData.GetColorName(string.Empty, false);
			}
			return string.Empty;
		}

		// Token: 0x06010AEA RID: 68330 RVA: 0x004BA9D4 File Offset: 0x004B8DD4
		private string GetVipAddUpText(int day)
		{
			return string.Empty;
		}

		// Token: 0x06010AEB RID: 68331 RVA: 0x004BA9DC File Offset: 0x004B8DDC
		public void SetUp(object data)
		{
			if (data == null)
			{
				return;
			}
			ActivityDataManager.AccumulativeSignInItemData accumulativeSignInItemData = data as ActivityDataManager.AccumulativeSignInItemData;
			if (accumulativeSignInItemData == null)
			{
				return;
			}
			this.btnReward.SafeSetOnClickListener(delegate
			{
				if (accumulativeSignInItemData.awardItemData != null)
				{
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(accumulativeSignInItemData.awardItemData.ID, 100, 0);
					if (itemData2 != null)
					{
						itemData2.Count = accumulativeSignInItemData.awardItemData.Num;
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData2, null, 4, true, false, true);
					}
				}
			});
			this.btnGot.SafeSetOnClickListener(delegate
			{
				DataManager<ActivityDataManager>.GetInstance().SendGetAccumulativeSignInAward(accumulativeSignInItemData.accumulativeDay);
			});
			DateTime dateTime = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
			this.gotMark.CustomActive(accumulativeSignInItemData.hasGotAward);
			this.gotMask.CustomActive(accumulativeSignInItemData.hasGotAward);
			this.canGetEff.CustomActive(!accumulativeSignInItemData.hasGotAward && accumulativeSignInItemData.accumulativeDay <= DataManager<ActivityDataManager>.GetInstance().GetHasSignInCount());
			this.accumulativeDay.SafeSetText(TR.Value("accumulative_day", accumulativeSignInItemData.accumulativeDay));
			if (accumulativeSignInItemData.accumulativeDay >= ActivityDataManager.GetMonthDayNum(dateTime.Year, dateTime.Month))
			{
				this.accumulativeDay.SafeSetText(TR.Value("at_duty_every_day"));
			}
			if (this.comItem != null && accumulativeSignInItemData.awardItemData != null)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(accumulativeSignInItemData.awardItemData.ID, 100, 0);
				if (itemData != null)
				{
					itemData.Count = accumulativeSignInItemData.awardItemData.Num;
					this.comItem.Setup(itemData, null);
				}
			}
			if (!accumulativeSignInItemData.hasGotAward)
			{
				this.btnGot.CustomActive(accumulativeSignInItemData.accumulativeDay <= DataManager<ActivityDataManager>.GetInstance().GetHasSignInCount());
				this.btnReward.CustomActive(accumulativeSignInItemData.accumulativeDay > DataManager<ActivityDataManager>.GetInstance().GetHasSignInCount());
			}
			else
			{
				this.btnGot.CustomActive(false);
				this.btnReward.CustomActive(true);
			}
		}

		// Token: 0x0400AA8A RID: 43658
		[SerializeField]
		private Text accumulativeDay;

		// Token: 0x0400AA8B RID: 43659
		[SerializeField]
		private ComItem comItem;

		// Token: 0x0400AA8C RID: 43660
		[SerializeField]
		private Image gotMark;

		// Token: 0x0400AA8D RID: 43661
		[SerializeField]
		private Image gotMask;

		// Token: 0x0400AA8E RID: 43662
		[SerializeField]
		private Button btnReward;

		// Token: 0x0400AA8F RID: 43663
		[SerializeField]
		private Button btnGot;

		// Token: 0x0400AA90 RID: 43664
		[SerializeField]
		private GameObject canGetEff;
	}
}
