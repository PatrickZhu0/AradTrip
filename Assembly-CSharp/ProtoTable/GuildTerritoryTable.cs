using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000489 RID: 1161
	public class GuildTerritoryTable : IFlatbufferObject
	{
		// Token: 0x17000E1C RID: 3612
		// (get) Token: 0x06003819 RID: 14361 RVA: 0x000BF334 File Offset: 0x000BD734
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600381A RID: 14362 RVA: 0x000BF341 File Offset: 0x000BD741
		public static GuildTerritoryTable GetRootAsGuildTerritoryTable(ByteBuffer _bb)
		{
			return GuildTerritoryTable.GetRootAsGuildTerritoryTable(_bb, new GuildTerritoryTable());
		}

		// Token: 0x0600381B RID: 14363 RVA: 0x000BF34E File Offset: 0x000BD74E
		public static GuildTerritoryTable GetRootAsGuildTerritoryTable(ByteBuffer _bb, GuildTerritoryTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600381C RID: 14364 RVA: 0x000BF36A File Offset: 0x000BD76A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600381D RID: 14365 RVA: 0x000BF384 File Offset: 0x000BD784
		public GuildTerritoryTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E1D RID: 3613
		// (get) Token: 0x0600381E RID: 14366 RVA: 0x000BF390 File Offset: 0x000BD790
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E1E RID: 3614
		// (get) Token: 0x0600381F RID: 14367 RVA: 0x000BF3DC File Offset: 0x000BD7DC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003820 RID: 14368 RVA: 0x000BF41E File Offset: 0x000BD81E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000E1F RID: 3615
		// (get) Token: 0x06003821 RID: 14369 RVA: 0x000BF42C File Offset: 0x000BD82C
		public GuildTerritoryTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (GuildTerritoryTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E20 RID: 3616
		// (get) Token: 0x06003822 RID: 14370 RVA: 0x000BF470 File Offset: 0x000BD870
		public int IsOpen
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E21 RID: 3617
		// (get) Token: 0x06003823 RID: 14371 RVA: 0x000BF4BC File Offset: 0x000BD8BC
		public int Level
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E22 RID: 3618
		// (get) Token: 0x06003824 RID: 14372 RVA: 0x000BF508 File Offset: 0x000BD908
		public int NeedTerritoryId
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E23 RID: 3619
		// (get) Token: 0x06003825 RID: 14373 RVA: 0x000BF554 File Offset: 0x000BD954
		public int NeedGuildLevel
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E24 RID: 3620
		// (get) Token: 0x06003826 RID: 14374 RVA: 0x000BF5A0 File Offset: 0x000BD9A0
		public int NextTerritoryId
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E25 RID: 3621
		// (get) Token: 0x06003827 RID: 14375 RVA: 0x000BF5EC File Offset: 0x000BD9EC
		public int EnrollNumber
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003828 RID: 14376 RVA: 0x000BF638 File Offset: 0x000BDA38
		public string ConsumeItemArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000E26 RID: 3622
		// (get) Token: 0x06003829 RID: 14377 RVA: 0x000BF680 File Offset: 0x000BDA80
		public int ConsumeItemLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000E27 RID: 3623
		// (get) Token: 0x0600382A RID: 14378 RVA: 0x000BF6B3 File Offset: 0x000BDAB3
		public FlatBufferArray<string> ConsumeItem
		{
			get
			{
				if (this.ConsumeItemValue == null)
				{
					this.ConsumeItemValue = new FlatBufferArray<string>(new Func<int, string>(this.ConsumeItemArray), this.ConsumeItemLength);
				}
				return this.ConsumeItemValue;
			}
		}

		// Token: 0x17000E28 RID: 3624
		// (get) Token: 0x0600382B RID: 14379 RVA: 0x000BF6E4 File Offset: 0x000BDAE4
		public string Score
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600382C RID: 14380 RVA: 0x000BF727 File Offset: 0x000BDB27
		public ArraySegment<byte>? GetScoreBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000E29 RID: 3625
		// (get) Token: 0x0600382D RID: 14381 RVA: 0x000BF738 File Offset: 0x000BDB38
		public int OccupyScore
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E2A RID: 3626
		// (get) Token: 0x0600382E RID: 14382 RVA: 0x000BF784 File Offset: 0x000BDB84
		public int BattleScoreFactor
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600382F RID: 14383 RVA: 0x000BF7D0 File Offset: 0x000BDBD0
		public string LeaderRewardArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000E2B RID: 3627
		// (get) Token: 0x06003830 RID: 14384 RVA: 0x000BF818 File Offset: 0x000BDC18
		public int LeaderRewardLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000E2C RID: 3628
		// (get) Token: 0x06003831 RID: 14385 RVA: 0x000BF84B File Offset: 0x000BDC4B
		public FlatBufferArray<string> LeaderReward
		{
			get
			{
				if (this.LeaderRewardValue == null)
				{
					this.LeaderRewardValue = new FlatBufferArray<string>(new Func<int, string>(this.LeaderRewardArray), this.LeaderRewardLength);
				}
				return this.LeaderRewardValue;
			}
		}

		// Token: 0x06003832 RID: 14386 RVA: 0x000BF87C File Offset: 0x000BDC7C
		public string MemberRewardArray(int j)
		{
			int num = this.__p.__offset(32);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000E2D RID: 3629
		// (get) Token: 0x06003833 RID: 14387 RVA: 0x000BF8C4 File Offset: 0x000BDCC4
		public int MemberRewardLength
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000E2E RID: 3630
		// (get) Token: 0x06003834 RID: 14388 RVA: 0x000BF8F7 File Offset: 0x000BDCF7
		public FlatBufferArray<string> MemberReward
		{
			get
			{
				if (this.MemberRewardValue == null)
				{
					this.MemberRewardValue = new FlatBufferArray<string>(new Func<int, string>(this.MemberRewardArray), this.MemberRewardLength);
				}
				return this.MemberRewardValue;
			}
		}

		// Token: 0x06003835 RID: 14389 RVA: 0x000BF928 File Offset: 0x000BDD28
		public string LeaderDayRewardArray(int j)
		{
			int num = this.__p.__offset(34);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000E2F RID: 3631
		// (get) Token: 0x06003836 RID: 14390 RVA: 0x000BF970 File Offset: 0x000BDD70
		public int LeaderDayRewardLength
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000E30 RID: 3632
		// (get) Token: 0x06003837 RID: 14391 RVA: 0x000BF9A3 File Offset: 0x000BDDA3
		public FlatBufferArray<string> LeaderDayReward
		{
			get
			{
				if (this.LeaderDayRewardValue == null)
				{
					this.LeaderDayRewardValue = new FlatBufferArray<string>(new Func<int, string>(this.LeaderDayRewardArray), this.LeaderDayRewardLength);
				}
				return this.LeaderDayRewardValue;
			}
		}

		// Token: 0x06003838 RID: 14392 RVA: 0x000BF9D4 File Offset: 0x000BDDD4
		public string DayRewardArray(int j)
		{
			int num = this.__p.__offset(36);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000E31 RID: 3633
		// (get) Token: 0x06003839 RID: 14393 RVA: 0x000BFA1C File Offset: 0x000BDE1C
		public int DayRewardLength
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000E32 RID: 3634
		// (get) Token: 0x0600383A RID: 14394 RVA: 0x000BFA4F File Offset: 0x000BDE4F
		public FlatBufferArray<string> DayReward
		{
			get
			{
				if (this.DayRewardValue == null)
				{
					this.DayRewardValue = new FlatBufferArray<string>(new Func<int, string>(this.DayRewardArray), this.DayRewardLength);
				}
				return this.DayRewardValue;
			}
		}

		// Token: 0x0600383B RID: 14395 RVA: 0x000BFA80 File Offset: 0x000BDE80
		public string LoseRewardArray(int j)
		{
			int num = this.__p.__offset(38);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000E33 RID: 3635
		// (get) Token: 0x0600383C RID: 14396 RVA: 0x000BFAC8 File Offset: 0x000BDEC8
		public int LoseRewardLength
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000E34 RID: 3636
		// (get) Token: 0x0600383D RID: 14397 RVA: 0x000BFAFB File Offset: 0x000BDEFB
		public FlatBufferArray<string> LoseReward
		{
			get
			{
				if (this.LoseRewardValue == null)
				{
					this.LoseRewardValue = new FlatBufferArray<string>(new Func<int, string>(this.LoseRewardArray), this.LoseRewardLength);
				}
				return this.LoseRewardValue;
			}
		}

		// Token: 0x0600383E RID: 14398 RVA: 0x000BFB2C File Offset: 0x000BDF2C
		public string MatchIConsumeArray(int j)
		{
			int num = this.__p.__offset(40);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000E35 RID: 3637
		// (get) Token: 0x0600383F RID: 14399 RVA: 0x000BFB74 File Offset: 0x000BDF74
		public int MatchIConsumeLength
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000E36 RID: 3638
		// (get) Token: 0x06003840 RID: 14400 RVA: 0x000BFBA7 File Offset: 0x000BDFA7
		public FlatBufferArray<string> MatchIConsume
		{
			get
			{
				if (this.MatchIConsumeValue == null)
				{
					this.MatchIConsumeValue = new FlatBufferArray<string>(new Func<int, string>(this.MatchIConsumeArray), this.MatchIConsumeLength);
				}
				return this.MatchIConsumeValue;
			}
		}

		// Token: 0x17000E37 RID: 3639
		// (get) Token: 0x06003841 RID: 14401 RVA: 0x000BFBD8 File Offset: 0x000BDFD8
		public int SceneID
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E38 RID: 3640
		// (get) Token: 0x06003842 RID: 14402 RVA: 0x000BFC24 File Offset: 0x000BE024
		public string ChestDoubleDungeons
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003843 RID: 14403 RVA: 0x000BFC67 File Offset: 0x000BE067
		public ArraySegment<byte>? GetChestDoubleDungeonsBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x17000E39 RID: 3641
		// (get) Token: 0x06003844 RID: 14404 RVA: 0x000BFC78 File Offset: 0x000BE078
		public int DailyChestDoubleTimes
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E3A RID: 3642
		// (get) Token: 0x06003845 RID: 14405 RVA: 0x000BFCC4 File Offset: 0x000BE0C4
		public string ChestDoubleFlag
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003846 RID: 14406 RVA: 0x000BFD07 File Offset: 0x000BE107
		public ArraySegment<byte>? GetChestDoubleFlagBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x17000E3B RID: 3643
		// (get) Token: 0x06003847 RID: 14407 RVA: 0x000BFD18 File Offset: 0x000BE118
		public string DropAdditionDungeons
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003848 RID: 14408 RVA: 0x000BFD5B File Offset: 0x000BE15B
		public ArraySegment<byte>? GetDropAdditionDungeonsBytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x17000E3C RID: 3644
		// (get) Token: 0x06003849 RID: 14409 RVA: 0x000BFD6C File Offset: 0x000BE16C
		public int DropAddition
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600384A RID: 14410 RVA: 0x000BFDB8 File Offset: 0x000BE1B8
		public string PropRewardsArray(int j)
		{
			int num = this.__p.__offset(54);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000E3D RID: 3645
		// (get) Token: 0x0600384B RID: 14411 RVA: 0x000BFE00 File Offset: 0x000BE200
		public int PropRewardsLength
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000E3E RID: 3646
		// (get) Token: 0x0600384C RID: 14412 RVA: 0x000BFE33 File Offset: 0x000BE233
		public FlatBufferArray<string> PropRewards
		{
			get
			{
				if (this.PropRewardsValue == null)
				{
					this.PropRewardsValue = new FlatBufferArray<string>(new Func<int, string>(this.PropRewardsArray), this.PropRewardsLength);
				}
				return this.PropRewardsValue;
			}
		}

		// Token: 0x17000E3F RID: 3647
		// (get) Token: 0x0600384D RID: 14413 RVA: 0x000BFE64 File Offset: 0x000BE264
		public int LinkID
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E40 RID: 3648
		// (get) Token: 0x0600384E RID: 14414 RVA: 0x000BFEB0 File Offset: 0x000BE2B0
		public int LeaderPveAddSkill
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E41 RID: 3649
		// (get) Token: 0x0600384F RID: 14415 RVA: 0x000BFEFC File Offset: 0x000BE2FC
		public int LeaderPvPAddSkill
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (-532710575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E42 RID: 3650
		// (get) Token: 0x06003850 RID: 14416 RVA: 0x000BFF48 File Offset: 0x000BE348
		public string iconPath
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003851 RID: 14417 RVA: 0x000BFF8B File Offset: 0x000BE38B
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x06003852 RID: 14418 RVA: 0x000BFF9C File Offset: 0x000BE39C
		public static Offset<GuildTerritoryTable> CreateGuildTerritoryTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), GuildTerritoryTable.eType Type = GuildTerritoryTable.eType.GTT_INVALID, int IsOpen = 0, int Level = 0, int NeedTerritoryId = 0, int NeedGuildLevel = 0, int NextTerritoryId = 0, int EnrollNumber = 0, VectorOffset ConsumeItemOffset = default(VectorOffset), StringOffset ScoreOffset = default(StringOffset), int OccupyScore = 0, int BattleScoreFactor = 0, VectorOffset LeaderRewardOffset = default(VectorOffset), VectorOffset MemberRewardOffset = default(VectorOffset), VectorOffset LeaderDayRewardOffset = default(VectorOffset), VectorOffset DayRewardOffset = default(VectorOffset), VectorOffset LoseRewardOffset = default(VectorOffset), VectorOffset MatchIConsumeOffset = default(VectorOffset), int SceneID = 0, StringOffset ChestDoubleDungeonsOffset = default(StringOffset), int DailyChestDoubleTimes = 0, StringOffset ChestDoubleFlagOffset = default(StringOffset), StringOffset DropAdditionDungeonsOffset = default(StringOffset), int DropAddition = 0, VectorOffset PropRewardsOffset = default(VectorOffset), int LinkID = 0, int LeaderPveAddSkill = 0, int LeaderPvPAddSkill = 0, StringOffset iconPathOffset = default(StringOffset))
		{
			builder.StartObject(30);
			GuildTerritoryTable.AddIconPath(builder, iconPathOffset);
			GuildTerritoryTable.AddLeaderPvPAddSkill(builder, LeaderPvPAddSkill);
			GuildTerritoryTable.AddLeaderPveAddSkill(builder, LeaderPveAddSkill);
			GuildTerritoryTable.AddLinkID(builder, LinkID);
			GuildTerritoryTable.AddPropRewards(builder, PropRewardsOffset);
			GuildTerritoryTable.AddDropAddition(builder, DropAddition);
			GuildTerritoryTable.AddDropAdditionDungeons(builder, DropAdditionDungeonsOffset);
			GuildTerritoryTable.AddChestDoubleFlag(builder, ChestDoubleFlagOffset);
			GuildTerritoryTable.AddDailyChestDoubleTimes(builder, DailyChestDoubleTimes);
			GuildTerritoryTable.AddChestDoubleDungeons(builder, ChestDoubleDungeonsOffset);
			GuildTerritoryTable.AddSceneID(builder, SceneID);
			GuildTerritoryTable.AddMatchIConsume(builder, MatchIConsumeOffset);
			GuildTerritoryTable.AddLoseReward(builder, LoseRewardOffset);
			GuildTerritoryTable.AddDayReward(builder, DayRewardOffset);
			GuildTerritoryTable.AddLeaderDayReward(builder, LeaderDayRewardOffset);
			GuildTerritoryTable.AddMemberReward(builder, MemberRewardOffset);
			GuildTerritoryTable.AddLeaderReward(builder, LeaderRewardOffset);
			GuildTerritoryTable.AddBattleScoreFactor(builder, BattleScoreFactor);
			GuildTerritoryTable.AddOccupyScore(builder, OccupyScore);
			GuildTerritoryTable.AddScore(builder, ScoreOffset);
			GuildTerritoryTable.AddConsumeItem(builder, ConsumeItemOffset);
			GuildTerritoryTable.AddEnrollNumber(builder, EnrollNumber);
			GuildTerritoryTable.AddNextTerritoryId(builder, NextTerritoryId);
			GuildTerritoryTable.AddNeedGuildLevel(builder, NeedGuildLevel);
			GuildTerritoryTable.AddNeedTerritoryId(builder, NeedTerritoryId);
			GuildTerritoryTable.AddLevel(builder, Level);
			GuildTerritoryTable.AddIsOpen(builder, IsOpen);
			GuildTerritoryTable.AddType(builder, Type);
			GuildTerritoryTable.AddName(builder, NameOffset);
			GuildTerritoryTable.AddID(builder, ID);
			return GuildTerritoryTable.EndGuildTerritoryTable(builder);
		}

		// Token: 0x06003853 RID: 14419 RVA: 0x000C00A4 File Offset: 0x000BE4A4
		public static void StartGuildTerritoryTable(FlatBufferBuilder builder)
		{
			builder.StartObject(30);
		}

		// Token: 0x06003854 RID: 14420 RVA: 0x000C00AE File Offset: 0x000BE4AE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003855 RID: 14421 RVA: 0x000C00B9 File Offset: 0x000BE4B9
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003856 RID: 14422 RVA: 0x000C00CA File Offset: 0x000BE4CA
		public static void AddType(FlatBufferBuilder builder, GuildTerritoryTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06003857 RID: 14423 RVA: 0x000C00D5 File Offset: 0x000BE4D5
		public static void AddIsOpen(FlatBufferBuilder builder, int IsOpen)
		{
			builder.AddInt(3, IsOpen, 0);
		}

		// Token: 0x06003858 RID: 14424 RVA: 0x000C00E0 File Offset: 0x000BE4E0
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(4, Level, 0);
		}

		// Token: 0x06003859 RID: 14425 RVA: 0x000C00EB File Offset: 0x000BE4EB
		public static void AddNeedTerritoryId(FlatBufferBuilder builder, int NeedTerritoryId)
		{
			builder.AddInt(5, NeedTerritoryId, 0);
		}

		// Token: 0x0600385A RID: 14426 RVA: 0x000C00F6 File Offset: 0x000BE4F6
		public static void AddNeedGuildLevel(FlatBufferBuilder builder, int NeedGuildLevel)
		{
			builder.AddInt(6, NeedGuildLevel, 0);
		}

		// Token: 0x0600385B RID: 14427 RVA: 0x000C0101 File Offset: 0x000BE501
		public static void AddNextTerritoryId(FlatBufferBuilder builder, int NextTerritoryId)
		{
			builder.AddInt(7, NextTerritoryId, 0);
		}

		// Token: 0x0600385C RID: 14428 RVA: 0x000C010C File Offset: 0x000BE50C
		public static void AddEnrollNumber(FlatBufferBuilder builder, int EnrollNumber)
		{
			builder.AddInt(8, EnrollNumber, 0);
		}

		// Token: 0x0600385D RID: 14429 RVA: 0x000C0117 File Offset: 0x000BE517
		public static void AddConsumeItem(FlatBufferBuilder builder, VectorOffset ConsumeItemOffset)
		{
			builder.AddOffset(9, ConsumeItemOffset.Value, 0);
		}

		// Token: 0x0600385E RID: 14430 RVA: 0x000C012C File Offset: 0x000BE52C
		public static VectorOffset CreateConsumeItemVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600385F RID: 14431 RVA: 0x000C0172 File Offset: 0x000BE572
		public static void StartConsumeItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003860 RID: 14432 RVA: 0x000C017D File Offset: 0x000BE57D
		public static void AddScore(FlatBufferBuilder builder, StringOffset ScoreOffset)
		{
			builder.AddOffset(10, ScoreOffset.Value, 0);
		}

		// Token: 0x06003861 RID: 14433 RVA: 0x000C018F File Offset: 0x000BE58F
		public static void AddOccupyScore(FlatBufferBuilder builder, int OccupyScore)
		{
			builder.AddInt(11, OccupyScore, 0);
		}

		// Token: 0x06003862 RID: 14434 RVA: 0x000C019B File Offset: 0x000BE59B
		public static void AddBattleScoreFactor(FlatBufferBuilder builder, int BattleScoreFactor)
		{
			builder.AddInt(12, BattleScoreFactor, 0);
		}

		// Token: 0x06003863 RID: 14435 RVA: 0x000C01A7 File Offset: 0x000BE5A7
		public static void AddLeaderReward(FlatBufferBuilder builder, VectorOffset LeaderRewardOffset)
		{
			builder.AddOffset(13, LeaderRewardOffset.Value, 0);
		}

		// Token: 0x06003864 RID: 14436 RVA: 0x000C01BC File Offset: 0x000BE5BC
		public static VectorOffset CreateLeaderRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003865 RID: 14437 RVA: 0x000C0202 File Offset: 0x000BE602
		public static void StartLeaderRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003866 RID: 14438 RVA: 0x000C020D File Offset: 0x000BE60D
		public static void AddMemberReward(FlatBufferBuilder builder, VectorOffset MemberRewardOffset)
		{
			builder.AddOffset(14, MemberRewardOffset.Value, 0);
		}

		// Token: 0x06003867 RID: 14439 RVA: 0x000C0220 File Offset: 0x000BE620
		public static VectorOffset CreateMemberRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003868 RID: 14440 RVA: 0x000C0266 File Offset: 0x000BE666
		public static void StartMemberRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003869 RID: 14441 RVA: 0x000C0271 File Offset: 0x000BE671
		public static void AddLeaderDayReward(FlatBufferBuilder builder, VectorOffset LeaderDayRewardOffset)
		{
			builder.AddOffset(15, LeaderDayRewardOffset.Value, 0);
		}

		// Token: 0x0600386A RID: 14442 RVA: 0x000C0284 File Offset: 0x000BE684
		public static VectorOffset CreateLeaderDayRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600386B RID: 14443 RVA: 0x000C02CA File Offset: 0x000BE6CA
		public static void StartLeaderDayRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600386C RID: 14444 RVA: 0x000C02D5 File Offset: 0x000BE6D5
		public static void AddDayReward(FlatBufferBuilder builder, VectorOffset DayRewardOffset)
		{
			builder.AddOffset(16, DayRewardOffset.Value, 0);
		}

		// Token: 0x0600386D RID: 14445 RVA: 0x000C02E8 File Offset: 0x000BE6E8
		public static VectorOffset CreateDayRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600386E RID: 14446 RVA: 0x000C032E File Offset: 0x000BE72E
		public static void StartDayRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600386F RID: 14447 RVA: 0x000C0339 File Offset: 0x000BE739
		public static void AddLoseReward(FlatBufferBuilder builder, VectorOffset LoseRewardOffset)
		{
			builder.AddOffset(17, LoseRewardOffset.Value, 0);
		}

		// Token: 0x06003870 RID: 14448 RVA: 0x000C034C File Offset: 0x000BE74C
		public static VectorOffset CreateLoseRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003871 RID: 14449 RVA: 0x000C0392 File Offset: 0x000BE792
		public static void StartLoseRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003872 RID: 14450 RVA: 0x000C039D File Offset: 0x000BE79D
		public static void AddMatchIConsume(FlatBufferBuilder builder, VectorOffset MatchIConsumeOffset)
		{
			builder.AddOffset(18, MatchIConsumeOffset.Value, 0);
		}

		// Token: 0x06003873 RID: 14451 RVA: 0x000C03B0 File Offset: 0x000BE7B0
		public static VectorOffset CreateMatchIConsumeVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003874 RID: 14452 RVA: 0x000C03F6 File Offset: 0x000BE7F6
		public static void StartMatchIConsumeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003875 RID: 14453 RVA: 0x000C0401 File Offset: 0x000BE801
		public static void AddSceneID(FlatBufferBuilder builder, int SceneID)
		{
			builder.AddInt(19, SceneID, 0);
		}

		// Token: 0x06003876 RID: 14454 RVA: 0x000C040D File Offset: 0x000BE80D
		public static void AddChestDoubleDungeons(FlatBufferBuilder builder, StringOffset ChestDoubleDungeonsOffset)
		{
			builder.AddOffset(20, ChestDoubleDungeonsOffset.Value, 0);
		}

		// Token: 0x06003877 RID: 14455 RVA: 0x000C041F File Offset: 0x000BE81F
		public static void AddDailyChestDoubleTimes(FlatBufferBuilder builder, int DailyChestDoubleTimes)
		{
			builder.AddInt(21, DailyChestDoubleTimes, 0);
		}

		// Token: 0x06003878 RID: 14456 RVA: 0x000C042B File Offset: 0x000BE82B
		public static void AddChestDoubleFlag(FlatBufferBuilder builder, StringOffset ChestDoubleFlagOffset)
		{
			builder.AddOffset(22, ChestDoubleFlagOffset.Value, 0);
		}

		// Token: 0x06003879 RID: 14457 RVA: 0x000C043D File Offset: 0x000BE83D
		public static void AddDropAdditionDungeons(FlatBufferBuilder builder, StringOffset DropAdditionDungeonsOffset)
		{
			builder.AddOffset(23, DropAdditionDungeonsOffset.Value, 0);
		}

		// Token: 0x0600387A RID: 14458 RVA: 0x000C044F File Offset: 0x000BE84F
		public static void AddDropAddition(FlatBufferBuilder builder, int DropAddition)
		{
			builder.AddInt(24, DropAddition, 0);
		}

		// Token: 0x0600387B RID: 14459 RVA: 0x000C045B File Offset: 0x000BE85B
		public static void AddPropRewards(FlatBufferBuilder builder, VectorOffset PropRewardsOffset)
		{
			builder.AddOffset(25, PropRewardsOffset.Value, 0);
		}

		// Token: 0x0600387C RID: 14460 RVA: 0x000C0470 File Offset: 0x000BE870
		public static VectorOffset CreatePropRewardsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600387D RID: 14461 RVA: 0x000C04B6 File Offset: 0x000BE8B6
		public static void StartPropRewardsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600387E RID: 14462 RVA: 0x000C04C1 File Offset: 0x000BE8C1
		public static void AddLinkID(FlatBufferBuilder builder, int LinkID)
		{
			builder.AddInt(26, LinkID, 0);
		}

		// Token: 0x0600387F RID: 14463 RVA: 0x000C04CD File Offset: 0x000BE8CD
		public static void AddLeaderPveAddSkill(FlatBufferBuilder builder, int LeaderPveAddSkill)
		{
			builder.AddInt(27, LeaderPveAddSkill, 0);
		}

		// Token: 0x06003880 RID: 14464 RVA: 0x000C04D9 File Offset: 0x000BE8D9
		public static void AddLeaderPvPAddSkill(FlatBufferBuilder builder, int LeaderPvPAddSkill)
		{
			builder.AddInt(28, LeaderPvPAddSkill, 0);
		}

		// Token: 0x06003881 RID: 14465 RVA: 0x000C04E5 File Offset: 0x000BE8E5
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset iconPathOffset)
		{
			builder.AddOffset(29, iconPathOffset.Value, 0);
		}

		// Token: 0x06003882 RID: 14466 RVA: 0x000C04F8 File Offset: 0x000BE8F8
		public static Offset<GuildTerritoryTable> EndGuildTerritoryTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildTerritoryTable>(value);
		}

		// Token: 0x06003883 RID: 14467 RVA: 0x000C0512 File Offset: 0x000BE912
		public static void FinishGuildTerritoryTableBuffer(FlatBufferBuilder builder, Offset<GuildTerritoryTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015F9 RID: 5625
		private Table __p = new Table();

		// Token: 0x040015FA RID: 5626
		private FlatBufferArray<string> ConsumeItemValue;

		// Token: 0x040015FB RID: 5627
		private FlatBufferArray<string> LeaderRewardValue;

		// Token: 0x040015FC RID: 5628
		private FlatBufferArray<string> MemberRewardValue;

		// Token: 0x040015FD RID: 5629
		private FlatBufferArray<string> LeaderDayRewardValue;

		// Token: 0x040015FE RID: 5630
		private FlatBufferArray<string> DayRewardValue;

		// Token: 0x040015FF RID: 5631
		private FlatBufferArray<string> LoseRewardValue;

		// Token: 0x04001600 RID: 5632
		private FlatBufferArray<string> MatchIConsumeValue;

		// Token: 0x04001601 RID: 5633
		private FlatBufferArray<string> PropRewardsValue;

		// Token: 0x0200048A RID: 1162
		public enum eType
		{
			// Token: 0x04001603 RID: 5635
			GTT_INVALID,
			// Token: 0x04001604 RID: 5636
			GTT_NORMAL,
			// Token: 0x04001605 RID: 5637
			GTT_CROSS
		}

		// Token: 0x0200048B RID: 1163
		public enum eCrypt
		{
			// Token: 0x04001607 RID: 5639
			code = -532710575
		}
	}
}
