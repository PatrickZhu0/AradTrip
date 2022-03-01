using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200042E RID: 1070
	public class FashionComposeRateTable : IFlatbufferObject
	{
		// Token: 0x17000C70 RID: 3184
		// (get) Token: 0x060032F0 RID: 13040 RVA: 0x000B3694 File Offset: 0x000B1A94
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060032F1 RID: 13041 RVA: 0x000B36A1 File Offset: 0x000B1AA1
		public static FashionComposeRateTable GetRootAsFashionComposeRateTable(ByteBuffer _bb)
		{
			return FashionComposeRateTable.GetRootAsFashionComposeRateTable(_bb, new FashionComposeRateTable());
		}

		// Token: 0x060032F2 RID: 13042 RVA: 0x000B36AE File Offset: 0x000B1AAE
		public static FashionComposeRateTable GetRootAsFashionComposeRateTable(ByteBuffer _bb, FashionComposeRateTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060032F3 RID: 13043 RVA: 0x000B36CA File Offset: 0x000B1ACA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060032F4 RID: 13044 RVA: 0x000B36E4 File Offset: 0x000B1AE4
		public FashionComposeRateTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C71 RID: 3185
		// (get) Token: 0x060032F5 RID: 13045 RVA: 0x000B36F0 File Offset: 0x000B1AF0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-907772120 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C72 RID: 3186
		// (get) Token: 0x060032F6 RID: 13046 RVA: 0x000B373C File Offset: 0x000B1B3C
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-907772120 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C73 RID: 3187
		// (get) Token: 0x060032F7 RID: 13047 RVA: 0x000B3788 File Offset: 0x000B1B88
		public int Rate
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-907772120 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060032F8 RID: 13048 RVA: 0x000B37D1 File Offset: 0x000B1BD1
		public static Offset<FashionComposeRateTable> CreateFashionComposeRateTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int Rate = 0)
		{
			builder.StartObject(3);
			FashionComposeRateTable.AddRate(builder, Rate);
			FashionComposeRateTable.AddType(builder, Type);
			FashionComposeRateTable.AddID(builder, ID);
			return FashionComposeRateTable.EndFashionComposeRateTable(builder);
		}

		// Token: 0x060032F9 RID: 13049 RVA: 0x000B37F5 File Offset: 0x000B1BF5
		public static void StartFashionComposeRateTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x060032FA RID: 13050 RVA: 0x000B37FE File Offset: 0x000B1BFE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060032FB RID: 13051 RVA: 0x000B3809 File Offset: 0x000B1C09
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x060032FC RID: 13052 RVA: 0x000B3814 File Offset: 0x000B1C14
		public static void AddRate(FlatBufferBuilder builder, int Rate)
		{
			builder.AddInt(2, Rate, 0);
		}

		// Token: 0x060032FD RID: 13053 RVA: 0x000B3820 File Offset: 0x000B1C20
		public static Offset<FashionComposeRateTable> EndFashionComposeRateTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FashionComposeRateTable>(value);
		}

		// Token: 0x060032FE RID: 13054 RVA: 0x000B383A File Offset: 0x000B1C3A
		public static void FinishFashionComposeRateTableBuffer(FlatBufferBuilder builder, Offset<FashionComposeRateTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014DC RID: 5340
		private Table __p = new Table();

		// Token: 0x0200042F RID: 1071
		public enum eCrypt
		{
			// Token: 0x040014DE RID: 5342
			code = -907772120
		}
	}
}
