using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C58 RID: 7256
	public class TeamDuplicationMainFightFrame : ClientFrame
	{
		// Token: 0x06011D18 RID: 72984 RVA: 0x00536FA5 File Offset: 0x005353A5
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/TeamDuplicationMainFightFrame";
		}

		// Token: 0x06011D19 RID: 72985 RVA: 0x00536FAC File Offset: 0x005353AC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationMainFightView != null)
			{
				this.mTeamDuplicationMainFightView.Init();
			}
			this.InitComTalk();
			this.mVoiceTalk = new TeamDuplicationVoiceTalk(this.mVoiceTalkParent);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationComTalkDestroyInGridMapMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationComTalkDestroyInGridMapMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationComTalkShowInGridMapMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationComTalkShowInGridMapMessage));
		}

		// Token: 0x06011D1A RID: 72986 RVA: 0x00537028 File Offset: 0x00535428
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationComTalkDestroyInGridMapMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationComTalkDestroyInGridMapMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationComTalkShowInGridMapMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationComTalkShowInGridMapMessage));
			this.OnDestroyComTalk();
			if (this.mVoiceTalk != null)
			{
				this.mVoiceTalk.UnInit();
			}
		}

		// Token: 0x06011D1B RID: 72987 RVA: 0x00537087 File Offset: 0x00535487
		private void InitComTalk()
		{
			this.m_miniTalk = ComTalk.Create(this.mTalkParent);
		}

		// Token: 0x06011D1C RID: 72988 RVA: 0x0053709A File Offset: 0x0053549A
		private void OnDestroyComTalk()
		{
			if (this.m_miniTalk != null)
			{
				ComTalk.Recycle();
				this.m_miniTalk = null;
			}
		}

		// Token: 0x06011D1D RID: 72989 RVA: 0x005370B9 File Offset: 0x005354B9
		private void OnReceiveTeamDuplicationComTalkDestroyInGridMapMessage(UIEvent uiEvent)
		{
			this.InitComTalk();
		}

		// Token: 0x06011D1E RID: 72990 RVA: 0x005370C1 File Offset: 0x005354C1
		private void OnReceiveTeamDuplicationComTalkShowInGridMapMessage(UIEvent uiEvent)
		{
			this.OnDestroyComTalk();
		}

		// Token: 0x06011D1F RID: 72991 RVA: 0x005370CC File Offset: 0x005354CC
		protected override void _bindExUI()
		{
			this.mTeamDuplicationMainFightView = this.mBind.GetCom<TeamDuplicationMainFightView>("TeamDuplicationMainFightView");
			this.mTalkParent = this.mBind.GetGameObject("TalkParent");
			this.mVoiceTalkParent = this.mBind.GetGameObject("VoiceTalkParent");
		}

		// Token: 0x06011D20 RID: 72992 RVA: 0x0053711B File Offset: 0x0053551B
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationMainFightView = null;
			this.mTalkParent = null;
			this.mVoiceTalkParent = null;
		}

		// Token: 0x0400B996 RID: 47510
		private ComTalk m_miniTalk;

		// Token: 0x0400B997 RID: 47511
		private TeamDuplicationVoiceTalk mVoiceTalk;

		// Token: 0x0400B998 RID: 47512
		private TeamDuplicationMainFightView mTeamDuplicationMainFightView;

		// Token: 0x0400B999 RID: 47513
		private GameObject mTalkParent;

		// Token: 0x0400B99A RID: 47514
		private GameObject mVoiceTalkParent;
	}
}
