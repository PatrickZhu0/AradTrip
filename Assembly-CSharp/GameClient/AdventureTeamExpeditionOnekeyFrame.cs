using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001411 RID: 5137
	public class AdventureTeamExpeditionOnekeyFrame : ClientFrame
	{
		// Token: 0x0600C70F RID: 50959 RVA: 0x00301A19 File Offset: 0x002FFE19
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AdventureTeam/AdventureTeamExpeditionOnekeyFrame";
		}

		// Token: 0x0600C710 RID: 50960 RVA: 0x00301A20 File Offset: 0x002FFE20
		protected override void _OnOpenFrame()
		{
			this._BindUIEvent();
			if (this.userData == null)
			{
				return;
			}
			this.mReadyMapModels = (this.userData as List<ExpeditionMapModel>);
			if (this.mMainContentView != null)
			{
				this.mMainContentView.InitView(this.mReadyMapModels);
			}
		}

		// Token: 0x0600C711 RID: 50961 RVA: 0x00301A72 File Offset: 0x002FFE72
		protected override void _OnCloseFrame()
		{
			this._UnBindUIEvent();
			if (this.mReadyMapModels != null)
			{
				this.mReadyMapModels.Clear();
			}
		}

		// Token: 0x0600C712 RID: 50962 RVA: 0x00301A90 File Offset: 0x002FFE90
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionTimeChanged, new ClientEventSystem.UIEventHandler(this._OnExpeditionTimeChanged));
		}

		// Token: 0x0600C713 RID: 50963 RVA: 0x00301AAD File Offset: 0x002FFEAD
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionTimeChanged, new ClientEventSystem.UIEventHandler(this._OnExpeditionTimeChanged));
		}

		// Token: 0x0600C714 RID: 50964 RVA: 0x00301ACA File Offset: 0x002FFECA
		private void _OnExpeditionTimeChanged(UIEvent uIEvent)
		{
			if (this.mMainContentView != null)
			{
				this.mMainContentView.RefreshView();
			}
		}

		// Token: 0x0600C715 RID: 50965 RVA: 0x00301AE8 File Offset: 0x002FFEE8
		protected override void _bindExUI()
		{
			this.mMainContentView = this.mBind.GetCom<AdventureTeamExpeditionOnekeyView>("MainContentView");
			this.mOkButton = this.mBind.GetCom<Button>("okButton");
			this.mOkButton.onClick.AddListener(new UnityAction(this._onOkButtonButtonClick));
			this.mCloseButton = this.mBind.GetCom<Button>("closeButton");
			this.mCloseButton.onClick.AddListener(new UnityAction(this._onCloseButtonButtonClick));
		}

		// Token: 0x0600C716 RID: 50966 RVA: 0x00301B70 File Offset: 0x002FFF70
		protected override void _unbindExUI()
		{
			this.mMainContentView = null;
			this.mOkButton.onClick.RemoveListener(new UnityAction(this._onOkButtonButtonClick));
			this.mOkButton = null;
			this.mCloseButton.onClick.RemoveListener(new UnityAction(this._onCloseButtonButtonClick));
			this.mCloseButton = null;
		}

		// Token: 0x0600C717 RID: 50967 RVA: 0x00301BCA File Offset: 0x002FFFCA
		private void _onOkButtonButtonClick()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ReqDispatchExpeditionTeam(this.mReadyMapModels);
			base.Close(false);
		}

		// Token: 0x0600C718 RID: 50968 RVA: 0x00301BE3 File Offset: 0x002FFFE3
		private void _onCloseButtonButtonClick()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ClearReadyExpeditionMapModels(this.mReadyMapModels);
			base.Close(false);
		}

		// Token: 0x04007247 RID: 29255
		private List<ExpeditionMapModel> mReadyMapModels;

		// Token: 0x04007248 RID: 29256
		private AdventureTeamExpeditionOnekeyView mMainContentView;

		// Token: 0x04007249 RID: 29257
		private Button mOkButton;

		// Token: 0x0400724A RID: 29258
		private Button mCloseButton;
	}
}
