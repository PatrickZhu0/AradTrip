using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003C5 RID: 965
	public class EquChangeConsumeTable : IFlatbufferObject
	{
		// Token: 0x17000A1B RID: 2587
		// (get) Token: 0x06002B6E RID: 11118 RVA: 0x000A1A00 File Offset: 0x0009FE00
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002B6F RID: 11119 RVA: 0x000A1A0D File Offset: 0x0009FE0D
		public static EquChangeConsumeTable GetRootAsEquChangeConsumeTable(ByteBuffer _bb)
		{
			return EquChangeConsumeTable.GetRootAsEquChangeConsumeTable(_bb, new EquChangeConsumeTable());
		}

		// Token: 0x06002B70 RID: 11120 RVA: 0x000A1A1A File Offset: 0x0009FE1A
		public static EquChangeConsumeTable GetRootAsEquChangeConsumeTable(ByteBuffer _bb, EquChangeConsumeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002B71 RID: 11121 RVA: 0x000A1A36 File Offset: 0x0009FE36
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002B72 RID: 11122 RVA: 0x000A1A50 File Offset: 0x0009FE50
		public EquChangeConsumeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A1C RID: 2588
		// (get) Token: 0x06002B73 RID: 11123 RVA: 0x000A1A5C File Offset: 0x0009FE5C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1644211627 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A1D RID: 2589
		// (get) Token: 0x06002B74 RID: 11124 RVA: 0x000A1AA8 File Offset: 0x0009FEA8
		public int ConvertType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1644211627 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A1E RID: 2590
		// (get) Token: 0x06002B75 RID: 11125 RVA: 0x000A1AF4 File Offset: 0x0009FEF4
		public EquChangeConsumeTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (EquChangeConsumeTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A1F RID: 2591
		// (get) Token: 0x06002B76 RID: 11126 RVA: 0x000A1B38 File Offset: 0x0009FF38
		public int Level
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1644211627 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A20 RID: 2592
		// (get) Token: 0x06002B77 RID: 11127 RVA: 0x000A1B84 File Offset: 0x0009FF84
		public EquChangeConsumeTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(12);
				return (EquChangeConsumeTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A21 RID: 2593
		// (get) Token: 0x06002B78 RID: 11128 RVA: 0x000A1BC8 File Offset: 0x0009FFC8
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1644211627 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002B79 RID: 11129 RVA: 0x000A1C14 File Offset: 0x000A0014
		public string ItemConsumeArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000A22 RID: 2594
		// (get) Token: 0x06002B7A RID: 11130 RVA: 0x000A1C5C File Offset: 0x000A005C
		public int ItemConsumeLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000A23 RID: 2595
		// (get) Token: 0x06002B7B RID: 11131 RVA: 0x000A1C8F File Offset: 0x000A008F
		public FlatBufferArray<string> ItemConsume
		{
			get
			{
				if (this.ItemConsumeValue == null)
				{
					this.ItemConsumeValue = new FlatBufferArray<string>(new Func<int, string>(this.ItemConsumeArray), this.ItemConsumeLength);
				}
				return this.ItemConsumeValue;
			}
		}

		// Token: 0x17000A24 RID: 2596
		// (get) Token: 0x06002B7C RID: 11132 RVA: 0x000A1CC0 File Offset: 0x000A00C0
		public string ConverterConsume
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002B7D RID: 11133 RVA: 0x000A1D03 File Offset: 0x000A0103
		public ArraySegment<byte>? GetConverterConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x06002B7E RID: 11134 RVA: 0x000A1D14 File Offset: 0x000A0114
		public static Offset<EquChangeConsumeTable> CreateEquChangeConsumeTable(FlatBufferBuilder builder, int ID = 0, int ConvertType = 0, EquChangeConsumeTable.eSubType SubType = EquChangeConsumeTable.eSubType.ST_NONE, int Level = 0, EquChangeConsumeTable.eColor Color = EquChangeConsumeTable.eColor.CL_NONE, int Color2 = 0, VectorOffset ItemConsumeOffset = default(VectorOffset), StringOffset ConverterConsumeOffset = default(StringOffset))
		{
			builder.StartObject(8);
			EquChangeConsumeTable.AddConverterConsume(builder, ConverterConsumeOffset);
			EquChangeConsumeTable.AddItemConsume(builder, ItemConsumeOffset);
			EquChangeConsumeTable.AddColor2(builder, Color2);
			EquChangeConsumeTable.AddColor(builder, Color);
			EquChangeConsumeTable.AddLevel(builder, Level);
			EquChangeConsumeTable.AddSubType(builder, SubType);
			EquChangeConsumeTable.AddConvertType(builder, ConvertType);
			EquChangeConsumeTable.AddID(builder, ID);
			return EquChangeConsumeTable.EndEquChangeConsumeTable(builder);
		}

		// Token: 0x06002B7F RID: 11135 RVA: 0x000A1D6B File Offset: 0x000A016B
		public static void StartEquChangeConsumeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06002B80 RID: 11136 RVA: 0x000A1D74 File Offset: 0x000A0174
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002B81 RID: 11137 RVA: 0x000A1D7F File Offset: 0x000A017F
		public static void AddConvertType(FlatBufferBuilder builder, int ConvertType)
		{
			builder.AddInt(1, ConvertType, 0);
		}

		// Token: 0x06002B82 RID: 11138 RVA: 0x000A1D8A File Offset: 0x000A018A
		public static void AddSubType(FlatBufferBuilder builder, EquChangeConsumeTable.eSubType SubType)
		{
			builder.AddInt(2, (int)SubType, 0);
		}

		// Token: 0x06002B83 RID: 11139 RVA: 0x000A1D95 File Offset: 0x000A0195
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(3, Level, 0);
		}

		// Token: 0x06002B84 RID: 11140 RVA: 0x000A1DA0 File Offset: 0x000A01A0
		public static void AddColor(FlatBufferBuilder builder, EquChangeConsumeTable.eColor Color)
		{
			builder.AddInt(4, (int)Color, 0);
		}

		// Token: 0x06002B85 RID: 11141 RVA: 0x000A1DAB File Offset: 0x000A01AB
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(5, Color2, 0);
		}

		// Token: 0x06002B86 RID: 11142 RVA: 0x000A1DB6 File Offset: 0x000A01B6
		public static void AddItemConsume(FlatBufferBuilder builder, VectorOffset ItemConsumeOffset)
		{
			builder.AddOffset(6, ItemConsumeOffset.Value, 0);
		}

		// Token: 0x06002B87 RID: 11143 RVA: 0x000A1DC8 File Offset: 0x000A01C8
		public static VectorOffset CreateItemConsumeVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B88 RID: 11144 RVA: 0x000A1E0E File Offset: 0x000A020E
		public static void StartItemConsumeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B89 RID: 11145 RVA: 0x000A1E19 File Offset: 0x000A0219
		public static void AddConverterConsume(FlatBufferBuilder builder, StringOffset ConverterConsumeOffset)
		{
			builder.AddOffset(7, ConverterConsumeOffset.Value, 0);
		}

		// Token: 0x06002B8A RID: 11146 RVA: 0x000A1E2C File Offset: 0x000A022C
		public static Offset<EquChangeConsumeTable> EndEquChangeConsumeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquChangeConsumeTable>(value);
		}

		// Token: 0x06002B8B RID: 11147 RVA: 0x000A1E46 File Offset: 0x000A0246
		public static void FinishEquChangeConsumeTableBuffer(FlatBufferBuilder builder, Offset<EquChangeConsumeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400128A RID: 4746
		private Table __p = new Table();

		// Token: 0x0400128B RID: 4747
		private FlatBufferArray<string> ItemConsumeValue;

		// Token: 0x020003C6 RID: 966
		public enum eSubType
		{
			// Token: 0x0400128D RID: 4749
			ST_NONE,
			// Token: 0x0400128E RID: 4750
			WEAPON,
			// Token: 0x0400128F RID: 4751
			HEAD,
			// Token: 0x04001290 RID: 4752
			CHEST,
			// Token: 0x04001291 RID: 4753
			BELT,
			// Token: 0x04001292 RID: 4754
			LEG,
			// Token: 0x04001293 RID: 4755
			BOOT,
			// Token: 0x04001294 RID: 4756
			RING,
			// Token: 0x04001295 RID: 4757
			NECKLASE,
			// Token: 0x04001296 RID: 4758
			BRACELET,
			// Token: 0x04001297 RID: 4759
			TITLE
		}

		// Token: 0x020003C7 RID: 967
		public enum eColor
		{
			// Token: 0x04001299 RID: 4761
			CL_NONE,
			// Token: 0x0400129A RID: 4762
			WHITE,
			// Token: 0x0400129B RID: 4763
			BLUE,
			// Token: 0x0400129C RID: 4764
			PURPLE,
			// Token: 0x0400129D RID: 4765
			GREEN,
			// Token: 0x0400129E RID: 4766
			PINK,
			// Token: 0x0400129F RID: 4767
			YELLOW
		}

		// Token: 0x020003C8 RID: 968
		public enum eCrypt
		{
			// Token: 0x040012A1 RID: 4769
			code = -1644211627
		}
	}
}
