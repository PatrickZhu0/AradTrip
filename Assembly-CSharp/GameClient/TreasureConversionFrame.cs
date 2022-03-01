using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CC1 RID: 7361
	public class TreasureConversionFrame : ClientFrame
	{
		// Token: 0x060120F0 RID: 73968 RVA: 0x005485C4 File Offset: 0x005469C4
		protected sealed override void _bindExUI()
		{
			this.mTreasureConversionView = this.mBind.GetCom<TreasureConversionView>("TreasureConversionView");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}

		// Token: 0x060120F1 RID: 73969 RVA: 0x00548619 File Offset: 0x00546A19
		protected sealed override void _unbindExUI()
		{
			this.mTreasureConversionView = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
		}

		// Token: 0x060120F2 RID: 73970 RVA: 0x00548645 File Offset: 0x00546A45
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<TreasureConversionFrame>(this, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewMsgBoxOkCancelFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewMsgBoxOkCancelFrame>(null, false);
			}
		}

		// Token: 0x060120F3 RID: 73971 RVA: 0x00548670 File Offset: 0x00546A70
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TreasureConversionFrame/TreasureConversionFrame";
		}

		// Token: 0x060120F4 RID: 73972 RVA: 0x00548677 File Offset: 0x00546A77
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityUpdate));
			if (this.mTreasureConversionView != null)
			{
				this.mTreasureConversionView.InitView();
			}
		}

		// Token: 0x060120F5 RID: 73973 RVA: 0x005486B6 File Offset: 0x00546AB6
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityUpdate));
		}

		// Token: 0x060120F6 RID: 73974 RVA: 0x005486D9 File Offset: 0x00546AD9
		private void OnActivityUpdate(UIEvent a_event)
		{
			if (!DataManager<BeadCardManager>.GetInstance().CheckTreasureConvertActivityOpon())
			{
				this.frameMgr.CloseFrame<TreasureConversionFrame>(this, false);
			}
		}

		// Token: 0x0400BC39 RID: 48185
		private TreasureConversionView mTreasureConversionView;

		// Token: 0x0400BC3A RID: 48186
		private Button mClose;
	}
}
