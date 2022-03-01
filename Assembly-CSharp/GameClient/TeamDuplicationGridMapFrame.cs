using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C80 RID: 7296
	public class TeamDuplicationGridMapFrame : ClientFrame
	{
		// Token: 0x06011E6E RID: 73326 RVA: 0x0053C9C8 File Offset: 0x0053ADC8
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/GridMap/TeamDuplicationGridMapFrame";
		}

		// Token: 0x06011E6F RID: 73327 RVA: 0x0053C9D0 File Offset: 0x0053ADD0
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.onFadeInEnd = (ClientFrame.OnFadeInEnd)Delegate.Combine(this.onFadeInEnd, new ClientFrame.OnFadeInEnd(this.OnFadeInEndInFrame));
			if (this.mTeamDuplicationGridMapView != null)
			{
				this.mTeamDuplicationGridMapView.Init();
			}
			ComVoiceTalk.Bind(this.mVoiceTalkParent);
		}

		// Token: 0x06011E70 RID: 73328 RVA: 0x0053CA2D File Offset: 0x0053AE2D
		protected override void _OnCloseFrame()
		{
			ComVoiceTalk.UnBind();
			this.DestroyComTalk();
		}

		// Token: 0x06011E71 RID: 73329 RVA: 0x0053CA3A File Offset: 0x0053AE3A
		private void OnFadeInEndInFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationComTalkShowInGridMapMessage, null, null, null, null);
			this.InitComTalk();
		}

		// Token: 0x06011E72 RID: 73330 RVA: 0x0053CA55 File Offset: 0x0053AE55
		private void InitComTalk()
		{
			this.m_miniTalk = ComTalk.Create(this.mTalkParentRoot);
		}

		// Token: 0x06011E73 RID: 73331 RVA: 0x0053CA68 File Offset: 0x0053AE68
		private void DestroyComTalk()
		{
			if (this.m_miniTalk != null)
			{
				ComTalk.Recycle();
				this.m_miniTalk = null;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationComTalkDestroyInGridMapMessage, null, null, null, null);
		}

		// Token: 0x06011E74 RID: 73332 RVA: 0x0053CA9C File Offset: 0x0053AE9C
		protected override void _bindExUI()
		{
			this.mTeamDuplicationGridMapView = this.mBind.GetCom<TeamDuplicationGridMapView>("TeamDuplicationGridMapView");
			this.mTalkParentRoot = this.mBind.GetGameObject("talkParentRoot");
			this.mVoiceTalkParent = this.mBind.GetGameObject("VoiceTalkParent");
		}

		// Token: 0x06011E75 RID: 73333 RVA: 0x0053CAEB File Offset: 0x0053AEEB
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationGridMapView = null;
			this.mTalkParentRoot = null;
			this.mVoiceTalkParent = null;
		}

		// Token: 0x0400BA8D RID: 47757
		private ComTalk m_miniTalk;

		// Token: 0x0400BA8E RID: 47758
		private TeamDuplicationGridMapView mTeamDuplicationGridMapView;

		// Token: 0x0400BA8F RID: 47759
		private GameObject mTalkParentRoot;

		// Token: 0x0400BA90 RID: 47760
		private GameObject mVoiceTalkParent;
	}
}
