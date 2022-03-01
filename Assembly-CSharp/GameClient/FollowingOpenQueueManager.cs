using System;
using System.Collections.Generic;
using AdsPush;
using Protocol;

namespace GameClient
{
	// Token: 0x02001255 RID: 4693
	public class FollowingOpenQueueManager : DataManager<FollowingOpenQueueManager>
	{
		// Token: 0x0600B439 RID: 46137 RVA: 0x00285054 File Offset: 0x00283454
		public sealed override void Initialize()
		{
			this.Clear();
			this._InitFollowingOpenQueue();
			this._RegisterAllExtendMethods();
		}

		// Token: 0x0600B43A RID: 46138 RVA: 0x00285068 File Offset: 0x00283468
		public sealed override void Clear()
		{
			if (this.m_FollowingOpenQueue != null)
			{
				this.m_FollowingOpenQueue.Clear();
			}
			if (this.m_FollowingOpenHandlers != null && this.m_FollowingOpenHandlers.Count > 0)
			{
				for (int i = 0; i < 7; i++)
				{
					FollowingOpenQueueManager.FollowingOpenHandler followingOpenHandler;
					if (this.m_FollowingOpenHandlers.TryGetValue(i, out followingOpenHandler))
					{
						if (followingOpenHandler != null)
						{
							Delegate[] invocationList = followingOpenHandler.GetInvocationList();
							if (invocationList != null && invocationList.Length > 0)
							{
								for (int j = 0; j < invocationList.Length; j++)
								{
									followingOpenHandler = (FollowingOpenQueueManager.FollowingOpenHandler)Delegate.Remove(followingOpenHandler, invocationList[j] as FollowingOpenQueueManager.FollowingOpenHandler);
								}
								followingOpenHandler = null;
							}
						}
					}
				}
				this.m_FollowingOpenHandlers.Clear();
			}
			this.m_OpenTriggerType = FollowingOpenTriggerType.Excepetion;
			this.m_OpenQueueOrder = FollowingOpenQueueOrder.None;
		}

		// Token: 0x0600B43B RID: 46139 RVA: 0x0028513C File Offset: 0x0028353C
		private void _InitFollowingOpenQueue()
		{
			int num = 7;
			for (int i = 1; i < num; i++)
			{
				this.m_FollowingOpenQueue.Enqueue((FollowingOpenQueueOrder)i);
			}
		}

		// Token: 0x0600B43C RID: 46140 RVA: 0x00285169 File Offset: 0x00283569
		private bool _IsFollowingOpenQueueEmpty()
		{
			return this.m_FollowingOpenQueue == null || this.m_FollowingOpenQueue.Count == 0;
		}

		// Token: 0x0600B43D RID: 46141 RVA: 0x00285189 File Offset: 0x00283589
		private FollowingOpenQueueOrder _RemoveCurrentFollowingOpenOrder()
		{
			if (this._IsFollowingOpenQueueEmpty())
			{
				return FollowingOpenQueueOrder.None;
			}
			return this.m_FollowingOpenQueue.Dequeue();
		}

		// Token: 0x0600B43E RID: 46142 RVA: 0x002851A4 File Offset: 0x002835A4
		private void _OpenFollowingQueueHandler()
		{
			this.m_OpenTriggerType = FollowingOpenTriggerType.Excepetion;
			if (this.m_OpenTrigger == null)
			{
				this.m_OpenTrigger = new FollowingOpenTrigger();
			}
			this.m_OpenTrigger.triggerType = this.m_OpenTriggerType;
			this.m_OpenQueueOrder = this._RemoveCurrentFollowingOpenOrder();
			if (this.m_FollowingOpenHandlers != null && this.m_FollowingOpenHandlers.ContainsKey((int)this.m_OpenQueueOrder))
			{
				FollowingOpenQueueManager.FollowingOpenHandler followingOpenHandler = this.m_FollowingOpenHandlers[(int)this.m_OpenQueueOrder];
				if (followingOpenHandler != null && this.m_OpenTrigger != null)
				{
					followingOpenHandler(this.m_OpenTrigger);
				}
			}
			if (this.m_OpenTrigger != null && this.m_OpenTrigger.triggerType == FollowingOpenTriggerType.Excepetion)
			{
				this.StartOpenFollowingQueue();
			}
		}

		// Token: 0x0600B43F RID: 46143 RVA: 0x00285260 File Offset: 0x00283660
		private void _RegisterFollowingOpenQueueHandler(FollowingOpenQueueOrder order, FollowingOpenQueueManager.FollowingOpenHandler handler)
		{
			if (this.m_FollowingOpenHandlers == null)
			{
				return;
			}
			if (this.m_FollowingOpenHandlers.ContainsKey((int)order))
			{
				Dictionary<int, FollowingOpenQueueManager.FollowingOpenHandler> followingOpenHandlers;
				(followingOpenHandlers = this.m_FollowingOpenHandlers)[(int)order] = (FollowingOpenQueueManager.FollowingOpenHandler)Delegate.Combine(followingOpenHandlers[(int)order], handler);
			}
			else
			{
				this.m_FollowingOpenHandlers.Add((int)order, new FollowingOpenQueueManager.FollowingOpenHandler(handler.Invoke));
			}
		}

		// Token: 0x0600B440 RID: 46144 RVA: 0x002852C9 File Offset: 0x002836C9
		public void StartOpenFollowingQueue()
		{
			if (this._IsFollowingOpenQueueEmpty())
			{
				return;
			}
			this._OpenFollowingQueueHandler();
		}

		// Token: 0x0600B441 RID: 46145 RVA: 0x002852DD File Offset: 0x002836DD
		public void NotifyCurrentOrderClosed()
		{
			if (this.m_OpenQueueOrder == FollowingOpenQueueOrder.None || this.m_OpenQueueOrder == FollowingOpenQueueOrder.Count)
			{
				return;
			}
			this.StartOpenFollowingQueue();
		}

		// Token: 0x0600B442 RID: 46146 RVA: 0x00285300 File Offset: 0x00283700
		private void _RegisterAllExtendMethods()
		{
			this._RegisterFollowingOpenQueueHandler(FollowingOpenQueueOrder.TopUpPushFrame_FirstOpenEcheDay, new FollowingOpenQueueManager.FollowingOpenHandler(this.OpenTopUpPushFrame));
			this._RegisterFollowingOpenQueueHandler(FollowingOpenQueueOrder.FuncUnlock_MainTown_AdventureTeam, new FollowingOpenQueueManager.FollowingOpenHandler(this._PlayAdventureMainTownUnlockAnim));
			this._RegisterFollowingOpenQueueHandler(FollowingOpenQueueOrder.FuncUnlock_MainTown_AdventurePassCard, new FollowingOpenQueueManager.FollowingOpenHandler(this._PlayAdventurePassCardMainTownUnlockAnim));
			this._RegisterFollowingOpenQueueHandler(FollowingOpenQueueOrder.TryToOpenActiveWelfareFrame, new FollowingOpenQueueManager.FollowingOpenHandler(this._TryToOpenActiveWelfareFrame));
			this._RegisterFollowingOpenQueueHandler(FollowingOpenQueueOrder.Reconnect, new FollowingOpenQueueManager.FollowingOpenHandler(this.TryOpenReconnectSceneTip));
			this._RegisterFollowingOpenQueueHandler(FollowingOpenQueueOrder.WarriorRecruitPush, new FollowingOpenQueueManager.FollowingOpenHandler(this.TryOpenWarriorRecruitPushFrame));
		}

		// Token: 0x0600B443 RID: 46147 RVA: 0x0028537F File Offset: 0x0028377F
		private void _PlayAdventureMainTownUnlockAnim(FollowingOpenTrigger trigger)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NotifyShowAdventureTeamUnlockAnim, trigger, null, null, null);
		}

		// Token: 0x0600B444 RID: 46148 RVA: 0x00285394 File Offset: 0x00283794
		private void _PlayAdventurePassCardMainTownUnlockAnim(FollowingOpenTrigger trigger)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NotifyShowAdventurePassSeasonUnlockAnim, trigger, null, null, null);
		}

		// Token: 0x0600B445 RID: 46149 RVA: 0x002853AC File Offset: 0x002837AC
		private void OpenTopUpPushFrame(FollowingOpenTrigger trigger)
		{
			if (Singleton<ClientSystemManager>.GetInstance().PreSystemType != typeof(ClientSystemLogin))
			{
				return;
			}
			if (Singleton<LoginPushManager>.GetInstance().IsFirstLogin())
			{
				TopUpPushDataModel topUpPushDataModel = DataManager<TopUpPushDataManager>.GetInstance().GetTopUpPushDataModel();
				if (topUpPushDataModel != null && topUpPushDataModel.mItems.Count > 0 && DataManager<TopUpPushDataManager>.GetInstance().CheckFirstLoginIsPush() && !DataManager<TopUpPushDataManager>.GetInstance().LoginTopUpPushIsOpen)
				{
					IClientFrame clientFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<TopUpPushFrame>(FrameLayer.Middle, null, string.Empty);
					if (clientFrame != null && trigger != null)
					{
						trigger.triggerType = FollowingOpenTriggerType.Normal;
					}
					DataManager<TopUpPushDataManager>.GetInstance().LoginTopUpPushIsOpen = true;
				}
			}
		}

		// Token: 0x0600B446 RID: 46150 RVA: 0x00285452 File Offset: 0x00283852
		private void _TryToOpenActiveWelfareFrame(FollowingOpenTrigger trigger)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NotifyOpenWelfareFrame, trigger, null, null, null);
		}

		// Token: 0x0600B447 RID: 46151 RVA: 0x00285468 File Offset: 0x00283868
		private void TryOpenReconnectSceneTip(FollowingOpenTrigger trigger)
		{
			if (Singleton<ClientSystemManager>.GetInstance().PreSystemType != typeof(ClientSystemLogin))
			{
				return;
			}
			if (!TeamDuplicationUtility.IsNeedReconnectToTeamDuplicationScene())
			{
				return;
			}
			TeamDuplicationUtility.OpenReconnectToTeamDuplicationSceneTip(new Action(this.OnReconnectToTeamDuplicationSceneAction), new Action(this.OnReconnectToDuplicationSceneCancelAction));
			trigger.triggerType = FollowingOpenTriggerType.Normal;
		}

		// Token: 0x0600B448 RID: 46152 RVA: 0x002854BE File Offset: 0x002838BE
		private void OnReconnectToTeamDuplicationSceneAction()
		{
			TeamDuplicationUtility.ReconnectToTeamDuplicationScene();
			this.NotifyCurrentOrderClosed();
		}

		// Token: 0x0600B449 RID: 46153 RVA: 0x002854CB File Offset: 0x002838CB
		private void OnReconnectToDuplicationSceneCancelAction()
		{
			this.NotifyCurrentOrderClosed();
		}

		// Token: 0x0600B44A RID: 46154 RVA: 0x002854D4 File Offset: 0x002838D4
		private void TryOpenWarriorRecruitPushFrame(FollowingOpenTrigger trigger)
		{
			if (Singleton<ClientSystemManager>.GetInstance().PreSystemType != typeof(ClientSystemLogin))
			{
				return;
			}
			int num = 0;
			int.TryParse(TR.Value("RecruitmentPush_Lv"), out num);
			if (Singleton<LoginPushManager>.GetInstance().IsFirstLogin() && (int)DataManager<PlayerBaseData>.GetInstance().Level >= num && DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_COUNTER_HIRE_PUS) <= 0UL && DataManager<WarriorRecruitDataManager>.GetInstance().CheckWarriorRecruitActiveIsOpen())
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<WarriorRecruitPushFrame>(FrameLayer.Middle, null, string.Empty);
				trigger.triggerType = FollowingOpenTriggerType.Normal;
			}
		}

		// Token: 0x0400659B RID: 26011
		private Queue<FollowingOpenQueueOrder> m_FollowingOpenQueue = new Queue<FollowingOpenQueueOrder>();

		// Token: 0x0400659C RID: 26012
		private Dictionary<int, FollowingOpenQueueManager.FollowingOpenHandler> m_FollowingOpenHandlers = new Dictionary<int, FollowingOpenQueueManager.FollowingOpenHandler>();

		// Token: 0x0400659D RID: 26013
		private FollowingOpenTriggerType m_OpenTriggerType = FollowingOpenTriggerType.Excepetion;

		// Token: 0x0400659E RID: 26014
		private FollowingOpenTrigger m_OpenTrigger = new FollowingOpenTrigger();

		// Token: 0x0400659F RID: 26015
		private FollowingOpenQueueOrder m_OpenQueueOrder;

		// Token: 0x02001256 RID: 4694
		// (Invoke) Token: 0x0600B44C RID: 46156
		public delegate void FollowingOpenHandler(FollowingOpenTrigger trigger);
	}
}
