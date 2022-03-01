using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A90 RID: 6800
	public class MonthlySignInItem : MonoBehaviour
	{
		// Token: 0x06010B14 RID: 68372 RVA: 0x004BBD93 File Offset: 0x004BA193
		private void Start()
		{
		}

		// Token: 0x06010B15 RID: 68373 RVA: 0x004BBD95 File Offset: 0x004BA195
		private void OnDestroy()
		{
		}

		// Token: 0x06010B16 RID: 68374 RVA: 0x004BBD97 File Offset: 0x004BA197
		private void Update()
		{
		}

		// Token: 0x06010B17 RID: 68375 RVA: 0x004BBD99 File Offset: 0x004BA199
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().CloseAll();
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x06010B18 RID: 68376 RVA: 0x004BBDBC File Offset: 0x004BA1BC
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

		// Token: 0x06010B19 RID: 68377 RVA: 0x004BBE10 File Offset: 0x004BA210
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

		// Token: 0x06010B1A RID: 68378 RVA: 0x004BBE50 File Offset: 0x004BA250
		public void SetUp(object data)
		{
			if (data == null)
			{
				return;
			}
			ActivityDataManager.MonthlySignInItemData monthlySignInItemData = data as ActivityDataManager.MonthlySignInItemData;
			if (monthlySignInItemData == null)
			{
				return;
			}
			this.btnReward.SafeSetOnClickListener(delegate
			{
				if (monthlySignInItemData.awardItemData != null)
				{
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(monthlySignInItemData.awardItemData.ID, 100, 0);
					if (itemData2 != null)
					{
						itemData2.Count = monthlySignInItemData.awardItemData.Num;
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData2, null, 4, true, false, true);
					}
				}
			});
			this.btnSignIn.SafeSetOnClickListener(delegate
			{
				DataManager<ActivityDataManager>.GetInstance().SendMonthlySignIn(0, false);
			});
			this.btnFillCheck.SafeSetOnClickListener(delegate
			{
				if (DataManager<ActivityDataManager>.GetInstance().GetFillCheckCount() == 0)
				{
					SystemNotifyManager.SystemNotify(10044, string.Empty);
					return;
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SignFrame>(FrameLayer.Middle, monthlySignInItemData, string.Empty);
			});
			DateTime dateTime = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
			if (dateTime.Hour < 6)
			{
				dateTime = dateTime.AddDays(-1.0);
			}
			int day = dateTime.Day;
			this.signInTodayEff.CustomActive(monthlySignInItemData.day == day && !monthlySignInItemData.signIned);
			this.signInMark.CustomActive(monthlySignInItemData.signIned);
			this.signInMask.CustomActive(monthlySignInItemData.signIned || monthlySignInItemData.day < day);
			if (this.comItem != null && monthlySignInItemData.awardItemData != null)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(monthlySignInItemData.awardItemData.ID, 100, 0);
				if (itemData != null)
				{
					itemData.Count = monthlySignInItemData.awardItemData.Num;
					this.comItem.Setup(itemData, null);
				}
			}
			this.vipAddUpTip.SafeSetText(DataManager<ActivityDataManager>.GetInstance().GetVipAddUpText(dateTime.Month, monthlySignInItemData.day));
			this.vipAddUpTipRoot.CustomActive(DataManager<ActivityDataManager>.GetInstance().GetVipAddUpText(dateTime.Month, monthlySignInItemData.day) != string.Empty);
			if (monthlySignInItemData.day == day)
			{
				this.btnSignIn.CustomActive(!monthlySignInItemData.signIned);
				this.btnFillCheck.CustomActive(false);
				this.btnReward.CustomActive(monthlySignInItemData.signIned);
			}
			else if (monthlySignInItemData.day < day)
			{
				if (monthlySignInItemData.signIned)
				{
					this.btnSignIn.CustomActive(false);
					this.btnFillCheck.CustomActive(false);
					this.btnReward.CustomActive(true);
				}
				else
				{
					this.btnSignIn.CustomActive(false);
					this.btnFillCheck.CustomActive(true);
					this.btnReward.CustomActive(true);
				}
			}
			else
			{
				this.btnSignIn.CustomActive(false);
				this.btnFillCheck.CustomActive(false);
				this.btnReward.CustomActive(true);
			}
		}

		// Token: 0x0400AAB7 RID: 43703
		[SerializeField]
		private ComItem comItem;

		// Token: 0x0400AAB8 RID: 43704
		[SerializeField]
		private Image signInMark;

		// Token: 0x0400AAB9 RID: 43705
		[SerializeField]
		private Image signInMask;

		// Token: 0x0400AABA RID: 43706
		[SerializeField]
		private GameObject signInTodayEff;

		// Token: 0x0400AABB RID: 43707
		[SerializeField]
		private Button btnReward;

		// Token: 0x0400AABC RID: 43708
		[SerializeField]
		private Button btnSignIn;

		// Token: 0x0400AABD RID: 43709
		[SerializeField]
		private Button btnFillCheck;

		// Token: 0x0400AABE RID: 43710
		[SerializeField]
		private GameObject vipAddUpTipRoot;

		// Token: 0x0400AABF RID: 43711
		[SerializeField]
		private Text vipAddUpTip;
	}
}
