using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001453 RID: 5203
	public class AuctionFreezeRemindFrame : ClientFrame
	{
		// Token: 0x0600C9F7 RID: 51703 RVA: 0x00315FCD File Offset: 0x003143CD
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Auction/AuctionFreezeRemind";
		}

		// Token: 0x0600C9F8 RID: 51704 RVA: 0x00315FD4 File Offset: 0x003143D4
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mText = this.mBind.GetCom<Text>("text");
			this.mTerminationOfBailText = this.mBind.GetCom<Text>("TerminationOfBailText");
			this.mExceptionTradHoursText = this.mBind.GetCom<Text>("ExceptionTradHoursText");
			this.mRemainingOnBailText = this.mBind.GetCom<Text>("RemainingOnBailText");
			this.mForeverBlank = this.mBind.GetCom<Text>("foreverBlank");
			this.mOne = this.mBind.GetCom<Text>("One");
			this.mTwo = this.mBind.GetCom<Text>("Two");
			this.mRuleOne = this.mBind.GetCom<Text>("RuleOne");
			this.mRuleTwo = this.mBind.GetCom<Text>("RuleTwo");
			this.mScroll = this.mBind.GetCom<ScrollRect>("scroll");
		}

		// Token: 0x0600C9F9 RID: 51705 RVA: 0x00316100 File Offset: 0x00314500
		protected override void _unbindExUI()
		{
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mText = null;
			this.mTerminationOfBailText = null;
			this.mExceptionTradHoursText = null;
			this.mRemainingOnBailText = null;
			this.mRemainingOnBailText = null;
			this.mOne = null;
			this.mTwo = null;
			this.mRuleOne = null;
			this.mRuleTwo = null;
			this.mScroll = null;
		}

		// Token: 0x0600C9FA RID: 51706 RVA: 0x00316187 File Offset: 0x00314587
		private void _onCloseButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<AuctionFreezeRemindFrame>(this, false);
		}

		// Token: 0x0600C9FB RID: 51707 RVA: 0x00316195 File Offset: 0x00314595
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.mAuctionFreezeRemindData = (this.userData as AuctionFreezeRemindData);
			}
			this._InitData();
			this._Init(this.mAuctionFreezeRemindData);
		}

		// Token: 0x0600C9FC RID: 51708 RVA: 0x003161C5 File Offset: 0x003145C5
		protected sealed override void _OnCloseFrame()
		{
			this.mAuctionFreezeRemindData = null;
			this.mChargeUnFreezeMoneryRate = 0;
			this.mDailyTaskScoreUnFreezeRequirement = 0;
			this.mDailyTaskScoreUnFreezeDays = 0;
		}

		// Token: 0x0600C9FD RID: 51709 RVA: 0x003161E4 File Offset: 0x003145E4
		private void _InitData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(390, string.Empty, string.Empty);
			this.mChargeUnFreezeMoneryRate = tableItem.Value;
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(391, string.Empty, string.Empty);
			this.mDailyTaskScoreUnFreezeRequirement = tableItem2.Value;
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(392, string.Empty, string.Empty);
			this.mDailyTaskScoreUnFreezeDays = tableItem3.Value;
		}

		// Token: 0x0600C9FE RID: 51710 RVA: 0x00316264 File Offset: 0x00314664
		private void _Init(AuctionFreezeRemindData data)
		{
			if (data == null)
			{
				return;
			}
			bool flag = AuctionNewUtility.IsItemForeverFreeze((int)data.remainingBailPeriod);
			this.mText.text = TR.Value("AuctionFreezeRemind_ExceptionText", data.frozenAmount);
			this.mExceptionTradHoursText.text = TR.Value("AuctionFreezeRemind_ExceptionTextTradHours", DataManager<AuctionDataManager>.GetInstance().GetDateTime((int)data.abnormalTransactionTime));
			this.mTerminationOfBailText.text = TR.Value("AuctionFreezeRemind_TerminationOfBail", DataManager<AuctionDataManager>.GetInstance().GetDateTime((int)data.terminationOfBail));
			this.mRemainingOnBailText.text = TR.Value("AuctionFreezeRemind_RemainingOnBail", DataManager<AuctionDataManager>.GetInstance().GetDataDay((int)data.remainingBailPeriod));
			this.mOne.text = TR.Value("AuctionFreezeRemind_One", data.backAmount);
			this.mTwo.text = TR.Value("AuctionFreezeRemind_Two", data.backDays);
			this.mRuleOne.text = TR.Value("AuctionFreezeRemind_RuleOne", this.mChargeUnFreezeMoneryRate);
			this.mRuleTwo.text = TR.Value("AuctionFreezeRemind_RuleTwo", this.mDailyTaskScoreUnFreezeRequirement, this.mDailyTaskScoreUnFreezeDays);
			if (flag)
			{
				CommonUtility.UpdateTextVisible(this.mForeverBlank, true);
				CommonUtility.UpdateTextVisible(this.mTwo, false);
				CommonUtility.UpdateTextVisible(this.mRuleTwo, false);
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.mForeverBlank, false);
				CommonUtility.UpdateTextVisible(this.mTwo, true);
				CommonUtility.UpdateTextVisible(this.mRuleTwo, true);
			}
		}

		// Token: 0x040074F5 RID: 29941
		private const string mPrefabPath = "UIFlatten/Prefabs/Auction/AuctionFreezeRemind";

		// Token: 0x040074F6 RID: 29942
		private int mChargeUnFreezeMoneryRate;

		// Token: 0x040074F7 RID: 29943
		private int mDailyTaskScoreUnFreezeRequirement;

		// Token: 0x040074F8 RID: 29944
		private int mDailyTaskScoreUnFreezeDays;

		// Token: 0x040074F9 RID: 29945
		private AuctionFreezeRemindData mAuctionFreezeRemindData;

		// Token: 0x040074FA RID: 29946
		private Button mClose;

		// Token: 0x040074FB RID: 29947
		private Text mText;

		// Token: 0x040074FC RID: 29948
		private Text mTerminationOfBailText;

		// Token: 0x040074FD RID: 29949
		private Text mExceptionTradHoursText;

		// Token: 0x040074FE RID: 29950
		private Text mRemainingOnBailText;

		// Token: 0x040074FF RID: 29951
		private Text mOne;

		// Token: 0x04007500 RID: 29952
		private Text mForeverBlank;

		// Token: 0x04007501 RID: 29953
		private Text mTwo;

		// Token: 0x04007502 RID: 29954
		private Text mRuleOne;

		// Token: 0x04007503 RID: 29955
		private Text mRuleTwo;

		// Token: 0x04007504 RID: 29956
		private ScrollRect mScroll;
	}
}
