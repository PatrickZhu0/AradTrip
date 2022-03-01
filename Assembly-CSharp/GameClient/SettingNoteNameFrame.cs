using System;
using Network;
using Protocol;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A0B RID: 6667
	public class SettingNoteNameFrame : ClientFrame
	{
		// Token: 0x060105D4 RID: 67028 RVA: 0x00498C88 File Offset: 0x00497088
		protected sealed override void _bindExUI()
		{
			this.mOk = this.mBind.GetCom<Button>("Ok");
			if (null != this.mOk)
			{
				this.mOk.onClick.AddListener(new UnityAction(this._onOkButtonClick));
			}
			this.mCount = this.mBind.GetCom<Text>("Count");
			this.mInputField = this.mBind.GetCom<InputField>("InputField");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x060105D5 RID: 67029 RVA: 0x00498D48 File Offset: 0x00497148
		protected sealed override void _unbindExUI()
		{
			if (null != this.mOk)
			{
				this.mOk.onClick.RemoveListener(new UnityAction(this._onOkButtonClick));
			}
			this.mOk = null;
			this.mCount = null;
			this.mInputField = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x060105D6 RID: 67030 RVA: 0x00498DCC File Offset: 0x004971CC
		private void _onOkButtonClick()
		{
			if (this.relationData != null)
			{
				if (this.relationData.remark != null && this.relationData.remark != string.Empty)
				{
					if (this.mInputField.text != this.relationData.remark)
					{
						this.SendWorldSetPlayerRemarkReq();
					}
				}
				else if (this.mInputField.text != this.relationData.name)
				{
					this.SendWorldSetPlayerRemarkReq();
				}
			}
			this._onCloseButtonClick();
		}

		// Token: 0x060105D7 RID: 67031 RVA: 0x00498E68 File Offset: 0x00497268
		private void SendWorldSetPlayerRemarkReq()
		{
			WorldSetPlayerRemarkReq worldSetPlayerRemarkReq = new WorldSetPlayerRemarkReq();
			worldSetPlayerRemarkReq.roleId = this.relationData.uid;
			worldSetPlayerRemarkReq.remark = this.mInputField.text;
			NetManager.Instance().SendCommand<WorldSetPlayerRemarkReq>(ServerType.GATE_SERVER, worldSetPlayerRemarkReq);
		}

		// Token: 0x060105D8 RID: 67032 RVA: 0x00498EAA File Offset: 0x004972AA
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<SettingNoteNameFrame>(this, false);
		}

		// Token: 0x060105D9 RID: 67033 RVA: 0x00498EB9 File Offset: 0x004972B9
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RelationFrame/SettingNoteName";
		}

		// Token: 0x060105DA RID: 67034 RVA: 0x00498EC0 File Offset: 0x004972C0
		protected sealed override void _OnOpenFrame()
		{
			this.relationData = (this.userData as RelationData);
			int.TryParse(TR.Value("m_notename_maxcount"), out this.mNoteNameMaxCount);
			if (this.relationData.remark != null && this.relationData.remark != string.Empty)
			{
				this.mInputField.text = this.relationData.remark;
			}
			else
			{
				this.mInputField.text = this.relationData.name;
			}
			this.mCount.text = string.Format("{0}/{1}", this.mInputField.text.Length, this.mNoteNameMaxCount);
			this.mInputField.onValueChanged.AddListener(delegate(string a_strValue)
			{
				this.mCount.text = string.Format("{0}/{1}", a_strValue.Length, this.mNoteNameMaxCount);
			});
		}

		// Token: 0x060105DB RID: 67035 RVA: 0x00498FA0 File Offset: 0x004973A0
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x0400A5D6 RID: 42454
		private RelationData relationData;

		// Token: 0x0400A5D7 RID: 42455
		private int mNoteNameMaxCount = 8;

		// Token: 0x0400A5D8 RID: 42456
		private Button mOk;

		// Token: 0x0400A5D9 RID: 42457
		private Text mCount;

		// Token: 0x0400A5DA RID: 42458
		private InputField mInputField;

		// Token: 0x0400A5DB RID: 42459
		private Button mClose;
	}
}
