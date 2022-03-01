using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E0F RID: 3599
	public class AuctionNewMsgBoxOkCancelView : MonoBehaviour
	{
		// Token: 0x06009022 RID: 36898 RVA: 0x001AA5F9 File Offset: 0x001A89F9
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06009023 RID: 36899 RVA: 0x001AA601 File Offset: 0x001A8A01
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06009024 RID: 36900 RVA: 0x001AA610 File Offset: 0x001A8A10
		private void BindEvents()
		{
			if (this.notifyToggle != null)
			{
				this.notifyToggle.onValueChanged.RemoveAllListeners();
				this.notifyToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleClick));
			}
			if (this.leftButton != null)
			{
				this.leftButton.onClick.RemoveAllListeners();
				this.leftButton.onClick.AddListener(new UnityAction(this.OnLeftButtonClick));
			}
			if (this.rightButton != null)
			{
				this.rightButton.onClick.RemoveAllListeners();
				this.rightButton.onClick.AddListener(new UnityAction(this.OnRightButtonClick));
			}
		}

		// Token: 0x06009025 RID: 36901 RVA: 0x001AA6D4 File Offset: 0x001A8AD4
		private void UnBindEvents()
		{
			if (this.notifyToggle != null)
			{
				this.notifyToggle.onValueChanged.RemoveAllListeners();
			}
			if (this.leftButton != null)
			{
				this.leftButton.onClick.RemoveAllListeners();
			}
			if (this.rightButton != null)
			{
				this.rightButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06009026 RID: 36902 RVA: 0x001AA744 File Offset: 0x001A8B44
		private void ClearData()
		{
			this._onCommonMsgBoxToggleClick = null;
			this._onLeftButtonClickCallBack = null;
			this._onRightButtonClickCallBack = null;
			this._isShowNotify = false;
			this._commonMsgBoxOkCancelNewParamData = null;
		}

		// Token: 0x06009027 RID: 36903 RVA: 0x001AA76C File Offset: 0x001A8B6C
		public void InitData(CommonMsgBoxOkCancelNewParamData paramData)
		{
			this._commonMsgBoxOkCancelNewParamData = paramData;
			if (this._commonMsgBoxOkCancelNewParamData == null)
			{
				Logger.LogErrorFormat("AuctionNewMsgBoxOkCancelView InitData data is null", new object[0]);
				this.OnCloseFrame();
				return;
			}
			this._onCommonMsgBoxToggleClick = this._commonMsgBoxOkCancelNewParamData.OnCommonMsgBoxToggleClick;
			this._onLeftButtonClickCallBack = this._commonMsgBoxOkCancelNewParamData.OnLeftButtonClickCallBack;
			this._onRightButtonClickCallBack = this._commonMsgBoxOkCancelNewParamData.OnRightButtonClickCallBack;
			this._isShowNotify = this._commonMsgBoxOkCancelNewParamData.IsShowNotify;
			this.InitView();
		}

		// Token: 0x06009028 RID: 36904 RVA: 0x001AA7EC File Offset: 0x001A8BEC
		private void InitView()
		{
			this.InitContent();
			this.InitButton();
		}

		// Token: 0x06009029 RID: 36905 RVA: 0x001AA7FC File Offset: 0x001A8BFC
		private void InitContent()
		{
			if (this.notifyToggleRoot != null)
			{
				this.notifyToggleRoot.gameObject.CustomActive(this._isShowNotify);
			}
			if (this.contentLabelOne != null)
			{
				this.contentLabelOne.text = this._commonMsgBoxOkCancelNewParamData.ContentLabel;
				this.contentLabelOne.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600902A RID: 36906 RVA: 0x001AA868 File Offset: 0x001A8C68
		private void InitButton()
		{
			if (this.leftButtonText != null)
			{
				this.leftButtonText.text = this._commonMsgBoxOkCancelNewParamData.LeftButtonText;
			}
			if (this.rightButtonText != null)
			{
				this.rightButtonText.text = this._commonMsgBoxOkCancelNewParamData.RightButtonText;
			}
		}

		// Token: 0x0600902B RID: 36907 RVA: 0x001AA8C3 File Offset: 0x001A8CC3
		private void OnToggleClick(bool value)
		{
			if (this._onCommonMsgBoxToggleClick != null)
			{
				this._onCommonMsgBoxToggleClick(value);
			}
		}

		// Token: 0x0600902C RID: 36908 RVA: 0x001AA8DC File Offset: 0x001A8CDC
		private void OnLeftButtonClick()
		{
			this.OnCloseFrame();
			if (this._onLeftButtonClickCallBack != null)
			{
				this._onLeftButtonClickCallBack();
			}
		}

		// Token: 0x0600902D RID: 36909 RVA: 0x001AA8FA File Offset: 0x001A8CFA
		private void OnRightButtonClick()
		{
			this.OnCloseFrame();
			if (this._onRightButtonClickCallBack != null)
			{
				this._onRightButtonClickCallBack();
			}
		}

		// Token: 0x0600902E RID: 36910 RVA: 0x001AA918 File Offset: 0x001A8D18
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewMsgBoxOkCancelFrame>(null, false);
		}

		// Token: 0x0400479C RID: 18332
		private CommonMsgBoxOkCancelNewParamData _commonMsgBoxOkCancelNewParamData;

		// Token: 0x0400479D RID: 18333
		private bool _isShowNotify;

		// Token: 0x0400479E RID: 18334
		private OnCommonMsgBoxToggleClick _onCommonMsgBoxToggleClick;

		// Token: 0x0400479F RID: 18335
		private Action _onLeftButtonClickCallBack;

		// Token: 0x040047A0 RID: 18336
		private Action _onRightButtonClickCallBack;

		// Token: 0x040047A1 RID: 18337
		[Space(10f)]
		[Header("Content")]
		[SerializeField]
		private Text contentLabelOne;

		// Token: 0x040047A2 RID: 18338
		[SerializeField]
		private GameObject notifyToggleRoot;

		// Token: 0x040047A3 RID: 18339
		[SerializeField]
		private Toggle notifyToggle;

		// Token: 0x040047A4 RID: 18340
		[Space(10f)]
		[Header("Button")]
		[SerializeField]
		private Button leftButton;

		// Token: 0x040047A5 RID: 18341
		[SerializeField]
		private Text leftButtonText;

		// Token: 0x040047A6 RID: 18342
		[SerializeField]
		private Button rightButton;

		// Token: 0x040047A7 RID: 18343
		[SerializeField]
		private Text rightButtonText;
	}
}
