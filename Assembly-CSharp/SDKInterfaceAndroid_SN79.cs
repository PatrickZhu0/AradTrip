using System;
using GameClient;
using ProtoTable;

// Token: 0x02004662 RID: 18018
public class SDKInterfaceAndroid_SN79 : SDKInterfaceAndroid
{
	// Token: 0x0601962C RID: 103980 RVA: 0x008067F2 File Offset: 0x00804BF2
	public override void Init(bool debug)
	{
		base.Init(debug);
		base.GetActivity().Call("InitSNSS", new object[]
		{
			debug
		});
	}

	// Token: 0x0601962D RID: 103981 RVA: 0x0080681A File Offset: 0x00804C1A
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x0601962E RID: 103982 RVA: 0x00806832 File Offset: 0x00804C32
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x0601962F RID: 103983 RVA: 0x0080684C File Offset: 0x00804C4C
	public override void Pay(string price, string extra = "", int serverID = 0, string openuid = "")
	{
		this.SetPayItemNameAndDesc(extra);
		base.GetActivity().Call("Pay", new object[]
		{
			this.PAY_APP_NAME,
			this.PAY_APP_DESC,
			price,
			extra,
			ClientApplication.adminServer.name,
			serverID,
			openuid,
			DataManager<PlayerBaseData>.GetInstance().Name,
			(int)DataManager<PlayerBaseData>.GetInstance().Level
		});
	}

	// Token: 0x06019630 RID: 103984 RVA: 0x008068CB File Offset: 0x00804CCB
	public override bool NeedSDKBindPhoneOpen()
	{
		return false;
	}

	// Token: 0x06019631 RID: 103985 RVA: 0x008068CE File Offset: 0x00804CCE
	public override void OpenBindPhone()
	{
		base.GetActivity().Call("OpenBindPhone", new object[0]);
	}

	// Token: 0x06019632 RID: 103986 RVA: 0x008068E6 File Offset: 0x00804CE6
	public override void CheckIsPhoneBind()
	{
		base.GetActivity().Call("CheckBindPhoneSucc", new object[0]);
	}

	// Token: 0x06019633 RID: 103987 RVA: 0x008068FE File Offset: 0x00804CFE
	public override bool CanSetCreateRoleInfoInFiveMin()
	{
		return this.canSetCreateRoleInfoInFiveMin;
	}

	// Token: 0x06019634 RID: 103988 RVA: 0x00806906 File Offset: 0x00804D06
	public override void SetCreateRoleInfo(string accid, string roleid)
	{
		this.canSetCreateRoleInfoInFiveMin = true;
	}

	// Token: 0x06019635 RID: 103989 RVA: 0x0080690F File Offset: 0x00804D0F
	public override void SetCreateRoleInFiveInfo(string accid, string roleid)
	{
		this.canSetCreateRoleInfoInFiveMin = false;
	}

	// Token: 0x06019636 RID: 103990 RVA: 0x00806918 File Offset: 0x00804D18
	public override void SetRoleUpLevelInfo(string accid, string roleid, string roleLevel)
	{
	}

	// Token: 0x06019637 RID: 103991 RVA: 0x0080691C File Offset: 0x00804D1C
	public override void UpdateRoleInfo(int scene, uint serverID, string serverName, string roleID, string roleName, int proID, int roleLevel = 1, int vip = 0, int dianquanNum = 0)
	{
		string empty = string.Empty;
		if (scene != 1)
		{
			if (scene != 2)
			{
				if (scene != 3)
				{
					if (scene == 4)
					{
					}
				}
			}
		}
		string openuid = ClientApplication.playerinfo.openuid;
		int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
		if (scene == 1)
		{
			try
			{
				base.GetActivity().Call("SetRoleLogin", new object[]
				{
					openuid,
					roleID,
					roleName,
					roleLevel.ToString(),
					DataManager<PlayerBaseData>.GetInstance().RoleCreateTime.ToString(),
					serverID.ToString(),
					serverName,
					vip.ToString(),
					jobTableID.ToString(),
					Utility.GetJobName(jobTableID, 0),
					dianquanNum.ToString()
				});
			}
			catch (Exception ex)
			{
				Logger.LogError("ReporterLoginRoleInfo is not found in 7977" + ex.ToString());
			}
		}
		else if (scene == 2)
		{
			try
			{
				base.GetActivity().Call("SetRoleUpLevelInfo", new object[]
				{
					openuid,
					roleID,
					roleName,
					roleLevel.ToString(),
					DataManager<PlayerBaseData>.GetInstance().RoleCreateTime.ToString(),
					serverID.ToString(),
					serverName,
					vip.ToString(),
					jobTableID.ToString(),
					Utility.GetJobName(jobTableID, 0),
					dianquanNum.ToString()
				});
			}
			catch (Exception ex2)
			{
				Logger.LogError("SetRoleUpLevelInfo is not found in 7977" + ex2.ToString());
			}
		}
		else if (scene == 3)
		{
			try
			{
				base.GetActivity().Call("SetCreateRoleInfo", new object[]
				{
					openuid,
					roleID,
					roleName,
					roleLevel.ToString(),
					DataManager<PlayerBaseData>.GetInstance().RoleCreateTime.ToString(),
					serverID.ToString(),
					serverName,
					vip.ToString(),
					jobTableID.ToString(),
					Utility.GetJobName(jobTableID, 0),
					dianquanNum.ToString()
				});
			}
			catch (Exception ex3)
			{
				Logger.LogError("SetCreateRoleInfo is not found in 7977" + ex3.ToString());
			}
		}
		else if (scene == 4)
		{
			try
			{
				base.GetActivity().Call("SetRoleOnExit", new object[]
				{
					openuid,
					roleID,
					roleName,
					roleLevel.ToString(),
					DataManager<PlayerBaseData>.GetInstance().RoleCreateTime.ToString(),
					serverID.ToString(),
					serverName,
					vip.ToString(),
					jobTableID.ToString(),
					Utility.GetJobName(jobTableID, 0),
					dianquanNum.ToString()
				});
			}
			catch (Exception ex4)
			{
				Logger.LogError("SetRoleOnExit is not found in 7977" + ex4.ToString());
			}
		}
	}

	// Token: 0x06019638 RID: 103992 RVA: 0x00806CF4 File Offset: 0x008050F4
	private void SetPayItemNameAndDesc(string cookie)
	{
		if (string.IsNullOrEmpty(cookie))
		{
			return;
		}
		string[] array = cookie.Split(new char[]
		{
			','
		});
		int id;
		if (array != null && array.Length >= 3 && int.TryParse(array[1], out id))
		{
			ChargeMallTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChargeMallTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.PAY_APP_NAME = tableItem.Name;
				this.PAY_APP_DESC = tableItem.Desc;
			}
			else
			{
				this.PAY_APP_NAME = "商城礼包";
				this.PAY_APP_DESC = "购买可获得商城大礼包";
			}
		}
	}

	// Token: 0x04012305 RID: 74501
	private string PAY_APP_NAME = "商城礼包";

	// Token: 0x04012306 RID: 74502
	private string PAY_APP_DESC = "购买可获得商城大礼包";

	// Token: 0x04012307 RID: 74503
	private bool canSetCreateRoleInfoInFiveMin;
}
