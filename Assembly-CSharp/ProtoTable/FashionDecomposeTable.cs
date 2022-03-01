using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000434 RID: 1076
	public class FashionDecomposeTable : IFlatbufferObject
	{
		// Token: 0x17000C8D RID: 3213
		// (get) Token: 0x06003346 RID: 13126 RVA: 0x000B42D8 File Offset: 0x000B26D8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003347 RID: 13127 RVA: 0x000B42E5 File Offset: 0x000B26E5
		public static FashionDecomposeTable GetRootAsFashionDecomposeTable(ByteBuffer _bb)
		{
			return FashionDecomposeTable.GetRootAsFashionDecomposeTable(_bb, new FashionDecomposeTable());
		}

		// Token: 0x06003348 RID: 13128 RVA: 0x000B42F2 File Offset: 0x000B26F2
		public static FashionDecomposeTable GetRootAsFashionDecomposeTable(ByteBuffer _bb, FashionDecomposeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003349 RID: 13129 RVA: 0x000B430E File Offset: 0x000B270E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600334A RID: 13130 RVA: 0x000B4328 File Offset: 0x000B2728
		public FashionDecomposeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C8E RID: 3214
		// (get) Token: 0x0600334B RID: 13131 RVA: 0x000B4334 File Offset: 0x000B2734
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (491160631 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C8F RID: 3215
		// (get) Token: 0x0600334C RID: 13132 RVA: 0x000B4380 File Offset: 0x000B2780
		public FashionDecomposeTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (FashionDecomposeTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C90 RID: 3216
		// (get) Token: 0x0600334D RID: 13133 RVA: 0x000B43C4 File Offset: 0x000B27C4
		public FashionDecomposeTable.eThirdType ThirdType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (FashionDecomposeTable.eThirdType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C91 RID: 3217
		// (get) Token: 0x0600334E RID: 13134 RVA: 0x000B4408 File Offset: 0x000B2808
		public FashionDecomposeTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(10);
				return (FashionDecomposeTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C92 RID: 3218
		// (get) Token: 0x0600334F RID: 13135 RVA: 0x000B444C File Offset: 0x000B284C
		public int FashionID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (491160631 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C93 RID: 3219
		// (get) Token: 0x06003350 RID: 13136 RVA: 0x000B4498 File Offset: 0x000B2898
		public int GroupID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (491160631 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003351 RID: 13137 RVA: 0x000B44E4 File Offset: 0x000B28E4
		public int TextArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (491160631 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C94 RID: 3220
		// (get) Token: 0x06003352 RID: 13138 RVA: 0x000B4534 File Offset: 0x000B2934
		public int TextLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003353 RID: 13139 RVA: 0x000B4567 File Offset: 0x000B2967
		public ArraySegment<byte>? GetTextBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000C95 RID: 3221
		// (get) Token: 0x06003354 RID: 13140 RVA: 0x000B4576 File Offset: 0x000B2976
		public FlatBufferArray<int> Text
		{
			get
			{
				if (this.TextValue == null)
				{
					this.TextValue = new FlatBufferArray<int>(new Func<int, int>(this.TextArray), this.TextLength);
				}
				return this.TextValue;
			}
		}

		// Token: 0x06003355 RID: 13141 RVA: 0x000B45A8 File Offset: 0x000B29A8
		public static Offset<FashionDecomposeTable> CreateFashionDecomposeTable(FlatBufferBuilder builder, int ID = 0, FashionDecomposeTable.eSubType SubType = FashionDecomposeTable.eSubType.SubType_None, FashionDecomposeTable.eThirdType ThirdType = FashionDecomposeTable.eThirdType.TT_NONE, FashionDecomposeTable.eColor Color = FashionDecomposeTable.eColor.CL_NONE, int FashionID = 0, int GroupID = 0, VectorOffset TextOffset = default(VectorOffset))
		{
			builder.StartObject(7);
			FashionDecomposeTable.AddText(builder, TextOffset);
			FashionDecomposeTable.AddGroupID(builder, GroupID);
			FashionDecomposeTable.AddFashionID(builder, FashionID);
			FashionDecomposeTable.AddColor(builder, Color);
			FashionDecomposeTable.AddThirdType(builder, ThirdType);
			FashionDecomposeTable.AddSubType(builder, SubType);
			FashionDecomposeTable.AddID(builder, ID);
			return FashionDecomposeTable.EndFashionDecomposeTable(builder);
		}

		// Token: 0x06003356 RID: 13142 RVA: 0x000B45F7 File Offset: 0x000B29F7
		public static void StartFashionDecomposeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06003357 RID: 13143 RVA: 0x000B4600 File Offset: 0x000B2A00
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003358 RID: 13144 RVA: 0x000B460B File Offset: 0x000B2A0B
		public static void AddSubType(FlatBufferBuilder builder, FashionDecomposeTable.eSubType SubType)
		{
			builder.AddInt(1, (int)SubType, 0);
		}

		// Token: 0x06003359 RID: 13145 RVA: 0x000B4616 File Offset: 0x000B2A16
		public static void AddThirdType(FlatBufferBuilder builder, FashionDecomposeTable.eThirdType ThirdType)
		{
			builder.AddInt(2, (int)ThirdType, 0);
		}

		// Token: 0x0600335A RID: 13146 RVA: 0x000B4621 File Offset: 0x000B2A21
		public static void AddColor(FlatBufferBuilder builder, FashionDecomposeTable.eColor Color)
		{
			builder.AddInt(3, (int)Color, 0);
		}

		// Token: 0x0600335B RID: 13147 RVA: 0x000B462C File Offset: 0x000B2A2C
		public static void AddFashionID(FlatBufferBuilder builder, int FashionID)
		{
			builder.AddInt(4, FashionID, 0);
		}

		// Token: 0x0600335C RID: 13148 RVA: 0x000B4637 File Offset: 0x000B2A37
		public static void AddGroupID(FlatBufferBuilder builder, int GroupID)
		{
			builder.AddInt(5, GroupID, 0);
		}

		// Token: 0x0600335D RID: 13149 RVA: 0x000B4642 File Offset: 0x000B2A42
		public static void AddText(FlatBufferBuilder builder, VectorOffset TextOffset)
		{
			builder.AddOffset(6, TextOffset.Value, 0);
		}

		// Token: 0x0600335E RID: 13150 RVA: 0x000B4654 File Offset: 0x000B2A54
		public static VectorOffset CreateTextVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600335F RID: 13151 RVA: 0x000B4691 File Offset: 0x000B2A91
		public static void StartTextVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003360 RID: 13152 RVA: 0x000B469C File Offset: 0x000B2A9C
		public static Offset<FashionDecomposeTable> EndFashionDecomposeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FashionDecomposeTable>(value);
		}

		// Token: 0x06003361 RID: 13153 RVA: 0x000B46B6 File Offset: 0x000B2AB6
		public static void FinishFashionDecomposeTableBuffer(FlatBufferBuilder builder, Offset<FashionDecomposeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014E6 RID: 5350
		private Table __p = new Table();

		// Token: 0x040014E7 RID: 5351
		private FlatBufferArray<int> TextValue;

		// Token: 0x02000435 RID: 1077
		public enum eSubType
		{
			// Token: 0x040014E9 RID: 5353
			SubType_None,
			// Token: 0x040014EA RID: 5354
			FASHION_HAIR = 11,
			// Token: 0x040014EB RID: 5355
			FASHION_HEAD,
			// Token: 0x040014EC RID: 5356
			FASHION_SASH,
			// Token: 0x040014ED RID: 5357
			FASHION_CHEST,
			// Token: 0x040014EE RID: 5358
			FASHION_LEG,
			// Token: 0x040014EF RID: 5359
			FASHION_EPAULET,
			// Token: 0x040014F0 RID: 5360
			FASHION_AURAS = 92
		}

		// Token: 0x02000436 RID: 1078
		public enum eThirdType
		{
			// Token: 0x040014F2 RID: 5362
			TT_NONE,
			// Token: 0x040014F3 RID: 5363
			FASHION_JUNIOR = 100,
			// Token: 0x040014F4 RID: 5364
			FASHION_SENIOR,
			// Token: 0x040014F5 RID: 5365
			FASHION_FESTIVAL
		}

		// Token: 0x02000437 RID: 1079
		public enum eColor
		{
			// Token: 0x040014F7 RID: 5367
			CL_NONE,
			// Token: 0x040014F8 RID: 5368
			WHITE,
			// Token: 0x040014F9 RID: 5369
			BLUE,
			// Token: 0x040014FA RID: 5370
			PURPLE,
			// Token: 0x040014FB RID: 5371
			GREEN,
			// Token: 0x040014FC RID: 5372
			PINK,
			// Token: 0x040014FD RID: 5373
			YELLOW
		}

		// Token: 0x02000438 RID: 1080
		public enum eCrypt
		{
			// Token: 0x040014FF RID: 5375
			code = 491160631
		}
	}
}
