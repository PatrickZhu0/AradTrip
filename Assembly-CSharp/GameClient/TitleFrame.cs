using System;

namespace GameClient
{
	// Token: 0x02001975 RID: 6517
	public class TitleFrame : ClientFrame
	{
		// Token: 0x0600FD3A RID: 64826 RVA: 0x0045B1CC File Offset: 0x004595CC
		protected override void _bindExUI()
		{
			this.mTitleView = this.mBind.GetCom<TitleView>("TitleView");
		}

		// Token: 0x0600FD3B RID: 64827 RVA: 0x0045B1E4 File Offset: 0x004595E4
		protected override void _unbindExUI()
		{
			this.mTitleView = null;
		}

		// Token: 0x0600FD3C RID: 64828 RVA: 0x0045B1ED File Offset: 0x004595ED
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/PersonalSettingFrame/TitleFrame";
		}

		// Token: 0x0600FD3D RID: 64829 RVA: 0x0045B1F4 File Offset: 0x004595F4
		protected override void _OnOpenFrame()
		{
			this._bindExUI();
			this._BindUIEvent();
			this.mTitleView.InitUI(0);
			this.mTitleView.UpdateToggleUI(0);
		}

		// Token: 0x0600FD3E RID: 64830 RVA: 0x0045B21A File Offset: 0x0045961A
		protected override void _OnCloseFrame()
		{
			this._unbindExUI();
			this._UnBindUIEvent();
		}

		// Token: 0x0600FD3F RID: 64831 RVA: 0x0045B228 File Offset: 0x00459628
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TitleDataUpdate, new ClientEventSystem.UIEventHandler(this._UpdateTitleFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TitleGuidUpdate, new ClientEventSystem.UIEventHandler(this._UpdateMyTitleUI));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TitleModeUpdate, new ClientEventSystem.UIEventHandler(this._UpdateTitleMode));
		}

		// Token: 0x0600FD40 RID: 64832 RVA: 0x0045B288 File Offset: 0x00459688
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TitleDataUpdate, new ClientEventSystem.UIEventHandler(this._UpdateTitleFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TitleGuidUpdate, new ClientEventSystem.UIEventHandler(this._UpdateMyTitleUI));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TitleModeUpdate, new ClientEventSystem.UIEventHandler(this._UpdateTitleMode));
		}

		// Token: 0x0600FD41 RID: 64833 RVA: 0x0045B2E6 File Offset: 0x004596E6
		private void _UpdateTitleFrame(UIEvent uiEvent)
		{
			this.mTitleView.UpdateToggleUI(-1);
		}

		// Token: 0x0600FD42 RID: 64834 RVA: 0x0045B2F4 File Offset: 0x004596F4
		private void _UpdateMyTitleUI(UIEvent uiEvent)
		{
			this.mTitleView.UpdateToggleUI(-1);
		}

		// Token: 0x0600FD43 RID: 64835 RVA: 0x0045B302 File Offset: 0x00459702
		private void _UpdateTitleMode(UIEvent uiEvent)
		{
			this.mTitleView._InitModel();
		}

		// Token: 0x04009F18 RID: 40728
		private TitleView mTitleView;
	}
}
