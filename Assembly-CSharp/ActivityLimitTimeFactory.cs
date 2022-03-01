using System;
using GameClient;
using Protocol;
using ProtoTable;

// Token: 0x020018BC RID: 6332
public static class ActivityLimitTimeFactory
{
	// Token: 0x0600F763 RID: 63331 RVA: 0x0042EB5C File Offset: 0x0042CF5C
	public static IActivity Create(uint activityId)
	{
		ActivityLimitTimeFactory.EActivityType activityType = ActivityLimitTimeFactory.GetActivityType(activityId);
		IActivity activity = null;
		switch (activityType)
		{
		case ActivityLimitTimeFactory.EActivityType.NONE:
			break;
		case ActivityLimitTimeFactory.EActivityType.DAY_SINGLE_CHARGE:
		case ActivityLimitTimeFactory.EActivityType.DAY_TATOL_CHARGE:
		case ActivityLimitTimeFactory.EActivityType.TATOL_CHARGE:
		case ActivityLimitTimeFactory.EActivityType.SINGLE_CHARGE:
		case ActivityLimitTimeFactory.EActivityType.COMBO_CHARGE:
		case ActivityLimitTimeFactory.EActivityType.DAY_COST_ITEM:
		case ActivityLimitTimeFactory.EActivityType.COST_ITEM:
		case ActivityLimitTimeFactory.EActivityType.DAY_BUY_GIFTPACK:
		case ActivityLimitTimeFactory.EActivityType.BUY_GIFTPACK:
		case ActivityLimitTimeFactory.EActivityType.DAY_LOGIN:
		case ActivityLimitTimeFactory.EActivityType.LOGIN_DAYNUM:
		case ActivityLimitTimeFactory.EActivityType.DAY_ONLINE_TIME:
		case ActivityLimitTimeFactory.EActivityType.ONLINE_TIME:
		case ActivityLimitTimeFactory.EActivityType.DAY_COMPLETE_DUNG:
		case ActivityLimitTimeFactory.EActivityType.COMPLETE_DUNG:
			activity = new LimitTimeCommonActivity();
			break;
		default:
			switch (activityType)
			{
			case ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEGROUPBUYACTIVITY:
				activity = new LimitTimeGroupBuyActivity();
				break;
			default:
				switch (activityType)
				{
				case ActivityLimitTimeFactory.EActivityType.OAT_SWIPEPICTURESTOSENDTICKETSACTIVITY:
					activity = new SwipePicturesToSendTicketsActivity();
					break;
				case ActivityLimitTimeFactory.EActivityType.OAT_BRUSHFIGUREGIFTSACTIVITY:
					activity = new BrushFigureGiftsActivity();
					break;
				case ActivityLimitTimeFactory.EActivityType.OAT_MAGICALJOURENYACTIVITY:
					activity = new ZillionaireGameActivity();
					break;
				case ActivityLimitTimeFactory.EActivityType.OAT_BLESSCARDEXCHANGEACTIVITY:
					activity = new BlessingCardExchangeActivity();
					break;
				default:
					switch (activityType)
					{
					case ActivityLimitTimeFactory.EActivityType.MALL_DISCOUNT_FOR_NEW_SERVER:
						activity = new FashionDiscountActivity();
						break;
					case ActivityLimitTimeFactory.EActivityType.LEVEL_FIGHTING_FOR_NEW_SERVER:
						activity = new LevelFightActivity();
						break;
					case ActivityLimitTimeFactory.EActivityType.LEVEL_SHOW_FOR_NEW_SERVER:
						activity = new LevelFightShowActivity();
						break;
					default:
						switch (activityType)
						{
						case ActivityLimitTimeFactory.EActivityType.BOSS_KILL:
							activity = new BossKillActivity();
							break;
						case ActivityLimitTimeFactory.EActivityType.BOSS_EXCHANGE:
							activity = new BossExchangeActivity();
							break;
						case ActivityLimitTimeFactory.EActivityType.SPECOAL_EXCHANGE:
							activity = new SpecialExchangeActivity();
							break;
						default:
							if (activityType != ActivityLimitTimeFactory.EActivityType.DUNGEON_DROP_ACTIVITY && activityType != ActivityLimitTimeFactory.EActivityType.DUNGEON_EXP_ADDITION && activityType != ActivityLimitTimeFactory.EActivityType.PVP_PK_COIN)
							{
								if (activityType == ActivityLimitTimeFactory.EActivityType.APPOINTMENT_OCCU)
								{
									activity = new ReservationUpgradeActivity();
									break;
								}
								if (activityType == ActivityLimitTimeFactory.EActivityType.HELL_TICKET_FOR_DRAW_PRIZE)
								{
									activity = new HellTicketActivity();
									break;
								}
								if (activityType == ActivityLimitTimeFactory.EActivityType.FATIGUE_FOR_BUFF)
								{
									activity = new FatigueForBuffActivity();
									break;
								}
								if (activityType == ActivityLimitTimeFactory.EActivityType.FATIGUE_FOR_TOKEN_COIN)
								{
									activity = new CoinExchangeActivity();
									break;
								}
								if (activityType == ActivityLimitTimeFactory.EActivityType.FATIGUE_BURNING)
								{
									activity = new FatigueBurnActivity();
									break;
								}
								if (activityType == ActivityLimitTimeFactory.EActivityType.DAILY_REWARD)
								{
									activity = new DailyRewardActivity();
									break;
								}
								if (activityType == ActivityLimitTimeFactory.EActivityType.MAGPIE_BRIDGE)
								{
									activity = new QiXiQueQiaoActivity();
									break;
								}
								if (activityType == ActivityLimitTimeFactory.EActivityType.MONTH_CARD)
								{
									activity = new MonthCardActivity();
									break;
								}
								if (activityType != ActivityLimitTimeFactory.EActivityType.OAT_DUNGEON_DROP_RATE_ADDITION)
								{
									if (activityType == ActivityLimitTimeFactory.EActivityType.CHANGE_FASHION)
									{
										activity = new ChangeFashionActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_CHANGE_FASHION_EXCHANGE)
									{
										activity = new ChangeFashionSpecialExchangeActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_CHANGE_FASHION_WELFARE)
									{
										activity = new ChangeFashionExchangeActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.DUNGEON_RANDOM_BUFF)
									{
										activity = new VanityBonusActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.DUNGEON_CLEAR_GET_REWARD)
									{
										activity = new VanityCustomClearanceActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_BUY_FASHION_TICKET)
									{
										activity = new FashionTicketBuyActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.BUFF_PRAY_ACTIVITY)
									{
										activity = new BuffPrayActivityNew();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_GOBLIN_SHOP_ACT)
									{
										activity = new GoblinShopActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_LIMIT_TIME_HELL)
									{
										activity = new LimitTimeHellActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_RETURN_GIFT)
									{
										activity = new ReturnGiftActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_ACCOUNT_SHOP)
									{
										activity = new ReturnExchangeActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_RETURN_REBATE)
									{
										activity = new ConsumePointActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_CHALLENGE_CHAPTER)
									{
										activity = new ConsumeDeepTicketActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_RETURN_PRIVILEGE)
									{
										activity = new ReturnTeamBuffActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_BUY_PRRSENT)
									{
										activity = new BuyPresentationActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_LOGIN_REWARD)
									{
										activity = new AccumulateLoginActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_PASS_DUNGEON_REWARD)
									{
										activity = new AccumulateClearanceActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.MALL_GIFT_PACK)
									{
										activity = new LimitTimeMallGiftPackActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_PROMOTE_EQUIP_STRENGTHEN_RATE)
									{
										activity = new EquipmentUpgradeActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_WEEKLY_VACATION)
									{
										activity = new SummerVacationWeeklyActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_GRANDdTOTAL_VACATION)
									{
										activity = new SummerVacationGrandTotalActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_SECOND_ANNIVERSARY_PRAY)
									{
										activity = new AnniversaryBuffPrayActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_FLYING_GIFTPACK_ACTIVITY)
									{
										activity = new FlyingGiftPackActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_TUANBEN_ACTIVITY)
									{
										activity = new TuanBenActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_ANNIVERACCUMULATE)
									{
										activity = new AnniversaryAccumulateClearanceActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_ANNIBERPARTY)
									{
										activity = new AnniversaryPartyActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_HALLOWEENONLINEACTIVITY)
									{
										activity = new HalloweenOnlineActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_NEWYEARONDAYACTIVITY)
									{
										activity = new NewYearOnDayActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_CONSUMEREBATEACTIVITY)
									{
										activity = new ConsumeRebateActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_INTEGRATIONCHALLENGEACTIVITU)
									{
										activity = new IntegrationChallengeActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_MOUSEYEARREDPACKAGEACTIVITY)
									{
										activity = new MouseYearRedPackageActivity();
										break;
									}
									if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_SPRINGFESTIVALACTIVITY)
									{
										activity = new SpringFestivalDungeonActivity();
										break;
									}
									if (activityType != ActivityLimitTimeFactory.EActivityType.OAT_SPRINGFESTIVALREDENVELOPERAINACTIVITY)
									{
										if (activityType != ActivityLimitTimeFactory.EActivityType.OAT_CHALLENGEPOINTSREWARDACTIVITY)
										{
											if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_SPINGCHALLENGEACTIVITY)
											{
												activity = new SpringChallengeActivity();
												break;
											}
											if (activityType != ActivityLimitTimeFactory.EActivityType.OAT_SPRINGENGEPOINTSREWARDACTIVITY)
											{
												if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_INAWEEKACTIVITY)
												{
													activity = new WeeklyCheckInActivity();
													break;
												}
												if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_ONLINEGIFTGIVINGACTIVITY)
												{
													activity = new OnLineGiftGivingActivity();
													break;
												}
												if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_PLANT_TREE)
												{
													activity = new ArborDayActivity();
													break;
												}
												if (activityType == ActivityLimitTimeFactory.EActivityType.OAT_FEEDBACKGIFTACTIVITY)
												{
													activity = new FeedbackGiftActivity();
													break;
												}
												if (activityType == ActivityLimitTimeFactory.EActivityType.BOSS_QUEST)
												{
													activity = new BossQuestActivity();
													break;
												}
												if (activityType == ActivityLimitTimeFactory.EActivityType.MALL_ACTIVITY_GIFT_PACK)
												{
													activity = new MallActivityGiftPackActivity();
													break;
												}
												if (activityType != ActivityLimitTimeFactory.EActivityType.OAT_ABYESS_TICKET_REDUCE)
												{
													break;
												}
												activity = new AbyssBlackGoldMemberActivity();
												break;
											}
										}
										activity = new RewardPointsActivity();
										break;
									}
									activity = new SpringFestivalRedEnvelopeRainActivity();
									break;
								}
							}
							activity = new DungeonDropActivity();
							break;
						}
						break;
					}
					break;
				}
				break;
			case ActivityLimitTimeFactory.EActivityType.OAT_RECHARGECONSUMERREBATES:
				activity = new RechargeConsumerRebatesActivity();
				break;
			case ActivityLimitTimeFactory.EActivityType.OAT_COMPETITIONSUPPORTACTIVITY:
				activity = new CompetitionSupportActivity();
				break;
			case ActivityLimitTimeFactory.EActivityType.OAT_COMMONREWARDACTIVITY:
				activity = new CommonRewardActivity();
				break;
			case ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY:
				activity = new DailyChallengeActivity();
				break;
			case ActivityLimitTimeFactory.EActivityType.OAT_ONLINEAWARD:
				activity = new OnLineRewardActivity();
				break;
			case ActivityLimitTimeFactory.EActivityType.OAT_COURTESYPRIVILEGESACTIVITY:
				activity = new CourtesyPrivilegesActivity();
				break;
			case ActivityLimitTimeFactory.EActivityType.OAT_MYSTERIOUS_MEGASTORE:
				activity = new MysteriousStoresActivity();
				break;
			}
			break;
		case ActivityLimitTimeFactory.EActivityType.BUY_FASHION:
			activity = new FashionActivity();
			break;
		}
		if (activity != null)
		{
			activity.Init(activityId);
		}
		return activity;
	}

	// Token: 0x0600F764 RID: 63332 RVA: 0x0042F1C4 File Offset: 0x0042D5C4
	public static ActivityLimitTimeFactory.EActivityType GetActivityType(uint activityId)
	{
		ActivityDataManager instance = DataManager<ActivityDataManager>.GetInstance();
		if (instance == null)
		{
			return ActivityLimitTimeFactory.EActivityType.NONE;
		}
		if (instance.IsContainGiftActivity(MallTypeTable.eMallType.SN_ACTIVITY_GIFT, activityId))
		{
			return ActivityLimitTimeFactory.EActivityType.MALL_ACTIVITY_GIFT_PACK;
		}
		if (instance.GetLimitTimeActivityData(activityId) == null)
		{
			if (instance.GetBossActivityData(activityId) != null)
			{
				ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>((int)activityId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.ActivityType == ActiveMainTable.eActivityType.KillBossActivity)
					{
						return ActivityLimitTimeFactory.EActivityType.BOSS_KILL;
					}
					if (tableItem.ActivityType == ActiveMainTable.eActivityType.ExchangeActivity)
					{
						return ActivityLimitTimeFactory.EActivityType.BOSS_EXCHANGE;
					}
					if (tableItem.ActivityType == ActiveMainTable.eActivityType.QuestActivity)
					{
						return ActivityLimitTimeFactory.EActivityType.BOSS_QUEST;
					}
					if (tableItem.ActivityType == ActiveMainTable.eActivityType.SpecialExchangeActivity)
					{
						return ActivityLimitTimeFactory.EActivityType.SPECOAL_EXCHANGE;
					}
				}
			}
			return ActivityLimitTimeFactory.EActivityType.NONE;
		}
		OpActivityData limitTimeActivityData = instance.GetLimitTimeActivityData(activityId);
		if (limitTimeActivityData.tmpType == 5000U)
		{
			return ActivityLimitTimeFactory.EActivityType.MALL_GIFT_PACK;
		}
		return ActivityLimitTimeFactory.GetActivityTypeByLimitTimeType((OpActivityTmpType)limitTimeActivityData.tmpType);
	}

	// Token: 0x0600F765 RID: 63333 RVA: 0x0042F299 File Offset: 0x0042D699
	public static ActivityLimitTimeFactory.EActivityType GetActivityTypeByLimitTimeType(OpActivityTmpType Orgtype)
	{
		return (ActivityLimitTimeFactory.EActivityType)Orgtype;
	}

	// Token: 0x020018BD RID: 6333
	public enum EActivityCounterType
	{
		// Token: 0x0400982C RID: 38956
		QAT_SUMMER_DAILY_CHARGE = 1001,
		// Token: 0x0400982D RID: 38957
		OAT_SUMMER_WEEKLY_VACATION = 2001,
		// Token: 0x0400982E RID: 38958
		OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK = 1002,
		// Token: 0x0400982F RID: 38959
		OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK = 4002,
		// Token: 0x04009830 RID: 38960
		OP_ITEM_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK,
		// Token: 0x04009831 RID: 38961
		OP_ACTIVITY_BEHAVIOR_DAILY_DUNGEON_COUNT = 1003,
		// Token: 0x04009832 RID: 38962
		OP_ACTIVITY_BEHAVIOR_WEEKLY_SUBMIT_TASK = 2002,
		// Token: 0x04009833 RID: 38963
		OP_ACTIVITY_BEHAVIOR_MONEY_CONSUME_COUNT = 4008,
		// Token: 0x04009834 RID: 38964
		OP_ACTIVITY_BEHAVIOR_DAILY_ACCEPT_TASK = 1004,
		// Token: 0x04009835 RID: 38965
		OP_ACTIVITY_BEHAVIOR_DAILY_ONLINE_COUNT,
		// Token: 0x04009836 RID: 38966
		OP_ACTIVITY_BEHAVIOR_ACCOUNT_ONLINE_DAT_COUNT = 4009,
		// Token: 0x04009837 RID: 38967
		OP_ACTIVITY_BEHAVIOR_WEEKLY_ACCEPT_TASK = 2003
	}

	// Token: 0x020018BE RID: 6334
	public enum EActivityType
	{
		// Token: 0x04009839 RID: 38969
		NONE,
		// Token: 0x0400983A RID: 38970
		DAY_SINGLE_CHARGE,
		// Token: 0x0400983B RID: 38971
		DAY_TATOL_CHARGE,
		// Token: 0x0400983C RID: 38972
		TATOL_CHARGE,
		// Token: 0x0400983D RID: 38973
		SINGLE_CHARGE,
		// Token: 0x0400983E RID: 38974
		COMBO_CHARGE,
		// Token: 0x0400983F RID: 38975
		DAY_COST_ITEM,
		// Token: 0x04009840 RID: 38976
		COST_ITEM,
		// Token: 0x04009841 RID: 38977
		DAY_BUY_GIFTPACK,
		// Token: 0x04009842 RID: 38978
		BUY_GIFTPACK,
		// Token: 0x04009843 RID: 38979
		DAY_LOGIN,
		// Token: 0x04009844 RID: 38980
		LOGIN_DAYNUM,
		// Token: 0x04009845 RID: 38981
		DAY_ONLINE_TIME,
		// Token: 0x04009846 RID: 38982
		ONLINE_TIME,
		// Token: 0x04009847 RID: 38983
		DAY_COMPLETE_DUNG,
		// Token: 0x04009848 RID: 38984
		COMPLETE_DUNG,
		// Token: 0x04009849 RID: 38985
		BIND_PHONE,
		// Token: 0x0400984A RID: 38986
		BUY_FASHION,
		// Token: 0x0400984B RID: 38987
		MALL_DISCOUNT_FOR_NEW_SERVER = 1000,
		// Token: 0x0400984C RID: 38988
		LEVEL_FIGHTING_FOR_NEW_SERVER,
		// Token: 0x0400984D RID: 38989
		LEVEL_SHOW_FOR_NEW_SERVER,
		// Token: 0x0400984E RID: 38990
		DUNGEON_DROP_ACTIVITY = 1100,
		// Token: 0x0400984F RID: 38991
		DUNGEON_EXP_ADDITION = 1200,
		// Token: 0x04009850 RID: 38992
		PVP_PK_COIN = 1300,
		// Token: 0x04009851 RID: 38993
		APPOINTMENT_OCCU = 1400,
		// Token: 0x04009852 RID: 38994
		HELL_TICKET_FOR_DRAW_PRIZE = 1500,
		// Token: 0x04009853 RID: 38995
		FATIGUE_FOR_BUFF = 1600,
		// Token: 0x04009854 RID: 38996
		FATIGUE_FOR_TOKEN_COIN = 1700,
		// Token: 0x04009855 RID: 38997
		FATIGUE_BURNING = 1800,
		// Token: 0x04009856 RID: 38998
		GAMBING = 1900,
		// Token: 0x04009857 RID: 38999
		MALL_GIFT_PACK = 5000,
		// Token: 0x04009858 RID: 39000
		DAILY_REWARD = 2000,
		// Token: 0x04009859 RID: 39001
		BOSS_KILL = 20000,
		// Token: 0x0400985A RID: 39002
		BOSS_EXCHANGE,
		// Token: 0x0400985B RID: 39003
		SPECOAL_EXCHANGE,
		// Token: 0x0400985C RID: 39004
		BOSS_QUEST = 24000,
		// Token: 0x0400985D RID: 39005
		MAGPIE_BRIDGE = 2100,
		// Token: 0x0400985E RID: 39006
		MONTH_CARD = 2200,
		// Token: 0x0400985F RID: 39007
		MALL_ACTIVITY_GIFT_PACK = 30001,
		// Token: 0x04009860 RID: 39008
		OAT_DUNGEON_DROP_RATE_ADDITION = 2400,
		// Token: 0x04009861 RID: 39009
		CHANGE_FASHION = 2500,
		// Token: 0x04009862 RID: 39010
		OAT_CHANGE_FASHION_EXCHANGE = 2600,
		// Token: 0x04009863 RID: 39011
		OAT_CHANGE_FASHION_WELFARE = 2700,
		// Token: 0x04009864 RID: 39012
		DUNGEON_RANDOM_BUFF = 2800,
		// Token: 0x04009865 RID: 39013
		DUNGEON_CLEAR_GET_REWARD = 2900,
		// Token: 0x04009866 RID: 39014
		OAT_BUY_FASHION_TICKET = 3000,
		// Token: 0x04009867 RID: 39015
		BUFF_PRAY_ACTIVITY = 3100,
		// Token: 0x04009868 RID: 39016
		OAT_GOBLIN_SHOP_ACT = 3400,
		// Token: 0x04009869 RID: 39017
		OAT_ARTIFACT_JAR = 3500,
		// Token: 0x0400986A RID: 39018
		OAT_JAR_DRAW_LOTTERY = 3600,
		// Token: 0x0400986B RID: 39019
		OAT_LIMIT_TIME_HELL = 3700,
		// Token: 0x0400986C RID: 39020
		OAT_BIND_GOLD_SHOP = 3900,
		// Token: 0x0400986D RID: 39021
		OAT_RETURN_GIFT = 4100,
		// Token: 0x0400986E RID: 39022
		OAT_ACCOUNT_SHOP = 4200,
		// Token: 0x0400986F RID: 39023
		OAT_RETURN_REBATE = 4300,
		// Token: 0x04009870 RID: 39024
		OAT_CHALLENGE_CHAPTER = 4400,
		// Token: 0x04009871 RID: 39025
		OAT_RETURN_PRIVILEGE = 4500,
		// Token: 0x04009872 RID: 39026
		OAT_WEEK_DEEP = 4600,
		// Token: 0x04009873 RID: 39027
		OAT_BUY_PRRSENT = 4700,
		// Token: 0x04009874 RID: 39028
		OAT_LOGIN_REWARD = 4800,
		// Token: 0x04009875 RID: 39029
		OAT_PASS_DUNGEON_REWARD = 4900,
		// Token: 0x04009876 RID: 39030
		OAT_ARTIFACT_JAR_SHOW = 5200,
		// Token: 0x04009877 RID: 39031
		OAT_PROMOTE_EQUIP_STRENGTHEN_RATE = 5300,
		// Token: 0x04009878 RID: 39032
		OAT_WEEK_SIGN_NEW_PLAYER = 5400,
		// Token: 0x04009879 RID: 39033
		OAT_WEEK_SIGN_ACTIVITY = 5500,
		// Token: 0x0400987A RID: 39034
		OAT_SUMMER_WEEKLY_VACATION = 5600,
		// Token: 0x0400987B RID: 39035
		OAT_SUMMER_GRANDdTOTAL_VACATION = 5700,
		// Token: 0x0400987C RID: 39036
		OAT_SECOND_ANNIVERSARY_PRAY = 5800,
		// Token: 0x0400987D RID: 39037
		OAT_FLYING_GIFTPACK_ACTIVITY = 5900,
		// Token: 0x0400987E RID: 39038
		OAT_TUANBEN_ACTIVITY = 6000,
		// Token: 0x0400987F RID: 39039
		OAT_ANNIVERACCUMULATE = 6100,
		// Token: 0x04009880 RID: 39040
		OAT_ANNIBERPARTY = 6200,
		// Token: 0x04009881 RID: 39041
		OAT_HALLOWEENONLINEACTIVITY = 6300,
		// Token: 0x04009882 RID: 39042
		OAT_NEWYEARONDAYACTIVITY = 6400,
		// Token: 0x04009883 RID: 39043
		OAT_CONSUMEREBATEACTIVITY = 6500,
		// Token: 0x04009884 RID: 39044
		OAT_INTEGRATIONCHALLENGEACTIVITU = 6600,
		// Token: 0x04009885 RID: 39045
		OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY = 6800,
		// Token: 0x04009886 RID: 39046
		OAT_MOUSEYEARREDPACKAGEACTIVITY = 6900,
		// Token: 0x04009887 RID: 39047
		OAT_SPRINGFESTIVALACTIVITY = 7000,
		// Token: 0x04009888 RID: 39048
		OAT_SPRINGFESTIVALREDENVELOPERAINACTIVITY = 7100,
		// Token: 0x04009889 RID: 39049
		OAT_CHALLENGEPOINTSREWARDACTIVITY = 7200,
		// Token: 0x0400988A RID: 39050
		OAT_SPINGCHALLENGEACTIVITY = 7300,
		// Token: 0x0400988B RID: 39051
		OAT_SPRINGENGEPOINTSREWARDACTIVITY = 7400,
		// Token: 0x0400988C RID: 39052
		OAT_INAWEEKACTIVITY = 7500,
		// Token: 0x0400988D RID: 39053
		OAT_ONLINEGIFTGIVINGACTIVITY = 7600,
		// Token: 0x0400988E RID: 39054
		OAT_PLANT_TREE = 7700,
		// Token: 0x0400988F RID: 39055
		OAT_FEEDBACKGIFTACTIVITY = 7900,
		// Token: 0x04009890 RID: 39056
		OAT_LIMITTIMEGROUPBUYACTIVITY = 50001,
		// Token: 0x04009891 RID: 39057
		OAT_RECHARGECONSUMERREBATES = 50003,
		// Token: 0x04009892 RID: 39058
		OAT_COMPETITIONSUPPORTACTIVITY,
		// Token: 0x04009893 RID: 39059
		OAT_CHAMPIOSHIPGIFTBAGACTIVITY,
		// Token: 0x04009894 RID: 39060
		OAT_COMMONREWARDACTIVITY,
		// Token: 0x04009895 RID: 39061
		OAT_DAILYCHALLENGEACTIVITY,
		// Token: 0x04009896 RID: 39062
		OAT_ONLINEAWARD,
		// Token: 0x04009897 RID: 39063
		OAT_COURTESYPRIVILEGESACTIVITY,
		// Token: 0x04009898 RID: 39064
		OAT_MYSTERIOUS_MEGASTORE,
		// Token: 0x04009899 RID: 39065
		OAT_SWIPEPICTURESTOSENDTICKETSACTIVITY = 60001,
		// Token: 0x0400989A RID: 39066
		OAT_BRUSHFIGUREGIFTSACTIVITY,
		// Token: 0x0400989B RID: 39067
		OAT_MAGICALJOURENYACTIVITY,
		// Token: 0x0400989C RID: 39068
		OAT_BLESSCARDEXCHANGEACTIVITY,
		// Token: 0x0400989D RID: 39069
		OAT_ABYESS_TICKET_REDUCE = 600010
	}
}
