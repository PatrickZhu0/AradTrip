using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200162D RID: 5677
	internal class GuildManorFrame : ClientFrame
	{
		// Token: 0x0600DEDF RID: 57055 RVA: 0x0038CD2C File Offset: 0x0038B12C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildManor";
		}

		// Token: 0x0600DEE0 RID: 57056 RVA: 0x0038CD34 File Offset: 0x0038B134
		protected sealed override void _OnOpenFrame()
		{
			for (int i = 0; i < this.TerritoryIDs.Length; i++)
			{
				int nID = this.TerritoryIDs[i];
				GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(nID, true);
				GameObject gameObject = Utility.FindGameObject(string.Format("Map/Manor{0}", nID), true);
				Button componetInChild = Utility.GetComponetInChild<Button>(gameObject, "Func");
				componetInChild.onClick.RemoveAllListeners();
				componetInChild.onClick.AddListener(delegate()
				{
					DataManager<GuildDataManager>.GetInstance().RequestManorInfo(nID);
				});
				Text componetInChild2 = Utility.GetComponetInChild<Text>(gameObject, "Name/Text");
				componetInChild2.SafeSetText(guildTerritoryTable.Name);
				if (!DataManager<GuildDataManager>.GetInstance().HasTargetManor() && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL && DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Signup && DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.StartGuildBattle, EGuildDuty.Invalid))
				{
					Utility.FindGameObject(gameObject, "ClickToSignup", true).SetActive(true);
				}
				else
				{
					Utility.FindGameObject(gameObject, "ClickToSignup", true).SetActive(false);
				}
				Utility.FindGameObject(gameObject, "AlreadySignup", true).SetActive(nID == DataManager<GuildDataManager>.GetInstance().myGuild.nTargetManorID);
				string manorOwner = DataManager<GuildDataManager>.GetInstance().GetManorOwner(nID);
				if (manorOwner != string.Empty)
				{
					Utility.GetComponetInChild<Text>(gameObject, "Owner").text = string.Format("【{0}】", manorOwner);
				}
				else
				{
					Utility.GetComponetInChild<Text>(gameObject, "Owner").text = string.Empty;
				}
			}
			this._UpdateCurrentManaor();
			this._UpdateTargetManaor();
			this._UpdateJoin();
			this._UpdateAttackCity();
			this._UpdateShowTitle();
			this._UpdateLotteryShow();
			this.UpdateInspireInfo();
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_NORMAL_CHALLENGE);
			this._RegisterUIEvent();
			DataManager<GuildDataManager>.GetInstance().SetGuildBattleSignUpRedPoint(false);
			this.InitSignUpTimeInfos();
		}

		// Token: 0x0600DEE1 RID: 57057 RVA: 0x0038CF47 File Offset: 0x0038B347
		protected sealed override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
			this.signUpTimeInfos = null;
		}

		// Token: 0x0600DEE2 RID: 57058 RVA: 0x0038CF58 File Offset: 0x0038B358
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildInspireSuccess, new ClientEventSystem.UIEventHandler(this._OnInspireSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildSignupSuccess, new ClientEventSystem.UIEventHandler(this._OnSignupSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildManorInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnManorInfoUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBaseInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildBaseInfoUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStateUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildManorOwnerUpdated, new ClientEventSystem.UIEventHandler(this._OnManorOwnerUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildAttackCityInfoUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildAttackCityInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildLotteryResultRes, new ClientEventSystem.UIEventHandler(this._OnGuildLotteryResultRes));
		}

		// Token: 0x0600DEE3 RID: 57059 RVA: 0x0038D040 File Offset: 0x0038B440
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildInspireSuccess, new ClientEventSystem.UIEventHandler(this._OnInspireSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildSignupSuccess, new ClientEventSystem.UIEventHandler(this._OnSignupSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildManorInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnManorInfoUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBaseInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildBaseInfoUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStateUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildManorOwnerUpdated, new ClientEventSystem.UIEventHandler(this._OnManorOwnerUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildAttackCityInfoUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildAttackCityInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildLotteryResultRes, new ClientEventSystem.UIEventHandler(this._OnGuildLotteryResultRes));
		}

		// Token: 0x0600DEE4 RID: 57060 RVA: 0x0038D128 File Offset: 0x0038B528
		private void _OnInspireSuccess(UIEvent a_event)
		{
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_NORMAL_CHALLENGE);
		}

		// Token: 0x0600DEE5 RID: 57061 RVA: 0x0038D16C File Offset: 0x0038B56C
		private void _OnSignupSuccess(UIEvent a_event)
		{
			this._UpdateTargetManaor();
			this._UpdateManor();
			this.UpdateInspireInfo();
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_NORMAL_CHALLENGE);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildManorInfoFrame>(null, false);
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_manor_signup_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x0600DEE6 RID: 57062 RVA: 0x0038D1DC File Offset: 0x0038B5DC
		private void _OnManorInfoUpdated(UIEvent a_event)
		{
			GuildTerritoryBaseInfo guildTerritoryBaseInfo = a_event.Param1 as GuildTerritoryBaseInfo;
			if (guildTerritoryBaseInfo != null)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildManorInfoFrame>(FrameLayer.Middle, guildTerritoryBaseInfo, string.Empty);
			}
		}

		// Token: 0x0600DEE7 RID: 57063 RVA: 0x0038D210 File Offset: 0x0038B610
		private void _OnGuildBaseInfoUpdated(UIEvent a_event)
		{
			this._UpdateCurrentManaor();
			this._UpdateTargetManaor();
			this._UpdateManor();
			this.UpdateInspireInfo();
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_NORMAL_CHALLENGE);
		}

		// Token: 0x0600DEE8 RID: 57064 RVA: 0x0038D26C File Offset: 0x0038B66C
		private void _OnGuildBattleStateUpdated(UIEvent a_event)
		{
			this._UpdateJoin();
			this._UpdateAttackCity();
			this._UpdateManor();
			this._UpdateLotteryShow();
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_NORMAL_CHALLENGE);
			this.UpdateInspireInfo();
		}

		// Token: 0x0600DEE9 RID: 57065 RVA: 0x0038D2CC File Offset: 0x0038B6CC
		private void UpdateInspireInfo()
		{
			this.inspireRoot.CustomActive(DataManager<GuildDataManager>.GetInstance().HasSelfGuild() && DataManager<GuildDataManager>.GetInstance().HasTargetManor());
		}

		// Token: 0x0600DEEA RID: 57066 RVA: 0x0038D2F5 File Offset: 0x0038B6F5
		private void _OnManorOwnerUpdate(UIEvent a_event)
		{
			this._UpdateManor();
		}

		// Token: 0x0600DEEB RID: 57067 RVA: 0x0038D2FD File Offset: 0x0038B6FD
		private void _OnGuildAttackCityInfoUpdate(UIEvent a_event)
		{
			this._UpdateAttackCity();
		}

		// Token: 0x0600DEEC RID: 57068 RVA: 0x0038D305 File Offset: 0x0038B705
		private void _OnGuildLotteryResultRes(UIEvent a_event)
		{
			this._UpdateLotteryShow();
		}

		// Token: 0x0600DEED RID: 57069 RVA: 0x0038D310 File Offset: 0x0038B710
		private void _UpdateCurrentManaor()
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild() && DataManager<GuildDataManager>.GetInstance().HasSelfManor())
			{
				GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(DataManager<GuildDataManager>.GetInstance().myGuild.nSelfManorID, true);
				this.mCurManorName.text = guildTerritoryTable.Name;
			}
			else
			{
				this.mCurManorName.text = TR.Value("guild_manor_none_manor");
			}
		}

		// Token: 0x0600DEEE RID: 57070 RVA: 0x0038D380 File Offset: 0x0038B780
		private void _UpdateTargetManaor()
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild() && DataManager<GuildDataManager>.GetInstance().HasTargetManor())
			{
				GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(DataManager<GuildDataManager>.GetInstance().myGuild.nTargetManorID, true);
				if (guildTerritoryTable != null)
				{
					this.mTargetManorName.text = guildTerritoryTable.Name;
				}
				else
				{
					this.mTargetManorName.text = TR.Value("guild_manor_none_manor");
				}
			}
			else
			{
				this.mTargetManorName.text = TR.Value("guild_manor_none_manor");
			}
		}

		// Token: 0x0600DEEF RID: 57071 RVA: 0x0038D410 File Offset: 0x0038B810
		private void _UpdateJoin()
		{
			bool enable = DataManager<GuildDataManager>.GetInstance().HasTargetManor() && (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL || DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CHALLENGE) && (DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Preparing || DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Firing);
			this.mEnableJoin.SetEnable(enable);
			this.mJoinRedPoint.gameObject.CustomActive((DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL || DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CHALLENGE) && DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildBattleEnter));
		}

		// Token: 0x0600DEF0 RID: 57072 RVA: 0x0038D4BC File Offset: 0x0038B8BC
		private void _UpdateAttackCity()
		{
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CHALLENGE)
			{
				EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
				if (guildBattleState > EGuildBattleState.Invalid && guildBattleState < EGuildBattleState.Firing)
				{
					GuildAttackCityData attackCityData = DataManager<GuildDataManager>.GetInstance().GetAttackCityData();
					this.mAttackCity.gameObject.CustomActive(true);
				}
				else
				{
					this.mAttackCity.gameObject.CustomActive(false);
				}
			}
			else
			{
				this.mAttackCity.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600DEF1 RID: 57073 RVA: 0x0038D53C File Offset: 0x0038B93C
		private void _UpdateShowTitle()
		{
			GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(1, true);
			if (guildTerritoryTable == null)
			{
				return;
			}
			if (guildTerritoryTable.LeaderReward.Count > 0 && guildTerritoryTable.LeaderReward[0] != "-" && guildTerritoryTable.LeaderReward[0] != string.Empty)
			{
				string[] array = guildTerritoryTable.LeaderReward[0].Split(new char[]
				{
					'_'
				});
				if (array.Length >= 2)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array[0]), 100, 0);
					itemData.Count = int.Parse(array[1]);
					ComItem comItem = base.CreateComItem(this.mLeaderRewardPos);
					comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
				}
			}
			if (guildTerritoryTable.MemberReward.Count > 0 && guildTerritoryTable.MemberReward[0] != "-" && guildTerritoryTable.MemberReward[0] != string.Empty)
			{
				string[] array2 = guildTerritoryTable.MemberReward[0].Split(new char[]
				{
					'_'
				});
				if (array2.Length >= 2)
				{
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
					itemData2.Count = int.Parse(array2[1]);
					ComItem comItem2 = base.CreateComItem(this.mMemberRewardPos);
					comItem2.Setup(itemData2, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
				}
			}
		}

		// Token: 0x0600DEF2 RID: 57074 RVA: 0x0038D6DC File Offset: 0x0038BADC
		private void _UpdateLotteryShow()
		{
		}

		// Token: 0x0600DEF3 RID: 57075 RVA: 0x0038D6E0 File Offset: 0x0038BAE0
		private void _UpdateManor()
		{
			for (int i = 0; i < this.TerritoryIDs.Length; i++)
			{
				int num = this.TerritoryIDs[i];
				GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(num, true);
				GameObject gameObject = Utility.FindGameObject(string.Format("Map/Manor{0}", num), true);
				if (!DataManager<GuildDataManager>.GetInstance().HasTargetManor() && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL && DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Signup && DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.StartGuildBattle, EGuildDuty.Invalid))
				{
					Utility.FindGameObject(gameObject, "ClickToSignup", true).SetActive(true);
				}
				else
				{
					Utility.FindGameObject(gameObject, "ClickToSignup", true).SetActive(false);
				}
				Utility.FindGameObject(gameObject, "AlreadySignup", true).SetActive(num == DataManager<GuildDataManager>.GetInstance().myGuild.nTargetManorID);
				string manorOwner = DataManager<GuildDataManager>.GetInstance().GetManorOwner(num);
				if (manorOwner != string.Empty)
				{
					Utility.GetComponetInChild<Text>(gameObject, "Owner").text = string.Format("【{0}】", manorOwner);
				}
				else
				{
					Utility.GetComponetInChild<Text>(gameObject, "Owner").text = string.Empty;
				}
			}
		}

		// Token: 0x0600DEF4 RID: 57076 RVA: 0x0038D814 File Offset: 0x0038BC14
		private GuildTerritoryTable _GetTerritoryTableData(int a_nID, bool a_bShowError = true)
		{
			GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(a_nID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			return tableItem;
		}

		// Token: 0x0600DEF5 RID: 57077 RVA: 0x0038D840 File Offset: 0x0038BC40
		protected override void _bindExUI()
		{
			this.mDetail = this.mBind.GetCom<Button>("Detail");
			this.mDetail.onClick.AddListener(new UnityAction(this._onDetailButtonClick));
			this.mAttackCity = this.mBind.GetCom<Button>("AttackCity");
			this.mAttackCity.onClick.AddListener(new UnityAction(this._onAttackCityButtonClick));
			this.mInspireLevel = this.mBind.GetCom<Text>("InspireLevel");
			this.mCurManorName = this.mBind.GetCom<Text>("CurManorName");
			this.mTargetManorName = this.mBind.GetCom<Text>("TargetManorName");
			this.mCurAttr = this.mBind.GetCom<Text>("CurAttr");
			this.mInspire = this.mBind.GetCom<Button>("Inspire");
			this.mInspire.onClick.AddListener(new UnityAction(this._onInspireButtonClick));
			this.mJoin = this.mBind.GetCom<Button>("Join");
			this.mJoin.onClick.AddListener(new UnityAction(this._onJoinButtonClick));
			this.mEnableInspire = this.mBind.GetCom<ComButtonEnbale>("EnableInspire");
			this.mEnableJoin = this.mBind.GetCom<ComButtonEnbale>("EnableJoin");
			this.mInspireMax = this.mBind.GetGameObject("InspireMax");
			this.mJoinRedPoint = this.mBind.GetCom<Image>("JoinRedPoint");
			this.mInspireIcon = this.mBind.GetCom<Image>("InspireIcon");
			this.mInspireCount = this.mBind.GetCom<Text>("InspireCount");
			this.mLeaderRewardPos = this.mBind.GetGameObject("LeaderRewardPos");
			this.mMemberRewardPos = this.mBind.GetGameObject("MemberRewardPos");
			this.mStatue = this.mBind.GetCom<Button>("Statue");
			this.mStatue.onClick.AddListener(new UnityAction(this._onStatueButtonClick));
			this.mViceStatue = this.mBind.GetCom<Button>("ViceStatue");
			this.mViceStatue.onClick.AddListener(new UnityAction(this._onViceStatueButtonClick));
			this.rankList = this.mBind.GetCom<Button>("rankList");
			this.rankList.SafeSetOnClickListener(delegate
			{
				DataManager<GuildDataManager>.GetInstance().RequestGuildManorWeekRanklist();
			});
			this.dailyAward = this.mBind.GetCom<Button>("dailyAward");
			this.dailyAward.SafeSetOnClickListener(delegate
			{
				DataManager<GuildDataManager>.GetInstance().SendWorldGuildGetTerrDayRewardReq();
			});
			this.dailyAwardRedPoint = this.mBind.GetGameObject("dailyAwardRedPoint");
			this.leftTime = this.mBind.GetCom<Text>("leftTime");
			this.leftTimeRoot = this.mBind.GetGameObject("leftTimeRoot");
			this.statue = this.mBind.GetCom<Button>("statue");
			this.statue.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildManorOwnerAttrAddUpShowFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.inspireRoot = this.mBind.GetGameObject("inspireRoot");
		}

		// Token: 0x0600DEF6 RID: 57078 RVA: 0x0038DB94 File Offset: 0x0038BF94
		protected override void _unbindExUI()
		{
			this.mDetail.onClick.RemoveListener(new UnityAction(this._onDetailButtonClick));
			this.mDetail = null;
			this.mAttackCity.onClick.RemoveListener(new UnityAction(this._onAttackCityButtonClick));
			this.mAttackCity = null;
			this.mInspireLevel = null;
			this.mCurManorName = null;
			this.mTargetManorName = null;
			this.mCurAttr = null;
			this.mInspire.onClick.RemoveListener(new UnityAction(this._onInspireButtonClick));
			this.mInspire = null;
			this.mJoin.onClick.RemoveListener(new UnityAction(this._onJoinButtonClick));
			this.mJoin = null;
			this.mEnableInspire = null;
			this.mEnableJoin = null;
			this.mInspireMax = null;
			this.mJoinRedPoint = null;
			this.mInspireIcon = null;
			this.mInspireCount = null;
			this.mLeaderRewardPos = null;
			this.mMemberRewardPos = null;
			this.mStatue.onClick.RemoveListener(new UnityAction(this._onStatueButtonClick));
			this.mStatue = null;
			this.mViceStatue.onClick.RemoveListener(new UnityAction(this._onViceStatueButtonClick));
			this.mViceStatue = null;
			this.rankList = null;
			this.dailyAward = null;
			this.dailyAwardRedPoint = null;
			this.leftTime = null;
			this.leftTimeRoot = null;
			this.statue = null;
			this.inspireRoot = null;
		}

		// Token: 0x0600DEF7 RID: 57079 RVA: 0x0038DCF8 File Offset: 0x0038C0F8
		private int GetActivityNextOpenStamp()
		{
			if (this.signUpTimeInfos == null)
			{
				return 0;
			}
			DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)DataManager<TimeManager>.GetInstance().GetServerTime());
			DateTime temp = dateTimeByTimeStamp;
			for (int i = 0; i <= 7; i++)
			{
				temp = dateTimeByTimeStamp.AddDays((double)i);
				GuildManorFrame.TimeInfo timeInfo = this.signUpTimeInfos.Find((GuildManorFrame.TimeInfo t) => temp.DayOfWeek == (DayOfWeek)(t.day % 7));
				if (timeInfo != null)
				{
					DateTime time = new DateTime(temp.Year, temp.Month, temp.Day, timeInfo.hour, timeInfo.minute, timeInfo.second);
					if (Function.ConvertDateTimeInt(time) >= DataManager<TimeManager>.GetInstance().GetServerTime())
					{
						return (int)Function.ConvertDateTimeInt(time);
					}
				}
			}
			return 0;
		}

		// Token: 0x0600DEF8 RID: 57080 RVA: 0x0038DDCC File Offset: 0x0038C1CC
		private string GetLeftTime(int end, int now)
		{
			int num = end - now;
			if (num < 0)
			{
				num = 0;
			}
			int num2 = num / 86400;
			num -= num2 * 24 * 60 * 60;
			int num3 = num / 3600;
			num -= num3 * 60 * 60;
			int num4 = num / 60;
			num -= num4 * 60;
			if (num2 > 0)
			{
				return TR.Value("guild_battle_activity_time_format1", num2, num3);
			}
			return TR.Value("guild_battle_activity_time_format2", num3, num4, num);
		}

		// Token: 0x0600DEF9 RID: 57081 RVA: 0x0038DE54 File Offset: 0x0038C254
		private void InitSignUpTimeInfos()
		{
			this.signUpTimeInfos = new List<GuildManorFrame.TimeInfo>();
			if (this.signUpTimeInfos == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildBattleTimeTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildBattleTimeTable guildBattleTimeTable = keyValuePair.Value as GuildBattleTimeTable;
					if (guildBattleTimeTable != null)
					{
						if (guildBattleTimeTable.Type == GuildBattleTimeTable.eType.GBT_NORMAL && guildBattleTimeTable.Status == GuildBattleTimeTable.eStatus.GBS_ENROLL && guildBattleTimeTable.IsOpen == 1)
						{
							GuildManorFrame.TimeInfo timeInfo = new GuildManorFrame.TimeInfo();
							if (timeInfo != null)
							{
								timeInfo.day = guildBattleTimeTable.Week;
								string[] array = guildBattleTimeTable.Time.Split(new char[]
								{
									':'
								});
								if (array != null)
								{
									if (array.Length == 3)
									{
										timeInfo.hour = Utility.ToInt(array[0]);
										timeInfo.minute = Utility.ToInt(array[1]);
										timeInfo.second = Utility.ToInt(array[2]);
										this.signUpTimeInfos.Add(timeInfo);
									}
								}
							}
						}
					}
				}
			}
			this.signUpTimeInfos.Sort(delegate(GuildManorFrame.TimeInfo a, GuildManorFrame.TimeInfo b)
			{
				if (a == null || b == null)
				{
					return 0;
				}
				return a.day.CompareTo(b.day);
			});
		}

		// Token: 0x0600DEFA RID: 57082 RVA: 0x0038DFA4 File Offset: 0x0038C3A4
		private void UpdateActivtyLeftTimeTip()
		{
			int num = 0;
			EGuildBattleState eguildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS || DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CHALLENGE)
			{
				eguildBattleState = EGuildBattleState.Invalid;
			}
			if (eguildBattleState == EGuildBattleState.Invalid)
			{
				num = this.GetActivityNextOpenStamp();
				this.leftTime.SafeSetText(TR.Value("guild_battle_activity_open_time_tip", this.GetLeftTime(num, (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
			}
			else if (eguildBattleState == EGuildBattleState.Signup)
			{
				num = (int)DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime();
				this.leftTime.SafeSetText(TR.Value("guild_battle_activity_sign_up_tip", this.GetLeftTime((int)DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime(), (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
			}
			else if (eguildBattleState == EGuildBattleState.Preparing)
			{
				num = (int)DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime();
				this.leftTime.SafeSetText(TR.Value("guild_battle_activity_prepare_tip", this.GetLeftTime((int)DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime(), (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
			}
			else if (eguildBattleState == EGuildBattleState.Firing)
			{
				num = (int)DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime();
				this.leftTime.SafeSetText(TR.Value("guild_battle_activity_firing_tip", this.GetLeftTime((int)DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime(), (int)DataManager<TimeManager>.GetInstance().GetServerTime())));
			}
			this.leftTimeRoot.CustomActive(num > 0);
		}

		// Token: 0x0600DEFB RID: 57083 RVA: 0x0038E0F4 File Offset: 0x0038C4F4
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600DEFC RID: 57084 RVA: 0x0038E0F7 File Offset: 0x0038C4F7
		protected override void _OnUpdate(float timeElapsed)
		{
			this.UpdateActivtyLeftTimeTip();
		}

		// Token: 0x0600DEFD RID: 57085 RVA: 0x0038E0FF File Offset: 0x0038C4FF
		private void _onDetailButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildInspireDetailFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DEFE RID: 57086 RVA: 0x0038E114 File Offset: 0x0038C514
		private void _onAttackCityButtonClick()
		{
			int num = 1;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildAttackCityFrame>(FrameLayer.Middle, num, string.Empty);
		}

		// Token: 0x0600DEFF RID: 57087 RVA: 0x0038E13A File Offset: 0x0038C53A
		private void _onInspireButtonClick()
		{
			DataManager<GuildDataManager>.GetInstance().SendInspire();
		}

		// Token: 0x0600DF00 RID: 57088 RVA: 0x0038E146 File Offset: 0x0038C546
		private void _onJoinButtonClick()
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._requestNewTitleTakeUpGuildPost());
			this.frameMgr.CloseFrame<GuildManorFrame>(null, false);
		}

		// Token: 0x0600DF01 RID: 57089 RVA: 0x0038E188 File Offset: 0x0038C588
		private IEnumerator _requestNewTitleTakeUpGuildPost()
		{
			MessageEvents msg = new MessageEvents();
			WorldNewTitleTakeUpGuildPostReq req = new WorldNewTitleTakeUpGuildPostReq();
			WorldNewTitleTakeUpGuildPostRes res = new WorldNewTitleTakeUpGuildPostRes();
			yield return MessageUtility.WaitWithResend<WorldNewTitleTakeUpGuildPostReq, WorldNewTitleTakeUpGuildPostRes>(ServerType.GATE_SERVER, msg, req, res, true, 2f, null);
			if (msg.IsAllMessageReceived())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
				if (clientSystemTown != null && DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
				{
					int nTargetManorID = DataManager<GuildDataManager>.GetInstance().myGuild.nTargetManorID;
					GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(nTargetManorID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (clientSystemTown.CurrentSceneID != tableItem.SceneID)
						{
							clientSystemTown.ChangeScene(tableItem.SceneID, 0, clientSystemTown.CurrentSceneID, 0, null);
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildCloseMainFrame, null, null, null, null);
							DataManager<GuildDataManager>.GetInstance().SetGuildBattleEnterRedPoint(false);
						}
						else
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildCloseMainFrame, null, null, null, null);
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x0600DF02 RID: 57090 RVA: 0x0038E19C File Offset: 0x0038C59C
		private void _onStatueButtonClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildStatueFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildStatueFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildStatueFrame>(FrameLayer.Middle, StatueType.TownStatue, string.Empty);
		}

		// Token: 0x0600DF03 RID: 57091 RVA: 0x0038E1D1 File Offset: 0x0038C5D1
		private void _onViceStatueButtonClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildStatueFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildStatueFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildStatueFrame>(FrameLayer.Middle, StatueType.ViceTownStatue, string.Empty);
		}

		// Token: 0x0400843A RID: 33850
		private string AttackCityEffectPath = "Effects/Scene_effects/EffectUI/EffUI_chuizi";

		// Token: 0x0400843B RID: 33851
		private const int TerritoryNum = 10;

		// Token: 0x0400843C RID: 33852
		private int[] TerritoryIDs = new int[]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			21,
			22,
			23
		};

		// Token: 0x0400843D RID: 33853
		private const int guildActivityTableID = 1;

		// Token: 0x0400843E RID: 33854
		private List<GuildManorFrame.TimeInfo> signUpTimeInfos = new List<GuildManorFrame.TimeInfo>();

		// Token: 0x0400843F RID: 33855
		private Button mDetail;

		// Token: 0x04008440 RID: 33856
		private Button mAttackCity;

		// Token: 0x04008441 RID: 33857
		private Text mInspireLevel;

		// Token: 0x04008442 RID: 33858
		private Text mCurManorName;

		// Token: 0x04008443 RID: 33859
		private Text mTargetManorName;

		// Token: 0x04008444 RID: 33860
		private Text mCurAttr;

		// Token: 0x04008445 RID: 33861
		private Button mInspire;

		// Token: 0x04008446 RID: 33862
		private Button mJoin;

		// Token: 0x04008447 RID: 33863
		private ComButtonEnbale mEnableInspire;

		// Token: 0x04008448 RID: 33864
		private ComButtonEnbale mEnableJoin;

		// Token: 0x04008449 RID: 33865
		private GameObject mInspireMax;

		// Token: 0x0400844A RID: 33866
		private Image mJoinRedPoint;

		// Token: 0x0400844B RID: 33867
		private Image mInspireIcon;

		// Token: 0x0400844C RID: 33868
		private Text mInspireCount;

		// Token: 0x0400844D RID: 33869
		private GameObject mLeaderRewardPos;

		// Token: 0x0400844E RID: 33870
		private GameObject mMemberRewardPos;

		// Token: 0x0400844F RID: 33871
		private Button mStatue;

		// Token: 0x04008450 RID: 33872
		private Button mViceStatue;

		// Token: 0x04008451 RID: 33873
		private Button rankList;

		// Token: 0x04008452 RID: 33874
		private Button dailyAward;

		// Token: 0x04008453 RID: 33875
		private GameObject dailyAwardRedPoint;

		// Token: 0x04008454 RID: 33876
		private Text leftTime;

		// Token: 0x04008455 RID: 33877
		private GameObject leftTimeRoot;

		// Token: 0x04008456 RID: 33878
		private Button statue;

		// Token: 0x04008457 RID: 33879
		private GameObject inspireRoot;

		// Token: 0x0200162E RID: 5678
		private class TimeInfo
		{
			// Token: 0x0400845E RID: 33886
			public int day;

			// Token: 0x0400845F RID: 33887
			public int hour;

			// Token: 0x04008460 RID: 33888
			public int minute;

			// Token: 0x04008461 RID: 33889
			public int second;
		}
	}
}
