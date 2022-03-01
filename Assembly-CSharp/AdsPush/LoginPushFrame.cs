using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AdsPush
{
	// Token: 0x02001805 RID: 6149
	public class LoginPushFrame : ClientFrame
	{
		// Token: 0x0600F267 RID: 62055 RVA: 0x0041623F File Offset: 0x0041463F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/PushAds/AdsItem";
		}

		// Token: 0x0600F268 RID: 62056 RVA: 0x00416246 File Offset: 0x00414646
		protected override void _OnOpenFrame()
		{
			this.InitPushData();
		}

		// Token: 0x0600F269 RID: 62057 RVA: 0x00416250 File Offset: 0x00414650
		private void InitPushData()
		{
			string pushIconPath = Singleton<LoginPushManager>.GetInstance().GetPushIconPath();
			if (pushIconPath != string.Empty && this.mContentImg != null && this.mContentImgRect != null)
			{
				this.mContentImg.sprite = (Singleton<AssetLoader>.instance.LoadRes(pushIconPath, typeof(Sprite), true, 0U).obj as Sprite);
				if (Singleton<LoginPushManager>.GetInstance().IsSetNative())
				{
					this.mContentImg.SetNativeSize();
				}
				else
				{
					this.mContentImgRect.sizeDelta = this.mOriginalSize;
				}
			}
			string pushTime = Singleton<LoginPushManager>.GetInstance().GetPushTime();
			if (pushTime == null)
			{
				this.mTime.CustomActive(false);
			}
			else
			{
				this.mTime.text = pushTime;
				this.mTime.CustomActive(true);
			}
			Type linkType = Singleton<LoginPushManager>.GetInstance().getLinkType();
			this.mGoKnowBtnGo.CustomActive(false);
			if (linkType == null)
			{
				this.mGoKnowBtnGo.CustomActive(false);
				return;
			}
			if (linkType == typeof(ActivityJarFrame))
			{
				this.mGoKnowBtnGo.CustomActive(true);
				this.mGoKnowBtn.onClick.RemoveAllListeners();
				this.mGoKnowBtn.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityJarFrame>(FrameLayer.Middle, null, string.Empty);
				});
			}
		}

		// Token: 0x0600F26A RID: 62058 RVA: 0x004163B3 File Offset: 0x004147B3
		protected override void _OnCloseFrame()
		{
			Singleton<LoginPushManager>.GetInstance().TryOpenLoginPushFrame();
		}

		// Token: 0x0600F26B RID: 62059 RVA: 0x004163C0 File Offset: 0x004147C0
		protected override void _bindExUI()
		{
			this.mContentImg = this.mBind.GetCom<Image>("ContentImg");
			this.mContentBtn = this.mBind.GetCom<Button>("ContentBtn");
			this.mContentBtn.onClick.AddListener(new UnityAction(this._onContentBtnButtonClick));
			this.mContentLoading = this.mBind.GetGameObject("ContentLoading");
			this.mKnowBtn = this.mBind.GetCom<Button>("KnowBtn");
			this.mKnowBtn.onClick.AddListener(new UnityAction(this._onKnowBtnButtonClick));
			this.mKnowBtnGo = this.mBind.GetGameObject("KnowBtnGo");
			this.mGoKnowBtn = this.mBind.GetCom<Button>("GoKnowBtn");
			this.mGoKnowBtn.onClick.AddListener(new UnityAction(this._onGoKnowBtnButtonClick));
			this.mGoKnowBtnGo = this.mBind.GetGameObject("GoKnowBtnGo");
			this.mTime = this.mBind.GetCom<Text>("time");
			this.mContentImgRect = this.mBind.GetCom<RectTransform>("ContentImgRect");
		}

		// Token: 0x0600F26C RID: 62060 RVA: 0x004164E8 File Offset: 0x004148E8
		protected override void _unbindExUI()
		{
			this.mContentImg = null;
			this.mContentBtn.onClick.RemoveListener(new UnityAction(this._onContentBtnButtonClick));
			this.mContentBtn = null;
			this.mContentLoading = null;
			this.mKnowBtn.onClick.RemoveListener(new UnityAction(this._onKnowBtnButtonClick));
			this.mKnowBtn = null;
			this.mKnowBtnGo = null;
			this.mGoKnowBtn.onClick.RemoveListener(new UnityAction(this._onGoKnowBtnButtonClick));
			this.mGoKnowBtn = null;
			this.mGoKnowBtnGo = null;
			this.mTime = null;
			this.mContentImgRect = null;
		}

		// Token: 0x0600F26D RID: 62061 RVA: 0x00416588 File Offset: 0x00414988
		private void _onContentBtnButtonClick()
		{
		}

		// Token: 0x0600F26E RID: 62062 RVA: 0x0041658A File Offset: 0x0041498A
		private void _onKnowBtnButtonClick()
		{
			this.frameMgr.CloseFrame<LoginPushFrame>(this, false);
		}

		// Token: 0x0600F26F RID: 62063 RVA: 0x00416599 File Offset: 0x00414999
		private void _onGoKnowBtnButtonClick()
		{
		}

		// Token: 0x040094F1 RID: 38129
		private Vector2 mOriginalSize = new Vector2(1408f, 717f);

		// Token: 0x040094F2 RID: 38130
		private Image mContentImg;

		// Token: 0x040094F3 RID: 38131
		private Button mContentBtn;

		// Token: 0x040094F4 RID: 38132
		private GameObject mContentLoading;

		// Token: 0x040094F5 RID: 38133
		private Button mKnowBtn;

		// Token: 0x040094F6 RID: 38134
		private GameObject mKnowBtnGo;

		// Token: 0x040094F7 RID: 38135
		private Button mGoKnowBtn;

		// Token: 0x040094F8 RID: 38136
		private GameObject mGoKnowBtnGo;

		// Token: 0x040094F9 RID: 38137
		private Text mTime;

		// Token: 0x040094FA RID: 38138
		private RectTransform mContentImgRect;
	}
}
