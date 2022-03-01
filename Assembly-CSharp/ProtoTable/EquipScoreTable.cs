using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000405 RID: 1029
	public class EquipScoreTable : IFlatbufferObject
	{
		// Token: 0x17000B64 RID: 2916
		// (get) Token: 0x06002F6F RID: 12143 RVA: 0x000AB11C File Offset: 0x000A951C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002F70 RID: 12144 RVA: 0x000AB129 File Offset: 0x000A9529
		public static EquipScoreTable GetRootAsEquipScoreTable(ByteBuffer _bb)
		{
			return EquipScoreTable.GetRootAsEquipScoreTable(_bb, new EquipScoreTable());
		}

		// Token: 0x06002F71 RID: 12145 RVA: 0x000AB136 File Offset: 0x000A9536
		public static EquipScoreTable GetRootAsEquipScoreTable(ByteBuffer _bb, EquipScoreTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002F72 RID: 12146 RVA: 0x000AB152 File Offset: 0x000A9552
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002F73 RID: 12147 RVA: 0x000AB16C File Offset: 0x000A956C
		public EquipScoreTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B65 RID: 2917
		// (get) Token: 0x06002F74 RID: 12148 RVA: 0x000AB178 File Offset: 0x000A9578
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (265134066 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B66 RID: 2918
		// (get) Token: 0x06002F75 RID: 12149 RVA: 0x000AB1C4 File Offset: 0x000A95C4
		public EquipScoreTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (EquipScoreTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B67 RID: 2919
		// (get) Token: 0x06002F76 RID: 12150 RVA: 0x000AB208 File Offset: 0x000A9608
		public int Value
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (265134066 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002F77 RID: 12151 RVA: 0x000AB251 File Offset: 0x000A9651
		public static Offset<EquipScoreTable> CreateEquipScoreTable(FlatBufferBuilder builder, int ID = 0, EquipScoreTable.eType Type = EquipScoreTable.eType.None, int Value = 0)
		{
			builder.StartObject(3);
			EquipScoreTable.AddValue(builder, Value);
			EquipScoreTable.AddType(builder, Type);
			EquipScoreTable.AddID(builder, ID);
			return EquipScoreTable.EndEquipScoreTable(builder);
		}

		// Token: 0x06002F78 RID: 12152 RVA: 0x000AB275 File Offset: 0x000A9675
		public static void StartEquipScoreTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06002F79 RID: 12153 RVA: 0x000AB27E File Offset: 0x000A967E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002F7A RID: 12154 RVA: 0x000AB289 File Offset: 0x000A9689
		public static void AddType(FlatBufferBuilder builder, EquipScoreTable.eType Type)
		{
			builder.AddInt(1, (int)Type, 0);
		}

		// Token: 0x06002F7B RID: 12155 RVA: 0x000AB294 File Offset: 0x000A9694
		public static void AddValue(FlatBufferBuilder builder, int Value)
		{
			builder.AddInt(2, Value, 0);
		}

		// Token: 0x06002F7C RID: 12156 RVA: 0x000AB2A0 File Offset: 0x000A96A0
		public static Offset<EquipScoreTable> EndEquipScoreTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipScoreTable>(value);
		}

		// Token: 0x06002F7D RID: 12157 RVA: 0x000AB2BA File Offset: 0x000A96BA
		public static void FinishEquipScoreTableBuffer(FlatBufferBuilder builder, Offset<EquipScoreTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040013BC RID: 5052
		private Table __p = new Table();

		// Token: 0x02000406 RID: 1030
		public enum eType
		{
			// Token: 0x040013BE RID: 5054
			None,
			// Token: 0x040013BF RID: 5055
			STR,
			// Token: 0x040013C0 RID: 5056
			INT,
			// Token: 0x040013C1 RID: 5057
			STAM,
			// Token: 0x040013C2 RID: 5058
			SPR,
			// Token: 0x040013C3 RID: 5059
			HP,
			// Token: 0x040013C4 RID: 5060
			MP,
			// Token: 0x040013C5 RID: 5061
			HPRECVR,
			// Token: 0x040013C6 RID: 5062
			MPRECVR,
			// Token: 0x040013C7 RID: 5063
			PHYATK,
			// Token: 0x040013C8 RID: 5064
			MAGATK,
			// Token: 0x040013C9 RID: 5065
			PHYDEF,
			// Token: 0x040013CA RID: 5066
			MAGDEF,
			// Token: 0x040013CB RID: 5067
			DISPHYATK,
			// Token: 0x040013CC RID: 5068
			DISMAGATK,
			// Token: 0x040013CD RID: 5069
			PHYDMGRDC,
			// Token: 0x040013CE RID: 5070
			MAGDMGRDC,
			// Token: 0x040013CF RID: 5071
			ATKSPD,
			// Token: 0x040013D0 RID: 5072
			MAGSPD,
			// Token: 0x040013D1 RID: 5073
			MVSPD,
			// Token: 0x040013D2 RID: 5074
			PHYCRT,
			// Token: 0x040013D3 RID: 5075
			MAGCRT,
			// Token: 0x040013D4 RID: 5076
			CRTDMG,
			// Token: 0x040013D5 RID: 5077
			HIT,
			// Token: 0x040013D6 RID: 5078
			MISS,
			// Token: 0x040013D7 RID: 5079
			JZ,
			// Token: 0x040013D8 RID: 5080
			YZ,
			// Token: 0x040013D9 RID: 5081
			Light,
			// Token: 0x040013DA RID: 5082
			Fire,
			// Token: 0x040013DB RID: 5083
			Ice,
			// Token: 0x040013DC RID: 5084
			Dark,
			// Token: 0x040013DD RID: 5085
			LightAttack,
			// Token: 0x040013DE RID: 5086
			FireAttack,
			// Token: 0x040013DF RID: 5087
			IceAttack,
			// Token: 0x040013E0 RID: 5088
			DarkAttack,
			// Token: 0x040013E1 RID: 5089
			LightDefence,
			// Token: 0x040013E2 RID: 5090
			FireDefence,
			// Token: 0x040013E3 RID: 5091
			IceDefence,
			// Token: 0x040013E4 RID: 5092
			DarkDefence,
			// Token: 0x040013E5 RID: 5093
			GDKX,
			// Token: 0x040013E6 RID: 5094
			CXKX,
			// Token: 0x040013E7 RID: 5095
			ZSKX,
			// Token: 0x040013E8 RID: 5096
			ZDKX,
			// Token: 0x040013E9 RID: 5097
			SMKX,
			// Token: 0x040013EA RID: 5098
			XYKX,
			// Token: 0x040013EB RID: 5099
			SHKX,
			// Token: 0x040013EC RID: 5100
			BDKX,
			// Token: 0x040013ED RID: 5101
			SLKX,
			// Token: 0x040013EE RID: 5102
			HLKX,
			// Token: 0x040013EF RID: 5103
			SFKX,
			// Token: 0x040013F0 RID: 5104
			JSKX,
			// Token: 0x040013F1 RID: 5105
			ZZKX,
			// Token: 0x040013F2 RID: 5106
			HSWORD = 100,
			// Token: 0x040013F3 RID: 5107
			TD,
			// Token: 0x040013F4 RID: 5108
			ZL,
			// Token: 0x040013F5 RID: 5109
			SP,
			// Token: 0x040013F6 RID: 5110
			FZ,
			// Token: 0x040013F7 RID: 5111
			MZ,
			// Token: 0x040013F8 RID: 5112
			BJ,
			// Token: 0x040013F9 RID: 5113
			PJ,
			// Token: 0x040013FA RID: 5114
			DJ,
			// Token: 0x040013FB RID: 5115
			QJ,
			// Token: 0x040013FC RID: 5116
			ZJ,
			// Token: 0x040013FD RID: 5117
			BA,
			// Token: 0x040013FE RID: 5118
			OFG,
			// Token: 0x040013FF RID: 5119
			EAST_STICK,
			// Token: 0x04001400 RID: 5120
			GLOVE,
			// Token: 0x04001401 RID: 5121
			BIKAI,
			// Token: 0x04001402 RID: 5122
			CLAW,
			// Token: 0x04001403 RID: 5123
			NUJIAN,
			// Token: 0x04001404 RID: 5124
			BUQIANG,
			// Token: 0x04001405 RID: 5125
			GUANGJIAN,
			// Token: 0x04001406 RID: 5126
			SICKLE,
			// Token: 0x04001407 RID: 5127
			TOTEM,
			// Token: 0x04001408 RID: 5128
			AXE,
			// Token: 0x04001409 RID: 5129
			BEADS,
			// Token: 0x0400140A RID: 5130
			CROSS,
			// Token: 0x0400140B RID: 5131
			SPEAR,
			// Token: 0x0400140C RID: 5132
			STICK,
			// Token: 0x0400140D RID: 5133
			ATTACK = 200,
			// Token: 0x0400140E RID: 5134
			POWER,
			// Token: 0x0400140F RID: 5135
			REDUCE,
			// Token: 0x04001410 RID: 5136
			DISPHYATTACK,
			// Token: 0x04001411 RID: 5137
			DISPHYREDUCE,
			// Token: 0x04001412 RID: 5138
			FUJIA,
			// Token: 0x04001413 RID: 5139
			Independent
		}

		// Token: 0x02000407 RID: 1031
		public enum eCrypt
		{
			// Token: 0x04001415 RID: 5141
			code = 265134066
		}
	}
}
