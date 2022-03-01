using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004A4 RID: 1188
	public class InscriptionProbabilityTable : IFlatbufferObject
	{
		// Token: 0x17000EA9 RID: 3753
		// (get) Token: 0x060039E2 RID: 14818 RVA: 0x000C34D8 File Offset: 0x000C18D8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060039E3 RID: 14819 RVA: 0x000C34E5 File Offset: 0x000C18E5
		public static InscriptionProbabilityTable GetRootAsInscriptionProbabilityTable(ByteBuffer _bb)
		{
			return InscriptionProbabilityTable.GetRootAsInscriptionProbabilityTable(_bb, new InscriptionProbabilityTable());
		}

		// Token: 0x060039E4 RID: 14820 RVA: 0x000C34F2 File Offset: 0x000C18F2
		public static InscriptionProbabilityTable GetRootAsInscriptionProbabilityTable(ByteBuffer _bb, InscriptionProbabilityTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060039E5 RID: 14821 RVA: 0x000C350E File Offset: 0x000C190E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060039E6 RID: 14822 RVA: 0x000C3528 File Offset: 0x000C1928
		public InscriptionProbabilityTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EAA RID: 3754
		// (get) Token: 0x060039E7 RID: 14823 RVA: 0x000C3534 File Offset: 0x000C1934
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (209140199 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EAB RID: 3755
		// (get) Token: 0x060039E8 RID: 14824 RVA: 0x000C3580 File Offset: 0x000C1980
		public int MinProbability
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (209140199 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EAC RID: 3756
		// (get) Token: 0x060039E9 RID: 14825 RVA: 0x000C35CC File Offset: 0x000C19CC
		public int MaxProbability
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (209140199 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EAD RID: 3757
		// (get) Token: 0x060039EA RID: 14826 RVA: 0x000C3618 File Offset: 0x000C1A18
		public string SuccessName
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060039EB RID: 14827 RVA: 0x000C365B File Offset: 0x000C1A5B
		public ArraySegment<byte>? GetSuccessNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x060039EC RID: 14828 RVA: 0x000C366A File Offset: 0x000C1A6A
		public static Offset<InscriptionProbabilityTable> CreateInscriptionProbabilityTable(FlatBufferBuilder builder, int ID = 0, int MinProbability = 0, int MaxProbability = 0, StringOffset SuccessNameOffset = default(StringOffset))
		{
			builder.StartObject(4);
			InscriptionProbabilityTable.AddSuccessName(builder, SuccessNameOffset);
			InscriptionProbabilityTable.AddMaxProbability(builder, MaxProbability);
			InscriptionProbabilityTable.AddMinProbability(builder, MinProbability);
			InscriptionProbabilityTable.AddID(builder, ID);
			return InscriptionProbabilityTable.EndInscriptionProbabilityTable(builder);
		}

		// Token: 0x060039ED RID: 14829 RVA: 0x000C3696 File Offset: 0x000C1A96
		public static void StartInscriptionProbabilityTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x060039EE RID: 14830 RVA: 0x000C369F File Offset: 0x000C1A9F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060039EF RID: 14831 RVA: 0x000C36AA File Offset: 0x000C1AAA
		public static void AddMinProbability(FlatBufferBuilder builder, int MinProbability)
		{
			builder.AddInt(1, MinProbability, 0);
		}

		// Token: 0x060039F0 RID: 14832 RVA: 0x000C36B5 File Offset: 0x000C1AB5
		public static void AddMaxProbability(FlatBufferBuilder builder, int MaxProbability)
		{
			builder.AddInt(2, MaxProbability, 0);
		}

		// Token: 0x060039F1 RID: 14833 RVA: 0x000C36C0 File Offset: 0x000C1AC0
		public static void AddSuccessName(FlatBufferBuilder builder, StringOffset SuccessNameOffset)
		{
			builder.AddOffset(3, SuccessNameOffset.Value, 0);
		}

		// Token: 0x060039F2 RID: 14834 RVA: 0x000C36D4 File Offset: 0x000C1AD4
		public static Offset<InscriptionProbabilityTable> EndInscriptionProbabilityTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<InscriptionProbabilityTable>(value);
		}

		// Token: 0x060039F3 RID: 14835 RVA: 0x000C36EE File Offset: 0x000C1AEE
		public static void FinishInscriptionProbabilityTableBuffer(FlatBufferBuilder builder, Offset<InscriptionProbabilityTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400164E RID: 5710
		private Table __p = new Table();

		// Token: 0x020004A5 RID: 1189
		public enum eCrypt
		{
			// Token: 0x04001650 RID: 5712
			code = 209140199
		}
	}
}
