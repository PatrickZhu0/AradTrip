using System;

namespace GameClient
{
	// Token: 0x02001926 RID: 6438
	public class VanityBuffBonusFrame : ClientFrame
	{
		// Token: 0x0600FA87 RID: 64135 RVA: 0x00449DED File Offset: 0x004481ED
		protected sealed override void _bindExUI()
		{
			this.mVanityBuffBonusView = this.mBind.GetCom<VanityBuffBonusView>("VanityBuffBonusView");
		}

		// Token: 0x0600FA88 RID: 64136 RVA: 0x00449E05 File Offset: 0x00448205
		protected sealed override void _unbindExUI()
		{
			this.mVanityBuffBonusView = null;
		}

		// Token: 0x0600FA89 RID: 64137 RVA: 0x00449E0E File Offset: 0x0044820E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/YiJie/VanityBuffBonusFrame";
		}

		// Token: 0x0600FA8A RID: 64138 RVA: 0x00449E15 File Offset: 0x00448215
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this._InitView();
		}

		// Token: 0x0600FA8B RID: 64139 RVA: 0x00449E23 File Offset: 0x00448223
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VanityBonusAnimationEnd, null, null, null, null);
		}

		// Token: 0x0600FA8C RID: 64140 RVA: 0x00449E3E File Offset: 0x0044823E
		public void _InitView()
		{
			this.data = (this.userData as VanityBuffBonusModel);
			if (this.data != null)
			{
				this.mVanityBuffBonusView.Init(this.data);
				this.mVanityBuffBonusView.PlayAnimation();
			}
		}

		// Token: 0x0600FA8D RID: 64141 RVA: 0x00449E78 File Offset: 0x00448278
		private void _OnCloseClick()
		{
			base.Close(false);
		}

		// Token: 0x04009C83 RID: 40067
		private const string prefabPath = "UIFlatten/Prefabs/OperateActivity/YiJie/VanityBuffBonusFrame";

		// Token: 0x04009C84 RID: 40068
		private VanityBuffBonusModel data;

		// Token: 0x04009C85 RID: 40069
		private VanityBuffBonusView mVanityBuffBonusView;
	}
}
