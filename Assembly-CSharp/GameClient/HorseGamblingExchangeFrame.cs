using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001681 RID: 5761
	internal class HorseGamblingExchangeFrame : ClientFrame
	{
		// Token: 0x0600E27D RID: 57981 RVA: 0x003A2DF4 File Offset: 0x003A11F4
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/HorseGambling/HorseGamblingExchangeFrame";
		}

		// Token: 0x0600E27E RID: 57982 RVA: 0x003A2DFC File Offset: 0x003A11FC
		protected override void _OnOpenFrame()
		{
			this.mView = this.frame.GetComponent<HorseGamblingExchangeView>();
			if (this.mView != null)
			{
				this.mView.Init(new UnityAction(this.OnBuy), new UnityAction(this.OnClose));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingBuyBulletResponse, new ClientEventSystem.UIEventHandler(this.OnBuyResp));
		}

		// Token: 0x0600E27F RID: 57983 RVA: 0x003A2E69 File Offset: 0x003A1269
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingBuyBulletResponse, new ClientEventSystem.UIEventHandler(this.OnBuyResp));
			if (this.mView != null)
			{
				this.mView.Dispose();
				this.mView = null;
			}
		}

		// Token: 0x0600E280 RID: 57984 RVA: 0x003A2EA9 File Offset: 0x003A12A9
		private void OnClose()
		{
			base.Close(false);
		}

		// Token: 0x0600E281 RID: 57985 RVA: 0x003A2EB4 File Offset: 0x003A12B4
		private void OnBuy()
		{
			if (this.mView != null)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mView.GoldItemId, false);
				if (ownedItemCount < this.mView.ExchangeRate * this.mView.ExchangeCount)
				{
					SystemNotifyManager.SystemNotify(9929, string.Empty);
					return;
				}
				if (this.mView.ExchangeCount > 0)
				{
					this.mView.SetConfirmEnable(false);
					DataManager<HorseGamblingDataManager>.GetInstance().ExchangeBullet(this.mView.ExchangeCount);
				}
				else
				{
					SystemNotifyManager.SystemNotify(9926, string.Empty);
				}
			}
		}

		// Token: 0x0600E282 RID: 57986 RVA: 0x003A2F5C File Offset: 0x003A135C
		private void OnBuyResp(UIEvent uiEvent)
		{
			if (uiEvent != null && uiEvent.Param1 != null)
			{
				if ((int)uiEvent.Param1 == 0)
				{
					base.Close(false);
				}
				else if (this.mView != null)
				{
					this.mView.SetConfirmEnable(true);
				}
			}
		}

		// Token: 0x04008785 RID: 34693
		private HorseGamblingExchangeView mView;

		// Token: 0x04008786 RID: 34694
		private int mShooterId;
	}
}
