using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace GameClient
{
	// Token: 0x020017D1 RID: 6097
	public class SendDoorMapModelItem : MonoBehaviour
	{
		// Token: 0x0600F064 RID: 61540 RVA: 0x0040B3E6 File Offset: 0x004097E6
		private void Awake()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600F065 RID: 61541 RVA: 0x0040B425 File Offset: 0x00409825
		private void ResetData()
		{
			this._isSelected = false;
			this._sendDoorModelData = null;
			this._onSendDoorMapToggleClick = null;
		}

		// Token: 0x0600F066 RID: 61542 RVA: 0x0040B43C File Offset: 0x0040983C
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x0600F067 RID: 61543 RVA: 0x0040B468 File Offset: 0x00409868
		public void Init(SendDoorModelData sendDoorModelData, OnSendDoorMapToggleClick onSendDoorMapToggleClick, bool isSelected = false)
		{
			this.ResetData();
			this._sendDoorModelData = sendDoorModelData;
			if (this._sendDoorModelData == null)
			{
				return;
			}
			this._onSendDoorMapToggleClick = onSendDoorMapToggleClick;
			if (this.normalTabName != null && !string.IsNullOrEmpty(this._sendDoorModelData.ToggleName))
			{
				this.normalTabName.text = this._sendDoorModelData.ToggleName;
			}
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x0600F068 RID: 61544 RVA: 0x0040B4F4 File Offset: 0x004098F4
		private void UpdateTabImage()
		{
		}

		// Token: 0x0600F069 RID: 61545 RVA: 0x0040B4F8 File Offset: 0x004098F8
		private void OnTabClicked(bool value)
		{
			if (this._sendDoorModelData == null)
			{
				return;
			}
			if (this._isSelected == value)
			{
				return;
			}
			this._isSelected = value;
			if (value && this._onSendDoorMapToggleClick != null)
			{
				this._onSendDoorMapToggleClick(this._sendDoorModelData.ModelType);
			}
		}

		// Token: 0x0400935A RID: 37722
		private const string NormalTabImagePath = "UI/Image/Packed/p_UI_Tuanben_02.png:UI_Tuanben_Tab_01";

		// Token: 0x0400935B RID: 37723
		private const string SelectedTabImagePath = "UI/Image/Packed/p_UI_Tuanben_02.png:UI_Tuanben_Tab_02";

		// Token: 0x0400935C RID: 37724
		private bool _isSelected;

		// Token: 0x0400935D RID: 37725
		private SendDoorModelData _sendDoorModelData;

		// Token: 0x0400935E RID: 37726
		private OnSendDoorMapToggleClick _onSendDoorMapToggleClick;

		// Token: 0x0400935F RID: 37727
		[Space(10f)]
		[Header("TabName")]
		[Space(10f)]
		[SerializeField]
		private Text normalTabName;

		// Token: 0x04009360 RID: 37728
		[SerializeField]
		private ComChangeColor nameComChangeColor;

		// Token: 0x04009361 RID: 37729
		[SerializeField]
		private NicerOutline nameNicerOutLine;

		// Token: 0x04009362 RID: 37730
		[Space(10f)]
		[Header("ToggleName")]
		[Space(10f)]
		[SerializeField]
		private Toggle toggle;

		// Token: 0x04009363 RID: 37731
		[SerializeField]
		private Image normalTabImage;

		// Token: 0x04009364 RID: 37732
		[SerializeField]
		private Image selectedTabImage;
	}
}
