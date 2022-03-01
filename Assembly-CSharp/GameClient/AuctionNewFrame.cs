using System;

namespace GameClient
{
	// Token: 0x02001461 RID: 5217
	public class AuctionNewFrame : ClientFrame
	{
		// Token: 0x0600CA4D RID: 51789 RVA: 0x00318328 File Offset: 0x00316728
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length >= 3)
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewFrame>(null, false);
					AuctionNewUserData auctionNewUserData = new AuctionNewUserData();
					auctionNewUserData.MainTabType = (AuctionNewMainTabType)int.Parse(array[0]);
					auctionNewUserData.FirstLayerTabId = int.Parse(array[1]);
					auctionNewUserData.SecondLayerTabId = int.Parse(array[2]);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewFrame>(FrameLayer.Middle, auctionNewUserData, string.Empty);
				}
				else
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewFrame>(null, false);
					AuctionNewUserData userData = new AuctionNewUserData
					{
						MainTabType = AuctionNewMainTabType.AuctionBuyType,
						FirstLayerTabId = 0
					};
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewFrame>(FrameLayer.Middle, userData, string.Empty);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600CA4E RID: 51790 RVA: 0x00318400 File Offset: 0x00316800
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AuctionNew/AuctionNewFrame";
		}

		// Token: 0x0600CA4F RID: 51791 RVA: 0x00318408 File Offset: 0x00316808
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			DataManager<AuctionNewDataManager>.GetInstance().ResetPreviewOnShelfItemData();
			AuctionNewUserData auctionNewUserData;
			if (this.userData != null)
			{
				auctionNewUserData = (this.userData as AuctionNewUserData);
			}
			else
			{
				auctionNewUserData = DataManager<AuctionNewDataManager>.GetInstance().GetLastTimeUserData();
			}
			if (this.mAuctionNewView != null)
			{
				this.mAuctionNewView.InitView(auctionNewUserData);
			}
		}

		// Token: 0x0600CA50 RID: 51792 RVA: 0x0031846B File Offset: 0x0031686B
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewFrameClosed, null, null, null, null);
			DataManager<AuctionNewDataManager>.GetInstance().ResetPreviewOnShelfItemData();
		}

		// Token: 0x0600CA51 RID: 51793 RVA: 0x0031848A File Offset: 0x0031688A
		protected override void _bindExUI()
		{
			this.mAuctionNewView = this.mBind.GetCom<AuctionNewView>("AuctionNewView");
		}

		// Token: 0x0600CA52 RID: 51794 RVA: 0x003184A2 File Offset: 0x003168A2
		protected override void _unbindExUI()
		{
			this.mAuctionNewView = null;
		}

		// Token: 0x04007576 RID: 30070
		private AuctionNewView mAuctionNewView;
	}
}
