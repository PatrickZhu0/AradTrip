using System;
using System.Collections.Generic;
using AdsPush;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020011D7 RID: 4567
	internal class AdventurerPassCardDataManager : DataManager<AdventurerPassCardDataManager>
	{
		// Token: 0x17001AB1 RID: 6833
		// (get) Token: 0x0600AFC6 RID: 44998 RVA: 0x00269711 File Offset: 0x00267B11
		public uint CardLv
		{
			get
			{
				return this.cardLv;
			}
		}

		// Token: 0x17001AB2 RID: 6834
		// (get) Token: 0x0600AFC7 RID: 44999 RVA: 0x00269719 File Offset: 0x00267B19
		public uint CardExp
		{
			get
			{
				return this.cardExp;
			}
		}

		// Token: 0x17001AB3 RID: 6835
		// (get) Token: 0x0600AFC8 RID: 45000 RVA: 0x00269721 File Offset: 0x00267B21
		public uint SeasonID
		{
			get
			{
				return this.seasonID;
			}
		}

		// Token: 0x17001AB4 RID: 6836
		// (get) Token: 0x0600AFC9 RID: 45001 RVA: 0x00269729 File Offset: 0x00267B29
		public AdventurerPassCardDataManager.PassCardType GetPassCardType
		{
			get
			{
				return this.passCardType;
			}
		}

		// Token: 0x17001AB5 RID: 6837
		// (get) Token: 0x0600AFCA RID: 45002 RVA: 0x00269731 File Offset: 0x00267B31
		// (set) Token: 0x0600AFCB RID: 45003 RVA: 0x00269739 File Offset: 0x00267B39
		public int KingCardItemID { get; private set; }

		// Token: 0x17001AB6 RID: 6838
		// (get) Token: 0x0600AFCC RID: 45004 RVA: 0x00269742 File Offset: 0x00267B42
		// (set) Token: 0x0600AFCD RID: 45005 RVA: 0x0026974A File Offset: 0x00267B4A
		public int KingCardItemPrice { get; private set; }

		// Token: 0x0600AFCE RID: 45006 RVA: 0x00269754 File Offset: 0x00267B54
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
			this.cardLv = 0U;
			this.cardExp = 0U;
			this.seasonID = 0U;
			this.passCardType = AdventurerPassCardDataManager.PassCardType.Normal;
			this.normalReward = string.Empty;
			this.highReward = string.Empty;
			this.activeToday = 0;
			this.seasonStartTime = 0;
			this.seasonEndTime = 0;
			this.expPackState = AdventurerPassCardDataManager.ExpPackState.Lock;
			this.KingCardItemID = 0;
			this.KingCardItemPrice = 0;
			this.seasonID2LevelAward = null;
			this.seasonID2LevelAward = new Dictionary<int, Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo>>();
			if (this.seasonID2LevelAward != null)
			{
				Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassRewardTable>();
				if (table != null)
				{
					Func<string, List<AdventurerPassCardDataManager.ItemInfo>> func = delegate(string awardText)
					{
						if (awardText == null)
						{
							return null;
						}
						List<AdventurerPassCardDataManager.ItemInfo> list = new List<AdventurerPassCardDataManager.ItemInfo>();
						if (list == null)
						{
							return null;
						}
						string[] array = awardText.Split(new char[]
						{
							','
						});
						for (int i = 0; i < array.Length; i++)
						{
							string[] array2 = array[i].Split(new char[]
							{
								'_'
							});
							if (array2.Length >= 3)
							{
								int itemID = 0;
								int.TryParse(array2[0], out itemID);
								int itemNum = 0;
								int.TryParse(array2[1], out itemNum);
								int num = 0;
								int.TryParse(array2[2], out num);
								AdventurerPassCardDataManager.ItemInfo itemInfo = new AdventurerPassCardDataManager.ItemInfo();
								if (itemInfo != null)
								{
									itemInfo.itemID = itemID;
									itemInfo.itemNum = itemNum;
									itemInfo.highValue = (num > 0);
									list.Add(itemInfo);
								}
							}
						}
						return list;
					};
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						AdventurePassRewardTable adventurePassRewardTable = keyValuePair.Value as AdventurePassRewardTable;
						if (adventurePassRewardTable != null)
						{
							if (!this.seasonID2LevelAward.ContainsKey(adventurePassRewardTable.Season))
							{
								this.seasonID2LevelAward.Add(adventurePassRewardTable.Season, new Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo>());
							}
							Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo> dictionary = this.seasonID2LevelAward[adventurePassRewardTable.Season];
							if (dictionary != null)
							{
								if (!dictionary.ContainsKey(adventurePassRewardTable.Lv))
								{
									dictionary.Add(adventurePassRewardTable.Lv, new AdventurerPassCardDataManager.AwardItemInfo());
								}
								AdventurerPassCardDataManager.AwardItemInfo awardItemInfo = dictionary[adventurePassRewardTable.Lv];
								if (awardItemInfo != null)
								{
									awardItemInfo.lv = adventurePassRewardTable.Lv;
									awardItemInfo.normalAwards = func(adventurePassRewardTable.Normal);
									awardItemInfo.highAwards = func(adventurePassRewardTable.High);
									awardItemInfo.exp = adventurePassRewardTable.Exp;
								}
							}
						}
					}
				}
			}
			ChargeMallTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChargeMallTable>(14, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.KingCardItemID = tableItem.ID;
				this.KingCardItemPrice = tableItem.ChargeMoney;
			}
		}

		// Token: 0x0600AFCF RID: 45007 RVA: 0x00269954 File Offset: 0x00267D54
		public override void Clear()
		{
			this._UnBindNetMsg();
			this.cardLv = 0U;
			this.cardExp = 0U;
			this.seasonID = 0U;
			this.passCardType = AdventurerPassCardDataManager.PassCardType.Normal;
			this.normalReward = string.Empty;
			this.highReward = string.Empty;
			this.activeToday = 0;
			this.seasonStartTime = 0;
			this.seasonEndTime = 0;
			this.expPackState = AdventurerPassCardDataManager.ExpPackState.Lock;
			this.KingCardItemID = 0;
			this.KingCardItemPrice = 0;
			this.seasonID2LevelAward = null;
		}

		// Token: 0x0600AFD0 RID: 45008 RVA: 0x002699CC File Offset: 0x00267DCC
		public int GetAdventurerPassCardMaxLv(uint seasonID)
		{
			Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo> adventurePassAwardsBySeasonID = this.GetAdventurePassAwardsBySeasonID(seasonID);
			if (adventurePassAwardsBySeasonID != null)
			{
				return adventurePassAwardsBySeasonID.Count;
			}
			return 0;
		}

		// Token: 0x0600AFD1 RID: 45009 RVA: 0x002699EF File Offset: 0x00267DEF
		public Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo> GetAdventurePassAwardsBySeasonID(uint seasonID)
		{
			if (this.seasonID2LevelAward == null)
			{
				return null;
			}
			if (this.seasonID2LevelAward.ContainsKey((int)seasonID))
			{
				return this.seasonID2LevelAward[(int)seasonID];
			}
			return null;
		}

		// Token: 0x0600AFD2 RID: 45010 RVA: 0x00269A20 File Offset: 0x00267E20
		public AdventurerPassCardDataManager.AwardItemInfo GetAwardItemInfo(uint seasonID, int lv)
		{
			Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo> adventurePassAwardsBySeasonID = this.GetAdventurePassAwardsBySeasonID(seasonID);
			if (adventurePassAwardsBySeasonID == null)
			{
				return null;
			}
			if (adventurePassAwardsBySeasonID.ContainsKey(lv))
			{
				return adventurePassAwardsBySeasonID[lv];
			}
			return null;
		}

		// Token: 0x0600AFD3 RID: 45011 RVA: 0x00269A54 File Offset: 0x00267E54
		public bool IsNormalAwardReceived(int lv)
		{
			int adventurerPassCardMaxLv = this.GetAdventurerPassCardMaxLv(this.seasonID);
			if (lv <= 0 || lv > adventurerPassCardMaxLv)
			{
				return false;
			}
			if (lv > this.normalReward.Length)
			{
				return false;
			}
			AdventurerPassCardDataManager.AwardItemInfo awardItemInfo = this.GetAwardItemInfo(this.seasonID, lv);
			return (awardItemInfo != null && awardItemInfo.normalAwards.Count == 0) || this.normalReward[lv] == '0';
		}

		// Token: 0x0600AFD4 RID: 45012 RVA: 0x00269AC8 File Offset: 0x00267EC8
		public bool IsHighAwardReceived(int lv)
		{
			int adventurerPassCardMaxLv = this.GetAdventurerPassCardMaxLv(this.seasonID);
			return lv > 0 && lv <= adventurerPassCardMaxLv && lv <= this.highReward.Length && this.highReward[lv] == '0';
		}

		// Token: 0x0600AFD5 RID: 45013 RVA: 0x00269B18 File Offset: 0x00267F18
		public int GetNeedExpToNextLv(int lv)
		{
			AdventurerPassCardDataManager.AwardItemInfo awardItemInfo = this.GetAwardItemInfo(this.seasonID, lv);
			if (awardItemInfo == null)
			{
				return 0;
			}
			if (lv >= this.GetAdventurerPassCardMaxLv(this.seasonID))
			{
				return 0;
			}
			return awardItemInfo.exp;
		}

		// Token: 0x0600AFD6 RID: 45014 RVA: 0x00269B58 File Offset: 0x00267F58
		public bool IsBuyKingCardUseRMB(int seasonID)
		{
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AdventurePassBuyRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AdventurePassBuyRewardTable adventurePassBuyRewardTable = keyValuePair.Value as AdventurePassBuyRewardTable;
					if (adventurePassBuyRewardTable != null)
					{
						if (adventurePassBuyRewardTable.Season == seasonID)
						{
							return adventurePassBuyRewardTable.buyType == 1;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600AFD7 RID: 45015 RVA: 0x00269BC5 File Offset: 0x00267FC5
		public void SendBuyKingCardUseRmb()
		{
			Singleton<PayManager>.GetInstance().DoPay(this.KingCardItemID, this.KingCardItemPrice, ChargeMallType.AdventurePassKing);
		}

		// Token: 0x0600AFD8 RID: 45016 RVA: 0x00269BDE File Offset: 0x00267FDE
		public int GetTodayActive()
		{
			return this.activeToday;
		}

		// Token: 0x0600AFD9 RID: 45017 RVA: 0x00269BE6 File Offset: 0x00267FE6
		public int GetSeasonStartTime()
		{
			return this.seasonStartTime;
		}

		// Token: 0x0600AFDA RID: 45018 RVA: 0x00269BEE File Offset: 0x00267FEE
		public int GetSeasonEndTime()
		{
			return this.seasonEndTime;
		}

		// Token: 0x0600AFDB RID: 45019 RVA: 0x00269BF6 File Offset: 0x00267FF6
		public AdventurerPassCardDataManager.ExpPackState GetExpPackState()
		{
			return this.expPackState;
		}

		// Token: 0x0600AFDC RID: 45020 RVA: 0x00269C00 File Offset: 0x00268000
		public int GetCanGetHighAwardItemCopies(int lv)
		{
			int adventurerPassCardMaxLv = this.GetAdventurerPassCardMaxLv(this.seasonID);
			if (lv <= 0 || lv > adventurerPassCardMaxLv)
			{
				return 0;
			}
			if (lv > this.highReward.Length)
			{
				return 0;
			}
			return Utility.ToInt(this.highReward[lv].ToString());
		}

		// Token: 0x0600AFDD RID: 45021 RVA: 0x00269C5C File Offset: 0x0026805C
		public static bool GetShowFlag(AdventurerPassCardDataManager.RedPointShowType redPointShowType)
		{
			if (!PlayerPrefs.HasKey(redPointShowType.ToString()))
			{
				return false;
			}
			DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)DataManager<TimeManager>.GetInstance().GetServerTime());
			string @string = PlayerPrefs.GetString(redPointShowType.ToString());
			if (string.IsNullOrEmpty(@string))
			{
				return false;
			}
			string[] array = @string.Split(new char[]
			{
				'|'
			});
			return array.Length == 2 && array[0] == string.Format("{0}-{1}-{2}", dateTimeByTimeStamp.Year, dateTimeByTimeStamp.Month, dateTimeByTimeStamp.Day) && Utility.ToInt(array[1]) > 0;
		}

		// Token: 0x0600AFDE RID: 45022 RVA: 0x00269D18 File Offset: 0x00268118
		public static void SetShowFlag(AdventurerPassCardDataManager.RedPointShowType redPointShowType, bool value)
		{
			DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)DataManager<TimeManager>.GetInstance().GetServerTime());
			PlayerPrefs.SetString(redPointShowType.ToString(), string.Format("{0}-{1}-{2}", dateTimeByTimeStamp.Year, dateTimeByTimeStamp.Month, dateTimeByTimeStamp.Day) + "|" + value.ToString());
			PlayerPrefs.Save();
		}

		// Token: 0x0600AFDF RID: 45023 RVA: 0x00269D91 File Offset: 0x00268191
		public static void ClearShowFlag(AdventurerPassCardDataManager.RedPointShowType redPointShowType)
		{
			PlayerPrefs.DeleteKey(redPointShowType.ToString());
			PlayerPrefs.Save();
		}

		// Token: 0x0600AFE0 RID: 45024 RVA: 0x00269DAC File Offset: 0x002681AC
		private void _BindNetMsg()
		{
			NetProcess.AddMsgHandler(609502U, new Action<MsgDATA>(this._OnWorldAventurePassStatusRet));
			NetProcess.AddMsgHandler(609504U, new Action<MsgDATA>(this._OnWorldAventurePassBuyRet));
			NetProcess.AddMsgHandler(609506U, new Action<MsgDATA>(this._OnWorldAventurePassBuyLvRet));
			NetProcess.AddMsgHandler(609510U, new Action<MsgDATA>(this._OnWorldAventurePassRewardRet));
			NetProcess.AddMsgHandler(609508U, new Action<MsgDATA>(this._OnWorldAventurePassExpPackRet));
			NetProcess.AddMsgHandler(504003U, new Action<MsgDATA>(this.OnSyncPayRes));
		}

		// Token: 0x0600AFE1 RID: 45025 RVA: 0x00269E40 File Offset: 0x00268240
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(609502U, new Action<MsgDATA>(this._OnWorldAventurePassStatusRet));
			NetProcess.RemoveMsgHandler(609504U, new Action<MsgDATA>(this._OnWorldAventurePassBuyRet));
			NetProcess.RemoveMsgHandler(609506U, new Action<MsgDATA>(this._OnWorldAventurePassBuyLvRet));
			NetProcess.RemoveMsgHandler(609510U, new Action<MsgDATA>(this._OnWorldAventurePassRewardRet));
			NetProcess.RemoveMsgHandler(609508U, new Action<MsgDATA>(this._OnWorldAventurePassExpPackRet));
			NetProcess.RemoveMsgHandler(504003U, new Action<MsgDATA>(this.OnSyncPayRes));
		}

		// Token: 0x0600AFE2 RID: 45026 RVA: 0x00269ED4 File Offset: 0x002682D4
		private void _OnWorldAventurePassStatusRet(MsgDATA a_data)
		{
			WorldAventurePassStatusRet worldAventurePassStatusRet = new WorldAventurePassStatusRet();
			worldAventurePassStatusRet.decode(a_data.bytes);
			uint num = this.cardLv;
			uint num2 = this.seasonID;
			this.cardLv = worldAventurePassStatusRet.lv;
			this.cardExp = worldAventurePassStatusRet.exp;
			this.seasonID = worldAventurePassStatusRet.seasonID;
			this.passCardType = (AdventurerPassCardDataManager.PassCardType)worldAventurePassStatusRet.type;
			this.normalReward = worldAventurePassStatusRet.normalReward;
			this.highReward = worldAventurePassStatusRet.highReward;
			this.activeToday = (int)worldAventurePassStatusRet.activity;
			this.seasonStartTime = (int)worldAventurePassStatusRet.startTime;
			this.seasonEndTime = (int)worldAventurePassStatusRet.endTime;
			if (AdventurerPassCardFrame.CanOneKeyGetAwards() || this.expPackState == AdventurerPassCardDataManager.ExpPackState.CanGet)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateAventurePassButtonRedPoint, true, null, null, null);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateAventurePassButtonRedPoint, false, null, null, null);
			}
			uint num3 = this.cardLv;
			uint num4 = this.seasonID;
			if (num > 0U && num3 > num)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateAventurePassButtonRedPoint, true, null, null, null);
			}
			if (num4 != num2 && num4 > 0U)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateAventurePassButtonRedPoint, true, null, null, null);
			}
			if (Singleton<LoginPushManager>.GetInstance().IsFirstLogin())
			{
				DataManager<DeadLineReminderDataManager>.GetInstance().CheckCurrencyDeadlineStatus();
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateAventurePassStatus, null, null, null, null);
			if (this.cardLv == 0U)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdventurerPassCardFrame>(null, false);
			}
		}

		// Token: 0x0600AFE3 RID: 45027 RVA: 0x0026A058 File Offset: 0x00268458
		private void _OnWorldAventurePassBuyRet(MsgDATA a_data)
		{
			WorldAventurePassBuyRet stream = new WorldAventurePassBuyRet();
			stream.decode(a_data.bytes);
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventurer_pass_card_buy_high_card_success"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			this.SendWorldAventurePassStatusReq();
			this.SendWorldAventurePassExpPackReq(0);
		}

		// Token: 0x0600AFE4 RID: 45028 RVA: 0x0026A098 File Offset: 0x00268498
		private void _OnWorldAventurePassBuyLvRet(MsgDATA a_data)
		{
			WorldAventurePassBuyLvRet worldAventurePassBuyLvRet = new WorldAventurePassBuyLvRet();
			worldAventurePassBuyLvRet.decode(a_data.bytes);
			if (worldAventurePassBuyLvRet.lv > 0U)
			{
				long num = Math.Min((long)((ulong)(worldAventurePassBuyLvRet.lv + DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv)), (long)DataManager<AdventurerPassCardDataManager>.GetInstance().GetAdventurerPassCardMaxLv(DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID));
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventurer_pass_card_buy_lv_up_tip", num), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			this.SendWorldAventurePassStatusReq();
		}

		// Token: 0x0600AFE5 RID: 45029 RVA: 0x0026A110 File Offset: 0x00268510
		private void _OnWorldAventurePassRewardRet(MsgDATA a_data)
		{
			WorldAventurePassRewardRet stream = new WorldAventurePassRewardRet();
			stream.decode(a_data.bytes);
			this.SendWorldAventurePassStatusReq();
		}

		// Token: 0x0600AFE6 RID: 45030 RVA: 0x0026A138 File Offset: 0x00268538
		private void _OnWorldAventurePassExpPackRet(MsgDATA a_data)
		{
			WorldAventurePassExpPackRet worldAventurePassExpPackRet = new WorldAventurePassExpPackRet();
			worldAventurePassExpPackRet.decode(a_data.bytes);
			this.expPackState = (AdventurerPassCardDataManager.ExpPackState)worldAventurePassExpPackRet.type;
			this.SendWorldAventurePassStatusReq();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateAventurePassExpPackStatus, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateAventurePassButtonRedPoint, null, null, null, null);
		}

		// Token: 0x0600AFE7 RID: 45031 RVA: 0x0026A18F File Offset: 0x0026858F
		private void OnSyncPayRes(MsgDATA data)
		{
			if (SDKInterface.instance.IsPayResultNotify())
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPayResultNotify, "0", null, null, null);
			}
			this.SendWorldAventurePassStatusReq();
			this.SendWorldAventurePassExpPackReq(0);
		}

		// Token: 0x0600AFE8 RID: 45032 RVA: 0x0026A1C4 File Offset: 0x002685C4
		public void SendWorldAventurePassStatusReq()
		{
			WorldAventurePassStatusReq cmd = new WorldAventurePassStatusReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAventurePassStatusReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600AFE9 RID: 45033 RVA: 0x0026A1E8 File Offset: 0x002685E8
		public void SendWorldAventurePassBuyReq(byte buyType)
		{
			WorldAventurePassBuyReq worldAventurePassBuyReq = new WorldAventurePassBuyReq();
			worldAventurePassBuyReq.type = buyType;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAventurePassBuyReq>(ServerType.GATE_SERVER, worldAventurePassBuyReq);
		}

		// Token: 0x0600AFEA RID: 45034 RVA: 0x0026A214 File Offset: 0x00268614
		public void SendWorldAventurePassBuyLvReq(uint lv)
		{
			WorldAventurePassBuyLvReq worldAventurePassBuyLvReq = new WorldAventurePassBuyLvReq();
			worldAventurePassBuyLvReq.lv = lv;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAventurePassBuyLvReq>(ServerType.GATE_SERVER, worldAventurePassBuyLvReq);
		}

		// Token: 0x0600AFEB RID: 45035 RVA: 0x0026A240 File Offset: 0x00268640
		public void SendWorldAventurePassRewardReq(uint lv)
		{
			WorldAventurePassRewardReq worldAventurePassRewardReq = new WorldAventurePassRewardReq();
			worldAventurePassRewardReq.lv = lv;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAventurePassRewardReq>(ServerType.GATE_SERVER, worldAventurePassRewardReq);
		}

		// Token: 0x0600AFEC RID: 45036 RVA: 0x0026A26C File Offset: 0x0026866C
		public void SendWorldAventurePassExpPackReq(byte opType)
		{
			WorldAventurePassExpPackReq worldAventurePassExpPackReq = new WorldAventurePassExpPackReq();
			worldAventurePassExpPackReq.op = opType;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAventurePassExpPackReq>(ServerType.GATE_SERVER, worldAventurePassExpPackReq);
		}

		// Token: 0x04006243 RID: 25155
		private uint cardLv;

		// Token: 0x04006244 RID: 25156
		private uint cardExp;

		// Token: 0x04006245 RID: 25157
		private uint seasonID;

		// Token: 0x04006246 RID: 25158
		private AdventurerPassCardDataManager.PassCardType passCardType;

		// Token: 0x04006247 RID: 25159
		private string normalReward;

		// Token: 0x04006248 RID: 25160
		private string highReward;

		// Token: 0x04006249 RID: 25161
		private int activeToday;

		// Token: 0x0400624A RID: 25162
		private int seasonStartTime;

		// Token: 0x0400624B RID: 25163
		private int seasonEndTime;

		// Token: 0x0400624C RID: 25164
		private AdventurerPassCardDataManager.ExpPackState expPackState;

		// Token: 0x0400624D RID: 25165
		private Dictionary<int, Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo>> seasonID2LevelAward = new Dictionary<int, Dictionary<int, AdventurerPassCardDataManager.AwardItemInfo>>();

		// Token: 0x04006250 RID: 25168
		private const int ChargeTableID = 14;

		// Token: 0x020011D8 RID: 4568
		public enum PassCardType
		{
			// Token: 0x04006253 RID: 25171
			Normal,
			// Token: 0x04006254 RID: 25172
			King,
			// Token: 0x04006255 RID: 25173
			HighKing
		}

		// Token: 0x020011D9 RID: 4569
		public class ItemInfo
		{
			// Token: 0x04006256 RID: 25174
			public int itemID;

			// Token: 0x04006257 RID: 25175
			public int itemNum;

			// Token: 0x04006258 RID: 25176
			public bool highValue;
		}

		// Token: 0x020011DA RID: 4570
		public class AwardItemInfo
		{
			// Token: 0x04006259 RID: 25177
			public int lv;

			// Token: 0x0400625A RID: 25178
			public List<AdventurerPassCardDataManager.ItemInfo> normalAwards = new List<AdventurerPassCardDataManager.ItemInfo>();

			// Token: 0x0400625B RID: 25179
			public List<AdventurerPassCardDataManager.ItemInfo> highAwards = new List<AdventurerPassCardDataManager.ItemInfo>();

			// Token: 0x0400625C RID: 25180
			public int exp;
		}

		// Token: 0x020011DB RID: 4571
		public enum ExpPackState
		{
			// Token: 0x0400625E RID: 25182
			Lock,
			// Token: 0x0400625F RID: 25183
			CanGet,
			// Token: 0x04006260 RID: 25184
			Got
		}

		// Token: 0x020011DC RID: 4572
		public enum RedPointShowType
		{
			// Token: 0x04006262 RID: 25186
			UnLockPassCard,
			// Token: 0x04006263 RID: 25187
			SeasonIDOnLineUpdate,
			// Token: 0x04006264 RID: 25188
			SeasonInTheOpenWhenLogin,
			// Token: 0x04006265 RID: 25189
			CanGetExpPack,
			// Token: 0x04006266 RID: 25190
			CardLvUp,
			// Token: 0x04006267 RID: 25191
			CanGetAward
		}
	}
}
