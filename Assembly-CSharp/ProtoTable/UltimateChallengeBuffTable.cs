using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000606 RID: 1542
	public class UltimateChallengeBuffTable : IFlatbufferObject
	{
		// Token: 0x17001679 RID: 5753
		// (get) Token: 0x0600516A RID: 20842 RVA: 0x000FAAD4 File Offset: 0x000F8ED4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600516B RID: 20843 RVA: 0x000FAAE1 File Offset: 0x000F8EE1
		public static UltimateChallengeBuffTable GetRootAsUltimateChallengeBuffTable(ByteBuffer _bb)
		{
			return UltimateChallengeBuffTable.GetRootAsUltimateChallengeBuffTable(_bb, new UltimateChallengeBuffTable());
		}

		// Token: 0x0600516C RID: 20844 RVA: 0x000FAAEE File Offset: 0x000F8EEE
		public static UltimateChallengeBuffTable GetRootAsUltimateChallengeBuffTable(ByteBuffer _bb, UltimateChallengeBuffTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600516D RID: 20845 RVA: 0x000FAB0A File Offset: 0x000F8F0A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600516E RID: 20846 RVA: 0x000FAB24 File Offset: 0x000F8F24
		public UltimateChallengeBuffTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700167A RID: 5754
		// (get) Token: 0x0600516F RID: 20847 RVA: 0x000FAB30 File Offset: 0x000F8F30
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1636419005 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700167B RID: 5755
		// (get) Token: 0x06005170 RID: 20848 RVA: 0x000FAB7C File Offset: 0x000F8F7C
		public int buffID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1636419005 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700167C RID: 5756
		// (get) Token: 0x06005171 RID: 20849 RVA: 0x000FABC8 File Offset: 0x000F8FC8
		public string Description
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005172 RID: 20850 RVA: 0x000FAC0A File Offset: 0x000F900A
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700167D RID: 5757
		// (get) Token: 0x06005173 RID: 20851 RVA: 0x000FAC18 File Offset: 0x000F9018
		public int target
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1636419005 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700167E RID: 5758
		// (get) Token: 0x06005174 RID: 20852 RVA: 0x000FAC64 File Offset: 0x000F9064
		public int sustain
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1636419005 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005175 RID: 20853 RVA: 0x000FACAE File Offset: 0x000F90AE
		public static Offset<UltimateChallengeBuffTable> CreateUltimateChallengeBuffTable(FlatBufferBuilder builder, int ID = 0, int buffID = 0, StringOffset DescriptionOffset = default(StringOffset), int target = 0, int sustain = 0)
		{
			builder.StartObject(5);
			UltimateChallengeBuffTable.AddSustain(builder, sustain);
			UltimateChallengeBuffTable.AddTarget(builder, target);
			UltimateChallengeBuffTable.AddDescription(builder, DescriptionOffset);
			UltimateChallengeBuffTable.AddBuffID(builder, buffID);
			UltimateChallengeBuffTable.AddID(builder, ID);
			return UltimateChallengeBuffTable.EndUltimateChallengeBuffTable(builder);
		}

		// Token: 0x06005176 RID: 20854 RVA: 0x000FACE2 File Offset: 0x000F90E2
		public static void StartUltimateChallengeBuffTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06005177 RID: 20855 RVA: 0x000FACEB File Offset: 0x000F90EB
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005178 RID: 20856 RVA: 0x000FACF6 File Offset: 0x000F90F6
		public static void AddBuffID(FlatBufferBuilder builder, int buffID)
		{
			builder.AddInt(1, buffID, 0);
		}

		// Token: 0x06005179 RID: 20857 RVA: 0x000FAD01 File Offset: 0x000F9101
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(2, DescriptionOffset.Value, 0);
		}

		// Token: 0x0600517A RID: 20858 RVA: 0x000FAD12 File Offset: 0x000F9112
		public static void AddTarget(FlatBufferBuilder builder, int target)
		{
			builder.AddInt(3, target, 0);
		}

		// Token: 0x0600517B RID: 20859 RVA: 0x000FAD1D File Offset: 0x000F911D
		public static void AddSustain(FlatBufferBuilder builder, int sustain)
		{
			builder.AddInt(4, sustain, 0);
		}

		// Token: 0x0600517C RID: 20860 RVA: 0x000FAD28 File Offset: 0x000F9128
		public static Offset<UltimateChallengeBuffTable> EndUltimateChallengeBuffTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<UltimateChallengeBuffTable>(value);
		}

		// Token: 0x0600517D RID: 20861 RVA: 0x000FAD42 File Offset: 0x000F9142
		public static void FinishUltimateChallengeBuffTableBuffer(FlatBufferBuilder builder, Offset<UltimateChallengeBuffTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E12 RID: 7698
		private Table __p = new Table();

		// Token: 0x02000607 RID: 1543
		public enum eCrypt
		{
			// Token: 0x04001E14 RID: 7700
			code = -1636419005
		}
	}
}
