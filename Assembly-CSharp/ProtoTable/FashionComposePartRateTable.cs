using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200042C RID: 1068
	public class FashionComposePartRateTable : IFlatbufferObject
	{
		// Token: 0x17000C6A RID: 3178
		// (get) Token: 0x060032DC RID: 13020 RVA: 0x000B340C File Offset: 0x000B180C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060032DD RID: 13021 RVA: 0x000B3419 File Offset: 0x000B1819
		public static FashionComposePartRateTable GetRootAsFashionComposePartRateTable(ByteBuffer _bb)
		{
			return FashionComposePartRateTable.GetRootAsFashionComposePartRateTable(_bb, new FashionComposePartRateTable());
		}

		// Token: 0x060032DE RID: 13022 RVA: 0x000B3426 File Offset: 0x000B1826
		public static FashionComposePartRateTable GetRootAsFashionComposePartRateTable(ByteBuffer _bb, FashionComposePartRateTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060032DF RID: 13023 RVA: 0x000B3442 File Offset: 0x000B1842
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060032E0 RID: 13024 RVA: 0x000B345C File Offset: 0x000B185C
		public FashionComposePartRateTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C6B RID: 3179
		// (get) Token: 0x060032E1 RID: 13025 RVA: 0x000B3468 File Offset: 0x000B1868
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1187066657 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C6C RID: 3180
		// (get) Token: 0x060032E2 RID: 13026 RVA: 0x000B34B4 File Offset: 0x000B18B4
		public int ComposeNum
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1187066657 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C6D RID: 3181
		// (get) Token: 0x060032E3 RID: 13027 RVA: 0x000B3500 File Offset: 0x000B1900
		public int NoneSkyRate
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1187066657 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C6E RID: 3182
		// (get) Token: 0x060032E4 RID: 13028 RVA: 0x000B354C File Offset: 0x000B194C
		public int NormalSkyRate
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1187066657 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C6F RID: 3183
		// (get) Token: 0x060032E5 RID: 13029 RVA: 0x000B3598 File Offset: 0x000B1998
		public int GoldSkyRate
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1187066657 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060032E6 RID: 13030 RVA: 0x000B35E2 File Offset: 0x000B19E2
		public static Offset<FashionComposePartRateTable> CreateFashionComposePartRateTable(FlatBufferBuilder builder, int ID = 0, int ComposeNum = 0, int NoneSkyRate = 0, int NormalSkyRate = 0, int GoldSkyRate = 0)
		{
			builder.StartObject(5);
			FashionComposePartRateTable.AddGoldSkyRate(builder, GoldSkyRate);
			FashionComposePartRateTable.AddNormalSkyRate(builder, NormalSkyRate);
			FashionComposePartRateTable.AddNoneSkyRate(builder, NoneSkyRate);
			FashionComposePartRateTable.AddComposeNum(builder, ComposeNum);
			FashionComposePartRateTable.AddID(builder, ID);
			return FashionComposePartRateTable.EndFashionComposePartRateTable(builder);
		}

		// Token: 0x060032E7 RID: 13031 RVA: 0x000B3616 File Offset: 0x000B1A16
		public static void StartFashionComposePartRateTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060032E8 RID: 13032 RVA: 0x000B361F File Offset: 0x000B1A1F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060032E9 RID: 13033 RVA: 0x000B362A File Offset: 0x000B1A2A
		public static void AddComposeNum(FlatBufferBuilder builder, int ComposeNum)
		{
			builder.AddInt(1, ComposeNum, 0);
		}

		// Token: 0x060032EA RID: 13034 RVA: 0x000B3635 File Offset: 0x000B1A35
		public static void AddNoneSkyRate(FlatBufferBuilder builder, int NoneSkyRate)
		{
			builder.AddInt(2, NoneSkyRate, 0);
		}

		// Token: 0x060032EB RID: 13035 RVA: 0x000B3640 File Offset: 0x000B1A40
		public static void AddNormalSkyRate(FlatBufferBuilder builder, int NormalSkyRate)
		{
			builder.AddInt(3, NormalSkyRate, 0);
		}

		// Token: 0x060032EC RID: 13036 RVA: 0x000B364B File Offset: 0x000B1A4B
		public static void AddGoldSkyRate(FlatBufferBuilder builder, int GoldSkyRate)
		{
			builder.AddInt(4, GoldSkyRate, 0);
		}

		// Token: 0x060032ED RID: 13037 RVA: 0x000B3658 File Offset: 0x000B1A58
		public static Offset<FashionComposePartRateTable> EndFashionComposePartRateTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FashionComposePartRateTable>(value);
		}

		// Token: 0x060032EE RID: 13038 RVA: 0x000B3672 File Offset: 0x000B1A72
		public static void FinishFashionComposePartRateTableBuffer(FlatBufferBuilder builder, Offset<FashionComposePartRateTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014D9 RID: 5337
		private Table __p = new Table();

		// Token: 0x0200042D RID: 1069
		public enum eCrypt
		{
			// Token: 0x040014DB RID: 5339
			code = -1187066657
		}
	}
}
