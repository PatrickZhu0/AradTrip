using System;
using GameClient;
using LitJson;
using ProtoTable;

// Token: 0x0200465E RID: 18014
public class SDKInterfaceAndroid_MG : SDKInterfaceAndroid
{
	// Token: 0x06019607 RID: 103943 RVA: 0x00805AA2 File Offset: 0x00803EA2
	public override void Init(bool debug)
	{
		base.Init(debug);
		base.GetActivity().Call("InitMG", new object[]
		{
			debug
		});
	}

	// Token: 0x06019608 RID: 103944 RVA: 0x00805ACC File Offset: 0x00803ECC
	public override void Login()
	{
		if (Global.Settings.sdkChannel.ToString().Contains("MGOther"))
		{
			this.AccountTransfer();
		}
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x06019609 RID: 103945 RVA: 0x00805B19 File Offset: 0x00803F19
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x0601960A RID: 103946 RVA: 0x00805B34 File Offset: 0x00803F34
	public override void Pay(string price, string extra = "", int serverID = 0, string openuid = "")
	{
		this.PayNotifyUrl = string.Format("http://{0}/mg_charge", Global.ANDROID_MG_CHARGE);
		this.SetPayItemNameAndDesc(extra);
		base.GetActivity().Call("Pay", new object[]
		{
			this.PAY_APP_NAME,
			this.PAY_APP_DESC,
			price,
			extra,
			serverID,
			DataManager<PlayerBaseData>.GetInstance().Name,
			DataManager<PlayerBaseData>.GetInstance().RoleID.ToString(),
			this.PayNotifyUrl,
			"阿拉德之怒"
		});
	}

	// Token: 0x0601960B RID: 103947 RVA: 0x00805BD0 File Offset: 0x00803FD0
	public override bool NeedSDKBindPhoneOpen()
	{
		return true;
	}

	// Token: 0x0601960C RID: 103948 RVA: 0x00805BD4 File Offset: 0x00803FD4
	public override void OpenBindPhone()
	{
		try
		{
			base.GetActivity().Call("OpenBindPhone", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("OpenBindPhone is not found in MG" + ex.ToString());
		}
	}

	// Token: 0x0601960D RID: 103949 RVA: 0x00805C28 File Offset: 0x00804028
	public override void CheckIsPhoneBind()
	{
		try
		{
			base.GetActivity().Call("CheckBindPhoneSucc", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("CheckBindPhoneSucc is not found in MG" + ex.ToString());
		}
	}

	// Token: 0x0601960E RID: 103950 RVA: 0x00805C7C File Offset: 0x0080407C
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
		if (scene == 3)
		{
			try
			{
				base.GetActivity().Call("ReporterCreateRoleInfo", new object[]
				{
					roleID,
					serverID.ToString(),
					roleName
				});
			}
			catch (Exception ex)
			{
				Logger.LogError("ReporterCreateRoleInfo is not found in MG" + ex.ToString());
			}
		}
		else if (scene == 1)
		{
			try
			{
				string text = "default";
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(proID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					text = tableItem.Name;
				}
				base.GetActivity().Call("ReporterLoginRoleInfo", new object[]
				{
					roleID,
					serverID.ToString(),
					roleName,
					roleLevel.ToString(),
					text
				});
			}
			catch (Exception ex2)
			{
				Logger.LogError("ReporterLoginRoleInfo is not found in MG" + ex2.ToString());
			}
		}
	}

	// Token: 0x0601960F RID: 103951 RVA: 0x00805DE4 File Offset: 0x008041E4
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

	// Token: 0x06019610 RID: 103952 RVA: 0x00805E7C File Offset: 0x0080427C
	private void AccountTransfer()
	{
		bool flag = false;
		try
		{
			string text = SDKInterfaceAndroid_MG._loadAcctransferconfigFromFile();
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split(new char[]
				{
					','
				});
				if (array == null || array.Length > 0)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (!string.IsNullOrEmpty(array[i]))
						{
							string fileName = string.Format("{0}_{1}.{2}", "convertInfo", array[i], "conf");
							string text2 = Singleton<PluginManager>.GetInstance().ReadDoc(TR.Value("zymg_convert_account_filerootpath"), fileName);
							if (!string.IsNullOrEmpty(text2))
							{
								LocalConvertAccInfos localConvertAccInfos = JsonMapper.ToObject<LocalConvertAccInfos>(text2);
								if (localConvertAccInfos != null && localConvertAccInfos.convertAccountInfos != null)
								{
									for (int j = 0; j < localConvertAccInfos.convertAccountInfos.Count; j++)
									{
										ConvertAccountInfo convertAccountInfo = localConvertAccInfos.convertAccountInfos[j];
										if (convertAccountInfo != null)
										{
											if (!convertAccountInfo.alreadyConverAccount)
											{
												base.GetActivity().Call("AccountTransfer", new object[]
												{
													convertAccountInfo.account,
													convertAccountInfo.password
												});
												convertAccountInfo.alreadyConverAccount = true;
												flag = true;
											}
										}
									}
									string text3 = JsonMapper.ToJson(localConvertAccInfos);
									if (!string.IsNullOrEmpty(text3) && flag)
									{
										this.SaveDoc(text3, TR.Value("zymg_convert_account_filerootpath"), fileName, false);
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogError("AccountTransfer failed" + ex.ToString());
		}
	}

	// Token: 0x06019611 RID: 103953 RVA: 0x00806038 File Offset: 0x00804438
	private static string _loadAcctransferconfigFromFile()
	{
		string empty = string.Empty;
		if (FileArchiveAccessor.LoadFileInLocalFileArchive("accounttransferconfig.conf", out empty))
		{
			try
			{
				return empty;
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[acctransferconfig] 解析 {0} 失败, {1}", new object[]
				{
					"accounttransferconfig.conf",
					ex.ToString()
				});
				return string.Empty;
			}
		}
		Logger.LogErrorFormat("[acctransferconfig] 加载 {0} 失败", new object[]
		{
			"accounttransferconfig.conf"
		});
		return string.Empty;
	}

	// Token: 0x040122F4 RID: 74484
	private const string APP_NAME = "阿拉德之怒";

	// Token: 0x040122F5 RID: 74485
	private string PayNotifyUrl = "http://39.108.116.227:58002/mg_charge";

	// Token: 0x040122F6 RID: 74486
	private string PAY_APP_NAME = "商城礼包";

	// Token: 0x040122F7 RID: 74487
	private string PAY_APP_DESC = "购买可获得商城大礼包";

	// Token: 0x040122F8 RID: 74488
	private const string acctransferconfigFileName = "accounttransferconfig.conf";
}
