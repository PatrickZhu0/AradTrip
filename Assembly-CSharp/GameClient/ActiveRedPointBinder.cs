using System;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000008 RID: 8
	internal class ActiveRedPointBinder : MonoBehaviour
	{
		// Token: 0x06000029 RID: 41 RVA: 0x000052D0 File Offset: 0x000036D0
		private void Start()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Combine(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Combine(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Combine(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WelfActivityRedPoint, new ClientEventSystem.UIEventHandler(this.OnUpdateRedPoint));
			this.BindEvents();
			this._UpdateRedPoint();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000539C File Offset: 0x0000379C
		private void BindEvents()
		{
			if (this.iActiveConfigID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityConfigId && DataManager<FinancialPlanDataManager>.GetInstance().IsExistFinancialPlanActivity() && (this.iMainID == 0 || this.iMainID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityTemplateId))
			{
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinancialPlanRedPointTips, new ClientEventSystem.UIEventHandler(this.UpdateSpecialActiveRedPoint));
			}
			if (this.iActiveConfigID == 9380)
			{
				if (WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn) && (this.iMainID == 0 || (long)this.iMainID == 5400L))
				{
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.UpdateSpecialActiveRedPoint));
				}
				if (WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(WeekSignInType.ActivityWeekSignIn) && (this.iMainID == 0 || (long)this.iMainID == 5500L))
				{
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnActivityWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.UpdateSpecialActiveRedPoint));
				}
			}
			if (this.iActiveConfigID == 9380 && (this.iMainID == 0 || this.iMainID == 6000))
			{
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonthCardRewardRedPointReset, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardRedPointReset));
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000054E4 File Offset: 0x000038E4
		private void OnDestroy()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Remove(instance2.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Remove(instance3.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WelfActivityRedPoint, new ClientEventSystem.UIEventHandler(this.OnUpdateRedPoint));
			this.UnBindEvents();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000055AC File Offset: 0x000039AC
		private void UnBindEvents()
		{
			if (this.iActiveConfigID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityConfigId && DataManager<FinancialPlanDataManager>.GetInstance().IsExistFinancialPlanActivity() && (this.iMainID == 0 || this.iMainID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityTemplateId))
			{
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinancialPlanRedPointTips, new ClientEventSystem.UIEventHandler(this.UpdateSpecialActiveRedPoint));
			}
			if (this.iActiveConfigID == 9380)
			{
				if (WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn) && (this.iMainID == 0 || (long)this.iMainID == 5400L))
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.UpdateSpecialActiveRedPoint));
				}
				if (WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(WeekSignInType.ActivityWeekSignIn) && (this.iMainID == 0 || (long)this.iMainID == 5500L))
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnActivityWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.UpdateSpecialActiveRedPoint));
				}
			}
			if (this.iActiveConfigID == 9380 && (this.iMainID == 0 || this.iMainID == 6000))
			{
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonthCardRewardRedPointReset, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardRedPointReset));
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000056F4 File Offset: 0x00003AF4
		private void UpdateSpecialActiveRedPoint(UIEvent data = null)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000056FC File Offset: 0x00003AFC
		private void _OnMonthCardRewardRedPointReset(UIEvent uiEvent)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00005704 File Offset: 0x00003B04
		private void _UpdateRedPoint()
		{
			if (this.redPoints == null)
			{
				return;
			}
			bool flag = false;
			List<ActiveMainTable> type2Templates = DataManager<ActiveManager>.GetInstance().GetType2Templates(this.iActiveConfigID);
			if (type2Templates != null)
			{
				int num = 0;
				while (num < type2Templates.Count && !flag)
				{
					int id = type2Templates[num].ID;
					if (this.iMainID == 0 || this.iMainID == id)
					{
						if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.ContainsKey(id))
						{
							ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().ActiveDictionary[id];
							for (int i = 0; i < activeData.akChildItems.Count; i++)
							{
								if (DataManager<ActiveManager>.GetInstance().CheckChildRedPass(activeData.akChildItems[i]))
								{
									flag = true;
									break;
								}
							}
							if (ActiveManager.activityId[0] == activeData.iActiveID && DataManager<ActiveManager>.GetInstance().WelfareTABEnergyRedPointFlag)
							{
								flag = false;
							}
							else if (ActiveManager.activityId[1] == activeData.iActiveID && DataManager<ActiveManager>.GetInstance().WelfareTABRewardRedPointFlag)
							{
								flag = false;
							}
						}
					}
					num++;
				}
			}
			if (!flag)
			{
				flag = this.IsSpecialActiveHaveRedPoint();
			}
			for (int j = 0; j < this.redPoints.Length; j++)
			{
				this.redPoints[j].CustomActive(flag);
			}
			if (this.PlayAniObj != null)
			{
				DOTweenAnimation[] components = this.PlayAniObj.GetComponents<DOTweenAnimation>();
				for (int k = 0; k < components.Length; k++)
				{
					if (!(components[k] == null))
					{
						if (flag)
						{
							components[k].DORestart(false);
						}
						else
						{
							components[k].DOPause();
							components[k].gameObject.transform.localRotation = Quaternion.identity;
						}
					}
				}
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000058F8 File Offset: 0x00003CF8
		private bool IsSpecialActiveHaveRedPoint()
		{
			if (this.iActiveConfigID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityConfigId && DataManager<FinancialPlanDataManager>.GetInstance().IsExistFinancialPlanActivity() && (this.iMainID == 0 || this.iMainID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityTemplateId) && DataManager<FinancialPlanDataManager>.GetInstance().IsShowRedPoint())
			{
				return true;
			}
			if (this.iActiveConfigID == 9380)
			{
				if (WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn) && (this.iMainID == 0 || (long)this.iMainID == 5400L) && WeekSignInUtility.IsWeekSignInRedPointVisibleByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn))
				{
					return true;
				}
				if (WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(WeekSignInType.ActivityWeekSignIn) && (this.iMainID == 0 || (long)this.iMainID == 5500L) && WeekSignInUtility.IsWeekSignInRedPointVisibleByWeekSignInType(WeekSignInType.ActivityWeekSignIn))
				{
					return true;
				}
			}
			if (this.iActiveConfigID == 9380 && (this.iMainID == 0 || this.iMainID == 9380))
			{
				bool flag = DataManager<ActivityDataManager>.GetInstance().IsShowSignInRedPoint();
				if (flag)
				{
					return true;
				}
			}
			return this.iActiveConfigID == 9380 && (this.iMainID == 0 || this.iMainID == 6000) && DataManager<MonthCardRewardLockersDataManager>.GetInstance().IsRedPointShow();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00005A49 File Offset: 0x00003E49
		private void _OnAddMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._UpdateRedPoint();
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00005A67 File Offset: 0x00003E67
		private void _OnRemoveMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._UpdateRedPoint();
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00005A88 File Offset: 0x00003E88
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(data.activeItem.TemplateID);
			if (activeData != null && activeData.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._UpdateRedPoint();
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00005ACD File Offset: 0x00003ECD
		private void _OnUpdateMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._UpdateRedPoint();
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00005AEB File Offset: 0x00003EEB
		private void OnUpdateRedPoint(UIEvent uiEvent)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x04000017 RID: 23
		public GameObject[] redPoints;

		// Token: 0x04000018 RID: 24
		public int iActiveConfigID;

		// Token: 0x04000019 RID: 25
		public int iMainID;

		// Token: 0x0400001A RID: 26
		public GameObject PlayAniObj;
	}
}
