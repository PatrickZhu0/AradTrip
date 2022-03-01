using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C2B RID: 7211
	public class TeamDuplicationTeamBuildFrame : ClientFrame
	{
		// Token: 0x06011B0B RID: 72459 RVA: 0x0052ECA7 File Offset: 0x0052D0A7
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Build/TeamDuplicationTeamBuildFrame";
		}

		// Token: 0x06011B0C RID: 72460 RVA: 0x0052ECB0 File Offset: 0x0052D0B0
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.blackMask != null)
			{
				Image component = this.blackMask.GetComponent<Image>();
				if (component != null)
				{
					component.color = new Color(0f, 0f, 0f, 0.8235294f);
				}
			}
			if (this.mTeamDuplicationTeamBuildView != null)
			{
				this.mTeamDuplicationTeamBuildView.Init();
			}
		}

		// Token: 0x06011B0D RID: 72461 RVA: 0x0052ED27 File Offset: 0x0052D127
		protected override void _bindExUI()
		{
			this.mTeamDuplicationTeamBuildView = this.mBind.GetCom<TeamDuplicationTeamBuildView>("TeamDuplicationTeamBuildView");
		}

		// Token: 0x06011B0E RID: 72462 RVA: 0x0052ED3F File Offset: 0x0052D13F
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationTeamBuildView = null;
		}

		// Token: 0x0400B85C RID: 47196
		private TeamDuplicationTeamBuildView mTeamDuplicationTeamBuildView;
	}
}
