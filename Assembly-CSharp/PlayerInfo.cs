using System;
using GameClient;
using Protocol;

// Token: 0x02004569 RID: 17769
public class PlayerInfo
{
	// Token: 0x06018CA0 RID: 101536 RVA: 0x007BEBBC File Offset: 0x007BCFBC
	public bool GetHasApponintmentActiviti()
	{
		return this.apponintmentOccus.Length != 0;
	}

	// Token: 0x06018CA1 RID: 101537 RVA: 0x007BEBD0 File Offset: 0x007BCFD0
	public bool GetRoleHasApponintmentOccu(int ID)
	{
		for (int i = 0; i < this.apponintmentOccus.Length; i++)
		{
			if (ID == (int)this.apponintmentOccus[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018CA2 RID: 101538 RVA: 0x007BEC07 File Offset: 0x007BD007
	public bool GetRoleHasApponintmentOccu(RoleInfo info)
	{
		return info.isAppointmentOccu == 1;
	}

	// Token: 0x06018CA3 RID: 101539 RVA: 0x007BEC18 File Offset: 0x007BD018
	public bool GetSelectRoleHasPassFirstFight()
	{
		RoleInfo selectRoleBaseInfoByLogin = this.GetSelectRoleBaseInfoByLogin();
		return selectRoleBaseInfoByLogin != null && selectRoleBaseInfoByLogin.newboot >= 1U;
	}

	// Token: 0x06018CA4 RID: 101540 RVA: 0x007BEC44 File Offset: 0x007BD044
	public RoleInfo GetSelectRoleBaseInfoByLogin()
	{
		if (this.roleinfo == null)
		{
			return this.defaultRoleInfo;
		}
		if (this.curSelectedRoleIdx >= 0 && this.curSelectedRoleIdx < this.roleinfo.Length)
		{
			return this.roleinfo[this.curSelectedRoleIdx];
		}
		Logger.LogErrorFormat("curSelectRoleIdx = {0},roleinfo.Count = {1}", new object[]
		{
			this.curSelectedRoleIdx,
			this.roleinfo.Length
		});
		return null;
	}

	// Token: 0x06018CA5 RID: 101541 RVA: 0x007BECC4 File Offset: 0x007BD0C4
	public bool CheckAllRoleLevelIsContainsParamLevel(int level)
	{
		for (int i = 0; i < this.roleinfo.Length; i++)
		{
			RoleInfo roleInfo = this.roleinfo[i];
			if ((int)roleInfo.level >= level)
			{
				return true;
			}
		}
		return (int)DataManager<PlayerBaseData>.GetInstance().Level >= level;
	}

	// Token: 0x06018CA6 RID: 101542 RVA: 0x007BED1C File Offset: 0x007BD11C
	public bool CheckRoleIsBuyGift(int min, int max)
	{
		bool result = false;
		for (int i = 0; i < this.roleinfo.Length; i++)
		{
			RoleInfo roleInfo = this.roleinfo[i];
			if (roleInfo.roleId == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= min && (int)DataManager<PlayerBaseData>.GetInstance().Level <= max)
				{
					return true;
				}
			}
			else if ((int)roleInfo.level >= min && (int)roleInfo.level <= max)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x04011DA6 RID: 73126
	public uint accid;

	// Token: 0x04011DA7 RID: 73127
	public byte[] hashValue = new byte[20];

	// Token: 0x04011DA8 RID: 73128
	public string param = string.Empty;

	// Token: 0x04011DA9 RID: 73129
	public ulong session;

	// Token: 0x04011DAA RID: 73130
	public byte seat;

	// Token: 0x04011DAB RID: 73131
	public string currentGateServer;

	// Token: 0x04011DAC RID: 73132
	public string currentGateServerName;

	// Token: 0x04011DAD RID: 73133
	public string token;

	// Token: 0x04011DAE RID: 73134
	public string openuid;

	// Token: 0x04011DAF RID: 73135
	public string sdkLoginExt;

	// Token: 0x04011DB0 RID: 73136
	public string password = string.Empty;

	// Token: 0x04011DB1 RID: 73137
	public string password2 = string.Empty;

	// Token: 0x04011DB2 RID: 73138
	public string cpsaccount = string.Empty;

	// Token: 0x04011DB3 RID: 73139
	public int age;

	// Token: 0x04011DB4 RID: 73140
	public AuthIDType authType = AuthIDType.AUTH_ADULT;

	// Token: 0x04011DB5 RID: 73141
	public uint serverID;

	// Token: 0x04011DB6 RID: 73142
	public PlayerState state;

	// Token: 0x04011DB7 RID: 73143
	public int curSelectedRoleIdx;

	// Token: 0x04011DB8 RID: 73144
	public RoleInfo[] roleinfo;

	// Token: 0x04011DB9 RID: 73145
	public byte[] apponintmentOccus;

	// Token: 0x04011DBA RID: 73146
	public uint appointmentRoleNum;

	// Token: 0x04011DBB RID: 73147
	public uint baseRoleFieldNum;

	// Token: 0x04011DBC RID: 73148
	public uint extendRoleFieldNum;

	// Token: 0x04011DBD RID: 73149
	public uint unLockedExtendRoleFieldNum;

	// Token: 0x04011DBE RID: 73150
	public uint newUnLockExtendRoleFieldNum;

	// Token: 0x04011DBF RID: 73151
	public AdventureTeamExtraInfo adventureTeamInfo;

	// Token: 0x04011DC0 RID: 73152
	public RoleInfo defaultRoleInfo = new RoleInfo
	{
		occupation = (byte)Global.Settings.iSingleCharactorID,
		name = "DNF大神"
	};
}
