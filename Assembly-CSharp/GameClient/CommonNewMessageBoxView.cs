using System;
using System.Runtime.CompilerServices;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AF3 RID: 6899
	public class CommonNewMessageBoxView : MonoBehaviour
	{
		// Token: 0x17001D7F RID: 7551
		// (get) Token: 0x06010EE1 RID: 69345 RVA: 0x004D5BD3 File Offset: 0x004D3FD3
		// (set) Token: 0x06010EE2 RID: 69346 RVA: 0x004D5BDA File Offset: 0x004D3FDA
		private static MsgBoxNewdata Value
		{
			get
			{
				return CommonNewMessageBoxView.data;
			}
			set
			{
				CommonNewMessageBoxView.data = value;
			}
		}

		// Token: 0x17001D80 RID: 7552
		// (get) Token: 0x06010EE3 RID: 69347 RVA: 0x004D5BE2 File Offset: 0x004D3FE2
		private bool IsReverse
		{
			get
			{
				return this._HasFlag(MsgBoxDataType.MBDT_REVERSE);
			}
		}

		// Token: 0x06010EE4 RID: 69348 RVA: 0x004D5BEB File Offset: 0x004D3FEB
		private bool _HasFlag(MsgBoxDataType eFlag)
		{
			return (eFlag & CommonNewMessageBoxView.Value.flags) == eFlag;
		}

		// Token: 0x06010EE5 RID: 69349 RVA: 0x004D5BFC File Offset: 0x004D3FFC
		private void Awake()
		{
			this.bStopCloseFrame = false;
			this._BindUIEvents();
			this._InitTR();
			this._InitToggleScrollListBind();
		}

		// Token: 0x06010EE6 RID: 69350 RVA: 0x004D5C17 File Offset: 0x004D4017
		private void OnDestroy()
		{
			this.bStopCloseFrame = false;
			this._UnBindUIEvents();
		}

		// Token: 0x06010EE7 RID: 69351 RVA: 0x004D5C26 File Offset: 0x004D4026
		protected virtual void _bindEvents()
		{
		}

		// Token: 0x06010EE8 RID: 69352 RVA: 0x004D5C28 File Offset: 0x004D4028
		protected virtual void _unBindEvente()
		{
		}

		// Token: 0x06010EE9 RID: 69353 RVA: 0x004D5C2A File Offset: 0x004D402A
		protected virtual void _BindUIEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.StopCloseCommonNewMessageBoxView, new ClientEventSystem.UIEventHandler(this._OnStopCloseFrame));
		}

		// Token: 0x06010EEA RID: 69354 RVA: 0x004D5C48 File Offset: 0x004D4048
		protected virtual void _UnBindUIEvents()
		{
			if (this.tempCancelBtn != null)
			{
				UnityEvent onClick = this.tempCancelBtn.onClick;
				if (CommonNewMessageBoxView.<>f__mg$cache0 == null)
				{
					CommonNewMessageBoxView.<>f__mg$cache0 = new UnityAction(CommonNewMessageBoxView._CloseFrame);
				}
				onClick.RemoveListener(CommonNewMessageBoxView.<>f__mg$cache0);
			}
			if (this.tempOKBtn != null)
			{
				this.tempOKBtn.onClick.RemoveListener(new UnityAction(this._TryCloseFrame));
			}
			if (this.mCloseBtn != null)
			{
				UnityEvent onClick2 = this.mCloseBtn.onClick;
				if (CommonNewMessageBoxView.<>f__mg$cache1 == null)
				{
					CommonNewMessageBoxView.<>f__mg$cache1 = new UnityAction(CommonNewMessageBoxView._CloseFrame);
				}
				onClick2.RemoveListener(CommonNewMessageBoxView.<>f__mg$cache1);
			}
			if (CommonNewMessageBoxView.Value.ToggleListEvent == null)
			{
				if (CommonNewMessageBoxView.Value.OnOK != null && this.tempOKBtn != null)
				{
					this.tempOKBtn.onClick.RemoveListener(CommonNewMessageBoxView.Value.OnOK);
				}
				if (CommonNewMessageBoxView.Value.OnCancel != null && this.tempCancelBtn != null)
				{
					this.tempCancelBtn.onClick.RemoveListener(CommonNewMessageBoxView.Value.OnCancel);
				}
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.StopCloseCommonNewMessageBoxView, new ClientEventSystem.UIEventHandler(this._OnStopCloseFrame));
		}

		// Token: 0x06010EEB RID: 69355 RVA: 0x004D5D9C File Offset: 0x004D419C
		protected virtual void _InitTR()
		{
		}

		// Token: 0x06010EEC RID: 69356 RVA: 0x004D5D9E File Offset: 0x004D419E
		protected virtual void _ClearTR()
		{
		}

		// Token: 0x06010EED RID: 69357 RVA: 0x004D5DA0 File Offset: 0x004D41A0
		protected virtual void _InitBaseData()
		{
			if (this.mTitleLabel)
			{
				Text componetInChild = Utility.GetComponetInChild<Text>(this.mTitleLabel, "Title/titletext");
				if (componetInChild && string.IsNullOrEmpty(CommonNewMessageBoxView.Value.title))
				{
					componetInChild.text = CommonNewMessageBoxView.Value.title;
				}
				else
				{
					this.mTitleLabel.CustomActive(false);
				}
			}
			if (this.mContentLabel)
			{
				this.mContentLabel.text = CommonNewMessageBoxView.Value.content;
			}
			Text componetInChild2 = Utility.GetComponetInChild<Text>(this.mOkBtn.gameObject, "Text");
			Text componetInChild3 = Utility.GetComponetInChild<Text>(this.mCancelBtn.gameObject, "Text");
			if (this.IsReverse)
			{
				this.tempCancelBtn = this.mOkBtn;
				this.tempOKBtn = this.mCancelBtn;
				if (componetInChild2)
				{
					componetInChild2.text = CommonNewMessageBoxView.Value.cancel;
				}
				if (componetInChild3)
				{
					componetInChild3.text = CommonNewMessageBoxView.Value.ok;
				}
			}
			else
			{
				this.tempCancelBtn = this.mCancelBtn;
				this.tempOKBtn = this.mOkBtn;
				if (componetInChild2)
				{
					componetInChild2.text = CommonNewMessageBoxView.Value.ok;
				}
				if (componetInChild3)
				{
					componetInChild3.text = CommonNewMessageBoxView.Value.cancel;
				}
			}
			if (CommonNewMessageBoxView.Value.ToggleListEvent != null)
			{
				if (CommonNewMessageBoxView.Value.ToggleListEvent.Count > 0 && this.mToggleRoot != null)
				{
					this.mToggleRoot.SetElementAmount(CommonNewMessageBoxView.Value.ToggleListEvent.Count);
				}
			}
			else
			{
				if (CommonNewMessageBoxView.Value.OnOK != null && this.tempOKBtn != null)
				{
					this.tempOKBtn.onClick.AddListener(CommonNewMessageBoxView.Value.OnOK);
				}
				if (CommonNewMessageBoxView.Value.OnCancel != null && this.tempCancelBtn != null)
				{
					this.tempCancelBtn.onClick.AddListener(CommonNewMessageBoxView.Value.OnCancel);
				}
			}
			if (this.tempCancelBtn != null)
			{
				UnityEvent onClick = this.tempCancelBtn.onClick;
				if (CommonNewMessageBoxView.<>f__mg$cache2 == null)
				{
					CommonNewMessageBoxView.<>f__mg$cache2 = new UnityAction(CommonNewMessageBoxView._CloseFrame);
				}
				onClick.AddListener(CommonNewMessageBoxView.<>f__mg$cache2);
			}
			if (this.tempOKBtn != null)
			{
				this.tempOKBtn.onClick.AddListener(new UnityAction(this._TryCloseFrame));
			}
			if (this.mCloseBtn != null)
			{
				UnityEvent onClick2 = this.mCloseBtn.onClick;
				if (CommonNewMessageBoxView.<>f__mg$cache3 == null)
				{
					CommonNewMessageBoxView.<>f__mg$cache3 = new UnityAction(CommonNewMessageBoxView._CloseFrame);
				}
				onClick2.AddListener(CommonNewMessageBoxView.<>f__mg$cache3);
			}
		}

		// Token: 0x06010EEE RID: 69358 RVA: 0x004D607C File Offset: 0x004D447C
		private void _TryCloseFrame()
		{
			if (this.bStopCloseFrame)
			{
				this.bStopCloseFrame = false;
				return;
			}
			CommonNewMessageBoxView._CloseFrame();
		}

		// Token: 0x06010EEF RID: 69359 RVA: 0x004D6098 File Offset: 0x004D4498
		public static void _CloseFrame()
		{
			if (CommonNewMessageBoxView.Value == null)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen("CommonNewMessageBox" + CommonNewMessageBoxView.Value.iID.ToString()))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame("CommonNewMessageBox" + CommonNewMessageBoxView.Value.iID.ToString());
			}
		}

		// Token: 0x06010EF0 RID: 69360 RVA: 0x004D6107 File Offset: 0x004D4507
		private void _OnCloseButtonClickCallBack()
		{
			CommonNewMessageBoxView._CloseFrame();
		}

		// Token: 0x06010EF1 RID: 69361 RVA: 0x004D610E File Offset: 0x004D450E
		private void _OnStopCloseFrame(UIEvent uiEvent)
		{
			this.bStopCloseFrame = true;
		}

		// Token: 0x06010EF2 RID: 69362 RVA: 0x004D6117 File Offset: 0x004D4517
		private void _InitToggleScrollListBind()
		{
			this.mToggleRoot.Initialize();
			this.mToggleRoot.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (this.mGroup != null && item != null && item.m_index >= 0)
				{
					this.mGroup.allowSwitchOff = true;
					NewMessageBoxToggleUnit component = item.GetComponent<NewMessageBoxToggleUnit>();
					if (component != null)
					{
						Button tempBtn;
						if (this.IsReverse)
						{
							tempBtn = this.mCancelBtn;
						}
						else
						{
							tempBtn = this.mOkBtn;
						}
						component.InitBaseData(CommonNewMessageBoxView.Value.ToggleListEvent[item.m_index], tempBtn);
						component.UpdateItemInfo();
					}
					if (item.m_index == 0)
					{
						Toggle component2 = item.GetComponent<Toggle>();
						if (component2 != null)
						{
							component2.isOn = true;
						}
					}
					this.mGroup.allowSwitchOff = false;
				}
			};
			this.mToggleRoot.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (this.mGroup != null && item != null)
				{
					this.mGroup.allowSwitchOff = true;
					NewMessageBoxToggleUnit component = item.GetComponent<NewMessageBoxToggleUnit>();
					if (component != null)
					{
						component.OnItemRecycle();
					}
					this.mGroup.allowSwitchOff = false;
				}
			};
		}

		// Token: 0x06010EF3 RID: 69363 RVA: 0x004D6152 File Offset: 0x004D4552
		public void InitData(MsgBoxNewdata data)
		{
			CommonNewMessageBoxView.Value = data;
			this._InitBaseData();
		}

		// Token: 0x06010EF4 RID: 69364 RVA: 0x004D6160 File Offset: 0x004D4560
		public void Clear()
		{
			this._ClearTR();
		}

		// Token: 0x0400AE02 RID: 44546
		private static MsgBoxNewdata data;

		// Token: 0x0400AE03 RID: 44547
		private Button tempCancelBtn;

		// Token: 0x0400AE04 RID: 44548
		private Button tempOKBtn;

		// Token: 0x0400AE05 RID: 44549
		[SerializeField]
		private GameObject mTitleLabel;

		// Token: 0x0400AE06 RID: 44550
		[SerializeField]
		private Text mContentLabel;

		// Token: 0x0400AE07 RID: 44551
		[SerializeField]
		private ComUIListScript mToggleRoot;

		// Token: 0x0400AE08 RID: 44552
		[SerializeField]
		private Button mCancelBtn;

		// Token: 0x0400AE09 RID: 44553
		[SerializeField]
		private Button mOkBtn;

		// Token: 0x0400AE0A RID: 44554
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x0400AE0B RID: 44555
		[SerializeField]
		private ToggleGroup mGroup;

		// Token: 0x0400AE0C RID: 44556
		private bool bStopCloseFrame;

		// Token: 0x0400AE0D RID: 44557
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache0;

		// Token: 0x0400AE0E RID: 44558
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache1;

		// Token: 0x0400AE0F RID: 44559
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache2;

		// Token: 0x0400AE10 RID: 44560
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache3;
	}
}
