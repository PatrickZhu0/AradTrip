using System;
using System.Collections.Generic;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
	// Token: 0x020048C2 RID: 18626
	[AddComponentMenu("DOTween/DOTween Animation")]
	public class DOTweenAnimation : ABSAnimationComponent
	{
		// Token: 0x0601ACBE RID: 109758 RVA: 0x0083D893 File Offset: 0x0083BC93
		private void Awake()
		{
			if (!this.isActive || !this.isValid)
			{
				return;
			}
			this.CreateTween();
		}

		// Token: 0x0601ACBF RID: 109759 RVA: 0x0083D8B2 File Offset: 0x0083BCB2
		private void OnDestroy()
		{
			if (this.tween != null && TweenExtensions.IsActive(this.tween))
			{
				TweenExtensions.Kill(this.tween, false);
			}
			this.tween = null;
		}

		// Token: 0x0601ACC0 RID: 109760 RVA: 0x0083D8E4 File Offset: 0x0083BCE4
		public void CreateTween()
		{
			if (this.target == null)
			{
				return;
			}
			Type type = this.target.GetType();
			switch (this.animationType)
			{
			case 1:
				if (type.IsSameOrSubclassOf(typeof(RectTransform)))
				{
					this.tween = ShortcutExtensions46.DOAnchorPos3D((RectTransform)this.target, this.endValueV3, this.duration, this.optionalBool0);
				}
				else if (type.IsSameOrSubclassOf(typeof(Transform)))
				{
					this.tween = ShortcutExtensions.DOMove((Transform)this.target, this.endValueV3, this.duration, this.optionalBool0);
				}
				else if (type.IsSameOrSubclassOf(typeof(Rigidbody2D)))
				{
					this.tween = ShortcutExtensions43.DOMove((Rigidbody2D)this.target, this.endValueV3, this.duration, this.optionalBool0);
				}
				else if (type.IsSameOrSubclassOf(typeof(Rigidbody)))
				{
					this.tween = ShortcutExtensions.DOMove((Rigidbody)this.target, this.endValueV3, this.duration, this.optionalBool0);
				}
				break;
			case 2:
				this.tween = ShortcutExtensions.DOLocalMove(base.transform, this.endValueV3, this.duration, this.optionalBool0);
				break;
			case 3:
				if (type.IsSameOrSubclassOf(typeof(Transform)))
				{
					this.tween = ShortcutExtensions.DORotate((Transform)this.target, this.endValueV3, this.duration, this.optionalRotationMode);
				}
				else if (type.IsSameOrSubclassOf(typeof(Rigidbody2D)))
				{
					this.tween = ShortcutExtensions43.DORotate((Rigidbody2D)this.target, this.endValueFloat, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Rigidbody)))
				{
					this.tween = ShortcutExtensions.DORotate((Rigidbody)this.target, this.endValueV3, this.duration, this.optionalRotationMode);
				}
				break;
			case 4:
				this.tween = ShortcutExtensions.DOLocalRotate(base.transform, this.endValueV3, this.duration, this.optionalRotationMode);
				break;
			case 5:
				this.tween = ShortcutExtensions.DOScale(base.transform, (!this.optionalBool0) ? this.endValueV3 : new Vector3(this.endValueFloat, this.endValueFloat, this.endValueFloat), this.duration);
				break;
			case 6:
				this.isRelative = false;
				if (type.IsSameOrSubclassOf(typeof(SpriteRenderer)))
				{
					this.tween = ShortcutExtensions43.DOColor((SpriteRenderer)this.target, this.endValueColor, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Renderer)))
				{
					this.tween = ShortcutExtensions.DOColor(((Renderer)this.target).material, this.endValueColor, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Image)))
				{
					this.tween = ShortcutExtensions46.DOColor((Image)this.target, this.endValueColor, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Text)))
				{
					this.tween = ShortcutExtensions46.DOColor((Text)this.target, this.endValueColor, this.duration);
				}
				break;
			case 7:
				this.isRelative = false;
				if (type.IsSameOrSubclassOf(typeof(SpriteRenderer)))
				{
					this.tween = ShortcutExtensions43.DOFade((SpriteRenderer)this.target, this.endValueFloat, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Renderer)))
				{
					this.tween = ShortcutExtensions.DOFade(((Renderer)this.target).material, this.endValueFloat, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Image)))
				{
					this.tween = ShortcutExtensions46.DOFade((Image)this.target, this.endValueFloat, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Text)))
				{
					this.tween = ShortcutExtensions46.DOFade((Text)this.target, this.endValueFloat, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(CanvasGroup)))
				{
					this.tween = DOTween.To(() => ((CanvasGroup)this.target).alpha, delegate(float alpha)
					{
						((CanvasGroup)this.target).alpha = alpha;
					}, this.endValueFloat, this.duration);
				}
				break;
			case 8:
				if (type.IsSameOrSubclassOf(typeof(Text)))
				{
					this.tween = ShortcutExtensions46.DOText((Text)this.target, this.endValueString, this.duration, this.optionalBool0, this.optionalScrambleMode, this.optionalString);
				}
				break;
			case 9:
				if (type.IsSameOrSubclassOf(typeof(RectTransform)))
				{
					this.tween = ShortcutExtensions46.DOPunchAnchorPos((RectTransform)this.target, this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				else if (type.IsSameOrSubclassOf(typeof(Transform)))
				{
					this.tween = ShortcutExtensions.DOPunchPosition((Transform)this.target, this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				break;
			case 10:
				this.tween = ShortcutExtensions.DOPunchRotation(base.transform, this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0);
				break;
			case 11:
				this.tween = ShortcutExtensions.DOPunchScale(base.transform, this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0);
				break;
			case 12:
				if (type.IsSameOrSubclassOf(typeof(RectTransform)))
				{
					this.tween = ShortcutExtensions46.DOShakeAnchorPos((RectTransform)this.target, this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				if (type.IsSameOrSubclassOf(typeof(Transform)))
				{
					this.tween = ShortcutExtensions.DOShakePosition((Transform)this.target, this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				break;
			case 13:
				this.tween = ShortcutExtensions.DOShakeRotation(base.transform, this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0);
				break;
			case 14:
				this.tween = ShortcutExtensions.DOShakeScale(base.transform, this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0);
				break;
			case 15:
				this.tween = ShortcutExtensions.DOAspect((Camera)this.target, this.endValueFloat, this.duration);
				break;
			case 16:
				this.tween = ShortcutExtensions.DOColor((Camera)this.target, this.endValueColor, this.duration);
				break;
			case 17:
				this.tween = ShortcutExtensions.DOFieldOfView((Camera)this.target, this.endValueFloat, this.duration);
				break;
			case 18:
				this.tween = ShortcutExtensions.DOOrthoSize((Camera)this.target, this.endValueFloat, this.duration);
				break;
			case 19:
				this.tween = ShortcutExtensions.DOPixelRect((Camera)this.target, this.endValueRect, this.duration);
				break;
			case 20:
				this.tween = ShortcutExtensions.DORect((Camera)this.target, this.endValueRect, this.duration);
				break;
			}
			if (this.tween == null)
			{
				return;
			}
			if (this.isFrom)
			{
				TweenSettingsExtensions.From<Tweener>((Tweener)this.tween, this.isRelative);
			}
			else
			{
				TweenSettingsExtensions.SetRelative<Tween>(this.tween, this.isRelative);
			}
			TweenSettingsExtensions.OnKill<Tween>(TweenSettingsExtensions.SetAutoKill<Tween>(TweenSettingsExtensions.SetLoops<Tween>(TweenSettingsExtensions.SetDelay<Tween>(TweenSettingsExtensions.SetTarget<Tween>(this.tween, base.gameObject), this.delay), this.loops, this.loopType), this.autoKill), delegate()
			{
				this.tween = null;
			});
			if (this.easeType == 33)
			{
				TweenSettingsExtensions.SetEase<Tween>(this.tween, this.easeCurve);
			}
			else
			{
				TweenSettingsExtensions.SetEase<Tween>(this.tween, this.easeType);
			}
			if (!string.IsNullOrEmpty(this.id))
			{
				TweenSettingsExtensions.SetId<Tween>(this.tween, this.id);
			}
			TweenSettingsExtensions.SetUpdate<Tween>(this.tween, this.isIndependentUpdate);
			if (this.hasOnStart)
			{
				if (this.onStart != null)
				{
					TweenSettingsExtensions.OnStart<Tween>(this.tween, new TweenCallback(this.onStart.Invoke));
				}
			}
			else
			{
				this.onStart = null;
			}
			if (this.hasOnPlay)
			{
				if (this.onPlay != null)
				{
					TweenSettingsExtensions.OnPlay<Tween>(this.tween, new TweenCallback(this.onPlay.Invoke));
				}
			}
			else
			{
				this.onPlay = null;
			}
			if (this.hasOnUpdate)
			{
				if (this.onUpdate != null)
				{
					TweenSettingsExtensions.OnUpdate<Tween>(this.tween, new TweenCallback(this.onUpdate.Invoke));
				}
			}
			else
			{
				this.onUpdate = null;
			}
			if (this.hasOnStepComplete)
			{
				if (this.onStepComplete != null)
				{
					TweenSettingsExtensions.OnStepComplete<Tween>(this.tween, new TweenCallback(this.onStepComplete.Invoke));
				}
			}
			else
			{
				this.onStepComplete = null;
			}
			if (this.hasOnComplete)
			{
				if (this.onComplete != null)
				{
					TweenSettingsExtensions.OnComplete<Tween>(this.tween, new TweenCallback(this.onComplete.Invoke));
				}
			}
			else
			{
				this.onComplete = null;
			}
			if (this.autoPlay)
			{
				TweenExtensions.Play<Tween>(this.tween);
			}
			else
			{
				TweenExtensions.Pause<Tween>(this.tween);
			}
		}

		// Token: 0x0601ACC1 RID: 109761 RVA: 0x0083E3AA File Offset: 0x0083C7AA
		public override void DOPlay()
		{
			DOTween.Play(base.gameObject);
		}

		// Token: 0x0601ACC2 RID: 109762 RVA: 0x0083E3B8 File Offset: 0x0083C7B8
		public override void DOPlayBackwards()
		{
			DOTween.PlayBackwards(base.gameObject);
		}

		// Token: 0x0601ACC3 RID: 109763 RVA: 0x0083E3C6 File Offset: 0x0083C7C6
		public override void DOPlayForward()
		{
			DOTween.PlayForward(base.gameObject);
		}

		// Token: 0x0601ACC4 RID: 109764 RVA: 0x0083E3D4 File Offset: 0x0083C7D4
		public override void DOPause()
		{
			DOTween.Pause(base.gameObject);
		}

		// Token: 0x0601ACC5 RID: 109765 RVA: 0x0083E3E2 File Offset: 0x0083C7E2
		public override void DOTogglePause()
		{
			DOTween.TogglePause(base.gameObject);
		}

		// Token: 0x0601ACC6 RID: 109766 RVA: 0x0083E3F0 File Offset: 0x0083C7F0
		public override void DORewind()
		{
			this._playCount = -1;
			DOTweenAnimation[] components = base.gameObject.GetComponents<DOTweenAnimation>();
			for (int i = components.Length - 1; i > -1; i--)
			{
				Tween tween = components[i].tween;
				if (tween != null && TweenExtensions.IsInitialized(tween))
				{
					TweenExtensions.Rewind(components[i].tween, true);
				}
			}
		}

		// Token: 0x0601ACC7 RID: 109767 RVA: 0x0083E450 File Offset: 0x0083C850
		public override void DORestart(bool fromHere = false)
		{
			this._playCount = -1;
			if (this.tween == null)
			{
				if (Debugger.logPriority > 1)
				{
					Debugger.LogNullTween(this.tween);
				}
				return;
			}
			if (fromHere && this.isRelative)
			{
				this.ReEvaluateRelativeTween();
			}
			DOTween.Restart(base.gameObject, true);
		}

		// Token: 0x0601ACC8 RID: 109768 RVA: 0x0083E4AA File Offset: 0x0083C8AA
		public override void DOComplete()
		{
			DOTween.Complete(base.gameObject);
		}

		// Token: 0x0601ACC9 RID: 109769 RVA: 0x0083E4B8 File Offset: 0x0083C8B8
		public override void DOKill()
		{
			DOTween.Kill(base.gameObject, false);
			this.tween = null;
		}

		// Token: 0x0601ACCA RID: 109770 RVA: 0x0083E4CE File Offset: 0x0083C8CE
		public void DOPlayById(string id)
		{
			DOTween.Play(base.gameObject, id);
		}

		// Token: 0x0601ACCB RID: 109771 RVA: 0x0083E4DD File Offset: 0x0083C8DD
		public void DOPlayAllById(string id)
		{
			DOTween.Play(id);
		}

		// Token: 0x0601ACCC RID: 109772 RVA: 0x0083E4E8 File Offset: 0x0083C8E8
		public void DOPlayNext()
		{
			DOTweenAnimation[] components = base.GetComponents<DOTweenAnimation>();
			while (this._playCount < components.Length - 1)
			{
				this._playCount++;
				DOTweenAnimation dotweenAnimation = components[this._playCount];
				if (dotweenAnimation != null && dotweenAnimation.tween != null && !TweenExtensions.IsPlaying(dotweenAnimation.tween) && !TweenExtensions.IsComplete(dotweenAnimation.tween))
				{
					TweenExtensions.Play<Tween>(dotweenAnimation.tween);
					break;
				}
			}
		}

		// Token: 0x0601ACCD RID: 109773 RVA: 0x0083E570 File Offset: 0x0083C970
		public void DORewindAndPlayNext()
		{
			this._playCount = -1;
			DOTween.Rewind(base.gameObject, true);
			this.DOPlayNext();
		}

		// Token: 0x0601ACCE RID: 109774 RVA: 0x0083E58C File Offset: 0x0083C98C
		public void DORestartById(string id)
		{
			this._playCount = -1;
			DOTween.Restart(base.gameObject, id, true);
		}

		// Token: 0x0601ACCF RID: 109775 RVA: 0x0083E5A3 File Offset: 0x0083C9A3
		public void DORestartAllById(string id)
		{
			this._playCount = -1;
			DOTween.Restart(id, true);
		}

		// Token: 0x0601ACD0 RID: 109776 RVA: 0x0083E5B4 File Offset: 0x0083C9B4
		public List<Tween> GetTweens()
		{
			return DOTween.TweensByTarget(base.gameObject, false);
		}

		// Token: 0x0601ACD1 RID: 109777 RVA: 0x0083E5C4 File Offset: 0x0083C9C4
		private void ReEvaluateRelativeTween()
		{
			if (this.animationType == 1)
			{
				((Tweener)this.tween).ChangeEndValue(base.transform.position + this.endValueV3, true);
			}
			else if (this.animationType == 2)
			{
				((Tweener)this.tween).ChangeEndValue(base.transform.localPosition + this.endValueV3, true);
			}
		}

		// Token: 0x04012A53 RID: 76371
		public float delay;

		// Token: 0x04012A54 RID: 76372
		public float duration = 1f;

		// Token: 0x04012A55 RID: 76373
		public Ease easeType = 6;

		// Token: 0x04012A56 RID: 76374
		public AnimationCurve easeCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04012A57 RID: 76375
		public LoopType loopType;

		// Token: 0x04012A58 RID: 76376
		public int loops = 1;

		// Token: 0x04012A59 RID: 76377
		public string id = string.Empty;

		// Token: 0x04012A5A RID: 76378
		public bool isRelative;

		// Token: 0x04012A5B RID: 76379
		public bool isFrom;

		// Token: 0x04012A5C RID: 76380
		public bool isIndependentUpdate;

		// Token: 0x04012A5D RID: 76381
		public bool autoKill = true;

		// Token: 0x04012A5E RID: 76382
		public bool isActive = true;

		// Token: 0x04012A5F RID: 76383
		public bool isValid;

		// Token: 0x04012A60 RID: 76384
		public Component target;

		// Token: 0x04012A61 RID: 76385
		public DOTweenAnimationType animationType;

		// Token: 0x04012A62 RID: 76386
		public bool autoPlay = true;

		// Token: 0x04012A63 RID: 76387
		public float endValueFloat;

		// Token: 0x04012A64 RID: 76388
		public Vector3 endValueV3;

		// Token: 0x04012A65 RID: 76389
		public Color endValueColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x04012A66 RID: 76390
		public string endValueString = string.Empty;

		// Token: 0x04012A67 RID: 76391
		public Rect endValueRect = new Rect(0f, 0f, 0f, 0f);

		// Token: 0x04012A68 RID: 76392
		public bool optionalBool0;

		// Token: 0x04012A69 RID: 76393
		public float optionalFloat0;

		// Token: 0x04012A6A RID: 76394
		public int optionalInt0;

		// Token: 0x04012A6B RID: 76395
		public RotateMode optionalRotationMode;

		// Token: 0x04012A6C RID: 76396
		public ScrambleMode optionalScrambleMode;

		// Token: 0x04012A6D RID: 76397
		public string optionalString;

		// Token: 0x04012A6E RID: 76398
		private int _playCount = -1;
	}
}
