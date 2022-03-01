using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000461 RID: 1121
	public class GuildBattleTimeTable : IFlatbufferObject
	{
		// Token: 0x17000D73 RID: 3443
		// (get) Token: 0x060035F0 RID: 13808 RVA: 0x000BA614 File Offset: 0x000B8A14
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060035F1 RID: 13809 RVA: 0x000BA621 File Offset: 0x000B8A21
		public static GuildBattleTimeTable GetRootAsGuildBattleTimeTable(ByteBuffer _bb)
		{
			return GuildBattleTimeTable.GetRootAsGuildBattleTimeTable(_bb, new GuildBattleTimeTable());
		}

		// Token: 0x060035F2 RID: 13810 RVA: 0x000BA62E File Offset: 0x000B8A2E
		public static GuildBattleTimeTable GetRootAsGuildBattleTimeTable(ByteBuffer _bb, GuildBattleTimeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060035F3 RID: 13811 RVA: 0x000BA64A File Offset: 0x000B8A4A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060035F4 RID: 13812 RVA: 0x000BA664 File Offset: 0x000B8A64
		public GuildBattleTimeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D74 RID: 3444
		// (get) Token: 0x060035F5 RID: 13813 RVA: 0x000BA670 File Offset: 0x000B8A70
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (287298126 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D75 RID: 3445
		// (get) Token: 0x060035F6 RID: 13814 RVA: 0x000BA6BC File Offset: 0x000B8ABC
		public int Group
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (287298126 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D76 RID: 3446
		// (get) Token: 0x060035F7 RID: 13815 RVA: 0x000BA708 File Offset: 0x000B8B08
		public GuildBattleTimeTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (GuildBattleTimeTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D77 RID: 3447
		// (get) Token: 0x060035F8 RID: 13816 RVA: 0x000BA74C File Offset: 0x000B8B4C
		public GuildBattleTimeTable.eStatus Status
		{
			get
			{
				int num = this.__p.__offset(10);
				return (GuildBattleTimeTable.eStatus)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D78 RID: 3448
		// (get) Token: 0x060035F9 RID: 13817 RVA: 0x000BA790 File Offset: 0x000B8B90
		public int Week
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (287298126 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D79 RID: 3449
		// (get) Token: 0x060035FA RID: 13818 RVA: 0x000BA7DC File Offset: 0x000B8BDC
		public string Time
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060035FB RID: 13819 RVA: 0x000BA81F File Offset: 0x000B8C1F
		public ArraySegment<byte>? GetTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000D7A RID: 3450
		// (get) Token: 0x060035FC RID: 13820 RVA: 0x000BA830 File Offset: 0x000B8C30
		public int IsOpen
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (287298126 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060035FD RID: 13821 RVA: 0x000BA87C File Offset: 0x000B8C7C
		public static Offset<GuildBattleTimeTable> CreateGuildBattleTimeTable(FlatBufferBuilder builder, int ID = 0, int Group = 0, GuildBattleTimeTable.eType Type = GuildBattleTimeTable.eType.GBT_INVALID, GuildBattleTimeTable.eStatus Status = GuildBattleTimeTable.eStatus.GBS_INVALID, int Week = 0, StringOffset TimeOffset = default(StringOffset), int IsOpen = 0)
		{
			builder.StartObject(7);
			GuildBattleTimeTable.AddIsOpen(builder, IsOpen);
			GuildBattleTimeTable.AddTime(builder, TimeOffset);
			GuildBattleTimeTable.AddWeek(builder, Week);
			GuildBattleTimeTable.AddStatus(builder, Status);
			GuildBattleTimeTable.AddType(builder, Type);
			GuildBattleTimeTable.AddGroup(builder, Group);
			GuildBattleTimeTable.AddID(builder, ID);
			return GuildBattleTimeTable.EndGuildBattleTimeTable(builder);
		}

		// Token: 0x060035FE RID: 13822 RVA: 0x000BA8CB File Offset: 0x000B8CCB
		public static void StartGuildBattleTimeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x060035FF RID: 13823 RVA: 0x000BA8D4 File Offset: 0x000B8CD4
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003600 RID: 13824 RVA: 0x000BA8DF File Offset: 0x000B8CDF
		public static void AddGroup(FlatBufferBuilder builder, int Group)
		{
			builder.AddInt(1, Group, 0);
		}

		// Token: 0x06003601 RID: 13825 RVA: 0x000BA8EA File Offset: 0x000B8CEA
		public static void AddType(FlatBufferBuilder builder, GuildBattleTimeTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06003602 RID: 13826 RVA: 0x000BA8F5 File Offset: 0x000B8CF5
		public static void AddStatus(FlatBufferBuilder builder, GuildBattleTimeTable.eStatus Status)
		{
			builder.AddInt(3, (int)Status, 0);
		}

		// Token: 0x06003603 RID: 13827 RVA: 0x000BA900 File Offset: 0x000B8D00
		public static void AddWeek(FlatBufferBuilder builder, int Week)
		{
			builder.AddInt(4, Week, 0);
		}

		// Token: 0x06003604 RID: 13828 RVA: 0x000BA90B File Offset: 0x000B8D0B
		public static void AddTime(FlatBufferBuilder builder, StringOffset TimeOffset)
		{
			builder.AddOffset(5, TimeOffset.Value, 0);
		}

		// Token: 0x06003605 RID: 13829 RVA: 0x000BA91C File Offset: 0x000B8D1C
		public static void AddIsOpen(FlatBufferBuilder builder, int IsOpen)
		{
			builder.AddInt(6, IsOpen, 0);
		}

		// Token: 0x06003606 RID: 13830 RVA: 0x000BA928 File Offset: 0x000B8D28
		public static Offset<GuildBattleTimeTable> EndGuildBattleTimeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildBattleTimeTable>(value);
		}

		// Token: 0x06003607 RID: 13831 RVA: 0x000BA942 File Offset: 0x000B8D42
		public static void FinishGuildBattleTimeTableBuffer(FlatBufferBuilder builder, Offset<GuildBattleTimeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400159D RID: 5533
		private Table __p = new Table();

		// Token: 0x02000462 RID: 1122
		public enum eType
		{
			// Token: 0x0400159F RID: 5535
			GBT_INVALID,
			// Token: 0x040015A0 RID: 5536
			GBT_NORMAL,
			// Token: 0x040015A1 RID: 5537
			GBT_CHALLENGE,
			// Token: 0x040015A2 RID: 5538
			GBT_CROSS
		}

		// Token: 0x02000463 RID: 1123
		public enum eStatus
		{
			// Token: 0x040015A4 RID: 5540
			GBS_INVALID,
			// Token: 0x040015A5 RID: 5541
			GBS_ENROLL,
			// Token: 0x040015A6 RID: 5542
			GBS_PREPARE,
			// Token: 0x040015A7 RID: 5543
			GBS_BATTLE,
			// Token: 0x040015A8 RID: 5544
			GBS_REWARD
		}

		// Token: 0x02000464 RID: 1124
		public enum eCrypt
		{
			// Token: 0x040015AA RID: 5546
			code = 287298126
		}
	}
}
