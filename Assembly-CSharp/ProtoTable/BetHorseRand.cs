using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002DA RID: 730
	public class BetHorseRand : IFlatbufferObject
	{
		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06001A96 RID: 6806 RVA: 0x00078460 File Offset: 0x00076860
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001A97 RID: 6807 RVA: 0x0007846D File Offset: 0x0007686D
		public static BetHorseRand GetRootAsBetHorseRand(ByteBuffer _bb)
		{
			return BetHorseRand.GetRootAsBetHorseRand(_bb, new BetHorseRand());
		}

		// Token: 0x06001A98 RID: 6808 RVA: 0x0007847A File Offset: 0x0007687A
		public static BetHorseRand GetRootAsBetHorseRand(ByteBuffer _bb, BetHorseRand obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001A99 RID: 6809 RVA: 0x00078496 File Offset: 0x00076896
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001A9A RID: 6810 RVA: 0x000784B0 File Offset: 0x000768B0
		public BetHorseRand __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06001A9B RID: 6811 RVA: 0x000784BC File Offset: 0x000768BC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-192585619 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06001A9C RID: 6812 RVA: 0x00078508 File Offset: 0x00076908
		public int WeatherType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-192585619 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06001A9D RID: 6813 RVA: 0x00078554 File Offset: 0x00076954
		public int WeatherRate
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-192585619 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06001A9E RID: 6814 RVA: 0x000785A0 File Offset: 0x000769A0
		public int TerrainType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-192585619 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06001A9F RID: 6815 RVA: 0x000785EC File Offset: 0x000769EC
		public int TerrainRate
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-192585619 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06001AA0 RID: 6816 RVA: 0x00078638 File Offset: 0x00076A38
		public int StatusType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-192585619 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06001AA1 RID: 6817 RVA: 0x00078684 File Offset: 0x00076A84
		public int StatusRate
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-192585619 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001AA2 RID: 6818 RVA: 0x000786D0 File Offset: 0x00076AD0
		public static Offset<BetHorseRand> CreateBetHorseRand(FlatBufferBuilder builder, int ID = 0, int WeatherType = 0, int WeatherRate = 0, int TerrainType = 0, int TerrainRate = 0, int StatusType = 0, int StatusRate = 0)
		{
			builder.StartObject(7);
			BetHorseRand.AddStatusRate(builder, StatusRate);
			BetHorseRand.AddStatusType(builder, StatusType);
			BetHorseRand.AddTerrainRate(builder, TerrainRate);
			BetHorseRand.AddTerrainType(builder, TerrainType);
			BetHorseRand.AddWeatherRate(builder, WeatherRate);
			BetHorseRand.AddWeatherType(builder, WeatherType);
			BetHorseRand.AddID(builder, ID);
			return BetHorseRand.EndBetHorseRand(builder);
		}

		// Token: 0x06001AA3 RID: 6819 RVA: 0x0007871F File Offset: 0x00076B1F
		public static void StartBetHorseRand(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06001AA4 RID: 6820 RVA: 0x00078728 File Offset: 0x00076B28
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001AA5 RID: 6821 RVA: 0x00078733 File Offset: 0x00076B33
		public static void AddWeatherType(FlatBufferBuilder builder, int WeatherType)
		{
			builder.AddInt(1, WeatherType, 0);
		}

		// Token: 0x06001AA6 RID: 6822 RVA: 0x0007873E File Offset: 0x00076B3E
		public static void AddWeatherRate(FlatBufferBuilder builder, int WeatherRate)
		{
			builder.AddInt(2, WeatherRate, 0);
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x00078749 File Offset: 0x00076B49
		public static void AddTerrainType(FlatBufferBuilder builder, int TerrainType)
		{
			builder.AddInt(3, TerrainType, 0);
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x00078754 File Offset: 0x00076B54
		public static void AddTerrainRate(FlatBufferBuilder builder, int TerrainRate)
		{
			builder.AddInt(4, TerrainRate, 0);
		}

		// Token: 0x06001AA9 RID: 6825 RVA: 0x0007875F File Offset: 0x00076B5F
		public static void AddStatusType(FlatBufferBuilder builder, int StatusType)
		{
			builder.AddInt(5, StatusType, 0);
		}

		// Token: 0x06001AAA RID: 6826 RVA: 0x0007876A File Offset: 0x00076B6A
		public static void AddStatusRate(FlatBufferBuilder builder, int StatusRate)
		{
			builder.AddInt(6, StatusRate, 0);
		}

		// Token: 0x06001AAB RID: 6827 RVA: 0x00078778 File Offset: 0x00076B78
		public static Offset<BetHorseRand> EndBetHorseRand(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BetHorseRand>(value);
		}

		// Token: 0x06001AAC RID: 6828 RVA: 0x00078792 File Offset: 0x00076B92
		public static void FinishBetHorseRandBuffer(FlatBufferBuilder builder, Offset<BetHorseRand> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EAE RID: 3758
		private Table __p = new Table();

		// Token: 0x020002DB RID: 731
		public enum eCrypt
		{
			// Token: 0x04000EB0 RID: 3760
			code = -192585619
		}
	}
}
