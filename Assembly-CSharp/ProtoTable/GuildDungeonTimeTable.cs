using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000473 RID: 1139
	public class GuildDungeonTimeTable : IFlatbufferObject
	{
		// Token: 0x17000DCB RID: 3531
		// (get) Token: 0x0600370D RID: 14093 RVA: 0x000BCE8C File Offset: 0x000BB28C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600370E RID: 14094 RVA: 0x000BCE99 File Offset: 0x000BB299
		public static GuildDungeonTimeTable GetRootAsGuildDungeonTimeTable(ByteBuffer _bb)
		{
			return GuildDungeonTimeTable.GetRootAsGuildDungeonTimeTable(_bb, new GuildDungeonTimeTable());
		}

		// Token: 0x0600370F RID: 14095 RVA: 0x000BCEA6 File Offset: 0x000BB2A6
		public static GuildDungeonTimeTable GetRootAsGuildDungeonTimeTable(ByteBuffer _bb, GuildDungeonTimeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003710 RID: 14096 RVA: 0x000BCEC2 File Offset: 0x000BB2C2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003711 RID: 14097 RVA: 0x000BCEDC File Offset: 0x000BB2DC
		public GuildDungeonTimeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000DCC RID: 3532
		// (get) Token: 0x06003712 RID: 14098 RVA: 0x000BCEE8 File Offset: 0x000BB2E8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-64003044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DCD RID: 3533
		// (get) Token: 0x06003713 RID: 14099 RVA: 0x000BCF34 File Offset: 0x000BB334
		public int Week
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-64003044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DCE RID: 3534
		// (get) Token: 0x06003714 RID: 14100 RVA: 0x000BCF80 File Offset: 0x000BB380
		public int Status
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-64003044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DCF RID: 3535
		// (get) Token: 0x06003715 RID: 14101 RVA: 0x000BCFCC File Offset: 0x000BB3CC
		public string Time
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003716 RID: 14102 RVA: 0x000BD00F File Offset: 0x000BB40F
		public ArraySegment<byte>? GetTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000DD0 RID: 3536
		// (get) Token: 0x06003717 RID: 14103 RVA: 0x000BD020 File Offset: 0x000BB420
		public int isOpen
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-64003044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003718 RID: 14104 RVA: 0x000BD06A File Offset: 0x000BB46A
		public static Offset<GuildDungeonTimeTable> CreateGuildDungeonTimeTable(FlatBufferBuilder builder, int ID = 0, int Week = 0, int Status = 0, StringOffset TimeOffset = default(StringOffset), int isOpen = 0)
		{
			builder.StartObject(5);
			GuildDungeonTimeTable.AddIsOpen(builder, isOpen);
			GuildDungeonTimeTable.AddTime(builder, TimeOffset);
			GuildDungeonTimeTable.AddStatus(builder, Status);
			GuildDungeonTimeTable.AddWeek(builder, Week);
			GuildDungeonTimeTable.AddID(builder, ID);
			return GuildDungeonTimeTable.EndGuildDungeonTimeTable(builder);
		}

		// Token: 0x06003719 RID: 14105 RVA: 0x000BD09E File Offset: 0x000BB49E
		public static void StartGuildDungeonTimeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0600371A RID: 14106 RVA: 0x000BD0A7 File Offset: 0x000BB4A7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600371B RID: 14107 RVA: 0x000BD0B2 File Offset: 0x000BB4B2
		public static void AddWeek(FlatBufferBuilder builder, int Week)
		{
			builder.AddInt(1, Week, 0);
		}

		// Token: 0x0600371C RID: 14108 RVA: 0x000BD0BD File Offset: 0x000BB4BD
		public static void AddStatus(FlatBufferBuilder builder, int Status)
		{
			builder.AddInt(2, Status, 0);
		}

		// Token: 0x0600371D RID: 14109 RVA: 0x000BD0C8 File Offset: 0x000BB4C8
		public static void AddTime(FlatBufferBuilder builder, StringOffset TimeOffset)
		{
			builder.AddOffset(3, TimeOffset.Value, 0);
		}

		// Token: 0x0600371E RID: 14110 RVA: 0x000BD0D9 File Offset: 0x000BB4D9
		public static void AddIsOpen(FlatBufferBuilder builder, int isOpen)
		{
			builder.AddInt(4, isOpen, 0);
		}

		// Token: 0x0600371F RID: 14111 RVA: 0x000BD0E4 File Offset: 0x000BB4E4
		public static Offset<GuildDungeonTimeTable> EndGuildDungeonTimeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildDungeonTimeTable>(value);
		}

		// Token: 0x06003720 RID: 14112 RVA: 0x000BD0FE File Offset: 0x000BB4FE
		public static void FinishGuildDungeonTimeTableBuffer(FlatBufferBuilder builder, Offset<GuildDungeonTimeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015CB RID: 5579
		private Table __p = new Table();

		// Token: 0x02000474 RID: 1140
		public enum eCrypt
		{
			// Token: 0x040015CD RID: 5581
			code = -64003044
		}
	}
}
