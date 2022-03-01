using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001968 RID: 6504
	public class HeadPortraitFrame : ClientFrame
	{
		// Token: 0x0600FCEA RID: 64746 RVA: 0x0045A09C File Offset: 0x0045849C
		protected sealed override void _bindExUI()
		{
			this.mHeadPortraitFrameView = this.mBind.GetCom<HeadPortraitFrameView>("HeadPortraitFrameView");
		}

		// Token: 0x0600FCEB RID: 64747 RVA: 0x0045A0B4 File Offset: 0x004584B4
		protected sealed override void _unbindExUI()
		{
			this.mHeadPortraitFrameView = null;
		}

		// Token: 0x0600FCEC RID: 64748 RVA: 0x0045A0BD File Offset: 0x004584BD
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/PersonalSettingFrame/HeadPortraitFrame/HeadPortraitFrame";
		}

		// Token: 0x0600FCED RID: 64749 RVA: 0x0045A0C4 File Offset: 0x004584C4
		protected sealed override void _OnOpenFrame()
		{
			this.RegistUIEventHandle();
			this.UpdateWearHeadPortraitFrameID();
			this.mHeadPortraitFrameView.InitView(new OnHeadPortraitTabItemClick(this.OnHeadPortraitTabItemClick));
		}

		// Token: 0x0600FCEE RID: 64750 RVA: 0x0045A0E9 File Offset: 0x004584E9
		protected sealed override void _OnCloseFrame()
		{
			this.UnRegistUIEventHandle();
			this.mCurrentSelectHeadPortraitTabType = HeadPortraitTabType.HPTT_ALL;
		}

		// Token: 0x0600FCEF RID: 64751 RVA: 0x0045A0F8 File Offset: 0x004584F8
		private void RegistUIEventHandle()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UseHeadPortraitFrameSuccess, new ClientEventSystem.UIEventHandler(this.UpdateHeadPortraitItemInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HeadPortraitFrameNotify, new ClientEventSystem.UIEventHandler(this.UpdateHeadPortraitItemInfo));
		}

		// Token: 0x0600FCF0 RID: 64752 RVA: 0x0045A130 File Offset: 0x00458530
		private void UnRegistUIEventHandle()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UseHeadPortraitFrameSuccess, new ClientEventSystem.UIEventHandler(this.UpdateHeadPortraitItemInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HeadPortraitFrameNotify, new ClientEventSystem.UIEventHandler(this.UpdateHeadPortraitItemInfo));
		}

		// Token: 0x0600FCF1 RID: 64753 RVA: 0x0045A168 File Offset: 0x00458568
		private void UpdateHeadPortraitItemInfo(UIEvent uiEvent)
		{
			this.UpdateWearHeadPortraitFrameID();
			this.UpdateHeadProtraitItem(this.mCurrentSelectHeadPortraitTabType, false);
		}

		// Token: 0x0600FCF2 RID: 64754 RVA: 0x0045A17D File Offset: 0x0045857D
		private void OnHeadPortraitTabItemClick(HeadPortraitTabDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mCurrentSelectHeadPortraitTabType = data.tabType;
			this.UpdateHeadProtraitItem(this.mCurrentSelectHeadPortraitTabType, true);
		}

		// Token: 0x0600FCF3 RID: 64755 RVA: 0x0045A1A0 File Offset: 0x004585A0
		private void UpdateHeadProtraitItem(HeadPortraitTabType tabType, bool isResetIndex = false)
		{
			List<HeadPortraitItemData> headPortraitItemList = DataManager<HeadPortraitFrameDataManager>.GetInstance().GetHeadPortraitItemList(tabType);
			if (headPortraitItemList != null)
			{
				this.mHeadPortraitFrameView.UpdateHeadProtraitItem(headPortraitItemList, isResetIndex);
			}
			else
			{
				this.mHeadPortraitFrameView.UpdateHeadProtraitItem(new List<HeadPortraitItemData>(), isResetIndex);
			}
		}

		// Token: 0x0600FCF4 RID: 64756 RVA: 0x0045A1E2 File Offset: 0x004585E2
		private void UpdateWearHeadPortraitFrameID()
		{
			if (HeadPortraitFrameDataManager.WearHeadPortraitFrameID == 0)
			{
				HeadPortraitFrameDataManager.WearHeadPortraitFrameID = HeadPortraitFrameDataManager.iDefaultHeadPortraitID;
			}
		}

		// Token: 0x04009EE0 RID: 40672
		private HeadPortraitTabType mCurrentSelectHeadPortraitTabType;

		// Token: 0x04009EE1 RID: 40673
		private HeadPortraitFrameView mHeadPortraitFrameView;
	}
}
