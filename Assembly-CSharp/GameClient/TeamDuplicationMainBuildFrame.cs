using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C27 RID: 7207
	public class TeamDuplicationMainBuildFrame : ClientFrame
	{
		// Token: 0x06011AE0 RID: 72416 RVA: 0x0052E343 File Offset: 0x0052C743
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/TeamDuplicationMainBuildFrame";
		}

		// Token: 0x06011AE1 RID: 72417 RVA: 0x0052E34A File Offset: 0x0052C74A
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationMainBuildView != null)
			{
				this.mTeamDuplicationMainBuildView.Init();
			}
			this.InitComTalk();
			this.mVoiceTalk = new TeamDuplicationVoiceTalk(this.mVoiceTalkParent);
		}

		// Token: 0x06011AE2 RID: 72418 RVA: 0x0052E388 File Offset: 0x0052C788
		protected override void _OnCloseFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				if (clientSystemTownFrame != null)
				{
					clientSystemTownFrame.SetForbidFadeIn(false);
				}
			}
			if (this.m_miniTalk != null)
			{
				ComTalk.Recycle();
				this.m_miniTalk = null;
			}
			if (this.mVoiceTalk != null)
			{
				this.mVoiceTalk.UnInit();
			}
		}

		// Token: 0x06011AE3 RID: 72419 RVA: 0x0052E3FF File Offset: 0x0052C7FF
		private void InitComTalk()
		{
			this.m_miniTalk = ComTalk.Create(this.mTalkParent);
		}

		// Token: 0x06011AE4 RID: 72420 RVA: 0x0052E414 File Offset: 0x0052C814
		protected override void _bindExUI()
		{
			this.mTeamDuplicationMainBuildView = this.mBind.GetCom<TeamDuplicationMainBuildView>("TeamDuplicationMainBuildView");
			this.mTalkParent = this.mBind.GetGameObject("TalkParent");
			this.mVoiceTalkParent = this.mBind.GetGameObject("VoiceTalkParent");
		}

		// Token: 0x06011AE5 RID: 72421 RVA: 0x0052E463 File Offset: 0x0052C863
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationMainBuildView = null;
			this.mTalkParent = null;
			this.mVoiceTalkParent = null;
		}

		// Token: 0x0400B848 RID: 47176
		private ComTalk m_miniTalk;

		// Token: 0x0400B849 RID: 47177
		private TeamDuplicationVoiceTalk mVoiceTalk;

		// Token: 0x0400B84A RID: 47178
		private TeamDuplicationMainBuildView mTeamDuplicationMainBuildView;

		// Token: 0x0400B84B RID: 47179
		private GameObject mTalkParent;

		// Token: 0x0400B84C RID: 47180
		private GameObject mVoiceTalkParent;
	}
}
