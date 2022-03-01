using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005A1 RID: 1441
	public class SeasonAttrTable : IFlatbufferObject
	{
		// Token: 0x1700143F RID: 5183
		// (get) Token: 0x06004A8A RID: 19082 RVA: 0x000EA910 File Offset: 0x000E8D10
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004A8B RID: 19083 RVA: 0x000EA91D File Offset: 0x000E8D1D
		public static SeasonAttrTable GetRootAsSeasonAttrTable(ByteBuffer _bb)
		{
			return SeasonAttrTable.GetRootAsSeasonAttrTable(_bb, new SeasonAttrTable());
		}

		// Token: 0x06004A8C RID: 19084 RVA: 0x000EA92A File Offset: 0x000E8D2A
		public static SeasonAttrTable GetRootAsSeasonAttrTable(ByteBuffer _bb, SeasonAttrTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004A8D RID: 19085 RVA: 0x000EA946 File Offset: 0x000E8D46
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004A8E RID: 19086 RVA: 0x000EA960 File Offset: 0x000E8D60
		public SeasonAttrTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001440 RID: 5184
		// (get) Token: 0x06004A8F RID: 19087 RVA: 0x000EA96C File Offset: 0x000E8D6C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1724784624 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004A90 RID: 19088 RVA: 0x000EA9B8 File Offset: 0x000E8DB8
		public string DescsArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001441 RID: 5185
		// (get) Token: 0x06004A91 RID: 19089 RVA: 0x000EAA00 File Offset: 0x000E8E00
		public int DescsLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001442 RID: 5186
		// (get) Token: 0x06004A92 RID: 19090 RVA: 0x000EAA32 File Offset: 0x000E8E32
		public FlatBufferArray<string> Descs
		{
			get
			{
				if (this.DescsValue == null)
				{
					this.DescsValue = new FlatBufferArray<string>(new Func<int, string>(this.DescsArray), this.DescsLength);
				}
				return this.DescsValue;
			}
		}

		// Token: 0x06004A93 RID: 19091 RVA: 0x000EAA64 File Offset: 0x000E8E64
		public int BuffIDsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (1724784624 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001443 RID: 5187
		// (get) Token: 0x06004A94 RID: 19092 RVA: 0x000EAAB0 File Offset: 0x000E8EB0
		public int BuffIDsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004A95 RID: 19093 RVA: 0x000EAAE2 File Offset: 0x000E8EE2
		public ArraySegment<byte>? GetBuffIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17001444 RID: 5188
		// (get) Token: 0x06004A96 RID: 19094 RVA: 0x000EAAF0 File Offset: 0x000E8EF0
		public FlatBufferArray<int> BuffIDs
		{
			get
			{
				if (this.BuffIDsValue == null)
				{
					this.BuffIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffIDsArray), this.BuffIDsLength);
				}
				return this.BuffIDsValue;
			}
		}

		// Token: 0x06004A97 RID: 19095 RVA: 0x000EAB20 File Offset: 0x000E8F20
		public static Offset<SeasonAttrTable> CreateSeasonAttrTable(FlatBufferBuilder builder, int ID = 0, VectorOffset DescsOffset = default(VectorOffset), VectorOffset BuffIDsOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			SeasonAttrTable.AddBuffIDs(builder, BuffIDsOffset);
			SeasonAttrTable.AddDescs(builder, DescsOffset);
			SeasonAttrTable.AddID(builder, ID);
			return SeasonAttrTable.EndSeasonAttrTable(builder);
		}

		// Token: 0x06004A98 RID: 19096 RVA: 0x000EAB44 File Offset: 0x000E8F44
		public static void StartSeasonAttrTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004A99 RID: 19097 RVA: 0x000EAB4D File Offset: 0x000E8F4D
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004A9A RID: 19098 RVA: 0x000EAB58 File Offset: 0x000E8F58
		public static void AddDescs(FlatBufferBuilder builder, VectorOffset DescsOffset)
		{
			builder.AddOffset(1, DescsOffset.Value, 0);
		}

		// Token: 0x06004A9B RID: 19099 RVA: 0x000EAB6C File Offset: 0x000E8F6C
		public static VectorOffset CreateDescsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004A9C RID: 19100 RVA: 0x000EABB2 File Offset: 0x000E8FB2
		public static void StartDescsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004A9D RID: 19101 RVA: 0x000EABBD File Offset: 0x000E8FBD
		public static void AddBuffIDs(FlatBufferBuilder builder, VectorOffset BuffIDsOffset)
		{
			builder.AddOffset(2, BuffIDsOffset.Value, 0);
		}

		// Token: 0x06004A9E RID: 19102 RVA: 0x000EABD0 File Offset: 0x000E8FD0
		public static VectorOffset CreateBuffIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004A9F RID: 19103 RVA: 0x000EAC0D File Offset: 0x000E900D
		public static void StartBuffIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004AA0 RID: 19104 RVA: 0x000EAC18 File Offset: 0x000E9018
		public static Offset<SeasonAttrTable> EndSeasonAttrTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SeasonAttrTable>(value);
		}

		// Token: 0x06004AA1 RID: 19105 RVA: 0x000EAC32 File Offset: 0x000E9032
		public static void FinishSeasonAttrTableBuffer(FlatBufferBuilder builder, Offset<SeasonAttrTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AF5 RID: 6901
		private Table __p = new Table();

		// Token: 0x04001AF6 RID: 6902
		private FlatBufferArray<string> DescsValue;

		// Token: 0x04001AF7 RID: 6903
		private FlatBufferArray<int> BuffIDsValue;

		// Token: 0x020005A2 RID: 1442
		public enum eCrypt
		{
			// Token: 0x04001AF9 RID: 6905
			code = 1724784624
		}
	}
}
