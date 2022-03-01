using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000293 RID: 659
	public class AdventurePassSeasonTable : IFlatbufferObject
	{
		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06001772 RID: 6002 RVA: 0x00071894 File Offset: 0x0006FC94
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x000718A1 File Offset: 0x0006FCA1
		public static AdventurePassSeasonTable GetRootAsAdventurePassSeasonTable(ByteBuffer _bb)
		{
			return AdventurePassSeasonTable.GetRootAsAdventurePassSeasonTable(_bb, new AdventurePassSeasonTable());
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x000718AE File Offset: 0x0006FCAE
		public static AdventurePassSeasonTable GetRootAsAdventurePassSeasonTable(ByteBuffer _bb, AdventurePassSeasonTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001775 RID: 6005 RVA: 0x000718CA File Offset: 0x0006FCCA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x000718E4 File Offset: 0x0006FCE4
		public AdventurePassSeasonTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06001777 RID: 6007 RVA: 0x000718F0 File Offset: 0x0006FCF0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-379814892 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06001778 RID: 6008 RVA: 0x0007193C File Offset: 0x0006FD3C
		public string StartTime
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001779 RID: 6009 RVA: 0x0007197E File Offset: 0x0006FD7E
		public ArraySegment<byte>? GetStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x0600177A RID: 6010 RVA: 0x0007198C File Offset: 0x0006FD8C
		public string EndTime
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x000719CE File Offset: 0x0006FDCE
		public ArraySegment<byte>? GetEndTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x0600177C RID: 6012 RVA: 0x000719DC File Offset: 0x0006FDDC
		public int MaxLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-379814892 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x00071A26 File Offset: 0x0006FE26
		public static Offset<AdventurePassSeasonTable> CreateAdventurePassSeasonTable(FlatBufferBuilder builder, int ID = 0, StringOffset StartTimeOffset = default(StringOffset), StringOffset EndTimeOffset = default(StringOffset), int MaxLevel = 0)
		{
			builder.StartObject(4);
			AdventurePassSeasonTable.AddMaxLevel(builder, MaxLevel);
			AdventurePassSeasonTable.AddEndTime(builder, EndTimeOffset);
			AdventurePassSeasonTable.AddStartTime(builder, StartTimeOffset);
			AdventurePassSeasonTable.AddID(builder, ID);
			return AdventurePassSeasonTable.EndAdventurePassSeasonTable(builder);
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x00071A52 File Offset: 0x0006FE52
		public static void StartAdventurePassSeasonTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0600177F RID: 6015 RVA: 0x00071A5B File Offset: 0x0006FE5B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x00071A66 File Offset: 0x0006FE66
		public static void AddStartTime(FlatBufferBuilder builder, StringOffset StartTimeOffset)
		{
			builder.AddOffset(1, StartTimeOffset.Value, 0);
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x00071A77 File Offset: 0x0006FE77
		public static void AddEndTime(FlatBufferBuilder builder, StringOffset EndTimeOffset)
		{
			builder.AddOffset(2, EndTimeOffset.Value, 0);
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x00071A88 File Offset: 0x0006FE88
		public static void AddMaxLevel(FlatBufferBuilder builder, int MaxLevel)
		{
			builder.AddInt(3, MaxLevel, 0);
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x00071A94 File Offset: 0x0006FE94
		public static Offset<AdventurePassSeasonTable> EndAdventurePassSeasonTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AdventurePassSeasonTable>(value);
		}

		// Token: 0x06001784 RID: 6020 RVA: 0x00071AAE File Offset: 0x0006FEAE
		public static void FinishAdventurePassSeasonTableBuffer(FlatBufferBuilder builder, Offset<AdventurePassSeasonTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DCE RID: 3534
		private Table __p = new Table();

		// Token: 0x02000294 RID: 660
		public enum eCrypt
		{
			// Token: 0x04000DD0 RID: 3536
			code = -379814892
		}
	}
}
