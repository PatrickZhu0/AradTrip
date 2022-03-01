using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000608 RID: 1544
	public class UltimateChallengeDungeonTable : IFlatbufferObject
	{
		// Token: 0x1700167F RID: 5759
		// (get) Token: 0x0600517F RID: 20863 RVA: 0x000FAD64 File Offset: 0x000F9164
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005180 RID: 20864 RVA: 0x000FAD71 File Offset: 0x000F9171
		public static UltimateChallengeDungeonTable GetRootAsUltimateChallengeDungeonTable(ByteBuffer _bb)
		{
			return UltimateChallengeDungeonTable.GetRootAsUltimateChallengeDungeonTable(_bb, new UltimateChallengeDungeonTable());
		}

		// Token: 0x06005181 RID: 20865 RVA: 0x000FAD7E File Offset: 0x000F917E
		public static UltimateChallengeDungeonTable GetRootAsUltimateChallengeDungeonTable(ByteBuffer _bb, UltimateChallengeDungeonTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005182 RID: 20866 RVA: 0x000FAD9A File Offset: 0x000F919A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005183 RID: 20867 RVA: 0x000FADB4 File Offset: 0x000F91B4
		public UltimateChallengeDungeonTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001680 RID: 5760
		// (get) Token: 0x06005184 RID: 20868 RVA: 0x000FADC0 File Offset: 0x000F91C0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1968689288 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001681 RID: 5761
		// (get) Token: 0x06005185 RID: 20869 RVA: 0x000FAE0C File Offset: 0x000F920C
		public int level
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1968689288 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001682 RID: 5762
		// (get) Token: 0x06005186 RID: 20870 RVA: 0x000FAE58 File Offset: 0x000F9258
		public int dungeonID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1968689288 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001683 RID: 5763
		// (get) Token: 0x06005187 RID: 20871 RVA: 0x000FAEA4 File Offset: 0x000F92A4
		public string randomBuff
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005188 RID: 20872 RVA: 0x000FAEE7 File Offset: 0x000F92E7
		public ArraySegment<byte>? GetRandomBuffBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001684 RID: 5764
		// (get) Token: 0x06005189 RID: 20873 RVA: 0x000FAEF8 File Offset: 0x000F92F8
		public int limitTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1968689288 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001685 RID: 5765
		// (get) Token: 0x0600518A RID: 20874 RVA: 0x000FAF44 File Offset: 0x000F9344
		public string expendItem
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600518B RID: 20875 RVA: 0x000FAF87 File Offset: 0x000F9387
		public ArraySegment<byte>? GetExpendItemBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17001686 RID: 5766
		// (get) Token: 0x0600518C RID: 20876 RVA: 0x000FAF98 File Offset: 0x000F9398
		public int hpRecover
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1968689288 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001687 RID: 5767
		// (get) Token: 0x0600518D RID: 20877 RVA: 0x000FAFE4 File Offset: 0x000F93E4
		public int mpRecover
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1968689288 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001688 RID: 5768
		// (get) Token: 0x0600518E RID: 20878 RVA: 0x000FB030 File Offset: 0x000F9430
		public int MaxhpRecover
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1968689288 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001689 RID: 5769
		// (get) Token: 0x0600518F RID: 20879 RVA: 0x000FB07C File Offset: 0x000F947C
		public int MaxmpRecover
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1968689288 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700168A RID: 5770
		// (get) Token: 0x06005190 RID: 20880 RVA: 0x000FB0C8 File Offset: 0x000F94C8
		public string courageBuff
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005191 RID: 20881 RVA: 0x000FB10B File Offset: 0x000F950B
		public ArraySegment<byte>? GetCourageBuffBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x1700168B RID: 5771
		// (get) Token: 0x06005192 RID: 20882 RVA: 0x000FB11C File Offset: 0x000F951C
		public int IsDifficulty
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1968689288 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700168C RID: 5772
		// (get) Token: 0x06005193 RID: 20883 RVA: 0x000FB168 File Offset: 0x000F9568
		public string RewardShow
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005194 RID: 20884 RVA: 0x000FB1AB File Offset: 0x000F95AB
		public ArraySegment<byte>? GetRewardShowBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x06005195 RID: 20885 RVA: 0x000FB1BC File Offset: 0x000F95BC
		public static Offset<UltimateChallengeDungeonTable> CreateUltimateChallengeDungeonTable(FlatBufferBuilder builder, int ID = 0, int level = 0, int dungeonID = 0, StringOffset randomBuffOffset = default(StringOffset), int limitTime = 0, StringOffset expendItemOffset = default(StringOffset), int hpRecover = 0, int mpRecover = 0, int MaxhpRecover = 0, int MaxmpRecover = 0, StringOffset courageBuffOffset = default(StringOffset), int IsDifficulty = 0, StringOffset RewardShowOffset = default(StringOffset))
		{
			builder.StartObject(13);
			UltimateChallengeDungeonTable.AddRewardShow(builder, RewardShowOffset);
			UltimateChallengeDungeonTable.AddIsDifficulty(builder, IsDifficulty);
			UltimateChallengeDungeonTable.AddCourageBuff(builder, courageBuffOffset);
			UltimateChallengeDungeonTable.AddMaxmpRecover(builder, MaxmpRecover);
			UltimateChallengeDungeonTable.AddMaxhpRecover(builder, MaxhpRecover);
			UltimateChallengeDungeonTable.AddMpRecover(builder, mpRecover);
			UltimateChallengeDungeonTable.AddHpRecover(builder, hpRecover);
			UltimateChallengeDungeonTable.AddExpendItem(builder, expendItemOffset);
			UltimateChallengeDungeonTable.AddLimitTime(builder, limitTime);
			UltimateChallengeDungeonTable.AddRandomBuff(builder, randomBuffOffset);
			UltimateChallengeDungeonTable.AddDungeonID(builder, dungeonID);
			UltimateChallengeDungeonTable.AddLevel(builder, level);
			UltimateChallengeDungeonTable.AddID(builder, ID);
			return UltimateChallengeDungeonTable.EndUltimateChallengeDungeonTable(builder);
		}

		// Token: 0x06005196 RID: 20886 RVA: 0x000FB23C File Offset: 0x000F963C
		public static void StartUltimateChallengeDungeonTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x06005197 RID: 20887 RVA: 0x000FB246 File Offset: 0x000F9646
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005198 RID: 20888 RVA: 0x000FB251 File Offset: 0x000F9651
		public static void AddLevel(FlatBufferBuilder builder, int level)
		{
			builder.AddInt(1, level, 0);
		}

		// Token: 0x06005199 RID: 20889 RVA: 0x000FB25C File Offset: 0x000F965C
		public static void AddDungeonID(FlatBufferBuilder builder, int dungeonID)
		{
			builder.AddInt(2, dungeonID, 0);
		}

		// Token: 0x0600519A RID: 20890 RVA: 0x000FB267 File Offset: 0x000F9667
		public static void AddRandomBuff(FlatBufferBuilder builder, StringOffset randomBuffOffset)
		{
			builder.AddOffset(3, randomBuffOffset.Value, 0);
		}

		// Token: 0x0600519B RID: 20891 RVA: 0x000FB278 File Offset: 0x000F9678
		public static void AddLimitTime(FlatBufferBuilder builder, int limitTime)
		{
			builder.AddInt(4, limitTime, 0);
		}

		// Token: 0x0600519C RID: 20892 RVA: 0x000FB283 File Offset: 0x000F9683
		public static void AddExpendItem(FlatBufferBuilder builder, StringOffset expendItemOffset)
		{
			builder.AddOffset(5, expendItemOffset.Value, 0);
		}

		// Token: 0x0600519D RID: 20893 RVA: 0x000FB294 File Offset: 0x000F9694
		public static void AddHpRecover(FlatBufferBuilder builder, int hpRecover)
		{
			builder.AddInt(6, hpRecover, 0);
		}

		// Token: 0x0600519E RID: 20894 RVA: 0x000FB29F File Offset: 0x000F969F
		public static void AddMpRecover(FlatBufferBuilder builder, int mpRecover)
		{
			builder.AddInt(7, mpRecover, 0);
		}

		// Token: 0x0600519F RID: 20895 RVA: 0x000FB2AA File Offset: 0x000F96AA
		public static void AddMaxhpRecover(FlatBufferBuilder builder, int MaxhpRecover)
		{
			builder.AddInt(8, MaxhpRecover, 0);
		}

		// Token: 0x060051A0 RID: 20896 RVA: 0x000FB2B5 File Offset: 0x000F96B5
		public static void AddMaxmpRecover(FlatBufferBuilder builder, int MaxmpRecover)
		{
			builder.AddInt(9, MaxmpRecover, 0);
		}

		// Token: 0x060051A1 RID: 20897 RVA: 0x000FB2C1 File Offset: 0x000F96C1
		public static void AddCourageBuff(FlatBufferBuilder builder, StringOffset courageBuffOffset)
		{
			builder.AddOffset(10, courageBuffOffset.Value, 0);
		}

		// Token: 0x060051A2 RID: 20898 RVA: 0x000FB2D3 File Offset: 0x000F96D3
		public static void AddIsDifficulty(FlatBufferBuilder builder, int IsDifficulty)
		{
			builder.AddInt(11, IsDifficulty, 0);
		}

		// Token: 0x060051A3 RID: 20899 RVA: 0x000FB2DF File Offset: 0x000F96DF
		public static void AddRewardShow(FlatBufferBuilder builder, StringOffset RewardShowOffset)
		{
			builder.AddOffset(12, RewardShowOffset.Value, 0);
		}

		// Token: 0x060051A4 RID: 20900 RVA: 0x000FB2F4 File Offset: 0x000F96F4
		public static Offset<UltimateChallengeDungeonTable> EndUltimateChallengeDungeonTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<UltimateChallengeDungeonTable>(value);
		}

		// Token: 0x060051A5 RID: 20901 RVA: 0x000FB30E File Offset: 0x000F970E
		public static void FinishUltimateChallengeDungeonTableBuffer(FlatBufferBuilder builder, Offset<UltimateChallengeDungeonTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E15 RID: 7701
		private Table __p = new Table();

		// Token: 0x02000609 RID: 1545
		public enum eCrypt
		{
			// Token: 0x04001E17 RID: 7703
			code = 1968689288
		}
	}
}
