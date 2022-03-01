using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B9C RID: 7068
	public class SmithShopNewFrame : ClientFrame
	{
		// Token: 0x06011554 RID: 70996 RVA: 0x005030D8 File Offset: 0x005014D8
		protected sealed override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mSmithShopNewFrameView = this.mBind.GetCom<SmithShopNewFrameView>("SmithShopNewFrameView");
		}

		// Token: 0x06011555 RID: 70997 RVA: 0x0050312D File Offset: 0x0050152D
		protected sealed override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mSmithShopNewFrameView = null;
		}

		// Token: 0x06011556 RID: 70998 RVA: 0x00503159 File Offset: 0x00501559
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<SmithShopNewFrame>(this, false);
		}

		// Token: 0x06011557 RID: 70999 RVA: 0x00503168 File Offset: 0x00501568
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				SmithShopNewLinkData smithShopNewLinkData = new SmithShopNewLinkData();
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length == 1)
				{
					smithShopNewLinkData.itemData = null;
					int.TryParse(array[0], out smithShopNewLinkData.iDefaultFirstTabId);
				}
				else if (array.Length == 2)
				{
					smithShopNewLinkData.itemData = null;
					int.TryParse(array[0], out smithShopNewLinkData.iDefaultFirstTabId);
					int.TryParse(array[1], out smithShopNewLinkData.iDefaultSecondTabId);
				}
				else if (array.Length == 3)
				{
					smithShopNewLinkData.itemData = null;
					int.TryParse(array[0], out smithShopNewLinkData.iDefaultFirstTabId);
					int.TryParse(array[1], out smithShopNewLinkData.iDefaultSecondTabId);
					int.TryParse(array[2], out smithShopNewLinkData.iSmithShopNewOpenTypeId);
				}
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SmithShopNewFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, smithShopNewLinkData, string.Empty);
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x06011558 RID: 71000 RVA: 0x00503278 File Offset: 0x00501678
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShopNewFrame/SmithShopNewFrame";
		}

		// Token: 0x06011559 RID: 71001 RVA: 0x00503280 File Offset: 0x00501680
		protected sealed override void _OnOpenFrame()
		{
			this.RegisterUIEventHandle();
			if (this.userData != null)
			{
				SmithShopNewFrame.linkData = (this.userData as SmithShopNewLinkData);
			}
			if (this.mSmithShopNewFrameView != null)
			{
				this.mSmithShopNewFrameView.InitView(SmithShopNewFrame.linkData);
			}
		}

		// Token: 0x0601155A RID: 71002 RVA: 0x005032CF File Offset: 0x005016CF
		protected sealed override void _OnCloseFrame()
		{
			this.UnRegisterUIEventHandle();
			SmithShopNewFrame.linkData = null;
			this.CloseAllFrame();
		}

		// Token: 0x0601155B RID: 71003 RVA: 0x005032E4 File Offset: 0x005016E4
		private void CloseAllFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenConfirm>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenConfirm>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenSpecialConfirmFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenSpecialConfirmFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonMsgBoxOKCancel>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxOKCancel>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdjustResultFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdjustResultFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonMsgBoxOkCancelNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxOkCancelNewFrame>(null, false);
			}
			CommonNewMessageBoxView._CloseFrame();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MagicCardOneKeyMergeTipFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MagicCardOneKeyMergeTipFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewMsgBoxOkCancelFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewMsgBoxOkCancelFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonPurChaseHintFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonPurChaseHintFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<InscriptionExtractFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<InscriptionExtractFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<InscriptionFractureFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<InscriptionFractureFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PerfectWashRollConfirm>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PerfectWashRollConfirm>(null, false);
			}
		}

		// Token: 0x0601155C RID: 71004 RVA: 0x0050342A File Offset: 0x0050182A
		private void RegisterUIEventHandle()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationCloseRelationFrame, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationCloseRelationFrame));
		}

		// Token: 0x0601155D RID: 71005 RVA: 0x00503447 File Offset: 0x00501847
		private void UnRegisterUIEventHandle()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationCloseRelationFrame, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationCloseRelationFrame));
		}

		// Token: 0x0601155E RID: 71006 RVA: 0x00503464 File Offset: 0x00501864
		private void OnReceiveTeamDuplicationCloseRelationFrame(UIEvent uiEvent)
		{
			EquipGrowthDataManager.MandatoryCloseSmithshopNewFrame();
		}

		// Token: 0x0400B37E RID: 45950
		public static SmithShopNewLinkData linkData;

		// Token: 0x0400B37F RID: 45951
		private Button mClose;

		// Token: 0x0400B380 RID: 45952
		private SmithShopNewFrameView mSmithShopNewFrameView;
	}
}
