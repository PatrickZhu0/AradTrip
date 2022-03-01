using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200043B RID: 1083
	public class FatigueMakeUpPrice : IFlatbufferObject
	{
		// Token: 0x17000C9F RID: 3231
		// (get) Token: 0x0600337D RID: 13181 RVA: 0x000B4A88 File Offset: 0x000B2E88
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600337E RID: 13182 RVA: 0x000B4A95 File Offset: 0x000B2E95
		public static FatigueMakeUpPrice GetRootAsFatigueMakeUpPrice(ByteBuffer _bb)
		{
			return FatigueMakeUpPrice.GetRootAsFatigueMakeUpPrice(_bb, new FatigueMakeUpPrice());
		}

		// Token: 0x0600337F RID: 13183 RVA: 0x000B4AA2 File Offset: 0x000B2EA2
		public static FatigueMakeUpPrice GetRootAsFatigueMakeUpPrice(ByteBuffer _bb, FatigueMakeUpPrice obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003380 RID: 13184 RVA: 0x000B4ABE File Offset: 0x000B2EBE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003381 RID: 13185 RVA: 0x000B4AD8 File Offset: 0x000B2ED8
		public FatigueMakeUpPrice __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000CA0 RID: 3232
		// (get) Token: 0x06003382 RID: 13186 RVA: 0x000B4AE4 File Offset: 0x000B2EE4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-840572113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003383 RID: 13187 RVA: 0x000B4B30 File Offset: 0x000B2F30
		public int FatigueSectionArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (-840572113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000CA1 RID: 3233
		// (get) Token: 0x06003384 RID: 13188 RVA: 0x000B4B7C File Offset: 0x000B2F7C
		public int FatigueSectionLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003385 RID: 13189 RVA: 0x000B4BAE File Offset: 0x000B2FAE
		public ArraySegment<byte>? GetFatigueSectionBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000CA2 RID: 3234
		// (get) Token: 0x06003386 RID: 13190 RVA: 0x000B4BBC File Offset: 0x000B2FBC
		public FlatBufferArray<int> FatigueSection
		{
			get
			{
				if (this.FatigueSectionValue == null)
				{
					this.FatigueSectionValue = new FlatBufferArray<int>(new Func<int, int>(this.FatigueSectionArray), this.FatigueSectionLength);
				}
				return this.FatigueSectionValue;
			}
		}

		// Token: 0x17000CA3 RID: 3235
		// (get) Token: 0x06003387 RID: 13191 RVA: 0x000B4BEC File Offset: 0x000B2FEC
		public int LowPrice
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-840572113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CA4 RID: 3236
		// (get) Token: 0x06003388 RID: 13192 RVA: 0x000B4C38 File Offset: 0x000B3038
		public int HiPrice
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-840572113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003389 RID: 13193 RVA: 0x000B4C82 File Offset: 0x000B3082
		public static Offset<FatigueMakeUpPrice> CreateFatigueMakeUpPrice(FlatBufferBuilder builder, int ID = 0, VectorOffset FatigueSectionOffset = default(VectorOffset), int LowPrice = 0, int HiPrice = 0)
		{
			builder.StartObject(4);
			FatigueMakeUpPrice.AddHiPrice(builder, HiPrice);
			FatigueMakeUpPrice.AddLowPrice(builder, LowPrice);
			FatigueMakeUpPrice.AddFatigueSection(builder, FatigueSectionOffset);
			FatigueMakeUpPrice.AddID(builder, ID);
			return FatigueMakeUpPrice.EndFatigueMakeUpPrice(builder);
		}

		// Token: 0x0600338A RID: 13194 RVA: 0x000B4CAE File Offset: 0x000B30AE
		public static void StartFatigueMakeUpPrice(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0600338B RID: 13195 RVA: 0x000B4CB7 File Offset: 0x000B30B7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600338C RID: 13196 RVA: 0x000B4CC2 File Offset: 0x000B30C2
		public static void AddFatigueSection(FlatBufferBuilder builder, VectorOffset FatigueSectionOffset)
		{
			builder.AddOffset(1, FatigueSectionOffset.Value, 0);
		}

		// Token: 0x0600338D RID: 13197 RVA: 0x000B4CD4 File Offset: 0x000B30D4
		public static VectorOffset CreateFatigueSectionVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600338E RID: 13198 RVA: 0x000B4D11 File Offset: 0x000B3111
		public static void StartFatigueSectionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600338F RID: 13199 RVA: 0x000B4D1C File Offset: 0x000B311C
		public static void AddLowPrice(FlatBufferBuilder builder, int LowPrice)
		{
			builder.AddInt(2, LowPrice, 0);
		}

		// Token: 0x06003390 RID: 13200 RVA: 0x000B4D27 File Offset: 0x000B3127
		public static void AddHiPrice(FlatBufferBuilder builder, int HiPrice)
		{
			builder.AddInt(3, HiPrice, 0);
		}

		// Token: 0x06003391 RID: 13201 RVA: 0x000B4D34 File Offset: 0x000B3134
		public static Offset<FatigueMakeUpPrice> EndFatigueMakeUpPrice(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FatigueMakeUpPrice>(value);
		}

		// Token: 0x06003392 RID: 13202 RVA: 0x000B4D4E File Offset: 0x000B314E
		public static void FinishFatigueMakeUpPriceBuffer(FlatBufferBuilder builder, Offset<FatigueMakeUpPrice> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001503 RID: 5379
		private Table __p = new Table();

		// Token: 0x04001504 RID: 5380
		private FlatBufferArray<int> FatigueSectionValue;

		// Token: 0x0200043C RID: 1084
		public enum eCrypt
		{
			// Token: 0x04001506 RID: 5382
			code = -840572113
		}
	}
}
