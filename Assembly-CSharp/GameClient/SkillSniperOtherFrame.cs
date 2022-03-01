using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020010E2 RID: 4322
	public class SkillSniperOtherFrame : ClientFrame
	{
		// Token: 0x0600A3B1 RID: 41905 RVA: 0x00219450 File Offset: 0x00217850
		protected override void _bindExUI()
		{
			this.mTarget = this.mBind.GetCom<RectTransform>("Target");
			this.mFireAni = this.mBind.GetCom<DOTweenAnimation>("FireAni");
			this.mCloseAni = this.mBind.GetCom<DOTweenAnimation>("CloseAni");
			this.mShotEffect = this.mBind.GetCom<RectTransform>("ShotEffect");
		}

		// Token: 0x0600A3B2 RID: 41906 RVA: 0x002194B5 File Offset: 0x002178B5
		protected override void _unbindExUI()
		{
			this.mTarget = null;
			this.mFireAni = null;
			this.mCloseAni = null;
			this.mShotEffect = null;
		}

		// Token: 0x0600A3B3 RID: 41907 RVA: 0x002194D3 File Offset: 0x002178D3
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/SkillSniperOtherFrame";
		}

		// Token: 0x0600A3B4 RID: 41908 RVA: 0x002194DA File Offset: 0x002178DA
		public void QiangkouMove(Vector3 pos)
		{
			if (this.mTarget != null)
			{
				TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => this.mTarget.transform.localPosition, delegate(Vector3 r)
				{
					this.mTarget.transform.localPosition = r;
				}, pos, this.mPreMoveTime), 6);
			}
		}

		// Token: 0x0600A3B5 RID: 41909 RVA: 0x00219518 File Offset: 0x00217918
		public void Attack()
		{
			this.PlayAttackEffect();
		}

		// Token: 0x0600A3B6 RID: 41910 RVA: 0x00219520 File Offset: 0x00217920
		public RectTransform GetTargetParent()
		{
			return this.mTarget.parent as RectTransform;
		}

		// Token: 0x0600A3B7 RID: 41911 RVA: 0x00219534 File Offset: 0x00217934
		protected void PlayAttackEffect()
		{
			if (this.mShotEffect == null || Singleton<ClientSystemManager>.GetInstance() == null)
			{
				return;
			}
			this.mShotEffect.gameObject.CustomActive(true);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(300, delegate
			{
				if (this.mShotEffect != null)
				{
					this.mShotEffect.gameObject.CustomActive(false);
				}
			}, 0, 0, true);
		}

		// Token: 0x170019A4 RID: 6564
		// (get) Token: 0x0600A3B8 RID: 41912 RVA: 0x00219592 File Offset: 0x00217992
		public GameObject gameObject
		{
			get
			{
				return this.frame;
			}
		}

		// Token: 0x0600A3B9 RID: 41913 RVA: 0x0021959A File Offset: 0x0021799A
		public void PlayCloseAni()
		{
			if (this.mCloseAni != null)
			{
				this.mCloseAni.DORestartById("xiaoshi");
			}
		}

		// Token: 0x04005B59 RID: 23385
		private RectTransform mTarget;

		// Token: 0x04005B5A RID: 23386
		private DOTweenAnimation mFireAni;

		// Token: 0x04005B5B RID: 23387
		private DOTweenAnimation mCloseAni;

		// Token: 0x04005B5C RID: 23388
		private RectTransform mShotEffect;

		// Token: 0x04005B5D RID: 23389
		protected float mPreMoveTime = 0.2f;
	}
}
