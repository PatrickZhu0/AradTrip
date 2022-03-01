using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020019CD RID: 6605
	public class ComRandomTreasureUIFade : MonoBehaviour
	{
		// Token: 0x060102BA RID: 66234 RVA: 0x00482188 File Offset: 0x00480588
		private void Update()
		{
			if (!this.bDirty)
			{
				return;
			}
			if (this.mMapsContentRootRect == null || this.mAnimCurve == null)
			{
				return;
			}
			if (this.bHeightDoAnim)
			{
				if (this.mAnimTimer > this.mAnimTotalTime)
				{
					this.bDirty = false;
					this.mAnimTimer = 0f;
					this._ExecuteFadeEndHandler();
					this._RecoverAtlasRect();
					return;
				}
				if (this.bShow)
				{
					this.mRectCurrentHeight = this.mAnimCurve.Evaluate(this.mAnimTimer / this.mAnimTotalTime) * this.mRectOriginalHeight;
				}
				else
				{
					this.mRectCurrentHeight = this.mRectOriginalHeight - this.mAnimCurve.Evaluate(this.mAnimTimer / this.mAnimTotalTime) * this.mRectOriginalHeight;
				}
				this.mMapsContentRootRect.sizeDelta = new Vector2(this.mRectOriginalWidth, this.mRectCurrentHeight);
			}
			else
			{
				if (this.mAnimTimer > this.mAnimTotalTime)
				{
					this.bDirty = false;
					this.mAnimTimer = 0f;
					this._ExecuteFadeEndHandler();
					this._RecoverAtlasRect();
					return;
				}
				if (this.bShow)
				{
					this.mRectCurrentWidth = this.mAnimCurve.Evaluate(this.mAnimTimer / this.mAnimTotalTime) * this.mRectOriginalWidth;
				}
				else
				{
					this.mRectCurrentWidth = this.mRectOriginalWidth - this.mAnimCurve.Evaluate(this.mAnimTimer / this.mAnimTotalTime) * this.mRectOriginalWidth;
				}
				this.mMapsContentRootRect.sizeDelta = new Vector2(this.mRectCurrentWidth, this.mRectOriginalHeight);
			}
			this.mAnimTimer += Time.deltaTime * this.mAnimTotalTime * this.mAnimSpeed;
		}

		// Token: 0x060102BB RID: 66235 RVA: 0x00482348 File Offset: 0x00480748
		private void OnDestroy()
		{
			this.fadeInStart = null;
			this.fadeInEnd = null;
			this.fadeOutStart = null;
			this.fadeOutEnd = null;
			this._Clear();
		}

		// Token: 0x060102BC RID: 66236 RVA: 0x0048236C File Offset: 0x0048076C
		private void _Clear()
		{
			this.mMapsContentRootRect = null;
			this.mRectOriginalHeight = 0f;
			this.mRectOriginalWidth = 0f;
			this.mRectCurrentHeight = 0f;
			this.mRectCurrentWidth = 0f;
			this.bShow = false;
			this.bDirty = false;
			this.mAnimCurveLastKey = default(Keyframe);
			this.mAnimTimer = 0f;
			this.mAnimTotalTime = 0f;
			if (this.waitToCloseAtlas != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToCloseAtlas);
				this.waitToCloseAtlas = null;
			}
			if (this.waitToOpenAtlas != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToOpenAtlas);
				this.waitToOpenAtlas = null;
			}
			this.bInited = false;
		}

		// Token: 0x060102BD RID: 66237 RVA: 0x0048242A File Offset: 0x0048082A
		private void _ShowAtlasRectAnim(bool bShow)
		{
			if (this.bShow != bShow)
			{
				this.bDirty = true;
				this.bShow = bShow;
				this._ExecuteFadeStartHandler();
			}
		}

		// Token: 0x060102BE RID: 66238 RVA: 0x0048244C File Offset: 0x0048084C
		private void _ExecuteFadeEndHandler()
		{
			if (this.bShow)
			{
				if (this.fadeOutEnd != null)
				{
					this.fadeOutEnd.Invoke();
				}
			}
			else if (this.fadeInEnd != null)
			{
				this.fadeInEnd.Invoke();
			}
		}

		// Token: 0x060102BF RID: 66239 RVA: 0x0048248A File Offset: 0x0048088A
		private void _ExecuteFadeStartHandler()
		{
			if (this.bShow)
			{
				if (this.fadeOutStart != null)
				{
					this.fadeOutStart.Invoke();
				}
			}
			else if (this.fadeInStart != null)
			{
				this.fadeInStart.Invoke();
			}
		}

		// Token: 0x060102C0 RID: 66240 RVA: 0x004824C8 File Offset: 0x004808C8
		private void _RestartAtlasRect(bool toShow)
		{
			this.mRectCurrentWidth = this.mRectOriginalWidth;
			this.mRectCurrentHeight = this.mRectOriginalHeight;
			if (this.bHeightDoAnim)
			{
				if (toShow)
				{
					this.mRectCurrentHeight = 0.1f;
				}
			}
			else if (toShow)
			{
				this.mRectCurrentWidth = 0.1f;
			}
			if (this.mMapsContentRootRect)
			{
				this.mMapsContentRootRect.sizeDelta = new Vector2(this.mRectCurrentWidth, this.mRectCurrentHeight);
			}
		}

		// Token: 0x060102C1 RID: 66241 RVA: 0x0048254C File Offset: 0x0048094C
		private void _RecoverAtlasRect()
		{
			if (this.bHeightDoAnim)
			{
				if (this.bShow)
				{
					this.mRectCurrentHeight = this.mRectOriginalHeight;
				}
				else
				{
					this.mRectCurrentHeight = 0f;
				}
				if (this.mMapsContentRootRect)
				{
					this.mMapsContentRootRect.sizeDelta = new Vector2(this.mRectOriginalWidth, this.mRectCurrentHeight);
				}
			}
			else
			{
				if (this.bShow)
				{
					this.mRectCurrentWidth = this.mRectOriginalWidth;
				}
				else
				{
					this.mRectCurrentWidth = 0f;
				}
				if (this.mMapsContentRootRect)
				{
					this.mMapsContentRootRect.sizeDelta = new Vector2(this.mRectCurrentWidth, this.mRectOriginalHeight);
				}
			}
		}

		// Token: 0x060102C2 RID: 66242 RVA: 0x0048260F File Offset: 0x00480A0F
		private void _OnFadeInStart()
		{
		}

		// Token: 0x060102C3 RID: 66243 RVA: 0x00482611 File Offset: 0x00480A11
		private void _OnFadeOutStart()
		{
		}

		// Token: 0x060102C4 RID: 66244 RVA: 0x00482613 File Offset: 0x00480A13
		private void _OnFadeInEnd()
		{
		}

		// Token: 0x060102C5 RID: 66245 RVA: 0x00482615 File Offset: 0x00480A15
		private void _OnFadeOutEnd()
		{
		}

		// Token: 0x060102C6 RID: 66246 RVA: 0x00482617 File Offset: 0x00480A17
		private void _ReadyOpenAtlas()
		{
			this._RestartAtlasRect(true);
			this._ShowAtlasRectAnim(true);
		}

		// Token: 0x060102C7 RID: 66247 RVA: 0x00482627 File Offset: 0x00480A27
		private void _ReadyCloseAtlas()
		{
			this._RestartAtlasRect(false);
			this._ShowAtlasRectAnim(false);
		}

		// Token: 0x060102C8 RID: 66248 RVA: 0x00482638 File Offset: 0x00480A38
		private IEnumerator _WaitToOpenAtlas()
		{
			if (this.mAnimOpenDelay <= 0f)
			{
				this._ReadyOpenAtlas();
				yield break;
			}
			yield return new WaitForSecondsRealtime(this.mAnimOpenDelay);
			this._ReadyOpenAtlas();
			yield break;
		}

		// Token: 0x060102C9 RID: 66249 RVA: 0x00482654 File Offset: 0x00480A54
		private IEnumerator _WaitToCloseAtlas()
		{
			if (this.mAnimCloseDelay <= 0f)
			{
				this._ReadyCloseAtlas();
				yield break;
			}
			yield return new WaitForSecondsRealtime(this.mAnimCloseDelay);
			this._ReadyCloseAtlas();
			yield break;
		}

		// Token: 0x060102CA RID: 66250 RVA: 0x00482670 File Offset: 0x00480A70
		public void InitView()
		{
			if (this.bInited)
			{
				return;
			}
			if (this.mMapsContentRoot)
			{
				this.mMapsContentRootRect = this.mMapsContentRoot.GetComponent<RectTransform>();
				if (this.mMapsContentRootRect)
				{
					this.mRectOriginalHeight = this.mMapsContentRootRect.sizeDelta.y;
					this.mRectOriginalWidth = this.mMapsContentRootRect.sizeDelta.x;
				}
			}
			if (this.mAnimCurve != null && this.mAnimCurve.length > 0)
			{
				this.mAnimCurveLastKey = this.mAnimCurve[this.mAnimCurve.length - 1];
				this.mAnimTotalTime = this.mAnimCurveLastKey.time;
			}
			this._RestartAtlasRect(true);
			this.bInited = true;
		}

		// Token: 0x060102CB RID: 66251 RVA: 0x00482748 File Offset: 0x00480B48
		public void StartOpenAtlas(UnityAction openAtlasStart, UnityAction openAtlasEnd, bool bDelay = false)
		{
			this.fadeOutStart = openAtlasStart;
			this.fadeOutEnd = openAtlasEnd;
			if (bDelay)
			{
				if (this.waitToOpenAtlas != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToOpenAtlas);
				}
				this.waitToOpenAtlas = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToOpenAtlas());
			}
			else
			{
				this._ReadyOpenAtlas();
			}
		}

		// Token: 0x060102CC RID: 66252 RVA: 0x004827A8 File Offset: 0x00480BA8
		public void StartCloseAtlas(UnityAction closeAtlasStart, UnityAction closeAtlasEnd, bool bDelay = false)
		{
			this.fadeInStart = closeAtlasStart;
			this.fadeInEnd = closeAtlasEnd;
			if (bDelay)
			{
				if (this.waitToCloseAtlas != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToCloseAtlas);
				}
				this.waitToCloseAtlas = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToCloseAtlas());
			}
			else
			{
				this._ReadyCloseAtlas();
			}
		}

		// Token: 0x0400A377 RID: 41847
		private UnityAction fadeInStart;

		// Token: 0x0400A378 RID: 41848
		private UnityAction fadeInEnd;

		// Token: 0x0400A379 RID: 41849
		private UnityAction fadeOutStart;

		// Token: 0x0400A37A RID: 41850
		private UnityAction fadeOutEnd;

		// Token: 0x0400A37B RID: 41851
		private bool bInited;

		// Token: 0x0400A37C RID: 41852
		[SerializeField]
		private GameObject mMapsContentRoot;

		// Token: 0x0400A37D RID: 41853
		[Header("保持Y值最大为1，只调整X轴作为动画时间")]
		[SerializeField]
		private AnimationCurve mAnimCurve;

		// Token: 0x0400A37E RID: 41854
		[SerializeField]
		private float mAnimSpeed = 1f;

		// Token: 0x0400A37F RID: 41855
		[SerializeField]
		private bool bHeightDoAnim = true;

		// Token: 0x0400A380 RID: 41856
		[SerializeField]
		private float mAnimOpenDelay;

		// Token: 0x0400A381 RID: 41857
		[SerializeField]
		private float mAnimCloseDelay;

		// Token: 0x0400A382 RID: 41858
		private RectTransform mMapsContentRootRect;

		// Token: 0x0400A383 RID: 41859
		private float mRectOriginalHeight;

		// Token: 0x0400A384 RID: 41860
		private float mRectOriginalWidth;

		// Token: 0x0400A385 RID: 41861
		private float mRectCurrentHeight;

		// Token: 0x0400A386 RID: 41862
		private float mRectCurrentWidth;

		// Token: 0x0400A387 RID: 41863
		private bool bShow;

		// Token: 0x0400A388 RID: 41864
		private bool bDirty;

		// Token: 0x0400A389 RID: 41865
		private Keyframe mAnimCurveLastKey = default(Keyframe);

		// Token: 0x0400A38A RID: 41866
		private float mAnimTimer;

		// Token: 0x0400A38B RID: 41867
		private float mAnimTotalTime;

		// Token: 0x0400A38C RID: 41868
		private Coroutine waitToCloseAtlas;

		// Token: 0x0400A38D RID: 41869
		private Coroutine waitToOpenAtlas;
	}
}
