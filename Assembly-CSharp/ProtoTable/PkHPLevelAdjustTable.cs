using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000556 RID: 1366
	public class PkHPLevelAdjustTable : IFlatbufferObject
	{
		// Token: 0x170012F8 RID: 4856
		// (get) Token: 0x06004680 RID: 18048 RVA: 0x000E1A78 File Offset: 0x000DFE78
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004681 RID: 18049 RVA: 0x000E1A85 File Offset: 0x000DFE85
		public static PkHPLevelAdjustTable GetRootAsPkHPLevelAdjustTable(ByteBuffer _bb)
		{
			return PkHPLevelAdjustTable.GetRootAsPkHPLevelAdjustTable(_bb, new PkHPLevelAdjustTable());
		}

		// Token: 0x06004682 RID: 18050 RVA: 0x000E1A92 File Offset: 0x000DFE92
		public static PkHPLevelAdjustTable GetRootAsPkHPLevelAdjustTable(ByteBuffer _bb, PkHPLevelAdjustTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004683 RID: 18051 RVA: 0x000E1AAE File Offset: 0x000DFEAE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004684 RID: 18052 RVA: 0x000E1AC8 File Offset: 0x000DFEC8
		public PkHPLevelAdjustTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170012F9 RID: 4857
		// (get) Token: 0x06004685 RID: 18053 RVA: 0x000E1AD4 File Offset: 0x000DFED4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1033802426 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012FA RID: 4858
		// (get) Token: 0x06004686 RID: 18054 RVA: 0x000E1B20 File Offset: 0x000DFF20
		public int factor
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1033802426 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012FB RID: 4859
		// (get) Token: 0x06004687 RID: 18055 RVA: 0x000E1B6C File Offset: 0x000DFF6C
		public int Attackfactor
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1033802426 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012FC RID: 4860
		// (get) Token: 0x06004688 RID: 18056 RVA: 0x000E1BB8 File Offset: 0x000DFFB8
		public int factor_chiji
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1033802426 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012FD RID: 4861
		// (get) Token: 0x06004689 RID: 18057 RVA: 0x000E1C04 File Offset: 0x000E0004
		public int Attackfactor_chiji
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1033802426 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600468A RID: 18058 RVA: 0x000E1C4E File Offset: 0x000E004E
		public static Offset<PkHPLevelAdjustTable> CreatePkHPLevelAdjustTable(FlatBufferBuilder builder, int ID = 0, int factor = 0, int Attackfactor = 0, int factor_chiji = 0, int Attackfactor_chiji = 0)
		{
			builder.StartObject(5);
			PkHPLevelAdjustTable.AddAttackfactorChiji(builder, Attackfactor_chiji);
			PkHPLevelAdjustTable.AddFactorChiji(builder, factor_chiji);
			PkHPLevelAdjustTable.AddAttackfactor(builder, Attackfactor);
			PkHPLevelAdjustTable.AddFactor(builder, factor);
			PkHPLevelAdjustTable.AddID(builder, ID);
			return PkHPLevelAdjustTable.EndPkHPLevelAdjustTable(builder);
		}

		// Token: 0x0600468B RID: 18059 RVA: 0x000E1C82 File Offset: 0x000E0082
		public static void StartPkHPLevelAdjustTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0600468C RID: 18060 RVA: 0x000E1C8B File Offset: 0x000E008B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600468D RID: 18061 RVA: 0x000E1C96 File Offset: 0x000E0096
		public static void AddFactor(FlatBufferBuilder builder, int factor)
		{
			builder.AddInt(1, factor, 0);
		}

		// Token: 0x0600468E RID: 18062 RVA: 0x000E1CA1 File Offset: 0x000E00A1
		public static void AddAttackfactor(FlatBufferBuilder builder, int Attackfactor)
		{
			builder.AddInt(2, Attackfactor, 0);
		}

		// Token: 0x0600468F RID: 18063 RVA: 0x000E1CAC File Offset: 0x000E00AC
		public static void AddFactorChiji(FlatBufferBuilder builder, int factorChiji)
		{
			builder.AddInt(3, factorChiji, 0);
		}

		// Token: 0x06004690 RID: 18064 RVA: 0x000E1CB7 File Offset: 0x000E00B7
		public static void AddAttackfactorChiji(FlatBufferBuilder builder, int AttackfactorChiji)
		{
			builder.AddInt(4, AttackfactorChiji, 0);
		}

		// Token: 0x06004691 RID: 18065 RVA: 0x000E1CC4 File Offset: 0x000E00C4
		public static Offset<PkHPLevelAdjustTable> EndPkHPLevelAdjustTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PkHPLevelAdjustTable>(value);
		}

		// Token: 0x06004692 RID: 18066 RVA: 0x000E1CDE File Offset: 0x000E00DE
		public static void FinishPkHPLevelAdjustTableBuffer(FlatBufferBuilder builder, Offset<PkHPLevelAdjustTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A1B RID: 6683
		private Table __p = new Table();

		// Token: 0x02000557 RID: 1367
		public enum eCrypt
		{
			// Token: 0x04001A1D RID: 6685
			code = -1033802426
		}
	}
}
