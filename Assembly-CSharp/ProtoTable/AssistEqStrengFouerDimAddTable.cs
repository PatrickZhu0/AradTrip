using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002AB RID: 683
	public class AssistEqStrengFouerDimAddTable : IFlatbufferObject
	{
		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06001860 RID: 6240 RVA: 0x00073540 File Offset: 0x00071940
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x0007354D File Offset: 0x0007194D
		public static AssistEqStrengFouerDimAddTable GetRootAsAssistEqStrengFouerDimAddTable(ByteBuffer _bb)
		{
			return AssistEqStrengFouerDimAddTable.GetRootAsAssistEqStrengFouerDimAddTable(_bb, new AssistEqStrengFouerDimAddTable());
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x0007355A File Offset: 0x0007195A
		public static AssistEqStrengFouerDimAddTable GetRootAsAssistEqStrengFouerDimAddTable(ByteBuffer _bb, AssistEqStrengFouerDimAddTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x00073576 File Offset: 0x00071976
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x00073590 File Offset: 0x00071990
		public AssistEqStrengFouerDimAddTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06001865 RID: 6245 RVA: 0x0007359C File Offset: 0x0007199C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1169739646 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06001866 RID: 6246 RVA: 0x000735E8 File Offset: 0x000719E8
		public int Strengthen
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1169739646 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06001867 RID: 6247 RVA: 0x00073634 File Offset: 0x00071A34
		public int Lv
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1169739646 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06001868 RID: 6248 RVA: 0x00073680 File Offset: 0x00071A80
		public AssistEqStrengFouerDimAddTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(10);
				return (AssistEqStrengFouerDimAddTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06001869 RID: 6249 RVA: 0x000736C4 File Offset: 0x00071AC4
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1169739646 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x0600186A RID: 6250 RVA: 0x00073710 File Offset: 0x00071B10
		public int StrengNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1169739646 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x0600186B RID: 6251 RVA: 0x0007375C File Offset: 0x00071B5C
		public int StrengNumPVP
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1169739646 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x0600186C RID: 6252 RVA: 0x000737A8 File Offset: 0x00071BA8
		public int EqScore
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1169739646 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x000737F4 File Offset: 0x00071BF4
		public static Offset<AssistEqStrengFouerDimAddTable> CreateAssistEqStrengFouerDimAddTable(FlatBufferBuilder builder, int ID = 0, int Strengthen = 0, int Lv = 0, AssistEqStrengFouerDimAddTable.eColor Color = AssistEqStrengFouerDimAddTable.eColor.Color_None, int Color2 = 0, int StrengNum = 0, int StrengNumPVP = 0, int EqScore = 0)
		{
			builder.StartObject(8);
			AssistEqStrengFouerDimAddTable.AddEqScore(builder, EqScore);
			AssistEqStrengFouerDimAddTable.AddStrengNumPVP(builder, StrengNumPVP);
			AssistEqStrengFouerDimAddTable.AddStrengNum(builder, StrengNum);
			AssistEqStrengFouerDimAddTable.AddColor2(builder, Color2);
			AssistEqStrengFouerDimAddTable.AddColor(builder, Color);
			AssistEqStrengFouerDimAddTable.AddLv(builder, Lv);
			AssistEqStrengFouerDimAddTable.AddStrengthen(builder, Strengthen);
			AssistEqStrengFouerDimAddTable.AddID(builder, ID);
			return AssistEqStrengFouerDimAddTable.EndAssistEqStrengFouerDimAddTable(builder);
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x0007384B File Offset: 0x00071C4B
		public static void StartAssistEqStrengFouerDimAddTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x00073854 File Offset: 0x00071C54
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x0007385F File Offset: 0x00071C5F
		public static void AddStrengthen(FlatBufferBuilder builder, int Strengthen)
		{
			builder.AddInt(1, Strengthen, 0);
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x0007386A File Offset: 0x00071C6A
		public static void AddLv(FlatBufferBuilder builder, int Lv)
		{
			builder.AddInt(2, Lv, 0);
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x00073875 File Offset: 0x00071C75
		public static void AddColor(FlatBufferBuilder builder, AssistEqStrengFouerDimAddTable.eColor Color)
		{
			builder.AddInt(3, (int)Color, 0);
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x00073880 File Offset: 0x00071C80
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(4, Color2, 0);
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x0007388B File Offset: 0x00071C8B
		public static void AddStrengNum(FlatBufferBuilder builder, int StrengNum)
		{
			builder.AddInt(5, StrengNum, 0);
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x00073896 File Offset: 0x00071C96
		public static void AddStrengNumPVP(FlatBufferBuilder builder, int StrengNumPVP)
		{
			builder.AddInt(6, StrengNumPVP, 0);
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x000738A1 File Offset: 0x00071CA1
		public static void AddEqScore(FlatBufferBuilder builder, int EqScore)
		{
			builder.AddInt(7, EqScore, 0);
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x000738AC File Offset: 0x00071CAC
		public static Offset<AssistEqStrengFouerDimAddTable> EndAssistEqStrengFouerDimAddTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AssistEqStrengFouerDimAddTable>(value);
		}

		// Token: 0x06001878 RID: 6264 RVA: 0x000738C6 File Offset: 0x00071CC6
		public static void FinishAssistEqStrengFouerDimAddTableBuffer(FlatBufferBuilder builder, Offset<AssistEqStrengFouerDimAddTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DFB RID: 3579
		private Table __p = new Table();

		// Token: 0x020002AC RID: 684
		public enum eColor
		{
			// Token: 0x04000DFD RID: 3581
			Color_None,
			// Token: 0x04000DFE RID: 3582
			WHITE,
			// Token: 0x04000DFF RID: 3583
			BLUE,
			// Token: 0x04000E00 RID: 3584
			PURPLE,
			// Token: 0x04000E01 RID: 3585
			GREEN,
			// Token: 0x04000E02 RID: 3586
			PINK,
			// Token: 0x04000E03 RID: 3587
			YELLOW
		}

		// Token: 0x020002AD RID: 685
		public enum eCrypt
		{
			// Token: 0x04000E05 RID: 3589
			code = -1169739646
		}
	}
}
