using System;

namespace GameClient
{
	// Token: 0x02001A72 RID: 6770
	public class GoblinPreviewFrame : ClientFrame
	{
		// Token: 0x060109EE RID: 68078 RVA: 0x004B3809 File Offset: 0x004B1C09
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ShopNew/GoblinPreviewFrame";
		}

		// Token: 0x060109EF RID: 68079 RVA: 0x004B3810 File Offset: 0x004B1C10
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this._updatePreviewView));
			DataManager<MallNewDataManager>.GetInstance().SendWorldMallQueryItemReq(9, 0, 0);
			if (this.mGoblinPreviewView != null)
			{
				this.mGoblinPreviewView.InitPreviewView();
			}
		}

		// Token: 0x060109F0 RID: 68080 RVA: 0x004B3862 File Offset: 0x004B1C62
		protected override void _bindExUI()
		{
			this.mGoblinPreviewView = this.mBind.GetCom<GoblinPreviewView>("GoblinPreviewView");
		}

		// Token: 0x060109F1 RID: 68081 RVA: 0x004B387A File Offset: 0x004B1C7A
		protected override void _unbindExUI()
		{
			this.mGoblinPreviewView = null;
		}

		// Token: 0x060109F2 RID: 68082 RVA: 0x004B3883 File Offset: 0x004B1C83
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this._updatePreviewView));
		}

		// Token: 0x060109F3 RID: 68083 RVA: 0x004B38A0 File Offset: 0x004B1CA0
		private void _updatePreviewView(UIEvent uiEvent)
		{
			int num = (int)uiEvent.Param1;
			if (num == 6 && this.mGoblinPreviewView != null)
			{
				this.mGoblinPreviewView.InitPreviewView();
			}
		}

		// Token: 0x0400A99E RID: 43422
		private GoblinPreviewView mGoblinPreviewView;
	}
}
