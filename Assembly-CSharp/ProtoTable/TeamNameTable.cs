using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005FE RID: 1534
	public class TeamNameTable : IFlatbufferObject
	{
		// Token: 0x17001669 RID: 5737
		// (get) Token: 0x06005128 RID: 20776 RVA: 0x000FA390 File Offset: 0x000F8790
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005129 RID: 20777 RVA: 0x000FA39D File Offset: 0x000F879D
		public static TeamNameTable GetRootAsTeamNameTable(ByteBuffer _bb)
		{
			return TeamNameTable.GetRootAsTeamNameTable(_bb, new TeamNameTable());
		}

		// Token: 0x0600512A RID: 20778 RVA: 0x000FA3AA File Offset: 0x000F87AA
		public static TeamNameTable GetRootAsTeamNameTable(ByteBuffer _bb, TeamNameTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600512B RID: 20779 RVA: 0x000FA3C6 File Offset: 0x000F87C6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600512C RID: 20780 RVA: 0x000FA3E0 File Offset: 0x000F87E0
		public TeamNameTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700166A RID: 5738
		// (get) Token: 0x0600512D RID: 20781 RVA: 0x000FA3EC File Offset: 0x000F87EC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (224544348 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700166B RID: 5739
		// (get) Token: 0x0600512E RID: 20782 RVA: 0x000FA438 File Offset: 0x000F8838
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600512F RID: 20783 RVA: 0x000FA47A File Offset: 0x000F887A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06005130 RID: 20784 RVA: 0x000FA488 File Offset: 0x000F8888
		public static Offset<TeamNameTable> CreateTeamNameTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset))
		{
			builder.StartObject(2);
			TeamNameTable.AddName(builder, NameOffset);
			TeamNameTable.AddID(builder, ID);
			return TeamNameTable.EndTeamNameTable(builder);
		}

		// Token: 0x06005131 RID: 20785 RVA: 0x000FA4A5 File Offset: 0x000F88A5
		public static void StartTeamNameTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06005132 RID: 20786 RVA: 0x000FA4AE File Offset: 0x000F88AE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005133 RID: 20787 RVA: 0x000FA4B9 File Offset: 0x000F88B9
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06005134 RID: 20788 RVA: 0x000FA4CC File Offset: 0x000F88CC
		public static Offset<TeamNameTable> EndTeamNameTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamNameTable>(value);
		}

		// Token: 0x06005135 RID: 20789 RVA: 0x000FA4E6 File Offset: 0x000F88E6
		public static void FinishTeamNameTableBuffer(FlatBufferBuilder builder, Offset<TeamNameTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E06 RID: 7686
		private Table __p = new Table();

		// Token: 0x020005FF RID: 1535
		public enum eCrypt
		{
			// Token: 0x04001E08 RID: 7688
			code = 224544348
		}
	}
}
