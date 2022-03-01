using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015A2 RID: 5538
	public class ComDailyTodoFunctionItem : MonoBehaviour
	{
		// Token: 0x17001C26 RID: 7206
		// (get) Token: 0x0600D893 RID: 55443 RVA: 0x0036318E File Offset: 0x0036158E
		public bool IsEndAnim
		{
			get
			{
				return this.isEndAnim;
			}
		}

		// Token: 0x0600D894 RID: 55444 RVA: 0x00363198 File Offset: 0x00361598
		private void Awake()
		{
			if (this.gotoBtn)
			{
				this.gotoBtn.onClick.AddListener(new UnityAction(this._OnGotoBtnClick));
			}
			if (this.gotoBtn2)
			{
				this.gotoBtn2.onClick.AddListener(new UnityAction(this._OnGotoBtnClick));
			}
		}

		// Token: 0x0600D895 RID: 55445 RVA: 0x00363200 File Offset: 0x00361600
		private void OnDestroy()
		{
			if (this.gotoBtn)
			{
				this.gotoBtn.onClick.RemoveListener(new UnityAction(this._OnGotoBtnClick));
			}
			if (this.gotoBtn2)
			{
				this.gotoBtn2.onClick.RemoveListener(new UnityAction(this._OnGotoBtnClick));
			}
			this._ClearView();
		}

		// Token: 0x0600D896 RID: 55446 RVA: 0x0036326B File Offset: 0x0036166B
		private void _ClearView()
		{
			this.tempModel = null;
			if (this.mFinishTagAnimQueue != null)
			{
				TweenExtensions.Pause<Sequence>(this.mFinishTagAnimQueue);
				TweenExtensions.Kill(this.mFinishTagAnimQueue, false);
				this.mFinishTagAnimQueue = null;
				this.isEndAnim = false;
			}
		}

		// Token: 0x0600D897 RID: 55447 RVA: 0x003632A5 File Offset: 0x003616A5
		private void _OnGotoBtnClick()
		{
			if (this.tempModel != null && this.tempModel.gotoHandler != null)
			{
				this.tempModel.gotoHandler(this.tempModel);
			}
		}

		// Token: 0x0600D898 RID: 55448 RVA: 0x003632D8 File Offset: 0x003616D8
		private void _SetName(string name)
		{
			if (this.nameText)
			{
				this.nameText.text = name;
			}
		}

		// Token: 0x0600D899 RID: 55449 RVA: 0x003632F8 File Offset: 0x003616F8
		private void _SetBackground(string imgPath)
		{
			if (!string.IsNullOrEmpty(imgPath) && this.backgroundImg)
			{
				this.backgroundImg.color = Color.white;
				if (!ETCImageLoader.LoadSprite(ref this.backgroundImg, imgPath, true))
				{
					Logger.LogErrorFormat("[ComDailyTodoActivityItem] - SetBackground can not load img : {0}", new object[]
					{
						imgPath
					});
				}
			}
		}

		// Token: 0x0600D89A RID: 55450 RVA: 0x00363358 File Offset: 0x00361758
		private void _SetChacterDesc(string desc)
		{
			if (this.descText)
			{
				this.descText.text = desc;
			}
		}

		// Token: 0x0600D89B RID: 55451 RVA: 0x00363376 File Offset: 0x00361776
		private void _SetRecommendDesc(string desc)
		{
			if (this.recommendText)
			{
				this.recommendText.text = desc;
			}
		}

		// Token: 0x0600D89C RID: 55452 RVA: 0x00363394 File Offset: 0x00361794
		private void _SetFunctionState(DailyTodoFuncState dailyTodoFuncState)
		{
			if (dailyTodoFuncState == DailyTodoFuncState.End)
			{
				this._SetGoToFieldStatus(true, false, true);
			}
			else if (dailyTodoFuncState == DailyTodoFuncState.Start)
			{
				this._SetGoToFieldStatus(false, true, false);
			}
			else
			{
				this._SetGoToFieldStatus(false, false, false);
			}
		}

		// Token: 0x0600D89D RID: 55453 RVA: 0x003633C9 File Offset: 0x003617C9
		private void _OnFinishTagPlayTweenStart()
		{
			this.isEndAnim = false;
			this._SetGoToFieldStatus(true, false, false);
		}

		// Token: 0x0600D89E RID: 55454 RVA: 0x003633DC File Offset: 0x003617DC
		private void _OnFinishTagPlayTweenEnd()
		{
			this.isEndAnim = true;
			this._SetGoToFieldStatus(true, false, true);
			if (this.tempModel != null)
			{
				this.tempModel.RecommendState = DailyTodoFuncState.End;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnDailyTodoFuncPlayAnimEnd, this.extraAnimParam, null, null, null);
		}

		// Token: 0x0600D89F RID: 55455 RVA: 0x00363428 File Offset: 0x00361828
		private void _SetGoToFieldStatus(bool enableFinishTag, bool enableBtn, bool enableBlackMask)
		{
			if (this.finishTagImg)
			{
				this.finishTagImg.enabled = enableFinishTag;
			}
			if (this.gotoBtn)
			{
				this.gotoBtn.interactable = enableBtn;
			}
			if (this.blackMask)
			{
				this.blackMask.enabled = enableBlackMask;
			}
		}

		// Token: 0x0600D8A0 RID: 55456 RVA: 0x0036348C File Offset: 0x0036188C
		public void RefreshView(DailyTodoFunction model)
		{
			if (model == null)
			{
				return;
			}
			this.tempModel = model;
			this._SetBackground(model.backgroundImgPath);
			this._SetName(model.name);
			this._SetChacterDesc(model.characterDesc);
			this._SetRecommendDesc(model.dayRecommendDesc);
			this._SetFunctionState(model.RecommendState);
		}

		// Token: 0x0600D8A1 RID: 55457 RVA: 0x003634E3 File Offset: 0x003618E3
		public void Recycle()
		{
			this._ClearView();
		}

		// Token: 0x0600D8A2 RID: 55458 RVA: 0x003634EC File Offset: 0x003618EC
		public bool TryPlayAnim()
		{
			if (this.tempModel != null && this.tempModel.RecommendState == DailyTodoFuncState.Finishing && this.finishTagRect && this.finishTagImg)
			{
				if (this.mFinishTagAnimQueue == null)
				{
					this.mFinishTagAnimQueue = DOTween.Sequence();
					TweenSettingsExtensions.Append(this.mFinishTagAnimQueue, TweenSettingsExtensions.OnComplete<Tweener>(TweenSettingsExtensions.OnStart<Tweener>(TweenSettingsExtensions.From<Tweener>(TweenSettingsExtensions.SetEase<Tweener>(TweenSettingsExtensions.SetDelay<Tweener>(ShortcutExtensions.DOScale(this.finishTagRect, this.finishTagScaleAnimFromValue, this.finishTagAnimDuration), this.finishTagAnimDelay), this.finishTagAnimCurve)), new TweenCallback(this._OnFinishTagPlayTweenStart)), new TweenCallback(this._OnFinishTagPlayTweenEnd)));
					TweenSettingsExtensions.Join(this.mFinishTagAnimQueue, TweenSettingsExtensions.From<Tweener>(TweenSettingsExtensions.SetEase<Tweener>(TweenSettingsExtensions.SetDelay<Tweener>(ShortcutExtensions46.DOColor(this.finishTagImg, new Color(1f, 1f, 1f, 0f), this.finishTagFromFadeZeroDuration), this.finishTagFromFadeZeroDelay), this.finishTagFromFadeZeroEase)));
				}
				if (TweenExtensions.IsPlaying(this.mFinishTagAnimQueue))
				{
					TweenExtensions.Pause<Sequence>(this.mFinishTagAnimQueue);
				}
				TweenExtensions.Restart(this.mFinishTagAnimQueue, true);
				return true;
			}
			return false;
		}

		// Token: 0x04007F2D RID: 32557
		private DailyTodoFunction tempModel;

		// Token: 0x04007F2E RID: 32558
		private bool isEndAnim;

		// Token: 0x04007F2F RID: 32559
		private Sequence mFinishTagAnimQueue;

		// Token: 0x04007F30 RID: 32560
		[SerializeField]
		private Image backgroundImg;

		// Token: 0x04007F31 RID: 32561
		[SerializeField]
		private Text nameText;

		// Token: 0x04007F32 RID: 32562
		[SerializeField]
		private Text recommendText;

		// Token: 0x04007F33 RID: 32563
		[SerializeField]
		private Text descText;

		// Token: 0x04007F34 RID: 32564
		[SerializeField]
		private Button gotoBtn;

		// Token: 0x04007F35 RID: 32565
		[SerializeField]
		private Button gotoBtn2;

		// Token: 0x04007F36 RID: 32566
		[SerializeField]
		private Image blackMask;

		// Token: 0x04007F37 RID: 32567
		[SerializeField]
		private Image finishTagImg;

		// Token: 0x04007F38 RID: 32568
		[SerializeField]
		private RectTransform finishTagRect;

		// Token: 0x04007F39 RID: 32569
		[SerializeField]
		private AnimationCurve finishTagAnimCurve;

		// Token: 0x04007F3A RID: 32570
		[SerializeField]
		private float finishTagAnimDuration;

		// Token: 0x04007F3B RID: 32571
		[SerializeField]
		private float finishTagAnimDelay;

		// Token: 0x04007F3C RID: 32572
		[SerializeField]
		private float finishTagScaleAnimFromValue;

		// Token: 0x04007F3D RID: 32573
		[SerializeField]
		private Ease finishTagFromFadeZeroEase;

		// Token: 0x04007F3E RID: 32574
		[SerializeField]
		private float finishTagFromFadeZeroDuration;

		// Token: 0x04007F3F RID: 32575
		[SerializeField]
		private float finishTagFromFadeZeroDelay;

		// Token: 0x04007F40 RID: 32576
		[SerializeField]
		[Header("动画额外参数")]
		private ComDailyTodoFunctionExtraAnimParam extraAnimParam;
	}
}
