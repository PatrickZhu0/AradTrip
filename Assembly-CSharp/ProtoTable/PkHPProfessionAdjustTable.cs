using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000558 RID: 1368
	public class PkHPProfessionAdjustTable : IFlatbufferObject
	{
		// Token: 0x170012FE RID: 4862
		// (get) Token: 0x06004694 RID: 18068 RVA: 0x000E1D00 File Offset: 0x000E0100
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004695 RID: 18069 RVA: 0x000E1D0D File Offset: 0x000E010D
		public static PkHPProfessionAdjustTable GetRootAsPkHPProfessionAdjustTable(ByteBuffer _bb)
		{
			return PkHPProfessionAdjustTable.GetRootAsPkHPProfessionAdjustTable(_bb, new PkHPProfessionAdjustTable());
		}

		// Token: 0x06004696 RID: 18070 RVA: 0x000E1D1A File Offset: 0x000E011A
		public static PkHPProfessionAdjustTable GetRootAsPkHPProfessionAdjustTable(ByteBuffer _bb, PkHPProfessionAdjustTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004697 RID: 18071 RVA: 0x000E1D36 File Offset: 0x000E0136
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004698 RID: 18072 RVA: 0x000E1D50 File Offset: 0x000E0150
		public PkHPProfessionAdjustTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170012FF RID: 4863
		// (get) Token: 0x06004699 RID: 18073 RVA: 0x000E1D5C File Offset: 0x000E015C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (181084950 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001300 RID: 4864
		// (get) Token: 0x0600469A RID: 18074 RVA: 0x000E1DA8 File Offset: 0x000E01A8
		public string ProfessionDesc1
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600469B RID: 18075 RVA: 0x000E1DEA File Offset: 0x000E01EA
		public ArraySegment<byte>? GetProfessionDesc1Bytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001301 RID: 4865
		// (get) Token: 0x0600469C RID: 18076 RVA: 0x000E1DF8 File Offset: 0x000E01F8
		public int factor
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (181084950 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001302 RID: 4866
		// (get) Token: 0x0600469D RID: 18077 RVA: 0x000E1E44 File Offset: 0x000E0244
		public int DamageFactor
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (181084950 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001303 RID: 4867
		// (get) Token: 0x0600469E RID: 18078 RVA: 0x000E1E90 File Offset: 0x000E0290
		public int factor_3v3
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (181084950 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001304 RID: 4868
		// (get) Token: 0x0600469F RID: 18079 RVA: 0x000E1EDC File Offset: 0x000E02DC
		public int DamageFactor_3v3
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (181084950 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001305 RID: 4869
		// (get) Token: 0x060046A0 RID: 18080 RVA: 0x000E1F28 File Offset: 0x000E0328
		public int factor_chiji
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (181084950 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001306 RID: 4870
		// (get) Token: 0x060046A1 RID: 18081 RVA: 0x000E1F74 File Offset: 0x000E0374
		public int DamageFactor_chiji
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (181084950 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060046A2 RID: 18082 RVA: 0x000E1FC0 File Offset: 0x000E03C0
		public static Offset<PkHPProfessionAdjustTable> CreatePkHPProfessionAdjustTable(FlatBufferBuilder builder, int ID = 0, StringOffset ProfessionDesc1Offset = default(StringOffset), int factor = 0, int DamageFactor = 0, int factor_3v3 = 0, int DamageFactor_3v3 = 0, int factor_chiji = 0, int DamageFactor_chiji = 0)
		{
			builder.StartObject(8);
			PkHPProfessionAdjustTable.AddDamageFactorChiji(builder, DamageFactor_chiji);
			PkHPProfessionAdjustTable.AddFactorChiji(builder, factor_chiji);
			PkHPProfessionAdjustTable.AddDamageFactor3v3(builder, DamageFactor_3v3);
			PkHPProfessionAdjustTable.AddFactor3v3(builder, factor_3v3);
			PkHPProfessionAdjustTable.AddDamageFactor(builder, DamageFactor);
			PkHPProfessionAdjustTable.AddFactor(builder, factor);
			PkHPProfessionAdjustTable.AddProfessionDesc1(builder, ProfessionDesc1Offset);
			PkHPProfessionAdjustTable.AddID(builder, ID);
			return PkHPProfessionAdjustTable.EndPkHPProfessionAdjustTable(builder);
		}

		// Token: 0x060046A3 RID: 18083 RVA: 0x000E2017 File Offset: 0x000E0417
		public static void StartPkHPProfessionAdjustTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x060046A4 RID: 18084 RVA: 0x000E2020 File Offset: 0x000E0420
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060046A5 RID: 18085 RVA: 0x000E202B File Offset: 0x000E042B
		public static void AddProfessionDesc1(FlatBufferBuilder builder, StringOffset ProfessionDesc1Offset)
		{
			builder.AddOffset(1, ProfessionDesc1Offset.Value, 0);
		}

		// Token: 0x060046A6 RID: 18086 RVA: 0x000E203C File Offset: 0x000E043C
		public static void AddFactor(FlatBufferBuilder builder, int factor)
		{
			builder.AddInt(2, factor, 0);
		}

		// Token: 0x060046A7 RID: 18087 RVA: 0x000E2047 File Offset: 0x000E0447
		public static void AddDamageFactor(FlatBufferBuilder builder, int DamageFactor)
		{
			builder.AddInt(3, DamageFactor, 0);
		}

		// Token: 0x060046A8 RID: 18088 RVA: 0x000E2052 File Offset: 0x000E0452
		public static void AddFactor3v3(FlatBufferBuilder builder, int factor3v3)
		{
			builder.AddInt(4, factor3v3, 0);
		}

		// Token: 0x060046A9 RID: 18089 RVA: 0x000E205D File Offset: 0x000E045D
		public static void AddDamageFactor3v3(FlatBufferBuilder builder, int DamageFactor3v3)
		{
			builder.AddInt(5, DamageFactor3v3, 0);
		}

		// Token: 0x060046AA RID: 18090 RVA: 0x000E2068 File Offset: 0x000E0468
		public static void AddFactorChiji(FlatBufferBuilder builder, int factorChiji)
		{
			builder.AddInt(6, factorChiji, 0);
		}

		// Token: 0x060046AB RID: 18091 RVA: 0x000E2073 File Offset: 0x000E0473
		public static void AddDamageFactorChiji(FlatBufferBuilder builder, int DamageFactorChiji)
		{
			builder.AddInt(7, DamageFactorChiji, 0);
		}

		// Token: 0x060046AC RID: 18092 RVA: 0x000E2080 File Offset: 0x000E0480
		public static Offset<PkHPProfessionAdjustTable> EndPkHPProfessionAdjustTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PkHPProfessionAdjustTable>(value);
		}

		// Token: 0x060046AD RID: 18093 RVA: 0x000E209A File Offset: 0x000E049A
		public static void FinishPkHPProfessionAdjustTableBuffer(FlatBufferBuilder builder, Offset<PkHPProfessionAdjustTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A1E RID: 6686
		private Table __p = new Table();

		// Token: 0x02000559 RID: 1369
		public enum eCrypt
		{
			// Token: 0x04001A20 RID: 6688
			code = 181084950
		}
	}
}
