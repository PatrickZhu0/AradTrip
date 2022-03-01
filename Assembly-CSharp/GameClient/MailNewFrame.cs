using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x0200174F RID: 5967
	public class MailNewFrame : ClientFrame
	{
		// Token: 0x0600EA6C RID: 60012 RVA: 0x003E2483 File Offset: 0x003E0883
		protected sealed override void _bindExUI()
		{
			DataManager<MailDataManager>.GetInstance().UpdateOpenMailTabType();
			this.mMailFrameNew = this.mBind.GetCom<MailNewView>("MailFrameNew");
		}

		// Token: 0x0600EA6D RID: 60013 RVA: 0x003E24A5 File Offset: 0x003E08A5
		protected sealed override void _unbindExUI()
		{
			this.mMailFrameNew = null;
		}

		// Token: 0x0600EA6E RID: 60014 RVA: 0x003E24AE File Offset: 0x003E08AE
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mail/MailFrameNew";
		}

		// Token: 0x0600EA6F RID: 60015 RVA: 0x003E24B5 File Offset: 0x003E08B5
		protected sealed override void _OnOpenFrame()
		{
			this.RegisterUIEventHandler();
			this.mMailFrameNew.InitView(new OnMailMainTabAddListener(this.OnMailMainTabClick));
		}

		// Token: 0x0600EA70 RID: 60016 RVA: 0x003E24D4 File Offset: 0x003E08D4
		protected sealed override void _OnCloseFrame()
		{
			this.UnRegisterUIEventHandler();
		}

		// Token: 0x0600EA71 RID: 60017 RVA: 0x003E24DC File Offset: 0x003E08DC
		private void RegisterUIEventHandler()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewMailNotify, new ClientEventSystem.UIEventHandler(this.OnUpdateNewMailNotify));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMailDeleteSuccess, new ClientEventSystem.UIEventHandler(this.OnMailDeleteSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReadMailResSuccess, new ClientEventSystem.UIEventHandler(this.OnReadMailResSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateMailStatus, new ClientEventSystem.UIEventHandler(this.OnUpdateMailTitleInfoList));
		}

		// Token: 0x0600EA72 RID: 60018 RVA: 0x003E2558 File Offset: 0x003E0958
		private void UnRegisterUIEventHandler()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewMailNotify, new ClientEventSystem.UIEventHandler(this.OnUpdateNewMailNotify));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMailDeleteSuccess, new ClientEventSystem.UIEventHandler(this.OnMailDeleteSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReadMailResSuccess, new ClientEventSystem.UIEventHandler(this.OnReadMailResSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateMailStatus, new ClientEventSystem.UIEventHandler(this.OnUpdateMailTitleInfoList));
		}

		// Token: 0x0600EA73 RID: 60019 RVA: 0x003E25D4 File Offset: 0x003E09D4
		private void OnUpdateNewMailNotify(UIEvent uiEvent)
		{
			List<MailTitleInfo> currentShowMailTitleInfoList = DataManager<MailDataManager>.GetInstance().GetCurrentShowMailTitleInfoList();
			this.mMailFrameNew.UpdateNewMailNotify(currentShowMailTitleInfoList);
		}

		// Token: 0x0600EA74 RID: 60020 RVA: 0x003E25F8 File Offset: 0x003E09F8
		private void OnUpdateMailTitleInfoList(UIEvent uiEvent)
		{
			List<MailTitleInfo> currentShowMailTitleInfoList = DataManager<MailDataManager>.GetInstance().GetCurrentShowMailTitleInfoList();
			this.mMailFrameNew.UpdateMailTitleInfo(currentShowMailTitleInfoList);
		}

		// Token: 0x0600EA75 RID: 60021 RVA: 0x003E261C File Offset: 0x003E0A1C
		private void OnMailDeleteSuccess(UIEvent uiEvent)
		{
			List<MailTitleInfo> currentShowMailTitleInfoList = DataManager<MailDataManager>.GetInstance().GetCurrentShowMailTitleInfoList();
			this.mMailFrameNew.UpdateSelfMailTitleInfoList(currentShowMailTitleInfoList);
		}

		// Token: 0x0600EA76 RID: 60022 RVA: 0x003E2640 File Offset: 0x003E0A40
		private void OnReadMailResSuccess(UIEvent uiEvent)
		{
			MailDataModel mailData = uiEvent.Param1 as MailDataModel;
			this.mMailFrameNew.UpdateMailInfoMationView(mailData);
		}

		// Token: 0x0600EA77 RID: 60023 RVA: 0x003E2668 File Offset: 0x003E0A68
		private void OnMailMainTabClick(MailNewMainTabDataModel mailMainTabDataModel)
		{
			if (mailMainTabDataModel == null)
			{
				return;
			}
			MailDataManager.CurrentSelectMailTabType = mailMainTabDataModel.mailTabType;
			List<MailTitleInfo> currentShowMailTitleInfoList = DataManager<MailDataManager>.GetInstance().GetCurrentShowMailTitleInfoList();
			this.mMailFrameNew.UpdateBtnStatue(mailMainTabDataModel);
			this.mMailFrameNew.UpdateSelfMailTitleInfoList(currentShowMailTitleInfoList);
		}

		// Token: 0x04008E31 RID: 36401
		private MailNewView mMailFrameNew;
	}
}
