using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Token: 0x0200153E RID: 5438
public class ComChapterSelectAnimate : MonoBehaviour
{
	// Token: 0x0600D46A RID: 54378 RVA: 0x0034FED8 File Offset: 0x0034E2D8
	public IEnumerator NormalAnimate(RectTransform targetPos)
	{
		yield return Yielders.GetWaitForSeconds(this.animateDelayTime);
		if (this.hiddenRoots != null)
		{
			for (int i = 0; i < this.hiddenRoots.Length; i++)
			{
				if (this.hiddenRoots[i] != null)
				{
					this.hiddenRoots[i].alpha = 0f;
				}
				yield return null;
				yield return null;
				yield return null;
			}
		}
		if (null != this.animateTarget)
		{
			TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => this.animateTarget.localScale, delegate(Vector3 v)
			{
				this.animateTarget.localScale = v;
			}, this.animateScale * Vector3.one, this.animateTime), this.animateScaleIn);
			TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => this.animateTarget.localPosition, delegate(Vector3 v)
			{
				this.animateTarget.localPosition = v;
			}, this._convert2Position(targetPos), this.animateTime), this.animateMoveIn);
			this._updatePovit(targetPos);
		}
		yield return Yielders.GetWaitForSeconds(this.animateTime);
		yield break;
	}

	// Token: 0x0600D46B RID: 54379 RVA: 0x0034FEFC File Offset: 0x0034E2FC
	public void NormalAnimateWithAction(RectTransform targetPos)
	{
		if (this.hiddenRoots != null)
		{
			for (int i = 0; i < this.hiddenRoots.Length; i++)
			{
				if (this.hiddenRoots[i] != null)
				{
					this.hiddenRoots[i].alpha = 0f;
				}
			}
		}
		if (null != this.animateTarget)
		{
			this.animateTarget.localScale = this.animateScale * Vector3.one;
			this.animateTarget.localPosition = this._convert2Position(targetPos);
		}
		this._updatePovit(targetPos);
	}

	// Token: 0x0600D46C RID: 54380 RVA: 0x0034FF98 File Offset: 0x0034E398
	private void _updatePovit(RectTransform targetPos)
	{
		Vector3 localPosition = targetPos.localPosition;
		Vector2 pivot;
		pivot..ctor(localPosition.x / this._getWidth() + 0.5f, localPosition.y / this._getHeight() + 0.5f);
		this.animateTarget.pivot = pivot;
	}

	// Token: 0x0600D46D RID: 54381 RVA: 0x0034FFE7 File Offset: 0x0034E3E7
	private float _getWidth()
	{
		return 1920f;
	}

	// Token: 0x0600D46E RID: 54382 RVA: 0x0034FFEE File Offset: 0x0034E3EE
	private float _getHeight()
	{
		return 1080f;
	}

	// Token: 0x0600D46F RID: 54383 RVA: 0x0034FFF5 File Offset: 0x0034E3F5
	private Vector3 _convert2Position(RectTransform targetPos)
	{
		return this.positionTarget.localPosition;
	}

	// Token: 0x0600D470 RID: 54384 RVA: 0x00350004 File Offset: 0x0034E404
	public IEnumerator RevertAnimate()
	{
		if (this.animateTarget != null)
		{
			this.animateTarget.pivot = 0.5f * Vector2.one;
			TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => this.animateTarget.localScale, delegate(Vector3 v)
			{
				this.animateTarget.localScale = v;
			}, Vector3.one, this.animateTime), this.animateScaleOut);
			TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => this.animateTarget.localPosition, delegate(Vector3 v)
			{
				this.animateTarget.localPosition = v;
			}, Vector3.zero, this.animateTime), this.animateMoveOut);
			yield return Yielders.GetWaitForSeconds(this.animateTime);
			if (this.hiddenRoots != null)
			{
				for (int i = this.hiddenRoots.Length - 1; i >= 0; i--)
				{
					if (this.hiddenRoots[i] != null)
					{
						this.hiddenRoots[i].alpha = 1f;
					}
					yield return null;
					yield return null;
					yield return null;
				}
			}
		}
		yield break;
	}

	// Token: 0x04007C91 RID: 31889
	public RectTransform positionTarget;

	// Token: 0x04007C92 RID: 31890
	public RectTransform animateTarget;

	// Token: 0x04007C93 RID: 31891
	public CanvasGroup[] hiddenRoots;

	// Token: 0x04007C94 RID: 31892
	public float animateDelayTime = 1f;

	// Token: 0x04007C95 RID: 31893
	public float animateTime = 1f;

	// Token: 0x04007C96 RID: 31894
	public float animateScale = 2f;

	// Token: 0x04007C97 RID: 31895
	public AnimationCurve animateScaleIn;

	// Token: 0x04007C98 RID: 31896
	public AnimationCurve animateScaleOut;

	// Token: 0x04007C99 RID: 31897
	public AnimationCurve animateMoveIn;

	// Token: 0x04007C9A RID: 31898
	public AnimationCurve animateMoveOut;
}
