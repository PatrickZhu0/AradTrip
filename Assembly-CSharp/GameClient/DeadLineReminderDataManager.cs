using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001239 RID: 4665
	public class DeadLineReminderDataManager : DataManager<DeadLineReminderDataManager>
	{
		// Token: 0x0600B356 RID: 45910 RVA: 0x0027DCB3 File Offset: 0x0027C0B3
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B357 RID: 45911 RVA: 0x0027DCB7 File Offset: 0x0027C0B7
		public sealed override void Clear()
		{
			if (this.mDeadLineReminderModelList != null)
			{
				this.mDeadLineReminderModelList.Clear();
			}
			this._UnBindNetMessage();
			this._ClearDeadlineNotifyFlagList();
			this.mUpdateTimer = 0f;
		}

		// Token: 0x0600B358 RID: 45912 RVA: 0x0027DCE8 File Offset: 0x0027C0E8
		public sealed override void Initialize()
		{
			this._BindNetMessage();
			this._InitDeadlineNotifyFlagList();
			this.mUpdateFlag = DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_CURRENCY_DEADLINE_CHECK);
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(627, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mUpdateCD = (float)tableItem.Value;
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(596, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.mRefreshHour = tableItem2.Value;
			}
		}

		// Token: 0x0600B359 RID: 45913 RVA: 0x0027DD6C File Offset: 0x0027C16C
		public sealed override void Update(float a_fTime)
		{
			if (!this.mUpdateFlag)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem == null || !(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
			{
				return;
			}
			this.mUpdateTimer += a_fTime;
			if (this.mUpdateTimer >= this.mUpdateCD)
			{
				this.CheckCurrencyDeadlineStatus();
				this.mUpdateTimer = 0f;
			}
		}

		// Token: 0x0600B35A RID: 45914 RVA: 0x0027DDD9 File Offset: 0x0027C1D9
		private void _BindNetMessage()
		{
			NetProcess.AddMsgHandler(501154U, new Action<MsgDATA>(this.OnAddNotify));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVICE_CURRENCY_DEADLINE_CHECK, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServiceFuncChange));
		}

		// Token: 0x0600B35B RID: 45915 RVA: 0x0027DE09 File Offset: 0x0027C209
		private void _UnBindNetMessage()
		{
			NetProcess.RemoveMsgHandler(501154U, new Action<MsgDATA>(this.OnAddNotify));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVICE_CURRENCY_DEADLINE_CHECK, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServiceFuncChange));
		}

		// Token: 0x0600B35C RID: 45916 RVA: 0x0027DE39 File Offset: 0x0027C239
		private void _OnServiceFuncChange(ServerSceneFuncSwitch ssfSwitch)
		{
			if (ssfSwitch.sType == ServiceType.SERVICE_CURRENCY_DEADLINE_CHECK)
			{
				this.mUpdateFlag = ssfSwitch.sIsOpen;
			}
		}

		// Token: 0x0600B35D RID: 45917 RVA: 0x0027DE54 File Offset: 0x0027C254
		public List<DeadLineReminderModel> GetDeadLineReminderModelList()
		{
			if (this.mDeadLineReminderModelList == null)
			{
				this.mDeadLineReminderModelList = new List<DeadLineReminderModel>();
			}
			return this.mDeadLineReminderModelList;
		}

		// Token: 0x0600B35E RID: 45918 RVA: 0x0027DE72 File Offset: 0x0027C272
		public void Add(DeadLineReminderModel model)
		{
			this.mDeadLineReminderModelList.Add(model);
		}

		// Token: 0x0600B35F RID: 45919 RVA: 0x0027DE80 File Offset: 0x0027C280
		public void RemoveAll(ulong guid)
		{
			this.mDeadLineReminderModelList.RemoveAll((DeadLineReminderModel x) => x.type == DeadLineReminderType.DRT_LIMITTIMEITEM && (x.itemData == null || x.itemData.GUID == guid));
		}

		// Token: 0x0600B360 RID: 45920 RVA: 0x0027DEB2 File Offset: 0x0027C2B2
		public void Sort()
		{
			this.mDeadLineReminderModelList.Sort(delegate(DeadLineReminderModel var1, DeadLineReminderModel var2)
			{
				if (var1.type != var2.type || var1.itemData == null || var2.itemData == null)
				{
					return var1.type.CompareTo(var2.type);
				}
				int num;
				bool flag;
				var1.itemData.GetTimeLeft(out num, out flag);
				int num2;
				bool flag2;
				var2.itemData.GetTimeLeft(out num2, out flag2);
				if (num <= 0)
				{
					if (num2 > 0)
					{
						return -1;
					}
					return 0;
				}
				else
				{
					if (num2 <= 0)
					{
						return 1;
					}
					return num - num2;
				}
			});
		}

		// Token: 0x0600B361 RID: 45921 RVA: 0x0027DEDC File Offset: 0x0027C2DC
		public sealed override void OnBindEnterGameMsg()
		{
			EnterGameBinding enterGameBinding = new EnterGameBinding();
			enterGameBinding.id = 501153U;
			try
			{
				enterGameBinding.method = new Action<MsgDATA>(this.OnInitNotifyInfos);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("错误!! 绑定消息{0}(ID:{1})到方法", new object[]
				{
					Singleton<ProtocolHelper>.instance.GetName(enterGameBinding.id),
					enterGameBinding.id
				});
			}
			this.m_arrEnterGameBindings.Add(enterGameBinding);
		}

		// Token: 0x0600B362 RID: 45922 RVA: 0x0027DF64 File Offset: 0x0027C364
		private void OnInitNotifyInfos(MsgDATA data)
		{
			SceneInitNotifyList sceneInitNotifyList = new SceneInitNotifyList();
			sceneInitNotifyList.decode(data.bytes);
			for (int i = 0; i < sceneInitNotifyList.notifys.Length; i++)
			{
				NotifyInfo notifyInfo = sceneInitNotifyList.notifys[i];
				if (notifyInfo != null)
				{
					if (DeadLineReminderDataManager.IsDeadlineReminderType((NotifyType)notifyInfo.type))
					{
						DeadLineReminderModel item = new DeadLineReminderModel
						{
							type = DeadLineReminderType.DRT_NOTIFYINFO,
							info = notifyInfo
						};
						this.mDeadLineReminderModelList.Add(item);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DeadLineReminderChanged, null, null, null, null);
		}

		// Token: 0x0600B363 RID: 45923 RVA: 0x0027E000 File Offset: 0x0027C400
		private void OnAddNotify(MsgDATA msg)
		{
			SceneUpdateNotifyList sceneUpdateNotifyList = new SceneUpdateNotifyList();
			sceneUpdateNotifyList.decode(msg.bytes);
			this.AddActivityNotice(sceneUpdateNotifyList.notify);
		}

		// Token: 0x0600B364 RID: 45924 RVA: 0x0027E02C File Offset: 0x0027C42C
		public void AddActivityNotice(NotifyInfo a_info)
		{
			NotifyType type = (NotifyType)a_info.type;
			if (!DeadLineReminderDataManager.IsDeadlineReminderType(type))
			{
				return;
			}
			if (this._IsDeadLineNotified(type))
			{
				return;
			}
			if (this._IsDeadLineNotifiedToday(type))
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.mDeadLineReminderModelList.Count; i++)
			{
				if (this.mDeadLineReminderModelList[i].type == DeadLineReminderType.DRT_NOTIFYINFO && this.mDeadLineReminderModelList[i].info.type == a_info.type && this.mDeadLineReminderModelList[i].info.param == a_info.param)
				{
					this.mDeadLineReminderModelList[i].info = a_info;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				DeadLineReminderModel item = new DeadLineReminderModel
				{
					type = DeadLineReminderType.DRT_NOTIFYINFO,
					info = a_info
				};
				this.mDeadLineReminderModelList.Add(item);
				this._UpdateDeadLineNotifyFlagList(type, true);
				this._SaveDeadLineNotifyTimestamp(type);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DeadLineReminderChanged, null, null, null, null);
			}
		}

		// Token: 0x0600B365 RID: 45925 RVA: 0x0027E144 File Offset: 0x0027C544
		public void DeleteActivityNotice(NotifyInfo a_info)
		{
			for (int i = 0; i < this.mDeadLineReminderModelList.Count; i++)
			{
				if (this.mDeadLineReminderModelList[i].type == DeadLineReminderType.DRT_NOTIFYINFO && this.mDeadLineReminderModelList[i].info.type == a_info.type && this.mDeadLineReminderModelList[i].info.param == a_info.param)
				{
					this.mDeadLineReminderModelList.RemoveAt(i);
					this.SendMsgRemoveNotice(a_info);
					break;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DeadLineReminderChanged, null, null, null, null);
		}

		// Token: 0x0600B366 RID: 45926 RVA: 0x0027E1F4 File Offset: 0x0027C5F4
		public void DeleteLimitTimeItem(ItemData itemData)
		{
			for (int i = 0; i < this.mDeadLineReminderModelList.Count; i++)
			{
				if (this.mDeadLineReminderModelList[i].type == DeadLineReminderType.DRT_LIMITTIMEITEM)
				{
					if (this.mDeadLineReminderModelList[i].itemData.GUID == itemData.GUID)
					{
						this.mDeadLineReminderModelList.RemoveAt(i);
						this.SendMsgRemoveLimitTimeItem(itemData);
						break;
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DeadLineReminderChanged, null, null, null, null);
		}

		// Token: 0x0600B367 RID: 45927 RVA: 0x0027E28A File Offset: 0x0027C68A
		public void DeleteFailureItem()
		{
			this.mDeadLineReminderModelList.RemoveAll(delegate(DeadLineReminderModel x)
			{
				if (x.type != DeadLineReminderType.DRT_LIMITTIMEITEM)
				{
					return false;
				}
				if (x.itemData == null)
				{
					return true;
				}
				int num;
				bool flag;
				x.itemData.GetTimeLeft(out num, out flag);
				if (flag && num <= 0)
				{
					this.SendMsgRemoveLimitTimeItem(x.itemData);
					return true;
				}
				return false;
			});
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DeadLineReminderChanged, null, null, null, null);
		}

		// Token: 0x0600B368 RID: 45928 RVA: 0x0027E2B8 File Offset: 0x0027C6B8
		private void SendMsgRemoveNotice(NotifyInfo a_info)
		{
			if (a_info != null)
			{
				SceneDeleteNotifyList sceneDeleteNotifyList = new SceneDeleteNotifyList();
				sceneDeleteNotifyList.notify = a_info;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneDeleteNotifyList>(ServerType.GATE_SERVER, sceneDeleteNotifyList);
			}
		}

		// Token: 0x0600B369 RID: 45929 RVA: 0x0027E2E8 File Offset: 0x0027C6E8
		private void SendMsgRemoveLimitTimeItem(ItemData itemData)
		{
			if (itemData != null)
			{
				SceneDeleteNotifyList sceneDeleteNotifyList = new SceneDeleteNotifyList();
				sceneDeleteNotifyList.notify.type = 5U;
				sceneDeleteNotifyList.notify.param = itemData.GUID;
				NetManager.Instance().SendCommand<SceneDeleteNotifyList>(ServerType.GATE_SERVER, sceneDeleteNotifyList);
			}
		}

		// Token: 0x0600B36A RID: 45930 RVA: 0x0027E32B File Offset: 0x0027C72B
		public static bool IsDeadlineReminderType(NotifyType type)
		{
			return type == NotifyType.NT_MAGIC_INTEGRAL_EMPTYING || type == NotifyType.NT_MONTH_CARD_REWARD_EXPIRE_24H || type == NotifyType.NT_ADVENTURE_TEAM_BOUNTY_EMPTYING || type == NotifyType.NT_ADVENTURE_TEAM_INHERIT_BLESS_EMPTYING || type == NotifyType.NT_ADVENTURE_PASS_CARD_COIN_EMPTYING;
		}

		// Token: 0x0600B36B RID: 45931 RVA: 0x0027E358 File Offset: 0x0027C758
		public string GetDeadlineReminderItemIcon(NotifyType type)
		{
			string empty = string.Empty;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<CurrencyQuickTipsTable>();
			if (table == null)
			{
				return empty;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				CurrencyQuickTipsTable currencyQuickTipsTable = keyValuePair.Value as CurrencyQuickTipsTable;
				if (currencyQuickTipsTable != null)
				{
					if (currencyQuickTipsTable.NotifyType == (CurrencyQuickTipsTable.eNotifyType)type)
					{
						return currencyQuickTipsTable.NotifyIcon;
					}
				}
			}
			return empty;
		}

		// Token: 0x0600B36C RID: 45932 RVA: 0x0027E3CC File Offset: 0x0027C7CC
		private void _InitDeadlineNotifyFlagList()
		{
			if (this.mDeadLineNotifyFlagList == null)
			{
				this.mDeadLineNotifyFlagList = new List<DeadLineNotifyFlag>();
			}
			for (int i = 0; i < 13; i++)
			{
				NotifyType notifyType = (NotifyType)i;
				if (DeadLineReminderDataManager.IsDeadlineReminderType(notifyType))
				{
					DeadLineNotifyFlag item = new DeadLineNotifyFlag
					{
						notifyType = notifyType,
						isThisLoginNotified = false
					};
					this.mDeadLineNotifyFlagList.Add(item);
				}
			}
		}

		// Token: 0x0600B36D RID: 45933 RVA: 0x0027E436 File Offset: 0x0027C836
		private void _ClearDeadlineNotifyFlagList()
		{
			if (this.mDeadLineNotifyFlagList != null)
			{
				this.mDeadLineNotifyFlagList.Clear();
			}
		}

		// Token: 0x0600B36E RID: 45934 RVA: 0x0027E450 File Offset: 0x0027C850
		private void _UpdateDeadLineNotifyFlagList(NotifyType type, bool isNotified)
		{
			if (this.mDeadLineNotifyFlagList == null)
			{
				return;
			}
			for (int i = 0; i < this.mDeadLineNotifyFlagList.Count; i++)
			{
				DeadLineNotifyFlag deadLineNotifyFlag = this.mDeadLineNotifyFlagList[i];
				if (deadLineNotifyFlag != null)
				{
					if (deadLineNotifyFlag.notifyType == type)
					{
						deadLineNotifyFlag.isThisLoginNotified = isNotified;
						break;
					}
				}
			}
		}

		// Token: 0x0600B36F RID: 45935 RVA: 0x0027E4B8 File Offset: 0x0027C8B8
		private bool _IsDeadLineNotified(NotifyType type)
		{
			if (this.mDeadLineNotifyFlagList == null)
			{
				return false;
			}
			for (int i = 0; i < this.mDeadLineNotifyFlagList.Count; i++)
			{
				DeadLineNotifyFlag deadLineNotifyFlag = this.mDeadLineNotifyFlagList[i];
				if (deadLineNotifyFlag != null)
				{
					if (deadLineNotifyFlag.notifyType == type)
					{
						return deadLineNotifyFlag.isThisLoginNotified;
					}
				}
			}
			return false;
		}

		// Token: 0x0600B370 RID: 45936 RVA: 0x0027E51C File Offset: 0x0027C91C
		private bool _IsDeadLineNotifiedToday(NotifyType type)
		{
			int typeKeyIntValue = Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.CurrencyDeadLineTipsTime, new object[]
			{
				string.Format("NotifyType{0}", (int)type)
			});
			return typeKeyIntValue > Function.GetRefreshHourTimeStamp(this.mRefreshHour);
		}

		// Token: 0x0600B371 RID: 45937 RVA: 0x0027E564 File Offset: 0x0027C964
		private void _SaveDeadLineNotifyTimestamp(NotifyType type)
		{
			int currTimeStamp = Function.GetCurrTimeStamp();
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.CurrencyDeadLineTipsTime, currTimeStamp, new object[]
			{
				string.Format("NotifyType{0}", (int)type)
			});
		}

		// Token: 0x0600B372 RID: 45938 RVA: 0x0027E59C File Offset: 0x0027C99C
		public void CheckCurrencyDeadlineStatus()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<CurrencyQuickTipsTable>();
			if (table == null)
			{
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				CurrencyQuickTipsTable currencyQuickTipsTable = keyValuePair.Value as CurrencyQuickTipsTable;
				if (currencyQuickTipsTable != null)
				{
					if (currencyQuickTipsTable.NotifyType == CurrencyQuickTipsTable.eNotifyType.NT_ADVENTURE_PASS_CARD_COIN_EMPTYING)
					{
						if (!this.IsAdventurnPassCardSeasonInDeadLine(currencyQuickTipsTable))
						{
							continue;
						}
					}
					else if (!this._IsOwnedSpecialCurrency(currencyQuickTipsTable.NotifyType) && !this._IsOwnedCurrency(currencyQuickTipsTable.ID, 0))
					{
						continue;
					}
					NotifyInfo a_info = new NotifyInfo
					{
						type = (uint)currencyQuickTipsTable.NotifyType
					};
					if (this._IsInDeadline(currencyQuickTipsTable))
					{
						this.AddActivityNotice(a_info);
					}
					else
					{
						this.DeleteActivityNotice(a_info);
					}
				}
			}
		}

		// Token: 0x0600B373 RID: 45939 RVA: 0x0027E678 File Offset: 0x0027CA78
		public bool _IsOwnedCurrency(int itemTableId, int count = 0)
		{
			bool result = false;
			if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemTableId, true) > count)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600B374 RID: 45940 RVA: 0x0027E69C File Offset: 0x0027CA9C
		private bool _IsOwnedSpecialCurrency(CurrencyQuickTipsTable.eNotifyType notifyType)
		{
			if (notifyType == CurrencyQuickTipsTable.eNotifyType.NT_ADVENTURE_TEAM_INHERIT_BLESS_EMPTYING)
			{
				ulong adventureTeamPassBlessCount = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamPassBlessCount();
				ulong adventureTeamPassBlessExp = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamPassBlessExp();
				ulong adventureTeamPassBlessUnitExp = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamPassBlessUnitExp();
				if (adventureTeamPassBlessCount > 0UL || adventureTeamPassBlessExp >= adventureTeamPassBlessUnitExp)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B375 RID: 45941 RVA: 0x0027E6E4 File Offset: 0x0027CAE4
		private bool IsAdventurnPassCardSeasonInDeadLine(CurrencyQuickTipsTable currencyQuickTipsTable)
		{
			if (currencyQuickTipsTable == null || currencyQuickTipsTable.NotifyType != CurrencyQuickTipsTable.eNotifyType.NT_ADVENTURE_PASS_CARD_COIN_EMPTYING)
			{
				return false;
			}
			if (DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID == 0U)
			{
				return false;
			}
			if (DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv == 0U)
			{
				return false;
			}
			uint num = (uint)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime() + (ulong)((long)(currencyQuickTipsTable.PromptTime * 3600 * 24)));
			return (ulong)num >= (ulong)((long)DataManager<AdventurerPassCardDataManager>.GetInstance().GetSeasonEndTime());
		}

		// Token: 0x0600B376 RID: 45942 RVA: 0x0027E758 File Offset: 0x0027CB58
		public bool _IsInDeadline(CurrencyQuickTipsTable table)
		{
			if (table != null && table.NotifyType == CurrencyQuickTipsTable.eNotifyType.NT_ADVENTURE_PASS_CARD_COIN_EMPTYING)
			{
				return this.IsAdventurnPassCardSeasonInDeadLine(table);
			}
			bool result = false;
			if (table == null)
			{
				return result;
			}
			int day = this._GetTimeFromTable(table.ResetTimePoint, table.ResetType, DeadLineTimePoint.Day);
			int hour = this._GetTimeFromTable(table.ResetTimePoint, table.ResetType, DeadLineTimePoint.Hour);
			DateTime[] array = this._GetDurtionDateTime(table.ResetType, day, hour);
			if (array == null || array.Length != 2)
			{
				return result;
			}
			DateTime t = array[0];
			DateTime dateTime = array[1];
			DateTime currDateTime = Function.GetCurrDateTime();
			DateTime t2 = t.AddDays((double)(-(double)table.PromptTime));
			DateTime dateTime2 = dateTime.AddDays((double)(-(double)table.PromptTime));
			if (DateTime.Compare(dateTime2, t) < 0)
			{
				Logger.LogErrorFormat("[DeadLineReminderDateManager] - _GetDeadlineStatus, 注意检查【货币快捷提示表】， 下一次重置时间的前置时间点 在 本次重置时间点 之前了 ！！！", new object[0]);
				return result;
			}
			if (DateTime.Compare(currDateTime, t2) < 0)
			{
				result = false;
			}
			else if (DateTime.Compare(currDateTime, t2) >= 0 && DateTime.Compare(currDateTime, t) < 0)
			{
				result = true;
			}
			else if (DateTime.Compare(currDateTime, t) >= 0 && DateTime.Compare(currDateTime, dateTime2) < 0)
			{
				result = false;
			}
			else if (DateTime.Compare(currDateTime, dateTime2) >= 0)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600B377 RID: 45943 RVA: 0x0027E8AC File Offset: 0x0027CCAC
		private int _GetTimeFromTable(string tableTimes, CurrencyQuickTipsTable.eResetType type, DeadLineTimePoint timePoint)
		{
			int result = 0;
			if (string.IsNullOrEmpty(tableTimes))
			{
				return 0;
			}
			if (type == CurrencyQuickTipsTable.eResetType.None)
			{
				return 0;
			}
			if (type == CurrencyQuickTipsTable.eResetType.Daily && int.TryParse(tableTimes, out result))
			{
				return result;
			}
			string[] array = tableTimes.Split(new char[]
			{
				'|'
			});
			if (array == null || array.Length != 2)
			{
				return 0;
			}
			int result2;
			if (timePoint == DeadLineTimePoint.Day && int.TryParse(array[0], out result2))
			{
				return result2;
			}
			if (timePoint == DeadLineTimePoint.Hour && int.TryParse(array[1], out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x0600B378 RID: 45944 RVA: 0x0027E93C File Offset: 0x0027CD3C
		private DateTime[] _GetDurtionDateTime(CurrencyQuickTipsTable.eResetType type, int day, int hour)
		{
			DateTime currDateTime = Function.GetCurrDateTime();
			DateTime currDateTime2 = Function.GetCurrDateTime();
			if (type != CurrencyQuickTipsTable.eResetType.Monthly)
			{
				if (type != CurrencyQuickTipsTable.eResetType.Weekly)
				{
					if (type == CurrencyQuickTipsTable.eResetType.Daily)
					{
						DateTime dateTime = Function.GetCurrDateTime();
						currDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, 0, 0);
					}
				}
				else
				{
					if (day == 7)
					{
						day = 0;
					}
					else if (day < 0)
					{
						day = 1;
					}
					else if (day > 7)
					{
						day = 7;
					}
					DateTime dateTime = Function.GetThisWeekdayDateTime((DayOfWeek)day);
					currDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, 0, 0);
					DateTime dateTime2 = Function.GetNextWeekdayDateTime((DayOfWeek)day);
					currDateTime2 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, hour, 0, 0);
				}
			}
			else
			{
				DateTime dateTime = Function.GetThisMonthdayDateTime(day);
				currDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, 0, 0);
				DateTime dateTime2 = Function.GetNextMonthdayDateTime(day);
				currDateTime2 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, hour, 0, 0);
			}
			return new DateTime[]
			{
				currDateTime,
				currDateTime2
			};
		}

		// Token: 0x04006517 RID: 25879
		private List<DeadLineReminderModel> mDeadLineReminderModelList = new List<DeadLineReminderModel>();

		// Token: 0x04006518 RID: 25880
		private List<DeadLineNotifyFlag> mDeadLineNotifyFlagList = new List<DeadLineNotifyFlag>();

		// Token: 0x04006519 RID: 25881
		private float mUpdateTimer;

		// Token: 0x0400651A RID: 25882
		private float mUpdateCD = 60f;

		// Token: 0x0400651B RID: 25883
		private bool mUpdateFlag;

		// Token: 0x0400651C RID: 25884
		private int mRefreshHour = 6;
	}
}
