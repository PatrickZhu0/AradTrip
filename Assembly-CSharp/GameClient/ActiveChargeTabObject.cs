using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001372 RID: 4978
	public class ActiveChargeTabObject : CachedObject
	{
		// Token: 0x17001BAF RID: 7087
		// (get) Token: 0x0600C10C RID: 49420 RVA: 0x002DD236 File Offset: 0x002DB636
		public static ActiveChargeTabObject Selected
		{
			get
			{
				return ActiveChargeTabObject.ms_selected;
			}
		}

		// Token: 0x0600C10D RID: 49421 RVA: 0x002DD23D File Offset: 0x002DB63D
		public static void Clear()
		{
			ActiveChargeTabObject.ms_selected = null;
		}

		// Token: 0x0600C10E RID: 49422 RVA: 0x002DD248 File Offset: 0x002DB648
		private void _Initialize()
		{
			if (this.goLocal != null)
			{
				this.comActiveStatusControl = this.goLocal.GetComponent<ActiveStatus2GameObject>();
				if (this.comActiveStatusControl != null && this.activeData != null && this.activeData.mainItem != null)
				{
					this.comActiveStatusControl.ActiveConfigID = this.activeData.mainItem.ID;
				}
				if (this.activeData != null && this.activeData.mainItem != null)
				{
					this.m_akGoRedPoints = RedPointObject.Create(this.activeData.mainItem.RedPointPath, this.goLocal);
				}
				if (this.m_akGoRedPoints != null)
				{
					for (int i = 0; i < this.m_akGoRedPoints.Count; i++)
					{
						if (this.m_akGoRedPoints[i].Current != null)
						{
							this.m_akGoRedPoints[i].Current.CustomActive(false);
						}
					}
					if (this.activeData != null && this.activeData.mainItem != null)
					{
						for (int j = 0; j < this.m_akGoRedPoints.Count; j++)
						{
							if (this.m_akGoRedPoints[j].redBinder != null)
							{
								this.m_akGoRedPoints[j].redBinder.iMainId = this.activeData.mainItem.ID;
							}
						}
					}
				}
				if (this.activeData != null && this.activeData.mainItem != null && !string.IsNullOrEmpty(this.activeData.mainItem.TabInitDesc))
				{
					string[] array = this.activeData.mainItem.TabInitDesc.Split(new char[]
					{
						'\r',
						'\n'
					});
					for (int k = 0; k < array.Length; k++)
					{
						if (!string.IsNullOrEmpty(array[k]))
						{
							Match match = ActiveChargeTabObject.s_regex_tabinit.Match(array[k]);
							if (!string.IsNullOrEmpty(match.Groups[0].Value))
							{
								string value = match.Groups[2].Value;
								if (value != null)
								{
									if (!(value == "Text"))
									{
										if (value == "Image")
										{
											Image image = Utility.FindComponent<Image>(this.goLocal, match.Groups[1].Value, true);
											if (image != null)
											{
												ETCImageLoader.LoadSprite(ref image, match.Groups[3].Value, true);
												image.SetNativeSize();
											}
										}
									}
									else
									{
										Text text = Utility.FindComponent<Text>(this.goLocal, match.Groups[1].Value, true);
										if (text != null)
										{
											text.text = match.Groups[3].Value;
										}
									}
								}
							}
						}
					}
				}
			}
			this.InitSpecialTab();
		}

		// Token: 0x0600C10F RID: 49423 RVA: 0x002DD55C File Offset: 0x002DB95C
		public override void OnCreate(object[] param)
		{
			if (param.Length >= 1)
			{
				this.goParent = (param[0] as GameObject);
			}
			if (param.Length >= 2)
			{
				this.goPrefab = (param[1] as GameObject);
			}
			if (param.Length >= 3)
			{
				this.activeData = (param[2] as ActiveManager.ActiveData);
			}
			if (param.Length >= 4)
			{
				this.THIS = (param[3] as ActiveChargeFrame);
			}
			if (this.goLocal == null)
			{
				if (this.goPrefab != null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
				}
				if (this.goLocal != null && this.goParent != null)
				{
					Utility.AttachTo(this.goLocal, this.goParent, false);
				}
				if (this.goLocal != null)
				{
					this.m_kLabel = Utility.FindComponent<Text>(this.goLocal, "Image/Label", false);
					this.m_kMarkLabel = Utility.FindComponent<Text>(this.goLocal, "Checkmark/Label", false);
					this.m_kToggle = this.goLocal.GetComponent<Toggle>();
					if (this.m_kToggle != null)
					{
						this.m_kToggle.onValueChanged.RemoveAllListeners();
						this.m_kToggle.onValueChanged.AddListener(delegate(bool bValue)
						{
							if (this.m_kLabel != null)
							{
								this.m_kLabel.transform.parent.gameObject.CustomActive(!bValue);
							}
							if (this.m_kMarkLabel != null)
							{
								this.m_kMarkLabel.transform.parent.gameObject.CustomActive(bValue);
							}
							if (bValue)
							{
								this.OnSelected();
							}
						});
					}
				}
				this._Initialize();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivitySpecialRedPointNotify, new ClientEventSystem.UIEventHandler(this._OnSignalRedPoint));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivitySpecialRedPointNotify, new ClientEventSystem.UIEventHandler(this._OnSignalRedPoint));
			this.Enable();
			this._UpdateItem();
		}

		// Token: 0x0600C110 RID: 49424 RVA: 0x002DD704 File Offset: 0x002DBB04
		private void OnSelected()
		{
			ActiveChargeTabObject.ms_selected = this;
			this.THIS.SetTarget(this.activeData);
			if (this.activeData.iActiveID == ActiveManager.activityId[0])
			{
				DataManager<ActiveManager>.GetInstance().WelfareTABEnergyRedPointFlag = true;
			}
			if (this.activeData.iActiveID == ActiveManager.activityId[1])
			{
				DataManager<ActiveManager>.GetInstance().WelfareTABRewardRedPointFlag = true;
			}
			this._UpdateItem();
		}

		// Token: 0x0600C111 RID: 49425 RVA: 0x002DD774 File Offset: 0x002DBB74
		private void _OnSignalRedPoint(UIEvent uiEvent)
		{
			UIEventSpecialRedPointNotify uieventSpecialRedPointNotify = uiEvent as UIEventSpecialRedPointNotify;
			if (uieventSpecialRedPointNotify != null && uieventSpecialRedPointNotify.iMainId == this.activeData.iActiveID)
			{
				this.OnSignalRedPoint(this.activeData, uieventSpecialRedPointNotify.prefabKey);
			}
		}

		// Token: 0x0600C112 RID: 49426 RVA: 0x002DD7B8 File Offset: 0x002DBBB8
		private void OnSignalRedPoint(ActiveManager.ActiveData activeData, string prefabKey)
		{
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				ActiveTable activeItem = activeData.akChildItems[i].activeItem;
				if (activeItem.DoesWorkToRedPoint == 1 && activeItem.RedPointWorkMode == 1 && prefabKey == activeItem.PrefabKey)
				{
					DataManager<ActiveManager>.GetInstance().SignalRedPoint(activeData.akChildItems[i]);
				}
			}
		}

		// Token: 0x0600C113 RID: 49427 RVA: 0x002DD832 File Offset: 0x002DBC32
		public override void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivitySpecialRedPointNotify, new ClientEventSystem.UIEventHandler(this._OnSignalRedPoint));
			this.DestroySpecialTab();
		}

		// Token: 0x0600C114 RID: 49428 RVA: 0x002DD855 File Offset: 0x002DBC55
		public override void OnRecycle()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivitySpecialRedPointNotify, new ClientEventSystem.UIEventHandler(this._OnSignalRedPoint));
			this.Disable();
		}

		// Token: 0x0600C115 RID: 49429 RVA: 0x002DD878 File Offset: 0x002DBC78
		public override void Enable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(true);
			}
		}

		// Token: 0x0600C116 RID: 49430 RVA: 0x002DD897 File Offset: 0x002DBC97
		public override void Disable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(false);
			}
		}

		// Token: 0x0600C117 RID: 49431 RVA: 0x002DD8B6 File Offset: 0x002DBCB6
		public override void OnDecycle(object[] param)
		{
			this.OnCreate(param);
		}

		// Token: 0x0600C118 RID: 49432 RVA: 0x002DD8BF File Offset: 0x002DBCBF
		public override void OnRefresh(object[] param)
		{
			this.OnCreate(param);
		}

		// Token: 0x0600C119 RID: 49433 RVA: 0x002DD8C8 File Offset: 0x002DBCC8
		public override bool NeedFilter(object[] param)
		{
			return false;
		}

		// Token: 0x0600C11A RID: 49434 RVA: 0x002DD8CC File Offset: 0x002DBCCC
		private void _UpdateItem()
		{
			if (!string.IsNullOrEmpty(this.activeData.mainItem.Name))
			{
				if (this.m_kLabel != null)
				{
					this.m_kLabel.text = this.activeData.mainItem.Name;
				}
				if (this.m_kMarkLabel != null)
				{
					this.m_kMarkLabel.text = this.activeData.mainItem.Name;
				}
			}
			if (this.m_akGoRedPoints != null)
			{
				for (int i = 0; i < this.m_akGoRedPoints.Count; i++)
				{
					if ((this.activeData.iActiveID == ActiveManager.activityId[0] && DataManager<ActiveManager>.GetInstance().WelfareTABEnergyRedPointFlag) || (this.activeData.iActiveID == ActiveManager.activityId[1] && DataManager<ActiveManager>.GetInstance().WelfareTABRewardRedPointFlag))
					{
						this.m_akGoRedPoints[i].Current.CustomActive(false);
					}
					else
					{
						bool flag = DataManager<ActiveManager>.GetInstance().CheckHasFinishedChildItem(this.activeData, this.m_akGoRedPoints[i].Keys);
						if (this.activeData.iActiveID == ActiveManager.activityId[0] && !flag)
						{
							DataManager<ActiveManager>.GetInstance().WelfareTABEnergyRedPointFlag = true;
						}
						if (this.activeData.iActiveID == ActiveManager.activityId[1] && !flag)
						{
							DataManager<ActiveManager>.GetInstance().WelfareTABRewardRedPointFlag = true;
						}
						this.m_akGoRedPoints[i].Current.CustomActive(flag);
					}
				}
			}
			if (this.comActiveStatusControl != null)
			{
				this.comActiveStatusControl.ActiveConfigID = this.activeData.mainItem.ID;
			}
			this.DealWithSpecialTabRedPoint(null);
		}

		// Token: 0x0600C11B RID: 49435 RVA: 0x002DDA98 File Offset: 0x002DBE98
		private void DestroySpecialTab()
		{
			if (this.activeData != null)
			{
				if (this.activeData.iActiveID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityTemplateId)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinancialPlanRedPointTips, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if (this.activeData.iActiveID == 8700)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DailyChargeRedPointChanged, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if ((long)this.activeData.iActiveID == 5400L)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if ((long)this.activeData.iActiveID == 5500L)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnActivityWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if (this.activeData.iActiveID == 6000)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonthCardRewardRedPointReset, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if (this.activeData.iActiveID == 3000)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonthlySignInRedPointReset, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if (this.activeData.iActiveID == DataManager<WarriorRecruitDataManager>.GetInstance().warriorRecruitActiveID)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WarriorRecruitReceiveRewardSuccessed, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WarriorRecruitQueryTaskSuccessed, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
					UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
			}
		}

		// Token: 0x0600C11C RID: 49436 RVA: 0x002DDC44 File Offset: 0x002DC044
		private void InitSpecialTab()
		{
			if (this.activeData != null)
			{
				if (this.activeData.iActiveID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityTemplateId)
				{
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinancialPlanRedPointTips, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if (this.activeData.iActiveID == 8700)
				{
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DailyChargeRedPointChanged, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if ((long)this.activeData.iActiveID == 5400L)
				{
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if ((long)this.activeData.iActiveID == 5500L)
				{
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnActivityWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if (this.activeData.iActiveID == 6000)
				{
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonthCardRewardRedPointReset, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if (this.activeData.iActiveID == 3000)
				{
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonthlySignInRedPointReset, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
				if (this.activeData.iActiveID == DataManager<WarriorRecruitDataManager>.GetInstance().warriorRecruitActiveID)
				{
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WarriorRecruitReceiveRewardSuccessed, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WarriorRecruitQueryTaskSuccessed, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
					UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.DealWithSpecialTabRedPoint));
				}
			}
		}

		// Token: 0x0600C11D RID: 49437 RVA: 0x002DDDF0 File Offset: 0x002DC1F0
		private void DealWithSpecialTabRedPoint(UIEvent data = null)
		{
			this.OnDealWithSpecialTab();
		}

		// Token: 0x0600C11E RID: 49438 RVA: 0x002DDDF8 File Offset: 0x002DC1F8
		private void OnDealWithSpecialTab()
		{
			if (this.activeData != null)
			{
				if (this.activeData.iActiveID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityTemplateId)
				{
					if (this.m_akGoRedPoints != null)
					{
						for (int i = 0; i < this.m_akGoRedPoints.Count; i++)
						{
							bool bActive = DataManager<FinancialPlanDataManager>.GetInstance().IsShowRedPoint();
							this.m_akGoRedPoints[i].Current.CustomActive(bActive);
						}
					}
				}
				else if (this.activeData.iActiveID == 8700)
				{
					if (this.m_akGoRedPoints != null)
					{
						for (int j = 0; j < this.m_akGoRedPoints.Count; j++)
						{
							bool bActive2 = DataManager<DailyChargeRaffleDataManager>.GetInstance().IsRedPointShow();
							this.m_akGoRedPoints[j].Current.CustomActive(bActive2);
						}
					}
				}
				else if ((long)this.activeData.iActiveID == 5500L)
				{
					if (this.m_akGoRedPoints != null)
					{
						for (int k = 0; k < this.m_akGoRedPoints.Count; k++)
						{
							bool bActive3 = WeekSignInUtility.IsWeekSignInRedPointVisibleByWeekSignInType(WeekSignInType.ActivityWeekSignIn);
							this.m_akGoRedPoints[k].Current.CustomActive(bActive3);
						}
					}
				}
				else if ((long)this.activeData.iActiveID == 5400L)
				{
					if (this.m_akGoRedPoints != null)
					{
						for (int l = 0; l < this.m_akGoRedPoints.Count; l++)
						{
							bool bActive4 = WeekSignInUtility.IsWeekSignInRedPointVisibleByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn);
							this.m_akGoRedPoints[l].Current.CustomActive(bActive4);
						}
					}
				}
				else if (this.activeData.iActiveID == 6000)
				{
					if (this.m_akGoRedPoints != null)
					{
						for (int m = 0; m < this.m_akGoRedPoints.Count; m++)
						{
							bool flag = DataManager<ActiveManager>.GetInstance().CheckHasFinishedChildItem(this.activeData, this.m_akGoRedPoints[m].Keys);
							bool bActive5 = DataManager<MonthCardRewardLockersDataManager>.GetInstance().IsRedPointShow() || flag;
							this.m_akGoRedPoints[m].Current.CustomActive(bActive5);
						}
					}
				}
				else if (this.activeData.iActiveID == 3000)
				{
					if (this.m_akGoRedPoints != null)
					{
						bool bActive6 = DataManager<ActivityDataManager>.GetInstance().IsShowSignInRedPoint();
						for (int n = 0; n < this.m_akGoRedPoints.Count; n++)
						{
							this.m_akGoRedPoints[n].Current.CustomActive(bActive6);
						}
					}
				}
				else if (this.activeData.iActiveID == DataManager<WarriorRecruitDataManager>.GetInstance().warriorRecruitActiveID && this.m_akGoRedPoints != null)
				{
					bool bActive7 = DataManager<WarriorRecruitDataManager>.GetInstance().IsRedPointShow();
					for (int num = 0; num < this.m_akGoRedPoints.Count; num++)
					{
						RedPointObject redPointObject = this.m_akGoRedPoints[num];
						if (redPointObject != null)
						{
							if (!(redPointObject.Current == null))
							{
								redPointObject.Current.CustomActive(bActive7);
							}
						}
					}
				}
			}
		}

		// Token: 0x04006D27 RID: 27943
		protected GameObject goLocal;

		// Token: 0x04006D28 RID: 27944
		protected GameObject goParent;

		// Token: 0x04006D29 RID: 27945
		protected GameObject goPrefab;

		// Token: 0x04006D2A RID: 27946
		protected ActiveChargeFrame THIS;

		// Token: 0x04006D2B RID: 27947
		protected ActiveManager.ActiveData activeData;

		// Token: 0x04006D2C RID: 27948
		protected ActiveStatus2GameObject comActiveStatusControl;

		// Token: 0x04006D2D RID: 27949
		private Text m_kLabel;

		// Token: 0x04006D2E RID: 27950
		private Text m_kMarkLabel;

		// Token: 0x04006D2F RID: 27951
		public Toggle m_kToggle;

		// Token: 0x04006D30 RID: 27952
		private static ActiveChargeTabObject ms_selected;

		// Token: 0x04006D31 RID: 27953
		public static Regex s_regex_tabinit = new Regex("<path=(.+) type=(\\w+) value=(.+)>", RegexOptions.Singleline);

		// Token: 0x04006D32 RID: 27954
		private List<RedPointObject> m_akGoRedPoints;
	}
}
