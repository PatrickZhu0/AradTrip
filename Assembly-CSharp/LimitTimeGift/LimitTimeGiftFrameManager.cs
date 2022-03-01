using System;
using System.Collections.Generic;
using GameClient;

namespace LimitTimeGift
{
	// Token: 0x0200172C RID: 5932
	public class LimitTimeGiftFrameManager : Singleton<LimitTimeGiftFrameManager>
	{
		// Token: 0x0600E8F6 RID: 59638 RVA: 0x003DAAB2 File Offset: 0x003D8EB2
		public override void Init()
		{
			this.currShowGiftFrameList = new List<LimitTimeGiftFrame>();
			this.cacheLimitTimeDataToShowFrame = null;
		}

		// Token: 0x0600E8F7 RID: 59639 RVA: 0x003DAAC6 File Offset: 0x003D8EC6
		public override void UnInit()
		{
			this.ClearAllCurrShowGiftFrameList();
			this.currShowGiftFrameList = null;
			this.cacheLimitTimeDataToShowFrame = null;
		}

		// Token: 0x0600E8F8 RID: 59640 RVA: 0x003DAADC File Offset: 0x003D8EDC
		public void AddCurrShowGiftFrame(LimitTimeGiftData giftData)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallNewFrame>(null))
			{
				return;
			}
			IClientSystem currentSystem = Singleton<ClientSystemManager>.GetInstance().CurrentSystem;
			if (currentSystem != null && this.currShowGiftFrameList != null)
			{
				this.cacheLimitTimeDataToShowFrame = null;
				if (currentSystem is ClientSystemTown)
				{
					if (DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToTown)
					{
						return;
					}
					Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(500, delegate
					{
						if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenResultFrame>(null) || Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenContinueResultsFrame>(null))
						{
							this.cacheLimitTimeDataToShowFrame = giftData;
							return;
						}
						LimitTimeGiftFrame limitTimeGiftFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<LimitTimeGiftFrame>(FrameLayer.Middle, giftData, string.Empty) as LimitTimeGiftFrame;
						if (limitTimeGiftFrame != null)
						{
							this.currShowGiftFrameList.Add(limitTimeGiftFrame);
						}
					}, 0, 0, false);
				}
				else
				{
					this.cacheLimitTimeDataToShowFrame = giftData;
				}
			}
		}

		// Token: 0x0600E8F9 RID: 59641 RVA: 0x003DAB81 File Offset: 0x003D8F81
		public void RemoveCurrShowGiftFrame(LimitTimeGiftFrame giftFrame)
		{
			if (this.currShowGiftFrameList != null && giftFrame != null && this.currShowGiftFrameList.Contains(giftFrame))
			{
				this.currShowGiftFrameList.Remove(giftFrame);
			}
		}

		// Token: 0x0600E8FA RID: 59642 RVA: 0x003DABB2 File Offset: 0x003D8FB2
		public void ClearAllCurrShowGiftFrameList()
		{
			if (this.currShowGiftFrameList != null)
			{
				this.currShowGiftFrameList.Clear();
			}
		}

		// Token: 0x0600E8FB RID: 59643 RVA: 0x003DABCA File Offset: 0x003D8FCA
		public void WaitToShowLimitTimeGiftFrame()
		{
			if (this.cacheLimitTimeDataToShowFrame != null)
			{
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(250, delegate
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenContinueResultsFrame>(null))
					{
						return;
					}
					LimitTimeGiftFrame limitTimeGiftFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<LimitTimeGiftFrame>(FrameLayer.Middle, this.cacheLimitTimeDataToShowFrame, string.Empty) as LimitTimeGiftFrame;
					if (limitTimeGiftFrame != null)
					{
						this.currShowGiftFrameList.Add(limitTimeGiftFrame);
						this.cacheLimitTimeDataToShowFrame = null;
					}
				}, 0, 0, false);
			}
		}

		// Token: 0x0600E8FC RID: 59644 RVA: 0x003DABFB File Offset: 0x003D8FFB
		private void RegisterActivateUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStrengthenFail, new ClientEventSystem.UIEventHandler(this._OnItemStrengthenFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStrengthenSuccess, new ClientEventSystem.UIEventHandler(this._OnItemStrengthenSucc));
		}

		// Token: 0x0600E8FD RID: 59645 RVA: 0x003DAC33 File Offset: 0x003D9033
		private void UnRegisterActivateUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStrengthenFail, new ClientEventSystem.UIEventHandler(this._OnItemStrengthenFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStrengthenSuccess, new ClientEventSystem.UIEventHandler(this._OnItemStrengthenSucc));
		}

		// Token: 0x0600E8FE RID: 59646 RVA: 0x003DAC6B File Offset: 0x003D906B
		private void _OnItemStrengthenFail(UIEvent uiEvent)
		{
		}

		// Token: 0x0600E8FF RID: 59647 RVA: 0x003DAC6D File Offset: 0x003D906D
		private void _OnItemStrengthenSucc(UIEvent uiEvent)
		{
		}

		// Token: 0x04008D54 RID: 36180
		private List<LimitTimeGiftFrame> currShowGiftFrameList;

		// Token: 0x04008D55 RID: 36181
		private LimitTimeGiftData cacheLimitTimeDataToShowFrame;
	}
}
