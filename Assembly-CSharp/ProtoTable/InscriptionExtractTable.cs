using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200049F RID: 1183
	public class InscriptionExtractTable : IFlatbufferObject
	{
		// Token: 0x17000E9B RID: 3739
		// (get) Token: 0x060039AD RID: 14765 RVA: 0x000C2E54 File Offset: 0x000C1254
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060039AE RID: 14766 RVA: 0x000C2E61 File Offset: 0x000C1261
		public static InscriptionExtractTable GetRootAsInscriptionExtractTable(ByteBuffer _bb)
		{
			return InscriptionExtractTable.GetRootAsInscriptionExtractTable(_bb, new InscriptionExtractTable());
		}

		// Token: 0x060039AF RID: 14767 RVA: 0x000C2E6E File Offset: 0x000C126E
		public static InscriptionExtractTable GetRootAsInscriptionExtractTable(ByteBuffer _bb, InscriptionExtractTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060039B0 RID: 14768 RVA: 0x000C2E8A File Offset: 0x000C128A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060039B1 RID: 14769 RVA: 0x000C2EA4 File Offset: 0x000C12A4
		public InscriptionExtractTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E9C RID: 3740
		// (get) Token: 0x060039B2 RID: 14770 RVA: 0x000C2EB0 File Offset: 0x000C12B0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1622601877 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E9D RID: 3741
		// (get) Token: 0x060039B3 RID: 14771 RVA: 0x000C2EFC File Offset: 0x000C12FC
		public InscriptionExtractTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(6);
				return (InscriptionExtractTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E9E RID: 3742
		// (get) Token: 0x060039B4 RID: 14772 RVA: 0x000C2F40 File Offset: 0x000C1340
		public string ExtractItemConsume
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060039B5 RID: 14773 RVA: 0x000C2F82 File Offset: 0x000C1382
		public ArraySegment<byte>? GetExtractItemConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000E9F RID: 3743
		// (get) Token: 0x060039B6 RID: 14774 RVA: 0x000C2F90 File Offset: 0x000C1390
		public string ExtractProbability
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060039B7 RID: 14775 RVA: 0x000C2FD3 File Offset: 0x000C13D3
		public ArraySegment<byte>? GetExtractProbabilityBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000EA0 RID: 3744
		// (get) Token: 0x060039B8 RID: 14776 RVA: 0x000C2FE4 File Offset: 0x000C13E4
		public int IsExtract
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1622601877 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EA1 RID: 3745
		// (get) Token: 0x060039B9 RID: 14777 RVA: 0x000C3030 File Offset: 0x000C1430
		public string EncapsuleProbability
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060039BA RID: 14778 RVA: 0x000C3073 File Offset: 0x000C1473
		public ArraySegment<byte>? GetEncapsuleProbabilityBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000EA2 RID: 3746
		// (get) Token: 0x060039BB RID: 14779 RVA: 0x000C3084 File Offset: 0x000C1484
		public string DestroyConsume
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060039BC RID: 14780 RVA: 0x000C30C7 File Offset: 0x000C14C7
		public ArraySegment<byte>? GetDestroyConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000EA3 RID: 3747
		// (get) Token: 0x060039BD RID: 14781 RVA: 0x000C30D8 File Offset: 0x000C14D8
		public string DestroyProbability
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060039BE RID: 14782 RVA: 0x000C311B File Offset: 0x000C151B
		public ArraySegment<byte>? GetDestroyProbabilityBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x060039BF RID: 14783 RVA: 0x000C312C File Offset: 0x000C152C
		public static Offset<InscriptionExtractTable> CreateInscriptionExtractTable(FlatBufferBuilder builder, int ID = 0, InscriptionExtractTable.eColor Color = InscriptionExtractTable.eColor.CL_NONE, StringOffset ExtractItemConsumeOffset = default(StringOffset), StringOffset ExtractProbabilityOffset = default(StringOffset), int IsExtract = 0, StringOffset EncapsuleProbabilityOffset = default(StringOffset), StringOffset DestroyConsumeOffset = default(StringOffset), StringOffset DestroyProbabilityOffset = default(StringOffset))
		{
			builder.StartObject(8);
			InscriptionExtractTable.AddDestroyProbability(builder, DestroyProbabilityOffset);
			InscriptionExtractTable.AddDestroyConsume(builder, DestroyConsumeOffset);
			InscriptionExtractTable.AddEncapsuleProbability(builder, EncapsuleProbabilityOffset);
			InscriptionExtractTable.AddIsExtract(builder, IsExtract);
			InscriptionExtractTable.AddExtractProbability(builder, ExtractProbabilityOffset);
			InscriptionExtractTable.AddExtractItemConsume(builder, ExtractItemConsumeOffset);
			InscriptionExtractTable.AddColor(builder, Color);
			InscriptionExtractTable.AddID(builder, ID);
			return InscriptionExtractTable.EndInscriptionExtractTable(builder);
		}

		// Token: 0x060039C0 RID: 14784 RVA: 0x000C3183 File Offset: 0x000C1583
		public static void StartInscriptionExtractTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x060039C1 RID: 14785 RVA: 0x000C318C File Offset: 0x000C158C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060039C2 RID: 14786 RVA: 0x000C3197 File Offset: 0x000C1597
		public static void AddColor(FlatBufferBuilder builder, InscriptionExtractTable.eColor Color)
		{
			builder.AddInt(1, (int)Color, 0);
		}

		// Token: 0x060039C3 RID: 14787 RVA: 0x000C31A2 File Offset: 0x000C15A2
		public static void AddExtractItemConsume(FlatBufferBuilder builder, StringOffset ExtractItemConsumeOffset)
		{
			builder.AddOffset(2, ExtractItemConsumeOffset.Value, 0);
		}

		// Token: 0x060039C4 RID: 14788 RVA: 0x000C31B3 File Offset: 0x000C15B3
		public static void AddExtractProbability(FlatBufferBuilder builder, StringOffset ExtractProbabilityOffset)
		{
			builder.AddOffset(3, ExtractProbabilityOffset.Value, 0);
		}

		// Token: 0x060039C5 RID: 14789 RVA: 0x000C31C4 File Offset: 0x000C15C4
		public static void AddIsExtract(FlatBufferBuilder builder, int IsExtract)
		{
			builder.AddInt(4, IsExtract, 0);
		}

		// Token: 0x060039C6 RID: 14790 RVA: 0x000C31CF File Offset: 0x000C15CF
		public static void AddEncapsuleProbability(FlatBufferBuilder builder, StringOffset EncapsuleProbabilityOffset)
		{
			builder.AddOffset(5, EncapsuleProbabilityOffset.Value, 0);
		}

		// Token: 0x060039C7 RID: 14791 RVA: 0x000C31E0 File Offset: 0x000C15E0
		public static void AddDestroyConsume(FlatBufferBuilder builder, StringOffset DestroyConsumeOffset)
		{
			builder.AddOffset(6, DestroyConsumeOffset.Value, 0);
		}

		// Token: 0x060039C8 RID: 14792 RVA: 0x000C31F1 File Offset: 0x000C15F1
		public static void AddDestroyProbability(FlatBufferBuilder builder, StringOffset DestroyProbabilityOffset)
		{
			builder.AddOffset(7, DestroyProbabilityOffset.Value, 0);
		}

		// Token: 0x060039C9 RID: 14793 RVA: 0x000C3204 File Offset: 0x000C1604
		public static Offset<InscriptionExtractTable> EndInscriptionExtractTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<InscriptionExtractTable>(value);
		}

		// Token: 0x060039CA RID: 14794 RVA: 0x000C321E File Offset: 0x000C161E
		public static void FinishInscriptionExtractTableBuffer(FlatBufferBuilder builder, Offset<InscriptionExtractTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400163F RID: 5695
		private Table __p = new Table();

		// Token: 0x020004A0 RID: 1184
		public enum eColor
		{
			// Token: 0x04001641 RID: 5697
			CL_NONE,
			// Token: 0x04001642 RID: 5698
			WHITE,
			// Token: 0x04001643 RID: 5699
			BLUE,
			// Token: 0x04001644 RID: 5700
			PURPLE,
			// Token: 0x04001645 RID: 5701
			GREEN,
			// Token: 0x04001646 RID: 5702
			PINK,
			// Token: 0x04001647 RID: 5703
			YELLOW
		}

		// Token: 0x020004A1 RID: 1185
		public enum eCrypt
		{
			// Token: 0x04001649 RID: 5705
			code = -1622601877
		}
	}
}
