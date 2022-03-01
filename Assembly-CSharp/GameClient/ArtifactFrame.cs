using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001436 RID: 5174
	public class ArtifactFrame : ClientFrame
	{
		// Token: 0x0600C8E4 RID: 51428 RVA: 0x0030D6D6 File Offset: 0x0030BAD6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ArtifactJar/ArtifactFrame";
		}

		// Token: 0x0600C8E5 RID: 51429 RVA: 0x0030D6E0 File Offset: 0x0030BAE0
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			if (ArtifactFrame.IsArtifactJarDiscountActivityOpen() && (ArtifactFrame.IsArtifactJarRewardActivityOpen() || ArtifactFrame.IsArtifactJarShowActivityOpen()))
			{
				this.SetShowContent(ArtifactFrame.MainTabType.MagicJarDiscount, ArtifactFrame.PrizeTabType.Invalid);
			}
			else if (ArtifactFrame.IsArtifactJarDiscountActivityOpen())
			{
				this.ToggleRecord.CustomActive(false);
				this.SetShowContent(ArtifactFrame.MainTabType.MagicJarDiscount, ArtifactFrame.PrizeTabType.Invalid);
			}
			else if (ArtifactFrame.IsArtifactJarRewardActivityOpen() || ArtifactFrame.IsArtifactJarShowActivityOpen())
			{
				this.ToggleMagicJar.CustomActive(false);
				this.SetShowContent(ArtifactFrame.MainTabType.PrizeRecord, ArtifactFrame.PrizeTabType.MyPrize);
			}
			else
			{
				this.ToggleMagicJar.CustomActive(false);
				this.ToggleRecord.CustomActive(false);
			}
			this._UpdateRewardToggleRedPoint();
			DataManager<ArtifactDataManager>.GetInstance().SendGASArtifactJarLotteryCfgReq();
		}

		// Token: 0x0600C8E6 RID: 51430 RVA: 0x0030D796 File Offset: 0x0030BB96
		protected override void _OnCloseFrame()
		{
			ActivityJarFrame.frameType = ActivityJarFrameType.Normal;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ArtifactJarDailyRewardFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ArtifactJarDailyRewardFrame>(null, false);
			}
			this.UnBindUIEvent();
		}

		// Token: 0x0600C8E7 RID: 51431 RVA: 0x0030D7C0 File Offset: 0x0030BBC0
		protected override void _bindExUI()
		{
			this.btnClose = this.mBind.GetCom<Button>("btnClose");
			this.btnClose.SafeAddOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActivityJarFrame>(null, false);
				this.frameMgr.CloseFrame<ArtifactFrame>(this, false);
			});
			this.ToggleMagicJar = this.mBind.GetCom<Toggle>("ToggleMagicJar");
			this.ToggleMagicJar.SafeAddOnValueChangedListener(delegate(bool bValue)
			{
				if (bValue)
				{
					this.mainType = ArtifactFrame.MainTabType.MagicJarDiscount;
					this.prizeType = ArtifactFrame.PrizeTabType.Invalid;
					this.UpdateMainTabContent();
					this.title.SafeSetText(TR.Value("artifactJar"));
					StaticUtility.SafeSetVisible(this.mBind, "Help1", true);
					StaticUtility.SafeSetVisible(this.mBind, "Help2", false);
				}
			});
			this.ToggleRecord = this.mBind.GetCom<Toggle>("ToggleRecord");
			this.ToggleRecord.SafeAddOnValueChangedListener(delegate(bool bValue)
			{
				if (bValue)
				{
					this.mRewardRedPoint.CustomActive(false);
					DataManager<ArtifactDataManager>.GetInstance().isArtifactRecordNew = false;
					this.mainType = ArtifactFrame.MainTabType.PrizeRecord;
					this.prizeType = ArtifactFrame.PrizeTabType.MyPrize;
					this.UpdateMainTabContent();
					this.title.SafeSetText(TR.Value("dailyAward"));
					this.UpdateMainTabContent();
					if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ArtifactJarDailyRewardFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<ArtifactJarDailyRewardFrame>(this.recordRoot, null, string.Empty);
					}
					DataManager<ArtifactDataManager>.GetInstance().SendArtifactJar();
					StaticUtility.SafeSetVisible(this.mBind, "Help1", false);
					StaticUtility.SafeSetVisible(this.mBind, "Help2", true);
				}
			});
			this.magicJarRoot = this.mBind.GetGameObject("magicJarRoot");
			this.recordRoot = this.mBind.GetGameObject("recordRoot");
			this.recordContent = this.mBind.GetGameObject("recordContent");
			this.title = this.mBind.GetCom<Text>("title");
			this.mRewardRedPoint = this.mBind.GetGameObject("RewardRedPoint");
		}

		// Token: 0x0600C8E8 RID: 51432 RVA: 0x0030D8C4 File Offset: 0x0030BCC4
		protected override void _unbindExUI()
		{
			this.btnClose = null;
			this.ToggleMagicJar = null;
			this.ToggleRecord = null;
			this.magicJarRoot = null;
			this.recordRoot = null;
			this.ToggleMyPrize = null;
			this.TogglePrizeRecord = null;
			this.recordContent = null;
			this.title = null;
			this.mRewardRedPoint = null;
		}

		// Token: 0x0600C8E9 RID: 51433 RVA: 0x0030D917 File Offset: 0x0030BD17
		private void BindUIEvent()
		{
		}

		// Token: 0x0600C8EA RID: 51434 RVA: 0x0030D919 File Offset: 0x0030BD19
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600C8EB RID: 51435 RVA: 0x0030D91B File Offset: 0x0030BD1B
		public void SetShowContent(ArtifactFrame.MainTabType mainTabType, ArtifactFrame.PrizeTabType prizeTabType)
		{
			this.mainType = mainTabType;
			this.prizeType = prizeTabType;
			this.ToggleMagicJar.SafeSetToggleOnState(mainTabType == ArtifactFrame.MainTabType.MagicJarDiscount);
			this.ToggleRecord.SafeSetToggleOnState(mainTabType == ArtifactFrame.MainTabType.PrizeRecord);
		}

		// Token: 0x0600C8EC RID: 51436 RVA: 0x0030D949 File Offset: 0x0030BD49
		private void SetShowPrizeRecord(ArtifactFrame.PrizeTabType prizeTab)
		{
			this.ToggleMyPrize.SafeSetToggleOnState(prizeTab == ArtifactFrame.PrizeTabType.MyPrize);
			this.TogglePrizeRecord.SafeSetToggleOnState(prizeTab == ArtifactFrame.PrizeTabType.Record);
		}

		// Token: 0x0600C8ED RID: 51437 RVA: 0x0030D96C File Offset: 0x0030BD6C
		private void UpdateMainTabContent()
		{
			this.magicJarRoot.CustomActive(this.mainType == ArtifactFrame.MainTabType.MagicJarDiscount);
			this.recordRoot.CustomActive(this.mainType == ArtifactFrame.MainTabType.PrizeRecord);
			if (this.mainType == ArtifactFrame.MainTabType.MagicJarDiscount)
			{
				if (this.magicJarRoot != null)
				{
					ActivityJarFrame.frameType = ActivityJarFrameType.Artifact;
					Singleton<ClientSystemManager>.instance.OpenFrame(typeof(ActivityJarFrame), this.magicJarRoot, null, string.Empty, FrameLayer.Invalid);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActivityJarFrame>(null, false);
			}
			if (this.mainType == ArtifactFrame.MainTabType.PrizeRecord)
			{
				this.SetShowPrizeRecord(this.prizeType);
			}
		}

		// Token: 0x0600C8EE RID: 51438 RVA: 0x0030DA0E File Offset: 0x0030BE0E
		private void _UpdateRewardToggleRedPoint()
		{
			if (DataManager<ArtifactDataManager>.GetInstance().isArtifactRecordNew)
			{
				this.mRewardRedPoint.CustomActive(true);
			}
			else
			{
				this.mRewardRedPoint.CustomActive(false);
			}
		}

		// Token: 0x0600C8EF RID: 51439 RVA: 0x0030DA3C File Offset: 0x0030BE3C
		public static bool IsArtifactJarShowActivityOpen()
		{
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_ARTIFACT_JAR_SHOW);
			return activeDataFromType != null && activeDataFromType.state == 1;
		}

		// Token: 0x0600C8F0 RID: 51440 RVA: 0x0030DA6C File Offset: 0x0030BE6C
		public static bool IsArtifactJarDiscountActivityOpen()
		{
			if (DataManager<ArtifactDataManager>.GetInstance() == null)
			{
				return false;
			}
			OpActivityData artifactJarActData = DataManager<ArtifactDataManager>.GetInstance().getArtifactJarActData();
			return artifactJarActData != null && artifactJarActData.state == 1;
		}

		// Token: 0x0600C8F1 RID: 51441 RVA: 0x0030DAA4 File Offset: 0x0030BEA4
		public static bool IsArtifactJarRewardActivityOpen()
		{
			if (DataManager<ArtifactDataManager>.GetInstance() == null)
			{
				return false;
			}
			OpActivityData artifactAwardActData = DataManager<ArtifactDataManager>.GetInstance().getArtifactAwardActData();
			return artifactAwardActData != null && artifactAwardActData.state == 1;
		}

		// Token: 0x040073DC RID: 29660
		private ArtifactFrame.MainTabType mainType;

		// Token: 0x040073DD RID: 29661
		private ArtifactFrame.PrizeTabType prizeType;

		// Token: 0x040073DE RID: 29662
		private Button btnClose;

		// Token: 0x040073DF RID: 29663
		private Toggle ToggleMagicJar;

		// Token: 0x040073E0 RID: 29664
		private Toggle ToggleRecord;

		// Token: 0x040073E1 RID: 29665
		private GameObject magicJarRoot;

		// Token: 0x040073E2 RID: 29666
		private GameObject recordRoot;

		// Token: 0x040073E3 RID: 29667
		private Toggle ToggleMyPrize;

		// Token: 0x040073E4 RID: 29668
		private Toggle TogglePrizeRecord;

		// Token: 0x040073E5 RID: 29669
		private GameObject recordContent;

		// Token: 0x040073E6 RID: 29670
		private Text title;

		// Token: 0x040073E7 RID: 29671
		private GameObject mRewardRedPoint;

		// Token: 0x02001437 RID: 5175
		public enum MainTabType
		{
			// Token: 0x040073E9 RID: 29673
			MagicJarDiscount,
			// Token: 0x040073EA RID: 29674
			PrizeRecord
		}

		// Token: 0x02001438 RID: 5176
		public enum PrizeTabType
		{
			// Token: 0x040073EC RID: 29676
			Invalid,
			// Token: 0x040073ED RID: 29677
			MyPrize,
			// Token: 0x040073EE RID: 29678
			Record
		}
	}
}
