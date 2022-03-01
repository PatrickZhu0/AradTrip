using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001997 RID: 6551
	public class PkMenuFrame : ClientFrame
	{
		// Token: 0x0600FF0D RID: 65293 RVA: 0x00469FC3 File Offset: 0x004683C3
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PkMenuFrame";
		}

		// Token: 0x0600FF0E RID: 65294 RVA: 0x00469FCA File Offset: 0x004683CA
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
		}

		// Token: 0x0600FF0F RID: 65295 RVA: 0x00469FEB File Offset: 0x004683EB
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
		}

		// Token: 0x0600FF10 RID: 65296 RVA: 0x0046A00C File Offset: 0x0046840C
		private void ClearData()
		{
		}

		// Token: 0x0600FF11 RID: 65297 RVA: 0x0046A00E File Offset: 0x0046840E
		private void BindUIEvent()
		{
		}

		// Token: 0x0600FF12 RID: 65298 RVA: 0x0046A010 File Offset: 0x00468410
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600FF13 RID: 65299 RVA: 0x0046A012 File Offset: 0x00468412
		[UIEventHandle("middle/Close")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<PkMenuFrame>(this, false);
		}

		// Token: 0x0600FF14 RID: 65300 RVA: 0x0046A021 File Offset: 0x00468421
		[UIEventHandle("middle/Scroll View/Viewport/Content/btMission")]
		private void OnMission()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MissionFrameNew>(FrameLayer.Middle, null, string.Empty);
			this.OnClose();
		}

		// Token: 0x0600FF15 RID: 65301 RVA: 0x0046A03B File Offset: 0x0046843B
		[UIEventHandle("middle/Scroll View/Viewport/Content/btForge")]
		private void OnForge()
		{
			if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Forge))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("等级不足,功能尚未解锁", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, null, string.Empty);
			this.OnClose();
		}

		// Token: 0x0600FF16 RID: 65302 RVA: 0x0046A06D File Offset: 0x0046846D
		[UIEventHandle("middle/Scroll View/Viewport/Content/btMall")]
		private void OnMall()
		{
			if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Mall))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("等级不足,功能尚未解锁", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallNewFrame>(FrameLayer.Middle, null, string.Empty);
			this.OnClose();
		}

		// Token: 0x0600FF17 RID: 65303 RVA: 0x0046A0A0 File Offset: 0x004684A0
		[UIEventHandle("middle/Scroll View/Viewport/Content/btAuction")]
		private void OnAuction()
		{
			if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Auction))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("等级不足,功能尚未解锁", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.frameMgr.OpenFrame<AuctionNewFrame>(FrameLayer.Middle, null, string.Empty);
			this.OnClose();
		}

		// Token: 0x0600FF18 RID: 65304 RVA: 0x0046A0D4 File Offset: 0x004684D4
		[UIEventHandle("middle/Scroll View/Viewport/Content/btShop")]
		private void OnShop()
		{
			if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Shop))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("等级不足,功能尚未解锁", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			ShopFrame.OpenLinkFrame("5|0|1");
			this.OnClose();
		}

		// Token: 0x0600FF19 RID: 65305 RVA: 0x0046A0FF File Offset: 0x004684FF
		[UIEventHandle("middle/Scroll View/Viewport/Content/btSkill")]
		private void OnSkill()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillTreeFrame>(FrameLayer.Middle, SkillLeftType.PVP, string.Empty);
			this.OnClose();
		}

		// Token: 0x0600FF1A RID: 65306 RVA: 0x0046A11E File Offset: 0x0046851E
		[UIEventHandle("middle/Scroll View/Viewport/Content/btBag")]
		private void OnBag()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, null, string.Empty);
			this.OnClose();
		}

		// Token: 0x0600FF1B RID: 65307 RVA: 0x0046A138 File Offset: 0x00468538
		[UIEventHandle("middle/Scroll View/Viewport/Content/btSetting")]
		private void OnSetting()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SettingFrame>(FrameLayer.Middle, null, string.Empty);
			this.OnClose();
		}

		// Token: 0x0600FF1C RID: 65308 RVA: 0x0046A152 File Offset: 0x00468552
		[UIEventHandle("middle/Scroll View/Viewport/Content/btAchievement")]
		private void OnAchievement()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActiveGroupMainFrame>(FrameLayer.Middle, null, string.Empty);
			this.OnClose();
		}

		// Token: 0x0600FF1D RID: 65309 RVA: 0x0046A16C File Offset: 0x0046856C
		private void InitInterface()
		{
		}
	}
}
