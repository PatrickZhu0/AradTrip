using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001773 RID: 6003
	internal class MallShopSelectFrame : ClientFrame
	{
		// Token: 0x0600ED3D RID: 60733 RVA: 0x003F966C File Offset: 0x003F7A6C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mall/MallShopSelectFrame";
		}

		// Token: 0x0600ED3E RID: 60734 RVA: 0x003F9673 File Offset: 0x003F7A73
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
		}

		// Token: 0x0600ED3F RID: 60735 RVA: 0x003F967B File Offset: 0x003F7A7B
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600ED40 RID: 60736 RVA: 0x003F9683 File Offset: 0x003F7A83
		private void ClearData()
		{
		}

		// Token: 0x0600ED41 RID: 60737 RVA: 0x003F9685 File Offset: 0x003F7A85
		private void InitInterface()
		{
		}

		// Token: 0x0600ED42 RID: 60738 RVA: 0x003F9688 File Offset: 0x003F7A88
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("BtClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtMall = this.mBind.GetCom<Button>("BtMall");
			this.mBtMall.onClick.AddListener(new UnityAction(this._onBtMallButtonClick));
			this.mBtShop = this.mBind.GetCom<Button>("BtShop");
			this.mBtShop.onClick.AddListener(new UnityAction(this._onBtShopButtonClick));
			this.mBtCharge = this.mBind.GetCom<Button>("BtCharge");
			this.mBtCharge.onClick.AddListener(new UnityAction(this._onBtChargeButtonClick));
		}

		// Token: 0x0600ED43 RID: 60739 RVA: 0x003F9760 File Offset: 0x003F7B60
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mBtMall.onClick.RemoveListener(new UnityAction(this._onBtMallButtonClick));
			this.mBtMall = null;
			this.mBtShop.onClick.RemoveListener(new UnityAction(this._onBtShopButtonClick));
			this.mBtShop = null;
			this.mBtCharge.onClick.RemoveListener(new UnityAction(this._onBtChargeButtonClick));
			this.mBtCharge = null;
		}

		// Token: 0x0600ED44 RID: 60740 RVA: 0x003F97F9 File Offset: 0x003F7BF9
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<MallShopSelectFrame>(this, false);
		}

		// Token: 0x0600ED45 RID: 60741 RVA: 0x003F9808 File Offset: 0x003F7C08
		private void _onBtMallButtonClick()
		{
			this.frameMgr.OpenFrame<MallNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600ED46 RID: 60742 RVA: 0x003F981D File Offset: 0x003F7C1D
		private void _onBtShopButtonClick()
		{
		}

		// Token: 0x0600ED47 RID: 60743 RVA: 0x003F9820 File Offset: 0x003F7C20
		private void _onBtChargeButtonClick()
		{
			VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
			vipFrame.OpenPayTab();
		}

		// Token: 0x040090C6 RID: 37062
		private Button mBtClose;

		// Token: 0x040090C7 RID: 37063
		private Button mBtMall;

		// Token: 0x040090C8 RID: 37064
		private Button mBtShop;

		// Token: 0x040090C9 RID: 37065
		private Button mBtCharge;
	}
}
