using System;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019A8 RID: 6568
	public class Pk3v3CheckPasswordFrame : ClientFrame
	{
		// Token: 0x06010027 RID: 65575 RVA: 0x00470529 File Offset: 0x0046E929
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3/Pk3v3PasswordAuthentication";
		}

		// Token: 0x06010028 RID: 65576 RVA: 0x00470530 File Offset: 0x0046E930
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.simpleinfo = (RoomSimpleInfo)this.userData;
			}
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x06010029 RID: 65577 RVA: 0x0047055A File Offset: 0x0046E95A
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x0601002A RID: 65578 RVA: 0x00470568 File Offset: 0x0046E968
		private void ClearData()
		{
			this.simpleinfo = null;
			this.password = string.Empty;
		}

		// Token: 0x0601002B RID: 65579 RVA: 0x0047057C File Offset: 0x0046E97C
		protected void BindUIEvent()
		{
			this.mPassword.onValueChanged.AddListener(new UnityAction<string>(this.OnPasswordInputEnd));
		}

		// Token: 0x0601002C RID: 65580 RVA: 0x0047059A File Offset: 0x0046E99A
		protected void UnBindUIEvent()
		{
			this.mPassword.onValueChanged.RemoveListener(new UnityAction<string>(this.OnPasswordInputEnd));
		}

		// Token: 0x0601002D RID: 65581 RVA: 0x004705B8 File Offset: 0x0046E9B8
		private void OnPasswordInputEnd(string passWord)
		{
			if (string.IsNullOrEmpty(passWord))
			{
				return;
			}
			this.password = passWord;
		}

		// Token: 0x0601002E RID: 65582 RVA: 0x004705CD File Offset: 0x0046E9CD
		private void InitInterface()
		{
		}

		// Token: 0x0601002F RID: 65583 RVA: 0x004705D0 File Offset: 0x0046E9D0
		protected override void _bindExUI()
		{
			this.mPassword = this.mBind.GetCom<InputField>("Password");
			this.mBtOk = this.mBind.GetCom<Button>("btOk");
			this.mBtOk.onClick.AddListener(new UnityAction(this._onBtOkButtonClick));
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
		}

		// Token: 0x06010030 RID: 65584 RVA: 0x00470658 File Offset: 0x0046EA58
		protected override void _unbindExUI()
		{
			this.mPassword = null;
			this.mBtOk.onClick.RemoveListener(new UnityAction(this._onBtOkButtonClick));
			this.mBtOk = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
		}

		// Token: 0x06010031 RID: 65585 RVA: 0x004706B4 File Offset: 0x0046EAB4
		private void _onBtOkButtonClick()
		{
			if (this.simpleinfo == null)
			{
				return;
			}
			bool flag = false;
			int num = 0;
			if (int.TryParse(this.password, out num))
			{
				if (num < 1000 || num > 9999)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("密码格式错误,请输入4位数字密码", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect("密码格式错误,请输入4位数字密码", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			if (flag)
			{
				Pk3v3DataManager.SendJoinRoomReq(this.simpleinfo.id, (RoomType)this.simpleinfo.roomType, this.password, 0U);
				this.frameMgr.CloseFrame<Pk3v3CheckPasswordFrame>(this, false);
			}
		}

		// Token: 0x06010032 RID: 65586 RVA: 0x00470752 File Offset: 0x0046EB52
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<Pk3v3CheckPasswordFrame>(this, false);
		}

		// Token: 0x0400A198 RID: 41368
		private RoomSimpleInfo simpleinfo;

		// Token: 0x0400A199 RID: 41369
		private string password = string.Empty;

		// Token: 0x0400A19A RID: 41370
		private InputField mPassword;

		// Token: 0x0400A19B RID: 41371
		private Button mBtOk;

		// Token: 0x0400A19C RID: 41372
		private Button mBtClose;
	}
}
