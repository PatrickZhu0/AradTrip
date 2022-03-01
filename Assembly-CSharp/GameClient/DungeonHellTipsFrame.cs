using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020010A8 RID: 4264
	public class DungeonHellTipsFrame : ClientFrame
	{
		// Token: 0x0600A0CC RID: 41164 RVA: 0x00207ABF File Offset: 0x00205EBF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Hell/DungeonHellTips";
		}

		// Token: 0x0600A0CD RID: 41165 RVA: 0x00207AC8 File Offset: 0x00205EC8
		protected override void _bindExUI()
		{
			this.mDamnDescRoot = this.mBind.GetGameObject("damnDescRoot");
			this.mNormalDescRoot = this.mBind.GetGameObject("normalDescRoot");
			this.mHardTitleRoot = this.mBind.GetGameObject("hardTitleRoot");
			this.mDamnHardTitleRoot = this.mBind.GetGameObject("damnHardTitleRoot");
			this.mBg = this.mBind.GetGameObject("Bg1");
			this.mBg1 = this.mBind.GetGameObject("Bg2");
			this.mBg2 = this.mBind.GetGameObject("Bg3");
			this.mVeryHardBottom = this.mBind.GetGameObject("VeryHardBottom");
			this.mVeryHardMiddle = this.mBind.GetGameObject("VeryHardMiddle");
			this.mVeryHardTop = this.mBind.GetGameObject("VeryHardTop");
			this.mVeryHardTitle = this.mBind.GetGameObject("VeryHardTitleRoot");
			this.mNormalMiddle = this.mBind.GetGameObject("NormalMiddle");
			this.mNormalSlogan = this.mBind.GetGameObject("NormalSlogan");
			this.mNormalTitleRoot = this.mBind.GetGameObject("NormalTitleRoot");
			this.mUIRoot = this.mBind.GetGameObject("UIRoot");
			this.mEffectRoot = this.mBind.GetGameObject("EffectRoot");
		}

		// Token: 0x0600A0CE RID: 41166 RVA: 0x00207C38 File Offset: 0x00206038
		protected override void _unbindExUI()
		{
			this.mNormalSlogan = null;
			this.mDamnDescRoot = null;
			this.mNormalDescRoot = null;
			this.mHardTitleRoot = null;
			this.mDamnHardTitleRoot = null;
			this.mBg = null;
			this.mBg1 = null;
			this.mBg2 = null;
			this.mVeryHardBottom = null;
			this.mVeryHardMiddle = null;
			this.mVeryHardTop = null;
			this.mVeryHardTitle = null;
			this.mNormalMiddle = null;
			this.mNormalTitleRoot = null;
			this.mUIRoot = null;
			this.mEffectRoot = null;
		}

		// Token: 0x0600A0CF RID: 41167 RVA: 0x00207CB5 File Offset: 0x002060B5
		public void HideUI()
		{
			if (this.mUIRoot != null)
			{
				this.mUIRoot.SetActive(false);
			}
		}

		// Token: 0x0600A0D0 RID: 41168 RVA: 0x00207CD4 File Offset: 0x002060D4
		public void ShowEffect()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_Shenyuan/Prefab/EffUI_Shenyuan_03", true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, this.frame, false);
			}
			this.mUIEffect = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_Shenyuan/Prefab/EffUI_Shenyuan_di", true, 0U);
			if (this.mUIEffect != null)
			{
				Utility.AttachTo(this.mUIEffect, this.mEffectRoot, false);
			}
		}

		// Token: 0x0600A0D1 RID: 41169 RVA: 0x00207D48 File Offset: 0x00206148
		public void SetHellType(DungeonHellMode mode)
		{
			this.mDamnDescRoot.SetActive(false);
			this.mNormalDescRoot.SetActive(false);
			this.mHardTitleRoot.SetActive(false);
			this.mDamnHardTitleRoot.SetActive(false);
			switch (mode)
			{
			case DungeonHellMode.Null:
			case DungeonHellMode.Normal:
				this.mNormalDescRoot.SetActive(true);
				this.mHardTitleRoot.SetActive(true);
				break;
			case DungeonHellMode.Hard:
				this.mDamnDescRoot.SetActive(true);
				this.mDamnHardTitleRoot.SetActive(true);
				break;
			case DungeonHellMode.Hard_Ultimate:
				if (this.mNormalSlogan != null)
				{
					this.mNormalSlogan.SetActive(false);
				}
				if (this.mNormalTitleRoot != null)
				{
					this.mNormalTitleRoot.SetActive(false);
				}
				if (this.mNormalMiddle != null)
				{
					this.mNormalMiddle.SetActive(false);
				}
				if (this.mBg != null)
				{
					this.mBg.SetActive(false);
				}
				if (this.mBg1 != null)
				{
					this.mBg1.SetActive(false);
				}
				if (this.mBg2 != null)
				{
					this.mBg2.SetActive(false);
				}
				if (this.mVeryHardBottom != null)
				{
					this.mVeryHardBottom.SetActive(true);
				}
				if (this.mVeryHardMiddle != null)
				{
					this.mVeryHardMiddle.SetActive(true);
				}
				if (this.mVeryHardTop != null)
				{
					this.mVeryHardTop.SetActive(true);
				}
				if (this.mVeryHardTitle != null)
				{
					this.mVeryHardTitle.SetActive(true);
				}
				if (this.mEffectRoot != null)
				{
					this.mEffectRoot.SetActive(true);
				}
				break;
			}
		}

		// Token: 0x0400594C RID: 22860
		private GameObject mDamnDescRoot;

		// Token: 0x0400594D RID: 22861
		private GameObject mNormalDescRoot;

		// Token: 0x0400594E RID: 22862
		private GameObject mHardTitleRoot;

		// Token: 0x0400594F RID: 22863
		private GameObject mDamnHardTitleRoot;

		// Token: 0x04005950 RID: 22864
		private GameObject mBg;

		// Token: 0x04005951 RID: 22865
		private GameObject mBg1;

		// Token: 0x04005952 RID: 22866
		private GameObject mBg2;

		// Token: 0x04005953 RID: 22867
		private GameObject mVeryHardBottom;

		// Token: 0x04005954 RID: 22868
		private GameObject mVeryHardMiddle;

		// Token: 0x04005955 RID: 22869
		private GameObject mVeryHardTop;

		// Token: 0x04005956 RID: 22870
		private GameObject mVeryHardTitle;

		// Token: 0x04005957 RID: 22871
		private GameObject mNormalMiddle;

		// Token: 0x04005958 RID: 22872
		private GameObject mNormalTitleRoot;

		// Token: 0x04005959 RID: 22873
		private GameObject mUIRoot;

		// Token: 0x0400595A RID: 22874
		private GameObject mUIEffect;

		// Token: 0x0400595B RID: 22875
		private GameObject mEffectRoot;

		// Token: 0x0400595C RID: 22876
		private GameObject mNormalSlogan;
	}
}
