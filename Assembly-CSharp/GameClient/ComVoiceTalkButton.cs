using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200156B RID: 5483
	public class ComVoiceTalkButton : MonoBehaviour
	{
		// Token: 0x17001C1D RID: 7197
		// (get) Token: 0x0600D646 RID: 54854 RVA: 0x0035895D File Offset: 0x00356D5D
		public ComVoiceTalkButton.OnTalkButtonClick onClick
		{
			get
			{
				if (this._onClick == null)
				{
					this._onClick = new ComVoiceTalkButton.OnTalkButtonClick();
				}
				return this._onClick;
			}
		}

		// Token: 0x17001C1E RID: 7198
		// (get) Token: 0x0600D647 RID: 54855 RVA: 0x0035897B File Offset: 0x00356D7B
		public ComVoiceTalkButton.TalkBtnType bType
		{
			get
			{
				if (this.talkBtnUnit != null)
				{
					return this.talkBtnUnit.talkBtnType;
				}
				return ComVoiceTalkButton.TalkBtnType.None;
			}
		}

		// Token: 0x17001C1F RID: 7199
		// (get) Token: 0x0600D648 RID: 54856 RVA: 0x00358995 File Offset: 0x00356D95
		public bool isMicType
		{
			get
			{
				return this.bType != ComVoiceTalkButton.TalkBtnType.None && this.bType <= ComVoiceTalkButton.TalkBtnType.MicSwitch;
			}
		}

		// Token: 0x17001C20 RID: 7200
		// (get) Token: 0x0600D649 RID: 54857 RVA: 0x003589B1 File Offset: 0x00356DB1
		public bool isPlayerType
		{
			get
			{
				return this.bType != ComVoiceTalkButton.TalkBtnType.None && this.bType >= ComVoiceTalkButton.TalkBtnType.PlayerSwitch;
			}
		}

		// Token: 0x17001C21 RID: 7201
		// (get) Token: 0x0600D64A RID: 54858 RVA: 0x003589CD File Offset: 0x00356DCD
		public bool isLimitSpeakType
		{
			get
			{
				return this.bType == ComVoiceTalkButton.TalkBtnType.MicAllNotSpeak;
			}
		}

		// Token: 0x17001C22 RID: 7202
		// (get) Token: 0x0600D64B RID: 54859 RVA: 0x003589DE File Offset: 0x00356DDE
		// (set) Token: 0x0600D64C RID: 54860 RVA: 0x003589E6 File Offset: 0x00356DE6
		public object param1 { get; set; }

		// Token: 0x17001C23 RID: 7203
		// (get) Token: 0x0600D64D RID: 54861 RVA: 0x003589EF File Offset: 0x00356DEF
		// (set) Token: 0x0600D64E RID: 54862 RVA: 0x003589F7 File Offset: 0x00356DF7
		public ComVoiceTalkButtonGroup group { get; set; }

		// Token: 0x17001C24 RID: 7204
		// (get) Token: 0x0600D64F RID: 54863 RVA: 0x00358A00 File Offset: 0x00356E00
		// (set) Token: 0x0600D650 RID: 54864 RVA: 0x00358A08 File Offset: 0x00356E08
		public int sortIndex { get; set; }

		// Token: 0x0600D651 RID: 54865 RVA: 0x00358A14 File Offset: 0x00356E14
		private void Awake()
		{
			if (this.talkBtnUnit != null && this.talkBtnUnit.talkBtn != null)
			{
				this.talkBtnUnit.talkBtn.onClick.AddListener(new UnityAction(this._OnTalkBtnClick));
			}
			this._InitView();
		}

		// Token: 0x0600D652 RID: 54866 RVA: 0x00358A6C File Offset: 0x00356E6C
		private void OnDestroy()
		{
			if (this.talkBtnUnit != null && this.talkBtnUnit.talkBtn != null)
			{
				this.talkBtnUnit.talkBtn.onClick.RemoveListener(new UnityAction(this._OnTalkBtnClick));
			}
			this.talkBtnUnit = null;
			this._onClick = null;
			this.param1 = null;
			this.group = null;
			this.sortIndex = -1;
		}

		// Token: 0x0600D653 RID: 54867 RVA: 0x00358ADE File Offset: 0x00356EDE
		private void _InitView()
		{
			if (this.isLimitSpeakType)
			{
				this.SetBtnStatus(true);
			}
			else
			{
				this.SetBtnStatus(false);
			}
		}

		// Token: 0x0600D654 RID: 54868 RVA: 0x00358B00 File Offset: 0x00356F00
		private void _OnTalkBtnClick()
		{
			if (this.talkBtnUnit == null || this.talkBtnUnit.talkBtnType == ComVoiceTalkButton.TalkBtnType.None)
			{
				return;
			}
			if (this.onClick != null)
			{
				this.onClick.Invoke(this.talkBtnUnit.talkBtnType, this, this.param1);
			}
		}

		// Token: 0x0600D655 RID: 54869 RVA: 0x00358B54 File Offset: 0x00356F54
		public void SetMarkIconShow(bool isShow)
		{
			if (this.talkBtnUnit == null)
			{
				return;
			}
			if (this.talkBtnUnit.talkBtnType == ComVoiceTalkButton.TalkBtnType.MicChannelOn || this.talkBtnUnit.talkBtnType == ComVoiceTalkButton.TalkBtnType.MicSwitch || this.talkBtnUnit.talkBtnType == ComVoiceTalkButton.TalkBtnType.PlayerSwitch || this.talkBtnUnit.talkBtnType == ComVoiceTalkButton.TalkBtnType.MicAllOff)
			{
				if (this.talkBtnUnit.talkMark)
				{
					this.talkBtnUnit.talkMark.enabled = !isShow;
				}
				if (this.talkBtnUnit.talkMarkImg)
				{
					this.talkBtnUnit.talkMarkImg.enabled = isShow;
				}
			}
		}

		// Token: 0x0600D656 RID: 54870 RVA: 0x00358C00 File Offset: 0x00357000
		public void SetBtnEnable(bool isEnable)
		{
			if (this.talkBtnUnit == null || null == this.talkBtnUnit.talkBtn)
			{
				return;
			}
			this.talkBtnUnit.talkBtn.interactable = isEnable;
		}

		// Token: 0x0600D657 RID: 54871 RVA: 0x00358C38 File Offset: 0x00357038
		public void SetBtnStatus(bool isOn)
		{
			if (this.talkBtnUnit == null)
			{
				return;
			}
			if (this.talkBtnUnit.talkMarkImg && this.talkBtnUnit.talkMarkImg.enabled)
			{
				return;
			}
			if (this.talkBtnUnit.talkBtnType != ComVoiceTalkButton.TalkBtnType.MicAllOff)
			{
				if (this.talkBtnUnit.talkBtnType == ComVoiceTalkButton.TalkBtnType.MicChannelOn && !isOn)
				{
					return;
				}
				if (this.talkBtnUnit.talkOnImg != null)
				{
					this.talkBtnUnit.talkOnImg.enabled = isOn;
				}
			}
			if (this.talkBtnUnit.talkBtnType != ComVoiceTalkButton.TalkBtnType.MicChannelOn)
			{
				if (this.talkBtnUnit.talkBtnType == ComVoiceTalkButton.TalkBtnType.MicAllOff && isOn)
				{
					return;
				}
				if (this.talkBtnUnit.talkOffImg != null)
				{
					this.talkBtnUnit.talkOffImg.enabled = !isOn;
				}
			}
		}

		// Token: 0x0600D658 RID: 54872 RVA: 0x00358D1F File Offset: 0x0035711F
		public void SetBtnMark(string mark)
		{
			if (this.talkBtnUnit == null)
			{
				return;
			}
			if (this.talkBtnUnit.talkMark)
			{
				this.talkBtnUnit.talkMark.text = mark;
			}
		}

		// Token: 0x0600D659 RID: 54873 RVA: 0x00358D53 File Offset: 0x00357153
		public void InitView(ComVoiceTalkButton.ComVoiceTalkButtonUnit btnUnit)
		{
			this.talkBtnUnit = btnUnit;
		}

		// Token: 0x04007DC9 RID: 32201
		private ComVoiceTalkButton.OnTalkButtonClick _onClick;

		// Token: 0x04007DCD RID: 32205
		[SerializeField]
		private ComVoiceTalkButton.ComVoiceTalkButtonUnit talkBtnUnit;

		// Token: 0x0200156C RID: 5484
		public enum TalkBtnType
		{
			// Token: 0x04007DCF RID: 32207
			None,
			// Token: 0x04007DD0 RID: 32208
			MicChannelOn,
			// Token: 0x04007DD1 RID: 32209
			MicAllOff,
			// Token: 0x04007DD2 RID: 32210
			MicSwitch,
			// Token: 0x04007DD3 RID: 32211
			MicAllNotSpeak,
			// Token: 0x04007DD4 RID: 32212
			PlayerSwitch
		}

		// Token: 0x0200156D RID: 5485
		[Serializable]
		public class OnTalkButtonClick : UnityEvent<ComVoiceTalkButton.TalkBtnType, ComVoiceTalkButton, object>
		{
		}

		// Token: 0x0200156E RID: 5486
		[Serializable]
		public class ComVoiceTalkButtonUnit
		{
			// Token: 0x0600D65B RID: 54875 RVA: 0x00358D64 File Offset: 0x00357164
			public ComVoiceTalkButtonUnit(Button btn, Image onImg, Image offImg, Text mark, Image markImg, ComVoiceTalkButton.TalkBtnType btnType)
			{
				this.talkBtn = btn;
				this.talkOnImg = onImg;
				this.talkOffImg = offImg;
				this.talkMark = mark;
				this.talkMarkImg = markImg;
				this.talkBtnType = btnType;
			}

			// Token: 0x0600D65C RID: 54876 RVA: 0x00358D9C File Offset: 0x0035719C
			public bool IsNull()
			{
				return null == this.talkBtn || null == this.talkOnImg || null == this.talkOffImg || this.talkBtnType == ComVoiceTalkButton.TalkBtnType.None;
			}

			// Token: 0x04007DD5 RID: 32213
			public Button talkBtn;

			// Token: 0x04007DD6 RID: 32214
			public Image talkOnImg;

			// Token: 0x04007DD7 RID: 32215
			public Image talkOffImg;

			// Token: 0x04007DD8 RID: 32216
			public Text talkMark;

			// Token: 0x04007DD9 RID: 32217
			public Image talkMarkImg;

			// Token: 0x04007DDA RID: 32218
			public ComVoiceTalkButton.TalkBtnType talkBtnType;
		}
	}
}
