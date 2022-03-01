using System;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x0200101E RID: 4126
	public class NewbieGuideComic1 : NewbieGuideFinalShow
	{
		// Token: 0x06009C67 RID: 40039 RVA: 0x001E92E5 File Offset: 0x001E76E5
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Comic/Comic1";
		}

		// Token: 0x06009C68 RID: 40040 RVA: 0x001E92EC File Offset: 0x001E76EC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.InitNewbieGuideState();
		}

		// Token: 0x06009C69 RID: 40041 RVA: 0x001E92FC File Offset: 0x001E76FC
		private void InitNewbieGuideState()
		{
			RoleInfo roleInfo = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin();
			if (roleInfo.playerLabelInfo.noviceGuideChooseFlag == 1)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("newbieguide_jump_tips"), delegate()
				{
					Singleton<NewbieGuideDataManager>.GetInstance().SetRoleNewbieguideState((int)roleInfo.roleId, NoviceGuideChooseFlag.NGCF_PASS);
					SceneNoviceGuideChooseReq sceneNoviceGuideChooseReq = new SceneNoviceGuideChooseReq();
					sceneNoviceGuideChooseReq.roleId = roleInfo.roleId;
					sceneNoviceGuideChooseReq.chooseFlag = 2;
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<SceneNoviceGuideChooseReq>(ServerType.GATE_SERVER, sceneNoviceGuideChooseReq);
					Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
				}, delegate()
				{
					Singleton<NewbieGuideDataManager>.GetInstance().SetRoleNewbieguideState((int)roleInfo.roleId, NoviceGuideChooseFlag.NGCF_NOT_PASS);
					SceneNoviceGuideChooseReq sceneNoviceGuideChooseReq = new SceneNoviceGuideChooseReq();
					sceneNoviceGuideChooseReq.chooseFlag = 3;
					sceneNoviceGuideChooseReq.roleId = roleInfo.roleId;
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<SceneNoviceGuideChooseReq>(ServerType.GATE_SERVER, sceneNoviceGuideChooseReq);
				}, 0f, false);
			}
		}
	}
}
