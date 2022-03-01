using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004D7 RID: 1239
	public class LiaoTianDynamicTextureTable : IFlatbufferObject
	{
		// Token: 0x1700106C RID: 4204
		// (get) Token: 0x06003EC7 RID: 16071 RVA: 0x000CFA24 File Offset: 0x000CDE24
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003EC8 RID: 16072 RVA: 0x000CFA31 File Offset: 0x000CDE31
		public static LiaoTianDynamicTextureTable GetRootAsLiaoTianDynamicTextureTable(ByteBuffer _bb)
		{
			return LiaoTianDynamicTextureTable.GetRootAsLiaoTianDynamicTextureTable(_bb, new LiaoTianDynamicTextureTable());
		}

		// Token: 0x06003EC9 RID: 16073 RVA: 0x000CFA3E File Offset: 0x000CDE3E
		public static LiaoTianDynamicTextureTable GetRootAsLiaoTianDynamicTextureTable(ByteBuffer _bb, LiaoTianDynamicTextureTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003ECA RID: 16074 RVA: 0x000CFA5A File Offset: 0x000CDE5A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003ECB RID: 16075 RVA: 0x000CFA74 File Offset: 0x000CDE74
		public LiaoTianDynamicTextureTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700106D RID: 4205
		// (get) Token: 0x06003ECC RID: 16076 RVA: 0x000CFA80 File Offset: 0x000CDE80
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-437325895 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700106E RID: 4206
		// (get) Token: 0x06003ECD RID: 16077 RVA: 0x000CFACC File Offset: 0x000CDECC
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003ECE RID: 16078 RVA: 0x000CFB0E File Offset: 0x000CDF0E
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700106F RID: 4207
		// (get) Token: 0x06003ECF RID: 16079 RVA: 0x000CFB1C File Offset: 0x000CDF1C
		public int Width
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-437325895 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001070 RID: 4208
		// (get) Token: 0x06003ED0 RID: 16080 RVA: 0x000CFB68 File Offset: 0x000CDF68
		public int Height
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-437325895 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001071 RID: 4209
		// (get) Token: 0x06003ED1 RID: 16081 RVA: 0x000CFBB4 File Offset: 0x000CDFB4
		public int Size
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-437325895 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001072 RID: 4210
		// (get) Token: 0x06003ED2 RID: 16082 RVA: 0x000CFC00 File Offset: 0x000CE000
		public LiaoTianDynamicTextureTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(14);
				return (LiaoTianDynamicTextureTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003ED3 RID: 16083 RVA: 0x000CFC44 File Offset: 0x000CE044
		public string ParamArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001073 RID: 4211
		// (get) Token: 0x06003ED4 RID: 16084 RVA: 0x000CFC8C File Offset: 0x000CE08C
		public int ParamLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001074 RID: 4212
		// (get) Token: 0x06003ED5 RID: 16085 RVA: 0x000CFCBF File Offset: 0x000CE0BF
		public FlatBufferArray<string> Param
		{
			get
			{
				if (this.ParamValue == null)
				{
					this.ParamValue = new FlatBufferArray<string>(new Func<int, string>(this.ParamArray), this.ParamLength);
				}
				return this.ParamValue;
			}
		}

		// Token: 0x06003ED6 RID: 16086 RVA: 0x000CFCF0 File Offset: 0x000CE0F0
		public static Offset<LiaoTianDynamicTextureTable> CreateLiaoTianDynamicTextureTable(FlatBufferBuilder builder, int ID = 0, StringOffset IconOffset = default(StringOffset), int Width = 0, int Height = 0, int Size = 0, LiaoTianDynamicTextureTable.eType Type = LiaoTianDynamicTextureTable.eType.Image, VectorOffset ParamOffset = default(VectorOffset))
		{
			builder.StartObject(7);
			LiaoTianDynamicTextureTable.AddParam(builder, ParamOffset);
			LiaoTianDynamicTextureTable.AddType(builder, Type);
			LiaoTianDynamicTextureTable.AddSize(builder, Size);
			LiaoTianDynamicTextureTable.AddHeight(builder, Height);
			LiaoTianDynamicTextureTable.AddWidth(builder, Width);
			LiaoTianDynamicTextureTable.AddIcon(builder, IconOffset);
			LiaoTianDynamicTextureTable.AddID(builder, ID);
			return LiaoTianDynamicTextureTable.EndLiaoTianDynamicTextureTable(builder);
		}

		// Token: 0x06003ED7 RID: 16087 RVA: 0x000CFD3F File Offset: 0x000CE13F
		public static void StartLiaoTianDynamicTextureTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06003ED8 RID: 16088 RVA: 0x000CFD48 File Offset: 0x000CE148
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003ED9 RID: 16089 RVA: 0x000CFD53 File Offset: 0x000CE153
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(1, IconOffset.Value, 0);
		}

		// Token: 0x06003EDA RID: 16090 RVA: 0x000CFD64 File Offset: 0x000CE164
		public static void AddWidth(FlatBufferBuilder builder, int Width)
		{
			builder.AddInt(2, Width, 0);
		}

		// Token: 0x06003EDB RID: 16091 RVA: 0x000CFD6F File Offset: 0x000CE16F
		public static void AddHeight(FlatBufferBuilder builder, int Height)
		{
			builder.AddInt(3, Height, 0);
		}

		// Token: 0x06003EDC RID: 16092 RVA: 0x000CFD7A File Offset: 0x000CE17A
		public static void AddSize(FlatBufferBuilder builder, int Size)
		{
			builder.AddInt(4, Size, 0);
		}

		// Token: 0x06003EDD RID: 16093 RVA: 0x000CFD85 File Offset: 0x000CE185
		public static void AddType(FlatBufferBuilder builder, LiaoTianDynamicTextureTable.eType Type)
		{
			builder.AddInt(5, (int)Type, 0);
		}

		// Token: 0x06003EDE RID: 16094 RVA: 0x000CFD90 File Offset: 0x000CE190
		public static void AddParam(FlatBufferBuilder builder, VectorOffset ParamOffset)
		{
			builder.AddOffset(6, ParamOffset.Value, 0);
		}

		// Token: 0x06003EDF RID: 16095 RVA: 0x000CFDA4 File Offset: 0x000CE1A4
		public static VectorOffset CreateParamVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003EE0 RID: 16096 RVA: 0x000CFDEA File Offset: 0x000CE1EA
		public static void StartParamVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003EE1 RID: 16097 RVA: 0x000CFDF8 File Offset: 0x000CE1F8
		public static Offset<LiaoTianDynamicTextureTable> EndLiaoTianDynamicTextureTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<LiaoTianDynamicTextureTable>(value);
		}

		// Token: 0x06003EE2 RID: 16098 RVA: 0x000CFE12 File Offset: 0x000CE212
		public static void FinishLiaoTianDynamicTextureTableBuffer(FlatBufferBuilder builder, Offset<LiaoTianDynamicTextureTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017E9 RID: 6121
		private Table __p = new Table();

		// Token: 0x040017EA RID: 6122
		private FlatBufferArray<string> ParamValue;

		// Token: 0x020004D8 RID: 1240
		public enum eType
		{
			// Token: 0x040017EC RID: 6124
			Image,
			// Token: 0x040017ED RID: 6125
			FrameSprite
		}

		// Token: 0x020004D9 RID: 1241
		public enum eCrypt
		{
			// Token: 0x040017EF RID: 6127
			code = -437325895
		}
	}
}
