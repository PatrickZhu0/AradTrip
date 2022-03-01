using System;
using System.Collections.Generic;
using Battle;
using LitJson;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001069 RID: 4201
	public sealed class PlayerBaseData : DataManager<PlayerBaseData>
	{
		// Token: 0x06009D9B RID: 40347 RVA: 0x001F17EC File Offset: 0x001EFBEC
		public PlayerBaseData()
		{
			for (int i = 0; i < 15; i++)
			{
				this.PackTotalSize.Add(0);
			}
		}

		// Token: 0x06009D9C RID: 40348 RVA: 0x001F193F File Offset: 0x001EFD3F
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.PlayerBaseData;
		}

		// Token: 0x17001955 RID: 6485
		// (get) Token: 0x06009D9D RID: 40349 RVA: 0x001F1943 File Offset: 0x001EFD43
		// (set) Token: 0x06009D9E RID: 40350 RVA: 0x001F194B File Offset: 0x001EFD4B
		public bool isNotify
		{
			get
			{
				return this.m_bNotify;
			}
			set
			{
				this.m_bNotify = value;
			}
		}

		// Token: 0x17001956 RID: 6486
		// (get) Token: 0x06009D9F RID: 40351 RVA: 0x001F1954 File Offset: 0x001EFD54
		// (set) Token: 0x06009DA0 RID: 40352 RVA: 0x001F195C File Offset: 0x001EFD5C
		public bool isWear
		{
			get
			{
				return this.m_bIsWear;
			}
			set
			{
				this.m_bIsWear = value;
			}
		}

		// Token: 0x17001957 RID: 6487
		// (get) Token: 0x06009DA1 RID: 40353 RVA: 0x001F1965 File Offset: 0x001EFD65
		// (set) Token: 0x06009DA2 RID: 40354 RVA: 0x001F196D File Offset: 0x001EFD6D
		public bool IsExpand
		{
			get
			{
				return this.m_bIsExpand;
			}
			set
			{
				this.m_bIsExpand = value;
			}
		}

		// Token: 0x17001958 RID: 6488
		// (get) Token: 0x06009DA3 RID: 40355 RVA: 0x001F1976 File Offset: 0x001EFD76
		// (set) Token: 0x06009DA4 RID: 40356 RVA: 0x001F197E File Offset: 0x001EFD7E
		public bool bIsSetPreferenceRole
		{
			get
			{
				return this.m_bIsSetPreferenceRole;
			}
			set
			{
				this.m_bIsSetPreferenceRole = value;
			}
		}

		// Token: 0x17001959 RID: 6489
		// (get) Token: 0x06009DA5 RID: 40357 RVA: 0x001F1987 File Offset: 0x001EFD87
		// (set) Token: 0x06009DA6 RID: 40358 RVA: 0x001F198F File Offset: 0x001EFD8F
		public bool bIsCancelPreferenceRole
		{
			get
			{
				return this.m_bIsCancelPreferenceRole;
			}
			set
			{
				this.m_bIsCancelPreferenceRole = value;
			}
		}

		// Token: 0x1700195A RID: 6490
		// (get) Token: 0x06009DA7 RID: 40359 RVA: 0x001F1998 File Offset: 0x001EFD98
		public BeFightBuffManager BuffMgr
		{
			get
			{
				return this.buffMgr;
			}
		}

		// Token: 0x1700195B RID: 6491
		// (get) Token: 0x06009DA8 RID: 40360 RVA: 0x001F19A0 File Offset: 0x001EFDA0
		public int PlayerMaxLv
		{
			get
			{
				return this.mPlayerMaxLv;
			}
		}

		// Token: 0x1700195C RID: 6492
		// (get) Token: 0x06009DA9 RID: 40361 RVA: 0x001F19A8 File Offset: 0x001EFDA8
		// (set) Token: 0x06009DAA RID: 40362 RVA: 0x001F19B0 File Offset: 0x001EFDB0
		public bool IsSelectedPerfectWashingRollTab
		{
			get
			{
				return this.m_bIsSelectedPerfectWashingRollTab;
			}
			set
			{
				this.m_bIsSelectedPerfectWashingRollTab = value;
			}
		}

		// Token: 0x06009DAB RID: 40363 RVA: 0x001F19BC File Offset: 0x001EFDBC
		private void InitMainPlayerData()
		{
			RoleInfo selectRoleBaseInfoByLogin = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin();
			if (selectRoleBaseInfoByLogin == null)
			{
				Logger.LogError("_OnSyncPlayerMain ==>> roleInfo is null!");
			}
			this.RoleID = selectRoleBaseInfoByLogin.roleId;
			this.mPlayerMaxLv = Utility.GetPlayerMaxLevel();
		}

		// Token: 0x06009DAC RID: 40364 RVA: 0x001F19FB File Offset: 0x001EFDFB
		public static bool IsJewelry(ItemTable.eSubType eSubType)
		{
			return eSubType == ItemTable.eSubType.RING || eSubType == ItemTable.eSubType.NECKLASE || eSubType == ItemTable.eSubType.BRACELET;
		}

		// Token: 0x06009DAD RID: 40365 RVA: 0x001F1A1B File Offset: 0x001EFE1B
		public static bool IsArmy(ItemTable.eSubType eSubType)
		{
			switch (eSubType)
			{
			case ItemTable.eSubType.HEAD:
			case ItemTable.eSubType.CHEST:
			case ItemTable.eSubType.BELT:
			case ItemTable.eSubType.LEG:
			case ItemTable.eSubType.BOOT:
				return true;
			default:
				return false;
			}
		}

		// Token: 0x06009DAE RID: 40366 RVA: 0x001F1A44 File Offset: 0x001EFE44
		public static bool IsJobChanged()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			return tableItem != null && tableItem.JobType == 1;
		}

		// Token: 0x06009DAF RID: 40367 RVA: 0x001F1A87 File Offset: 0x001EFE87
		public static bool IsWeapon(ItemTable.eSubType eSubType)
		{
			return eSubType == ItemTable.eSubType.WEAPON;
		}

		// Token: 0x06009DB0 RID: 40368 RVA: 0x001F1A90 File Offset: 0x001EFE90
		public override void Initialize()
		{
			this.InitMainPlayerData();
			NetProcess.AddMsgHandler(500601U, new Action<MsgDATA>(this._OnSyncSelfObject));
			this.m_bNotify = true;
			this.m_bIsWear = false;
			this.m_bIsExpand = false;
			this.m_bIsSetPreferenceRole = false;
			this.m_bIsCancelPreferenceRole = false;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
		}

		// Token: 0x06009DB1 RID: 40369 RVA: 0x001F1B20 File Offset: 0x001EFF20
		public override void Clear()
		{
			NetProcess.RemoveMsgHandler(500601U, new Action<MsgDATA>(this._OnSyncSelfObject));
			this.AxisScale = 10000f;
			this.bInitializeTownSystem = false;
			this.RoleID = 0UL;
			this.ZoneID = -1;
			this.Name = string.Empty;
			this.Level = 0;
			this.Exp = 0UL;
			this.CurExp = 0UL;
			this.IsFlyUpState = false;
			this.Sex = 0;
			this.HP = 0;
			this.MaxHP = 0;
			this.chiji_hp = 0;
			this.chiji_mp = 0;
			this.Pos = Vector3.zero;
			this.FaceRight = false;
			this.MoveSpeedRate = 0f;
			this.Gold = 0UL;
			this.BindGold = 0UL;
			this.Ticket = 0UL;
			this.BindTicket = 0UL;
			this.CreditTicketOwnerBySelf = 0U;
			this.CreditTicketGetInMonth = 0U;
			this.GoldJarScore = 0UL;
			this.MagicJarScore = 0UL;
			this.MonthCardLv = 0U;
			this.VipLevel = -1;
			this.CurVipLvRmb = 0;
			this.AliveCoin = 0UL;
			this.WarriorSoul = 0U;
			this.pkPoints = 0U;
			this.pkMatchScore = 0U;
			this.uiPkCoin = 0U;
			this.fatigue = 0;
			this.MaxFatigue = 0;
			this.PackBaseSize = 0;
			this.FashionPackBaseSize = 0;
			this.TitlePackBaseSize = 0;
			this.PackAddSize.Clear();
			this.PackTotalSize.Clear();
			for (int i = 0; i < 15; i++)
			{
				this.PackTotalSize.Add(0);
			}
			this.AccountStorageSize = 50;
			this._ChijiScore = 0U;
			this.iTittle = 0U;
			this._achievementScore = 0;
			this._accountAchievementScore = 0;
			this._roleAchievementScore = 0;
			this.isRoleEnterGame = false;
			this._dayChargeNum = 0U;
			this.AwakeState = -1;
			this.bNeedShowAwakeFrame = false;
			this.NextUnlockFunc = 0;
			this.SP = 0U;
			this.SP2 = 0U;
			this.pvpSP2 = 0U;
			this.pvpSP = 0U;
			this.m_jobTableID = Global.Settings.iSingleCharactorID;
			this.PreChangeJobTableID = 0;
			this.RoleCreateTime = 0U;
			this.eChangeJobState = ChangeJobState.JobState_Null;
			this.DeathTowerWipeoutEndTime = 0U;
			this.bIsForceGuide = false;
			this.bIsWeakGuide = false;
			this.bIsInitNewbieGuideData = true;
			this.GuideFinishMission = 0;
			this.ResistMagicValue = 0;
			this.avatar = null;
			this.isShowFashionWeapon = false;
			this.bPkClickVipCharge = false;
			this.NewbieGuideSaveBoot = 0;
			this.NewbieGuideCurSaveOrder = 0;
			this.NewbieGuideWeakGuideList.Clear();
			this.AuctionLastRefreshTime = 0U;
			this.AddAuctionFieldsNum = 0;
			this.GoodTeacherValue = 0UL;
			this.TotalEquipScore = 0U;
			if (this.UnlockFuncList != null)
			{
				this.UnlockFuncList.Clear();
			}
			if (this.NewUnlockFuncList != null)
			{
				this.NewUnlockFuncList.Clear();
			}
			if (this.NewUnlockNotPlayFuncList != null)
			{
				this.NewUnlockNotPlayFuncList.Clear();
			}
			if (this.UnlockAreaList != null)
			{
				this.UnlockAreaList.Clear();
			}
			if (this.m_activeJobTableIDs != null)
			{
				this.m_activeJobTableIDs.Clear();
			}
			if (this.buffList != null)
			{
				this.buffList.Clear();
			}
			this.buffList = new List<Battle.DungeonBuff>();
			if (this.removedBuffList != null)
			{
				this.removedBuffList.Clear();
			}
			this.removedBuffList = new List<Battle.DungeonBuff>();
			if (this.mails != null)
			{
				this.mails.ClearData();
			}
			this.mails = new GameMailData();
			this.BuffMgr.Clear();
			if (this.PkStatisticsData != null)
			{
				this.PkStatisticsData.Clear();
			}
			this.PkStatisticsData = new Dictionary<byte, PkStatistic>();
			if (this.MallItemData != null)
			{
				this.MallItemData.Clear();
			}
			this.guildName = string.Empty;
			this.eGuildDuty = EGuildDuty.Invalid;
			this.guildDuty = 0;
			this.guildContribution = 0;
			this.guildBattleTimes = 0;
			this.guildBattleScore = 0;
			this.guildBattleRewardMask = new GuildBattleMaskProperty();
			this.MissionScore = 0U;
			this.BudoStatus = 0;
			if (this.potionSets != null)
			{
				this.potionSets.Clear();
			}
			this.tmpPostionSets.Clear();
			this.Announcement = string.Empty;
			this.getPupil = true;
			this.m_bNotify = true;
			this.m_bIsWear = false;
			this.m_bIsExpand = false;
			this.appointmentOccu = 0;
			this.WeaponLeaseTicket = 0UL;
			this.IntergralMallTicket = 0UL;
			this.gameOptions = 0U;
			this.adventureCoin = 0U;
			this.ChanllengeScore = 0;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
		}

		// Token: 0x06009DB2 RID: 40370 RVA: 0x001F1FB0 File Offset: 0x001F03B0
		public override void OnApplicationStart()
		{
			FileArchiveAccessor.LoadFileInPersistentFileArchive(this.m_kSavePath, out this.jsonText);
			if (this.jsonText == null)
			{
				FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, string.Empty);
				this.jsonText = string.Empty;
			}
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData != null)
			{
				if (!jsonData.ContainsKey(PlayerBaseData.PotionSlotType.SlotMain.ToString()))
				{
					this.SetPotionPercent(PlayerBaseData.PotionSlotType.SlotMain, 50, true);
				}
				if (!jsonData.ContainsKey(PlayerBaseData.PotionSlotType.SlotExtend1.ToString()))
				{
					this.SetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend1, 50, true);
				}
				if (!jsonData.ContainsKey(PlayerBaseData.PotionSlotType.SlotExtend2.ToString()))
				{
					this.SetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend2, 50, true);
				}
				if (!jsonData.ContainsKey("PotionSlotMainSwitch"))
				{
					this.SetPotionSlotMainSwitchOn(false, true, "PotionSlotMainSwitch");
				}
			}
		}

		// Token: 0x06009DB3 RID: 40371 RVA: 0x001F2091 File Offset: 0x001F0491
		public void ClearChijiData()
		{
			this.SP = 0U;
			this.pvpSP = 0U;
		}

		// Token: 0x06009DB4 RID: 40372 RVA: 0x001F20A1 File Offset: 0x001F04A1
		private void OnCountValueChanged(UIEvent uiEvent)
		{
			this.AppoinmentCoin = (ulong)DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_COIN_NUM);
		}

		// Token: 0x06009DB5 RID: 40373 RVA: 0x001F20BC File Offset: 0x001F04BC
		public void CheckNameValid(ulong a_guid, string a_strName)
		{
			SceneCheckChangeNameReq cmd = new SceneCheckChangeNameReq
			{
				newName = a_strName
			};
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneCheckChangeNameReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneCheckChangeNameRes>(delegate(SceneCheckChangeNameRes msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("player_change_name_ask", a_strName), delegate()
					{
						this.ChangeName(a_guid, a_strName);
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildCommonModifyFrame>(null, false);
					}, null, 0f, false);
				}
			}, true, 15f, null);
		}

		// Token: 0x06009DB6 RID: 40374 RVA: 0x001F2128 File Offset: 0x001F0528
		public void ChangeName(ulong a_guid, string a_strName)
		{
			SceneChangeNameReq cmd = new SceneChangeNameReq
			{
				itemUid = a_guid,
				newName = a_strName
			};
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneChangeNameReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneChangeNameRes>(delegate(SceneChangeNameRes msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("player_change_name_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
			}, true, 15f, null);
		}

		// Token: 0x06009DB7 RID: 40375 RVA: 0x001F2189 File Offset: 0x001F0589
		private void _OnInitBaseData(MsgDATA msg)
		{
			this._OnSyncSelfObject(msg);
		}

		// Token: 0x06009DB8 RID: 40376 RVA: 0x001F2194 File Offset: 0x001F0594
		private void _OnSyncSelfObject(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncPlayerMain ==>> msg is nil");
				return;
			}
			int num = 0;
			SceneObject sceneObject = SceneObjectDecoder.DecodeSelfSceneObject(msg.bytes, ref num, msg.bytes.Length);
			for (int i = 0; i < sceneObject.dirtyFields.Count; i++)
			{
				this._UpdatePlayerData(sceneObject, sceneObject.dirtyFields[i]);
			}
		}

		// Token: 0x06009DB9 RID: 40377 RVA: 0x001F21FC File Offset: 0x001F05FC
		private void _UpdatePlayerData(SceneObject msgData, int dirtyField)
		{
			switch (dirtyField)
			{
			case 86:
				this.dayChargeNum = msgData.dayChargeNum;
				TitleComponent.OnChangedTittle(0, (int)this.iTittle);
				break;
			default:
				switch (dirtyField)
				{
				case 29:
					this.HP = (int)msgData.hp;
					break;
				case 30:
					this.MaxHP = (int)msgData.maxHp;
					break;
				default:
					switch (dirtyField)
					{
					case 1:
						this.Name = msgData.name;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NameChanged, null, null, null, null);
						TitleComponent.OnChangeName(0, DataManager<PlayerBaseData>.GetInstance().Name);
						break;
					case 2:
					{
						bool flag = false;
						if (this.Level == 0)
						{
							flag = true;
						}
						int level = (int)this.Level;
						this.Level = msgData.level;
						this.CurExp = 0UL;
						this.Exp = 0UL;
						this.CalRoleTotalExp();
						DataManager<ItemDataManager>.GetInstance().OnLevelChanged(level);
						DataManager<SkillDataManager>.GetInstance().UpdatePassiveSkillData();
						if (!flag)
						{
							DataManager<SkillDataManager>.GetInstance().UpdateNewSkill();
						}
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.LevelChanged, null, null, null, null);
						GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.LevelChanged, null, null, null, null);
						TitleComponent.OnChangedLv(0, (int)this.Level);
						ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
						if (!flag && clientSystemGameBattle == null)
						{
							this.bLevelUpChange = true;
						}
						break;
					}
					case 3:
						this.CurExp = msgData.exp;
						this.Exp = 0UL;
						this.CalRoleTotalExp();
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ExpChanged, null, null, null, null);
						break;
					default:
						switch (dirtyField)
						{
						case 77:
							this.NextUnlockFunc = msgData.funcNotify;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NextFuncOpen, null, null, null, null);
							break;
						default:
							if (dirtyField == 72)
							{
								this.iTittle = msgData.title;
								TitleComponent.OnChangedTittle(0, (int)this.iTittle);
							}
							break;
						case 80:
						{
							ClientSystemGameBattle clientSystemGameBattle2 = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
							if (clientSystemGameBattle2 == null)
							{
								if (this.UnlockFuncList.Count <= 0)
								{
								}
								this.UnlockFuncList.Clear();
								this.UnlockAreaList.Clear();
								Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<FunctionUnLock>();
								foreach (KeyValuePair<int, object> keyValuePair in table)
								{
									FunctionUnLock functionUnLock = keyValuePair.Value as FunctionUnLock;
									if (functionUnLock.IsOpen)
									{
										if (msgData.funcFlag.CheckMask((uint)functionUnLock.ID))
										{
											if (functionUnLock.BindType != FunctionUnLock.eBindType.BT_AccBind)
											{
												if (functionUnLock.Type == FunctionUnLock.eType.Area)
												{
													this.UnlockAreaList.Add(functionUnLock.AreaID);
												}
												else if (functionUnLock.Type == FunctionUnLock.eType.Func)
												{
													this.UnlockFuncList.Add(functionUnLock.ID);
												}
											}
										}
									}
								}
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateUnlockFunc, null, null, null, null);
							}
							break;
						}
						}
						break;
					case 5:
						this.Sex = (int)msgData.sex;
						break;
					case 6:
					{
						bool flag2 = false;
						if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle))
						{
							IList<int> nextJobsIDByCurJobID = Singleton<TableManager>.GetInstance().GetNextJobsIDByCurJobID(this.JobTableID);
							if (nextJobsIDByCurJobID != null)
							{
								for (int i = 0; i < nextJobsIDByCurJobID.Count; i++)
								{
									if ((int)msgData.occu == nextJobsIDByCurJobID[i])
									{
										flag2 = true;
										break;
									}
								}
							}
						}
						this.JobTableID = (int)msgData.occu;
						if (flag2)
						{
							DataManager<SkillDataManager>.GetInstance().LastSeeSkillLv = 1;
						}
						DataManager<SkillDataManager>.GetInstance().InitSkillData((int)msgData.level);
						DataManager<SkillDataManager>.GetInstance().UpdatePassiveSkillData();
						if (flag2)
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.JobIDChanged, null, null, null, null);
						}
						else
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.JobIDReset, null, null, null, null);
						}
						DataManager<ItemDataManager>.GetInstance().OnJobChanged();
						DataManager<JarDataManager>.GetInstance().OnJobChanged();
						break;
					}
					}
					break;
				case 32:
					this.MoveSpeedRate = (float)msgData.moveSpeed / (float)GlobalLogic.VALUE_1000;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MoveSpeedChanged, null, null, null, null);
					break;
				case 36:
					if (msgData.skillMgr != null)
					{
						bool flag3 = false;
						ClientSystemGameBattle clientSystemGameBattle3 = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
						if (clientSystemGameBattle3 != null)
						{
							flag3 = true;
						}
						if (!flag3)
						{
							DataManager<SkillDataManager>.GetInstance().CurPVESKillPage = (EPVESkillPage)msgData.skillMgr.currentPage;
							if (msgData.skillMgr.pageCnt >= 2U)
							{
								DataManager<SkillDataManager>.GetInstance().PVESkillPage2IsUnlock = true;
							}
							else
							{
								DataManager<SkillDataManager>.GetInstance().PVESkillPage2IsUnlock = false;
							}
							DataManager<SkillDataManager>.GetInstance().UpdateSkillData(msgData.skillMgr, SkillConfigType.SKILL_CONFIG_PVE);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillListChanged, null, null, null, null);
						}
					}
					break;
				case 37:
				{
					ClientSystemGameBattle clientSystemGameBattle4 = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
					if (msgData.buffList != null)
					{
						List<Battle.DungeonBuff> list = msgData.buffList;
						if (clientSystemGameBattle4 != null)
						{
							List<int> list2 = new List<int>();
							for (int j = 0; j < this.buffMgr.Count(); j++)
							{
								BeFightBuff beFightBuff = this.buffMgr.Get(j);
								bool flag4 = false;
								for (int k = 0; k < list.Count; k++)
								{
									if (list[k].uid == beFightBuff.GUID)
									{
										flag4 = true;
										break;
									}
								}
								if (!flag4)
								{
									list2.Add(j);
								}
							}
							for (int l = list2.Count - 1; l >= 0; l--)
							{
								BeFightBuff beFightBuff2 = this.buffMgr.Get(list2[l]);
								if (beFightBuff2 != null && clientSystemGameBattle4 != null && clientSystemGameBattle4.MainPlayer != null)
								{
									if (beFightBuff2.BuffID == 402000003)
									{
										UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PoisonStatChange, false, null, null, null);
									}
									beFightBuff2.Finish(clientSystemGameBattle4.MainPlayer.GraphicActor);
								}
								this.buffMgr.RemoveAt(list2[l]);
							}
						}
						for (int m = 0; m < list.Count; m++)
						{
							Battle.DungeonBuff curBuff = list[m];
							Battle.DungeonBuff dungeonBuff = this.buffList.Find((Battle.DungeonBuff buff) => buff.uid == curBuff.uid);
							if (dungeonBuff != null)
							{
								dungeonBuff.lefttime = curBuff.duration;
							}
							else
							{
								BuffTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffTable>(curBuff.id, string.Empty, string.Empty);
								if (tableItem != null)
								{
									curBuff.type = (Battle.DungeonBuff.eBuffDurationType)tableItem.durationType;
									curBuff.duration = (float)tableItem.duration;
									this.buffList.Add(curBuff);
								}
							}
							if (clientSystemGameBattle4 != null)
							{
								BeFightBuff buffByGUID = this.buffMgr.GetBuffByGUID(curBuff.uid);
								if (buffByGUID != null)
								{
									buffByGUID.Refresh(curBuff.lefttime, curBuff.overlay);
								}
								else
								{
									BeFightBuff beFightBuff3 = this.buffMgr.AddBuff(curBuff.id, curBuff.uid, 0UL, curBuff.lefttime, curBuff.overlay);
									if (curBuff.id == 402000003)
									{
										UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PoisonStatChange, true, null, null, null);
									}
									if (beFightBuff3 != null && clientSystemGameBattle4 != null && clientSystemGameBattle4.MainPlayer != null)
									{
										beFightBuff3.Start(clientSystemGameBattle4.MainPlayer.GraphicActor);
									}
								}
							}
						}
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BuffListChanged, null, null, null, null);
					}
					break;
				}
				case 38:
					DataManager<ItemDataManager>.GetInstance().SetupItemCDs(msgData.itemCd);
					break;
				case 39:
					this.Gold = (ulong)msgData.gold;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GoldChanged, null, null, null, null);
					break;
				case 40:
					this.BindGold = (ulong)msgData.bindGold;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BindGoldChanged, null, null, null, null);
					break;
				case 41:
					this.Ticket = (ulong)msgData.point;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TicketChanged, null, null, null, null);
					break;
				case 42:
					this.BindTicket = (ulong)msgData.bindPoint;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BindTicketChanged, null, null, null, null);
					break;
				case 45:
					this.PackBaseSize = (int)msgData.packSize;
					this.PackTotalSize.Clear();
					for (int n = 0; n < 15; n++)
					{
						int item = this.PackBaseSize;
						if (n == 5 || n == 14)
						{
							item = this.FashionPackBaseSize;
						}
						else if (n == 10)
						{
							item = this.TitlePackBaseSize;
						}
						this.PackTotalSize.Add(item);
						if (n < this.PackAddSize.Count)
						{
							List<int> packTotalSize;
							int index;
							(packTotalSize = this.PackTotalSize)[index = n] = packTotalSize[index] + this.PackAddSize[n];
						}
					}
					DataManager<ItemDataManager>.GetInstance().NotifyPackageFullState();
					break;
				case 46:
					this.AccountStorageSize = (int)msgData.storageSize;
					break;
				case 51:
					break;
				case 53:
					if (msgData.skillBars.bar.Length > 0)
					{
						DataManager<SkillDataManager>.GetInstance().UpdateSkillBar(msgData.skillBars, SkillConfigType.SKILL_CONFIG_PVE);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillBarChanged, null, null, null, null);
					}
					break;
				case 54:
					this.gameOptions = msgData.gameOptions;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateGameOptions, null, null, null, null);
					break;
				}
				break;
			case 89:
				this.ZoneID = (int)msgData.zoneId;
				break;
			case 91:
				this.Pos = new Vector3(msgData.pos.x / this.AxisScale, 0f, msgData.pos.y / this.AxisScale);
				break;
			case 92:
				this.FaceRight = (msgData.dir.faceRight >= 1);
				break;
			case 93:
				if (msgData.sp != null && msgData.sp.spList != null && msgData.sp.spList.Length >= 2)
				{
					this.SP = msgData.sp.spList[0];
					this.SP2 = msgData.sp.spList[1];
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SpChanged, null, null, null, null);
					DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Skill);
				}
				break;
			case 94:
				this.AwakeState = (int)msgData.awaken;
				break;
			case 97:
				this.fatigue = msgData.fatigue.fatigue;
				this.MaxFatigue = msgData.fatigue.maxFatigue;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FatigueChanged, null, null, null, null);
				break;
			case 98:
				this.WarriorSoul = msgData.warriorSoul;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WarriorSoulChanged, null, null, null, null);
				break;
			case 99:
				this.pkMatchScore = msgData.matchScore;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchScoreChanged, null, null, null, null);
				break;
			case 101:
			{
				Dictionary<string, CounterInfo>.Enumerator enumerator2 = msgData.counterMgr.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					CountDataManager instance = DataManager<CountDataManager>.GetInstance();
					KeyValuePair<string, CounterInfo> keyValuePair2 = enumerator2.Current;
					string name = keyValuePair2.Value.name;
					KeyValuePair<string, CounterInfo> keyValuePair3 = enumerator2.Current;
					instance.SetCount(name, keyValuePair3.Value.value);
				}
				this.AppoinmentCoin = (ulong)DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_COIN_NUM);
				DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.CounterChanged, null, null, null, null);
				break;
			}
			case 103:
				this.uiPkCoin = msgData.pkCoin;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkCoinChanged, null, null, null, null);
				break;
			case 104:
			{
				if (msgData.avatar == null)
				{
					Logger.LogErrorFormat("进城镇收到服务器协议数据: msgData.avatar == null, 协议解析出错", new object[0]);
				}
				bool flag5 = DataManager<PackageDataManager>.GetInstance().IsPlayerAvatarNeedChanged(this.avatar, msgData.avatar);
				this.avatar = msgData.avatar;
				if (!DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToTown && !DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare && !DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToChijiScene)
				{
					if (this.avatar != null && flag5)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AvatarChanged, null, null, null, null);
					}
				}
				break;
			}
			case 105:
				this.AliveCoin = (ulong)msgData.aliveCoin;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AliveCoinChanged, null, null, null, null);
				break;
			case 106:
				this.VipLevel = (int)msgData.vip.level;
				this.CurVipLvRmb = (int)msgData.vip.exp;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerVipLvChanged, null, null, null, null);
				break;
			case 107:
				this.RoleCreateTime = msgData.createTime;
				break;
			case 108:
			{
				this.NewbieGuideSaveBoot = (int)msgData.newBoot;
				if (this.NewbieGuideSaveBoot <= 0)
				{
					this.NewbieGuideSaveBoot = 100000;
				}
				NewbieGuideTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(this.NewbieGuideSaveBoot, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogErrorFormat("Receive Server NewbieGuide Save ID error. NewbieGuideSaveBoot = {0}.", new object[]
					{
						this.NewbieGuideSaveBoot
					});
				}
				else
				{
					this.NewbieGuideCurSaveOrder = tableItem2.Order;
				}
				this.bIsForceGuide = true;
				this.IsFlyUpState = false;
				if (this.bIsForceGuide && this.bIsWeakGuide && this.bIsInitNewbieGuideData)
				{
					GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.InitNewbieGuideBootData, null, null, null, null);
					this.bIsInitNewbieGuideData = false;
				}
				break;
			}
			case 109:
				this.DeathTowerWipeoutEndTime = msgData.deathTowerWipeoutEndTime;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnDeadTowerWipeoutTimeChange, null, null, null, null);
				break;
			case 110:
				this.eGuildDuty = DataManager<GuildDataManager>.GetInstance().GetClientDuty(msgData.guildPost);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataGuildUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				this.guildDuty = msgData.guildPost;
				TitleComponent.OnChangeGuildDuty(0, msgData.guildPost);
				if (this.eGuildDuty == EGuildDuty.Invalid)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatGuildLeave, null, null, null, null);
				}
				else if (this.eGuildDuty == EGuildDuty.Normal)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatGuildJoin, null, null, null, null);
				}
				break;
			case 111:
				DataManager<PlayerBaseData>.GetInstance().guildContribution = (int)msgData.guildContri;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataGuildUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				break;
			case 113:
				DataManager<RedPointDataManager>.GetInstance().UpdateRedPoints(msgData.redPoint);
				break;
			case 114:
				this.guildName = msgData.guildName;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataGuildUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				TitleComponent.OnChangeGuildName(0, DataManager<PlayerBaseData>.GetInstance().guildName);
				break;
			case 115:
				this.guildBattleTimes = (int)msgData.guildBattleNumber;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataGuildUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				break;
			case 116:
				this.guildBattleScore = (int)msgData.guildBattleScore;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataGuildUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				break;
			case 117:
				this.guildBattleRewardMask = msgData.guildBattleMask;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataGuildUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				break;
			case 118:
				this.MissionScore = msgData.datilyTaskScore;
				break;
			case 119:
				this.DailyTaskMaskProperty = msgData.dailyTaskMask;
				break;
			case 120:
				this.BudoStatus = (int)msgData.wudaoStatus;
				break;
			case 121:
				this.MonthCardLv = msgData.monthCardExpireTime;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMonthCardUpdate, null, null, null, null);
				break;
			case 123:
				DataManager<SeasonDataManager>.GetInstance().seasonLevel = (int)msgData.seasonLevel;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataSeasonUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				break;
			case 124:
				DataManager<SeasonDataManager>.GetInstance().seasonStar = (int)msgData.seasonStar;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataSeasonUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				break;
			case 125:
				DataManager<SeasonDataManager>.GetInstance().seasonUplevelRecords = msgData.seasonUplevelRecord;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataSeasonUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				break;
			case 126:
				DataManager<SeasonDataManager>.GetInstance().seasonAttrID = (int)msgData.seasonAttr;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataSeasonUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				break;
			case 128:
				this.AuctionLastRefreshTime = msgData.auctionRefreshTime;
				break;
			case 129:
				this.AddAuctionFieldsNum = (int)msgData.auctionAdditionBooth;
				break;
			case 130:
				this.GoldJarScore = (ulong)msgData.goldJarPoint;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GoldJarScoreChanged, null, null, null, null);
				break;
			case 131:
				this.MagicJarScore = (ulong)msgData.magJarPoint;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MagicJarScoreChanged, null, null, null, null);
				break;
			case 132:
			{
				Dictionary<int, object> table2 = Singleton<TableManager>.GetInstance().GetTable<NewbieGuideTable>();
				for (int num = 2; num <= table2.Count; num++)
				{
					if (msgData.bootFlag.CheckMask((uint)num))
					{
						bool flag6 = false;
						for (int num2 = 0; num2 < this.NewbieGuideWeakGuideList.Count; num2++)
						{
							if (this.NewbieGuideWeakGuideList[num2] == num)
							{
								flag6 = true;
								break;
							}
						}
						if (!flag6)
						{
							this.NewbieGuideWeakGuideList.Add(num);
						}
					}
				}
				this.bIsWeakGuide = true;
				if (this.bIsForceGuide && this.bIsWeakGuide && this.bIsInitNewbieGuideData)
				{
					GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.InitNewbieGuideBootData, null, null, null, null);
					this.bIsInitNewbieGuideData = false;
				}
				break;
			}
			case 133:
				DataManager<SeasonDataManager>.GetInstance().seasonExp = (int)msgData.seasonExp;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataSeasonUpdated, (SceneObjectAttr)dirtyField, null, null, null);
				break;
			case 134:
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PetChanged, msgData.followPetDataId, null, null, null);
				break;
			case 135:
				this.potionSets = msgData.potionSets;
				if (!(Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemBattle))
				{
					this.tmpPostionSets = this.potionSets;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonPotionSetChanged, null, null, null, null);
				break;
			case 136:
				this.PreChangeJobTableID = (int)msgData.preOccu;
				break;
			case 137:
				DataManager<GuildDataManager>.GetInstance().SetLotteryState(msgData.guildBattleLotteryStatus);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildLotteryResultRes, null, null, null, null);
				break;
			case 138:
				if (msgData.pvpSkillMgr != null)
				{
					bool flag7 = false;
					ClientSystemGameBattle clientSystemGameBattle5 = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
					if (clientSystemGameBattle5 != null)
					{
						flag7 = true;
					}
					if (flag7)
					{
						DataManager<SkillDataManager>.GetInstance().UpdateChijiSkillData(msgData.pvpSkillMgr);
					}
					else
					{
						DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage = (EPVPSkillPage)msgData.pvpSkillMgr.currentPage;
						if (msgData.pvpSkillMgr.pageCnt >= 2U)
						{
							DataManager<SkillDataManager>.GetInstance().PVPSkillPage2IsUnlock = true;
						}
						else
						{
							DataManager<SkillDataManager>.GetInstance().PVPSkillPage2IsUnlock = false;
						}
						DataManager<SkillDataManager>.GetInstance().UpdateSkillData(msgData.pvpSkillMgr, SkillConfigType.SKILL_CONFIG_PVP);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillListChanged, null, null, null, null);
					}
				}
				break;
			case 139:
				if (msgData.pvpSkillBars.bar.Length > 0)
				{
					bool flag8 = false;
					ClientSystemGameBattle clientSystemGameBattle6 = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
					if (clientSystemGameBattle6 != null)
					{
						flag8 = true;
					}
					if (flag8)
					{
						DataManager<SkillDataManager>.GetInstance().UpdateChijiSkillBar(msgData.pvpSkillBars);
					}
					else
					{
						DataManager<SkillDataManager>.GetInstance().UpdateSkillBar(msgData.pvpSkillBars, SkillConfigType.SKILL_CONFIG_PVP);
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillBarChanged, null, null, null, null);
				}
				break;
			case 140:
				if (msgData.pvpSp != null && msgData.pvpSp.spList != null && msgData.pvpSp.spList.Length >= 2)
				{
					this.pvpSP = msgData.pvpSp.spList[0];
					this.pvpSP2 = msgData.pvpSp.spList[1];
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SpChanged, null, null, null, null);
					DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Skill);
				}
				break;
			case 141:
				this.RoleAchievemeentScore = (int)msgData.achievementScore;
				break;
			case 142:
				this.AchievementMaskProperty = msgData.achievementMask;
				break;
			case 143:
				DataManager<SwitchWeaponDataManager>.GetInstance().UpdateSideWeapon(msgData.weaponBar);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SwitchEquipSuccess, null, null, null, null);
				break;
			case 144:
				this.appointmentOccu = (int)msgData.appointmentOccu;
				break;
			case 145:
				this.PackAddSize.Clear();
				this.PackTotalSize.Clear();
				for (int num3 = 0; num3 < 15; num3++)
				{
					int item2 = this.PackBaseSize;
					if (num3 == 5 || num3 == 14)
					{
						item2 = this.FashionPackBaseSize;
					}
					else if (num3 == 10)
					{
						item2 = this.TitlePackBaseSize;
					}
					this.PackTotalSize.Add(item2);
					if (num3 < msgData.packSizeAddition.Count)
					{
						this.PackAddSize.Add((int)msgData.packSizeAddition[num3]);
						List<int> packTotalSize;
						int index2;
						(packTotalSize = this.PackTotalSize)[index2 = num3] = packTotalSize[index2] + this.PackAddSize[num3];
					}
					else
					{
						Logger.LogErrorFormat("SOA_PACKAGE_SIZE_ADDITION : PackAddSize.Count <= {0}, EPackageType = {1}", new object[]
						{
							num3,
							(EPackageType)num3
						});
					}
				}
				DataManager<ItemDataManager>.GetInstance().NotifyPackageFullState();
				break;
			case 146:
				DataManager<FinancialPlanDataManager>.GetInstance().SyncBuyFinancialPlanBoughtStatus(msgData.moneyManageStatus);
				break;
			case 147:
				DataManager<FinancialPlanDataManager>.GetInstance().SyncFinancialPlanMaskProperty(msgData.moneyManageRewardMask);
				break;
			case 148:
			{
				Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
				pkInfo.nScore = msgData.scoreWarScore;
				DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo = pkInfo;
				break;
			}
			case 149:
			{
				Pk3v3CrossDataManager.My3v3PkInfo pkInfo2 = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
				pkInfo2.nCurPkCount = (int)(Pk3v3CrossDataManager.MAX_PK_COUNT - (uint)msgData.scoreWarBattleCount);
				DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo = pkInfo2;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossPkAwardInfoUpdate, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSlotInfoUpdate, null, null, null, null);
				break;
			}
			case 150:
			{
				Pk3v3CrossDataManager.My3v3PkInfo pkInfo3 = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
				List<uint> arrAwardIDs = pkInfo3.arrAwardIDs;
				arrAwardIDs.Clear();
				int count = Singleton<TableManager>.GetInstance().GetTable<ScoreWarRewardTable>().Count;
				uint num4 = 0U;
				while (num4 < msgData.scoreWarRewardMask.maskSize && (ulong)num4 < (ulong)((long)count))
				{
					int num5 = (int)(num4 + 1U);
					if (Singleton<TableManager>.GetInstance().GetTableItem<ScoreWarRewardTable>(num5, string.Empty, string.Empty) != null)
					{
						if (msgData.scoreWarRewardMask.CheckMask((uint)num5))
						{
							arrAwardIDs.Add((uint)num5);
						}
					}
					num4 += 1U;
				}
				arrAwardIDs.Sort();
				DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo = pkInfo3;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossPkAwardInfoUpdate, null, null, null, null);
				break;
			}
			case 151:
			{
				Pk3v3CrossDataManager.My3v3PkInfo pkInfo4 = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
				pkInfo4.nWinCount = msgData.scoreWarWinBattleCount;
				DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo = pkInfo4;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossPkAwardInfoUpdate, null, null, null, null);
				break;
			}
			case 152:
				DataManager<TAPNewDataManager>.GetInstance().myTAPData.academicTotalGrowth = msgData.academicTotalGrowthValue;
				break;
			case 153:
				DataManager<TAPNewDataManager>.GetInstance().myTAPData.masterDailyTaskGrowth = msgData.masterDailyTaskGrowth;
				break;
			case 154:
				DataManager<TAPNewDataManager>.GetInstance().myTAPData.masterAcademicTaskGrowth = msgData.masterAcademicTaskGrowth;
				break;
			case 155:
				DataManager<TAPNewDataManager>.GetInstance().myTAPData.masterUplevelGrowth = msgData.masterUplevelGrowth;
				break;
			case 156:
				DataManager<TAPNewDataManager>.GetInstance().myTAPData.masterGiveEquipGrowth = msgData.masterGiveEquipGrowth;
				break;
			case 157:
				DataManager<TAPNewDataManager>.GetInstance().myTAPData.masterGiveGiftGrowth = msgData.masterGiveGiftGrowth;
				break;
			case 158:
				DataManager<TAPNewDataManager>.GetInstance().myTAPData.masterTeamClearDungeonGrowth = msgData.masterTeamClearDungeonGrowth;
				break;
			case 159:
				DataManager<TAPNewDataManager>.GetInstance().myTAPData.goodTeachValue = msgData.goodTeacherValue;
				this.GoodTeacherValue = (ulong)msgData.goodTeacherValue;
				break;
			case 161:
				this.isShowFashionWeapon = (msgData.showFashionWeapon == 1);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnIsShowFashionWeapon, null, null, null, null);
				DataManager<PackageDataManager>.GetInstance().ResetSendFashionWeaponReqFlag();
				break;
			case 162:
				this.WeaponLeaseTicket = (ulong)msgData.weaponLeaseTickets;
				break;
			case 163:
				DataManager<SystemConfigManager>.GetInstance().ParseGameSet(msgData.gameSets);
				break;
			case 166:
				HeadPortraitFrameDataManager.WearHeadPortraitFrameID = (int)msgData.headFrame;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HeadPortraitFrameChange, null, null, null, null);
				break;
			case 167:
				this.WearedTitleInfo = msgData.wearedTitleInfo;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TitleNameUpdate, null, null, null, null);
				TitleComponent.OnChangeTitleName(0, DataManager<PlayerBaseData>.GetInstance().wearedTitleInfo);
				break;
			case 168:
				this.TitleGuid = msgData.newTitleGuid;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TitleGuidUpdate, null, null, null, null);
				break;
			case 169:
				if ((DataManager<ChijiDataManager>.GetInstance().CurrentUseDrugId == 401000001 || DataManager<ChijiDataManager>.GetInstance().CurrentUseDrugId == 401000002) && msgData.chijiHp - this.chiji_hp > 0)
				{
					string text = string.Empty;
					ChijiItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ChijiItemTable>(DataManager<ChijiDataManager>.GetInstance().CurrentUseDrugId, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						int num6 = 0;
						ChijiBuffTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ChijiBuffTable>(DataManager<ChijiDataManager>.GetInstance().CurrentUseDrugId, string.Empty, string.Empty);
						if (tableItem4 != null)
						{
							num6 = tableItem4.param1 / 10;
						}
						text = TR.Value("Chiji_UseDrug", tableItem3.Name, num6);
					}
					if (!string.IsNullOrEmpty(text))
					{
						SystemNotifyManager.SysNotifyTextAnimation(text, CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
					DataManager<ChijiDataManager>.GetInstance().CurrentUseDrugId = 0;
				}
				this.chiji_hp = msgData.chijiHp;
				if (this.chiji_hp <= 0)
				{
					DataManager<ChijiDataManager>.GetInstance().DoDead();
					ClientSystemGameBattle clientSystemGameBattle7 = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
					if (clientSystemGameBattle7 != null && clientSystemGameBattle7.MainPlayer != null)
					{
						clientSystemGameBattle7.MainPlayer.SetDead();
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiPlayerDead, null, null, null, null);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiHpChanged, null, null, null, null);
				break;
			case 170:
				this.chiji_mp = msgData.chijiMp;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiMpChanged, null, null, null, null);
				break;
			case 171:
				this.UpdatePackSizeByType(msgData.packageTypeStr);
				DataManager<ItemDataManager>.GetInstance().NotifyPackageFullState();
				break;
			case 172:
				this.GuildEmblemLv = msgData.guildEmblemLvl;
				TitleComponent.OnChangeGuileLv(0, DataManager<PlayerBaseData>.GetInstance().guildEmblemLv);
				break;
			case 173:
				DataManager<OPPOPrivilegeDataManager>.GetInstance().OppOAmberLevel = (int)msgData.oppoVipLevel;
				break;
			case 174:
				this.ChijiScore = msgData.chijiScore;
				break;
			case 175:
				if (msgData.equalPvpSkillMgr != null)
				{
					DataManager<SkillDataManager>.GetInstance().UpdateFairDuelSkillData(msgData.equalPvpSkillMgr);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillListChanged, null, null, null, null);
				}
				break;
			case 176:
				if (msgData.equalPvpSkillBars != null)
				{
					DataManager<SkillDataManager>.GetInstance().UpdateFairDuelSkillBar(msgData.equalPvpSkillBars);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillBarChanged, null, null, null, null);
				}
				break;
			case 177:
				this.FairDuelSp = msgData.equalPvpSp;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SpChanged, null, null, null, null);
				break;
			case 178:
				this.AccountAchievementScore = (int)msgData.accountAchievementScore;
				break;
			case 179:
				this.IntergralMallTicket = (ulong)msgData.mallPoint;
				break;
			case 180:
				this.TotalEquipScore = msgData.equipScore;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateEquipmentScore, null, null, null, null);
				break;
			case 181:
				this.adventureCoin = msgData.adventureCoin;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateAdventureCoin, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemCountChanged, null, null, null, null);
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_OTHER);
				}
				break;
			case 182:
				this.CreditTicketOwnerBySelf = msgData.creditPoint;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.CreditTicketOwnerBySelfChanged, null, null, null, null);
				break;
			case 183:
				this.CreditTicketGetInMonth = msgData.creditPointMonthGet;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.CreditTicketGetInMonthChanged, null, null, null, null);
				break;
			case 184:
				this.TicketEx = (ulong)msgData.pointex;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TicketExChanged, null, null, null, null);
				break;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerDataBaseUpdated, (SceneObjectAttr)dirtyField, null, null, null);
		}

		// Token: 0x06009DBA RID: 40378 RVA: 0x001F402C File Offset: 0x001F242C
		public int GetPotionID(PlayerBaseData.PotionSlotType potionSlotType)
		{
			if (this.potionSets == null)
			{
				return 0;
			}
			if (potionSlotType >= (PlayerBaseData.PotionSlotType)this.potionSets.Count || potionSlotType < PlayerBaseData.PotionSlotType.SlotMain)
			{
				return 0;
			}
			return (int)this.potionSets[(int)potionSlotType];
		}

		// Token: 0x06009DBB RID: 40379 RVA: 0x001F4070 File Offset: 0x001F2470
		public int GetHPPotionPercentMax()
		{
			if (this.IsPotionSlotMainSwitchOn("PotionSlotMainSwitch") && this.IsPotionSlotMainSwitchOn("PotionSlot1Switch"))
			{
				return Math.Max(this.GetPotionPercent(PlayerBaseData.PotionSlotType.SlotMain), this.GetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend1));
			}
			if (this.IsPotionSlotMainSwitchOn("PotionSlotMainSwitch"))
			{
				return this.GetPotionPercent(PlayerBaseData.PotionSlotType.SlotMain);
			}
			if (this.IsPotionSlotMainSwitchOn("PotionSlot1Switch"))
			{
				return this.GetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend1);
			}
			return -1;
		}

		// Token: 0x06009DBC RID: 40380 RVA: 0x001F40E4 File Offset: 0x001F24E4
		public int GetHPPotionIndex(bool isAuto)
		{
			if (this.IsPotionSlotMainSwitchOn("PotionSlotMainSwitch") && isAuto)
			{
				int potionID = this.GetPotionID(PlayerBaseData.PotionSlotType.SlotMain);
				if (potionID > 0)
				{
					return 0;
				}
			}
			int potionID2 = this.GetPotionID(PlayerBaseData.PotionSlotType.SlotExtend1);
			if (potionID2 > 0)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x06009DBD RID: 40381 RVA: 0x001F412A File Offset: 0x001F252A
		public int GetMPPotionIndex()
		{
			return 2;
		}

		// Token: 0x06009DBE RID: 40382 RVA: 0x001F412D File Offset: 0x001F252D
		public int GetMPPotionPercentMax()
		{
			if (this.IsPotionSlotMainSwitchOn("PotionSlot2Switch"))
			{
				return this.GetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend2);
			}
			return -1;
		}

		// Token: 0x06009DBF RID: 40383 RVA: 0x001F4148 File Offset: 0x001F2548
		public int GetPotionPercent(PlayerBaseData.PotionSlotType potionSlotType)
		{
			if (this.jsonText == null)
			{
				return 0;
			}
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return 0;
			}
			string text = potionSlotType.ToString();
			if (jsonData.ContainsKey(text) && jsonData[text].IsInt)
			{
				return (int)jsonData[text];
			}
			if (!jsonData.ContainsKey(text))
			{
				return 50;
			}
			return 0;
		}

		// Token: 0x06009DC0 RID: 40384 RVA: 0x001F41C0 File Offset: 0x001F25C0
		public void SetPotionPercent(PlayerBaseData.PotionSlotType potionSlotType, int value, bool save2File = false)
		{
			if (value < 0)
			{
				value = 0;
			}
			if (value > 100)
			{
				value = 100;
			}
			if (this.jsonText == null)
			{
				return;
			}
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return;
			}
			jsonData[potionSlotType.ToString()] = value;
			this.jsonText = jsonData.ToJson();
			if (save2File)
			{
				this.SavePotionPercentSetsToFile();
			}
		}

		// Token: 0x06009DC1 RID: 40385 RVA: 0x001F4234 File Offset: 0x001F2634
		public bool IsPotionSlotMainSwitchOn(string keyName = "PotionSlotMainSwitch")
		{
			if (this.jsonText == null)
			{
				return false;
			}
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			return jsonData != null && (jsonData.ContainsKey(keyName) && jsonData[keyName].IsBoolean) && (bool)jsonData[keyName];
		}

		// Token: 0x06009DC2 RID: 40386 RVA: 0x001F4290 File Offset: 0x001F2690
		public void SetPotionSlotMainSwitchOn(bool bOn, bool save2File = false, string keyName = "PotionSlotMainSwitch")
		{
			if (this.jsonText == null)
			{
				return;
			}
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return;
			}
			jsonData[keyName] = bOn;
			this.jsonText = jsonData.ToJson();
			if (save2File)
			{
				this.SavePotionPercentSetsToFile();
			}
		}

		// Token: 0x06009DC3 RID: 40387 RVA: 0x001F42E4 File Offset: 0x001F26E4
		public void SavePotionPercentSetsToFile()
		{
			if (this.jsonText == null)
			{
				return;
			}
			try
			{
				if (!string.IsNullOrEmpty(this.jsonText))
				{
					FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, this.jsonText);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x1700195D RID: 6493
		// (get) Token: 0x06009DC4 RID: 40388 RVA: 0x001F4348 File Offset: 0x001F2748
		// (set) Token: 0x06009DC5 RID: 40389 RVA: 0x001F4350 File Offset: 0x001F2750
		public ulong RoleID
		{
			get
			{
				return this.ulRoleId;
			}
			set
			{
				ulong num = this.ulRoleId;
				this.ulRoleId = value;
				if (num != this.ulRoleId)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RoleIdChanged, num, value, null, null);
				}
			}
		}

		// Token: 0x1700195E RID: 6494
		// (get) Token: 0x06009DC6 RID: 40390 RVA: 0x001F4394 File Offset: 0x001F2794
		// (set) Token: 0x06009DC7 RID: 40391 RVA: 0x001F439C File Offset: 0x001F279C
		public ushort Level
		{
			get
			{
				return this.iLevel;
			}
			set
			{
				if (value != this.iLevel)
				{
					int iPreLv = (int)this.iLevel;
					this.iLevel = value;
					if (this.onLevelChanged != null)
					{
						this.onLevelChanged(iPreLv, (int)this.iLevel);
					}
					if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.roleinfo != null)
					{
						foreach (RoleInfo roleInfo in ClientApplication.playerinfo.roleinfo)
						{
							if (roleInfo != null)
							{
								if (roleInfo.roleId == this.RoleID)
								{
									roleInfo.level = this.iLevel;
									break;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x1700195F RID: 6495
		// (get) Token: 0x06009DC8 RID: 40392 RVA: 0x001F4449 File Offset: 0x001F2849
		public bool IsLevelFull
		{
			get
			{
				return (int)this.iLevel >= this.mPlayerMaxLv;
			}
		}

		// Token: 0x17001960 RID: 6496
		// (get) Token: 0x06009DC9 RID: 40393 RVA: 0x001F445C File Offset: 0x001F285C
		public int ActivityValue
		{
			get
			{
				return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_VALUE);
			}
		}

		// Token: 0x17001961 RID: 6497
		// (get) Token: 0x06009DCA RID: 40394 RVA: 0x001F446D File Offset: 0x001F286D
		// (set) Token: 0x06009DCB RID: 40395 RVA: 0x001F4475 File Offset: 0x001F2875
		public uint MissionScore
		{
			get
			{
				return this.iMissionScore;
			}
			set
			{
				this.iMissionScore = value;
				if (this.onMissionScoreChanged != null)
				{
					this.onMissionScoreChanged((int)this.iMissionScore);
				}
			}
		}

		// Token: 0x17001962 RID: 6498
		// (get) Token: 0x06009DCC RID: 40396 RVA: 0x001F449A File Offset: 0x001F289A
		// (set) Token: 0x06009DCD RID: 40397 RVA: 0x001F44A2 File Offset: 0x001F28A2
		public int BudoStatus
		{
			get
			{
				return this.iBudoStatus;
			}
			set
			{
				this.iBudoStatus = value;
				DataManager<BudoManager>.GetInstance().BudoStatus = value;
			}
		}

		// Token: 0x17001963 RID: 6499
		// (get) Token: 0x06009DCE RID: 40398 RVA: 0x001F44B6 File Offset: 0x001F28B6
		// (set) Token: 0x06009DCF RID: 40399 RVA: 0x001F44BE File Offset: 0x001F28BE
		public AchievementMaskProperty AchievementMaskProperty
		{
			get
			{
				return this._achievementMask;
			}
			set
			{
				this._achievementMask = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementMaskPropertyChanged, null, null, null, null);
			}
		}

		// Token: 0x17001964 RID: 6500
		// (get) Token: 0x06009DD0 RID: 40400 RVA: 0x001F44DA File Offset: 0x001F28DA
		// (set) Token: 0x06009DD1 RID: 40401 RVA: 0x001F44E2 File Offset: 0x001F28E2
		public DailyTaskMaskProperty DailyTaskMaskProperty
		{
			get
			{
				return this.dailyTaskMaskProperty;
			}
			set
			{
				this.dailyTaskMaskProperty = value;
				DataManager<MissionManager>.GetInstance().SetDailyMaskProperty(this.dailyTaskMaskProperty);
			}
		}

		// Token: 0x17001965 RID: 6501
		// (get) Token: 0x06009DD2 RID: 40402 RVA: 0x001F44FB File Offset: 0x001F28FB
		public float Chiji_HP_Percent
		{
			get
			{
				return (float)this.chiji_hp / 1000f;
			}
		}

		// Token: 0x17001966 RID: 6502
		// (get) Token: 0x06009DD3 RID: 40403 RVA: 0x001F450A File Offset: 0x001F290A
		public float Chiji_MP_Percent
		{
			get
			{
				return (float)this.chiji_mp / 1000f;
			}
		}

		// Token: 0x17001967 RID: 6503
		// (get) Token: 0x06009DD4 RID: 40404 RVA: 0x001F4519 File Offset: 0x001F2919
		// (set) Token: 0x06009DD5 RID: 40405 RVA: 0x001F4526 File Offset: 0x001F2926
		public ulong GoodTeacherValue
		{
			get
			{
				return this.ulGoodTeacherValue;
			}
			set
			{
				this.ulGoodTeacherValue = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_GoodTeacher_Value);
				}
			}
		}

		// Token: 0x17001968 RID: 6504
		// (get) Token: 0x06009DD6 RID: 40406 RVA: 0x001F454C File Offset: 0x001F294C
		// (set) Token: 0x06009DD7 RID: 40407 RVA: 0x001F4559 File Offset: 0x001F2959
		public ulong Gold
		{
			get
			{
				return this.ulGold;
			}
			set
			{
				this.ulGold = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_GOLD);
				}
			}
		}

		// Token: 0x17001969 RID: 6505
		// (get) Token: 0x06009DD8 RID: 40408 RVA: 0x001F457E File Offset: 0x001F297E
		// (set) Token: 0x06009DD9 RID: 40409 RVA: 0x001F4586 File Offset: 0x001F2986
		public ulong TitleGuid
		{
			get
			{
				return this.titleGuid;
			}
			set
			{
				this.titleGuid = value;
			}
		}

		// Token: 0x1700196A RID: 6506
		// (get) Token: 0x06009DDA RID: 40410 RVA: 0x001F458F File Offset: 0x001F298F
		// (set) Token: 0x06009DDB RID: 40411 RVA: 0x001F4597 File Offset: 0x001F2997
		public PlayerWearedTitleInfo WearedTitleInfo
		{
			get
			{
				return this.wearedTitleInfo;
			}
			set
			{
				this.wearedTitleInfo = value;
			}
		}

		// Token: 0x1700196B RID: 6507
		// (get) Token: 0x06009DDC RID: 40412 RVA: 0x001F45A0 File Offset: 0x001F29A0
		// (set) Token: 0x06009DDD RID: 40413 RVA: 0x001F45A8 File Offset: 0x001F29A8
		public uint GuildEmblemLv
		{
			get
			{
				return this.guildEmblemLv;
			}
			set
			{
				this.guildEmblemLv = value;
			}
		}

		// Token: 0x1700196C RID: 6508
		// (get) Token: 0x06009DDE RID: 40414 RVA: 0x001F45B1 File Offset: 0x001F29B1
		// (set) Token: 0x06009DDF RID: 40415 RVA: 0x001F45BE File Offset: 0x001F29BE
		public ulong BindGold
		{
			get
			{
				return this.ulBindGold;
			}
			set
			{
				this.ulBindGold = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_BIND_GOLD);
				}
			}
		}

		// Token: 0x1700196D RID: 6509
		// (get) Token: 0x06009DE0 RID: 40416 RVA: 0x001F45E3 File Offset: 0x001F29E3
		// (set) Token: 0x06009DE1 RID: 40417 RVA: 0x001F45F0 File Offset: 0x001F29F0
		public ulong WeaponLeaseTicket
		{
			get
			{
				return this.weaponLeaseTicket;
			}
			set
			{
				this.weaponLeaseTicket = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_WEAPON_LEASE_TICKET);
				}
			}
		}

		// Token: 0x1700196E RID: 6510
		// (get) Token: 0x06009DE2 RID: 40418 RVA: 0x001F4616 File Offset: 0x001F2A16
		// (set) Token: 0x06009DE3 RID: 40419 RVA: 0x001F4623 File Offset: 0x001F2A23
		public ulong IntergralMallTicket
		{
			get
			{
				return this.intergralMallTicket;
			}
			set
			{
				this.intergralMallTicket = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_INTERGRALMALL_TICKET);
				}
			}
		}

		// Token: 0x06009DE4 RID: 40420 RVA: 0x001F4649 File Offset: 0x001F2A49
		private bool _canUse(ulong va, ulong vb, ulong cnt)
		{
			if (va >= cnt || vb >= cnt)
			{
				return true;
			}
			if (va < cnt)
			{
				return cnt - va <= vb;
			}
			return cnt - vb <= va;
		}

		// Token: 0x06009DE5 RID: 40421 RVA: 0x001F4675 File Offset: 0x001F2A75
		public bool CanUseGold(ulong cnt)
		{
			return this._canUse(this.BindGold, this.Gold, cnt);
		}

		// Token: 0x06009DE6 RID: 40422 RVA: 0x001F468A File Offset: 0x001F2A8A
		public bool CanUseTicket(ulong cnt)
		{
			return this._canUse(this.Ticket, this.BindTicket, cnt);
		}

		// Token: 0x1700196F RID: 6511
		// (get) Token: 0x06009DE7 RID: 40423 RVA: 0x001F469F File Offset: 0x001F2A9F
		// (set) Token: 0x06009DE8 RID: 40424 RVA: 0x001F46AD File Offset: 0x001F2AAD
		public ulong Ticket
		{
			get
			{
				return (ulong)((long)this.ulTicket.ToInt());
			}
			set
			{
				this.ulTicket = (int)value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_POINT);
				}
			}
		}

		// Token: 0x17001970 RID: 6512
		// (get) Token: 0x06009DE9 RID: 40425 RVA: 0x001F46D3 File Offset: 0x001F2AD3
		// (set) Token: 0x06009DEA RID: 40426 RVA: 0x001F46E1 File Offset: 0x001F2AE1
		public ulong TicketEx
		{
			get
			{
				return (ulong)((long)this.ulTicketEx.ToInt());
			}
			set
			{
				this.ulTicketEx = (int)value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_POINTEX);
				}
			}
		}

		// Token: 0x17001971 RID: 6513
		// (get) Token: 0x06009DEB RID: 40427 RVA: 0x001F4707 File Offset: 0x001F2B07
		// (set) Token: 0x06009DEC RID: 40428 RVA: 0x001F4715 File Offset: 0x001F2B15
		public ulong BindTicket
		{
			get
			{
				return (ulong)((long)this.ulBindTicket.ToInt());
			}
			set
			{
				this.ulBindTicket = (int)value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_BIND_POINT);
				}
			}
		}

		// Token: 0x17001972 RID: 6514
		// (get) Token: 0x06009DED RID: 40429 RVA: 0x001F473B File Offset: 0x001F2B3B
		// (set) Token: 0x06009DEE RID: 40430 RVA: 0x001F4748 File Offset: 0x001F2B48
		public ulong GoldJarScore
		{
			get
			{
				return this.ulGoldJarScore;
			}
			set
			{
				this.ulGoldJarScore = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_GOLD_JAR_SCORE);
				}
			}
		}

		// Token: 0x17001973 RID: 6515
		// (get) Token: 0x06009DEF RID: 40431 RVA: 0x001F476E File Offset: 0x001F2B6E
		// (set) Token: 0x06009DF0 RID: 40432 RVA: 0x001F477B File Offset: 0x001F2B7B
		public ulong MagicJarScore
		{
			get
			{
				return this.ulMagicJarScore;
			}
			set
			{
				this.ulMagicJarScore = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_Magic_JAR_SCORE);
				}
			}
		}

		// Token: 0x17001974 RID: 6516
		// (get) Token: 0x06009DF1 RID: 40433 RVA: 0x001F47A1 File Offset: 0x001F2BA1
		// (set) Token: 0x06009DF2 RID: 40434 RVA: 0x001F47AE File Offset: 0x001F2BAE
		public ulong AppoinmentCoin
		{
			get
			{
				return this.ulAppointmentCoin;
			}
			set
			{
				this.ulAppointmentCoin = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_Appoinment_Coin);
				}
			}
		}

		// Token: 0x17001975 RID: 6517
		// (get) Token: 0x06009DF3 RID: 40435 RVA: 0x001F47D4 File Offset: 0x001F2BD4
		// (set) Token: 0x06009DF4 RID: 40436 RVA: 0x001F47DC File Offset: 0x001F2BDC
		public uint RoleCreateTime
		{
			get
			{
				return this.uiRoleCreateTime;
			}
			set
			{
				this.uiRoleCreateTime = value;
				if (this.onRoleCreateTimeChanged != null)
				{
					this.onRoleCreateTimeChanged();
				}
			}
		}

		// Token: 0x17001976 RID: 6518
		// (get) Token: 0x06009DF5 RID: 40437 RVA: 0x001F47FB File Offset: 0x001F2BFB
		// (set) Token: 0x06009DF6 RID: 40438 RVA: 0x001F4803 File Offset: 0x001F2C03
		public uint MonthCardLv
		{
			get
			{
				return this.iMonthCardLv;
			}
			set
			{
				this.iMonthCardLv = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MonthCardChanged, null, null, null, null);
			}
		}

		// Token: 0x17001977 RID: 6519
		// (get) Token: 0x06009DF7 RID: 40439 RVA: 0x001F481C File Offset: 0x001F2C1C
		// (set) Token: 0x06009DF8 RID: 40440 RVA: 0x001F4829 File Offset: 0x001F2C29
		public ulong AliveCoin
		{
			get
			{
				return this.ulAliveCoin;
			}
			set
			{
				this.ulAliveCoin = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_ALIVE_COIN);
				}
			}
		}

		// Token: 0x17001978 RID: 6520
		// (get) Token: 0x06009DF9 RID: 40441 RVA: 0x001F484E File Offset: 0x001F2C4E
		// (set) Token: 0x06009DFA RID: 40442 RVA: 0x001F4856 File Offset: 0x001F2C56
		public uint WarriorSoul
		{
			get
			{
				return this.uiWarriorSoul;
			}
			set
			{
				this.uiWarriorSoul = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_WARRIOR_SOUL);
				}
			}
		}

		// Token: 0x17001979 RID: 6521
		// (get) Token: 0x06009DFB RID: 40443 RVA: 0x001F4876 File Offset: 0x001F2C76
		// (set) Token: 0x06009DFC RID: 40444 RVA: 0x001F487E File Offset: 0x001F2C7E
		public uint uiPkCoin
		{
			get
			{
				return this.pkCoin;
			}
			set
			{
				this.pkCoin = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_FIGHT_COIN);
				}
			}
		}

		// Token: 0x1700197A RID: 6522
		// (get) Token: 0x06009DFD RID: 40445 RVA: 0x001F489E File Offset: 0x001F2C9E
		// (set) Token: 0x06009DFE RID: 40446 RVA: 0x001F48A6 File Offset: 0x001F2CA6
		public uint dayChargeNum
		{
			get
			{
				return this._dayChargeNum;
			}
			set
			{
				this._dayChargeNum = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnDayChargeChanged, null, null, null, null);
			}
		}

		// Token: 0x1700197B RID: 6523
		// (get) Token: 0x06009DFF RID: 40447 RVA: 0x001F48C2 File Offset: 0x001F2CC2
		// (set) Token: 0x06009E00 RID: 40448 RVA: 0x001F48CC File Offset: 0x001F2CCC
		public int AchievementScore
		{
			get
			{
				return this._achievementScore;
			}
			set
			{
				int achievementScore = this._achievementScore;
				this._achievementScore = value;
				if (this.isRoleEnterGame)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementScoreChanged, achievementScore, this._achievementScore, null, null);
				}
			}
		}

		// Token: 0x1700197C RID: 6524
		// (set) Token: 0x06009E01 RID: 40449 RVA: 0x001F4914 File Offset: 0x001F2D14
		public int AccountAchievementScore
		{
			set
			{
				this._accountAchievementScore = value;
				this.AchievementScore = this._accountAchievementScore + this._roleAchievementScore;
			}
		}

		// Token: 0x1700197D RID: 6525
		// (set) Token: 0x06009E02 RID: 40450 RVA: 0x001F4930 File Offset: 0x001F2D30
		public int RoleAchievemeentScore
		{
			set
			{
				this._roleAchievementScore = value;
				this.AchievementScore = this._roleAchievementScore + this._accountAchievementScore;
			}
		}

		// Token: 0x1700197E RID: 6526
		// (set) Token: 0x06009E03 RID: 40451 RVA: 0x001F494C File Offset: 0x001F2D4C
		public bool IsRoleEnterGame
		{
			set
			{
				this.isRoleEnterGame = value;
			}
		}

		// Token: 0x1700197F RID: 6527
		// (get) Token: 0x06009E04 RID: 40452 RVA: 0x001F4955 File Offset: 0x001F2D55
		// (set) Token: 0x06009E05 RID: 40453 RVA: 0x001F495D File Offset: 0x001F2D5D
		public uint ChijiScore
		{
			get
			{
				return this._ChijiScore;
			}
			set
			{
				this._ChijiScore = value;
			}
		}

		// Token: 0x17001980 RID: 6528
		// (get) Token: 0x06009E06 RID: 40454 RVA: 0x001F4966 File Offset: 0x001F2D66
		// (set) Token: 0x06009E07 RID: 40455 RVA: 0x001F496E File Offset: 0x001F2D6E
		public uint TotalEquipScore
		{
			get
			{
				return this.totalEquipScore;
			}
			set
			{
				this.totalEquipScore = value;
			}
		}

		// Token: 0x17001981 RID: 6529
		// (get) Token: 0x06009E08 RID: 40456 RVA: 0x001F4977 File Offset: 0x001F2D77
		// (set) Token: 0x06009E09 RID: 40457 RVA: 0x001F4980 File Offset: 0x001F2D80
		public int JobTableID
		{
			get
			{
				return this.m_jobTableID;
			}
			set
			{
				this.m_jobTableID = value;
				this.m_activeJobTableIDs.Clear();
				int num = this.m_jobTableID;
				JobTable jobTable = null;
				if (num > 0)
				{
					jobTable = Singleton<TableManager>.instance.GetTableItem<JobTable>(num, string.Empty, string.Empty);
				}
				while (num > 0 && jobTable != null)
				{
					this.m_activeJobTableIDs.Add(num);
					num = jobTable.prejob;
					jobTable = null;
					if (num > 0)
					{
						jobTable = Singleton<TableManager>.instance.GetTableItem<JobTable>(num, string.Empty, string.Empty);
					}
				}
			}
		}

		// Token: 0x17001982 RID: 6530
		// (get) Token: 0x06009E0A RID: 40458 RVA: 0x001F4A09 File Offset: 0x001F2E09
		public List<int> ActiveJobTableIDs
		{
			get
			{
				return this.m_activeJobTableIDs;
			}
		}

		// Token: 0x17001983 RID: 6531
		// (get) Token: 0x06009E0B RID: 40459 RVA: 0x001F4A11 File Offset: 0x001F2E11
		// (set) Token: 0x06009E0C RID: 40460 RVA: 0x001F4A19 File Offset: 0x001F2E19
		public string Announcement
		{
			get
			{
				return this.puiplAnnouncement;
			}
			set
			{
				this.puiplAnnouncement = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAnnouncementChanged, null, null, null, null);
			}
		}

		// Token: 0x17001984 RID: 6532
		// (get) Token: 0x06009E0D RID: 40461 RVA: 0x001F4A35 File Offset: 0x001F2E35
		// (set) Token: 0x06009E0E RID: 40462 RVA: 0x001F4A3D File Offset: 0x001F2E3D
		public bool getPupil
		{
			get
			{
				return this._getPupilSetting;
			}
			set
			{
				this._getPupilSetting = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGetPupilSettingChanged, null, null, null, null);
			}
		}

		// Token: 0x17001985 RID: 6533
		// (get) Token: 0x06009E0F RID: 40463 RVA: 0x001F4A59 File Offset: 0x001F2E59
		// (set) Token: 0x06009E10 RID: 40464 RVA: 0x001F4A61 File Offset: 0x001F2E61
		public int guildContribution
		{
			get
			{
				return this.ms_nGuildContribution;
			}
			set
			{
				this.ms_nGuildContribution = value;
				if (this.onMoneyChanged != null)
				{
					this.onMoneyChanged(PlayerBaseData.MoneyBinderType.MBT_GUILD_CONTRIBUTION);
				}
			}
		}

		// Token: 0x06009E11 RID: 40465 RVA: 0x001F4A84 File Offset: 0x001F2E84
		public List<BuffInfoData> GetRankBuff()
		{
			List<BuffInfoData> list = new List<BuffInfoData>();
			IList<int> seasonAttrBuffIDs = SeasonDataManager.GetSeasonAttrBuffIDs(DataManager<SeasonDataManager>.GetInstance().seasonAttrID);
			if (seasonAttrBuffIDs != null)
			{
				for (int i = 0; i < seasonAttrBuffIDs.Count; i++)
				{
					if (seasonAttrBuffIDs[i] > 0)
					{
						BuffInfoData item = new BuffInfoData
						{
							buffID = seasonAttrBuffIDs[i]
						};
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x06009E12 RID: 40466 RVA: 0x001F4AF6 File Offset: 0x001F2EF6
		public Dictionary<int, string> GetAvatar()
		{
			if (this.avatar == null)
			{
				return new Dictionary<int, string>();
			}
			return BattlePlayer.GetAvatar(this.avatar);
		}

		// Token: 0x06009E13 RID: 40467 RVA: 0x001F4B14 File Offset: 0x001F2F14
		public PetData GetPetData(bool isPvp)
		{
			PetData petData = new PetData();
			List<BuffInfoData> list = new List<BuffInfoData>();
			List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				PetInfo petInfo = onUsePetList[i];
				if (petInfo != null)
				{
					PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)petInfo.dataId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.InnateSkill > 0)
						{
							BeUtility.AddBuffFromSkill(tableItem.InnateSkill, (int)petInfo.level, list, isPvp);
						}
						if (tableItem.PetType == PetTable.ePetType.PT_ATTACK)
						{
							petData.id = tableItem.MonsterID;
							petData.skillID = tableItem.Skills[(int)petInfo.skillIndex];
							petData.hunger = (int)petInfo.hunger;
							petData.level = (int)petInfo.level;
						}
						else
						{
							int petSkillIDByJob = PetDataManager.GetPetSkillIDByJob((int)petInfo.dataId, DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)petInfo.skillIndex);
							BeUtility.AddBuffFromSkill(petSkillIDByJob, (int)petInfo.level, list, isPvp);
						}
					}
				}
			}
			petData.buffs = list;
			return petData;
		}

		// Token: 0x06009E14 RID: 40468 RVA: 0x001F4C38 File Offset: 0x001F3038
		public bool HasAccompany()
		{
			return false;
		}

		// Token: 0x06009E15 RID: 40469 RVA: 0x001F4C3C File Offset: 0x001F303C
		public int GetAwakeSkillID()
		{
			if (BattleMain.IsCanAccompany(BattleMain.battleType))
			{
				Dictionary<int, int> skillInfo = DataManager<SkillDataManager>.GetInstance().GetSkillInfo(BattleMain.IsModePvP(BattleMain.battleType), SkillSystemSourceType.None);
				foreach (KeyValuePair<int, int> keyValuePair in skillInfo)
				{
					int key = keyValuePair.Key;
					SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(key, string.Empty, string.Empty);
					if (tableItem != null && tableItem.SkillCategory == 4 && tableItem.SkillType == SkillTable.eSkillType.ACTIVE)
					{
						return key;
					}
				}
			}
			return 0;
		}

		// Token: 0x06009E16 RID: 40470 RVA: 0x001F4CD4 File Offset: 0x001F30D4
		public int GetWeaponStrengthenLevel()
		{
			int result = 0;
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			if (itemsByPackageType != null)
			{
				foreach (ulong id in itemsByPackageType)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
					if (item != null && item.SubType == 1 && item.EquipWearSlotType == EEquipWearSlotType.EquipWeapon)
					{
						result = item.StrengthenLevel;
					}
				}
			}
			return result;
		}

		// Token: 0x06009E17 RID: 40471 RVA: 0x001F4D70 File Offset: 0x001F3170
		public List<ItemProperty> GetSideEquipments()
		{
			List<ItemProperty> list = new List<ItemProperty>();
			List<ulong> sideWeaponIDList = DataManager<SwitchWeaponDataManager>.GetInstance().GetSideWeaponIDList();
			if (sideWeaponIDList != null)
			{
				int count = sideWeaponIDList.Count;
				for (int i = 0; i < count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(sideWeaponIDList[i]);
					if (item != null)
					{
						ItemProperty battleProperty = item.GetBattleProperty(0);
						battleProperty.itemID = item.TableID;
						battleProperty.guid = item.GUID;
						list.Add(battleProperty);
					}
				}
			}
			return list;
		}

		// Token: 0x06009E18 RID: 40472 RVA: 0x001F4DFC File Offset: 0x001F31FC
		public int GetTitleID()
		{
			int result = 0;
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			if (itemsByPackageType != null)
			{
				foreach (ulong id in itemsByPackageType)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
					if (item != null && item.SubType == 10)
					{
						result = item.TableID;
					}
				}
			}
			return result;
		}

		// Token: 0x06009E19 RID: 40473 RVA: 0x001F4E8C File Offset: 0x001F328C
		public List<ItemProperty> GetEquipedEquipments()
		{
			List<ItemProperty> list = new List<ItemProperty>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			if (itemsByPackageType != null)
			{
				foreach (ulong id in itemsByPackageType)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
					if (item != null)
					{
						ItemProperty battleProperty = item.GetBattleProperty(0);
						battleProperty.itemID = item.TableID;
						battleProperty.guid = item.GUID;
						list.Add(battleProperty);
					}
				}
			}
			itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
			if (itemsByPackageType != null)
			{
				foreach (ulong id2 in itemsByPackageType)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(id2);
					if (item2 != null)
					{
						ItemProperty battleProperty2 = item2.GetBattleProperty(0);
						battleProperty2.itemID = item2.TableID;
						list.Add(battleProperty2);
					}
				}
			}
			return list;
		}

		// Token: 0x06009E1A RID: 40474 RVA: 0x001F4FCC File Offset: 0x001F33CC
		private bool AutoSetHpMpPotion(uint hpMPPotionID)
		{
			if (hpMPPotionID == 0U)
			{
				return false;
			}
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemBattle))
			{
				return false;
			}
			bool flag = false;
			List<uint> list = this.tmpPostionSets;
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] == hpMPPotionID)
					{
						ChapterBattlePotionSetUtiilty.Save(i, hpMPPotionID);
						return true;
					}
				}
			}
			if (!flag && list != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j] == 0U)
					{
						ChapterBattlePotionSetUtiilty.Save(j, hpMPPotionID);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06009E1B RID: 40475 RVA: 0x001F5078 File Offset: 0x001F3478
		private void _OnAddNewItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i] != null)
				{
					ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>((int)items[i].tableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.SubType == ItemTable.eSubType.HpMp)
						{
							uint tableID = items[i].tableID;
							if (this.AutoSetHpMpPotion(tableID))
							{
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x06009E1C RID: 40476 RVA: 0x001F5110 File Offset: 0x001F3510
		public PkStatistic GetPkStatisticDataByPkType(PkType TypeID)
		{
			byte key = (byte)TypeID;
			PkStatistic result;
			if (this.PkStatisticsData.TryGetValue(key, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06009E1D RID: 40477 RVA: 0x001F5138 File Offset: 0x001F3538
		public void AvatarEquipPart(IGeAvatarActor avatarRenderer, EFashionWearSlotType slotType, int itemId, GeActorEx geActor = null, int prodId = 0, bool highPriority = false)
		{
			if (avatarRenderer == null && geActor == null)
			{
				return;
			}
			EFashionWearSlotType efashionWearSlotType = slotType;
			GeAvatarChannel geAvatarChannel = GeAvatarChannel.MaxChannelNum;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			this.GetFashionSlotChangedType(ref efashionWearSlotType, ref geAvatarChannel, tableItem, false);
			if (geAvatarChannel != GeAvatarChannel.MaxChannelNum)
			{
				if (itemId == 0)
				{
					if (geActor != null)
					{
						geActor.ChangeAvatar(geAvatarChannel, null, Singleton<AssetLoadConfig>.instance.asyncLoad, highPriority, prodId);
					}
					if (avatarRenderer != null)
					{
						avatarRenderer.ChangeAvatar(geAvatarChannel, null, Singleton<AssetLoadConfig>.instance.asyncLoad, highPriority);
					}
				}
				else if (tableItem != null)
				{
					int resID = tableItem.ResID;
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						if (geActor != null)
						{
							geActor.ChangeAvatar(geAvatarChannel, tableItem2.ModelPath, Singleton<AssetLoadConfig>.instance.asyncLoad, highPriority, prodId);
						}
						if (avatarRenderer != null)
						{
							avatarRenderer.ChangeAvatar(geAvatarChannel, tableItem2.ModelPath, Singleton<AssetLoadConfig>.instance.asyncLoad, highPriority);
						}
					}
				}
			}
		}

		// Token: 0x06009E1E RID: 40478 RVA: 0x001F5234 File Offset: 0x001F3634
		public void GetFashionSlotChangedType(ref EFashionWearSlotType slot, ref GeAvatarChannel channel, ItemTable itemTable, bool UseTableType = false)
		{
			if (!UseTableType)
			{
				switch (slot)
				{
				case EFashionWearSlotType.Head:
					channel = GeAvatarChannel.Head;
					break;
				case EFashionWearSlotType.Waist:
					channel = GeAvatarChannel.Bracelet;
					break;
				case EFashionWearSlotType.UpperBody:
					channel = GeAvatarChannel.UpperPart;
					break;
				case EFashionWearSlotType.LowerBody:
					channel = GeAvatarChannel.LowerPart;
					break;
				case EFashionWearSlotType.Chest:
					channel = GeAvatarChannel.Headwear;
					break;
				}
			}
			else
			{
				slot = EFashionWearSlotType.Invalid;
				channel = GeAvatarChannel.MaxChannelNum;
				if (itemTable != null)
				{
					ItemTable.eSubType subType = itemTable.SubType;
					switch (subType)
					{
					case ItemTable.eSubType.FASHION_HAIR:
						break;
					case ItemTable.eSubType.FASHION_HEAD:
						slot = EFashionWearSlotType.Head;
						channel = GeAvatarChannel.Head;
						break;
					case ItemTable.eSubType.FASHION_SASH:
						slot = EFashionWearSlotType.Waist;
						channel = GeAvatarChannel.Bracelet;
						break;
					case ItemTable.eSubType.FASHION_CHEST:
						slot = EFashionWearSlotType.UpperBody;
						channel = GeAvatarChannel.UpperPart;
						break;
					case ItemTable.eSubType.FASHION_LEG:
						slot = EFashionWearSlotType.LowerBody;
						channel = GeAvatarChannel.LowerPart;
						break;
					case ItemTable.eSubType.FASHION_EPAULET:
						slot = EFashionWearSlotType.Chest;
						channel = GeAvatarChannel.Headwear;
						break;
					default:
						Logger.LogErrorFormat("该时装部位外观未处理，对应表格SubType：{0}", new object[]
						{
							subType
						});
						break;
					}
				}
			}
		}

		// Token: 0x06009E1F RID: 40479 RVA: 0x001F5330 File Offset: 0x001F3730
		public void AvatarEquipWeaponFromRes(IGeAvatarActor avatarRenderer, string weaponPath, string weaponLocatorPath, GeActorEx geActor = null, bool highPriority = false, string defaultWeaponPath = null)
		{
			if (avatarRenderer == null && geActor == null)
			{
				return;
			}
			if (Utility.IsStringValid(weaponPath))
			{
				if (geActor != null)
				{
					string text = weaponPath;
					if (GeAvatarFallback.IsAvatarPartFallbackEnabled() && !GeAvatarFallback.IsAssetDependentAvaliable(text) && !string.IsNullOrEmpty(defaultWeaponPath))
					{
						text = defaultWeaponPath;
					}
					geActor.CreateAttachment("weapon", text, weaponLocatorPath, false, true, highPriority);
					geActor.ChangeAction(geActor.GetCurActionName(), 1f, true, true, false);
				}
				else if (avatarRenderer != null)
				{
					avatarRenderer.AttachAvatar("weapon", weaponPath, weaponLocatorPath, false, true, highPriority, 0f);
					avatarRenderer.ChangeAction(avatarRenderer.GetCurActionName(), 1f, true);
				}
			}
		}

		// Token: 0x06009E20 RID: 40480 RVA: 0x001F53E4 File Offset: 0x001F37E4
		public void AvatarEquipWeapon(IGeAvatarActor avatarRenderer, int jobID, int wid, GeActorEx geActor = null, bool highPriority = false)
		{
			if (avatarRenderer == null && geActor == null)
			{
				return;
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string weaponPath = tableItem.DefaultWeaponPath;
				string defaultWeaponLocator = tableItem.DefaultWeaponLocator;
				if (wid > 0)
				{
					ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(wid, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						int resID = tableItem2.ResID;
						ResTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
						if (tableItem3 != null)
						{
							weaponPath = tableItem3.ModelPath;
						}
					}
				}
				this.AvatarEquipWeaponFromRes(avatarRenderer, weaponPath, defaultWeaponLocator, geActor, highPriority, tableItem.DefaultWeaponPath);
			}
		}

		// Token: 0x06009E21 RID: 40481 RVA: 0x001F5490 File Offset: 0x001F3890
		public string GetWeaponResFormID(int wid)
		{
			if (wid > 0)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(wid, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.SubType != ItemTable.eSubType.WEAPON)
					{
						return null;
					}
					int resID = tableItem.ResID;
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						return tableItem2.ModelPath;
					}
				}
			}
			return null;
		}

		// Token: 0x06009E22 RID: 40482 RVA: 0x001F54FC File Offset: 0x001F38FC
		public void AvatarEquipCurrentWeapon(IGeAvatarActor avatarRenderer, GeActorEx geActor = null, bool highPriority = false)
		{
			if (avatarRenderer == null && geActor == null)
			{
				return;
			}
			int num = 0;
			int wid = 0;
			ulong wearEquipBySlotType = DataManager<ItemDataManager>.GetInstance().GetWearEquipBySlotType(EEquipWearSlotType.EquipWeapon);
			if (wearEquipBySlotType > 0UL)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(wearEquipBySlotType);
				if (item != null)
				{
					wid = item.TableID;
					if (item.StrengthenLevel > 0)
					{
						num = item.StrengthenLevel;
					}
				}
			}
			this.AvatarEquipWeapon(avatarRenderer, DataManager<PlayerBaseData>.GetInstance().JobTableID, wid, geActor, false);
			if (num >= 0)
			{
				this.AvatarShowWeaponStrengthen(avatarRenderer, num, geActor, false);
			}
		}

		// Token: 0x06009E23 RID: 40483 RVA: 0x001F5580 File Offset: 0x001F3980
		public void AvatarEquipFromPreviewCompleteFashion(IGeAvatarActor avatarRenderer, GeActorEx geActor = null)
		{
			if (avatarRenderer == null && geActor == null)
			{
				return;
			}
			PlayerAvatar playerAvatar = DataManager<PlayerBaseData>.GetInstance().avatar;
			if (playerAvatar == null)
			{
				return;
			}
			uint[] array = BeUtility.CopyVector(playerAvatar.equipItemIds);
			for (int i = 0; i < array.Length; i++)
			{
				uint id = array[i];
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)id, string.Empty, string.Empty);
				if (tableItem != null && (tableItem.SubType == ItemTable.eSubType.FASHION_HEAD || tableItem.SubType == ItemTable.eSubType.FASHION_SASH || tableItem.SubType == ItemTable.eSubType.FASHION_CHEST || tableItem.SubType == ItemTable.eSubType.FASHION_LEG || tableItem.SubType == ItemTable.eSubType.FASHION_EPAULET))
				{
					array[i] = 0U;
				}
			}
			DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(avatarRenderer, array, this.JobTableID, (int)playerAvatar.weaponStrengthen, geActor, false, playerAvatar.isShoWeapon, false);
		}

		// Token: 0x06009E24 RID: 40484 RVA: 0x001F565C File Offset: 0x001F3A5C
		public void AvatarEquipFromCurrentEquiped(IGeAvatarActor avatarRenderer, GeActorEx geActor = null, bool highPriority = false)
		{
			if (avatarRenderer == null && geActor == null)
			{
				return;
			}
			PlayerAvatar playerAvatar = DataManager<PlayerBaseData>.GetInstance().avatar;
			if (playerAvatar == null)
			{
				return;
			}
			DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(avatarRenderer, playerAvatar.equipItemIds, this.JobTableID, (int)playerAvatar.weaponStrengthen, geActor, false, playerAvatar.isShoWeapon, false);
		}

		// Token: 0x06009E25 RID: 40485 RVA: 0x001F56B0 File Offset: 0x001F3AB0
		public void AvatarEquipFromItems(IGeAvatarActor avatarRenderer, uint[] equipItemIds, int jobID, int weaponStrength = 0, GeActorEx geActor = null, bool forceAdditive = false, byte isShowFashionWeapon = 0, bool isTownOtherPlayer = false)
		{
			if (avatarRenderer == null && geActor == null)
			{
				return;
			}
			if (equipItemIds == null)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			uint[] array = BeUtility.CopyVector(equipItemIds);
			BeUtility.DealWithFashion(array);
			bool flag4 = DataManager<PackageDataManager>.GetInstance().IsEquipedFashionWeapon(equipItemIds);
			bool flag5 = isShowFashionWeapon == 1;
			List<EFashionWearSlotType> list = new List<EFashionWearSlotType>();
			bool flag6 = false;
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				flag6 = true;
			}
			foreach (int num in array)
			{
				if (num > 0)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.SubType == ItemTable.eSubType.WEAPON)
						{
							if (!flag5 || !flag4)
							{
								flag = true;
								this.AvatarEquipWeapon(avatarRenderer, jobID, num, geActor, false);
								if (weaponStrength >= 0)
								{
									this.AvatarShowWeaponStrengthen(avatarRenderer, weaponStrength, geActor, forceAdditive);
								}
							}
						}
						else if (tableItem.SubType == ItemTable.eSubType.FASHION_HAIR)
						{
							flag2 = true;
							this.AvatarEquipWing(avatarRenderer, num, geActor, false);
						}
						else if (tableItem.SubType == ItemTable.eSubType.FASHION_AURAS)
						{
							flag3 = true;
							this.AvatarEquipHalo(avatarRenderer, num, geActor, false, isTownOtherPlayer);
						}
						else if (tableItem.SubType.ToString().Contains("FASHION"))
						{
							if (tableItem.SubType == ItemTable.eSubType.FASHION_WEAPON)
							{
								if (flag5)
								{
									flag = true;
									this.AvatarEquipWeapon(avatarRenderer, jobID, num, geActor, false);
									if (weaponStrength >= 0)
									{
										this.AvatarShowWeaponStrengthen(avatarRenderer, weaponStrength, geActor, forceAdditive);
									}
								}
							}
							else
							{
								EFashionWearSlotType efashionWearSlotType = (EFashionWearSlotType)(tableItem.SubType - 10);
								this.AvatarEquipPart(avatarRenderer, efashionWearSlotType, num, geActor, jobID, false);
								list.Add(efashionWearSlotType);
							}
						}
						else if (flag6)
						{
							EFashionWearSlotType efashionWearSlotType2 = this._GetChijiEquipShowSlot(tableItem);
							this.AvatarEquipPart(avatarRenderer, efashionWearSlotType2, num, geActor, jobID, false);
							list.Add(efashionWearSlotType2);
						}
					}
				}
			}
			EFashionWearSlotType[] array2 = new EFashionWearSlotType[]
			{
				EFashionWearSlotType.UpperBody,
				EFashionWearSlotType.LowerBody,
				EFashionWearSlotType.Head,
				EFashionWearSlotType.Waist,
				EFashionWearSlotType.Chest
			};
			for (int j = 0; j < array2.Length; j++)
			{
				if (!list.Contains(array2[j]))
				{
					this.AvatarEquipPart(avatarRenderer, array2[j], 0, geActor, jobID, false);
				}
			}
			if (!flag)
			{
				this.AvatarEquipWeapon(avatarRenderer, jobID, 0, geActor, false);
				this.AvatarShowWeaponStrengthen(avatarRenderer, weaponStrength, geActor, forceAdditive);
			}
			if (!flag2)
			{
				this.AvatarEquipWing(avatarRenderer, 0, geActor, false);
			}
			if (!flag3)
			{
				this.AvatarEquipHalo(avatarRenderer, 0, geActor, false, false);
			}
			if (geActor != null)
			{
				geActor.SuitAvatar(Singleton<AssetLoadConfig>.instance.asyncLoad, false, jobID);
			}
			if (avatarRenderer != null)
			{
				avatarRenderer.SuitAvatar(Singleton<AssetLoadConfig>.instance.asyncLoad, false);
			}
		}

		// Token: 0x06009E26 RID: 40486 RVA: 0x001F5970 File Offset: 0x001F3D70
		private EFashionWearSlotType _GetChijiEquipShowSlot(ItemTable data)
		{
			EFashionWearSlotType result = EFashionWearSlotType.Max;
			if (data.SubType == ItemTable.eSubType.HEAD)
			{
				result = EFashionWearSlotType.Head;
			}
			else if (data.SubType == ItemTable.eSubType.CHEST)
			{
				result = EFashionWearSlotType.UpperBody;
			}
			else if (data.SubType == ItemTable.eSubType.BELT)
			{
				result = EFashionWearSlotType.Chest;
			}
			else if (data.SubType == ItemTable.eSubType.LEG)
			{
				result = EFashionWearSlotType.Waist;
			}
			else if (data.SubType == ItemTable.eSubType.BOOT)
			{
				result = EFashionWearSlotType.LowerBody;
			}
			return result;
		}

		// Token: 0x06009E27 RID: 40487 RVA: 0x001F59DC File Offset: 0x001F3DDC
		public void AvatarShowWeaponStrengthen(IGeAvatarActor avatarRenderer, int strengthenLevel = 0, GeActorEx geActor = null, bool forceAddtive = false)
		{
			if (avatarRenderer != null && geActor != null)
			{
				return;
			}
			GeAttach geAttach = null;
			if (avatarRenderer != null)
			{
				geAttach = avatarRenderer.GetAttachment("weapon");
			}
			else if (geActor != null)
			{
				geAttach = geActor.GetAttachment("weapon");
			}
			if (geAttach != null)
			{
				geAttach.ChangePhase(BeUtility.GetStrengthenEffectName(geAttach.ResPath), strengthenLevel, forceAddtive);
			}
		}

		// Token: 0x06009E28 RID: 40488 RVA: 0x001F5A3C File Offset: 0x001F3E3C
		private void CalRoleTotalExp()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ExpTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ExpTable expTable = keyValuePair.Value as ExpTable;
				if (expTable.ID >= (int)this.Level)
				{
					break;
				}
				this.Exp += (ulong)((long)expTable.TotalExp);
			}
			this.Exp += this.CurExp;
		}

		// Token: 0x06009E29 RID: 40489 RVA: 0x001F5AE8 File Offset: 0x001F3EE8
		public void AvatarEquipWingFromRes(IGeAvatarActor avatarRenderer, string weaponPath, string weaponLocatorPath, GeActorEx geActor = null, bool highPriority = false, string attachName = "")
		{
			if (avatarRenderer == null && geActor == null)
			{
				return;
			}
			if (Utility.IsStringValid(weaponPath))
			{
				if (geActor != null)
				{
					if (GeAvatarFallback.IsAvatarPartFallbackEnabled() && !GeAvatarFallback.IsAssetDependentAvaliable(weaponPath))
					{
						return;
					}
					geActor.CreateAttachment(attachName, weaponPath, weaponLocatorPath, false, true, highPriority);
				}
				else if (avatarRenderer != null)
				{
					avatarRenderer.AttachAvatar(attachName, weaponPath, weaponLocatorPath, false, true, highPriority, 0f);
				}
			}
		}

		// Token: 0x06009E2A RID: 40490 RVA: 0x001F5B5C File Offset: 0x001F3F5C
		public void SetFootIndocator(IGeAvatarActor avatarRenderer, GeActorEx geActor = null, bool show = true)
		{
			if (avatarRenderer != null)
			{
				GeAttach attachment = avatarRenderer.GetAttachment("Aureole");
				if (attachment != null)
				{
					attachment.SetVisible(show);
				}
			}
			if (geActor != null)
			{
				GeAttach attachment2 = geActor.GetAttachment("Aureole");
				if (attachment2 != null)
				{
					attachment2.SetVisible(show);
				}
			}
		}

		// Token: 0x06009E2B RID: 40491 RVA: 0x001F5BA8 File Offset: 0x001F3FA8
		public void AvatarEquipHalo(IGeAvatarActor avatarRenderer, int itemID, GeActorEx geActor = null, bool highPriority = false, bool isTownOtherPlayer = false)
		{
			this.SetFootIndocator(avatarRenderer, geActor, itemID < 0);
			this.AvatarEquipAttach(avatarRenderer, itemID, geActor, highPriority, "halo", "[actor]Orign");
			if (isTownOtherPlayer)
			{
				bool valueWithDefault = Singleton<SettingManager>.GetInstance().GetValueWithDefault("SETTING_ACTOR_HALO", true);
				if (!valueWithDefault && geActor != null)
				{
					GeAttach attachment = geActor.GetAttachment("halo");
					if (attachment != null)
					{
						attachment.SetVisible(valueWithDefault);
					}
				}
			}
		}

		// Token: 0x06009E2C RID: 40492 RVA: 0x001F5C13 File Offset: 0x001F4013
		public void AvatarEquipWing(IGeAvatarActor avatarRenderer, int itemID, GeActorEx geActor = null, bool highPriority = false)
		{
			this.AvatarEquipAttach(avatarRenderer, itemID, geActor, highPriority, "wing", "[actor]Back");
		}

		// Token: 0x06009E2D RID: 40493 RVA: 0x001F5C2C File Offset: 0x001F402C
		public void AvatarEquipAttach(IGeAvatarActor avatarRenderer, int itemID, GeActorEx geActor = null, bool highPriority = false, string attachName = "", string attachNode = null)
		{
			if (avatarRenderer == null && geActor == null)
			{
				return;
			}
			if (itemID > 0)
			{
				string itemModulePath = Utility.GetItemModulePath(itemID);
				this.AvatarEquipWingFromRes(avatarRenderer, itemModulePath, attachNode, geActor, highPriority, attachName);
			}
			else
			{
				if (geActor != null)
				{
					GeAttach attachment = geActor.GetAttachment(attachName);
					if (attachment != null)
					{
						geActor.DestroyAttachment(attachment);
					}
				}
				if (avatarRenderer != null)
				{
					GeAttach attachment2 = avatarRenderer.GetAttachment(attachName);
					if (attachment2 != null)
					{
						avatarRenderer.RemoveAttach(attachment2);
					}
				}
				if (attachName == "halo")
				{
					this.SetFootIndocator(avatarRenderer, geActor, true);
				}
			}
		}

		// Token: 0x06009E2E RID: 40494 RVA: 0x001F5CBC File Offset: 0x001F40BC
		private void UpdatePackSizeByType(string packageTypeStr)
		{
			if (string.IsNullOrEmpty(packageTypeStr))
			{
				return;
			}
			string[] array = packageTypeStr.Split(new char[]
			{
				'|'
			});
			if (array.Length > 0)
			{
				foreach (string text in array)
				{
					if (!string.IsNullOrEmpty(text))
					{
						string[] array2 = text.Split(new char[]
						{
							','
						});
						if (array2.Length == 2)
						{
							int num = int.Parse(array2[0]);
							int num2 = int.Parse(array2[1]);
							if (num == 5 || num == 14)
							{
								this.FashionPackBaseSize = num2;
							}
							else if (num == 10)
							{
								this.TitlePackBaseSize = num2;
							}
						}
					}
				}
			}
			int num3 = 5;
			this.PackTotalSize[num3] = this.FashionPackBaseSize;
			if (num3 < this.PackAddSize.Count)
			{
				List<int> packTotalSize;
				int index;
				(packTotalSize = this.PackTotalSize)[index = num3] = packTotalSize[index] + this.PackAddSize[num3];
			}
			int num4 = 14;
			this.PackTotalSize[num4] = this.FashionPackBaseSize;
			if (num4 < this.PackAddSize.Count)
			{
				List<int> packTotalSize;
				int index2;
				(packTotalSize = this.PackTotalSize)[index2 = num4] = packTotalSize[index2] + this.PackAddSize[num4];
			}
			int num5 = 10;
			this.PackTotalSize[num5] = this.TitlePackBaseSize;
			if (num5 < this.PackAddSize.Count)
			{
				List<int> packTotalSize;
				int index3;
				(packTotalSize = this.PackTotalSize)[index3 = num5] = packTotalSize[index3] + this.PackAddSize[num5];
			}
		}

		// Token: 0x0400567A RID: 22138
		private bool m_bNotify = true;

		// Token: 0x0400567B RID: 22139
		private bool m_bIsWear;

		// Token: 0x0400567C RID: 22140
		private bool m_bIsExpand;

		// Token: 0x0400567D RID: 22141
		private bool m_bIsSetPreferenceRole;

		// Token: 0x0400567E RID: 22142
		private bool m_bIsCancelPreferenceRole;

		// Token: 0x0400567F RID: 22143
		private bool m_bIsSelectedPerfectWashingRollTab;

		// Token: 0x04005680 RID: 22144
		private BeFightBuffManager buffMgr = new BeFightBuffManager();

		// Token: 0x04005681 RID: 22145
		private int mPlayerMaxLv;

		// Token: 0x04005682 RID: 22146
		public bool bLevelUpChange;

		// Token: 0x04005683 RID: 22147
		public PlayerBaseData.OnMoneyChanged onMoneyChanged;

		// Token: 0x04005684 RID: 22148
		public PlayerAvatar avatar;

		// Token: 0x04005685 RID: 22149
		public bool isShowFashionWeapon;

		// Token: 0x04005686 RID: 22150
		public float AxisScale = 10000f;

		// Token: 0x04005687 RID: 22151
		public bool bInitializeTownSystem;

		// Token: 0x04005688 RID: 22152
		public List<uint> potionSets = new List<uint>();

		// Token: 0x04005689 RID: 22153
		public List<uint> tmpPostionSets = new List<uint>();

		// Token: 0x0400568A RID: 22154
		private const int defaultPotionPercent = 50;

		// Token: 0x0400568B RID: 22155
		private string m_kSavePath = "PotionPercentSet.json";

		// Token: 0x0400568C RID: 22156
		private string jsonText;

		// Token: 0x0400568D RID: 22157
		public const string potionSlotMainSwitchKeyName = "PotionSlotMainSwitch";

		// Token: 0x0400568E RID: 22158
		public const string potionSlot1SwitchKeyName = "PotionSlot1Switch";

		// Token: 0x0400568F RID: 22159
		public const string potionSlot2SwitchKeyName = "PotionSlot2Switch";

		// Token: 0x04005690 RID: 22160
		public int appointmentOccu;

		// Token: 0x04005691 RID: 22161
		private ulong ulRoleId;

		// Token: 0x04005692 RID: 22162
		public int ZoneID;

		// Token: 0x04005693 RID: 22163
		public string Name;

		// Token: 0x04005694 RID: 22164
		public int ResistMagicValue;

		// Token: 0x04005695 RID: 22165
		public PlayerBaseData.OnLevelChanged onLevelChanged;

		// Token: 0x04005696 RID: 22166
		private ushort iLevel;

		// Token: 0x04005697 RID: 22167
		private int iActivityValue;

		// Token: 0x04005698 RID: 22168
		private uint iMissionScore;

		// Token: 0x04005699 RID: 22169
		public PlayerBaseData.OnMissionScoreChanged onMissionScoreChanged;

		// Token: 0x0400569A RID: 22170
		private int iBudoStatus;

		// Token: 0x0400569B RID: 22171
		private AchievementMaskProperty _achievementMask;

		// Token: 0x0400569C RID: 22172
		private DailyTaskMaskProperty dailyTaskMaskProperty;

		// Token: 0x0400569D RID: 22173
		public ulong CurExp;

		// Token: 0x0400569E RID: 22174
		public ulong Exp;

		// Token: 0x0400569F RID: 22175
		public bool IsFlyUpState;

		// Token: 0x040056A0 RID: 22176
		public int Sex;

		// Token: 0x040056A1 RID: 22177
		public int NewbieGuideSaveBoot;

		// Token: 0x040056A2 RID: 22178
		public int NewbieGuideCurSaveOrder;

		// Token: 0x040056A3 RID: 22179
		public List<int> NewbieGuideWeakGuideList = new List<int>();

		// Token: 0x040056A4 RID: 22180
		private bool bIsForceGuide;

		// Token: 0x040056A5 RID: 22181
		private bool bIsWeakGuide;

		// Token: 0x040056A6 RID: 22182
		public bool bIsInitNewbieGuideData = true;

		// Token: 0x040056A7 RID: 22183
		public int GuideFinishMission;

		// Token: 0x040056A8 RID: 22184
		public int HP;

		// Token: 0x040056A9 RID: 22185
		public int MaxHP;

		// Token: 0x040056AA RID: 22186
		private int chiji_hp;

		// Token: 0x040056AB RID: 22187
		private int chiji_mp;

		// Token: 0x040056AC RID: 22188
		public Vector3 Pos;

		// Token: 0x040056AD RID: 22189
		public bool FaceRight;

		// Token: 0x040056AE RID: 22190
		public float MoveSpeedRate;

		// Token: 0x040056AF RID: 22191
		public ushort fatigue;

		// Token: 0x040056B0 RID: 22192
		public ushort MaxFatigue;

		// Token: 0x040056B1 RID: 22193
		public uint AuctionLastRefreshTime;

		// Token: 0x040056B2 RID: 22194
		public int AddAuctionFieldsNum;

		// Token: 0x040056B3 RID: 22195
		private CrypticUlong ulGoodTeacherValue;

		// Token: 0x040056B4 RID: 22196
		private CrypticUlong ulGold;

		// Token: 0x040056B5 RID: 22197
		private ulong titleGuid;

		// Token: 0x040056B6 RID: 22198
		private string titleName;

		// Token: 0x040056B7 RID: 22199
		private PlayerWearedTitleInfo wearedTitleInfo;

		// Token: 0x040056B8 RID: 22200
		private uint guildEmblemLv;

		// Token: 0x040056B9 RID: 22201
		private CrypticUlong ulBindGold;

		// Token: 0x040056BA RID: 22202
		private CrypticUlong weaponLeaseTicket;

		// Token: 0x040056BB RID: 22203
		private CrypticUlong intergralMallTicket;

		// Token: 0x040056BC RID: 22204
		private CrypticInt32 ulTicket;

		// Token: 0x040056BD RID: 22205
		private CrypticInt32 ulTicketEx;

		// Token: 0x040056BE RID: 22206
		private CrypticInt32 ulBindTicket;

		// Token: 0x040056BF RID: 22207
		public uint CreditTicketOwnerBySelf;

		// Token: 0x040056C0 RID: 22208
		public uint CreditTicketGetInMonth;

		// Token: 0x040056C1 RID: 22209
		private CrypticUlong ulGoldJarScore;

		// Token: 0x040056C2 RID: 22210
		private CrypticUlong ulMagicJarScore;

		// Token: 0x040056C3 RID: 22211
		private CrypticUlong ulAppointmentCoin;

		// Token: 0x040056C4 RID: 22212
		public PlayerBaseData.OnRoleCreateTimeChanged onRoleCreateTimeChanged;

		// Token: 0x040056C5 RID: 22213
		private uint uiRoleCreateTime;

		// Token: 0x040056C6 RID: 22214
		public int VipLevel = -1;

		// Token: 0x040056C7 RID: 22215
		private uint iMonthCardLv;

		// Token: 0x040056C8 RID: 22216
		public int CurVipLvRmb;

		// Token: 0x040056C9 RID: 22217
		private CrypticUlong ulAliveCoin;

		// Token: 0x040056CA RID: 22218
		private uint uiWarriorSoul;

		// Token: 0x040056CB RID: 22219
		public uint pkPoints;

		// Token: 0x040056CC RID: 22220
		public uint pkMatchScore;

		// Token: 0x040056CD RID: 22221
		private uint pkCoin;

		// Token: 0x040056CE RID: 22222
		public int ChanllengeScore;

		// Token: 0x040056CF RID: 22223
		public bool bPkClickVipCharge;

		// Token: 0x040056D0 RID: 22224
		public int PackBaseSize;

		// Token: 0x040056D1 RID: 22225
		public int FashionPackBaseSize;

		// Token: 0x040056D2 RID: 22226
		public int TitlePackBaseSize;

		// Token: 0x040056D3 RID: 22227
		public List<int> PackAddSize = new List<int>();

		// Token: 0x040056D4 RID: 22228
		public List<int> PackTotalSize = new List<int>(15);

		// Token: 0x040056D5 RID: 22229
		public int AccountStorageSize = 50;

		// Token: 0x040056D6 RID: 22230
		public int RoleStorageSize = 30;

		// Token: 0x040056D7 RID: 22231
		private uint _dayChargeNum;

		// Token: 0x040056D8 RID: 22232
		private int _achievementScore;

		// Token: 0x040056D9 RID: 22233
		private int _accountAchievementScore;

		// Token: 0x040056DA RID: 22234
		private int _roleAchievementScore;

		// Token: 0x040056DB RID: 22235
		private bool isRoleEnterGame;

		// Token: 0x040056DC RID: 22236
		private uint _ChijiScore;

		// Token: 0x040056DD RID: 22237
		public uint iTittle;

		// Token: 0x040056DE RID: 22238
		private uint totalEquipScore;

		// Token: 0x040056DF RID: 22239
		public int AwakeState = -1;

		// Token: 0x040056E0 RID: 22240
		public bool bNeedShowAwakeFrame;

		// Token: 0x040056E1 RID: 22241
		public List<int> UnlockFuncList = new List<int>();

		// Token: 0x040056E2 RID: 22242
		public List<int> NewUnlockFuncList = new List<int>();

		// Token: 0x040056E3 RID: 22243
		public List<int> NewUnlockNotPlayFuncList = new List<int>();

		// Token: 0x040056E4 RID: 22244
		public byte NextUnlockFunc;

		// Token: 0x040056E5 RID: 22245
		public List<int> UnlockAreaList = new List<int>();

		// Token: 0x040056E6 RID: 22246
		public uint DeathTowerWipeoutEndTime;

		// Token: 0x040056E7 RID: 22247
		private int m_jobTableID = Global.Settings.iSingleCharactorID;

		// Token: 0x040056E8 RID: 22248
		public int PreChangeJobTableID;

		// Token: 0x040056E9 RID: 22249
		public ChangeJobState eChangeJobState;

		// Token: 0x040056EA RID: 22250
		private List<int> m_activeJobTableIDs = new List<int>();

		// Token: 0x040056EB RID: 22251
		private string puiplAnnouncement = string.Empty;

		// Token: 0x040056EC RID: 22252
		private bool _getPupilSetting = true;

		// Token: 0x040056ED RID: 22253
		public string guildName = string.Empty;

		// Token: 0x040056EE RID: 22254
		public EGuildDuty eGuildDuty;

		// Token: 0x040056EF RID: 22255
		public byte guildDuty;

		// Token: 0x040056F0 RID: 22256
		private int ms_nGuildContribution;

		// Token: 0x040056F1 RID: 22257
		public int guildBattleTimes;

		// Token: 0x040056F2 RID: 22258
		public int guildBattleScore;

		// Token: 0x040056F3 RID: 22259
		public GuildBattleMaskProperty guildBattleRewardMask;

		// Token: 0x040056F4 RID: 22260
		public uint gameOptions;

		// Token: 0x040056F5 RID: 22261
		public uint adventureCoin;

		// Token: 0x040056F6 RID: 22262
		public uint SP;

		// Token: 0x040056F7 RID: 22263
		public uint SP2;

		// Token: 0x040056F8 RID: 22264
		public uint pvpSP;

		// Token: 0x040056F9 RID: 22265
		public uint pvpSP2;

		// Token: 0x040056FA RID: 22266
		public uint FairDuelSp;

		// Token: 0x040056FB RID: 22267
		public List<Battle.DungeonBuff> buffList = new List<Battle.DungeonBuff>();

		// Token: 0x040056FC RID: 22268
		public List<Battle.DungeonBuff> removedBuffList = new List<Battle.DungeonBuff>();

		// Token: 0x040056FD RID: 22269
		public GameMailData mails = new GameMailData();

		// Token: 0x040056FE RID: 22270
		public Dictionary<byte, PkStatistic> PkStatisticsData = new Dictionary<byte, PkStatistic>();

		// Token: 0x040056FF RID: 22271
		public Dictionary<MallType, Dictionary<MallTypeTable.eMallType, Dictionary<MallTypeTable.eMallSubType, Dictionary<int, List<MallItemInfo>>>>> MallItemData = new Dictionary<MallType, Dictionary<MallTypeTable.eMallType, Dictionary<MallTypeTable.eMallSubType, Dictionary<int, List<MallItemInfo>>>>>();

		// Token: 0x0200106A RID: 4202
		public enum MoneyBinderType
		{
			// Token: 0x04005702 RID: 22274
			MBT_OTHER = -1,
			// Token: 0x04005703 RID: 22275
			MBT_GOLD,
			// Token: 0x04005704 RID: 22276
			MBT_BIND_GOLD,
			// Token: 0x04005705 RID: 22277
			MBT_POINT,
			// Token: 0x04005706 RID: 22278
			MBT_POINTEX,
			// Token: 0x04005707 RID: 22279
			MBT_BIND_POINT,
			// Token: 0x04005708 RID: 22280
			MBT_ALIVE_COIN,
			// Token: 0x04005709 RID: 22281
			MBT_WARRIOR_SOUL,
			// Token: 0x0400570A RID: 22282
			MBT_PKMONSETR_COIN,
			// Token: 0x0400570B RID: 22283
			MBT_FIGHT_COIN,
			// Token: 0x0400570C RID: 22284
			MBT_GUILD_CONTRIBUTION,
			// Token: 0x0400570D RID: 22285
			MBT_GOLD_JAR_SCORE,
			// Token: 0x0400570E RID: 22286
			MBT_Magic_JAR_SCORE,
			// Token: 0x0400570F RID: 22287
			MBT_Appoinment_Coin,
			// Token: 0x04005710 RID: 22288
			MBT_GoodTeacher_Value,
			// Token: 0x04005711 RID: 22289
			MBT_WEAPON_LEASE_TICKET,
			// Token: 0x04005712 RID: 22290
			MBT_INTERGRALMALL_TICKET
		}

		// Token: 0x0200106B RID: 4203
		// (Invoke) Token: 0x06009E31 RID: 40497
		public delegate void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType);

		// Token: 0x0200106C RID: 4204
		public enum PotionSlotType
		{
			// Token: 0x04005714 RID: 22292
			SlotMain,
			// Token: 0x04005715 RID: 22293
			SlotExtend1,
			// Token: 0x04005716 RID: 22294
			SlotExtend2
		}

		// Token: 0x0200106D RID: 4205
		// (Invoke) Token: 0x06009E35 RID: 40501
		public delegate void OnLevelChanged(int iPreLv, int iCurLv);

		// Token: 0x0200106E RID: 4206
		// (Invoke) Token: 0x06009E39 RID: 40505
		public delegate void OnMissionScoreChanged(int iValue);

		// Token: 0x0200106F RID: 4207
		// (Invoke) Token: 0x06009E3D RID: 40509
		public delegate void OnRoleCreateTimeChanged();
	}
}
