using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004A6 RID: 1190
	public class InscriptionSynthesisTable : IFlatbufferObject
	{
		// Token: 0x17000EAE RID: 3758
		// (get) Token: 0x060039F5 RID: 14837 RVA: 0x000C3710 File Offset: 0x000C1B10
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060039F6 RID: 14838 RVA: 0x000C371D File Offset: 0x000C1B1D
		public static InscriptionSynthesisTable GetRootAsInscriptionSynthesisTable(ByteBuffer _bb)
		{
			return InscriptionSynthesisTable.GetRootAsInscriptionSynthesisTable(_bb, new InscriptionSynthesisTable());
		}

		// Token: 0x060039F7 RID: 14839 RVA: 0x000C372A File Offset: 0x000C1B2A
		public static InscriptionSynthesisTable GetRootAsInscriptionSynthesisTable(ByteBuffer _bb, InscriptionSynthesisTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060039F8 RID: 14840 RVA: 0x000C3746 File Offset: 0x000C1B46
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060039F9 RID: 14841 RVA: 0x000C3760 File Offset: 0x000C1B60
		public InscriptionSynthesisTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EAF RID: 3759
		// (get) Token: 0x060039FA RID: 14842 RVA: 0x000C376C File Offset: 0x000C1B6C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (913657090 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EB0 RID: 3760
		// (get) Token: 0x060039FB RID: 14843 RVA: 0x000C37B8 File Offset: 0x000C1BB8
		public InscriptionSynthesisTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(6);
				return (InscriptionSynthesisTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EB1 RID: 3761
		// (get) Token: 0x060039FC RID: 14844 RVA: 0x000C37FC File Offset: 0x000C1BFC
		public int SynthesisNum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (913657090 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EB2 RID: 3762
		// (get) Token: 0x060039FD RID: 14845 RVA: 0x000C3848 File Offset: 0x000C1C48
		public string GenerateInscription
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060039FE RID: 14846 RVA: 0x000C388B File Offset: 0x000C1C8B
		public ArraySegment<byte>? GetGenerateInscriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000EB3 RID: 3763
		// (get) Token: 0x060039FF RID: 14847 RVA: 0x000C389C File Offset: 0x000C1C9C
		public int IsMaxSynthesisNum
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (913657090 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EB4 RID: 3764
		// (get) Token: 0x06003A00 RID: 14848 RVA: 0x000C38E8 File Offset: 0x000C1CE8
		public string GenerateInscriptionPreView
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003A01 RID: 14849 RVA: 0x000C392B File Offset: 0x000C1D2B
		public ArraySegment<byte>? GetGenerateInscriptionPreViewBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x06003A02 RID: 14850 RVA: 0x000C393A File Offset: 0x000C1D3A
		public static Offset<InscriptionSynthesisTable> CreateInscriptionSynthesisTable(FlatBufferBuilder builder, int ID = 0, InscriptionSynthesisTable.eColor Color = InscriptionSynthesisTable.eColor.CL_NONE, int SynthesisNum = 0, StringOffset GenerateInscriptionOffset = default(StringOffset), int IsMaxSynthesisNum = 0, StringOffset GenerateInscriptionPreViewOffset = default(StringOffset))
		{
			builder.StartObject(6);
			InscriptionSynthesisTable.AddGenerateInscriptionPreView(builder, GenerateInscriptionPreViewOffset);
			InscriptionSynthesisTable.AddIsMaxSynthesisNum(builder, IsMaxSynthesisNum);
			InscriptionSynthesisTable.AddGenerateInscription(builder, GenerateInscriptionOffset);
			InscriptionSynthesisTable.AddSynthesisNum(builder, SynthesisNum);
			InscriptionSynthesisTable.AddColor(builder, Color);
			InscriptionSynthesisTable.AddID(builder, ID);
			return InscriptionSynthesisTable.EndInscriptionSynthesisTable(builder);
		}

		// Token: 0x06003A03 RID: 14851 RVA: 0x000C3976 File Offset: 0x000C1D76
		public static void StartInscriptionSynthesisTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06003A04 RID: 14852 RVA: 0x000C397F File Offset: 0x000C1D7F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003A05 RID: 14853 RVA: 0x000C398A File Offset: 0x000C1D8A
		public static void AddColor(FlatBufferBuilder builder, InscriptionSynthesisTable.eColor Color)
		{
			builder.AddInt(1, (int)Color, 0);
		}

		// Token: 0x06003A06 RID: 14854 RVA: 0x000C3995 File Offset: 0x000C1D95
		public static void AddSynthesisNum(FlatBufferBuilder builder, int SynthesisNum)
		{
			builder.AddInt(2, SynthesisNum, 0);
		}

		// Token: 0x06003A07 RID: 14855 RVA: 0x000C39A0 File Offset: 0x000C1DA0
		public static void AddGenerateInscription(FlatBufferBuilder builder, StringOffset GenerateInscriptionOffset)
		{
			builder.AddOffset(3, GenerateInscriptionOffset.Value, 0);
		}

		// Token: 0x06003A08 RID: 14856 RVA: 0x000C39B1 File Offset: 0x000C1DB1
		public static void AddIsMaxSynthesisNum(FlatBufferBuilder builder, int IsMaxSynthesisNum)
		{
			builder.AddInt(4, IsMaxSynthesisNum, 0);
		}

		// Token: 0x06003A09 RID: 14857 RVA: 0x000C39BC File Offset: 0x000C1DBC
		public static void AddGenerateInscriptionPreView(FlatBufferBuilder builder, StringOffset GenerateInscriptionPreViewOffset)
		{
			builder.AddOffset(5, GenerateInscriptionPreViewOffset.Value, 0);
		}

		// Token: 0x06003A0A RID: 14858 RVA: 0x000C39D0 File Offset: 0x000C1DD0
		public static Offset<InscriptionSynthesisTable> EndInscriptionSynthesisTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<InscriptionSynthesisTable>(value);
		}

		// Token: 0x06003A0B RID: 14859 RVA: 0x000C39EA File Offset: 0x000C1DEA
		public static void FinishInscriptionSynthesisTableBuffer(FlatBufferBuilder builder, Offset<InscriptionSynthesisTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001651 RID: 5713
		private Table __p = new Table();

		// Token: 0x020004A7 RID: 1191
		public enum eColor
		{
			// Token: 0x04001653 RID: 5715
			CL_NONE,
			// Token: 0x04001654 RID: 5716
			WHITE,
			// Token: 0x04001655 RID: 5717
			BLUE,
			// Token: 0x04001656 RID: 5718
			PURPLE,
			// Token: 0x04001657 RID: 5719
			GREEN,
			// Token: 0x04001658 RID: 5720
			PINK,
			// Token: 0x04001659 RID: 5721
			YELLOW
		}

		// Token: 0x020004A8 RID: 1192
		public enum eCrypt
		{
			// Token: 0x0400165B RID: 5723
			code = 913657090
		}
	}
}
