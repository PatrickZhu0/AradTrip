using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200033E RID: 830
	public class ChijiEffectMapTable : IFlatbufferObject
	{
		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x06002316 RID: 8982 RVA: 0x0008D884 File Offset: 0x0008BC84
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002317 RID: 8983 RVA: 0x0008D891 File Offset: 0x0008BC91
		public static ChijiEffectMapTable GetRootAsChijiEffectMapTable(ByteBuffer _bb)
		{
			return ChijiEffectMapTable.GetRootAsChijiEffectMapTable(_bb, new ChijiEffectMapTable());
		}

		// Token: 0x06002318 RID: 8984 RVA: 0x0008D89E File Offset: 0x0008BC9E
		public static ChijiEffectMapTable GetRootAsChijiEffectMapTable(ByteBuffer _bb, ChijiEffectMapTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002319 RID: 8985 RVA: 0x0008D8BA File Offset: 0x0008BCBA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600231A RID: 8986 RVA: 0x0008D8D4 File Offset: 0x0008BCD4
		public ChijiEffectMapTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x0600231B RID: 8987 RVA: 0x0008D8E0 File Offset: 0x0008BCE0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (196207592 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x0600231C RID: 8988 RVA: 0x0008D92C File Offset: 0x0008BD2C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600231D RID: 8989 RVA: 0x0008D96E File Offset: 0x0008BD6E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x0600231E RID: 8990 RVA: 0x0008D97C File Offset: 0x0008BD7C
		public UnionCell DamageRatePVP
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x0600231F RID: 8991 RVA: 0x0008D9D4 File Offset: 0x0008BDD4
		public UnionCell DamageFixedValuePVP
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06002320 RID: 8992 RVA: 0x0008DA2C File Offset: 0x0008BE2C
		public UnionCell Attack
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06002321 RID: 8993 RVA: 0x0008DA84 File Offset: 0x0008BE84
		public UnionCell FloatingRate
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x06002322 RID: 8994 RVA: 0x0008DADC File Offset: 0x0008BEDC
		public UnionCell HitFloatXForce
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x06002323 RID: 8995 RVA: 0x0008DB34 File Offset: 0x0008BF34
		public UnionCell HitFloatYForce
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x06002324 RID: 8996 RVA: 0x0008DB8C File Offset: 0x0008BF8C
		public UnionCell SummonLevel
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06002325 RID: 8997 RVA: 0x0008DBE4 File Offset: 0x0008BFE4
		public UnionCell BuffLevel
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x06002326 RID: 8998 RVA: 0x0008DC3C File Offset: 0x0008C03C
		public UnionCell AttachBuffRate
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x06002327 RID: 8999 RVA: 0x0008DC94 File Offset: 0x0008C094
		public UnionCell AttachBuffTime
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x06002328 RID: 9000 RVA: 0x0008DCEC File Offset: 0x0008C0EC
		public UnionCell BuffAttack
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x06002329 RID: 9001 RVA: 0x0008DD44 File Offset: 0x0008C144
		public int PVPBuffInfoIDArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (196207592 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x0600232A RID: 9002 RVA: 0x0008DD94 File Offset: 0x0008C194
		public int PVPBuffInfoIDLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600232B RID: 9003 RVA: 0x0008DDC7 File Offset: 0x0008C1C7
		public ArraySegment<byte>? GetPVPBuffInfoIDBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x0600232C RID: 9004 RVA: 0x0008DDD6 File Offset: 0x0008C1D6
		public FlatBufferArray<int> PVPBuffInfoID
		{
			get
			{
				if (this.PVPBuffInfoIDValue == null)
				{
					this.PVPBuffInfoIDValue = new FlatBufferArray<int>(new Func<int, int>(this.PVPBuffInfoIDArray), this.PVPBuffInfoIDLength);
				}
				return this.PVPBuffInfoIDValue;
			}
		}

		// Token: 0x0600232D RID: 9005 RVA: 0x0008DE08 File Offset: 0x0008C208
		public static Offset<ChijiEffectMapTable> CreateChijiEffectMapTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), Offset<UnionCell> DamageRatePVPOffset = default(Offset<UnionCell>), Offset<UnionCell> DamageFixedValuePVPOffset = default(Offset<UnionCell>), Offset<UnionCell> AttackOffset = default(Offset<UnionCell>), Offset<UnionCell> FloatingRateOffset = default(Offset<UnionCell>), Offset<UnionCell> HitFloatXForceOffset = default(Offset<UnionCell>), Offset<UnionCell> HitFloatYForceOffset = default(Offset<UnionCell>), Offset<UnionCell> SummonLevelOffset = default(Offset<UnionCell>), Offset<UnionCell> BuffLevelOffset = default(Offset<UnionCell>), Offset<UnionCell> AttachBuffRateOffset = default(Offset<UnionCell>), Offset<UnionCell> AttachBuffTimeOffset = default(Offset<UnionCell>), Offset<UnionCell> BuffAttackOffset = default(Offset<UnionCell>), VectorOffset PVPBuffInfoIDOffset = default(VectorOffset))
		{
			builder.StartObject(14);
			ChijiEffectMapTable.AddPVPBuffInfoID(builder, PVPBuffInfoIDOffset);
			ChijiEffectMapTable.AddBuffAttack(builder, BuffAttackOffset);
			ChijiEffectMapTable.AddAttachBuffTime(builder, AttachBuffTimeOffset);
			ChijiEffectMapTable.AddAttachBuffRate(builder, AttachBuffRateOffset);
			ChijiEffectMapTable.AddBuffLevel(builder, BuffLevelOffset);
			ChijiEffectMapTable.AddSummonLevel(builder, SummonLevelOffset);
			ChijiEffectMapTable.AddHitFloatYForce(builder, HitFloatYForceOffset);
			ChijiEffectMapTable.AddHitFloatXForce(builder, HitFloatXForceOffset);
			ChijiEffectMapTable.AddFloatingRate(builder, FloatingRateOffset);
			ChijiEffectMapTable.AddAttack(builder, AttackOffset);
			ChijiEffectMapTable.AddDamageFixedValuePVP(builder, DamageFixedValuePVPOffset);
			ChijiEffectMapTable.AddDamageRatePVP(builder, DamageRatePVPOffset);
			ChijiEffectMapTable.AddName(builder, NameOffset);
			ChijiEffectMapTable.AddID(builder, ID);
			return ChijiEffectMapTable.EndChijiEffectMapTable(builder);
		}

		// Token: 0x0600232E RID: 9006 RVA: 0x0008DE90 File Offset: 0x0008C290
		public static void StartChijiEffectMapTable(FlatBufferBuilder builder)
		{
			builder.StartObject(14);
		}

		// Token: 0x0600232F RID: 9007 RVA: 0x0008DE9A File Offset: 0x0008C29A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002330 RID: 9008 RVA: 0x0008DEA5 File Offset: 0x0008C2A5
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002331 RID: 9009 RVA: 0x0008DEB6 File Offset: 0x0008C2B6
		public static void AddDamageRatePVP(FlatBufferBuilder builder, Offset<UnionCell> DamageRatePVPOffset)
		{
			builder.AddOffset(2, DamageRatePVPOffset.Value, 0);
		}

		// Token: 0x06002332 RID: 9010 RVA: 0x0008DEC7 File Offset: 0x0008C2C7
		public static void AddDamageFixedValuePVP(FlatBufferBuilder builder, Offset<UnionCell> DamageFixedValuePVPOffset)
		{
			builder.AddOffset(3, DamageFixedValuePVPOffset.Value, 0);
		}

		// Token: 0x06002333 RID: 9011 RVA: 0x0008DED8 File Offset: 0x0008C2D8
		public static void AddAttack(FlatBufferBuilder builder, Offset<UnionCell> AttackOffset)
		{
			builder.AddOffset(4, AttackOffset.Value, 0);
		}

		// Token: 0x06002334 RID: 9012 RVA: 0x0008DEE9 File Offset: 0x0008C2E9
		public static void AddFloatingRate(FlatBufferBuilder builder, Offset<UnionCell> FloatingRateOffset)
		{
			builder.AddOffset(5, FloatingRateOffset.Value, 0);
		}

		// Token: 0x06002335 RID: 9013 RVA: 0x0008DEFA File Offset: 0x0008C2FA
		public static void AddHitFloatXForce(FlatBufferBuilder builder, Offset<UnionCell> HitFloatXForceOffset)
		{
			builder.AddOffset(6, HitFloatXForceOffset.Value, 0);
		}

		// Token: 0x06002336 RID: 9014 RVA: 0x0008DF0B File Offset: 0x0008C30B
		public static void AddHitFloatYForce(FlatBufferBuilder builder, Offset<UnionCell> HitFloatYForceOffset)
		{
			builder.AddOffset(7, HitFloatYForceOffset.Value, 0);
		}

		// Token: 0x06002337 RID: 9015 RVA: 0x0008DF1C File Offset: 0x0008C31C
		public static void AddSummonLevel(FlatBufferBuilder builder, Offset<UnionCell> SummonLevelOffset)
		{
			builder.AddOffset(8, SummonLevelOffset.Value, 0);
		}

		// Token: 0x06002338 RID: 9016 RVA: 0x0008DF2D File Offset: 0x0008C32D
		public static void AddBuffLevel(FlatBufferBuilder builder, Offset<UnionCell> BuffLevelOffset)
		{
			builder.AddOffset(9, BuffLevelOffset.Value, 0);
		}

		// Token: 0x06002339 RID: 9017 RVA: 0x0008DF3F File Offset: 0x0008C33F
		public static void AddAttachBuffRate(FlatBufferBuilder builder, Offset<UnionCell> AttachBuffRateOffset)
		{
			builder.AddOffset(10, AttachBuffRateOffset.Value, 0);
		}

		// Token: 0x0600233A RID: 9018 RVA: 0x0008DF51 File Offset: 0x0008C351
		public static void AddAttachBuffTime(FlatBufferBuilder builder, Offset<UnionCell> AttachBuffTimeOffset)
		{
			builder.AddOffset(11, AttachBuffTimeOffset.Value, 0);
		}

		// Token: 0x0600233B RID: 9019 RVA: 0x0008DF63 File Offset: 0x0008C363
		public static void AddBuffAttack(FlatBufferBuilder builder, Offset<UnionCell> BuffAttackOffset)
		{
			builder.AddOffset(12, BuffAttackOffset.Value, 0);
		}

		// Token: 0x0600233C RID: 9020 RVA: 0x0008DF75 File Offset: 0x0008C375
		public static void AddPVPBuffInfoID(FlatBufferBuilder builder, VectorOffset PVPBuffInfoIDOffset)
		{
			builder.AddOffset(13, PVPBuffInfoIDOffset.Value, 0);
		}

		// Token: 0x0600233D RID: 9021 RVA: 0x0008DF88 File Offset: 0x0008C388
		public static VectorOffset CreatePVPBuffInfoIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600233E RID: 9022 RVA: 0x0008DFC5 File Offset: 0x0008C3C5
		public static void StartPVPBuffInfoIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600233F RID: 9023 RVA: 0x0008DFD0 File Offset: 0x0008C3D0
		public static Offset<ChijiEffectMapTable> EndChijiEffectMapTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChijiEffectMapTable>(value);
		}

		// Token: 0x06002340 RID: 9024 RVA: 0x0008DFEA File Offset: 0x0008C3EA
		public static void FinishChijiEffectMapTableBuffer(FlatBufferBuilder builder, Offset<ChijiEffectMapTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001015 RID: 4117
		private Table __p = new Table();

		// Token: 0x04001016 RID: 4118
		private FlatBufferArray<int> PVPBuffInfoIDValue;

		// Token: 0x0200033F RID: 831
		public enum eCrypt
		{
			// Token: 0x04001018 RID: 4120
			code = 196207592
		}
	}
}
