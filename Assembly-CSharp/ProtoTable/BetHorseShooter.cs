using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002DE RID: 734
	public class BetHorseShooter : IFlatbufferObject
	{
		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06001ACA RID: 6858 RVA: 0x00078BC8 File Offset: 0x00076FC8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001ACB RID: 6859 RVA: 0x00078BD5 File Offset: 0x00076FD5
		public static BetHorseShooter GetRootAsBetHorseShooter(ByteBuffer _bb)
		{
			return BetHorseShooter.GetRootAsBetHorseShooter(_bb, new BetHorseShooter());
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x00078BE2 File Offset: 0x00076FE2
		public static BetHorseShooter GetRootAsBetHorseShooter(ByteBuffer _bb, BetHorseShooter obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x00078BFE File Offset: 0x00076FFE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x00078C18 File Offset: 0x00077018
		public BetHorseShooter __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06001ACF RID: 6863 RVA: 0x00078C24 File Offset: 0x00077024
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1185171060 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06001AD0 RID: 6864 RVA: 0x00078C70 File Offset: 0x00077070
		public int MysteryRate
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1185171060 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06001AD1 RID: 6865 RVA: 0x00078CBC File Offset: 0x000770BC
		public int AppearRate
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1185171060 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06001AD2 RID: 6866 RVA: 0x00078D08 File Offset: 0x00077108
		public string Name
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001AD3 RID: 6867 RVA: 0x00078D4B File Offset: 0x0007714B
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06001AD4 RID: 6868 RVA: 0x00078D5C File Offset: 0x0007715C
		public int OccupationType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1185171060 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06001AD5 RID: 6869 RVA: 0x00078DA8 File Offset: 0x000771A8
		public string Occupation
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001AD6 RID: 6870 RVA: 0x00078DEB File Offset: 0x000771EB
		public ArraySegment<byte>? GetOccupationBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06001AD7 RID: 6871 RVA: 0x00078DFC File Offset: 0x000771FC
		public string OccupationIcon
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001AD8 RID: 6872 RVA: 0x00078E3F File Offset: 0x0007723F
		public ArraySegment<byte>? GetOccupationIconBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06001AD9 RID: 6873 RVA: 0x00078E50 File Offset: 0x00077250
		public string Terrain
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001ADA RID: 6874 RVA: 0x00078E93 File Offset: 0x00077293
		public ArraySegment<byte>? GetTerrainBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06001ADB RID: 6875 RVA: 0x00078EA4 File Offset: 0x000772A4
		public string Weather
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x00078EE7 File Offset: 0x000772E7
		public ArraySegment<byte>? GetWeatherBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06001ADD RID: 6877 RVA: 0x00078EF8 File Offset: 0x000772F8
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x00078F3B File Offset: 0x0007733B
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06001ADF RID: 6879 RVA: 0x00078F4C File Offset: 0x0007734C
		public string PortraitPath
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x00078F8F File Offset: 0x0007738F
		public ArraySegment<byte>? GetPortraitPathBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x06001AE1 RID: 6881 RVA: 0x00078FA0 File Offset: 0x000773A0
		public static Offset<BetHorseShooter> CreateBetHorseShooter(FlatBufferBuilder builder, int ID = 0, int MysteryRate = 0, int AppearRate = 0, StringOffset NameOffset = default(StringOffset), int OccupationType = 0, StringOffset OccupationOffset = default(StringOffset), StringOffset OccupationIconOffset = default(StringOffset), StringOffset TerrainOffset = default(StringOffset), StringOffset WeatherOffset = default(StringOffset), StringOffset IconPathOffset = default(StringOffset), StringOffset PortraitPathOffset = default(StringOffset))
		{
			builder.StartObject(11);
			BetHorseShooter.AddPortraitPath(builder, PortraitPathOffset);
			BetHorseShooter.AddIconPath(builder, IconPathOffset);
			BetHorseShooter.AddWeather(builder, WeatherOffset);
			BetHorseShooter.AddTerrain(builder, TerrainOffset);
			BetHorseShooter.AddOccupationIcon(builder, OccupationIconOffset);
			BetHorseShooter.AddOccupation(builder, OccupationOffset);
			BetHorseShooter.AddOccupationType(builder, OccupationType);
			BetHorseShooter.AddName(builder, NameOffset);
			BetHorseShooter.AddAppearRate(builder, AppearRate);
			BetHorseShooter.AddMysteryRate(builder, MysteryRate);
			BetHorseShooter.AddID(builder, ID);
			return BetHorseShooter.EndBetHorseShooter(builder);
		}

		// Token: 0x06001AE2 RID: 6882 RVA: 0x00079010 File Offset: 0x00077410
		public static void StartBetHorseShooter(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x0007901A File Offset: 0x0007741A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x00079025 File Offset: 0x00077425
		public static void AddMysteryRate(FlatBufferBuilder builder, int MysteryRate)
		{
			builder.AddInt(1, MysteryRate, 0);
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x00079030 File Offset: 0x00077430
		public static void AddAppearRate(FlatBufferBuilder builder, int AppearRate)
		{
			builder.AddInt(2, AppearRate, 0);
		}

		// Token: 0x06001AE6 RID: 6886 RVA: 0x0007903B File Offset: 0x0007743B
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(3, NameOffset.Value, 0);
		}

		// Token: 0x06001AE7 RID: 6887 RVA: 0x0007904C File Offset: 0x0007744C
		public static void AddOccupationType(FlatBufferBuilder builder, int OccupationType)
		{
			builder.AddInt(4, OccupationType, 0);
		}

		// Token: 0x06001AE8 RID: 6888 RVA: 0x00079057 File Offset: 0x00077457
		public static void AddOccupation(FlatBufferBuilder builder, StringOffset OccupationOffset)
		{
			builder.AddOffset(5, OccupationOffset.Value, 0);
		}

		// Token: 0x06001AE9 RID: 6889 RVA: 0x00079068 File Offset: 0x00077468
		public static void AddOccupationIcon(FlatBufferBuilder builder, StringOffset OccupationIconOffset)
		{
			builder.AddOffset(6, OccupationIconOffset.Value, 0);
		}

		// Token: 0x06001AEA RID: 6890 RVA: 0x00079079 File Offset: 0x00077479
		public static void AddTerrain(FlatBufferBuilder builder, StringOffset TerrainOffset)
		{
			builder.AddOffset(7, TerrainOffset.Value, 0);
		}

		// Token: 0x06001AEB RID: 6891 RVA: 0x0007908A File Offset: 0x0007748A
		public static void AddWeather(FlatBufferBuilder builder, StringOffset WeatherOffset)
		{
			builder.AddOffset(8, WeatherOffset.Value, 0);
		}

		// Token: 0x06001AEC RID: 6892 RVA: 0x0007909B File Offset: 0x0007749B
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(9, IconPathOffset.Value, 0);
		}

		// Token: 0x06001AED RID: 6893 RVA: 0x000790AD File Offset: 0x000774AD
		public static void AddPortraitPath(FlatBufferBuilder builder, StringOffset PortraitPathOffset)
		{
			builder.AddOffset(10, PortraitPathOffset.Value, 0);
		}

		// Token: 0x06001AEE RID: 6894 RVA: 0x000790C0 File Offset: 0x000774C0
		public static Offset<BetHorseShooter> EndBetHorseShooter(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BetHorseShooter>(value);
		}

		// Token: 0x06001AEF RID: 6895 RVA: 0x000790DA File Offset: 0x000774DA
		public static void FinishBetHorseShooterBuffer(FlatBufferBuilder builder, Offset<BetHorseShooter> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EB4 RID: 3764
		private Table __p = new Table();

		// Token: 0x020002DF RID: 735
		public enum eCrypt
		{
			// Token: 0x04000EB6 RID: 3766
			code = -1185171060
		}
	}
}
