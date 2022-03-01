using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001369 RID: 4969
	public class ActiveChargeFrame : ClientFrame
	{
		// Token: 0x0600C0DE RID: 49374 RVA: 0x002DB92C File Offset: 0x002D9D2C
		public static void OpenLinkFrame(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			string[] array = value.Split(new char[]
			{
				'\r',
				'\n'
			});
			if (array.Length != 2)
			{
				array = value.Split(new char[]
				{
					'|'
				});
			}
			if (array.Length != 2)
			{
				return;
			}
			int iConfigID = 0;
			int iLinkTemplateID = 0;
			if (!int.TryParse(array[0], out iConfigID) || !int.TryParse(array[1], out iLinkTemplateID))
			{
				return;
			}
			DataManager<ActiveManager>.GetInstance().OpenActiveFrame(iConfigID, iLinkTemplateID);
		}

		// Token: 0x0600C0DF RID: 49375 RVA: 0x002DB9B0 File Offset: 0x002D9DB0
		public override string GetPrefabPath()
		{
			ActiveManager.ActiveFrameConfig activeFrameConfig = DataManager<ActiveManager>.GetInstance().PopAcitveFrameConfig();
			if (activeFrameConfig != null)
			{
				return activeFrameConfig.prefabpath;
			}
			return string.Empty;
		}

		// Token: 0x0600C0E0 RID: 49376 RVA: 0x002DB9DC File Offset: 0x002D9DDC
		private ActiveSpecialFrame _GetSpecialFrame(int iActiveID)
		{
			return this.m_akChildActiveFrames.Find((ActiveSpecialFrame x) => x.ActiveID == iActiveID);
		}

		// Token: 0x0600C0E1 RID: 49377 RVA: 0x002DBA10 File Offset: 0x002D9E10
		private ActiveSpecialFrame _TryAddSpecialFrame(int iActiveID)
		{
			ActiveSpecialFrameInfo activeSpecialFrameInfo = null;
			for (int i = 0; i < ActiveChargeFrame.ms_activeSpecialFrameDic.Length; i++)
			{
				if (ActiveChargeFrame.ms_activeSpecialFrameDic[i] != null && ActiveChargeFrame.ms_activeSpecialFrameDic[i].id == iActiveID)
				{
					activeSpecialFrameInfo = ActiveChargeFrame.ms_activeSpecialFrameDic[i];
					break;
				}
			}
			if (activeSpecialFrameInfo == null)
			{
				return null;
			}
			ActiveSpecialFrame activeSpecialFrame = this.m_akChildActiveFrames.Find((ActiveSpecialFrame x) => x.ActiveID == iActiveID);
			if (activeSpecialFrame != null)
			{
				return activeSpecialFrame;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>(iActiveID, string.Empty, string.Empty) == null)
			{
				return null;
			}
			if (!DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(iActiveID))
			{
				return null;
			}
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(iActiveID);
			if (activeData == null)
			{
				return null;
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			activeSpecialFrame = (executingAssembly.CreateInstance(activeSpecialFrameInfo.type.FullName) as ActiveSpecialFrame);
			if (activeSpecialFrame == null)
			{
				return null;
			}
			activeSpecialFrame.Intialize(this, this.frame, iActiveID);
			activeSpecialFrame.data = activeData;
			activeSpecialFrame.activityInfo = activeData.mainInfo;
			this.m_akChildActiveFrames.Add(activeSpecialFrame);
			return activeSpecialFrame;
		}

		// Token: 0x0600C0E2 RID: 49378 RVA: 0x002DBB54 File Offset: 0x002D9F54
		private void _TryCloseSpecialFrame(int iActiveID)
		{
			ActiveSpecialFrame activeSpecialFrame = this.m_akChildActiveFrames.Find((ActiveSpecialFrame x) => x.data.iActiveID == iActiveID);
			if (activeSpecialFrame != null)
			{
				activeSpecialFrame.OnDestroy();
				activeSpecialFrame.UnInitialize();
				this.m_akChildActiveFrames.Remove(activeSpecialFrame);
			}
		}

		// Token: 0x0600C0E3 RID: 49379 RVA: 0x002DBBA8 File Offset: 0x002D9FA8
		private void _CloseChildActive()
		{
			for (int i = 0; i < this.m_akChildActiveFrames.Count; i++)
			{
				if (this.m_akChildActiveFrames[i] != null)
				{
					this.m_akChildActiveFrames[i].OnDestroy();
					this.m_akChildActiveFrames[i] = null;
				}
			}
			this.m_akChildActiveFrames.Clear();
		}

		// Token: 0x0600C0E4 RID: 49380 RVA: 0x002DBC0C File Offset: 0x002DA00C
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as ActiveManager.ActiveFrameConfig);
			this.m_akActivities.Clear();
			ActiveItemObject.Clear();
			ActiveChargeTabObject.Clear();
			ActiveObject.Clear();
			this._InitActiveObjects();
			this._InitTabs();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this.OnActivityUpdate));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Combine(instance2.onAddMainActivity, new ActiveManager.OnAddMainActivity(this.OnAddMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Combine(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this.OnUpdateMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Combine(instance4.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this.OnRemoveMainActivity));
			ActiveManager.VarBinder varBinder = new ActiveManager.VarBinder();
			varBinder.Analysis();
			ActiveChargeFrame.activeChargeFrame = this;
			this.BindServerSwitchEvent();
			DataManager<ActivityDataManager>.GetInstance().SendMonthlySignInQuery();
		}

		// Token: 0x0600C0E5 RID: 49381 RVA: 0x002DBD0B File Offset: 0x002DA10B
		public override bool RemoveRefOnClose()
		{
			return true;
		}

		// Token: 0x0600C0E6 RID: 49382 RVA: 0x002DBD10 File Offset: 0x002DA110
		protected override void _OnCloseFrame()
		{
			this._CloseChildActive();
			ActiveChargeTabObject.Clear();
			ActiveItemObject.Clear();
			ActiveObject.Clear();
			this.m_akTabObjects.DestroyAllObjects();
			foreach (KeyValuePair<int, Dictionary<string, CachedObjectDicManager<int, ActiveItemObject>>> keyValuePair in this.m_akActivities)
			{
				foreach (KeyValuePair<string, CachedObjectDicManager<int, ActiveItemObject>> keyValuePair2 in keyValuePair.Value)
				{
					CachedObjectDicManager<int, ActiveItemObject> value = keyValuePair2.Value;
					value.DestroyAllObjects();
				}
			}
			this.m_akActivities.Clear();
			this.m_akActiveObjects.DestroyAllObjects();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this.OnActivityUpdate));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance2.onAddMainActivity, new ActiveManager.OnAddMainActivity(this.OnAddMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Remove(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this.OnUpdateMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Remove(instance4.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this.OnRemoveMainActivity));
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WelfareFrameClose, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WelfActivityRedPoint, null, null, null, null);
			ActiveChargeFrame.activeChargeFrame = null;
			this.UnBindServerSwitchEvent();
		}

		// Token: 0x0600C0E7 RID: 49383 RVA: 0x002DBE78 File Offset: 0x002DA278
		private void OnAddMainActivity(ActiveManager.ActiveData data)
		{
			if (data != null && data.mainItem.ActiveTypeID == this.m_kData.iConfigID)
			{
				if (!this.m_akTabObjects.HasObject(data.iActiveID))
				{
					this.m_akTabObjects.Create(data.iActiveID, new object[]
					{
						this.m_goTabParent,
						this.m_goTabPrefab,
						data,
						this
					});
				}
				else
				{
					Logger.LogError("OnAddMainActivity add repeated!");
				}
			}
		}

		// Token: 0x0600C0E8 RID: 49384 RVA: 0x002DBF00 File Offset: 0x002DA300
		private void OnUpdateMainActivity(ActiveManager.ActiveData data)
		{
			if (data != null && data.mainItem.ActiveTypeID == this.m_kData.iConfigID)
			{
				if (this.m_akTabObjects.HasObject(data.iActiveID))
				{
					this.m_akTabObjects.RefreshObject(data.iActiveID, new object[]
					{
						this.m_goTabParent,
						this.m_goTabPrefab,
						data,
						this
					});
					ActiveChargeTabObject @object = this.m_akTabObjects.GetObject(data.iActiveID);
					if (@object.m_kToggle.isOn && this.m_akActiveObjects.HasObject(data.iActiveID))
					{
						this.m_akActiveObjects.RefreshObject(data.iActiveID, null);
					}
				}
				else
				{
					Logger.LogError("OnAddMainActivity add repeated!");
				}
				ActiveSpecialFrame activeSpecialFrame = this._GetSpecialFrame(data.iActiveID);
				if (activeSpecialFrame != null)
				{
					activeSpecialFrame.data = data;
					activeSpecialFrame.activityInfo = data.mainInfo;
					activeSpecialFrame.OnUpdate();
				}
			}
		}

		// Token: 0x0600C0E9 RID: 49385 RVA: 0x002DBFFC File Offset: 0x002DA3FC
		private void OnRemoveMainActivity(ActiveManager.ActiveData activeData)
		{
			if (this.m_akActiveObjects.HasObject(activeData.iActiveID))
			{
				GameObject gameObject = Utility.FindChild(this.m_goActivitiesParent, activeData.mainItem.templateName);
				if (gameObject != null)
				{
					ActiveObject @object = this.m_akActiveObjects.GetObject(activeData.iActiveID);
					if (this.m_akActivities.ContainsKey(activeData.iActiveID))
					{
						this.m_akActivities.Remove(activeData.iActiveID);
					}
				}
				this._TryCloseSpecialFrame(activeData.iActiveID);
				this.m_akActiveObjects.DestroyObject(activeData.iActiveID);
			}
			if (this.m_akTabObjects.HasObject(activeData.iActiveID))
			{
				ActiveChargeTabObject object2 = this.m_akTabObjects.GetObject(activeData.iActiveID);
				if (object2 != null && object2 == ActiveChargeTabObject.Selected)
				{
					ActiveChargeTabObject.Clear();
				}
				this.m_akTabObjects.RecycleObject(activeData.iActiveID);
				this._SetDefaultTabs();
			}
		}

		// Token: 0x0600C0EA RID: 49386 RVA: 0x002DC0F0 File Offset: 0x002DA4F0
		private void OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			if (data != null)
			{
				ActiveTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveTable>(data.ID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ActiveManager.ActiveData activeData = null;
					if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.TryGetValue(tableItem.TemplateID, out activeData))
					{
						if (this.m_akTabObjects.HasObject(activeData.iActiveID))
						{
							this.m_akTabObjects.RefreshObject(activeData.iActiveID, new object[]
							{
								this.m_goTabParent,
								this.m_goTabPrefab,
								activeData,
								this
							});
						}
						if (this.m_akActiveObjects.HasObject(tableItem.TemplateID))
						{
							this.m_akActiveObjects.RefreshObject(tableItem.TemplateID, null);
						}
						Dictionary<string, CachedObjectDicManager<int, ActiveItemObject>> dictionary = null;
						if (this.m_akActivities.TryGetValue(activeData.iActiveID, out dictionary))
						{
							foreach (KeyValuePair<string, CachedObjectDicManager<int, ActiveItemObject>> keyValuePair in dictionary)
							{
								keyValuePair.Value.RefreshObject(tableItem.ID, null);
								Dictionary<string, CachedObjectDicManager<int, ActiveItemObject>>.Enumerator enumerator;
								KeyValuePair<string, CachedObjectDicManager<int, ActiveItemObject>> keyValuePair2 = enumerator.Current;
								this._Sort(keyValuePair2.Value);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C0EB RID: 49387 RVA: 0x002DC218 File Offset: 0x002DA618
		private void _Sort(CachedObjectDicManager<int, ActiveItemObject> tables)
		{
			List<ActiveItemObject> list = tables.ActiveObjects.Values.ToList<ActiveItemObject>();
			List<ActiveItemObject> list2 = list;
			if (ActiveChargeFrame.<>f__mg$cache0 == null)
			{
				ActiveChargeFrame.<>f__mg$cache0 = new Comparison<ActiveItemObject>(ActiveItemObject.Cmp);
			}
			list2.Sort(ActiveChargeFrame.<>f__mg$cache0);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].SetAsLastSibling();
			}
		}

		// Token: 0x0600C0EC RID: 49388 RVA: 0x002DC27C File Offset: 0x002DA67C
		private int _SortActivities(ActiveManager.ActiveData left, ActiveManager.ActiveData right)
		{
			if (left.iActiveSortID != right.iActiveSortID)
			{
				return left.iActiveSortID - right.iActiveSortID;
			}
			return left.iActiveID - right.iActiveID;
		}

		// Token: 0x0600C0ED RID: 49389 RVA: 0x002DC2AC File Offset: 0x002DA6AC
		private void _InitTabs()
		{
			ActiveChargeFrame.<_InitTabs>c__AnonStorey4 <_InitTabs>c__AnonStorey = new ActiveChargeFrame.<_InitTabs>c__AnonStorey4();
			if (this.m_kData == null || this.m_kData.templates.Count <= 0)
			{
				Logger.LogErrorFormat("data error!!!", new object[0]);
				return;
			}
			string[] array = this.m_kData.templates[0].ActiveFrameTabPath.Split(new char[]
			{
				'\r',
				'\n'
			});
			if (array.Length != 2)
			{
				Logger.LogErrorFormat("data error!!!", new object[0]);
				return;
			}
			this.m_akTabObjects.Clear();
			this.m_goTabParent = Utility.FindChild(array[0], this.frame);
			if (this.m_goTabParent == null)
			{
				this.m_goTabParent = Utility.FindThatChild(array[0], this.frame, false);
			}
			this.m_goTabPrefab = Utility.FindChild(array[1], this.frame);
			if (this.m_goTabPrefab == null)
			{
				this.m_goTabPrefab = Utility.FindThatChild("tab", this.frame, false);
			}
			this.m_goTabPrefab.CustomActive(false);
			this.m_goActivitiesParent = Utility.FindChild(this.frame, "Activities");
			for (int j = 0; j < this.m_goActivitiesParent.transform.childCount; j++)
			{
				this.m_goActivitiesParent.transform.GetChild(j).gameObject.CustomActive(false);
			}
			this.UpdateOpActivity();
			<_InitTabs>c__AnonStorey.activities = DataManager<ActiveManager>.GetInstance().ActiveDictionary.Values.ToList<ActiveManager.ActiveData>();
			this.DealWithSpecialActivity();
			<_InitTabs>c__AnonStorey.activities.Sort(new Comparison<ActiveManager.ActiveData>(this._SortActivities));
			int i;
			for (i = 0; i < <_InitTabs>c__AnonStorey.activities.Count; i++)
			{
				ActiveMainTable activeMainTable = this.m_kData.templates.Find((ActiveMainTable x) => x.ID == <_InitTabs>c__AnonStorey.activities[i].iActiveID);
				if (activeMainTable != null && !this.IsActiveSwitchOff(<_InitTabs>c__AnonStorey.activities[i].iActiveID))
				{
					if (<_InitTabs>c__AnonStorey.activities[i].iActiveID == 7800)
					{
						string[] array2 = this.m_kData.templates[this.m_kData.templates.Count - 1].ActiveFrameTabPath.Split(new char[]
						{
							'\r',
							'\n'
						});
						if (array2.Length != 2)
						{
							Logger.LogErrorFormat("data error!!!", new object[0]);
							return;
						}
						this.m_goTabParent = Utility.FindChild(array2[0], this.frame);
						if (this.m_goTabParent == null)
						{
							this.m_goTabParent = Utility.FindThatChild(array2[0], this.frame, false);
						}
						this.m_goTabPrefab = Utility.FindChild(array2[1], this.frame);
						if (this.m_goTabPrefab == null)
						{
							this.m_goTabPrefab = Utility.FindThatChild("rechargetab", this.frame, false);
						}
						this.m_goTabPrefab.CustomActive(false);
					}
					this.m_akTabObjects.Create(<_InitTabs>c__AnonStorey.activities[i].iActiveID, new object[]
					{
						this.m_goTabParent,
						this.m_goTabPrefab,
						<_InitTabs>c__AnonStorey.activities[i],
						this
					});
				}
			}
			this._SetDefaultTabs();
		}

		// Token: 0x0600C0EE RID: 49390 RVA: 0x002DC630 File Offset: 0x002DAA30
		private void _SetDefaultTabs()
		{
			if (ActiveChargeTabObject.Selected == null && this.m_akTabObjects.ActiveObjects.Count > 0)
			{
				if (this.m_kData != null && this.m_akTabObjects.HasObject(this.m_kData.iLinkTemplateID))
				{
					ActiveChargeTabObject @object = this.m_akTabObjects.GetObject(this.m_kData.iLinkTemplateID);
					if (@object != null && @object.m_kToggle != null)
					{
						@object.m_kToggle.isOn = true;
					}
					if (this.m_kData.iLinkTemplateID == 8800 && this.tabScrollRect != null)
					{
						this.tabScrollRect.verticalNormalizedPosition = 0f;
					}
				}
				else
				{
					List<ActiveChargeTabObject> list = this.m_akTabObjects.ActiveObjects.Values.ToList<ActiveChargeTabObject>();
					if (list != null && list.Count > 0)
					{
						ActiveChargeTabObject activeChargeTabObject = list[0];
						if (activeChargeTabObject != null && activeChargeTabObject.m_kToggle != null)
						{
							activeChargeTabObject.m_kToggle.isOn = true;
						}
					}
				}
			}
		}

		// Token: 0x0600C0EF RID: 49391 RVA: 0x002DC74C File Offset: 0x002DAB4C
		private IEnumerator _AnsyCreatePrefabs(ActiveManager.ActiveData activeData, Dictionary<string, CachedObjectDicManager<int, ActiveItemObject>> outValue, GameObject goCurrent)
		{
			if (activeData.prefabs != null)
			{
				int i = 0;
				foreach (KeyValuePair<string, ActiveManager.ActivityPrefab> keyValuePair in activeData.prefabs)
				{
					ActiveManager.ActivityPrefab current = keyValuePair.Value;
					CachedObjectDicManager<int, ActiveItemObject> activePrefabObject = null;
					if (!outValue.TryGetValue(current.key, out activePrefabObject))
					{
						activePrefabObject = new CachedObjectDicManager<int, ActiveItemObject>();
						activePrefabObject.Clear();
						outValue.Add(current.key, activePrefabObject);
					}
					GameObject goParent = Utility.FindChild(goCurrent, current.parent);
					GameObject goCurrentPrefab = Utility.FindChild(goParent, current.local);
					goCurrentPrefab.CustomActive(false);
					List<ActiveManager.ActivityData> akChildItems = activeData.akChildItems;
					if (ActiveChargeFrame.<>f__mg$cache1 == null)
					{
						ActiveChargeFrame.<>f__mg$cache1 = new Comparison<ActiveManager.ActivityData>(ActiveItemObject.Cmp);
					}
					akChildItems.Sort(ActiveChargeFrame.<>f__mg$cache1);
					for (int j = 0; j < activeData.akChildItems.Count; j++)
					{
						ActiveManager.ActivityData childItem = activeData.akChildItems[j];
						if (childItem.activeItem.PrefabKey == current.key)
						{
							activePrefabObject.Create(childItem.ID, new object[]
							{
								goParent,
								goCurrentPrefab,
								childItem,
								activeData,
								current.key,
								this
							});
							i++;
							yield return Yielders.EndOfFrame;
						}
					}
				}
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600C0F0 RID: 49392 RVA: 0x002DC77C File Offset: 0x002DAB7C
		public void SetTarget(ActiveManager.ActiveData activeData)
		{
			try
			{
				if (activeData.iActiveID == 8700)
				{
					Utility.DoStartFrameOperation("ActiveFuliFrame", "DailyPackageToggle");
				}
				else if (activeData.iActiveID == 8600)
				{
					Utility.DoStartFrameOperation("ActiveFuliFrame", "ManagingMoneyToggle");
				}
				else if (activeData.iActiveID >= 7100 && activeData.iActiveID <= 7700)
				{
					Utility.DoStartFrameOperation("ActiveFuliFrame", string.Format("7Days{0}", activeData.iActiveID));
				}
				GameObject gameObject = null;
				GameObject gameObject2 = null;
				if (!this.m_akActiveObjects.HasObject(activeData.iActiveID))
				{
					if (activeData.mainItem.bUseTemplate == 1)
					{
						gameObject = Utility.FindChild(this.frame, activeData.mainItem.templateName);
						if (gameObject != null)
						{
							UIPrefabWrapper component = gameObject.GetComponent<UIPrefabWrapper>();
							if (component != null)
							{
								GameObject gameObject3 = component.LoadUIPrefab();
								if (gameObject3 != null)
								{
									gameObject3.transform.SetParent(gameObject.transform.parent, false);
									Object.Destroy(gameObject);
									gameObject = gameObject3;
									ActivityChargeBaseView component2 = gameObject3.GetComponent<ActivityChargeBaseView>();
									if (component2 != null)
									{
										component2.InitView(component.IntParam);
									}
								}
							}
						}
					}
					else
					{
						gameObject2 = Utility.FindChild(this.frame, activeData.mainItem.templateName);
						gameObject2.CustomActive(false);
					}
					this.m_akActiveObjects.Create(activeData.iActiveID, new object[]
					{
						gameObject,
						gameObject2,
						activeData
					});
					ActiveSpecialFrame activeSpecialFrame = this._TryAddSpecialFrame(activeData.iActiveID);
					if (activeSpecialFrame != null)
					{
						activeSpecialFrame.OnCreate();
					}
					if (activeData.iActiveID != 3000)
					{
						GameObject gameObject4 = this.m_akActiveObjects.GetObject(activeData.iActiveID).gameObject;
						if (gameObject4 != null)
						{
							string arg = string.Empty;
							string[] array = activeData.mainItem.templateName.Split(new char[]
							{
								'/'
							});
							if (array.Length > 0)
							{
								arg = array[array.Length - 1];
							}
							gameObject4.name = arg + activeData.iActiveID;
							Dictionary<string, CachedObjectDicManager<int, ActiveItemObject>> dictionary = null;
							if (!this.m_akActivities.TryGetValue(activeData.iActiveID, out dictionary))
							{
								dictionary = new Dictionary<string, CachedObjectDicManager<int, ActiveItemObject>>();
								this.m_akActivities.Add(activeData.iActiveID, dictionary);
								base.StartCoroutine(this._AnsyCreatePrefabs(activeData, dictionary, gameObject4));
							}
						}
					}
				}
				if (this.m_akActiveObjects.HasObject(activeData.iActiveID))
				{
					this.m_akActiveObjects.Filter(new object[]
					{
						activeData.iActiveID
					});
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600C0F1 RID: 49393 RVA: 0x002DCA60 File Offset: 0x002DAE60
		private void _InitActiveObjects()
		{
			this.m_akActiveObjects.Clear();
		}

		// Token: 0x0600C0F2 RID: 49394 RVA: 0x002DCA70 File Offset: 0x002DAE70
		private void DealWithSpecialActivity()
		{
			List<ActiveManager.ActiveData> list = DataManager<ActiveManager>.GetInstance().ActiveDictionary.Values.ToList<ActiveManager.ActiveData>();
			foreach (ActiveManager.ActiveData activeData in list)
			{
				if (activeData.iActiveID == DataManager<FinancialPlanDataManager>.GetInstance().ActivityTemplateId)
				{
					if (DataManager<FinancialPlanDataManager>.GetInstance().IsAlreadyReceivedAllReward())
					{
						activeData.iActiveSortID = 100;
					}
				}
				else if (activeData.iActiveID == 8800 && DataManager<WarriorRecruitDataManager>.GetInstance().CheckWarriorRecruitActiveIsOpen())
				{
					activeData.iActiveSortID = 101;
				}
			}
		}

		// Token: 0x0600C0F3 RID: 49395 RVA: 0x002DCB30 File Offset: 0x002DAF30
		private void UpdateOpActivity()
		{
			if (WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn))
			{
				DataManager<ActiveManager>.GetInstance().AddOneActiveData(5400);
			}
			else
			{
				DataManager<ActiveManager>.GetInstance().RemoveOneActiveData(5400);
			}
			if (WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(WeekSignInType.ActivityWeekSignIn))
			{
				DataManager<ActiveManager>.GetInstance().AddOneActiveData(5500);
			}
			else
			{
				DataManager<ActiveManager>.GetInstance().RemoveOneActiveData(5500);
			}
			DataManager<ActiveManager>.GetInstance().AddOneActiveData(3000);
			if (DataManager<WarriorRecruitDataManager>.GetInstance().CheckWarriorRecruitActiveIsOpen())
			{
				DataManager<ActiveManager>.GetInstance().AddOneActiveData(8800);
			}
		}

		// Token: 0x0600C0F4 RID: 49396 RVA: 0x002DCBC6 File Offset: 0x002DAFC6
		[UIEventHandle("Shopbg/tittlebg1/close")]
		private void OnFunction()
		{
			this.frameMgr.CloseFrame<ActiveChargeFrame>(this, false);
		}

		// Token: 0x0600C0F5 RID: 49397 RVA: 0x002DCBD5 File Offset: 0x002DAFD5
		public static void CloseMe()
		{
			if (ActiveChargeFrame.activeChargeFrame != null)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame(ActiveChargeFrame.activeChargeFrame.GetFrameName());
				ActiveChargeFrame.activeChargeFrame = null;
			}
		}

		// Token: 0x0600C0F6 RID: 49398 RVA: 0x002DCBFC File Offset: 0x002DAFFC
		private bool IsActiveSwitchOff(int activeId)
		{
			bool result = false;
			if (activeId == 8700)
			{
				return DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVEICE_DAY_CHARGE_WELFARE);
			}
			return result;
		}

		// Token: 0x0600C0F7 RID: 49399 RVA: 0x002DCC26 File Offset: 0x002DB026
		private void BindServerSwitchEvent()
		{
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVEICE_DAY_CHARGE_WELFARE, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnActiveSwitch));
		}

		// Token: 0x0600C0F8 RID: 49400 RVA: 0x002DCC40 File Offset: 0x002DB040
		private void UnBindServerSwitchEvent()
		{
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVEICE_DAY_CHARGE_WELFARE, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnActiveSwitch));
		}

		// Token: 0x0600C0F9 RID: 49401 RVA: 0x002DCC5C File Offset: 0x002DB05C
		private void _OnActiveSwitch(ServerSceneFuncSwitch ssfs)
		{
			int activeId = 8700;
			if (ssfs.sType == ServiceType.SERVEICE_DAY_CHARGE_WELFARE && !ssfs.sIsOpen)
			{
				this.OnRemoveActiveTab(activeId);
			}
		}

		// Token: 0x0600C0FA RID: 49402 RVA: 0x002DCC90 File Offset: 0x002DB090
		private void OnRemoveActiveTab(int activeId)
		{
			if (this.m_akTabObjects == null)
			{
				return;
			}
			if (this.m_akTabObjects.HasObject(activeId))
			{
				ActiveChargeTabObject @object = this.m_akTabObjects.GetObject(activeId);
				if (@object != null && @object == ActiveChargeTabObject.Selected)
				{
					ActiveChargeTabObject.Clear();
				}
				this.m_akTabObjects.RecycleObject(activeId);
				this._SetDefaultTabs();
			}
		}

		// Token: 0x04006CFF RID: 27903
		public static ActiveChargeFrame activeChargeFrame = null;

		// Token: 0x04006D00 RID: 27904
		public const int monthlySignInActiveID = 3000;

		// Token: 0x04006D01 RID: 27905
		public const int warriorRecruitActiveID = 8800;

		// Token: 0x04006D02 RID: 27906
		private ActiveManager.ActiveFrameConfig m_kData;

		// Token: 0x04006D03 RID: 27907
		private static ActiveSpecialFrameInfo[] ms_activeSpecialFrameDic = new ActiveSpecialFrameInfo[]
		{
			new ActiveSpecialFrameInfo
			{
				id = 6000,
				type = typeof(MonthCardActive)
			}
		};

		// Token: 0x04006D04 RID: 27908
		private List<ActiveSpecialFrame> m_akChildActiveFrames = new List<ActiveSpecialFrame>();

		// Token: 0x04006D05 RID: 27909
		private GameObject m_goTabParent;

		// Token: 0x04006D06 RID: 27910
		private GameObject m_goTabPrefab;

		// Token: 0x04006D07 RID: 27911
		private CachedObjectDicManager<int, ActiveChargeTabObject> m_akTabObjects = new CachedObjectDicManager<int, ActiveChargeTabObject>();

		// Token: 0x04006D08 RID: 27912
		private GameObject m_goActivitiesParent;

		// Token: 0x04006D09 RID: 27913
		private Dictionary<int, Dictionary<string, CachedObjectDicManager<int, ActiveItemObject>>> m_akActivities = new Dictionary<int, Dictionary<string, CachedObjectDicManager<int, ActiveItemObject>>>();

		// Token: 0x04006D0A RID: 27914
		private CachedObjectDicManager<int, ActiveObject> m_akActiveObjects = new CachedObjectDicManager<int, ActiveObject>();

		// Token: 0x04006D0B RID: 27915
		[UIControl("tabsList", typeof(ScrollRect), 0)]
		private ScrollRect tabScrollRect;

		// Token: 0x04006D0C RID: 27916
		[CompilerGenerated]
		private static Comparison<ActiveItemObject> <>f__mg$cache0;

		// Token: 0x04006D0D RID: 27917
		[CompilerGenerated]
		private static Comparison<ActiveManager.ActivityData> <>f__mg$cache1;

		// Token: 0x0200136A RID: 4970
		private enum PathKeyType
		{
			// Token: 0x04006D0F RID: 27919
			PKT_GLOBAL,
			// Token: 0x04006D10 RID: 27920
			PKT_LOCAL
		}
	}
}
