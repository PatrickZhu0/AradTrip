using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002D0 RID: 720
	public class BeadRandomBuff : IFlatbufferObject
	{
		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x060019C7 RID: 6599 RVA: 0x000765C4 File Offset: 0x000749C4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x000765D1 File Offset: 0x000749D1
		public static BeadRandomBuff GetRootAsBeadRandomBuff(ByteBuffer _bb)
		{
			return BeadRandomBuff.GetRootAsBeadRandomBuff(_bb, new BeadRandomBuff());
		}

		// Token: 0x060019C9 RID: 6601 RVA: 0x000765DE File Offset: 0x000749DE
		public static BeadRandomBuff GetRootAsBeadRandomBuff(ByteBuffer _bb, BeadRandomBuff obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060019CA RID: 6602 RVA: 0x000765FA File Offset: 0x000749FA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x00076614 File Offset: 0x00074A14
		public BeadRandomBuff __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x060019CC RID: 6604 RVA: 0x00076620 File Offset: 0x00074A20
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-803912890 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x060019CD RID: 6605 RVA: 0x0007666C File Offset: 0x00074A6C
		public int BuffGroup
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-803912890 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x060019CE RID: 6606 RVA: 0x000766B8 File Offset: 0x00074AB8
		public int WeightedValue
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-803912890 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x060019CF RID: 6607 RVA: 0x00076704 File Offset: 0x00074B04
		public int BuffinfoID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-803912890 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x060019D0 RID: 6608 RVA: 0x00076750 File Offset: 0x00074B50
		public int BuffExplain
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-803912890 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060019D1 RID: 6609 RVA: 0x0007679C File Offset: 0x00074B9C
		public int PropTypeArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-803912890 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x060019D2 RID: 6610 RVA: 0x000767EC File Offset: 0x00074BEC
		public int PropTypeLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060019D3 RID: 6611 RVA: 0x0007681F File Offset: 0x00074C1F
		public ArraySegment<byte>? GetPropTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x060019D4 RID: 6612 RVA: 0x0007682E File Offset: 0x00074C2E
		public FlatBufferArray<int> PropType
		{
			get
			{
				if (this.PropTypeValue == null)
				{
					this.PropTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.PropTypeArray), this.PropTypeLength);
				}
				return this.PropTypeValue;
			}
		}

		// Token: 0x060019D5 RID: 6613 RVA: 0x00076860 File Offset: 0x00074C60
		public int PropValueArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-803912890 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x060019D6 RID: 6614 RVA: 0x000768B0 File Offset: 0x00074CB0
		public int PropValueLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060019D7 RID: 6615 RVA: 0x000768E3 File Offset: 0x00074CE3
		public ArraySegment<byte>? GetPropValueBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x060019D8 RID: 6616 RVA: 0x000768F2 File Offset: 0x00074CF2
		public FlatBufferArray<int> PropValue
		{
			get
			{
				if (this.PropValueValue == null)
				{
					this.PropValueValue = new FlatBufferArray<int>(new Func<int, int>(this.PropValueArray), this.PropValueLength);
				}
				return this.PropValueValue;
			}
		}

		// Token: 0x060019D9 RID: 6617 RVA: 0x00076924 File Offset: 0x00074D24
		public static Offset<BeadRandomBuff> CreateBeadRandomBuff(FlatBufferBuilder builder, int ID = 0, int BuffGroup = 0, int WeightedValue = 0, int BuffinfoID = 0, int BuffExplain = 0, VectorOffset PropTypeOffset = default(VectorOffset), VectorOffset PropValueOffset = default(VectorOffset))
		{
			builder.StartObject(7);
			BeadRandomBuff.AddPropValue(builder, PropValueOffset);
			BeadRandomBuff.AddPropType(builder, PropTypeOffset);
			BeadRandomBuff.AddBuffExplain(builder, BuffExplain);
			BeadRandomBuff.AddBuffinfoID(builder, BuffinfoID);
			BeadRandomBuff.AddWeightedValue(builder, WeightedValue);
			BeadRandomBuff.AddBuffGroup(builder, BuffGroup);
			BeadRandomBuff.AddID(builder, ID);
			return BeadRandomBuff.EndBeadRandomBuff(builder);
		}

		// Token: 0x060019DA RID: 6618 RVA: 0x00076973 File Offset: 0x00074D73
		public static void StartBeadRandomBuff(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x060019DB RID: 6619 RVA: 0x0007697C File Offset: 0x00074D7C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060019DC RID: 6620 RVA: 0x00076987 File Offset: 0x00074D87
		public static void AddBuffGroup(FlatBufferBuilder builder, int BuffGroup)
		{
			builder.AddInt(1, BuffGroup, 0);
		}

		// Token: 0x060019DD RID: 6621 RVA: 0x00076992 File Offset: 0x00074D92
		public static void AddWeightedValue(FlatBufferBuilder builder, int WeightedValue)
		{
			builder.AddInt(2, WeightedValue, 0);
		}

		// Token: 0x060019DE RID: 6622 RVA: 0x0007699D File Offset: 0x00074D9D
		public static void AddBuffinfoID(FlatBufferBuilder builder, int BuffinfoID)
		{
			builder.AddInt(3, BuffinfoID, 0);
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x000769A8 File Offset: 0x00074DA8
		public static void AddBuffExplain(FlatBufferBuilder builder, int BuffExplain)
		{
			builder.AddInt(4, BuffExplain, 0);
		}

		// Token: 0x060019E0 RID: 6624 RVA: 0x000769B3 File Offset: 0x00074DB3
		public static void AddPropType(FlatBufferBuilder builder, VectorOffset PropTypeOffset)
		{
			builder.AddOffset(5, PropTypeOffset.Value, 0);
		}

		// Token: 0x060019E1 RID: 6625 RVA: 0x000769C4 File Offset: 0x00074DC4
		public static VectorOffset CreatePropTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060019E2 RID: 6626 RVA: 0x00076A01 File Offset: 0x00074E01
		public static void StartPropTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x00076A0C File Offset: 0x00074E0C
		public static void AddPropValue(FlatBufferBuilder builder, VectorOffset PropValueOffset)
		{
			builder.AddOffset(6, PropValueOffset.Value, 0);
		}

		// Token: 0x060019E4 RID: 6628 RVA: 0x00076A20 File Offset: 0x00074E20
		public static VectorOffset CreatePropValueVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060019E5 RID: 6629 RVA: 0x00076A5D File Offset: 0x00074E5D
		public static void StartPropValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060019E6 RID: 6630 RVA: 0x00076A68 File Offset: 0x00074E68
		public static Offset<BeadRandomBuff> EndBeadRandomBuff(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BeadRandomBuff>(value);
		}

		// Token: 0x060019E7 RID: 6631 RVA: 0x00076A82 File Offset: 0x00074E82
		public static void FinishBeadRandomBuffBuffer(FlatBufferBuilder builder, Offset<BeadRandomBuff> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E96 RID: 3734
		private Table __p = new Table();

		// Token: 0x04000E97 RID: 3735
		private FlatBufferArray<int> PropTypeValue;

		// Token: 0x04000E98 RID: 3736
		private FlatBufferArray<int> PropValueValue;

		// Token: 0x020002D1 RID: 721
		public enum eCrypt
		{
			// Token: 0x04000E9A RID: 3738
			code = -803912890
		}
	}
}
