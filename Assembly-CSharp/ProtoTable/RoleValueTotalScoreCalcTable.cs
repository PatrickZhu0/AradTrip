using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200058B RID: 1419
	public class RoleValueTotalScoreCalcTable : IFlatbufferObject
	{
		// Token: 0x170013F6 RID: 5110
		// (get) Token: 0x060049A5 RID: 18853 RVA: 0x000E8944 File Offset: 0x000E6D44
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060049A6 RID: 18854 RVA: 0x000E8951 File Offset: 0x000E6D51
		public static RoleValueTotalScoreCalcTable GetRootAsRoleValueTotalScoreCalcTable(ByteBuffer _bb)
		{
			return RoleValueTotalScoreCalcTable.GetRootAsRoleValueTotalScoreCalcTable(_bb, new RoleValueTotalScoreCalcTable());
		}

		// Token: 0x060049A7 RID: 18855 RVA: 0x000E895E File Offset: 0x000E6D5E
		public static RoleValueTotalScoreCalcTable GetRootAsRoleValueTotalScoreCalcTable(ByteBuffer _bb, RoleValueTotalScoreCalcTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060049A8 RID: 18856 RVA: 0x000E897A File Offset: 0x000E6D7A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060049A9 RID: 18857 RVA: 0x000E8994 File Offset: 0x000E6D94
		public RoleValueTotalScoreCalcTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170013F7 RID: 5111
		// (get) Token: 0x060049AA RID: 18858 RVA: 0x000E89A0 File Offset: 0x000E6DA0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-294344558 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013F8 RID: 5112
		// (get) Token: 0x060049AB RID: 18859 RVA: 0x000E89EC File Offset: 0x000E6DEC
		public string AllRoleValueScoreLevel
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060049AC RID: 18860 RVA: 0x000E8A2E File Offset: 0x000E6E2E
		public ArraySegment<byte>? GetAllRoleValueScoreLevelBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170013F9 RID: 5113
		// (get) Token: 0x060049AD RID: 18861 RVA: 0x000E8A3C File Offset: 0x000E6E3C
		public int RoleValueScoreProb
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-294344558 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060049AE RID: 18862 RVA: 0x000E8A85 File Offset: 0x000E6E85
		public static Offset<RoleValueTotalScoreCalcTable> CreateRoleValueTotalScoreCalcTable(FlatBufferBuilder builder, int ID = 0, StringOffset AllRoleValueScoreLevelOffset = default(StringOffset), int RoleValueScoreProb = 0)
		{
			builder.StartObject(3);
			RoleValueTotalScoreCalcTable.AddRoleValueScoreProb(builder, RoleValueScoreProb);
			RoleValueTotalScoreCalcTable.AddAllRoleValueScoreLevel(builder, AllRoleValueScoreLevelOffset);
			RoleValueTotalScoreCalcTable.AddID(builder, ID);
			return RoleValueTotalScoreCalcTable.EndRoleValueTotalScoreCalcTable(builder);
		}

		// Token: 0x060049AF RID: 18863 RVA: 0x000E8AA9 File Offset: 0x000E6EA9
		public static void StartRoleValueTotalScoreCalcTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x060049B0 RID: 18864 RVA: 0x000E8AB2 File Offset: 0x000E6EB2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060049B1 RID: 18865 RVA: 0x000E8ABD File Offset: 0x000E6EBD
		public static void AddAllRoleValueScoreLevel(FlatBufferBuilder builder, StringOffset AllRoleValueScoreLevelOffset)
		{
			builder.AddOffset(1, AllRoleValueScoreLevelOffset.Value, 0);
		}

		// Token: 0x060049B2 RID: 18866 RVA: 0x000E8ACE File Offset: 0x000E6ECE
		public static void AddRoleValueScoreProb(FlatBufferBuilder builder, int RoleValueScoreProb)
		{
			builder.AddInt(2, RoleValueScoreProb, 0);
		}

		// Token: 0x060049B3 RID: 18867 RVA: 0x000E8ADC File Offset: 0x000E6EDC
		public static Offset<RoleValueTotalScoreCalcTable> EndRoleValueTotalScoreCalcTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RoleValueTotalScoreCalcTable>(value);
		}

		// Token: 0x060049B4 RID: 18868 RVA: 0x000E8AF6 File Offset: 0x000E6EF6
		public static void FinishRoleValueTotalScoreCalcTableBuffer(FlatBufferBuilder builder, Offset<RoleValueTotalScoreCalcTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001ABC RID: 6844
		private Table __p = new Table();

		// Token: 0x0200058C RID: 1420
		public enum eCrypt
		{
			// Token: 0x04001ABE RID: 6846
			code = -294344558
		}
	}
}
