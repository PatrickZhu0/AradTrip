using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200040A RID: 1034
	public class EquipStrModIndAtkTable : IFlatbufferObject
	{
		// Token: 0x17000B77 RID: 2935
		// (get) Token: 0x06002FB7 RID: 12215 RVA: 0x000ABB38 File Offset: 0x000A9F38
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002FB8 RID: 12216 RVA: 0x000ABB45 File Offset: 0x000A9F45
		public static EquipStrModIndAtkTable GetRootAsEquipStrModIndAtkTable(ByteBuffer _bb)
		{
			return EquipStrModIndAtkTable.GetRootAsEquipStrModIndAtkTable(_bb, new EquipStrModIndAtkTable());
		}

		// Token: 0x06002FB9 RID: 12217 RVA: 0x000ABB52 File Offset: 0x000A9F52
		public static EquipStrModIndAtkTable GetRootAsEquipStrModIndAtkTable(ByteBuffer _bb, EquipStrModIndAtkTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002FBA RID: 12218 RVA: 0x000ABB6E File Offset: 0x000A9F6E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002FBB RID: 12219 RVA: 0x000ABB88 File Offset: 0x000A9F88
		public EquipStrModIndAtkTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B78 RID: 2936
		// (get) Token: 0x06002FBC RID: 12220 RVA: 0x000ABB94 File Offset: 0x000A9F94
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (8120504 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002FBD RID: 12221 RVA: 0x000ABBE0 File Offset: 0x000A9FE0
		public int WpStrenthMod_1Array(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (8120504 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B79 RID: 2937
		// (get) Token: 0x06002FBE RID: 12222 RVA: 0x000ABC2C File Offset: 0x000AA02C
		public int WpStrenthMod_1Length
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FBF RID: 12223 RVA: 0x000ABC5E File Offset: 0x000AA05E
		public ArraySegment<byte>? GetWpStrenthMod1Bytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000B7A RID: 2938
		// (get) Token: 0x06002FC0 RID: 12224 RVA: 0x000ABC6C File Offset: 0x000AA06C
		public FlatBufferArray<int> WpStrenthMod_1
		{
			get
			{
				if (this.WpStrenthMod_1Value == null)
				{
					this.WpStrenthMod_1Value = new FlatBufferArray<int>(new Func<int, int>(this.WpStrenthMod_1Array), this.WpStrenthMod_1Length);
				}
				return this.WpStrenthMod_1Value;
			}
		}

		// Token: 0x06002FC1 RID: 12225 RVA: 0x000ABC9C File Offset: 0x000AA09C
		public int WpColorQaMod_1Array(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (8120504 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B7B RID: 2939
		// (get) Token: 0x06002FC2 RID: 12226 RVA: 0x000ABCE8 File Offset: 0x000AA0E8
		public int WpColorQaMod_1Length
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FC3 RID: 12227 RVA: 0x000ABD1A File Offset: 0x000AA11A
		public ArraySegment<byte>? GetWpColorQaMod1Bytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000B7C RID: 2940
		// (get) Token: 0x06002FC4 RID: 12228 RVA: 0x000ABD28 File Offset: 0x000AA128
		public FlatBufferArray<int> WpColorQaMod_1
		{
			get
			{
				if (this.WpColorQaMod_1Value == null)
				{
					this.WpColorQaMod_1Value = new FlatBufferArray<int>(new Func<int, int>(this.WpColorQaMod_1Array), this.WpColorQaMod_1Length);
				}
				return this.WpColorQaMod_1Value;
			}
		}

		// Token: 0x06002FC5 RID: 12229 RVA: 0x000ABD58 File Offset: 0x000AA158
		public int WpColorQbMod_1Array(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (8120504 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B7D RID: 2941
		// (get) Token: 0x06002FC6 RID: 12230 RVA: 0x000ABDA8 File Offset: 0x000AA1A8
		public int WpColorQbMod_1Length
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FC7 RID: 12231 RVA: 0x000ABDDB File Offset: 0x000AA1DB
		public ArraySegment<byte>? GetWpColorQbMod1Bytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000B7E RID: 2942
		// (get) Token: 0x06002FC8 RID: 12232 RVA: 0x000ABDEA File Offset: 0x000AA1EA
		public FlatBufferArray<int> WpColorQbMod_1
		{
			get
			{
				if (this.WpColorQbMod_1Value == null)
				{
					this.WpColorQbMod_1Value = new FlatBufferArray<int>(new Func<int, int>(this.WpColorQbMod_1Array), this.WpColorQbMod_1Length);
				}
				return this.WpColorQbMod_1Value;
			}
		}

		// Token: 0x06002FC9 RID: 12233 RVA: 0x000ABE1C File Offset: 0x000AA21C
		public int EquipModArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (8120504 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B7F RID: 2943
		// (get) Token: 0x06002FCA RID: 12234 RVA: 0x000ABE6C File Offset: 0x000AA26C
		public int EquipModLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FCB RID: 12235 RVA: 0x000ABE9F File Offset: 0x000AA29F
		public ArraySegment<byte>? GetEquipModBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000B80 RID: 2944
		// (get) Token: 0x06002FCC RID: 12236 RVA: 0x000ABEAE File Offset: 0x000AA2AE
		public FlatBufferArray<int> EquipMod
		{
			get
			{
				if (this.EquipModValue == null)
				{
					this.EquipModValue = new FlatBufferArray<int>(new Func<int, int>(this.EquipModArray), this.EquipModLength);
				}
				return this.EquipModValue;
			}
		}

		// Token: 0x06002FCD RID: 12237 RVA: 0x000ABEDE File Offset: 0x000AA2DE
		public static Offset<EquipStrModIndAtkTable> CreateEquipStrModIndAtkTable(FlatBufferBuilder builder, int ID = 0, VectorOffset WpStrenthMod_1Offset = default(VectorOffset), VectorOffset WpColorQaMod_1Offset = default(VectorOffset), VectorOffset WpColorQbMod_1Offset = default(VectorOffset), VectorOffset EquipModOffset = default(VectorOffset))
		{
			builder.StartObject(5);
			EquipStrModIndAtkTable.AddEquipMod(builder, EquipModOffset);
			EquipStrModIndAtkTable.AddWpColorQbMod1(builder, WpColorQbMod_1Offset);
			EquipStrModIndAtkTable.AddWpColorQaMod1(builder, WpColorQaMod_1Offset);
			EquipStrModIndAtkTable.AddWpStrenthMod1(builder, WpStrenthMod_1Offset);
			EquipStrModIndAtkTable.AddID(builder, ID);
			return EquipStrModIndAtkTable.EndEquipStrModIndAtkTable(builder);
		}

		// Token: 0x06002FCE RID: 12238 RVA: 0x000ABF12 File Offset: 0x000AA312
		public static void StartEquipStrModIndAtkTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06002FCF RID: 12239 RVA: 0x000ABF1B File Offset: 0x000AA31B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002FD0 RID: 12240 RVA: 0x000ABF26 File Offset: 0x000AA326
		public static void AddWpStrenthMod1(FlatBufferBuilder builder, VectorOffset WpStrenthMod1Offset)
		{
			builder.AddOffset(1, WpStrenthMod1Offset.Value, 0);
		}

		// Token: 0x06002FD1 RID: 12241 RVA: 0x000ABF38 File Offset: 0x000AA338
		public static VectorOffset CreateWpStrenthMod1Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FD2 RID: 12242 RVA: 0x000ABF75 File Offset: 0x000AA375
		public static void StartWpStrenthMod1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FD3 RID: 12243 RVA: 0x000ABF80 File Offset: 0x000AA380
		public static void AddWpColorQaMod1(FlatBufferBuilder builder, VectorOffset WpColorQaMod1Offset)
		{
			builder.AddOffset(2, WpColorQaMod1Offset.Value, 0);
		}

		// Token: 0x06002FD4 RID: 12244 RVA: 0x000ABF94 File Offset: 0x000AA394
		public static VectorOffset CreateWpColorQaMod1Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FD5 RID: 12245 RVA: 0x000ABFD1 File Offset: 0x000AA3D1
		public static void StartWpColorQaMod1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FD6 RID: 12246 RVA: 0x000ABFDC File Offset: 0x000AA3DC
		public static void AddWpColorQbMod1(FlatBufferBuilder builder, VectorOffset WpColorQbMod1Offset)
		{
			builder.AddOffset(3, WpColorQbMod1Offset.Value, 0);
		}

		// Token: 0x06002FD7 RID: 12247 RVA: 0x000ABFF0 File Offset: 0x000AA3F0
		public static VectorOffset CreateWpColorQbMod1Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FD8 RID: 12248 RVA: 0x000AC02D File Offset: 0x000AA42D
		public static void StartWpColorQbMod1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FD9 RID: 12249 RVA: 0x000AC038 File Offset: 0x000AA438
		public static void AddEquipMod(FlatBufferBuilder builder, VectorOffset EquipModOffset)
		{
			builder.AddOffset(4, EquipModOffset.Value, 0);
		}

		// Token: 0x06002FDA RID: 12250 RVA: 0x000AC04C File Offset: 0x000AA44C
		public static VectorOffset CreateEquipModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FDB RID: 12251 RVA: 0x000AC089 File Offset: 0x000AA489
		public static void StartEquipModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FDC RID: 12252 RVA: 0x000AC094 File Offset: 0x000AA494
		public static Offset<EquipStrModIndAtkTable> EndEquipStrModIndAtkTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipStrModIndAtkTable>(value);
		}

		// Token: 0x06002FDD RID: 12253 RVA: 0x000AC0AE File Offset: 0x000AA4AE
		public static void FinishEquipStrModIndAtkTableBuffer(FlatBufferBuilder builder, Offset<EquipStrModIndAtkTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400141F RID: 5151
		private Table __p = new Table();

		// Token: 0x04001420 RID: 5152
		private FlatBufferArray<int> WpStrenthMod_1Value;

		// Token: 0x04001421 RID: 5153
		private FlatBufferArray<int> WpColorQaMod_1Value;

		// Token: 0x04001422 RID: 5154
		private FlatBufferArray<int> WpColorQbMod_1Value;

		// Token: 0x04001423 RID: 5155
		private FlatBufferArray<int> EquipModValue;

		// Token: 0x0200040B RID: 1035
		public enum eCrypt
		{
			// Token: 0x04001425 RID: 5157
			code = 8120504
		}
	}
}
