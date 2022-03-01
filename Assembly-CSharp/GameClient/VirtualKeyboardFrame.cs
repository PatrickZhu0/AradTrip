using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001778 RID: 6008
	internal class VirtualKeyboardFrame : ClientFrame
	{
		// Token: 0x0600ED5A RID: 60762 RVA: 0x003F9F24 File Offset: 0x003F8324
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mall/VirtualKeyboard";
		}

		// Token: 0x0600ED5B RID: 60763 RVA: 0x003F9F2C File Offset: 0x003F832C
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				if (this.userData is float)
				{
					float num = (float)this.userData;
					Vector3 position = this.mBind.transform.position;
					position.x += num;
					this.mBind.transform.position = position;
					RectTransform rectTransform = this.mCloseBg.transform as RectTransform;
					if (rectTransform != null)
					{
						RectTransform rectTransform2 = this.mBind.transform as RectTransform;
						rectTransform.SetSizeWithCurrentAnchors(0, rectTransform.rect.width + Mathf.Abs(rectTransform2.offsetMin.x * 2f));
					}
				}
				else if (this.userData is Vector3)
				{
					Vector3 position2 = (Vector3)this.userData;
					this.mBind.transform.position = position2;
				}
			}
		}

		// Token: 0x0600ED5C RID: 60764 RVA: 0x003FA024 File Offset: 0x003F8424
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600ED5D RID: 60765 RVA: 0x003FA028 File Offset: 0x003F8428
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
		}

		// Token: 0x0600ED5E RID: 60766 RVA: 0x003FA2C0 File Offset: 0x003F86C0
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
		}

		// Token: 0x0600ED5F RID: 60767 RVA: 0x003FA494 File Offset: 0x003F8894
		private void _onKeyDelButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.BackSpace, null, null, null);
		}

		// Token: 0x0600ED60 RID: 60768 RVA: 0x003FA4AE File Offset: 0x003F88AE
		private void _onKeyCloseButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.EnSure, null, null, null);
			this.frameMgr.CloseFrame<VirtualKeyboardFrame>(this, false);
		}

		// Token: 0x0600ED61 RID: 60769 RVA: 0x003FA4D5 File Offset: 0x003F88D5
		private void _onKey0ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 0, null, null);
		}

		// Token: 0x0600ED62 RID: 60770 RVA: 0x003FA4F4 File Offset: 0x003F88F4
		private void _onKey9ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 9, null, null);
		}

		// Token: 0x0600ED63 RID: 60771 RVA: 0x003FA514 File Offset: 0x003F8914
		private void _onKey8ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 8, null, null);
		}

		// Token: 0x0600ED64 RID: 60772 RVA: 0x003FA533 File Offset: 0x003F8933
		private void _onKey7ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 7, null, null);
		}

		// Token: 0x0600ED65 RID: 60773 RVA: 0x003FA552 File Offset: 0x003F8952
		private void _onKey6ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 6, null, null);
		}

		// Token: 0x0600ED66 RID: 60774 RVA: 0x003FA571 File Offset: 0x003F8971
		private void _onKey5ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 5, null, null);
		}

		// Token: 0x0600ED67 RID: 60775 RVA: 0x003FA590 File Offset: 0x003F8990
		private void _onKey4ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 4, null, null);
		}

		// Token: 0x0600ED68 RID: 60776 RVA: 0x003FA5AF File Offset: 0x003F89AF
		private void _onKey3ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 3, null, null);
		}

		// Token: 0x0600ED69 RID: 60777 RVA: 0x003FA5CE File Offset: 0x003F89CE
		private void _onKey2ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 2, null, null);
		}

		// Token: 0x0600ED6A RID: 60778 RVA: 0x003FA5ED File Offset: 0x003F89ED
		private void _onKey1ButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.Add, 1, null, null);
		}

		// Token: 0x0600ED6B RID: 60779 RVA: 0x003FA60C File Offset: 0x003F8A0C
		private void _onCloseBgButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeNum, ChangeNumType.EnSure, null, null, null);
			this.frameMgr.CloseFrame<VirtualKeyboardFrame>(this, false);
		}

		// Token: 0x040090DB RID: 37083
		private Button mKeyDel;

		// Token: 0x040090DC RID: 37084
		private Button mKeyClose;

		// Token: 0x040090DD RID: 37085
		private Button mKey0;

		// Token: 0x040090DE RID: 37086
		private Button mKey9;

		// Token: 0x040090DF RID: 37087
		private Button mKey8;

		// Token: 0x040090E0 RID: 37088
		private Button mKey7;

		// Token: 0x040090E1 RID: 37089
		private Button mKey6;

		// Token: 0x040090E2 RID: 37090
		private Button mKey5;

		// Token: 0x040090E3 RID: 37091
		private Button mKey4;

		// Token: 0x040090E4 RID: 37092
		private Button mKey3;

		// Token: 0x040090E5 RID: 37093
		private Button mKey2;

		// Token: 0x040090E6 RID: 37094
		private Button mKey1;

		// Token: 0x040090E7 RID: 37095
		private Button mCloseBg;
	}
}
