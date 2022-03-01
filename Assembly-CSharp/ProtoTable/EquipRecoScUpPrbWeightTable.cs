using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003FF RID: 1023
	public class EquipRecoScUpPrbWeightTable : IFlatbufferObject
	{
		// Token: 0x17000B51 RID: 2897
		// (get) Token: 0x06002F29 RID: 12073 RVA: 0x000AA8B4 File Offset: 0x000A8CB4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002F2A RID: 12074 RVA: 0x000AA8C1 File Offset: 0x000A8CC1
		public static EquipRecoScUpPrbWeightTable GetRootAsEquipRecoScUpPrbWeightTable(ByteBuffer _bb)
		{
			return EquipRecoScUpPrbWeightTable.GetRootAsEquipRecoScUpPrbWeightTable(_bb, new EquipRecoScUpPrbWeightTable());
		}

		// Token: 0x06002F2B RID: 12075 RVA: 0x000AA8CE File Offset: 0x000A8CCE
		public static EquipRecoScUpPrbWeightTable GetRootAsEquipRecoScUpPrbWeightTable(ByteBuffer _bb, EquipRecoScUpPrbWeightTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002F2C RID: 12076 RVA: 0x000AA8EA File Offset: 0x000A8CEA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002F2D RID: 12077 RVA: 0x000AA904 File Offset: 0x000A8D04
		public EquipRecoScUpPrbWeightTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B52 RID: 2898
		// (get) Token: 0x06002F2E RID: 12078 RVA: 0x000AA910 File Offset: 0x000A8D10
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-596189940 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B53 RID: 2899
		// (get) Token: 0x06002F2F RID: 12079 RVA: 0x000AA95C File Offset: 0x000A8D5C
		public int UpScore
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-596189940 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B54 RID: 2900
		// (get) Token: 0x06002F30 RID: 12080 RVA: 0x000AA9A8 File Offset: 0x000A8DA8
		public int ProbWeight
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-596189940 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002F31 RID: 12081 RVA: 0x000AA9F1 File Offset: 0x000A8DF1
		public static Offset<EquipRecoScUpPrbWeightTable> CreateEquipRecoScUpPrbWeightTable(FlatBufferBuilder builder, int ID = 0, int UpScore = 0, int ProbWeight = 0)
		{
			builder.StartObject(3);
			EquipRecoScUpPrbWeightTable.AddProbWeight(builder, ProbWeight);
			EquipRecoScUpPrbWeightTable.AddUpScore(builder, UpScore);
			EquipRecoScUpPrbWeightTable.AddID(builder, ID);
			return EquipRecoScUpPrbWeightTable.EndEquipRecoScUpPrbWeightTable(builder);
		}

		// Token: 0x06002F32 RID: 12082 RVA: 0x000AAA15 File Offset: 0x000A8E15
		public static void StartEquipRecoScUpPrbWeightTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06002F33 RID: 12083 RVA: 0x000AAA1E File Offset: 0x000A8E1E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002F34 RID: 12084 RVA: 0x000AAA29 File Offset: 0x000A8E29
		public static void AddUpScore(FlatBufferBuilder builder, int UpScore)
		{
			builder.AddInt(1, UpScore, 0);
		}

		// Token: 0x06002F35 RID: 12085 RVA: 0x000AAA34 File Offset: 0x000A8E34
		public static void AddProbWeight(FlatBufferBuilder builder, int ProbWeight)
		{
			builder.AddInt(2, ProbWeight, 0);
		}

		// Token: 0x06002F36 RID: 12086 RVA: 0x000AAA40 File Offset: 0x000A8E40
		public static Offset<EquipRecoScUpPrbWeightTable> EndEquipRecoScUpPrbWeightTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipRecoScUpPrbWeightTable>(value);
		}

		// Token: 0x06002F37 RID: 12087 RVA: 0x000AAA5A File Offset: 0x000A8E5A
		public static void FinishEquipRecoScUpPrbWeightTableBuffer(FlatBufferBuilder builder, Offset<EquipRecoScUpPrbWeightTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040013B3 RID: 5043
		private Table __p = new Table();

		// Token: 0x02000400 RID: 1024
		public enum eCrypt
		{
			// Token: 0x040013B5 RID: 5045
			code = -596189940
		}
	}
}
