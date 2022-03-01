using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000439 RID: 1081
	public class FatigueMakeUp : IFlatbufferObject
	{
		// Token: 0x17000C96 RID: 3222
		// (get) Token: 0x06003363 RID: 13155 RVA: 0x000B46D8 File Offset: 0x000B2AD8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003364 RID: 13156 RVA: 0x000B46E5 File Offset: 0x000B2AE5
		public static FatigueMakeUp GetRootAsFatigueMakeUp(ByteBuffer _bb)
		{
			return FatigueMakeUp.GetRootAsFatigueMakeUp(_bb, new FatigueMakeUp());
		}

		// Token: 0x06003365 RID: 13157 RVA: 0x000B46F2 File Offset: 0x000B2AF2
		public static FatigueMakeUp GetRootAsFatigueMakeUp(ByteBuffer _bb, FatigueMakeUp obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003366 RID: 13158 RVA: 0x000B470E File Offset: 0x000B2B0E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003367 RID: 13159 RVA: 0x000B4728 File Offset: 0x000B2B28
		public FatigueMakeUp __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C97 RID: 3223
		// (get) Token: 0x06003368 RID: 13160 RVA: 0x000B4734 File Offset: 0x000B2B34
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1519808350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C98 RID: 3224
		// (get) Token: 0x06003369 RID: 13161 RVA: 0x000B4780 File Offset: 0x000B2B80
		public int LowEXP
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1519808350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C99 RID: 3225
		// (get) Token: 0x0600336A RID: 13162 RVA: 0x000B47CC File Offset: 0x000B2BCC
		public int LowNeedMoneyItem
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1519808350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C9A RID: 3226
		// (get) Token: 0x0600336B RID: 13163 RVA: 0x000B4818 File Offset: 0x000B2C18
		public int HiEXP
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1519808350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C9B RID: 3227
		// (get) Token: 0x0600336C RID: 13164 RVA: 0x000B4864 File Offset: 0x000B2C64
		public int HiNeedMoneyItem
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1519808350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C9C RID: 3228
		// (get) Token: 0x0600336D RID: 13165 RVA: 0x000B48B0 File Offset: 0x000B2CB0
		public int FatigueMax
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1519808350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C9D RID: 3229
		// (get) Token: 0x0600336E RID: 13166 RVA: 0x000B48FC File Offset: 0x000B2CFC
		public int VipFatigueMax
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1519808350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C9E RID: 3230
		// (get) Token: 0x0600336F RID: 13167 RVA: 0x000B4948 File Offset: 0x000B2D48
		public int VipLevel
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1519808350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003370 RID: 13168 RVA: 0x000B4994 File Offset: 0x000B2D94
		public static Offset<FatigueMakeUp> CreateFatigueMakeUp(FlatBufferBuilder builder, int ID = 0, int LowEXP = 0, int LowNeedMoneyItem = 0, int HiEXP = 0, int HiNeedMoneyItem = 0, int FatigueMax = 0, int VipFatigueMax = 0, int VipLevel = 0)
		{
			builder.StartObject(8);
			FatigueMakeUp.AddVipLevel(builder, VipLevel);
			FatigueMakeUp.AddVipFatigueMax(builder, VipFatigueMax);
			FatigueMakeUp.AddFatigueMax(builder, FatigueMax);
			FatigueMakeUp.AddHiNeedMoneyItem(builder, HiNeedMoneyItem);
			FatigueMakeUp.AddHiEXP(builder, HiEXP);
			FatigueMakeUp.AddLowNeedMoneyItem(builder, LowNeedMoneyItem);
			FatigueMakeUp.AddLowEXP(builder, LowEXP);
			FatigueMakeUp.AddID(builder, ID);
			return FatigueMakeUp.EndFatigueMakeUp(builder);
		}

		// Token: 0x06003371 RID: 13169 RVA: 0x000B49EB File Offset: 0x000B2DEB
		public static void StartFatigueMakeUp(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06003372 RID: 13170 RVA: 0x000B49F4 File Offset: 0x000B2DF4
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003373 RID: 13171 RVA: 0x000B49FF File Offset: 0x000B2DFF
		public static void AddLowEXP(FlatBufferBuilder builder, int LowEXP)
		{
			builder.AddInt(1, LowEXP, 0);
		}

		// Token: 0x06003374 RID: 13172 RVA: 0x000B4A0A File Offset: 0x000B2E0A
		public static void AddLowNeedMoneyItem(FlatBufferBuilder builder, int LowNeedMoneyItem)
		{
			builder.AddInt(2, LowNeedMoneyItem, 0);
		}

		// Token: 0x06003375 RID: 13173 RVA: 0x000B4A15 File Offset: 0x000B2E15
		public static void AddHiEXP(FlatBufferBuilder builder, int HiEXP)
		{
			builder.AddInt(3, HiEXP, 0);
		}

		// Token: 0x06003376 RID: 13174 RVA: 0x000B4A20 File Offset: 0x000B2E20
		public static void AddHiNeedMoneyItem(FlatBufferBuilder builder, int HiNeedMoneyItem)
		{
			builder.AddInt(4, HiNeedMoneyItem, 0);
		}

		// Token: 0x06003377 RID: 13175 RVA: 0x000B4A2B File Offset: 0x000B2E2B
		public static void AddFatigueMax(FlatBufferBuilder builder, int FatigueMax)
		{
			builder.AddInt(5, FatigueMax, 0);
		}

		// Token: 0x06003378 RID: 13176 RVA: 0x000B4A36 File Offset: 0x000B2E36
		public static void AddVipFatigueMax(FlatBufferBuilder builder, int VipFatigueMax)
		{
			builder.AddInt(6, VipFatigueMax, 0);
		}

		// Token: 0x06003379 RID: 13177 RVA: 0x000B4A41 File Offset: 0x000B2E41
		public static void AddVipLevel(FlatBufferBuilder builder, int VipLevel)
		{
			builder.AddInt(7, VipLevel, 0);
		}

		// Token: 0x0600337A RID: 13178 RVA: 0x000B4A4C File Offset: 0x000B2E4C
		public static Offset<FatigueMakeUp> EndFatigueMakeUp(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FatigueMakeUp>(value);
		}

		// Token: 0x0600337B RID: 13179 RVA: 0x000B4A66 File Offset: 0x000B2E66
		public static void FinishFatigueMakeUpBuffer(FlatBufferBuilder builder, Offset<FatigueMakeUp> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001500 RID: 5376
		private Table __p = new Table();

		// Token: 0x0200043A RID: 1082
		public enum eCrypt
		{
			// Token: 0x04001502 RID: 5378
			code = 1519808350
		}
	}
}
