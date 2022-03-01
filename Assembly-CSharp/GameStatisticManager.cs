using System;
using System.Collections.Generic;
using GameClient;
using LitJson;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using XUPorterJSON;

// Token: 0x0200463A RID: 17978
public class GameStatisticManager : Singleton<GameStatisticManager>
{
	// Token: 0x0601941B RID: 103451 RVA: 0x007FF19A File Offset: 0x007FD59A
	public override void Init()
	{
		base.Init();
	}

	// Token: 0x0601941C RID: 103452 RVA: 0x007FF1A4 File Offset: 0x007FD5A4
	public void DoStatDialog(int dialogID, int nextDialogID, GameStatisticManager.DialogOperateType eDialogOperateType, GameStatisticManager.DialogFinishType eDialogFinishType)
	{
	}

	// Token: 0x0601941D RID: 103453 RVA: 0x007FF1B4 File Offset: 0x007FD5B4
	public void DoStatTask(StatTaskType type, int taskID)
	{
	}

	// Token: 0x0601941E RID: 103454 RVA: 0x007FF1C4 File Offset: 0x007FD5C4
	public void DoStatNewBieGuide(string key, int idex = -1)
	{
		if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_NEW_CLIENT_LOG))
		{
			this.NewDoStatistic("newbieguide", string.Format("NewBieGuide:{0}:{1}", key, idex));
		}
		else
		{
			this.DoStatistic(string.Format("NewBieGuide|{0}|{1}|", key, idex), StatType.ROLE);
		}
	}

	// Token: 0x0601941F RID: 103455 RVA: 0x007FF21E File Offset: 0x007FD61E
	public void UploadLocalLogToServer(string log)
	{
	}

	// Token: 0x06019420 RID: 103456 RVA: 0x007FF220 File Offset: 0x007FD620
	public void DoStatEnterPVERoom(int GuanKaID, int RoomID)
	{
		this.DoStatistic(string.Format("EnterPVERoom|{0}|{1}|", GuanKaID, RoomID), StatType.ROLE);
	}

	// Token: 0x06019421 RID: 103457 RVA: 0x007FF240 File Offset: 0x007FD640
	public void DoStatFinishMeleeBattle(string jobs)
	{
		FramePerformance execCmdPerf = FrameSync.instance.execCmdPerf;
		FramePerformance recvCmdPerf = FrameSync.instance.recvCmdPerf;
		RoleInfo selectRoleBaseInfoByLogin = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin();
		GameStatisticManager.BattleStatistic battleStatistic = new GameStatisticManager.BattleStatistic
		{
			gameVersion = Singleton<VersionManager>.GetInstance().Version(),
			roleId = ((selectRoleBaseInfoByLogin == null) ? string.Empty : selectRoleBaseInfoByLogin.roleId.ToString()),
			roleLv = ((selectRoleBaseInfoByLogin == null) ? string.Empty : selectRoleBaseInfoByLogin.level.ToString()),
			account = ClientApplication.playerinfo.accid.ToString(),
			teamJobId = jobs,
			JobId = ((DataManager<PlayerBaseData>.GetInstance() == null) ? "0" : DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString()),
			sid = ClientApplication.playerinfo.serverID.ToString(),
			platId = Application.platform.ToString(),
			vip = ((DataManager<PlayerBaseData>.GetInstance() == null) ? "0" : DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString()),
			channel = Global.channelName,
			deviceId = SystemInfo.deviceUniqueIdentifier,
			ip = Network.player.ipAddress,
			ip_ext = Network.player.externalIP,
			netType = Application.internetReachability.ToString(),
			exeCmdRecentDelay = execCmdPerf.recentDelay.ToString(),
			exeCmdAvarageDelay = execCmdPerf.averageDelay.ToString(),
			exeCmdMaxDelay = execCmdPerf.maxDelay.ToString(),
			recvCmdRecentDelay = recvCmdPerf.recentDelay.ToString(),
			recvCmdAvarageDelay = recvCmdPerf.averageDelay.ToString(),
			recvCmdMaxDelay = recvCmdPerf.maxDelay.ToString(),
			mfr = SystemInfo.deviceModel,
			model = SystemInfo.deviceName,
			os_ver = SystemInfo.operatingSystem
		};
		battleStatistic.ping.S = this.dataStatistics.pingNums[0];
		battleStatistic.ping.A = this.dataStatistics.pingNums[1];
		battleStatistic.ping.B = this.dataStatistics.pingNums[2];
		battleStatistic.ping.C = this.dataStatistics.pingNums[3];
		battleStatistic.fps.S = this.dataStatistics.fpsNums[0];
		battleStatistic.fps.A = this.dataStatistics.fpsNums[1];
		battleStatistic.fps.B = this.dataStatistics.fpsNums[2];
		string content = JsonMapper.ToJson(battleStatistic);
		try
		{
			Http.SendPostRequest(string.Format("http://{0}//performance", Global.BATTLE_PERFORMANCE_POST_ADDRESS), content, null);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("Post BattleData error reason {0}", new object[]
			{
				ex.Message
			});
		}
	}

	// Token: 0x06019422 RID: 103458 RVA: 0x007FF5A8 File Offset: 0x007FD9A8
	public void DoStatFinishBattle(int GuanKaID)
	{
	}

	// Token: 0x06019423 RID: 103459 RVA: 0x007FF5AA File Offset: 0x007FD9AA
	public void DoStatSlideOperation(InfiniteSwordType infiniteSwordType)
	{
	}

	// Token: 0x06019424 RID: 103460 RVA: 0x007FF5AC File Offset: 0x007FD9AC
	public void DoStatJoyStick(InputManager.JoystickMode joystickMode)
	{
		this.DoStatistic(string.Format("JoystickMode|{0}|", joystickMode), StatType.ROLE);
	}

	// Token: 0x06019425 RID: 103461 RVA: 0x007FF5C5 File Offset: 0x007FD9C5
	public void DoStatRunning(RunningModeType runMode)
	{
		this.DoStatistic(string.Format("RunningMode|{0}|", runMode), StatType.ROLE);
	}

	// Token: 0x06019426 RID: 103462 RVA: 0x007FF5E0 File Offset: 0x007FD9E0
	public void DoStartSkillConfiguration(SkillConfigType skillConfigType, int skillId, int skillSlot)
	{
		string arg = string.Empty;
		if (skillConfigType == SkillConfigType.SKILL_CONFIG_PVE)
		{
			arg = "PVE";
		}
		else
		{
			arg = "PVP";
		}
		this.DoStatistic(string.Format("SkillConfigType:{0},SkillID:{1},SkillSlot:{2}", arg, skillId, skillSlot), StatType.ROLE);
	}

	// Token: 0x06019427 RID: 103463 RVA: 0x007FF629 File Offset: 0x007FDA29
	public void DoStatSkillPanel(StatSkillPanelType type, int skillID, int level = 0, int slot = 0)
	{
	}

	// Token: 0x06019428 RID: 103464 RVA: 0x007FF62B File Offset: 0x007FDA2B
	public void DoStatLevelChoose(StatLevelChooseType type, int chapterID, int levelID = 0, int difficult = 0, List<int> drugs = null)
	{
	}

	// Token: 0x06019429 RID: 103465 RVA: 0x007FF62D File Offset: 0x007FDA2D
	public void DoStartOPPO(StartOPPOType type, string str = "")
	{
	}

	// Token: 0x0601942A RID: 103466 RVA: 0x007FF62F File Offset: 0x007FDA2F
	public void DoStartVIVO(StartVIVOType type)
	{
	}

	// Token: 0x0601942B RID: 103467 RVA: 0x007FF634 File Offset: 0x007FDA34
	public void DoStartUIButton(string str)
	{
		string content = string.Format("UIButton:{0}", str);
		if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_NEW_CLIENT_LOG))
		{
			this.NewDoStatistic("guide", content);
		}
		else
		{
			this.DoStatistic(content, StatType.ROLE);
		}
	}

	// Token: 0x0601942C RID: 103468 RVA: 0x007FF67A File Offset: 0x007FDA7A
	public void DoStartCheckPointsSettlement(int dungeonId, string str)
	{
	}

	// Token: 0x0601942D RID: 103469 RVA: 0x007FF67C File Offset: 0x007FDA7C
	public void DoStartFuilDailChargeRaffle()
	{
		this.DoStatistic(string.Format("FuilDailChargeRaffle", new object[0]), StatType.ROLE);
	}

	// Token: 0x0601942E RID: 103470 RVA: 0x007FF695 File Offset: 0x007FDA95
	public void DoStartSingleBoardDoAgainButton(string str)
	{
	}

	// Token: 0x0601942F RID: 103471 RVA: 0x007FF697 File Offset: 0x007FDA97
	public void DoStartAnotherWorldDie(int roomId)
	{
		this.DoStatistic(string.Format("YiJiePlayerDeath|roomid{0}", roomId), StatType.ROLE);
	}

	// Token: 0x06019430 RID: 103472 RVA: 0x007FF6B0 File Offset: 0x007FDAB0
	public void DoStartMysticalMerchant(int totalNum)
	{
		this.DoStatistic(string.Format("MysticalMerchantTotalNumberOfTriggers|{0}", totalNum), StatType.ROLE);
	}

	// Token: 0x06019431 RID: 103473 RVA: 0x007FF6C9 File Offset: 0x007FDAC9
	public void DoStartMysticalMerchantType(string strType)
	{
		this.DoStatistic(string.Format("MysticalMerchanType|{0}", strType), StatType.ROLE);
	}

	// Token: 0x06019432 RID: 103474 RVA: 0x007FF6DD File Offset: 0x007FDADD
	public void DoStartMysticalMerchantDungeon(string dungeonName, string merchantName)
	{
		this.DoStatistic(string.Format("DungeonName|{0},MysticalMerchantType|{1}", dungeonName, merchantName), StatType.ROLE);
	}

	// Token: 0x06019433 RID: 103475 RVA: 0x007FF6F2 File Offset: 0x007FDAF2
	public void DoStartMysticalShopGoods(int itemId)
	{
		this.DoStatistic(string.Format("MysticalShopGoodsID|{0}", itemId), StatType.ROLE);
	}

	// Token: 0x06019434 RID: 103476 RVA: 0x007FF70B File Offset: 0x007FDB0B
	public void DoStartMysticalShopBuyDisCountGoodsNumber(int buyItemId, string moneyName, int disCount, int num)
	{
		this.DoStatistic(string.Format("MysticalShopBuyDisCountGoodsID|{0},ConsumptionMoneyType|{1},DisCountPRice|{2},MoneyNumber|{3}", new object[]
		{
			buyItemId,
			moneyName,
			disCount,
			num
		}), StatType.ROLE);
	}

	// Token: 0x06019435 RID: 103477 RVA: 0x007FF744 File Offset: 0x007FDB44
	public void DoStartMysticalShopBuyGoodsConsumptionOfMoney(int buyItemId, string moneyName, int num)
	{
		this.DoStatistic(string.Format("MysticalShopBuyDisCountGoodsID|{0},ConsumptionMoneyType|{1},MoneyNumber|{2}", buyItemId, moneyName, num), StatType.ROLE);
	}

	// Token: 0x06019436 RID: 103478 RVA: 0x007FF764 File Offset: 0x007FDB64
	public void DoStartOpenFrameUseTime(string sFrameName, int iTime)
	{
		this.DoStatistic(string.Format("OpenFrmae|{0}Time|{1}s", sFrameName, iTime), StatType.ROLE);
	}

	// Token: 0x06019437 RID: 103479 RVA: 0x007FF77E File Offset: 0x007FDB7E
	public void DoStartFrameOperation(string sFrameName, string sButtonName, string time)
	{
		this.DoStatistic(string.Format("FrameName|{0}ButtonName|{1}Time|{2}", sFrameName, sButtonName, time), StatType.ROLE);
	}

	// Token: 0x06019438 RID: 103480 RVA: 0x007FF794 File Offset: 0x007FDB94
	public void DoStartBreakThePitPillarAndReturnAutoMatically()
	{
		this.DoStatistic("BreakPitPillarReturnAutomatically", StatType.ROLE);
	}

	// Token: 0x06019439 RID: 103481 RVA: 0x007FF7A4 File Offset: 0x007FDBA4
	public string DungeonName(GameStatisticManager.DungeonsType type)
	{
		string result = string.Empty;
		if (type != GameStatisticManager.DungeonsType.NORMAL)
		{
			if (type != GameStatisticManager.DungeonsType.YUANGU)
			{
				if (type == GameStatisticManager.DungeonsType.HELL)
				{
					result = "深渊地下城";
				}
			}
			else
			{
				result = "远古地下城";
			}
		}
		else
		{
			result = "普通地下城";
		}
		return result;
	}

	// Token: 0x0601943A RID: 103482 RVA: 0x007FF7F2 File Offset: 0x007FDBF2
	public void DoYouMiVoiceIM(YouMiVoiceSDKCostType type, string param)
	{
	}

	// Token: 0x0601943B RID: 103483 RVA: 0x007FF7F4 File Offset: 0x007FDBF4
	public void DoStatPk(StatPKType type, string param = "")
	{
	}

	// Token: 0x0601943C RID: 103484 RVA: 0x007FF7F6 File Offset: 0x007FDBF6
	public void DoStatInBattleEx(StatInBattleType type, int dungeonID, int areaID, string content = "")
	{
	}

	// Token: 0x0601943D RID: 103485 RVA: 0x007FF7F8 File Offset: 0x007FDBF8
	public void DoStatDrugUse(int id, string content)
	{
	}

	// Token: 0x0601943E RID: 103486 RVA: 0x007FF7FC File Offset: 0x007FDBFC
	private bool _isOpen()
	{
		TestFunctionConfigTable tableItem = Singleton<TableManager>.instance.GetTableItem<TestFunctionConfigTable>(1, string.Empty, string.Empty);
		return tableItem != null && tableItem.Open;
	}

	// Token: 0x0601943F RID: 103487 RVA: 0x007FF833 File Offset: 0x007FDC33
	public void DoStatistic(string content, StatType type = StatType.ROLE)
	{
		this.count++;
		this.Send(content, type);
	}

	// Token: 0x06019440 RID: 103488 RVA: 0x007FF84C File Offset: 0x007FDC4C
	private void NewDoStatistic(string name = "guide", string content = "")
	{
		SceneClientLog sceneClientLog = new SceneClientLog();
		sceneClientLog.name = name;
		sceneClientLog.param1 = "1";
		sceneClientLog.param2 = content;
		sceneClientLog.param3 = string.Empty;
		NetManager.Instance().SendCommand<SceneClientLog>(ServerType.GATE_SERVER, sceneClientLog);
	}

	// Token: 0x06019441 RID: 103489 RVA: 0x007FF890 File Offset: 0x007FDC90
	public void DoAbnormalStat(string content)
	{
		this.Send(content, StatType.ABNORMAL);
	}

	// Token: 0x06019442 RID: 103490 RVA: 0x007FF89C File Offset: 0x007FDC9C
	public void DoStatClientData()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("gamever", Singleton<VersionManager>.GetInstance().Version());
		RoleInfo selectRoleBaseInfoByLogin = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin();
		if (selectRoleBaseInfoByLogin != null)
		{
			dictionary.Add("roleid", selectRoleBaseInfoByLogin.roleId.ToString());
			dictionary.Add("level", selectRoleBaseInfoByLogin.level.ToString());
		}
		else
		{
			dictionary.Add("roleid", string.Empty);
			dictionary.Add("level", string.Empty);
		}
		dictionary.Add("uid", ClientApplication.playerinfo.accid.ToString());
		dictionary.Add("_sid", ClientApplication.playerinfo.serverID.ToString());
		dictionary.Add("_nettype", Application.internetReachability.ToString());
		dictionary.Add("_ip", Network.player.ipAddress);
		dictionary.Add("_ip_ext", Network.player.externalIP);
		dictionary.Add("is_register", "false");
		dictionary.Add("_platId", Application.platform.ToString());
		dictionary.Add("_channel", Global.channelName);
		dictionary.Add("device_id", SystemInfo.deviceUniqueIdentifier);
		dictionary.Add("_mfr", SystemInfo.deviceModel);
		dictionary.Add("_model", SystemInfo.deviceName);
		dictionary.Add("_osver", SystemInfo.operatingSystem);
		this.Send2Device(dictionary);
		this.clientInfoSended = true;
	}

	// Token: 0x06019443 RID: 103491 RVA: 0x007FFA50 File Offset: 0x007FDE50
	private void Send2Device(Dictionary<string, string> jsondic)
	{
		if (!this._isOpen() || jsondic == null)
		{
			return;
		}
		string content = jsondic.toJson();
		string url = string.Format("http://{0}/device", Global.STATISTIC_SERVER_ADDRESS);
		Http.SendPostRequest(url, content, null);
	}

	// Token: 0x06019444 RID: 103492 RVA: 0x007FFA90 File Offset: 0x007FDE90
	private void Send(Dictionary<string, string> jsondic)
	{
		if (!this._isOpen() || jsondic == null)
		{
			return;
		}
		string content = jsondic.toJson();
		string url = string.Format("http://{0}:59527/game_process", "121.41.17.47");
		if (Global.Settings.isUsingSDK)
		{
			Http.SendPostRequest(url, content, null);
		}
		else
		{
			Http.SendPostRequest(url, content, null);
		}
	}

	// Token: 0x06019445 RID: 103493 RVA: 0x007FFAEC File Offset: 0x007FDEEC
	private string GetPlatform()
	{
		if (Application.platform == 8)
		{
			return "IOS";
		}
		if (Application.platform == 11)
		{
			return "Andorid";
		}
		if (Application.platform == 2 || Application.platform == 7)
		{
			return "PC";
		}
		if (Application.platform == null || Application.platform == 1)
		{
			return "MAC";
		}
		return "UNDEFINED";
	}

	// Token: 0x06019446 RID: 103494 RVA: 0x007FFB58 File Offset: 0x007FDF58
	public void SendBatrayCount(string content, string guideID)
	{
		string content2 = new Dictionary<string, string>
		{
			{
				"gamever",
				Singleton<VersionManager>.GetInstance().Version()
			},
			{
				"_account",
				ClientApplication.playerinfo.accid.ToString()
			},
			{
				"roleid",
				DataManager<PlayerBaseData>.GetInstance().RoleID.ToString()
			},
			{
				"job",
				DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString()
			},
			{
				"_sid",
				ClientApplication.playerinfo.serverID.ToString()
			},
			{
				"_platId",
				this.GetPlatform()
			},
			{
				"guide_id",
				guideID
			},
			{
				"guide_step",
				content
			},
			{
				"level",
				DataManager<PlayerBaseData>.GetInstance().Level.ToString()
			},
			{
				"vip",
				DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString()
			},
			{
				"_channel",
				Global.channelName
			}
		}.toJson();
		string url = string.Format("http://{0}/guide_battle", Global.STATISTIC_SERVER_ADDRESS);
		if (Global.Settings.isUsingSDK)
		{
			Http.SendPostRequest(url, content2, null);
		}
		else
		{
			Http.SendPostRequest(url, content2, null);
		}
	}

	// Token: 0x06019447 RID: 103495 RVA: 0x007FFCC4 File Offset: 0x007FE0C4
	private void Send(string content, StatType type = StatType.ROLE)
	{
		if (!this._isOpen())
		{
			return;
		}
		if (type == StatType.ROLE)
		{
			string content2 = new Dictionary<string, string>
			{
				{
					"gamever",
					Singleton<VersionManager>.GetInstance().Version()
				},
				{
					"_account",
					ClientApplication.playerinfo.accid.ToString()
				},
				{
					"roleid",
					DataManager<PlayerBaseData>.GetInstance().RoleID.ToString()
				},
				{
					"job",
					DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString()
				},
				{
					"_sid",
					ClientApplication.playerinfo.serverID.ToString()
				},
				{
					"_platId",
					this.GetPlatform()
				},
				{
					"guide_id",
					"1"
				},
				{
					"guide_step",
					content
				},
				{
					"level",
					DataManager<PlayerBaseData>.GetInstance().Level.ToString()
				},
				{
					"vip",
					DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString()
				},
				{
					"_channel",
					Global.channelName
				}
			}.toJson();
			string url = string.Format("http://{0}/guide_battle", Global.STATISTIC_SERVER_ADDRESS);
			if (Global.Settings.isUsingSDK)
			{
				Http.SendPostRequest(url, content2, null);
			}
			else
			{
				Http.SendPostRequest(url, content2, null);
			}
		}
		else if (type == StatType.DEVICE)
		{
			string content3 = new Dictionary<string, string>
			{
				{
					"id",
					SystemInfo.deviceUniqueIdentifier
				},
				{
					"key",
					content
				}
			}.toJson();
			string url2 = string.Format("http://{0}:59527/device", "121.41.17.47");
			if (Global.Settings.isUsingSDK)
			{
				Http.SendPostRequest(url2, content3, null);
			}
			else
			{
				Http.SendPostRequest(url2, content3, null);
			}
		}
		else if (type == StatType.ABNORMAL)
		{
			string url3 = string.Format("http://{0}", Global.STATISTIC2_SERVER_ADDRESS);
			Http.SendPostRequest(url3, content, null);
		}
	}

	// Token: 0x06019448 RID: 103496 RVA: 0x007FFEDE File Offset: 0x007FE2DE
	private void Save()
	{
	}

	// Token: 0x06019449 RID: 103497 RVA: 0x007FFEE0 File Offset: 0x007FE2E0
	private void Load()
	{
	}

	// Token: 0x0601944A RID: 103498 RVA: 0x007FFEE2 File Offset: 0x007FE2E2
	private string _getString(StatTaskType type)
	{
		if (type == StatTaskType.TASK_ACCEPT)
		{
			return "TaskAccept";
		}
		if (type == StatTaskType.TASK_FIND_ROAD)
		{
			return "TaskFindRoad";
		}
		if (type == StatTaskType.TASK_FINISH)
		{
			return "TaskFinish";
		}
		return string.Empty;
	}

	// Token: 0x0601944B RID: 103499 RVA: 0x007FFF0F File Offset: 0x007FE30F
	private string _getString(StatSkillPanelType type)
	{
		if (type == StatSkillPanelType.SKILL_LEVEL_UP)
		{
			return "LevelUp";
		}
		if (type == StatSkillPanelType.SKILL_LEVEL_DOWN)
		{
			return "LevelDown";
		}
		if (type == StatSkillPanelType.SKILL_CONFIG)
		{
			return "Config";
		}
		return string.Empty;
	}

	// Token: 0x0601944C RID: 103500 RVA: 0x007FFF3C File Offset: 0x007FE33C
	private string _getString(StatLevelChooseType type)
	{
		if (type == StatLevelChooseType.ENTER_SELECT)
		{
			return "EenterSelect";
		}
		if (type == StatLevelChooseType.CHOOSE_LEVEL)
		{
			return "ChooseLevel";
		}
		if (type == StatLevelChooseType.ENTER_LEVEL)
		{
			return "EnterBattle";
		}
		return string.Empty;
	}

	// Token: 0x0601944D RID: 103501 RVA: 0x007FFF6C File Offset: 0x007FE36C
	private string _getString(StatInBattleType type)
	{
		if (type == StatInBattleType.ENTER)
		{
			return "EnterBattle";
		}
		if (type == StatInBattleType.CLEAR_ROOM)
		{
			return "ClearRoom";
		}
		if (type == StatInBattleType.PASS_DOOR)
		{
			return "PassDoor";
		}
		if (type == StatInBattleType.FINISH)
		{
			return "FinishBattle";
		}
		if (type == StatInBattleType.USE_SKILL)
		{
			return "UseSkill";
		}
		if (type == StatInBattleType.CLICK_RESULT)
		{
			return "ClickResult";
		}
		if (type == StatInBattleType.CLICK_CARD)
		{
			return "ClickCard";
		}
		if (type == StatInBattleType.CLICK_RETURN)
		{
			return "ClickReturn";
		}
		return string.Empty;
	}

	// Token: 0x0601944E RID: 103502 RVA: 0x007FFFE5 File Offset: 0x007FE3E5
	private string _getString(StatPKType type)
	{
		if (type == StatPKType.ENTER)
		{
			return "EnterPKRoom";
		}
		if (type == StatPKType.MATCHING)
		{
			return "StartMatching";
		}
		if (type == StatPKType.RESULT)
		{
			return "Result";
		}
		return string.Empty;
	}

	// Token: 0x0601944F RID: 103503 RVA: 0x00800012 File Offset: 0x007FE412
	private string _getString(StatSystemType type)
	{
		if (type == StatSystemType.NONE)
		{
			return string.Empty;
		}
		if (type == StatSystemType.LOGIN)
		{
			return "Login";
		}
		if (type == StatSystemType.TOWN)
		{
			return "Town";
		}
		if (type == StatSystemType.BATTLE)
		{
			return "Battle";
		}
		return string.Empty;
	}

	// Token: 0x04012223 RID: 74275
	private bool clientInfoSended;

	// Token: 0x04012224 RID: 74276
	public DataStatistics dataStatistics = new DataStatistics();

	// Token: 0x04012225 RID: 74277
	private List<GameStatisticManager.StatData> contents = new List<GameStatisticManager.StatData>();

	// Token: 0x04012226 RID: 74278
	private int count;

	// Token: 0x0200463B RID: 17979
	public class StatData
	{
		// Token: 0x06019450 RID: 103504 RVA: 0x0080004C File Offset: 0x007FE44C
		public StatData(string c, string t)
		{
			this.content = c;
			this.time = t;
		}

		// Token: 0x04012227 RID: 74279
		public string content;

		// Token: 0x04012228 RID: 74280
		public string time;
	}

	// Token: 0x0200463C RID: 17980
	public enum DialogOperateType
	{
		// Token: 0x0401222A RID: 74282
		DOT_NEXT,
		// Token: 0x0401222B RID: 74283
		DOT_COMPLETE,
		// Token: 0x0401222C RID: 74284
		DOT_JUMPOVER,
		// Token: 0x0401222D RID: 74285
		DOT_STAR
	}

	// Token: 0x0200463D RID: 17981
	public enum DialogFinishType
	{
		// Token: 0x0401222F RID: 74287
		DFT_FINISH,
		// Token: 0x04012230 RID: 74288
		DFT_RESTAR,
		// Token: 0x04012231 RID: 74289
		DFT_NEWCREATE
	}

	// Token: 0x0200463E RID: 17982
	public class Ping
	{
		// Token: 0x04012232 RID: 74290
		public int S;

		// Token: 0x04012233 RID: 74291
		public int A;

		// Token: 0x04012234 RID: 74292
		public int B;

		// Token: 0x04012235 RID: 74293
		public int C;
	}

	// Token: 0x0200463F RID: 17983
	public class Fps
	{
		// Token: 0x04012236 RID: 74294
		public int S;

		// Token: 0x04012237 RID: 74295
		public int A;

		// Token: 0x04012238 RID: 74296
		public int B;
	}

	// Token: 0x02004640 RID: 17984
	public class BattleStatistic
	{
		// Token: 0x04012239 RID: 74297
		public string roleId;

		// Token: 0x0401223A RID: 74298
		public string roleLv;

		// Token: 0x0401223B RID: 74299
		public string account;

		// Token: 0x0401223C RID: 74300
		public string teamJobId;

		// Token: 0x0401223D RID: 74301
		public string JobId;

		// Token: 0x0401223E RID: 74302
		public string sid;

		// Token: 0x0401223F RID: 74303
		public string platId;

		// Token: 0x04012240 RID: 74304
		public string vip;

		// Token: 0x04012241 RID: 74305
		public string channel;

		// Token: 0x04012242 RID: 74306
		public string deviceId;

		// Token: 0x04012243 RID: 74307
		public string ip;

		// Token: 0x04012244 RID: 74308
		public string ip_ext;

		// Token: 0x04012245 RID: 74309
		public string gameVersion;

		// Token: 0x04012246 RID: 74310
		public string netType;

		// Token: 0x04012247 RID: 74311
		public string mfr;

		// Token: 0x04012248 RID: 74312
		public string model;

		// Token: 0x04012249 RID: 74313
		public string os_ver;

		// Token: 0x0401224A RID: 74314
		public GameStatisticManager.Ping ping = new GameStatisticManager.Ping();

		// Token: 0x0401224B RID: 74315
		public GameStatisticManager.Fps fps = new GameStatisticManager.Fps();

		// Token: 0x0401224C RID: 74316
		public string exeCmdRecentDelay;

		// Token: 0x0401224D RID: 74317
		public string exeCmdAvarageDelay;

		// Token: 0x0401224E RID: 74318
		public string exeCmdMaxDelay;

		// Token: 0x0401224F RID: 74319
		public string recvCmdRecentDelay;

		// Token: 0x04012250 RID: 74320
		public string recvCmdAvarageDelay;

		// Token: 0x04012251 RID: 74321
		public string recvCmdMaxDelay;
	}

	// Token: 0x02004641 RID: 17985
	public enum DungeonsType
	{
		// Token: 0x04012253 RID: 74323
		NORMAL,
		// Token: 0x04012254 RID: 74324
		YUANGU,
		// Token: 0x04012255 RID: 74325
		HELL = 8
	}
}
