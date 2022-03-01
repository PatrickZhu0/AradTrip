using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E09 RID: 3593
	public class CommonKeyBoardNumberItem : MonoBehaviour
	{
		// Token: 0x06008FF2 RID: 36850 RVA: 0x001A9AE6 File Offset: 0x001A7EE6
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06008FF3 RID: 36851 RVA: 0x001A9AEE File Offset: 0x001A7EEE
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06008FF4 RID: 36852 RVA: 0x001A9AFC File Offset: 0x001A7EFC
		private void BindEvents()
		{
			if (this.numberButton != null)
			{
				this.numberButton.onClick.RemoveAllListeners();
				this.numberButton.onClick.AddListener(new UnityAction(this.OnKeyBoardNumberClicked));
			}
		}

		// Token: 0x06008FF5 RID: 36853 RVA: 0x001A9B3B File Offset: 0x001A7F3B
		private void UnBindEvents()
		{
			if (this.numberButton != null)
			{
				this.numberButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06008FF6 RID: 36854 RVA: 0x001A9B5E File Offset: 0x001A7F5E
		private void ClearData()
		{
			this._keyBoardNumberType = KeyBoardNumberType.None;
			this._onCommonKeyBoardNumberClicked = null;
		}

		// Token: 0x06008FF7 RID: 36855 RVA: 0x001A9B70 File Offset: 0x001A7F70
		public void InitItem(KeyBoardNumberType keyBoardNumberType, OnCommonKeyBoardNumberClicked onCommonKeyBoardNumberClicked)
		{
			this._keyBoardNumberType = keyBoardNumberType;
			this._onCommonKeyBoardNumberClicked = onCommonKeyBoardNumberClicked;
			if (this._keyBoardNumberType >= KeyBoardNumberType.Zero && this._keyBoardNumberType <= KeyBoardNumberType.Nine && this.numberValue != null)
			{
				Text text = this.numberValue;
				int keyBoardNumberType2 = (int)this._keyBoardNumberType;
				text.text = keyBoardNumberType2.ToString();
			}
			base.gameObject.name = "Key_Number_" + this._keyBoardNumberType.ToString();
		}

		// Token: 0x06008FF8 RID: 36856 RVA: 0x001A9BFA File Offset: 0x001A7FFA
		private void OnKeyBoardNumberClicked()
		{
			if (this._onCommonKeyBoardNumberClicked != null)
			{
				this._onCommonKeyBoardNumberClicked(this._keyBoardNumberType);
			}
		}

		// Token: 0x0400476D RID: 18285
		private const string ItemNameBase = "Key_Number_";

		// Token: 0x0400476E RID: 18286
		private KeyBoardNumberType _keyBoardNumberType;

		// Token: 0x0400476F RID: 18287
		private OnCommonKeyBoardNumberClicked _onCommonKeyBoardNumberClicked;

		// Token: 0x04004770 RID: 18288
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button numberButton;

		// Token: 0x04004771 RID: 18289
		[SerializeField]
		private Text numberValue;
	}
}
