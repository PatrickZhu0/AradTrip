using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002D4 RID: 724
	public class BetHorseCfg : IFlatbufferObject
	{
		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06001A3B RID: 6715 RVA: 0x00077758 File Offset: 0x00075B58
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001A3C RID: 6716 RVA: 0x00077765 File Offset: 0x00075B65
		public static BetHorseCfg GetRootAsBetHorseCfg(ByteBuffer _bb)
		{
			return BetHorseCfg.GetRootAsBetHorseCfg(_bb, new BetHorseCfg());
		}

		// Token: 0x06001A3D RID: 6717 RVA: 0x00077772 File Offset: 0x00075B72
		public static BetHorseCfg GetRootAsBetHorseCfg(ByteBuffer _bb, BetHorseCfg obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001A3E RID: 6718 RVA: 0x0007778E File Offset: 0x00075B8E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001A3F RID: 6719 RVA: 0x000777A8 File Offset: 0x00075BA8
		public BetHorseCfg __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06001A40 RID: 6720 RVA: 0x000777B4 File Offset: 0x00075BB4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06001A41 RID: 6721 RVA: 0x00077800 File Offset: 0x00075C00
		public int StakeMax
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06001A42 RID: 6722 RVA: 0x0007784C File Offset: 0x00075C4C
		public int ShooterNum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06001A43 RID: 6723 RVA: 0x00077898 File Offset: 0x00075C98
		public int RefreshOddsInterval
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06001A44 RID: 6724 RVA: 0x000778E4 File Offset: 0x00075CE4
		public int StakeEndTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06001A45 RID: 6725 RVA: 0x00077930 File Offset: 0x00075D30
		public int AdjustEndTime
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06001A46 RID: 6726 RVA: 0x0007797C File Offset: 0x00075D7C
		public string StartTime
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001A47 RID: 6727 RVA: 0x000779BF File Offset: 0x00075DBF
		public ArraySegment<byte>? GetStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06001A48 RID: 6728 RVA: 0x000779D0 File Offset: 0x00075DD0
		public int bulletID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06001A49 RID: 6729 RVA: 0x00077A1C File Offset: 0x00075E1C
		public int StartStakePublic
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06001A4A RID: 6730 RVA: 0x00077A68 File Offset: 0x00075E68
		public int EndStakePublic
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06001A4B RID: 6731 RVA: 0x00077AB4 File Offset: 0x00075EB4
		public int BattleStartPublic
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06001A4C RID: 6732 RVA: 0x00077B00 File Offset: 0x00075F00
		public int OpenRewardPublic
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06001A4D RID: 6733 RVA: 0x00077B4C File Offset: 0x00075F4C
		public string EndWarnTime
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001A4E RID: 6734 RVA: 0x00077B8F File Offset: 0x00075F8F
		public ArraySegment<byte>? GetEndWarnTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06001A4F RID: 6735 RVA: 0x00077BA0 File Offset: 0x00075FA0
		public int MysteryRate
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06001A50 RID: 6736 RVA: 0x00077BEC File Offset: 0x00075FEC
		public int BaseWinRate
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06001A51 RID: 6737 RVA: 0x00077C38 File Offset: 0x00076038
		public int BulletMallItemId
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06001A52 RID: 6738 RVA: 0x00077C84 File Offset: 0x00076084
		public int initOddsMin
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06001A53 RID: 6739 RVA: 0x00077CD0 File Offset: 0x000760D0
		public int initOddsMax
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (2141410366 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001A54 RID: 6740 RVA: 0x00077D1C File Offset: 0x0007611C
		public static Offset<BetHorseCfg> CreateBetHorseCfg(FlatBufferBuilder builder, int ID = 0, int StakeMax = 0, int ShooterNum = 0, int RefreshOddsInterval = 0, int StakeEndTime = 0, int AdjustEndTime = 0, StringOffset StartTimeOffset = default(StringOffset), int bulletID = 0, int StartStakePublic = 0, int EndStakePublic = 0, int BattleStartPublic = 0, int OpenRewardPublic = 0, StringOffset EndWarnTimeOffset = default(StringOffset), int MysteryRate = 0, int BaseWinRate = 0, int BulletMallItemId = 0, int initOddsMin = 0, int initOddsMax = 0)
		{
			builder.StartObject(18);
			BetHorseCfg.AddInitOddsMax(builder, initOddsMax);
			BetHorseCfg.AddInitOddsMin(builder, initOddsMin);
			BetHorseCfg.AddBulletMallItemId(builder, BulletMallItemId);
			BetHorseCfg.AddBaseWinRate(builder, BaseWinRate);
			BetHorseCfg.AddMysteryRate(builder, MysteryRate);
			BetHorseCfg.AddEndWarnTime(builder, EndWarnTimeOffset);
			BetHorseCfg.AddOpenRewardPublic(builder, OpenRewardPublic);
			BetHorseCfg.AddBattleStartPublic(builder, BattleStartPublic);
			BetHorseCfg.AddEndStakePublic(builder, EndStakePublic);
			BetHorseCfg.AddStartStakePublic(builder, StartStakePublic);
			BetHorseCfg.AddBulletID(builder, bulletID);
			BetHorseCfg.AddStartTime(builder, StartTimeOffset);
			BetHorseCfg.AddAdjustEndTime(builder, AdjustEndTime);
			BetHorseCfg.AddStakeEndTime(builder, StakeEndTime);
			BetHorseCfg.AddRefreshOddsInterval(builder, RefreshOddsInterval);
			BetHorseCfg.AddShooterNum(builder, ShooterNum);
			BetHorseCfg.AddStakeMax(builder, StakeMax);
			BetHorseCfg.AddID(builder, ID);
			return BetHorseCfg.EndBetHorseCfg(builder);
		}

		// Token: 0x06001A55 RID: 6741 RVA: 0x00077DC4 File Offset: 0x000761C4
		public static void StartBetHorseCfg(FlatBufferBuilder builder)
		{
			builder.StartObject(18);
		}

		// Token: 0x06001A56 RID: 6742 RVA: 0x00077DCE File Offset: 0x000761CE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001A57 RID: 6743 RVA: 0x00077DD9 File Offset: 0x000761D9
		public static void AddStakeMax(FlatBufferBuilder builder, int StakeMax)
		{
			builder.AddInt(1, StakeMax, 0);
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x00077DE4 File Offset: 0x000761E4
		public static void AddShooterNum(FlatBufferBuilder builder, int ShooterNum)
		{
			builder.AddInt(2, ShooterNum, 0);
		}

		// Token: 0x06001A59 RID: 6745 RVA: 0x00077DEF File Offset: 0x000761EF
		public static void AddRefreshOddsInterval(FlatBufferBuilder builder, int RefreshOddsInterval)
		{
			builder.AddInt(3, RefreshOddsInterval, 0);
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x00077DFA File Offset: 0x000761FA
		public static void AddStakeEndTime(FlatBufferBuilder builder, int StakeEndTime)
		{
			builder.AddInt(4, StakeEndTime, 0);
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x00077E05 File Offset: 0x00076205
		public static void AddAdjustEndTime(FlatBufferBuilder builder, int AdjustEndTime)
		{
			builder.AddInt(5, AdjustEndTime, 0);
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x00077E10 File Offset: 0x00076210
		public static void AddStartTime(FlatBufferBuilder builder, StringOffset StartTimeOffset)
		{
			builder.AddOffset(6, StartTimeOffset.Value, 0);
		}

		// Token: 0x06001A5D RID: 6749 RVA: 0x00077E21 File Offset: 0x00076221
		public static void AddBulletID(FlatBufferBuilder builder, int bulletID)
		{
			builder.AddInt(7, bulletID, 0);
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x00077E2C File Offset: 0x0007622C
		public static void AddStartStakePublic(FlatBufferBuilder builder, int StartStakePublic)
		{
			builder.AddInt(8, StartStakePublic, 0);
		}

		// Token: 0x06001A5F RID: 6751 RVA: 0x00077E37 File Offset: 0x00076237
		public static void AddEndStakePublic(FlatBufferBuilder builder, int EndStakePublic)
		{
			builder.AddInt(9, EndStakePublic, 0);
		}

		// Token: 0x06001A60 RID: 6752 RVA: 0x00077E43 File Offset: 0x00076243
		public static void AddBattleStartPublic(FlatBufferBuilder builder, int BattleStartPublic)
		{
			builder.AddInt(10, BattleStartPublic, 0);
		}

		// Token: 0x06001A61 RID: 6753 RVA: 0x00077E4F File Offset: 0x0007624F
		public static void AddOpenRewardPublic(FlatBufferBuilder builder, int OpenRewardPublic)
		{
			builder.AddInt(11, OpenRewardPublic, 0);
		}

		// Token: 0x06001A62 RID: 6754 RVA: 0x00077E5B File Offset: 0x0007625B
		public static void AddEndWarnTime(FlatBufferBuilder builder, StringOffset EndWarnTimeOffset)
		{
			builder.AddOffset(12, EndWarnTimeOffset.Value, 0);
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x00077E6D File Offset: 0x0007626D
		public static void AddMysteryRate(FlatBufferBuilder builder, int MysteryRate)
		{
			builder.AddInt(13, MysteryRate, 0);
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x00077E79 File Offset: 0x00076279
		public static void AddBaseWinRate(FlatBufferBuilder builder, int BaseWinRate)
		{
			builder.AddInt(14, BaseWinRate, 0);
		}

		// Token: 0x06001A65 RID: 6757 RVA: 0x00077E85 File Offset: 0x00076285
		public static void AddBulletMallItemId(FlatBufferBuilder builder, int BulletMallItemId)
		{
			builder.AddInt(15, BulletMallItemId, 0);
		}

		// Token: 0x06001A66 RID: 6758 RVA: 0x00077E91 File Offset: 0x00076291
		public static void AddInitOddsMin(FlatBufferBuilder builder, int initOddsMin)
		{
			builder.AddInt(16, initOddsMin, 0);
		}

		// Token: 0x06001A67 RID: 6759 RVA: 0x00077E9D File Offset: 0x0007629D
		public static void AddInitOddsMax(FlatBufferBuilder builder, int initOddsMax)
		{
			builder.AddInt(17, initOddsMax, 0);
		}

		// Token: 0x06001A68 RID: 6760 RVA: 0x00077EAC File Offset: 0x000762AC
		public static Offset<BetHorseCfg> EndBetHorseCfg(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BetHorseCfg>(value);
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x00077EC6 File Offset: 0x000762C6
		public static void FinishBetHorseCfgBuffer(FlatBufferBuilder builder, Offset<BetHorseCfg> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EA4 RID: 3748
		private Table __p = new Table();

		// Token: 0x020002D5 RID: 725
		public enum eCrypt
		{
			// Token: 0x04000EA6 RID: 3750
			code = 2141410366
		}
	}
}
