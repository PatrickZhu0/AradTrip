using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E22 RID: 3618
	public class CommonMsgBoxOkCancelNewView : MonoBehaviour
	{
		// Token: 0x060090D4 RID: 37076 RVA: 0x001ACAE9 File Offset: 0x001AAEE9
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x060090D5 RID: 37077 RVA: 0x001ACAF1 File Offset: 0x001AAEF1
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x060090D6 RID: 37078 RVA: 0x001ACB00 File Offset: 0x001AAF00
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
			if (this.middleButton != null)
			{
				this.middleButton.onClick.RemoveAllListeners();
				this.middleButton.onClick.AddListener(new UnityAction(this.OnMiddleButtonClick));
			}
		}

		// Token: 0x060090D7 RID: 37079 RVA: 0x001ACC04 File Offset: 0x001AB004
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
			if (this.middleButton != null)
			{
				this.middleButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x060090D8 RID: 37080 RVA: 0x001ACC95 File Offset: 0x001AB095
		private void ClearData()
		{
			this._onCommonMsgBoxToggleClick = null;
			this._onLeftButtonClickCallBack = null;
			this._onRightButtonClickCallBack = null;
			this._isShowNotify = false;
			this._commonMsgBoxOkCancelNewParamData = null;
			this._isMiddleButton = false;
			this._onMiddleButtonClickCallBack = null;
		}

		// Token: 0x060090D9 RID: 37081 RVA: 0x001ACCC8 File Offset: 0x001AB0C8
		public void InitData(CommonMsgBoxOkCancelNewParamData paramData)
		{
			this._commonMsgBoxOkCancelNewParamData = paramData;
			if (this._commonMsgBoxOkCancelNewParamData == null)
			{
				this.OnCloseFrame();
				return;
			}
			this._onCommonMsgBoxToggleClick = this._commonMsgBoxOkCancelNewParamData.OnCommonMsgBoxToggleClick;
			this._onLeftButtonClickCallBack = this._commonMsgBoxOkCancelNewParamData.OnLeftButtonClickCallBack;
			this._onRightButtonClickCallBack = this._commonMsgBoxOkCancelNewParamData.OnRightButtonClickCallBack;
			this._isShowNotify = this._commonMsgBoxOkCancelNewParamData.IsShowNotify;
			this._onMiddleButtonClickCallBack = this._commonMsgBoxOkCancelNewParamData.OnMiddleButtonClickCallBack;
			this._isMiddleButton = this._commonMsgBoxOkCancelNewParamData.IsMiddleButton;
			this.InitView();
			if (this._commonMsgBoxOkCancelNewParamData.IsDefaultCheck && this.notifyToggle != null)
			{
				this.notifyToggle.isOn = true;
			}
		}

		// Token: 0x060090DA RID: 37082 RVA: 0x001ACD87 File Offset: 0x001AB187
		private void InitView()
		{
			this.InitContent();
			this.InitButton();
		}

		// Token: 0x060090DB RID: 37083 RVA: 0x001ACD98 File Offset: 0x001AB198
		private void InitContent()
		{
			if (this.notifyToggleRoot != null)
			{
				this.notifyToggleRoot.gameObject.CustomActive(this._isShowNotify);
			}
			if (this._isShowNotify)
			{
				if (this.contentLabelOne != null)
				{
					this.contentLabelOne.text = this._commonMsgBoxOkCancelNewParamData.ContentLabel;
					this.contentLabelOne.gameObject.CustomActive(true);
					if (this._commonMsgBoxOkCancelNewParamData.ContentTextAnchor != 4)
					{
						this.contentLabelOne.alignment = this._commonMsgBoxOkCancelNewParamData.ContentTextAnchor;
					}
					if (this._commonMsgBoxOkCancelNewParamData.IsSetContentFontSize && this._commonMsgBoxOkCancelNewParamData.ContentFontSize > 0)
					{
						this.contentLabelOne.fontSize = this._commonMsgBoxOkCancelNewParamData.ContentFontSize;
					}
				}
				if (this.contentLabelTwo != null)
				{
					this.contentLabelTwo.gameObject.CustomActive(false);
				}
			}
			else
			{
				if (this.contentLabelOne != null)
				{
					this.contentLabelOne.gameObject.CustomActive(false);
				}
				if (this.contentLabelTwo != null)
				{
					this.contentLabelTwo.text = this._commonMsgBoxOkCancelNewParamData.ContentLabel;
					this.contentLabelTwo.gameObject.CustomActive(true);
					if (this._commonMsgBoxOkCancelNewParamData.ContentTextAnchor != 4)
					{
						this.contentLabelTwo.alignment = this._commonMsgBoxOkCancelNewParamData.ContentTextAnchor;
					}
					if (this._commonMsgBoxOkCancelNewParamData.IsSetContentFontSize && this._commonMsgBoxOkCancelNewParamData.ContentFontSize > 0)
					{
						this.contentLabelTwo.fontSize = this._commonMsgBoxOkCancelNewParamData.ContentFontSize;
					}
				}
			}
		}

		// Token: 0x060090DC RID: 37084 RVA: 0x001ACF4C File Offset: 0x001AB34C
		private void InitButton()
		{
			if (!this._isMiddleButton)
			{
				if (this.middleButton != null)
				{
					this.middleButton.gameObject.CustomActive(false);
				}
				if (this.leftButton != null)
				{
					this.leftButton.gameObject.CustomActive(true);
					if (this.leftButtonText != null)
					{
						this.leftButtonText.text = this._commonMsgBoxOkCancelNewParamData.LeftButtonText;
					}
				}
				if (this.rightButton != null)
				{
					this.rightButton.gameObject.CustomActive(true);
					if (this.rightButtonText != null)
					{
						this.rightButtonText.text = this._commonMsgBoxOkCancelNewParamData.RightButtonText;
					}
				}
			}
			else
			{
				if (this.leftButton != null)
				{
					this.leftButton.gameObject.CustomActive(false);
				}
				if (this.rightButton != null)
				{
					this.rightButton.gameObject.CustomActive(false);
				}
				if (this.middleButton != null)
				{
					this.middleButton.gameObject.CustomActive(true);
					if (this.middleButtonText != null)
					{
						this.middleButtonText.text = this._commonMsgBoxOkCancelNewParamData.MiddleButtonText;
					}
				}
			}
		}

		// Token: 0x060090DD RID: 37085 RVA: 0x001AD0AA File Offset: 0x001AB4AA
		private void OnToggleClick(bool value)
		{
			if (this._onCommonMsgBoxToggleClick != null)
			{
				this._onCommonMsgBoxToggleClick(value);
			}
		}

		// Token: 0x060090DE RID: 37086 RVA: 0x001AD0C3 File Offset: 0x001AB4C3
		private void OnLeftButtonClick()
		{
			this.OnCloseFrame();
			if (this._onLeftButtonClickCallBack != null)
			{
				this._onLeftButtonClickCallBack();
			}
		}

		// Token: 0x060090DF RID: 37087 RVA: 0x001AD0E1 File Offset: 0x001AB4E1
		private void OnRightButtonClick()
		{
			this.OnCloseFrame();
			if (this._onRightButtonClickCallBack != null)
			{
				this._onRightButtonClickCallBack();
			}
		}

		// Token: 0x060090E0 RID: 37088 RVA: 0x001AD0FF File Offset: 0x001AB4FF
		private void OnMiddleButtonClick()
		{
			this.OnCloseFrame();
			if (this._onMiddleButtonClickCallBack != null)
			{
				this._onMiddleButtonClickCallBack();
			}
		}

		// Token: 0x060090E1 RID: 37089 RVA: 0x001AD11D File Offset: 0x001AB51D
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxOkCancelNewFrame>(null, false);
		}

		// Token: 0x0400481F RID: 18463
		private CommonMsgBoxOkCancelNewParamData _commonMsgBoxOkCancelNewParamData;

		// Token: 0x04004820 RID: 18464
		private bool _isShowNotify;

		// Token: 0x04004821 RID: 18465
		private OnCommonMsgBoxToggleClick _onCommonMsgBoxToggleClick;

		// Token: 0x04004822 RID: 18466
		private Action _onLeftButtonClickCallBack;

		// Token: 0x04004823 RID: 18467
		private Action _onRightButtonClickCallBack;

		// Token: 0x04004824 RID: 18468
		private bool _isMiddleButton;

		// Token: 0x04004825 RID: 18469
		private Action _onMiddleButtonClickCallBack;

		// Token: 0x04004826 RID: 18470
		[Space(10f)]
		[Header("Content")]
		[SerializeField]
		private Text contentLabelOne;

		// Token: 0x04004827 RID: 18471
		[SerializeField]
		private Text contentLabelTwo;

		// Token: 0x04004828 RID: 18472
		[SerializeField]
		private GameObject notifyToggleRoot;

		// Token: 0x04004829 RID: 18473
		[SerializeField]
		private Toggle notifyToggle;

		// Token: 0x0400482A RID: 18474
		[Space(10f)]
		[Header("Button")]
		[SerializeField]
		private Button leftButton;

		// Token: 0x0400482B RID: 18475
		[SerializeField]
		private Text leftButtonText;

		// Token: 0x0400482C RID: 18476
		[SerializeField]
		private Button rightButton;

		// Token: 0x0400482D RID: 18477
		[SerializeField]
		private Text rightButtonText;

		// Token: 0x0400482E RID: 18478
		[SerializeField]
		private Button middleButton;

		// Token: 0x0400482F RID: 18479
		[SerializeField]
		private Text middleButtonText;
	}
}
