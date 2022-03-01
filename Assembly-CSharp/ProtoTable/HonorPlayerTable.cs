using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000494 RID: 1172
	public class HonorPlayerTable : IFlatbufferObject
	{
		// Token: 0x17000E73 RID: 3699
		// (get) Token: 0x06003922 RID: 14626 RVA: 0x000C1BF0 File Offset: 0x000BFFF0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003923 RID: 14627 RVA: 0x000C1BFD File Offset: 0x000BFFFD
		public static HonorPlayerTable GetRootAsHonorPlayerTable(ByteBuffer _bb)
		{
			return HonorPlayerTable.GetRootAsHonorPlayerTable(_bb, new HonorPlayerTable());
		}

		// Token: 0x06003924 RID: 14628 RVA: 0x000C1C0A File Offset: 0x000C000A
		public static HonorPlayerTable GetRootAsHonorPlayerTable(ByteBuffer _bb, HonorPlayerTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003925 RID: 14629 RVA: 0x000C1C26 File Offset: 0x000C0026
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003926 RID: 14630 RVA: 0x000C1C40 File Offset: 0x000C0040
		public HonorPlayerTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E74 RID: 3700
		// (get) Token: 0x06003927 RID: 14631 RVA: 0x000C1C4C File Offset: 0x000C004C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1904858675 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E75 RID: 3701
		// (get) Token: 0x06003928 RID: 14632 RVA: 0x000C1C98 File Offset: 0x000C0098
		public string name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003929 RID: 14633 RVA: 0x000C1CDA File Offset: 0x000C00DA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000E76 RID: 3702
		// (get) Token: 0x0600392A RID: 14634 RVA: 0x000C1CE8 File Offset: 0x000C00E8
		public string HornorPlayIcon
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600392B RID: 14635 RVA: 0x000C1D2A File Offset: 0x000C012A
		public ArraySegment<byte>? GetHornorPlayIconBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000E77 RID: 3703
		// (get) Token: 0x0600392C RID: 14636 RVA: 0x000C1D38 File Offset: 0x000C0138
		public int Sort
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1904858675 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E78 RID: 3704
		// (get) Token: 0x0600392D RID: 14637 RVA: 0x000C1D84 File Offset: 0x000C0184
		public string OpenWeekDay
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600392E RID: 14638 RVA: 0x000C1DC7 File Offset: 0x000C01C7
		public ArraySegment<byte>? GetOpenWeekDayBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x0600392F RID: 14639 RVA: 0x000C1DD6 File Offset: 0x000C01D6
		public static Offset<HonorPlayerTable> CreateHonorPlayerTable(FlatBufferBuilder builder, int ID = 0, StringOffset nameOffset = default(StringOffset), StringOffset HornorPlayIconOffset = default(StringOffset), int Sort = 0, StringOffset OpenWeekDayOffset = default(StringOffset))
		{
			builder.StartObject(5);
			HonorPlayerTable.AddOpenWeekDay(builder, OpenWeekDayOffset);
			HonorPlayerTable.AddSort(builder, Sort);
			HonorPlayerTable.AddHornorPlayIcon(builder, HornorPlayIconOffset);
			HonorPlayerTable.AddName(builder, nameOffset);
			HonorPlayerTable.AddID(builder, ID);
			return HonorPlayerTable.EndHonorPlayerTable(builder);
		}

		// Token: 0x06003930 RID: 14640 RVA: 0x000C1E0A File Offset: 0x000C020A
		public static void StartHonorPlayerTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06003931 RID: 14641 RVA: 0x000C1E13 File Offset: 0x000C0213
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003932 RID: 14642 RVA: 0x000C1E1E File Offset: 0x000C021E
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(1, nameOffset.Value, 0);
		}

		// Token: 0x06003933 RID: 14643 RVA: 0x000C1E2F File Offset: 0x000C022F
		public static void AddHornorPlayIcon(FlatBufferBuilder builder, StringOffset HornorPlayIconOffset)
		{
			builder.AddOffset(2, HornorPlayIconOffset.Value, 0);
		}

		// Token: 0x06003934 RID: 14644 RVA: 0x000C1E40 File Offset: 0x000C0240
		public static void AddSort(FlatBufferBuilder builder, int Sort)
		{
			builder.AddInt(3, Sort, 0);
		}

		// Token: 0x06003935 RID: 14645 RVA: 0x000C1E4B File Offset: 0x000C024B
		public static void AddOpenWeekDay(FlatBufferBuilder builder, StringOffset OpenWeekDayOffset)
		{
			builder.AddOffset(4, OpenWeekDayOffset.Value, 0);
		}

		// Token: 0x06003936 RID: 14646 RVA: 0x000C1E5C File Offset: 0x000C025C
		public static Offset<HonorPlayerTable> EndHonorPlayerTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<HonorPlayerTable>(value);
		}

		// Token: 0x06003937 RID: 14647 RVA: 0x000C1E76 File Offset: 0x000C0276
		public static void FinishHonorPlayerTableBuffer(FlatBufferBuilder builder, Offset<HonorPlayerTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400161C RID: 5660
		private Table __p = new Table();

		// Token: 0x02000495 RID: 1173
		public enum eCrypt
		{
			// Token: 0x0400161E RID: 5662
			code = -1904858675
		}
	}
}
