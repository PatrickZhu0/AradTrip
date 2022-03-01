using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MobileBind;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012D2 RID: 4818
	internal class RedPointDataManager : DataManager<RedPointDataManager>
	{
		// Token: 0x0600BAD7 RID: 47831 RVA: 0x002B3C62 File Offset: 0x002B2062
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.RedPointDataManager;
		}

		// Token: 0x0600BAD8 RID: 47832 RVA: 0x002B3C68 File Offset: 0x002B2068
		public sealed override void Initialize()
		{
			if (!this.m_bRedPointsInited)
			{
				this.m_arrDelCheckRedPoints[0] = null;
				this.m_arrDelCheckRedPoints[1] = null;
				this.m_arrDelCheckRedPoints[33] = new RedPointDataManager.CheckRedPoint(DataManager<GuildDataManager>.GetInstance().CheckExchangeRedPoint);
				this.m_arrDelCheckRedPoints[35] = (() => DataManager<JarDataManager>.GetInstance().CheckRedPoint(JarBonus.eType.MagicJar));
				this.m_arrDelCheckRedPoints[36] = (() => DataManager<JarDataManager>.GetInstance().CheckRedPoint(JarBonus.eType.GoldJar));
				this.m_arrDelCheckRedPoints[37] = (() => DataManager<JarDataManager>.GetInstance().CheckRedPoint(JarBonus.eType.MagicJar_Lv55) && Utility.IsUnLockFunc(68));
				this.m_arrDelCheckRedPoints[34] = (() => this.HasRedPoint(ERedPoint.MagicJar) || this.HasRedPoint(ERedPoint.GoldJar) || this.HasRedPoint(ERedPoint.MagicJar_Lv55) || DataManager<JarDataManager>.GetInstance().IsRedPointShow());
				this.m_arrDelCheckRedPoints[116] = new RedPointDataManager.CheckRedPoint(DataManager<GuildDataManager>.GetInstance().CheckGuildBattleEnterRedPoint);
				this.m_arrDelCheckRedPoints[115] = new RedPointDataManager.CheckRedPoint(DataManager<GuildDataManager>.GetInstance().CheckGuildBattleSignUpRedPoint);
				this.m_arrDelCheckRedPoints[100] = delegate()
				{
					if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
					{
						bool flag = false;
						GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
						if (guildDungeonActivityData != null)
						{
							flag = (GuildDataManager.CheckActivityLimit() && guildDungeonActivityData.nActivityState != 0U);
						}
						return this.HasRedPoint(ERedPoint.GuildBase) || this.HasRedPoint(ERedPoint.GuildBuilding) || this.HasRedPoint(ERedPoint.GuildMember) || this.HasRedPoint(ERedPoint.GuildMerger) || this.HasRedPoint(ERedPoint.GuildManor) || this.HasRedPoint(ERedPoint.GuildCrossManor) || this.HasRedPoint(ERedPoint.GuildTerrDayReward) || flag;
					}
					return false;
				};
				this.m_arrDelCheckRedPoints[101] = (() => false);
				this.m_arrDelCheckRedPoints[102] = (() => this.HasRedPoint(ERedPoint.GuildMainCity) || this.HasRedPoint(ERedPoint.GuildBuildingManager) || this.HasRedPoint(ERedPoint.GuildEmblem) || this.HasRedPoint(ERedPoint.GuildSetBossDiff));
				this.m_arrDelCheckRedPoints[107] = (() => DataManager<GuildDataManager>.GetInstance().CanLvUpBulilding());
				this.m_arrDelCheckRedPoints[108] = (() => DataManager<GuildDataManager>.GetInstance().CanActiveEmblem() || DataManager<GuildDataManager>.GetInstance().CanLvUpEmblem());
				this.m_arrDelCheckRedPoints[109] = (() => DataManager<GuildDataManager>.GetInstance().CanSetBossDiff());
				this.m_arrDelCheckRedPoints[103] = (() => this.HasRedPoint(ERedPoint.GuildRequester) && DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.ProcessRequester, EGuildDuty.Invalid));
				this.m_arrDelCheckRedPoints[104] = (() => DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL && (this.HasRedPoint(ERedPoint.GuildBattleSignUp) || this.HasRedPoint(ERedPoint.GuildBattleEnter)));
				this.m_arrDelCheckRedPoints[105] = (() => DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS && (this.HasRedPoint(ERedPoint.GuildBattleSignUp) || this.HasRedPoint(ERedPoint.GuildBattleEnter)));
				this.m_arrDelCheckRedPoints[110] = (() => false);
				this.m_arrDelCheckRedPoints[111] = (() => this.HasRedPoint(ERedPoint.GuildExchange));
				this.m_arrDelCheckRedPoints[112] = (() => DataManager<GuildDataManager>.GetInstance().GetRemainWorshipTimes() > 0);
				this.m_arrDelCheckRedPoints[113] = (() => false);
				this.m_arrDelCheckRedPoints[114] = (() => !DataManager<GuildDataManager>.GetInstance().HasJoinedTable() && DataManager<GuildDataManager>.GetInstance().GetTableType() == GuildRoundtableTable.eType.First);
				this.m_arrDelCheckRedPoints[204] = (() => DataManager<MissionManager>.GetInstance().HasRedPoint());
				this.m_arrDelCheckRedPoints[200] = new RedPointDataManager.CheckRedPoint(DataManager<SkillDataManager>.GetInstance().HasSkillLvCanUp);
				RedPointDataManager.CheckRedPoint[] arrDelCheckRedPoints = this.m_arrDelCheckRedPoints;
				int num = 201;
				if (RedPointDataManager.<>f__mg$cache0 == null)
				{
					RedPointDataManager.<>f__mg$cache0 = new RedPointDataManager.CheckRedPoint(Utility.IsShowDailyProveRedPoint);
				}
				arrDelCheckRedPoints[num] = RedPointDataManager.<>f__mg$cache0;
				this.m_arrDelCheckRedPoints[202] = new RedPointDataManager.CheckRedPoint(DataManager<TeamDataManager>.GetInstance().HasNewRequester);
				RedPointDataManager.CheckRedPoint[] arrDelCheckRedPoints2 = this.m_arrDelCheckRedPoints;
				int num2 = 205;
				if (RedPointDataManager.<>f__mg$cache1 == null)
				{
					RedPointDataManager.<>f__mg$cache1 = new RedPointDataManager.CheckRedPoint(ChapterUtility.IsChapterCanGetChapterRewards);
				}
				arrDelCheckRedPoints2[num2] = RedPointDataManager.<>f__mg$cache1;
				this.m_arrDelCheckRedPoints[38] = (() => DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(EPackageType.Equip) || DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(EPackageType.Fashion) || DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(EPackageType.Consumable) || DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(EPackageType.Title) || DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(EPackageType.Inscription) || DataManager<PetDataManager>.GetInstance().IsNeedShowOnUsePetsRedPoint() || DataManager<PetDataManager>.GetInstance().IsNeedShowPetEggRedPoint() || DataManager<PetDataManager>.GetInstance().IsNeedShowPetRedPoint() || HonorSystemUtility.IsShowHonorSystemRedPoint());
				this.m_arrDelCheckRedPoints[203] = new RedPointDataManager.CheckRedPoint(DataManager<EquipForgeDataManager>.GetInstance().CheckRedPoint);
				this.m_arrDelCheckRedPoints[400] = (() => DataManager<ActivityDungeonDataManager>.GetInstance().IsShowRedByActivityType(ActivityDungeonTable.eActivityType.TimeLimit) || DataManager<ActivityDungeonDataManager>.GetInstance().IsShowRedByActivityType(ActivityDungeonTable.eActivityType.Daily) || MissionDailyFrame.CheckRedPoint());
				this.m_arrDelCheckRedPoints[500] = (() => DataManager<MobileBindManager>.GetInstance().HasBindMobileAwardToReceive());
				this.m_arrDelCheckRedPoints[401] = new RedPointDataManager.CheckRedPoint(DataManager<ActivityManager>.GetInstance().IsHaveAnyRedPoint);
				this.m_arrDelCheckRedPoints[501] = (() => DataManager<EquipRecoveryDataManager>.GetInstance().HaveRedPoint());
				this.m_arrDelCheckRedPoints[502] = (() => DataManager<AdventureTeamDataManager>.GetInstance().HasRedPointShow());
				this.m_arrDelCheckRedPoints[117] = null;
				this.m_bRedPointsInited = true;
			}
		}

		// Token: 0x0600BAD9 RID: 47833 RVA: 0x002B40D8 File Offset: 0x002B24D8
		public sealed override void Clear()
		{
			if (this.m_bRedPointsInited)
			{
				this.m_arrRedPoints = new bool[503];
				this.m_arrDelCheckRedPoints = new RedPointDataManager.CheckRedPoint[503];
				this.m_bRedPointsInited = false;
			}
			this.m_arrEventBuffer.Clear();
		}

		// Token: 0x0600BADA RID: 47834 RVA: 0x002B4118 File Offset: 0x002B2518
		public new void Update(float a_fTime)
		{
			for (int i = 0; i < this.m_arrEventBuffer.Count; i++)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, this.m_arrEventBuffer[i], null, null, null);
			}
			this.m_arrEventBuffer.Clear();
		}

		// Token: 0x0600BADB RID: 47835 RVA: 0x002B416C File Offset: 0x002B256C
		public void UpdateRedPoints(uint a_nServerData)
		{
			this.m_arrRedPoints[0] = ((a_nServerData & 1U) != 0U);
			this.m_arrRedPoints[1] = ((a_nServerData & 2U) != 0U);
			this.m_arrRedPoints[117] = ((a_nServerData & 16U) != 0U);
			this.m_arrRedPoints[118] = ((a_nServerData & 32U) != 0U);
			this.NotifyRedPointChanged(ERedPoint.Invalid);
		}

		// Token: 0x0600BADC RID: 47836 RVA: 0x002B41C8 File Offset: 0x002B25C8
		public bool HasRedPoint(ERedPoint a_eType)
		{
			if (a_eType > ERedPoint.Invalid && a_eType < ERedPoint.Count)
			{
				if (this.m_arrDelCheckRedPoints[(int)a_eType] != null)
				{
					this.m_arrRedPoints[(int)a_eType] = this.m_arrDelCheckRedPoints[(int)a_eType]();
				}
				return this.m_arrRedPoints[(int)a_eType];
			}
			return false;
		}

		// Token: 0x0600BADD RID: 47837 RVA: 0x002B4208 File Offset: 0x002B2608
		public void ClearRedPoint(ERedPoint a_eType)
		{
			if (a_eType > ERedPoint.Invalid && a_eType < ERedPoint.Count)
			{
				if (a_eType < ERedPoint.ServerRedPointCount)
				{
					SceneClearRedPoint sceneClearRedPoint = new SceneClearRedPoint();
					sceneClearRedPoint.flag = (uint)a_eType;
					NetManager.Instance().SendCommand<SceneClearRedPoint>(ServerType.GATE_SERVER, sceneClearRedPoint);
				}
				if (this.m_arrRedPoints[(int)a_eType])
				{
					this.m_arrRedPoints[(int)a_eType] = false;
					this.NotifyRedPointChanged(ERedPoint.Invalid);
				}
			}
		}

		// Token: 0x0600BADE RID: 47838 RVA: 0x002B4266 File Offset: 0x002B2666
		public void NotifyRedPointChanged(ERedPoint redPointType = ERedPoint.Invalid)
		{
			if (!this.m_arrEventBuffer.Contains(redPointType))
			{
				this.m_arrEventBuffer.Add(redPointType);
			}
		}

		// Token: 0x0400690C RID: 26892
		private bool[] m_arrRedPoints = new bool[503];

		// Token: 0x0400690D RID: 26893
		private RedPointDataManager.CheckRedPoint[] m_arrDelCheckRedPoints = new RedPointDataManager.CheckRedPoint[503];

		// Token: 0x0400690E RID: 26894
		private bool m_bRedPointsInited;

		// Token: 0x0400690F RID: 26895
		private List<ERedPoint> m_arrEventBuffer = new List<ERedPoint>();

		// Token: 0x04006910 RID: 26896
		[CompilerGenerated]
		private static RedPointDataManager.CheckRedPoint <>f__mg$cache0;

		// Token: 0x04006911 RID: 26897
		[CompilerGenerated]
		private static RedPointDataManager.CheckRedPoint <>f__mg$cache1;

		// Token: 0x020012D3 RID: 4819
		// (Invoke) Token: 0x0600BAF8 RID: 47864
		public delegate bool CheckRedPoint();
	}
}
