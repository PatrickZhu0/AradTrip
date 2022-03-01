using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002DC RID: 732
	public class BetHorseRate : IFlatbufferObject
	{
		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06001AAE RID: 6830 RVA: 0x000787B4 File Offset: 0x00076BB4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x000787C1 File Offset: 0x00076BC1
		public static BetHorseRate GetRootAsBetHorseRate(ByteBuffer _bb)
		{
			return BetHorseRate.GetRootAsBetHorseRate(_bb, new BetHorseRate());
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x000787CE File Offset: 0x00076BCE
		public static BetHorseRate GetRootAsBetHorseRate(ByteBuffer _bb, BetHorseRate obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001AB1 RID: 6833 RVA: 0x000787EA File Offset: 0x00076BEA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x00078804 File Offset: 0x00076C04
		public BetHorseRate __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06001AB3 RID: 6835 RVA: 0x00078810 File Offset: 0x00076C10
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-192584734 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06001AB4 RID: 6836 RVA: 0x0007885C File Offset: 0x00076C5C
		public int WeatherType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-192584734 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06001AB5 RID: 6837 RVA: 0x000788A8 File Offset: 0x00076CA8
		public int WeatherOccupation_1
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-192584734 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06001AB6 RID: 6838 RVA: 0x000788F4 File Offset: 0x00076CF4
		public int WeatherOccupation_2
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-192584734 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06001AB7 RID: 6839 RVA: 0x00078940 File Offset: 0x00076D40
		public int WeatherWinRate
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-192584734 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06001AB8 RID: 6840 RVA: 0x0007898C File Offset: 0x00076D8C
		public int TerrainType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-192584734 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06001AB9 RID: 6841 RVA: 0x000789D8 File Offset: 0x00076DD8
		public int TerrainOccupation_1
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-192584734 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06001ABA RID: 6842 RVA: 0x00078A24 File Offset: 0x00076E24
		public int TerrainOccupation_2
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-192584734 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06001ABB RID: 6843 RVA: 0x00078A70 File Offset: 0x00076E70
		public int TerrainWinRate
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-192584734 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001ABC RID: 6844 RVA: 0x00078ABC File Offset: 0x00076EBC
		public static Offset<BetHorseRate> CreateBetHorseRate(FlatBufferBuilder builder, int ID = 0, int WeatherType = 0, int WeatherOccupation_1 = 0, int WeatherOccupation_2 = 0, int WeatherWinRate = 0, int TerrainType = 0, int TerrainOccupation_1 = 0, int TerrainOccupation_2 = 0, int TerrainWinRate = 0)
		{
			builder.StartObject(9);
			BetHorseRate.AddTerrainWinRate(builder, TerrainWinRate);
			BetHorseRate.AddTerrainOccupation2(builder, TerrainOccupation_2);
			BetHorseRate.AddTerrainOccupation1(builder, TerrainOccupation_1);
			BetHorseRate.AddTerrainType(builder, TerrainType);
			BetHorseRate.AddWeatherWinRate(builder, WeatherWinRate);
			BetHorseRate.AddWeatherOccupation2(builder, WeatherOccupation_2);
			BetHorseRate.AddWeatherOccupation1(builder, WeatherOccupation_1);
			BetHorseRate.AddWeatherType(builder, WeatherType);
			BetHorseRate.AddID(builder, ID);
			return BetHorseRate.EndBetHorseRate(builder);
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x00078B1C File Offset: 0x00076F1C
		public static void StartBetHorseRate(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x00078B26 File Offset: 0x00076F26
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x00078B31 File Offset: 0x00076F31
		public static void AddWeatherType(FlatBufferBuilder builder, int WeatherType)
		{
			builder.AddInt(1, WeatherType, 0);
		}

		// Token: 0x06001AC0 RID: 6848 RVA: 0x00078B3C File Offset: 0x00076F3C
		public static void AddWeatherOccupation1(FlatBufferBuilder builder, int WeatherOccupation1)
		{
			builder.AddInt(2, WeatherOccupation1, 0);
		}

		// Token: 0x06001AC1 RID: 6849 RVA: 0x00078B47 File Offset: 0x00076F47
		public static void AddWeatherOccupation2(FlatBufferBuilder builder, int WeatherOccupation2)
		{
			builder.AddInt(3, WeatherOccupation2, 0);
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x00078B52 File Offset: 0x00076F52
		public static void AddWeatherWinRate(FlatBufferBuilder builder, int WeatherWinRate)
		{
			builder.AddInt(4, WeatherWinRate, 0);
		}

		// Token: 0x06001AC3 RID: 6851 RVA: 0x00078B5D File Offset: 0x00076F5D
		public static void AddTerrainType(FlatBufferBuilder builder, int TerrainType)
		{
			builder.AddInt(5, TerrainType, 0);
		}

		// Token: 0x06001AC4 RID: 6852 RVA: 0x00078B68 File Offset: 0x00076F68
		public static void AddTerrainOccupation1(FlatBufferBuilder builder, int TerrainOccupation1)
		{
			builder.AddInt(6, TerrainOccupation1, 0);
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x00078B73 File Offset: 0x00076F73
		public static void AddTerrainOccupation2(FlatBufferBuilder builder, int TerrainOccupation2)
		{
			builder.AddInt(7, TerrainOccupation2, 0);
		}

		// Token: 0x06001AC6 RID: 6854 RVA: 0x00078B7E File Offset: 0x00076F7E
		public static void AddTerrainWinRate(FlatBufferBuilder builder, int TerrainWinRate)
		{
			builder.AddInt(8, TerrainWinRate, 0);
		}

		// Token: 0x06001AC7 RID: 6855 RVA: 0x00078B8C File Offset: 0x00076F8C
		public static Offset<BetHorseRate> EndBetHorseRate(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BetHorseRate>(value);
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x00078BA6 File Offset: 0x00076FA6
		public static void FinishBetHorseRateBuffer(FlatBufferBuilder builder, Offset<BetHorseRate> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EB1 RID: 3761
		private Table __p = new Table();

		// Token: 0x020002DD RID: 733
		public enum eCrypt
		{
			// Token: 0x04000EB3 RID: 3763
			code = -192584734
		}
	}
}
