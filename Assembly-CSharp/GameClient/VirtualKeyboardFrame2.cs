using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001779 RID: 6009
	internal class VirtualKeyboardFrame2 : ClientFrame
	{
		// Token: 0x0600ED6D RID: 60781 RVA: 0x003FA63B File Offset: 0x003F8A3B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mall/VirtualKeyboard";
		}

		// Token: 0x0600ED6E RID: 60782 RVA: 0x003FA644 File Offset: 0x003F8A44
		protected override void _OnOpenFrame()
		{
			if (this.userData != null && this.KeyboardBg != null)
			{
				if (this.userData is float)
				{
					float num = (float)this.userData;
					Vector3 position = this.KeyboardBg.transform.position;
					position.x += num;
					this.KeyboardBg.transform.position = position;
				}
				else if (this.userData is Vector3)
				{
					Vector3 position2 = (Vector3)this.userData;
					this.KeyboardBg.transform.position = position2;
				}
			}
		}

		// Token: 0x0600ED6F RID: 60783 RVA: 0x003FA6EC File Offset: 0x003F8AEC
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600ED70 RID: 60784 RVA: 0x003FA6F0 File Offset: 0x003F8AF0
		protected override void _bindExUI()
		{
			this.mKeyDel = this.mBind.GetCom<Button>("KeyDel");
			this.mKeyDel.onClick.AddListener(new UnityAction(this._onKeyDelButtonClick));
			this.mKeyClose = this.mBind.GetCom<Button>("KeyClose");
			this.mKeyClose.onClick.AddListener(new UnityAction(this._onKeyCloseButtonClick));
			this.mKey0 = this.mBind.GetCom<Button>("Key0");
			this.mKey0.onClick.AddListener(new UnityAction(this._onKey0ButtonClick));
			this.mKey9 = this.mBind.GetCom<Button>("Key9");
			this.mKey9.onClick.AddListener(new UnityAction(this._onKey9ButtonClick));
			this.mKey8 = this.mBind.GetCom<Button>("Key8");
			this.mKey8.onClick.AddListener(new UnityAction(this._onKey8ButtonClick));
			this.mKey7 = this.mBind.GetCom<Button>("Key7");
			this.mKey7.onClick.AddListener(new UnityAction(this._onKey7ButtonClick));
			this.mKey6 = this.mBind.GetCom<Button>("Key6");
			this.mKey6.onClick.AddListener(new UnityAction(this._onKey6ButtonClick));
			this.mKey5 = this.mBind.GetCom<Button>("Key5");
			this.mKey5.onClick.AddListener(new UnityAction(this._onKey5ButtonClick));
			this.mKey4 = this.mBind.GetCom<Button>("Key4");
			this.mKey4.onClick.AddListener(new UnityAction(this._onKey4ButtonClick));
			this.mKey3 = this.mBind.GetCom<Button>("Key3");
			this.mKey3.onClick.AddListener(new UnityAction(this._onKey3ButtonClick));
			this.mKey2 = this.mBind.GetCom<Button>("Key2");
			this.mKey2.onClick.AddListener(new UnityAction(this._onKey2ButtonClick));
			this.mKey1 = this.mBind.GetCom<Button>("Key1");
			this.mKey1.onClick.AddListener(new UnityAction(this._onKey1ButtonClick));
			this.mCloseBg = this.mBind.GetCom<Button>("CloseBg");
			this.mCloseBg.onClick.AddListener(new UnityAction(this._onCloseBgButtonClick));
			this.KeyboardBg = this.mBind.GetGameObject("KeyboardBg");
		}

		// Token: 0x0600ED71 RID: 60785 RVA: 0x003FA9A0 File Offset: 0x003F8DA0
		protected override void _unbindExUI()
		{
			this.mKeyDel.onClick.RemoveListener(new UnityAction(this._onKeyDelButtonClick));
			this.mKeyDel = null;
			this.mKeyClose.onClick.RemoveListener(new UnityAction(this._onKeyCloseButtonClick));
			this.mKeyClose = null;
			this.mKey0.onClick.RemoveListener(new UnityAction(this._onKey0ButtonClick));
			this.mKey0 = null;
			this.mKey9.onClick.RemoveListener(new UnityAction(this._onKey9ButtonClick));
			this.mKey9 = null;
			this.mKey8.onClick.RemoveListener(new UnityAction(this._onKey8ButtonClick));
			this.mKey8 = null;
			this.mKey7.onClick.RemoveListener(new UnityAction(this._onKey7ButtonClick));
			this.mKey7 = null;
			this.mKey6.onClick.RemoveListener(new UnityAction(this._onKey6ButtonClick));
			this.mKey6 = null;
			this.mKey5.onClick.RemoveListener(new UnityAction(this._onKey5ButtonClick));
			this.mKey5 = null;
			this.mKey4.onClick.RemoveListener(new UnityAction(this._onKey4ButtonClick));
			this.mKey4 = null;
			this.mKey3.onClick.RemoveListener(new UnityAction(this._onKey3ButtonClick));
			this.mKey3 = null;
			this.mKey2.onClick.RemoveListener(new UnityAction(this._onKey2ButtonClick));
			this.mKey2 = null;
			this.mKey1.onClick.RemoveListener(new UnityAction(this._onKey1ButtonClick));
			this.mKey1 = null;
			this.mCloseBg.onClick.RemoveListener(new UnityAction(this._onCloseBgButtonClick));
			this.mCloseBg = null;
			this.KeyboardBg = null;
		}

		// Token: 0x0600ED72 RID: 60786 RVA: 0x003FAB7B File Offset: 0x003F8F7B
		private void _onKeyDelButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.BackSpace, null, null, null);
		}

		// Token: 0x0600ED73 RID: 60787 RVA: 0x003FAB95 File Offset: 0x003F8F95
		private void _onKeyCloseButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.EnSure, null, null, null);
			this.frameMgr.CloseFrame<VirtualKeyboardFrame2>(this, false);
		}

		// Token: 0x0600ED74 RID: 60788 RVA: 0x003FABBC File Offset: 0x003F8FBC
		private void _onKey0ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 0, null, null);
		}

		// Token: 0x0600ED75 RID: 60789 RVA: 0x003FABDB File Offset: 0x003F8FDB
		private void _onKey9ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 9, null, null);
		}

		// Token: 0x0600ED76 RID: 60790 RVA: 0x003FABFB File Offset: 0x003F8FFB
		private void _onKey8ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 8, null, null);
		}

		// Token: 0x0600ED77 RID: 60791 RVA: 0x003FAC1A File Offset: 0x003F901A
		private void _onKey7ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 7, null, null);
		}

		// Token: 0x0600ED78 RID: 60792 RVA: 0x003FAC39 File Offset: 0x003F9039
		private void _onKey6ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 6, null, null);
		}

		// Token: 0x0600ED79 RID: 60793 RVA: 0x003FAC58 File Offset: 0x003F9058
		private void _onKey5ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 5, null, null);
		}

		// Token: 0x0600ED7A RID: 60794 RVA: 0x003FAC77 File Offset: 0x003F9077
		private void _onKey4ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 4, null, null);
		}

		// Token: 0x0600ED7B RID: 60795 RVA: 0x003FAC96 File Offset: 0x003F9096
		private void _onKey3ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 3, null, null);
		}

		// Token: 0x0600ED7C RID: 60796 RVA: 0x003FACB5 File Offset: 0x003F90B5
		private void _onKey2ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 2, null, null);
		}

		// Token: 0x0600ED7D RID: 60797 RVA: 0x003FACD4 File Offset: 0x003F90D4
		private void _onKey1ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.Add, 1, null, null);
		}

		// Token: 0x0600ED7E RID: 60798 RVA: 0x003FACF3 File Offset: 0x003F90F3
		private void _onCloseBgButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum2, ChangeNumType.EnSure, null, null, null);
			this.frameMgr.CloseFrame<VirtualKeyboardFrame2>(this, false);
		}

		// Token: 0x040090E8 RID: 37096
		private Button mKeyDel;

		// Token: 0x040090E9 RID: 37097
		private Button mKeyClose;

		// Token: 0x040090EA RID: 37098
		private Button mKey0;

		// Token: 0x040090EB RID: 37099
		private Button mKey9;

		// Token: 0x040090EC RID: 37100
		private Button mKey8;

		// Token: 0x040090ED RID: 37101
		private Button mKey7;

		// Token: 0x040090EE RID: 37102
		private Button mKey6;

		// Token: 0x040090EF RID: 37103
		private Button mKey5;

		// Token: 0x040090F0 RID: 37104
		private Button mKey4;

		// Token: 0x040090F1 RID: 37105
		private Button mKey3;

		// Token: 0x040090F2 RID: 37106
		private Button mKey2;

		// Token: 0x040090F3 RID: 37107
		private Button mKey1;

		// Token: 0x040090F4 RID: 37108
		private Button mCloseBg;

		// Token: 0x040090F5 RID: 37109
		private GameObject KeyboardBg;
	}
}
