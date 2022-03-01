using System;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02001A2C RID: 6700
public class VipSetting : MonoBehaviour
{
	// Token: 0x06010756 RID: 67414 RVA: 0x004A1DFC File Offset: 0x004A01FC
	private void Start()
	{
		if (null != this.switchReborn)
		{
			this.switchReborn.onValueChanged.AddListener(new UnityAction<bool>(this._onRebornToggleValueChange));
		}
		if (null != this.switchCrystal)
		{
			this.switchCrystal.onValueChanged.AddListener(new UnityAction<bool>(this._onCrystalSkillToggleValueChange));
		}
		this.InitRebornSetting();
		this.InitUseCrystalSkillSetting();
		if (!BeUtility.CheckVipFuncOpen(31))
		{
			this.mReborn.CustomActive(false);
		}
		if (!BeUtility.CheckVipFuncOpen(32) || !this.CheckUseCrystal())
		{
			this.mCrystalSkill.CustomActive(false);
		}
	}

	// Token: 0x06010757 RID: 67415 RVA: 0x004A1EAA File Offset: 0x004A02AA
	private void Update()
	{
	}

	// Token: 0x06010758 RID: 67416 RVA: 0x004A1EAC File Offset: 0x004A02AC
	protected bool CheckUseCrystal()
	{
		SwitchClientFunctionTable tableItem = Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(32, string.Empty, string.Empty);
		for (int i = 0; i < tableItem.ValueDLength; i++)
		{
			if (tableItem.ValueDArray(i) == DataManager<PlayerBaseData>.GetInstance().JobTableID)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010759 RID: 67417 RVA: 0x004A1F00 File Offset: 0x004A0300
	private void _onRebornToggleValueChange(bool changed)
	{
		Singleton<SettingManager>.GetInstance().SetVipSettingData("SETTING_VIPREBORN", changed);
	}

	// Token: 0x0601075A RID: 67418 RVA: 0x004A1F12 File Offset: 0x004A0312
	private void _onCrystalSkillToggleValueChange(bool changed)
	{
		Singleton<SettingManager>.GetInstance().SetVipSettingData("SETTING_VIPCRYSTAL", changed);
	}

	// Token: 0x0601075B RID: 67419 RVA: 0x004A1F24 File Offset: 0x004A0324
	protected void InitRebornSetting()
	{
		int num = 31;
		if (!this.CheckVipLevel(num))
		{
			return;
		}
		bool @default = this.GetDefault(num, "SETTING_VIPREBORN");
		this.switchReborn.SetSwitch(@default);
	}

	// Token: 0x0601075C RID: 67420 RVA: 0x004A1F5C File Offset: 0x004A035C
	protected void InitUseCrystalSkillSetting()
	{
		int num = 32;
		if (!this.CheckVipLevel(num))
		{
			return;
		}
		bool @default = this.GetDefault(num, "SETTING_VIPCRYSTAL");
		this.switchCrystal.SetSwitch(@default);
	}

	// Token: 0x0601075D RID: 67421 RVA: 0x004A1F94 File Offset: 0x004A0394
	private bool CheckVipLevel(int id)
	{
		int vipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
		int valueA = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(id, string.Empty, string.Empty).ValueA;
		return vipLevel > valueA;
	}

	// Token: 0x0601075E RID: 67422 RVA: 0x004A1FCC File Offset: 0x004A03CC
	private string GetRoleId()
	{
		return DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
	}

	// Token: 0x0601075F RID: 67423 RVA: 0x004A1FF4 File Offset: 0x004A03F4
	private bool GetDefault(int tableId, string vipType)
	{
		string key = string.Format("{0}{1}", vipType, this.GetRoleId());
		bool result;
		if (PlayerLocalSetting.GetValue(key) == null)
		{
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(tableId, string.Empty, string.Empty);
			result = (tableItem.ValueB == 1);
		}
		else
		{
			result = Singleton<SettingManager>.GetInstance().GetVipSettingData(vipType, this.GetRoleId());
		}
		return result;
	}

	// Token: 0x06010760 RID: 67424 RVA: 0x004A2064 File Offset: 0x004A0464
	private void OnDestroy()
	{
		this.mReborn = null;
		if (null != this.switchReborn)
		{
			this.switchReborn.onValueChanged.RemoveListener(new UnityAction<bool>(this._onRebornToggleValueChange));
		}
		this.switchReborn = null;
		this.mCrystalSkill = null;
		if (null != this.switchCrystal)
		{
			this.switchCrystal.onValueChanged.RemoveListener(new UnityAction<bool>(this._onCrystalSkillToggleValueChange));
		}
	}

	// Token: 0x0400A75B RID: 42843
	public GeUISwitchButton switchReborn;

	// Token: 0x0400A75C RID: 42844
	public GeUISwitchButton switchCrystal;

	// Token: 0x0400A75D RID: 42845
	public GameObject mReborn;

	// Token: 0x0400A75E RID: 42846
	public GameObject mCrystalSkill;
}
