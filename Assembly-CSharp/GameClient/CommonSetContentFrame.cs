using System;

namespace GameClient
{
	// Token: 0x02000E28 RID: 3624
	public class CommonSetContentFrame : ClientFrame
	{
		// Token: 0x060090F4 RID: 37108 RVA: 0x001AD27F File Offset: 0x001AB67F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/CommonFrame/CommonSetContentFrame";
		}

		// Token: 0x060090F5 RID: 37109 RVA: 0x001AD288 File Offset: 0x001AB688
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			CommonSetContentDataModel setContentDataModel = this.userData as CommonSetContentDataModel;
			if (this.mCommonSetContentView != null)
			{
				this.mCommonSetContentView.Init(setContentDataModel);
			}
		}

		// Token: 0x060090F6 RID: 37110 RVA: 0x001AD2C4 File Offset: 0x001AB6C4
		protected override void _bindExUI()
		{
			this.mCommonSetContentView = this.mBind.GetCom<CommonSetContentView>("CommonSetContentView");
		}

		// Token: 0x060090F7 RID: 37111 RVA: 0x001AD2DC File Offset: 0x001AB6DC
		protected override void _unbindExUI()
		{
			this.mCommonSetContentView = null;
		}

		// Token: 0x04004840 RID: 18496
		private CommonSetContentView mCommonSetContentView;
	}
}
