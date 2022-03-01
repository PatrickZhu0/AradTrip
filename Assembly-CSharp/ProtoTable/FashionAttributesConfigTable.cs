using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000426 RID: 1062
	public class FashionAttributesConfigTable : IFlatbufferObject
	{
		// Token: 0x17000C55 RID: 3157
		// (get) Token: 0x0600328D RID: 12941 RVA: 0x000B29BC File Offset: 0x000B0DBC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600328E RID: 12942 RVA: 0x000B29C9 File Offset: 0x000B0DC9
		public static FashionAttributesConfigTable GetRootAsFashionAttributesConfigTable(ByteBuffer _bb)
		{
			return FashionAttributesConfigTable.GetRootAsFashionAttributesConfigTable(_bb, new FashionAttributesConfigTable());
		}

		// Token: 0x0600328F RID: 12943 RVA: 0x000B29D6 File Offset: 0x000B0DD6
		public static FashionAttributesConfigTable GetRootAsFashionAttributesConfigTable(ByteBuffer _bb, FashionAttributesConfigTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003290 RID: 12944 RVA: 0x000B29F2 File Offset: 0x000B0DF2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003291 RID: 12945 RVA: 0x000B2A0C File Offset: 0x000B0E0C
		public FashionAttributesConfigTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C56 RID: 3158
		// (get) Token: 0x06003292 RID: 12946 RVA: 0x000B2A18 File Offset: 0x000B0E18
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-707526069 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C57 RID: 3159
		// (get) Token: 0x06003293 RID: 12947 RVA: 0x000B2A64 File Offset: 0x000B0E64
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003294 RID: 12948 RVA: 0x000B2AA6 File Offset: 0x000B0EA6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000C58 RID: 3160
		// (get) Token: 0x06003295 RID: 12949 RVA: 0x000B2AB4 File Offset: 0x000B0EB4
		public int DefaultAttribute_1
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-707526069 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003296 RID: 12950 RVA: 0x000B2B00 File Offset: 0x000B0F00
		public int AttributesArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-707526069 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C59 RID: 3161
		// (get) Token: 0x06003297 RID: 12951 RVA: 0x000B2B50 File Offset: 0x000B0F50
		public int AttributesLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003298 RID: 12952 RVA: 0x000B2B83 File Offset: 0x000B0F83
		public ArraySegment<byte>? GetAttributesBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000C5A RID: 3162
		// (get) Token: 0x06003299 RID: 12953 RVA: 0x000B2B92 File Offset: 0x000B0F92
		public FlatBufferArray<int> Attributes
		{
			get
			{
				if (this.AttributesValue == null)
				{
					this.AttributesValue = new FlatBufferArray<int>(new Func<int, int>(this.AttributesArray), this.AttributesLength);
				}
				return this.AttributesValue;
			}
		}

		// Token: 0x17000C5B RID: 3163
		// (get) Token: 0x0600329A RID: 12954 RVA: 0x000B2BC4 File Offset: 0x000B0FC4
		public int DefaultAttribute
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-707526069 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C5C RID: 3164
		// (get) Token: 0x0600329B RID: 12955 RVA: 0x000B2C10 File Offset: 0x000B1010
		public int FreeSelecteTimes
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-707526069 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600329C RID: 12956 RVA: 0x000B2C5A File Offset: 0x000B105A
		public static Offset<FashionAttributesConfigTable> CreateFashionAttributesConfigTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int DefaultAttribute_1 = 0, VectorOffset AttributesOffset = default(VectorOffset), int DefaultAttribute = 0, int FreeSelecteTimes = 0)
		{
			builder.StartObject(6);
			FashionAttributesConfigTable.AddFreeSelecteTimes(builder, FreeSelecteTimes);
			FashionAttributesConfigTable.AddDefaultAttribute(builder, DefaultAttribute);
			FashionAttributesConfigTable.AddAttributes(builder, AttributesOffset);
			FashionAttributesConfigTable.AddDefaultAttribute1(builder, DefaultAttribute_1);
			FashionAttributesConfigTable.AddName(builder, NameOffset);
			FashionAttributesConfigTable.AddID(builder, ID);
			return FashionAttributesConfigTable.EndFashionAttributesConfigTable(builder);
		}

		// Token: 0x0600329D RID: 12957 RVA: 0x000B2C96 File Offset: 0x000B1096
		public static void StartFashionAttributesConfigTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x0600329E RID: 12958 RVA: 0x000B2C9F File Offset: 0x000B109F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600329F RID: 12959 RVA: 0x000B2CAA File Offset: 0x000B10AA
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060032A0 RID: 12960 RVA: 0x000B2CBB File Offset: 0x000B10BB
		public static void AddDefaultAttribute1(FlatBufferBuilder builder, int DefaultAttribute1)
		{
			builder.AddInt(2, DefaultAttribute1, 0);
		}

		// Token: 0x060032A1 RID: 12961 RVA: 0x000B2CC6 File Offset: 0x000B10C6
		public static void AddAttributes(FlatBufferBuilder builder, VectorOffset AttributesOffset)
		{
			builder.AddOffset(3, AttributesOffset.Value, 0);
		}

		// Token: 0x060032A2 RID: 12962 RVA: 0x000B2CD8 File Offset: 0x000B10D8
		public static VectorOffset CreateAttributesVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060032A3 RID: 12963 RVA: 0x000B2D15 File Offset: 0x000B1115
		public static void StartAttributesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060032A4 RID: 12964 RVA: 0x000B2D20 File Offset: 0x000B1120
		public static void AddDefaultAttribute(FlatBufferBuilder builder, int DefaultAttribute)
		{
			builder.AddInt(4, DefaultAttribute, 0);
		}

		// Token: 0x060032A5 RID: 12965 RVA: 0x000B2D2B File Offset: 0x000B112B
		public static void AddFreeSelecteTimes(FlatBufferBuilder builder, int FreeSelecteTimes)
		{
			builder.AddInt(5, FreeSelecteTimes, 0);
		}

		// Token: 0x060032A6 RID: 12966 RVA: 0x000B2D38 File Offset: 0x000B1138
		public static Offset<FashionAttributesConfigTable> EndFashionAttributesConfigTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FashionAttributesConfigTable>(value);
		}

		// Token: 0x060032A7 RID: 12967 RVA: 0x000B2D52 File Offset: 0x000B1152
		public static void FinishFashionAttributesConfigTableBuffer(FlatBufferBuilder builder, Offset<FashionAttributesConfigTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014CC RID: 5324
		private Table __p = new Table();

		// Token: 0x040014CD RID: 5325
		private FlatBufferArray<int> AttributesValue;

		// Token: 0x02000427 RID: 1063
		public enum eCrypt
		{
			// Token: 0x040014CF RID: 5327
			code = -707526069
		}
	}
}
