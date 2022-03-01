using System;

namespace GameClient
{
	// Token: 0x0200193A RID: 6458
	public class ZillionaireGameTurntableFrame : ClientFrame
	{
		// Token: 0x0600FB18 RID: 64280 RVA: 0x0044CB10 File Offset: 0x0044AF10
		protected override void _bindExUI()
		{
			this.mView = this.mBind.GetCom<ZillionaireGameTurntableView>("View");
		}

		// Token: 0x0600FB19 RID: 64281 RVA: 0x0044CB28 File Offset: 0x0044AF28
		protected override void _unbindExUI()
		{
			this.mView = null;
		}

		// Token: 0x0600FB1A RID: 64282 RVA: 0x0044CB31 File Offset: 0x0044AF31
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/ZillionaireGame/ZillionaireGameTurntable";
		}

		// Token: 0x0600FB1B RID: 64283 RVA: 0x0044CB38 File Offset: 0x0044AF38
		protected override void _OnOpenFrame()
		{
			ZillionaireGameTurntableData zillionaireGameTurntableData = this.userData as ZillionaireGameTurntableData;
			if (this.mView != null)
			{
				this.mView.InitView(zillionaireGameTurntableData);
			}
		}

		// Token: 0x0600FB1C RID: 64284 RVA: 0x0044CB6E File Offset: 0x0044AF6E
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
		}

		// Token: 0x04009CE4 RID: 40164
		private ZillionaireGameTurntableView mView;
	}
}
