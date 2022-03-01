using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015F9 RID: 5625
	public class GuildBenefitsFrame : ClientFrame
	{
		// Token: 0x0600DC80 RID: 56448 RVA: 0x0037B7B0 File Offset: 0x00379BB0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildBenefits";
		}

		// Token: 0x0600DC81 RID: 56449 RVA: 0x0037B7B7 File Offset: 0x00379BB7
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
		}

		// Token: 0x0600DC82 RID: 56450 RVA: 0x0037B7BF File Offset: 0x00379BBF
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0600DC83 RID: 56451 RVA: 0x0037B7C8 File Offset: 0x00379BC8
		protected override void _bindExUI()
		{
			this.openStorage = this.mBind.GetCom<Button>("openStorage");
			this.openStorage.SafeSetOnClickListener(delegate
			{
				GuildStoreFrame.ansyOpen(null);
			});
			this.openRedPacket = this.mBind.GetCom<Button>("openRedPacket");
			this.openRedPacket.SafeSetOnClickListener(delegate
			{
				this.frameMgr.OpenFrame<GuildRedPacketFrame>(FrameLayer.Middle, null, string.Empty);
			});
		}

		// Token: 0x0600DC84 RID: 56452 RVA: 0x0037B840 File Offset: 0x00379C40
		protected override void _unbindExUI()
		{
			this.openStorage = null;
			this.openRedPacket = null;
		}

		// Token: 0x0600DC85 RID: 56453 RVA: 0x0037B850 File Offset: 0x00379C50
		private void BindUIEvent()
		{
		}

		// Token: 0x0600DC86 RID: 56454 RVA: 0x0037B852 File Offset: 0x00379C52
		private void UnBindUIEvent()
		{
		}

		// Token: 0x04008217 RID: 33303
		private Button openStorage;

		// Token: 0x04008218 RID: 33304
		private Button openRedPacket;
	}
}
