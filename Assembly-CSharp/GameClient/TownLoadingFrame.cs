using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E5E RID: 3678
	internal class TownLoadingFrame : ClientFrame, ITownFadingFrame
	{
		// Token: 0x170018F3 RID: 6387
		// (get) Token: 0x06009219 RID: 37401 RVA: 0x001B18DA File Offset: 0x001AFCDA
		public int CurrentProgress
		{
			get
			{
				return this.mCurrentProgress;
			}
		}

		// Token: 0x0600921A RID: 37402 RVA: 0x001B18E4 File Offset: 0x001AFCE4
		protected override void _OnOpenFrame()
		{
			this.mUpdateSpeed = Global.Settings.loadingProgressStep;
			this.mTargetProgress = 0;
			this.mCurrentProgress = -1;
			this.mFadeInTime = 0f;
			this.mFadeOutTime = 0f;
			this.mMaxWaitingTime = 10f;
			this._randomTips();
			base.StartCoroutine(this._updateProgress());
		}

		// Token: 0x0600921B RID: 37403 RVA: 0x001B1943 File Offset: 0x001AFD43
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/TownLoadingFrame";
		}

		// Token: 0x0600921C RID: 37404 RVA: 0x001B194C File Offset: 0x001AFD4C
		private void _randomTips()
		{
			int tableItemCount = Singleton<TableManager>.GetInstance().GetTableItemCount<TipsTable>();
			int iIndex = Random.Range(1, tableItemCount);
			TipsTable tableItemByIndex = Singleton<TableManager>.GetInstance().GetTableItemByIndex<TipsTable>(iIndex);
			if (tableItemByIndex != null)
			{
				this.tipsText.text = "温馨提示:" + tableItemByIndex.ObjectName;
			}
		}

		// Token: 0x0600921D RID: 37405 RVA: 0x001B199C File Offset: 0x001AFD9C
		protected IEnumerator _updateProgress()
		{
			while (this.mTargetProgress <= 100)
			{
				while (this.mCurrentProgress < this.mTargetProgress)
				{
					this.mCurrentProgress += this.mUpdateSpeed;
					if (this.mCurrentProgress > this.mTargetProgress)
					{
						this.mCurrentProgress = this.mTargetProgress;
					}
					this._setProgress(this.mCurrentProgress);
					yield return Yielders.EndOfFrame;
				}
				if (this.mTargetProgress == 100 && this._IsLoadingFinished())
				{
					yield return MonoSingleton<GameFrameWork>.instance.OpenFadeFrame(delegate
					{
						this.frameMgr.CloseFrame<TownLoadingFrame>(this, false);
					}, delegate
					{
					}, null, 0.4f, 0.6f);
					break;
				}
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x0600921E RID: 37406 RVA: 0x001B19B7 File Offset: 0x001AFDB7
		protected void _setProgress(int progress)
		{
			if (progress < 0)
			{
				progress = 0;
			}
			if (progress > 100)
			{
				progress = 100;
			}
			this.loadProcess.value = (float)progress / 100f;
		}

		// Token: 0x0600921F RID: 37407 RVA: 0x001B19E2 File Offset: 0x001AFDE2
		public void FadingOut(float fadeOutTime)
		{
			this.m_state = EFrameState.FadeOut;
			this.mFadeOutTime = fadeOutTime;
			this.mTargetProgress = 85;
		}

		// Token: 0x06009220 RID: 37408 RVA: 0x001B19FA File Offset: 0x001AFDFA
		public void FadingIn(float fadeInTime)
		{
			this.m_state = EFrameState.FadeIn;
			this.mFadeInTime = fadeInTime;
			this.mTargetProgress = 20;
		}

		// Token: 0x06009221 RID: 37409 RVA: 0x001B1A12 File Offset: 0x001AFE12
		public bool IsClosed()
		{
			return this.m_state == EFrameState.Close;
		}

		// Token: 0x06009222 RID: 37410 RVA: 0x001B1A1D File Offset: 0x001AFE1D
		public bool IsOpened()
		{
			return this.m_state == EFrameState.Open;
		}

		// Token: 0x06009223 RID: 37411 RVA: 0x001B1A28 File Offset: 0x001AFE28
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06009224 RID: 37412 RVA: 0x001B1A2B File Offset: 0x001AFE2B
		public void AddCheckActor(BeBaseActor actor)
		{
			this.m_LoadingCheck.Add(actor);
		}

		// Token: 0x06009225 RID: 37413 RVA: 0x001B1A3C File Offset: 0x001AFE3C
		private bool _IsLoadingFinished()
		{
			bool flag = true;
			int i = 0;
			int count = this.m_LoadingCheck.Count;
			while (i < count)
			{
				BeBaseActor beBaseActor = this.m_LoadingCheck[i];
				if (beBaseActor != null && beBaseActor.GraphicActor != null)
				{
					flag = ((!flag) ? flag : beBaseActor.GraphicActor.IsAvatarLoadFinished());
				}
				i++;
			}
			if (this.mMaxWaitingTime <= 0f)
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x06009226 RID: 37414 RVA: 0x001B1AB4 File Offset: 0x001AFEB4
		protected override void _OnUpdate(float timeElapsed)
		{
			this.mMaxWaitingTime -= timeElapsed;
			EFrameState state = this.m_state;
			if (state != EFrameState.FadeIn)
			{
				if (state == EFrameState.FadeOut)
				{
					this.mFadeOutTime -= timeElapsed;
					if (this.mFadeOutTime < 0f)
					{
						this.mTargetProgress = 100;
					}
				}
			}
			else
			{
				this.mFadeInTime -= timeElapsed;
				if (this.mFadeInTime < 0f)
				{
					this.m_state = EFrameState.Open;
					this.mTargetProgress = 60;
				}
			}
		}

		// Token: 0x04004925 RID: 18725
		protected int mUpdateSpeed = 10;

		// Token: 0x04004926 RID: 18726
		protected int mTargetProgress;

		// Token: 0x04004927 RID: 18727
		protected int mCurrentProgress = -1;

		// Token: 0x04004928 RID: 18728
		protected float mFadeOutTime;

		// Token: 0x04004929 RID: 18729
		protected float mFadeInTime;

		// Token: 0x0400492A RID: 18730
		protected List<BeBaseActor> m_LoadingCheck = new List<BeBaseActor>();

		// Token: 0x0400492B RID: 18731
		protected float mMaxWaitingTime = 10f;

		// Token: 0x0400492C RID: 18732
		[UIControl("loading", null, 0)]
		private Slider loadProcess;

		// Token: 0x0400492D RID: 18733
		[UIControl("loadText", null, 0)]
		private Text tipsText;
	}
}
