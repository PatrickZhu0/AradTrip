using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E29 RID: 3625
	public class CommonSetContentView : MonoBehaviour
	{
		// Token: 0x060090F9 RID: 37113 RVA: 0x001AD2ED File Offset: 0x001AB6ED
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x060090FA RID: 37114 RVA: 0x001AD2F5 File Offset: 0x001AB6F5
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x060090FB RID: 37115 RVA: 0x001AD304 File Offset: 0x001AB704
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
				this.okButton.onClick.AddListener(new UnityAction(this.OnOkButtonClick));
			}
			if (this.contentInputField != null)
			{
				this.contentInputField.onValueChanged.RemoveAllListeners();
				this.contentInputField.onValueChanged.AddListener(new UnityAction<string>(this.OnContentInputFieldValueChanged));
			}
		}

		// Token: 0x060090FC RID: 37116 RVA: 0x001AD3C8 File Offset: 0x001AB7C8
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
			}
			if (this.contentInputField != null)
			{
				this.contentInputField.onValueChanged.RemoveAllListeners();
			}
		}

		// Token: 0x060090FD RID: 37117 RVA: 0x001AD438 File Offset: 0x001AB838
		private void ClearData()
		{
			this._setContentDataModel = null;
			this._onOkClick = null;
		}

		// Token: 0x060090FE RID: 37118 RVA: 0x001AD448 File Offset: 0x001AB848
		public void Init(CommonSetContentDataModel setContentDataModel)
		{
			this._setContentDataModel = setContentDataModel;
			if (this._setContentDataModel == null)
			{
				return;
			}
			this._titleStr = this._setContentDataModel.TitleStr;
			this._defaultEmptyStr = setContentDataModel.DefaultEmptyStr;
			this._maxWorldNumber = this._setContentDataModel.MaxWordNumber;
			this._onOkClick = this._setContentDataModel.OnOkClicked;
			this._inputContentStr = this._setContentDataModel.DefaultContentStr;
			this.InitView();
		}

		// Token: 0x060090FF RID: 37119 RVA: 0x001AD4C0 File Offset: 0x001AB8C0
		private void InitView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = this._titleStr;
			}
			if (this.contentPlaceHolderLabel != null)
			{
				this.contentPlaceHolderLabel.text = this._defaultEmptyStr;
			}
			if (this.contentInputField != null)
			{
				this.contentInputField.text = this._inputContentStr;
			}
			this.UpdateInputWorldNumberLabel();
		}

		// Token: 0x06009100 RID: 37120 RVA: 0x001AD53C File Offset: 0x001AB93C
		private void OnOkButtonClick()
		{
			if (string.IsNullOrEmpty(this._inputContentStr))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Common_Set_Content_With_None_Word"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else if (this._inputContentStr.Length <= 0)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Common_Set_Content_With_None_Word"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else if (this._inputContentStr.Length > this._maxWorldNumber)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Common_Set_Content_With_Exceed_Max_Word"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else if (this._onOkClick != null)
			{
				this._onOkClick.Invoke(this._inputContentStr);
			}
		}

		// Token: 0x06009101 RID: 37121 RVA: 0x001AD5DB File Offset: 0x001AB9DB
		private void OnContentInputFieldValueChanged(string valueStr)
		{
			this._inputContentStr = valueStr;
			this.UpdateInputWorldNumberLabel();
		}

		// Token: 0x06009102 RID: 37122 RVA: 0x001AD5EC File Offset: 0x001AB9EC
		private void UpdateInputWorldNumberLabel()
		{
			int num = 0;
			if (!string.IsNullOrEmpty(this._inputContentStr))
			{
				num = this._inputContentStr.Length;
			}
			if (this.inputWorldNumberLabel != null)
			{
				string text = TR.Value("Common_Two_Number_Format_One", num, this._maxWorldNumber);
				this.inputWorldNumberLabel.text = text;
			}
		}

		// Token: 0x06009103 RID: 37123 RVA: 0x001AD650 File Offset: 0x001ABA50
		private void OnCloseButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonSetContentFrame>(null, false);
		}

		// Token: 0x04004841 RID: 18497
		private string _titleStr;

		// Token: 0x04004842 RID: 18498
		private string _defaultEmptyStr;

		// Token: 0x04004843 RID: 18499
		private int _maxWorldNumber;

		// Token: 0x04004844 RID: 18500
		private UnityAction<string> _onOkClick;

		// Token: 0x04004845 RID: 18501
		private string _inputContentStr;

		// Token: 0x04004846 RID: 18502
		private CommonSetContentDataModel _setContentDataModel;

		// Token: 0x04004847 RID: 18503
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04004848 RID: 18504
		[Space(10f)]
		[Header("Input")]
		[Space(10f)]
		[SerializeField]
		private Text inputWorldNumberLabel;

		// Token: 0x04004849 RID: 18505
		[SerializeField]
		private Text contentPlaceHolderLabel;

		// Token: 0x0400484A RID: 18506
		[SerializeField]
		private InputField contentInputField;

		// Token: 0x0400484B RID: 18507
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400484C RID: 18508
		[SerializeField]
		private Button okButton;
	}
}
