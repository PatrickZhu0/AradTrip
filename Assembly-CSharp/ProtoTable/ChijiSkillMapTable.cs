using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200034D RID: 845
	public class ChijiSkillMapTable : IFlatbufferObject
	{
		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x06002435 RID: 9269 RVA: 0x0009081C File Offset: 0x0008EC1C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002436 RID: 9270 RVA: 0x00090829 File Offset: 0x0008EC29
		public static ChijiSkillMapTable GetRootAsChijiSkillMapTable(ByteBuffer _bb)
		{
			return ChijiSkillMapTable.GetRootAsChijiSkillMapTable(_bb, new ChijiSkillMapTable());
		}

		// Token: 0x06002437 RID: 9271 RVA: 0x00090836 File Offset: 0x0008EC36
		public static ChijiSkillMapTable GetRootAsChijiSkillMapTable(ByteBuffer _bb, ChijiSkillMapTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002438 RID: 9272 RVA: 0x00090852 File Offset: 0x0008EC52
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002439 RID: 9273 RVA: 0x0009086C File Offset: 0x0008EC6C
		public ChijiSkillMapTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x0600243A RID: 9274 RVA: 0x00090878 File Offset: 0x0008EC78
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1988046502 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x0600243B RID: 9275 RVA: 0x000908C4 File Offset: 0x0008ECC4
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600243C RID: 9276 RVA: 0x00090906 File Offset: 0x0008ED06
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x0600243D RID: 9277 RVA: 0x00090914 File Offset: 0x0008ED14
		public UnionCell RefreshTimePVP
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x0600243E RID: 9278 RVA: 0x0009096C File Offset: 0x0008ED6C
		public UnionCell InitCDPVP
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x0600243F RID: 9279 RVA: 0x000909C4 File Offset: 0x0008EDC4
		public static Offset<ChijiSkillMapTable> CreateChijiSkillMapTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), Offset<UnionCell> RefreshTimePVPOffset = default(Offset<UnionCell>), Offset<UnionCell> InitCDPVPOffset = default(Offset<UnionCell>))
		{
			builder.StartObject(4);
			ChijiSkillMapTable.AddInitCDPVP(builder, InitCDPVPOffset);
			ChijiSkillMapTable.AddRefreshTimePVP(builder, RefreshTimePVPOffset);
			ChijiSkillMapTable.AddName(builder, NameOffset);
			ChijiSkillMapTable.AddID(builder, ID);
			return ChijiSkillMapTable.EndChijiSkillMapTable(builder);
		}

		// Token: 0x06002440 RID: 9280 RVA: 0x000909F0 File Offset: 0x0008EDF0
		public static void StartChijiSkillMapTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x000909F9 File Offset: 0x0008EDF9
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002442 RID: 9282 RVA: 0x00090A04 File Offset: 0x0008EE04
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002443 RID: 9283 RVA: 0x00090A15 File Offset: 0x0008EE15
		public static void AddRefreshTimePVP(FlatBufferBuilder builder, Offset<UnionCell> RefreshTimePVPOffset)
		{
			builder.AddOffset(2, RefreshTimePVPOffset.Value, 0);
		}

		// Token: 0x06002444 RID: 9284 RVA: 0x00090A26 File Offset: 0x0008EE26
		public static void AddInitCDPVP(FlatBufferBuilder builder, Offset<UnionCell> InitCDPVPOffset)
		{
			builder.AddOffset(3, InitCDPVPOffset.Value, 0);
		}

		// Token: 0x06002445 RID: 9285 RVA: 0x00090A38 File Offset: 0x0008EE38
		public static Offset<ChijiSkillMapTable> EndChijiSkillMapTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChijiSkillMapTable>(value);
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x00090A52 File Offset: 0x0008EE52
		public static void FinishChijiSkillMapTableBuffer(FlatBufferBuilder builder, Offset<ChijiSkillMapTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040010EB RID: 4331
		private Table __p = new Table();

		// Token: 0x0200034E RID: 846
		public enum eCrypt
		{
			// Token: 0x040010ED RID: 4333
			code = -1988046502
		}
	}
}
