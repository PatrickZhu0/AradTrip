using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001937 RID: 6455
	public class ZillionaireGameGridItemTipsFrame : ClientFrame
	{
		// Token: 0x0600FAFC RID: 64252 RVA: 0x0044C29C File Offset: 0x0044A69C
		protected override void _bindExUI()
		{
			this.mView = this.mBind.GetCom<ZillionaireGameGridItemTipsView>("View");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}

		// Token: 0x0600FAFD RID: 64253 RVA: 0x0044C2F1 File Offset: 0x0044A6F1
		protected override void _unbindExUI()
		{
			this.mView = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
		}

		// Token: 0x0600FAFE RID: 64254 RVA: 0x0044C31D File Offset: 0x0044A71D
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ZillionaireGameGridItemTipsFrame>(this, false);
		}

		// Token: 0x0600FAFF RID: 64255 RVA: 0x0044C32C File Offset: 0x0044A72C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/ZillionaireGame/GridItemTips";
		}

		// Token: 0x0600FB00 RID: 64256 RVA: 0x0044C334 File Offset: 0x0044A734
		protected override void _OnOpenFrame()
		{
			MapGridItemData mapGridItemData = this.userData as MapGridItemData;
			if (mapGridItemData != null && this.mView != null)
			{
				this.mView.InitView(mapGridItemData);
			}
		}

		// Token: 0x0600FB01 RID: 64257 RVA: 0x0044C370 File Offset: 0x0044A770
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x04009CD3 RID: 40147
		private ZillionaireGameGridItemTipsView mView;

		// Token: 0x04009CD4 RID: 40148
		private Button mClose;
	}
}
