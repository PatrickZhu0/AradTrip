using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002A3 RID: 675
	public class AppraisalProbabilityTable : IFlatbufferObject
	{
		// Token: 0x17000381 RID: 897
		// (get) Token: 0x0600180B RID: 6155 RVA: 0x00072B30 File Offset: 0x00070F30
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x00072B3D File Offset: 0x00070F3D
		public static AppraisalProbabilityTable GetRootAsAppraisalProbabilityTable(ByteBuffer _bb)
		{
			return AppraisalProbabilityTable.GetRootAsAppraisalProbabilityTable(_bb, new AppraisalProbabilityTable());
		}

		// Token: 0x0600180D RID: 6157 RVA: 0x00072B4A File Offset: 0x00070F4A
		public static AppraisalProbabilityTable GetRootAsAppraisalProbabilityTable(ByteBuffer _bb, AppraisalProbabilityTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600180E RID: 6158 RVA: 0x00072B66 File Offset: 0x00070F66
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600180F RID: 6159 RVA: 0x00072B80 File Offset: 0x00070F80
		public AppraisalProbabilityTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06001810 RID: 6160 RVA: 0x00072B8C File Offset: 0x00070F8C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1737830770 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06001811 RID: 6161 RVA: 0x00072BD8 File Offset: 0x00070FD8
		public string section
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001812 RID: 6162 RVA: 0x00072C1A File Offset: 0x0007101A
		public ArraySegment<byte>? GetSectionBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06001813 RID: 6163 RVA: 0x00072C28 File Offset: 0x00071028
		public string weight
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001814 RID: 6164 RVA: 0x00072C6A File Offset: 0x0007106A
		public ArraySegment<byte>? GetWeightBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06001815 RID: 6165 RVA: 0x00072C78 File Offset: 0x00071078
		public static Offset<AppraisalProbabilityTable> CreateAppraisalProbabilityTable(FlatBufferBuilder builder, int ID = 0, StringOffset sectionOffset = default(StringOffset), StringOffset weightOffset = default(StringOffset))
		{
			builder.StartObject(3);
			AppraisalProbabilityTable.AddWeight(builder, weightOffset);
			AppraisalProbabilityTable.AddSection(builder, sectionOffset);
			AppraisalProbabilityTable.AddID(builder, ID);
			return AppraisalProbabilityTable.EndAppraisalProbabilityTable(builder);
		}

		// Token: 0x06001816 RID: 6166 RVA: 0x00072C9C File Offset: 0x0007109C
		public static void StartAppraisalProbabilityTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001817 RID: 6167 RVA: 0x00072CA5 File Offset: 0x000710A5
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001818 RID: 6168 RVA: 0x00072CB0 File Offset: 0x000710B0
		public static void AddSection(FlatBufferBuilder builder, StringOffset sectionOffset)
		{
			builder.AddOffset(1, sectionOffset.Value, 0);
		}

		// Token: 0x06001819 RID: 6169 RVA: 0x00072CC1 File Offset: 0x000710C1
		public static void AddWeight(FlatBufferBuilder builder, StringOffset weightOffset)
		{
			builder.AddOffset(2, weightOffset.Value, 0);
		}

		// Token: 0x0600181A RID: 6170 RVA: 0x00072CD4 File Offset: 0x000710D4
		public static Offset<AppraisalProbabilityTable> EndAppraisalProbabilityTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AppraisalProbabilityTable>(value);
		}

		// Token: 0x0600181B RID: 6171 RVA: 0x00072CEE File Offset: 0x000710EE
		public static void FinishAppraisalProbabilityTableBuffer(FlatBufferBuilder builder, Offset<AppraisalProbabilityTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DEE RID: 3566
		private Table __p = new Table();

		// Token: 0x020002A4 RID: 676
		public enum eCrypt
		{
			// Token: 0x04000DF0 RID: 3568
			code = 1737830770
		}
	}
}
