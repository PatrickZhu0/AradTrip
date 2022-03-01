using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020017C4 RID: 6084
	internal class MainMissionList
	{
		// Token: 0x17001CE9 RID: 7401
		// (get) Token: 0x0600EFE9 RID: 61417 RVA: 0x00408E32 File Offset: 0x00407232
		public bool Initialized
		{
			get
			{
				return this._initialized;
			}
		}

		// Token: 0x17001CEA RID: 7402
		// (get) Token: 0x0600EFEA RID: 61418 RVA: 0x00408E3A File Offset: 0x0040723A
		// (set) Token: 0x0600EFEB RID: 61419 RVA: 0x00408E41 File Offset: 0x00407241
		public static MissionManager.SingleMissionInfo Selected
		{
			get
			{
				return ComMainMissionScript.ms_selected;
			}
			set
			{
				ComMainMissionScript.ms_selected = value;
			}
		}

		// Token: 0x0600EFEC RID: 61420 RVA: 0x00408E4C File Offset: 0x0040724C
		private bool _IsLegalMainMission(MissionManager.SingleMissionInfo value)
		{
			if (value == null)
			{
				return false;
			}
			if (this.m_eFilterType == MissionFrameNew.FilterZeroType.FZT_ACCEPTED)
			{
				if (value.missionItem.TaskType == MissionTable.eTaskType.TT_BRANCH)
				{
					return true;
				}
				if (value.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN)
				{
					return true;
				}
				if (value.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE)
				{
					return true;
				}
				if (value.missionItem.TaskType == MissionTable.eTaskType.TT_AWAKEN)
				{
					return true;
				}
			}
			return this.m_eFilterType == MissionFrameNew.FilterZeroType.FZT_TITLE_TASK && value.missionItem.TaskType == MissionTable.eTaskType.TT_TITLE;
		}

		// Token: 0x0600EFED RID: 61421 RVA: 0x00408ED6 File Offset: 0x004072D6
		private bool _IsCycleMission(uint iId)
		{
			return DataManager<MissionManager>.GetInstance().taskGroup.ContainsKey(iId) && this._IsCycleMission(DataManager<MissionManager>.GetInstance().taskGroup[iId]);
		}

		// Token: 0x0600EFEE RID: 61422 RVA: 0x00408F05 File Offset: 0x00407305
		private bool _IsCycleMission(MissionManager.SingleMissionInfo value)
		{
			return value != null && value.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE;
		}

		// Token: 0x0600EFEF RID: 61423 RVA: 0x00408F22 File Offset: 0x00407322
		private ComMainMissionScript _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComMainMissionScript>();
		}

		// Token: 0x0600EFF0 RID: 61424 RVA: 0x00408F2C File Offset: 0x0040732C
		private void _OnFilter(List<MissionManager.SingleMissionInfo> missions, MissionFrameNew.FilterZeroType eFilterZero)
		{
			missions.RemoveAll((MissionManager.SingleMissionInfo x) => this._GetFilterType(x) != eFilterZero);
		}

		// Token: 0x0600EFF1 RID: 61425 RVA: 0x00408F60 File Offset: 0x00407360
		public void Filter(MissionFrameNew.FilterZeroType eFilterZero)
		{
			if (this.m_eFilterType != eFilterZero)
			{
				this.m_eFilterType = eFilterZero;
				this._LoadMainMissions(eFilterZero, false);
			}
		}

		// Token: 0x0600EFF2 RID: 61426 RVA: 0x00408F7D File Offset: 0x0040737D
		private MissionFrameNew.FilterZeroType _GetFilterType(MissionManager.SingleMissionInfo value)
		{
			if (value.missionItem.TaskType == MissionTable.eTaskType.TT_TITLE)
			{
				return MissionFrameNew.FilterZeroType.FZT_TITLE_TASK;
			}
			return MissionFrameNew.FilterZeroType.FZT_ACCEPTED;
		}

		// Token: 0x0600EFF3 RID: 61427 RVA: 0x00408F94 File Offset: 0x00407394
		public void Initialize(ClientFrame clientFrame, GameObject gameObject, MainMissionList.OnRedPointChanged onRedPointChanged, MissionFrameNew.FilterZeroType eFilterType, bool bCycle, bool bLocked)
		{
			if (this._initialized)
			{
				return;
			}
			this._initialized = true;
			this.clientFrame = clientFrame;
			this.gameObject = gameObject;
			this.onRedPointChanged = onRedPointChanged;
			this.m_eFilterType = eFilterType;
			this.bLockCycle = bCycle;
			this.comUIListScript = this.gameObject.GetComponent<ComUIListScript>();
			this.comUIListScript.Initialize();
			ComUIListScript comUIListScript = this.comUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.comUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			ComUIListScript comUIListScript3 = this.comUIListScript;
			comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
			ComUIListScript comUIListScript4 = this.comUIListScript;
			comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Combine(instance.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionListChanged));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onDeleteMissionValue = (MissionManager.OnDeleteMissionValue)Delegate.Combine(instance2.onDeleteMissionValue, new MissionManager.OnDeleteMissionValue(this.OnDeleteMissionValue));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance3.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMainMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance4.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMainMission));
			PlayerBaseData instance5 = DataManager<PlayerBaseData>.GetInstance();
			instance5.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance5.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			this._LoadMainMissions(this.m_eFilterType, bLocked);
		}

		// Token: 0x0600EFF4 RID: 61428 RVA: 0x00409160 File Offset: 0x00407560
		private List<MissionManager.SingleMissionInfo> _GetMainMissions(MissionFrameNew.FilterZeroType eFilterZero = MissionFrameNew.FilterZeroType.FZT_COUNT)
		{
			List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			list.RemoveAll((MissionManager.SingleMissionInfo x) => !this._IsLegalMainMission(x));
			return list;
		}

		// Token: 0x0600EFF5 RID: 61429 RVA: 0x00409198 File Offset: 0x00407598
		private bool _CheckRedPoint(List<MissionManager.SingleMissionInfo> values)
		{
			if (values != null)
			{
				for (int i = 0; i < values.Count; i++)
				{
					if (values[i].status == 2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600EFF6 RID: 61430 RVA: 0x004091D7 File Offset: 0x004075D7
		private void SortMissions()
		{
			if (this.missions == null)
			{
				return;
			}
			this.missions.Sort(new Comparison<MissionManager.SingleMissionInfo>(this._Sort));
			MainMissionList.SortBranchTasks(ref this.missions);
		}

		// Token: 0x0600EFF7 RID: 61431 RVA: 0x00409208 File Offset: 0x00407608
		private bool _SelectedCycleMission()
		{
			if (!this.bLockCycle)
			{
				return false;
			}
			this.missions = this._GetMainMissions(MissionFrameNew.FilterZeroType.FZT_COUNT);
			this.SortMissions();
			int num = -1;
			for (int i = 0; i < this.missions.Count; i++)
			{
				if (this.missions[i] != null && this.missions[i].missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				this._TryChangeFilter(this.missions[num]);
			}
			this.comUIListScript.SetElementAmount(this.missions.Count);
			num = -1;
			for (int j = 0; j < this.missions.Count; j++)
			{
				if (this.missions[j] != null && this.missions[j].missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE)
				{
					num = j;
					break;
				}
			}
			if (num != -1)
			{
				this._SetSelectedItem(num);
			}
			return -1 != num;
		}

		// Token: 0x0600EFF8 RID: 61432 RVA: 0x00409320 File Offset: 0x00407720
		private bool _SelectedFixedMission()
		{
			if (MainMissionList.Selected == null)
			{
				return false;
			}
			this.missions = this._GetMainMissions(MissionFrameNew.FilterZeroType.FZT_COUNT);
			if (this.missions == null)
			{
				return false;
			}
			this._TryChangeFilter(MainMissionList.Selected);
			this.SortMissions();
			if (this.comUIListScript == null)
			{
				return false;
			}
			this.comUIListScript.SetElementAmount(this.missions.Count);
			int num = -1;
			for (int i = 0; i < this.missions.Count; i++)
			{
				if (this.missions[i] != null && this.missions[i].taskID == MainMissionList.Selected.taskID)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				this._SetSelectedItem(num);
			}
			return -1 != num;
		}

		// Token: 0x0600EFF9 RID: 61433 RVA: 0x004093F8 File Offset: 0x004077F8
		private bool _SelectedFilterMission(MissionFrameNew.FilterZeroType eFilterZero)
		{
			if (eFilterZero == MissionFrameNew.FilterZeroType.FZT_COUNT)
			{
				return false;
			}
			if (this.clientFrame == null)
			{
				return false;
			}
			this.missions = this._GetMainMissions(MissionFrameNew.FilterZeroType.FZT_COUNT);
			this._OnFilter(this.missions, eFilterZero);
			this.m_eFilterType = eFilterZero;
			(this.clientFrame as MissionFrameNew).OnFilterZeroChanged(eFilterZero);
			this.SortMissions();
			this.comUIListScript.SetElementAmount(this.missions.Count);
			int num = -1;
			if (MainMissionList.Selected != null)
			{
				for (int i = 0; i < this.missions.Count; i++)
				{
					if (this.missions[i].taskID == MainMissionList.Selected.taskID)
					{
						num = i;
						break;
					}
				}
			}
			if (num == -1 && this.missions.Count > 0)
			{
				num = 0;
			}
			this._SetSelectedItem(num);
			return -1 != num;
		}

		// Token: 0x0600EFFA RID: 61434 RVA: 0x004094E0 File Offset: 0x004078E0
		private void _SelectedRandomMission()
		{
			this.missions = this._GetMainMissions(MissionFrameNew.FilterZeroType.FZT_COUNT);
			this.SortMissions();
			if (this.missions != null && this.missions.Count > 0)
			{
				this._TryChangeFilter(this.missions[0]);
				this._SetSelectedItem(0);
			}
			if (this.comUIListScript != null)
			{
				this.comUIListScript.SetElementAmount(this.missions.Count);
			}
		}

		// Token: 0x0600EFFB RID: 61435 RVA: 0x0040955C File Offset: 0x0040795C
		private void _TryChangeFilter(MissionManager.SingleMissionInfo value)
		{
			if (value != null)
			{
				MissionFrameNew.FilterZeroType filterZeroType = MissionFrameNew.FilterZeroType.FZT_TITLE_TASK;
				if (value.missionItem != null && value.missionItem.TaskType != MissionTable.eTaskType.TT_TITLE)
				{
					filterZeroType = MissionFrameNew.FilterZeroType.FZT_ACCEPTED;
				}
				this.m_eFilterType = filterZeroType;
				this._OnFilter(this.missions, this.m_eFilterType);
				MissionFrameNew missionFrameNew = this.clientFrame as MissionFrameNew;
				if (missionFrameNew != null)
				{
					missionFrameNew.OnFilterZeroChanged(filterZeroType);
				}
			}
		}

		// Token: 0x0600EFFC RID: 61436 RVA: 0x004095C4 File Offset: 0x004079C4
		private void _TrySetDefaultMission(MissionFrameNew.FilterZeroType eFilterZero, bool bLocked)
		{
			if (MainMissionList.Selected != null)
			{
				MainMissionList.Selected = DataManager<MissionManager>.GetInstance().GetMission(MainMissionList.Selected.taskID);
			}
			if (bLocked)
			{
				if (this._SelectedCycleMission())
				{
					return;
				}
				if (this._SelectedFixedMission())
				{
					return;
				}
				if (this._SelectedFilterMission(eFilterZero))
				{
					return;
				}
				this._SelectedRandomMission();
			}
			else if (eFilterZero != MissionFrameNew.FilterZeroType.FZT_COUNT)
			{
				this._SelectedFilterMission(eFilterZero);
			}
			else
			{
				this.m_eFilterType = MissionFrameNew.FilterZeroType.FZT_ACCEPTED;
				if (!this._SelectedFilterMission(MissionFrameNew.FilterZeroType.FZT_ACCEPTED))
				{
					this.m_eFilterType = MissionFrameNew.FilterZeroType.FZT_ACCEPTED;
					this._SelectedFilterMission(MissionFrameNew.FilterZeroType.FZT_ACCEPTED);
				}
			}
		}

		// Token: 0x0600EFFD RID: 61437 RVA: 0x00409660 File Offset: 0x00407A60
		private void _SetSelectedItem(int iBindIndex)
		{
			if (this.missions != null && this.comUIListScript != null)
			{
				if (iBindIndex >= 0 && iBindIndex < this.missions.Count)
				{
					MainMissionList.Selected = this.missions[iBindIndex];
					if (!this.comUIListScript.IsElementInScrollArea(iBindIndex))
					{
						this.comUIListScript.EnsureElementVisable(iBindIndex);
					}
					this.comUIListScript.SelectElement(iBindIndex, true);
				}
				else
				{
					this.comUIListScript.SelectElement(-1, true);
					MainMissionList.Selected = null;
				}
			}
			MissionFrameNew missionFrameNew = this.clientFrame as MissionFrameNew;
			if (missionFrameNew != null)
			{
				missionFrameNew.OnMissionSelected(MainMissionList.Selected);
			}
		}

		// Token: 0x0600EFFE RID: 61438 RVA: 0x00409714 File Offset: 0x00407B14
		public static void SortBranchTasks(ref List<MissionManager.SingleMissionInfo> missions)
		{
			List<MissionManager.SingleMissionInfo> list = new List<MissionManager.SingleMissionInfo>();
			if (list == null)
			{
				return;
			}
			if (missions == null)
			{
				return;
			}
			List<int> list2 = new List<int>();
			if (list2 == null)
			{
				return;
			}
			for (int i = 0; i < missions.Count; i++)
			{
				MissionManager.SingleMissionInfo singleMissionInfo = missions[i];
				if (singleMissionInfo != null)
				{
					if (singleMissionInfo.missionItem != null)
					{
						if (singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_BRANCH)
						{
							list2.Add(i);
							list.Add(singleMissionInfo);
						}
					}
				}
			}
			list.Sort(delegate(MissionManager.SingleMissionInfo a, MissionManager.SingleMissionInfo b)
			{
				if (a == null || b == null)
				{
					return 0;
				}
				if (a.missionItem == null || b.missionItem == null)
				{
					return 0;
				}
				if (a.status != b.status)
				{
					return MainMissionList._sortOrder[(int)a.status] - MainMissionList._sortOrder[(int)b.status];
				}
				if (a.missionItem.MinPlayerLv != b.missionItem.MinPlayerLv)
				{
					return b.missionItem.MinPlayerLv.CompareTo(a.missionItem.MinPlayerLv);
				}
				if (a.missionItem.ID != b.missionItem.ID)
				{
					return a.missionItem.ID.CompareTo(b.missionItem.ID);
				}
				return 0;
			});
			if (list2.Count != list.Count)
			{
				return;
			}
			for (int j = 0; j < list.Count; j++)
			{
				int num = list2[j];
				if (num < missions.Count)
				{
					missions[num] = list[j];
				}
			}
		}

		// Token: 0x0600EFFF RID: 61439 RVA: 0x0040981C File Offset: 0x00407C1C
		private void _LoadMainMissions(MissionFrameNew.FilterZeroType eFilterZero, bool bLoced = false)
		{
			this.missions = this._GetMainMissions(MissionFrameNew.FilterZeroType.FZT_COUNT);
			this.SortMissions();
			if (this.onRedPointChanged != null)
			{
				this.onRedPointChanged(this._CheckRedPoint(this.missions));
			}
			this._TrySetDefaultMission(eFilterZero, bLoced);
		}

		// Token: 0x0600F000 RID: 61440 RVA: 0x0040985C File Offset: 0x00407C5C
		private int _Sort(MissionManager.SingleMissionInfo left, MissionManager.SingleMissionInfo right)
		{
			if (left.missionItem.TaskType != right.missionItem.TaskType)
			{
				return DataManager<MissionManager>.GetInstance().getSortIDUseType(right.missionItem.TaskType) - DataManager<MissionManager>.GetInstance().getSortIDUseType(left.missionItem.TaskType);
			}
			if (left.status != right.status)
			{
				if (left.status == 5)
				{
					return 1;
				}
				if (right.status == 5)
				{
					return -1;
				}
				return (int)(right.status - left.status);
			}
			else
			{
				if (left.missionItem.SortID != right.missionItem.SortID)
				{
					return left.missionItem.SortID - right.missionItem.SortID;
				}
				return (left.taskID >= right.taskID) ? 1 : -1;
			}
		}

		// Token: 0x0600F001 RID: 61441 RVA: 0x00409938 File Offset: 0x00407D38
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			if (item != null && item.m_index >= 0 && item.m_index < this.missions.Count)
			{
				ComMainMissionScript comMainMissionScript = item.gameObjectBindScript as ComMainMissionScript;
				if (comMainMissionScript != null)
				{
					comMainMissionScript.OnVisible(this.missions[item.m_index], this.clientFrame);
				}
			}
		}

		// Token: 0x0600F002 RID: 61442 RVA: 0x004099A8 File Offset: 0x00407DA8
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			if (item != null)
			{
				ComMainMissionScript comMainMissionScript = item.gameObjectBindScript as ComMainMissionScript;
				if (comMainMissionScript != null)
				{
					MainMissionList.Selected = comMainMissionScript.Value;
					(this.clientFrame as MissionFrameNew).OnMissionSelected(comMainMissionScript.Value);
				}
			}
		}

		// Token: 0x0600F003 RID: 61443 RVA: 0x004099FC File Offset: 0x00407DFC
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			if (item != null)
			{
				ComMainMissionScript comMainMissionScript = item.gameObjectBindScript as ComMainMissionScript;
				if (comMainMissionScript != null)
				{
					comMainMissionScript.OnDisplayChange(bSelected);
				}
			}
		}

		// Token: 0x0600F004 RID: 61444 RVA: 0x00409A34 File Offset: 0x00407E34
		public void UnInitialize()
		{
			if (this._initialized)
			{
				MissionManager instance = DataManager<MissionManager>.GetInstance();
				instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMainMission));
				MissionManager instance2 = DataManager<MissionManager>.GetInstance();
				instance2.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance2.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMainMission));
				MissionManager instance3 = DataManager<MissionManager>.GetInstance();
				instance3.onDeleteMissionValue = (MissionManager.OnDeleteMissionValue)Delegate.Remove(instance3.onDeleteMissionValue, new MissionManager.OnDeleteMissionValue(this.OnDeleteMissionValue));
				MissionManager instance4 = DataManager<MissionManager>.GetInstance();
				instance4.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Remove(instance4.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionListChanged));
				PlayerBaseData instance5 = DataManager<PlayerBaseData>.GetInstance();
				instance5.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance5.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
				if (this.comUIListScript != null)
				{
					ComUIListScript comUIListScript = this.comUIListScript;
					comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
					ComUIListScript comUIListScript2 = this.comUIListScript;
					comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
					ComUIListScript comUIListScript3 = this.comUIListScript;
					comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
					ComUIListScript comUIListScript4 = this.comUIListScript;
					comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
					this.comUIListScript = null;
				}
				this.onRedPointChanged = null;
				this.clientFrame = null;
				this.gameObject = null;
				this._initialized = false;
			}
		}

		// Token: 0x0600F005 RID: 61445 RVA: 0x00409BDA File Offset: 0x00407FDA
		private void OnMissionListChanged()
		{
			this._LoadMainMissions(this.m_eFilterType, false);
		}

		// Token: 0x0600F006 RID: 61446 RVA: 0x00409BE9 File Offset: 0x00407FE9
		private void OnAddNewMainMission(uint taskID)
		{
			if (this.bLockCycle)
			{
				this._LoadMainMissions(this.m_eFilterType, true);
				this.bLockCycle = false;
			}
			else
			{
				this._LoadMainMissions(this.m_eFilterType, false);
			}
		}

		// Token: 0x0600F007 RID: 61447 RVA: 0x00409C1C File Offset: 0x0040801C
		private void OnDeleteMissionValue(MissionManager.SingleMissionInfo value)
		{
			if (this._IsCycleMission(value))
			{
				this.bLockCycle = true;
			}
			else
			{
				this._LoadMainMissions(this.m_eFilterType, false);
			}
		}

		// Token: 0x0600F008 RID: 61448 RVA: 0x00409C43 File Offset: 0x00408043
		private void OnUpdateMainMission(uint taskID)
		{
			this._LoadMainMissions(this.m_eFilterType, true);
		}

		// Token: 0x0600F009 RID: 61449 RVA: 0x00409C52 File Offset: 0x00408052
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			this._LoadMainMissions(this.m_eFilterType, true);
		}

		// Token: 0x0400931D RID: 37661
		private ClientFrame clientFrame;

		// Token: 0x0400931E RID: 37662
		private GameObject gameObject;

		// Token: 0x0400931F RID: 37663
		private ComUIListScript comUIListScript;

		// Token: 0x04009320 RID: 37664
		private List<MissionManager.SingleMissionInfo> missions;

		// Token: 0x04009321 RID: 37665
		private MissionManager.SingleMissionInfo curSelected;

		// Token: 0x04009322 RID: 37666
		private MissionFrameNew.FilterZeroType m_eFilterType;

		// Token: 0x04009323 RID: 37667
		public MainMissionList.OnRedPointChanged onRedPointChanged;

		// Token: 0x04009324 RID: 37668
		private bool _initialized;

		// Token: 0x04009325 RID: 37669
		private bool bLockCycle;

		// Token: 0x04009326 RID: 37670
		private static int[] _sortOrder = new int[]
		{
			3,
			2,
			1,
			4,
			0,
			5
		};

		// Token: 0x020017C5 RID: 6085
		// (Invoke) Token: 0x0600F00E RID: 61454
		public delegate void OnRedPointChanged(bool bCheck);
	}
}
