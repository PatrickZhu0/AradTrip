using System;

namespace GameClient
{
	// Token: 0x0200161A RID: 5658
	public class GuildDungeonHelpFrame : ClientFrame
	{
		// Token: 0x0600DE0F RID: 56847 RVA: 0x00386CD1 File Offset: 0x003850D1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonHelp";
		}

		// Token: 0x0600DE10 RID: 56848 RVA: 0x00386CD8 File Offset: 0x003850D8
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
		}

		// Token: 0x0600DE11 RID: 56849 RVA: 0x00386CE0 File Offset: 0x003850E0
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0600DE12 RID: 56850 RVA: 0x00386CE8 File Offset: 0x003850E8
		protected override void _bindExUI()
		{
		}

		// Token: 0x0600DE13 RID: 56851 RVA: 0x00386CEA File Offset: 0x003850EA
		protected override void _unbindExUI()
		{
		}

		// Token: 0x0600DE14 RID: 56852 RVA: 0x00386CEC File Offset: 0x003850EC
		private void BindUIEvent()
		{
		}

		// Token: 0x0600DE15 RID: 56853 RVA: 0x00386CEE File Offset: 0x003850EE
		private void UnBindUIEvent()
		{
		}
	}
}
