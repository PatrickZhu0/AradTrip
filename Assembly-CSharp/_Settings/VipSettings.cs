using System;
using GameClient;
using UnityEngine;

namespace _Settings
{
	// Token: 0x02001A2E RID: 6702
	public class VipSettings : SettingsBindUI
	{
		// Token: 0x0601076A RID: 67434 RVA: 0x004A2291 File Offset: 0x004A0691
		public VipSettings(GameObject root, ClientFrame frame) : base(root, frame)
		{
		}

		// Token: 0x0601076B RID: 67435 RVA: 0x004A229B File Offset: 0x004A069B
		protected override string GetCurrGameObjectPath()
		{
			return "UIRoot/UI2DRoot/Middle/SettingPanel/Panel/Contents/vip";
		}

		// Token: 0x0601076C RID: 67436 RVA: 0x004A22A2 File Offset: 0x004A06A2
		protected override void InitBind()
		{
			base.InitBind();
			this.node = this.mBind.GetGameObject("vipContentNode");
		}

		// Token: 0x0601076D RID: 67437 RVA: 0x004A22C0 File Offset: 0x004A06C0
		protected override void OnShowOut()
		{
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<VipSettingFrame>(null))
			{
				VipSettingFrame vipSettingFrame = Singleton<ClientSystemManager>.instance.OpenFrame<VipSettingFrame>(FrameLayer.Middle, null, string.Empty) as VipSettingFrame;
				if (vipSettingFrame != null)
				{
					this.vipFrameRoot = vipSettingFrame.GetFrame();
					Utility.AttachTo(this.vipFrameRoot, this.node, false);
				}
			}
		}

		// Token: 0x0601076E RID: 67438 RVA: 0x004A2318 File Offset: 0x004A0718
		protected override void OnHideIn()
		{
		}

		// Token: 0x0601076F RID: 67439 RVA: 0x004A231A File Offset: 0x004A071A
		protected override void Close()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<VipSettingFrame>(null, false);
		}

		// Token: 0x0400A763 RID: 42851
		private GameObject vipFrameRoot;

		// Token: 0x0400A764 RID: 42852
		private GameObject node;
	}
}
