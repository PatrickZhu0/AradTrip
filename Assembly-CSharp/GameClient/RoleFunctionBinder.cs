using System;
using System.Collections.Generic;
using GamePool;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200116E RID: 4462
	internal class RoleFunctionBinder : FunctionBinder<SelectRoleFrame>
	{
		// Token: 0x0600AA7F RID: 43647 RVA: 0x002464DC File Offset: 0x002448DC
		protected override void Initialize()
		{
			this.m_goParent = Utility.FindChild(this.frame, "Roles");
			for (int i = 0; i < this.m_goPrefabs.Length; i++)
			{
				this.m_goPrefabs[i] = Utility.FindChild(this.m_goParent, string.Format("Role{0}", i));
			}
			this.delegateRoleSelected = Delegate.CreateDelegate(typeof(CachedSelectedObject<RoleData, RoleObject>.OnSelectedDelegate), this, "OnRoleSelected");
			this.m_roleCount = Utility.FindComponent<Text>(this.frame, "Roles/FixeBG/Count", true);
			this.m_roleFieldCount = Utility.FindComponent<Text>(this.frame, "Roles/FixeBG/FieldCount", true);
			this.m_rolePreferenceRoleCount = Utility.FindComponent<Text>(this.frame, "Roles/FixeBG/PreferenceRoleCount", true);
			this.btnArrowLeft = Utility.FindComponent<Button>(this.frame, "Roles/ArrowLeft", true);
			this.btnArrowLeft.onClick.AddListener(delegate()
			{
				this._MinusPage();
			});
			this.btnArrowRight = Utility.FindComponent<Button>(this.frame, "Roles/ArrowRight", true);
			this.btnArrowRight.onClick.AddListener(delegate()
			{
				this._AddPage();
			});
			this.dotRoot = Utility.FindComponent<ComDotController>(this.frame, "Roles/DotParent", true);
			if (this.dotRoot != null)
			{
				int iMaxPage = this._GetMaxPage();
				this.dotRoot.InitDots(iMaxPage, true);
				this.dotRoot.CustomActive(false);
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SetDefaultSelectedID, new ClientEventSystem.UIEventHandler(this._OnSetDefaultSelectedID));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshRolePreferenceCount, new ClientEventSystem.UIEventHandler(this._OnRefreshRolePreferenceCount));
			this.m_iCurPage = 1;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(706, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.m_iTotalPreferenceRoleCount = tableItem.Value;
			}
		}

		// Token: 0x0600AA80 RID: 43648 RVA: 0x002466B4 File Offset: 0x00244AB4
		protected override void UnInitialize()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SetDefaultSelectedID, new ClientEventSystem.UIEventHandler(this._OnSetDefaultSelectedID));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshRolePreferenceCount, new ClientEventSystem.UIEventHandler(this._OnRefreshRolePreferenceCount));
			this.delegateRoleSelected = null;
			for (int i = 0; i < this.m_goPrefabs.Length; i++)
			{
				this.m_goPrefabs[i] = null;
			}
			this.m_goParent = null;
			CachedSelectedObject<RoleData, RoleObject>.Clear();
			this.m_akRoleObjects.DestroyAllObjects();
			this.btnArrowLeft.onClick.RemoveAllListeners();
			this.btnArrowRight.onClick.RemoveAllListeners();
		}

		// Token: 0x0600AA81 RID: 43649 RVA: 0x00246758 File Offset: 0x00244B58
		protected override void Refresh()
		{
			ulong num = 0UL;
			if (CachedSelectedObject<RoleData, RoleObject>.Selected != null)
			{
				num = CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo.roleId;
			}
			int iIndex = -1;
			this.m_akRoleObjects.DestroyAllObjects();
			PlayerUtility.SortRoleInfoList();
			RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
			List<RoleInfo> list = new List<RoleInfo>();
			for (int i = 0; i < roleinfo.Length; i++)
			{
				if (RecoveryRoleCachedObject.OnFilterAlive(roleinfo[i]))
				{
					list.Add(roleinfo[i]);
					if (roleinfo[i].roleId == num && num > 0UL)
					{
						iIndex = i;
					}
				}
			}
			this._RefreshRoleNumFormat(list.Count);
			this._RefreshPreferenceRoleCountFormat();
			this.m_iCurPage = IntMath.Max(1, this.m_iCurPage);
			int b = this._GetMaxPage();
			this.m_iCurPage = IntMath.Min(this.m_iCurPage, b);
			List<RoleFieldData> list2 = new List<RoleFieldData>();
			int num2 = this.m_iCurPage * RoleFunctionBinder.m_iMaxRoles;
			int num3 = (this.m_iCurPage - 1) * RoleFunctionBinder.m_iMaxRoles;
			int j = num3;
			int num4 = num2;
			while (j < num4)
			{
				RoleSelectFieldState fieldState = this._GetRoleFieldStateByPageIndex(j, list.Count);
				if (j < list.Count)
				{
					list2.Add(new RoleFieldData
					{
						roleInfo = list[j],
						fieldState = fieldState
					});
				}
				else
				{
					list2.Add(new RoleFieldData
					{
						roleInfo = null,
						fieldState = fieldState
					});
				}
				j++;
			}
			for (int k = 0; k < this.m_goPrefabs.Length; k++)
			{
				this.SetState(RoleSelectFieldState.Default, this.m_goPrefabs[k]);
			}
			int num5 = 0;
			while (num5 < list2.Count && num5 < this.m_goPrefabs.Length)
			{
				if (list2[num5] != null)
				{
					GameObject gameObject = this.m_goPrefabs[num5];
					this.SetState(list2[num5].fieldState, gameObject);
					if (list2[num5].fieldState == RoleSelectFieldState.BaseHasRole || list2[num5].fieldState == RoleSelectFieldState.NewUnlockHasRole || list2[num5].fieldState == RoleSelectFieldState.LockHasRole)
					{
						RoleData roleData = new RoleData
						{
							roleInfo = list2[num5].roleInfo
						};
						this.m_akRoleObjects.Create(new object[]
						{
							this.m_goParent,
							gameObject,
							roleData,
							this.delegateRoleSelected,
							true
						});
					}
				}
				num5++;
			}
			this._OnSelectedIndex(iIndex);
			this._OnPageChanged();
		}

		// Token: 0x0600AA82 RID: 43650 RVA: 0x00246A0B File Offset: 0x00244E0B
		public bool IsEmpty()
		{
			return this.m_akRoleObjects.ActiveObjects.Count <= 0;
		}

		// Token: 0x0600AA83 RID: 43651 RVA: 0x00246A23 File Offset: 0x00244E23
		public void ClearRoleSelected()
		{
			if (CachedSelectedObject<RoleData, RoleObject>.Selected != null)
			{
				CachedSelectedObject<RoleData, RoleObject>.Selected = null;
			}
		}

		// Token: 0x0600AA84 RID: 43652 RVA: 0x00246A35 File Offset: 0x00244E35
		public void OnRoleSelected(RoleData data)
		{
			if (data != null && data.roleInfo != null)
			{
				this.OnRoleSelected(data.roleInfo.roleId);
			}
		}

		// Token: 0x0600AA85 RID: 43653 RVA: 0x00246A5C File Offset: 0x00244E5C
		public void OnRoleSelected(ulong roleId)
		{
			int iIndex = -1;
			RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
			for (int i = 0; i < roleinfo.Length; i++)
			{
				if (roleinfo[i].roleId == roleId)
				{
					Singleton<VoiceManager>.instance.PlayVoiceByOccupation(VoiceTable.eVoiceType.SELECTROLE, (int)roleinfo[i].occupation);
					ClientApplication.playerinfo.curSelectedRoleIdx = i;
					iIndex = i;
					break;
				}
			}
			this._OnSelectedIndex(iIndex);
		}

		// Token: 0x0600AA86 RID: 43654 RVA: 0x00246AC4 File Offset: 0x00244EC4
		public void MoveToPageByRoleId(ulong roleId)
		{
			List<object> list = ListPool<object>.Get();
			this._GetRolesInfo(ref list);
			int iIndex = -1;
			for (int i = 0; i < list.Count; i++)
			{
				if ((list[i] as RoleInfo).roleId == roleId)
				{
					iIndex = i;
					break;
				}
			}
			this.m_iCurPage = this._TranslateIndexToPage(iIndex);
			ListPool<object>.Release(list);
		}

		// Token: 0x0600AA87 RID: 43655 RVA: 0x00246B2C File Offset: 0x00244F2C
		public ulong SetTheLatestLoginRoleAsDefault()
		{
			List<object> list = ListPool<object>.Get();
			this._GetRolesInfo(ref list);
			int num = -1;
			ulong result = 0UL;
			for (int i = 0; i < list.Count; i++)
			{
				if (num == -1)
				{
					num = i;
					result = (list[i] as RoleInfo).roleId;
				}
				else if ((list[i] as RoleInfo).offlineTime > (list[num] as RoleInfo).offlineTime)
				{
					num = i;
					result = (list[i] as RoleInfo).roleId;
				}
			}
			ListPool<object>.Release(list);
			this.m_iCurPage = this._TranslateIndexToPage(num);
			return result;
		}

		// Token: 0x0600AA88 RID: 43656 RVA: 0x00246BD4 File Offset: 0x00244FD4
		public void OnUpdate()
		{
			List<RoleObject> activeObjects = this.m_akRoleObjects.ActiveObjects;
			for (int i = 0; i < activeObjects.Count; i++)
			{
				activeObjects[i].OnFrameUpdate();
			}
		}

		// Token: 0x0600AA89 RID: 43657 RVA: 0x00246C10 File Offset: 0x00245010
		private void _OnSetDefaultSelectedID(UIEvent uiEvent)
		{
			this._OnSelectedIndex(uiEvent.EventParams.CurrentSelectedID);
		}

		// Token: 0x0600AA8A RID: 43658 RVA: 0x00246C23 File Offset: 0x00245023
		private void _OnRefreshRolePreferenceCount(UIEvent uIEvent)
		{
			this._RefreshPreferenceRoleCountFormat();
		}

		// Token: 0x0600AA8B RID: 43659 RVA: 0x00246C2C File Offset: 0x0024502C
		private void _OnSelectedIndex(int iIndex)
		{
			RoleObject roleObject = this._GetSelectedRoleObject(iIndex);
			if (roleObject != null)
			{
				roleObject.OnSelected();
			}
			else
			{
				CachedSelectedObject<RoleData, RoleObject>.Clear();
			}
		}

		// Token: 0x0600AA8C RID: 43660 RVA: 0x00246C58 File Offset: 0x00245058
		private RoleObject _GetSelectedRoleObject(int iIndex)
		{
			RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
			RoleObject result = null;
			if (iIndex >= 0 && iIndex < roleinfo.Length)
			{
				List<RoleObject> activeObjects = this.m_akRoleObjects.ActiveObjects;
				for (int i = 0; i < activeObjects.Count; i++)
				{
					if (activeObjects[i] != null && activeObjects[i].Value != null && activeObjects[i].Value.roleInfo != null)
					{
						if (activeObjects[i].Value.roleInfo.roleId == roleinfo[iIndex].roleId)
						{
							result = activeObjects[i];
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600AA8D RID: 43661 RVA: 0x00246D10 File Offset: 0x00245110
		private void _AddPage()
		{
			int num = this._GetMaxPage();
			if (this.m_iCurPage < num)
			{
				ulong num2 = 0UL;
				if (CachedSelectedObject<RoleData, RoleObject>.Selected != null && CachedSelectedObject<RoleData, RoleObject>.Selected.Value != null && CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo != null)
				{
					num2 = CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo.roleId;
				}
				this.m_iCurPage++;
				this.Refresh();
				this._OnPageChanged();
				if (this.m_akRoleObjects.ActiveObjects.Count > 0)
				{
					bool flag = false;
					List<RoleObject> activeObjects = this.m_akRoleObjects.ActiveObjects;
					for (int i = 0; i < activeObjects.Count; i++)
					{
						if (activeObjects[i] != null && activeObjects[i].Value != null && activeObjects[i].Value.roleInfo != null && activeObjects[i].Value.roleInfo.roleId == num2)
						{
							this.OnRoleSelected(activeObjects[i].Value);
							flag = true;
							break;
						}
					}
					int num3 = 0;
					while (num3 < activeObjects.Count && !flag)
					{
						if (activeObjects[num3] != null && activeObjects[num3].Value != null && activeObjects[num3].Value.roleInfo != null)
						{
							this.OnRoleSelected(activeObjects[num3].Value);
							break;
						}
						num3++;
					}
				}
			}
		}

		// Token: 0x0600AA8E RID: 43662 RVA: 0x00246EAC File Offset: 0x002452AC
		private void _MinusPage()
		{
			if (this.m_iCurPage > 1)
			{
				ulong num = 0UL;
				if (CachedSelectedObject<RoleData, RoleObject>.Selected != null && CachedSelectedObject<RoleData, RoleObject>.Selected.Value != null && CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo != null)
				{
					num = CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo.roleId;
				}
				this.m_iCurPage--;
				this.Refresh();
				this._OnPageChanged();
				if (this.m_akRoleObjects.ActiveObjects.Count > 0)
				{
					List<RoleObject> activeObjects = this.m_akRoleObjects.ActiveObjects;
					if (activeObjects.Count > 0)
					{
						bool flag = false;
						for (int i = activeObjects.Count - 1; i >= 0; i--)
						{
							if (activeObjects[i] != null && activeObjects[i].Value != null && activeObjects[i].Value.roleInfo != null && activeObjects[i].Value.roleInfo.roleId == num)
							{
								this.OnRoleSelected(activeObjects[i].Value);
								flag = true;
								break;
							}
						}
						int num2 = activeObjects.Count - 1;
						while (num2 >= 0 && !flag)
						{
							if (activeObjects[num2] != null && activeObjects[num2].Value != null && activeObjects[num2].Value.roleInfo != null)
							{
								this.OnRoleSelected(activeObjects[num2].Value);
								break;
							}
							num2--;
						}
					}
				}
			}
		}

		// Token: 0x0600AA8F RID: 43663 RVA: 0x00247048 File Offset: 0x00245448
		private void _OnPageChanged()
		{
			int num = this._GetMaxPage();
			this.btnArrowLeft.CustomActive(this.m_iCurPage > 1);
			this.btnArrowRight.CustomActive(this.m_iCurPage < num);
			if (this.dotRoot != null)
			{
				this.dotRoot.CustomActive(num >= 2);
				this.dotRoot.SetDots(this.m_iCurPage, num);
			}
		}

		// Token: 0x0600AA90 RID: 43664 RVA: 0x002470BC File Offset: 0x002454BC
		private int _GetMaxPage()
		{
			int num = this._GetTotalNeedShowRoleFieldCount();
			if (num <= 0)
			{
				return 1;
			}
			return (num - 1) / RoleFunctionBinder.m_iMaxRoles + 1;
		}

		// Token: 0x0600AA91 RID: 43665 RVA: 0x002470E4 File Offset: 0x002454E4
		private void _GetRolesInfo(ref List<object> akRoles)
		{
			if (akRoles != null)
			{
				RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
				for (int i = 0; i < roleinfo.Length; i++)
				{
					if (RecoveryRoleCachedObject.OnFilterAlive(roleinfo[i]))
					{
						akRoles.Add(roleinfo[i]);
					}
				}
			}
		}

		// Token: 0x0600AA92 RID: 43666 RVA: 0x0024712E File Offset: 0x0024552E
		protected void CreateRole(bool changed)
		{
		}

		// Token: 0x0600AA93 RID: 43667 RVA: 0x00247130 File Offset: 0x00245530
		protected void SetState(RoleSelectFieldState state, GameObject prefab)
		{
			if (prefab == null)
			{
				return;
			}
			ComSelectRoleField component = prefab.GetComponent<ComSelectRoleField>();
			if (component != null)
			{
				component.SetRoleSelectFieldState(state);
				switch (state)
				{
				case RoleSelectFieldState.None:
					component.SetNoneStateShow();
					break;
				case RoleSelectFieldState.Default:
					component.SetDefaultStateShow();
					break;
				case RoleSelectFieldState.BaseHasRole:
					component.SetBaseHasRoleStateShow();
					break;
				case RoleSelectFieldState.NewUnlockHasRole:
					component.SetNewUnlockHasRoleStateShow();
					break;
				case RoleSelectFieldState.NewUnlockNoRole:
					component.SetNewUnlockNoRoleStateShow();
					break;
				case RoleSelectFieldState.LockHasRole:
					component.SetLockHasRoleStateShow();
					break;
				case RoleSelectFieldState.LockNoRole:
					component.SetLockNoRoleStateShow();
					break;
				}
			}
		}

		// Token: 0x0600AA94 RID: 43668 RVA: 0x002471D8 File Offset: 0x002455D8
		private int _GetMaxPage(int iCount)
		{
			if (iCount <= 0)
			{
				return 1;
			}
			if (iCount % RoleFunctionBinder.m_iMaxRoles == 0)
			{
				return iCount / RoleFunctionBinder.m_iMaxRoles;
			}
			return 1 + iCount / RoleFunctionBinder.m_iMaxRoles;
		}

		// Token: 0x0600AA95 RID: 43669 RVA: 0x00247200 File Offset: 0x00245600
		private int _TranslateIndexToPage(int iIndex)
		{
			if (iIndex <= 0)
			{
				iIndex = 0;
			}
			return iIndex / RoleFunctionBinder.m_iMaxRoles + 1;
		}

		// Token: 0x0600AA96 RID: 43670 RVA: 0x00247218 File Offset: 0x00245618
		private void _RefreshRoleNumFormat(int roleNum)
		{
			if (this.m_roleCount)
			{
				this.m_roleCount.text = TR.Value("select_role_count", roleNum.ToString());
			}
			int num = this._GetTotalEnableRoleFieldCount();
			int num2 = Mathf.Max(this._GetTotalEnableRoleFieldCount(), this._GetStandardRoleFieldCount());
			if (this.m_roleFieldCount)
			{
				this.m_roleFieldCount.text = TR.Value("select_role_field_count", num.ToString(), num2.ToString());
			}
		}

		// Token: 0x0600AA97 RID: 43671 RVA: 0x002472B0 File Offset: 0x002456B0
		private void _RefreshPreferenceRoleCountFormat()
		{
			int preferenceCountInAccount = PlayerUtility.GetPreferenceCountInAccount();
			if (this.m_rolePreferenceRoleCount)
			{
				this.m_rolePreferenceRoleCount.text = TR.Value("select_role_preference_role_count", preferenceCountInAccount, this.m_iTotalPreferenceRoleCount);
			}
		}

		// Token: 0x0600AA98 RID: 43672 RVA: 0x002472FC File Offset: 0x002456FC
		private RoleSelectFieldState _GetRoleFieldStateByPageIndex(int index, int roleCount)
		{
			RoleSelectFieldState result = RoleSelectFieldState.None;
			if (index < this._GetStandardBaseRoleFieldNum())
			{
				result = ((index >= roleCount) ? RoleSelectFieldState.Default : RoleSelectFieldState.BaseHasRole);
			}
			else if (index >= this._GetStandardBaseRoleFieldNum() && index < this._GetTotalEnableRoleFieldCount())
			{
				if (this._GetStandardExtendNewUnlockRoleFieldNum() > 0 && index >= this._GetTotalEnableRoleFieldCount() - this._GetStandardExtendNewUnlockRoleFieldNum())
				{
					result = ((index >= roleCount) ? RoleSelectFieldState.NewUnlockNoRole : RoleSelectFieldState.NewUnlockHasRole);
				}
				else
				{
					result = ((index >= roleCount) ? RoleSelectFieldState.Default : RoleSelectFieldState.BaseHasRole);
				}
			}
			else if (index >= this._GetTotalEnableRoleFieldCount())
			{
				if (this._GetTotalLockRoleFieldCount() > 0)
				{
					if (roleCount > this._GetStandardRoleFieldCount())
					{
						result = ((index >= roleCount) ? RoleSelectFieldState.None : RoleSelectFieldState.LockHasRole);
					}
					else if (index < roleCount)
					{
						result = RoleSelectFieldState.LockHasRole;
					}
					else
					{
						result = ((index >= this._GetStandardRoleFieldCount()) ? RoleSelectFieldState.None : RoleSelectFieldState.LockNoRole);
					}
				}
				else
				{
					result = ((index >= roleCount) ? RoleSelectFieldState.None : RoleSelectFieldState.LockHasRole);
				}
			}
			return result;
		}

		// Token: 0x0600AA99 RID: 43673 RVA: 0x002473FC File Offset: 0x002457FC
		private int _GetStandardBaseRoleFieldNum()
		{
			int iMaxRoles = RoleFunctionBinder.m_iMaxRoles;
			if (ClientApplication.playerinfo == null)
			{
				return iMaxRoles;
			}
			if (iMaxRoles != (int)ClientApplication.playerinfo.baseRoleFieldNum)
			{
				return iMaxRoles;
			}
			return (int)ClientApplication.playerinfo.baseRoleFieldNum;
		}

		// Token: 0x0600AA9A RID: 43674 RVA: 0x00247437 File Offset: 0x00245837
		private int _GetStandardExtendRoleFieldNum()
		{
			if (ClientApplication.playerinfo != null)
			{
				return (int)ClientApplication.playerinfo.extendRoleFieldNum;
			}
			return 0;
		}

		// Token: 0x0600AA9B RID: 43675 RVA: 0x0024744F File Offset: 0x0024584F
		private int _GetStandardExtendUnlockRoleFieldNum()
		{
			if (ClientApplication.playerinfo != null)
			{
				return (int)ClientApplication.playerinfo.unLockedExtendRoleFieldNum;
			}
			return 0;
		}

		// Token: 0x0600AA9C RID: 43676 RVA: 0x00247467 File Offset: 0x00245867
		private int _GetStandardExtendNewUnlockRoleFieldNum()
		{
			if (ClientApplication.playerinfo != null)
			{
				return (int)ClientApplication.playerinfo.newUnLockExtendRoleFieldNum;
			}
			return 0;
		}

		// Token: 0x0600AA9D RID: 43677 RVA: 0x00247480 File Offset: 0x00245880
		private int _GetTotalLockRoleFieldCount()
		{
			int num = 0;
			if (ClientApplication.playerinfo != null)
			{
				num = this._GetStandardExtendRoleFieldNum() - this._GetStandardExtendUnlockRoleFieldNum();
				if (num < 0)
				{
					num = 0;
				}
			}
			return num;
		}

		// Token: 0x0600AA9E RID: 43678 RVA: 0x002474B4 File Offset: 0x002458B4
		private int _GetTotalEnableRoleFieldCount()
		{
			int result = RoleFunctionBinder.m_iMaxRoles;
			if (ClientApplication.playerinfo != null)
			{
				result = this._GetStandardBaseRoleFieldNum() + this._GetStandardExtendUnlockRoleFieldNum();
			}
			return result;
		}

		// Token: 0x0600AA9F RID: 43679 RVA: 0x002474E0 File Offset: 0x002458E0
		private int _GetStandardRoleFieldCount()
		{
			int result = RoleFunctionBinder.m_iMaxRoles;
			if (ClientApplication.playerinfo != null)
			{
				result = this._GetStandardBaseRoleFieldNum() + this._GetStandardExtendRoleFieldNum();
			}
			return result;
		}

		// Token: 0x0600AAA0 RID: 43680 RVA: 0x0024750C File Offset: 0x0024590C
		private int _GetTotalNeedShowRoleFieldCount()
		{
			int num = Mathf.Max(this._GetTotalEnableRoleFieldCount(), this._GetStandardRoleFieldCount());
			List<object> list = ListPool<object>.Get();
			this._GetRolesInfo(ref list);
			int count = list.Count;
			ListPool<object>.Release(list);
			if (num < count)
			{
				num = count;
			}
			return num;
		}

		// Token: 0x04005F99 RID: 24473
		public CachedObjectListManager<RoleObject> m_akRoleObjects = new CachedObjectListManager<RoleObject>();

		// Token: 0x04005F9A RID: 24474
		public static readonly int m_iMaxRoles = 8;

		// Token: 0x04005F9B RID: 24475
		private int totalRoleFieldCount;

		// Token: 0x04005F9C RID: 24476
		public GameObject m_goParent;

		// Token: 0x04005F9D RID: 24477
		public GameObject[] m_goPrefabs = new GameObject[RoleFunctionBinder.m_iMaxRoles];

		// Token: 0x04005F9E RID: 24478
		public Text m_roleCount;

		// Token: 0x04005F9F RID: 24479
		public Text m_roleFieldCount;

		// Token: 0x04005FA0 RID: 24480
		public Text m_rolePreferenceRoleCount;

		// Token: 0x04005FA1 RID: 24481
		private Button btnArrowLeft;

		// Token: 0x04005FA2 RID: 24482
		private Button btnArrowRight;

		// Token: 0x04005FA3 RID: 24483
		private ComDotController dotRoot;

		// Token: 0x04005FA4 RID: 24484
		private Delegate delegateRoleSelected;

		// Token: 0x04005FA5 RID: 24485
		private int m_iCurPage = 1;

		// Token: 0x04005FA6 RID: 24486
		private int m_iTotalPreferenceRoleCount;
	}
}
