using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001167 RID: 4455
	public class OldPlayerFrame : ClientFrame
	{
		// Token: 0x0600AA41 RID: 43585 RVA: 0x00244C3B File Offset: 0x0024303B
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SelecteRoleNew/OldPlayerFrame";
		}

		// Token: 0x0600AA42 RID: 43586 RVA: 0x00244C42 File Offset: 0x00243042
		protected sealed override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			this._InitData();
		}

		// Token: 0x0600AA43 RID: 43587 RVA: 0x00244C50 File Offset: 0x00243050
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600AA44 RID: 43588 RVA: 0x00244C5E File Offset: 0x0024305E
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600AA45 RID: 43589 RVA: 0x00244C60 File Offset: 0x00243060
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600AA46 RID: 43590 RVA: 0x00244C62 File Offset: 0x00243062
		private void _InitData()
		{
			ClientApplication.veteranReturn = 0U;
		}

		// Token: 0x0600AA47 RID: 43591 RVA: 0x00244C6A File Offset: 0x0024306A
		private void _ClearData()
		{
		}

		// Token: 0x0600AA48 RID: 43592 RVA: 0x00244C6C File Offset: 0x0024306C
		protected override void _bindExUI()
		{
			this.mReStart = this.mBind.GetCom<Button>("reStart");
			if (null != this.mReStart)
			{
				this.mReStart.onClick.AddListener(new UnityAction(this._onReStartButtonClick));
			}
			this.mOk = this.mBind.GetCom<Button>("ok");
			if (null != this.mOk)
			{
				this.mOk.onClick.AddListener(new UnityAction(this._onOkButtonClick));
			}
			this.mClose = this.mBind.GetCom<Button>("close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x0600AA49 RID: 43593 RVA: 0x00244D44 File Offset: 0x00243144
		protected override void _unbindExUI()
		{
			if (null != this.mReStart)
			{
				this.mReStart.onClick.RemoveListener(new UnityAction(this._onReStartButtonClick));
			}
			this.mReStart = null;
			if (null != this.mOk)
			{
				this.mOk.onClick.RemoveListener(new UnityAction(this._onOkButtonClick));
			}
			this.mOk = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x0600AA4A RID: 43594 RVA: 0x00244DED File Offset: 0x002431ED
		private void _onReStartButtonClick()
		{
			ClientApplication.DisconnectGateServerAtLogin();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SelectRoleFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SelectRoleFrame>(null, false);
			}
			this.frameMgr.CloseFrame<OldPlayerFrame>(this, false);
		}

		// Token: 0x0600AA4B RID: 43595 RVA: 0x00244E1D File Offset: 0x0024321D
		private void _onOkButtonClick()
		{
			this.frameMgr.CloseFrame<OldPlayerFrame>(this, false);
		}

		// Token: 0x0600AA4C RID: 43596 RVA: 0x00244E2C File Offset: 0x0024322C
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<OldPlayerFrame>(this, false);
		}

		// Token: 0x04005F68 RID: 24424
		private Button mReStart;

		// Token: 0x04005F69 RID: 24425
		private Button mOk;

		// Token: 0x04005F6A RID: 24426
		private Button mClose;
	}
}
