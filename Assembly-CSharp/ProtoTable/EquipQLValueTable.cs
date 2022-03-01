using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003FA RID: 1018
	public class EquipQLValueTable : IFlatbufferObject
	{
		// Token: 0x17000B3D RID: 2877
		// (get) Token: 0x06002EEF RID: 12015 RVA: 0x000AA048 File Offset: 0x000A8448
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002EF0 RID: 12016 RVA: 0x000AA055 File Offset: 0x000A8455
		public static EquipQLValueTable GetRootAsEquipQLValueTable(ByteBuffer _bb)
		{
			return EquipQLValueTable.GetRootAsEquipQLValueTable(_bb, new EquipQLValueTable());
		}

		// Token: 0x06002EF1 RID: 12017 RVA: 0x000AA062 File Offset: 0x000A8462
		public static EquipQLValueTable GetRootAsEquipQLValueTable(ByteBuffer _bb, EquipQLValueTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002EF2 RID: 12018 RVA: 0x000AA07E File Offset: 0x000A847E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002EF3 RID: 12019 RVA: 0x000AA098 File Offset: 0x000A8498
		public EquipQLValueTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B3E RID: 2878
		// (get) Token: 0x06002EF4 RID: 12020 RVA: 0x000AA0A4 File Offset: 0x000A84A4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B3F RID: 2879
		// (get) Token: 0x06002EF5 RID: 12021 RVA: 0x000AA0F0 File Offset: 0x000A84F0
		public EquipQLValueTable.ePart Part
		{
			get
			{
				int num = this.__p.__offset(6);
				return (EquipQLValueTable.ePart)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B40 RID: 2880
		// (get) Token: 0x06002EF6 RID: 12022 RVA: 0x000AA134 File Offset: 0x000A8534
		public int AtkDef
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B41 RID: 2881
		// (get) Token: 0x06002EF7 RID: 12023 RVA: 0x000AA180 File Offset: 0x000A8580
		public int FourDimensional
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B42 RID: 2882
		// (get) Token: 0x06002EF8 RID: 12024 RVA: 0x000AA1CC File Offset: 0x000A85CC
		public int PerfectAtkDef
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B43 RID: 2883
		// (get) Token: 0x06002EF9 RID: 12025 RVA: 0x000AA218 File Offset: 0x000A8618
		public int PerfectFourDimensional
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B44 RID: 2884
		// (get) Token: 0x06002EFA RID: 12026 RVA: 0x000AA264 File Offset: 0x000A8664
		public int StrProp
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B45 RID: 2885
		// (get) Token: 0x06002EFB RID: 12027 RVA: 0x000AA2B0 File Offset: 0x000A86B0
		public int PerfectStrProp
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B46 RID: 2886
		// (get) Token: 0x06002EFC RID: 12028 RVA: 0x000AA2FC File Offset: 0x000A86FC
		public int DefProp
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B47 RID: 2887
		// (get) Token: 0x06002EFD RID: 12029 RVA: 0x000AA348 File Offset: 0x000A8748
		public int PerfectDefProp
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B48 RID: 2888
		// (get) Token: 0x06002EFE RID: 12030 RVA: 0x000AA394 File Offset: 0x000A8794
		public int AbnormalResists
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B49 RID: 2889
		// (get) Token: 0x06002EFF RID: 12031 RVA: 0x000AA3E0 File Offset: 0x000A87E0
		public int PerfectAbnormalResists
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B4A RID: 2890
		// (get) Token: 0x06002F00 RID: 12032 RVA: 0x000AA42C File Offset: 0x000A882C
		public int IndependentResists
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B4B RID: 2891
		// (get) Token: 0x06002F01 RID: 12033 RVA: 0x000AA478 File Offset: 0x000A8878
		public int PerfectIndependentResists
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (571032840 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002F02 RID: 12034 RVA: 0x000AA4C4 File Offset: 0x000A88C4
		public static Offset<EquipQLValueTable> CreateEquipQLValueTable(FlatBufferBuilder builder, int ID = 0, EquipQLValueTable.ePart Part = EquipQLValueTable.ePart.NONE, int AtkDef = 0, int FourDimensional = 0, int PerfectAtkDef = 0, int PerfectFourDimensional = 0, int StrProp = 0, int PerfectStrProp = 0, int DefProp = 0, int PerfectDefProp = 0, int AbnormalResists = 0, int PerfectAbnormalResists = 0, int IndependentResists = 0, int PerfectIndependentResists = 0)
		{
			builder.StartObject(14);
			EquipQLValueTable.AddPerfectIndependentResists(builder, PerfectIndependentResists);
			EquipQLValueTable.AddIndependentResists(builder, IndependentResists);
			EquipQLValueTable.AddPerfectAbnormalResists(builder, PerfectAbnormalResists);
			EquipQLValueTable.AddAbnormalResists(builder, AbnormalResists);
			EquipQLValueTable.AddPerfectDefProp(builder, PerfectDefProp);
			EquipQLValueTable.AddDefProp(builder, DefProp);
			EquipQLValueTable.AddPerfectStrProp(builder, PerfectStrProp);
			EquipQLValueTable.AddStrProp(builder, StrProp);
			EquipQLValueTable.AddPerfectFourDimensional(builder, PerfectFourDimensional);
			EquipQLValueTable.AddPerfectAtkDef(builder, PerfectAtkDef);
			EquipQLValueTable.AddFourDimensional(builder, FourDimensional);
			EquipQLValueTable.AddAtkDef(builder, AtkDef);
			EquipQLValueTable.AddPart(builder, Part);
			EquipQLValueTable.AddID(builder, ID);
			return EquipQLValueTable.EndEquipQLValueTable(builder);
		}

		// Token: 0x06002F03 RID: 12035 RVA: 0x000AA54C File Offset: 0x000A894C
		public static void StartEquipQLValueTable(FlatBufferBuilder builder)
		{
			builder.StartObject(14);
		}

		// Token: 0x06002F04 RID: 12036 RVA: 0x000AA556 File Offset: 0x000A8956
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002F05 RID: 12037 RVA: 0x000AA561 File Offset: 0x000A8961
		public static void AddPart(FlatBufferBuilder builder, EquipQLValueTable.ePart Part)
		{
			builder.AddInt(1, (int)Part, 0);
		}

		// Token: 0x06002F06 RID: 12038 RVA: 0x000AA56C File Offset: 0x000A896C
		public static void AddAtkDef(FlatBufferBuilder builder, int AtkDef)
		{
			builder.AddInt(2, AtkDef, 0);
		}

		// Token: 0x06002F07 RID: 12039 RVA: 0x000AA577 File Offset: 0x000A8977
		public static void AddFourDimensional(FlatBufferBuilder builder, int FourDimensional)
		{
			builder.AddInt(3, FourDimensional, 0);
		}

		// Token: 0x06002F08 RID: 12040 RVA: 0x000AA582 File Offset: 0x000A8982
		public static void AddPerfectAtkDef(FlatBufferBuilder builder, int PerfectAtkDef)
		{
			builder.AddInt(4, PerfectAtkDef, 0);
		}

		// Token: 0x06002F09 RID: 12041 RVA: 0x000AA58D File Offset: 0x000A898D
		public static void AddPerfectFourDimensional(FlatBufferBuilder builder, int PerfectFourDimensional)
		{
			builder.AddInt(5, PerfectFourDimensional, 0);
		}

		// Token: 0x06002F0A RID: 12042 RVA: 0x000AA598 File Offset: 0x000A8998
		public static void AddStrProp(FlatBufferBuilder builder, int StrProp)
		{
			builder.AddInt(6, StrProp, 0);
		}

		// Token: 0x06002F0B RID: 12043 RVA: 0x000AA5A3 File Offset: 0x000A89A3
		public static void AddPerfectStrProp(FlatBufferBuilder builder, int PerfectStrProp)
		{
			builder.AddInt(7, PerfectStrProp, 0);
		}

		// Token: 0x06002F0C RID: 12044 RVA: 0x000AA5AE File Offset: 0x000A89AE
		public static void AddDefProp(FlatBufferBuilder builder, int DefProp)
		{
			builder.AddInt(8, DefProp, 0);
		}

		// Token: 0x06002F0D RID: 12045 RVA: 0x000AA5B9 File Offset: 0x000A89B9
		public static void AddPerfectDefProp(FlatBufferBuilder builder, int PerfectDefProp)
		{
			builder.AddInt(9, PerfectDefProp, 0);
		}

		// Token: 0x06002F0E RID: 12046 RVA: 0x000AA5C5 File Offset: 0x000A89C5
		public static void AddAbnormalResists(FlatBufferBuilder builder, int AbnormalResists)
		{
			builder.AddInt(10, AbnormalResists, 0);
		}

		// Token: 0x06002F0F RID: 12047 RVA: 0x000AA5D1 File Offset: 0x000A89D1
		public static void AddPerfectAbnormalResists(FlatBufferBuilder builder, int PerfectAbnormalResists)
		{
			builder.AddInt(11, PerfectAbnormalResists, 0);
		}

		// Token: 0x06002F10 RID: 12048 RVA: 0x000AA5DD File Offset: 0x000A89DD
		public static void AddIndependentResists(FlatBufferBuilder builder, int IndependentResists)
		{
			builder.AddInt(12, IndependentResists, 0);
		}

		// Token: 0x06002F11 RID: 12049 RVA: 0x000AA5E9 File Offset: 0x000A89E9
		public static void AddPerfectIndependentResists(FlatBufferBuilder builder, int PerfectIndependentResists)
		{
			builder.AddInt(13, PerfectIndependentResists, 0);
		}

		// Token: 0x06002F12 RID: 12050 RVA: 0x000AA5F8 File Offset: 0x000A89F8
		public static Offset<EquipQLValueTable> EndEquipQLValueTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipQLValueTable>(value);
		}

		// Token: 0x06002F13 RID: 12051 RVA: 0x000AA612 File Offset: 0x000A8A12
		public static void FinishEquipQLValueTableBuffer(FlatBufferBuilder builder, Offset<EquipQLValueTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040013A0 RID: 5024
		private Table __p = new Table();

		// Token: 0x020003FB RID: 1019
		public enum ePart
		{
			// Token: 0x040013A2 RID: 5026
			NONE,
			// Token: 0x040013A3 RID: 5027
			WEAPON,
			// Token: 0x040013A4 RID: 5028
			CLOTH,
			// Token: 0x040013A5 RID: 5029
			LEATHER,
			// Token: 0x040013A6 RID: 5030
			HEAVY,
			// Token: 0x040013A7 RID: 5031
			PLATE,
			// Token: 0x040013A8 RID: 5032
			LIGHT,
			// Token: 0x040013A9 RID: 5033
			JEWELRY,
			// Token: 0x040013AA RID: 5034
			ASSIST,
			// Token: 0x040013AB RID: 5035
			MAGICSTONE,
			// Token: 0x040013AC RID: 5036
			EARRINGS
		}

		// Token: 0x020003FC RID: 1020
		public enum eCrypt
		{
			// Token: 0x040013AE RID: 5038
			code = 571032840
		}
	}
}
