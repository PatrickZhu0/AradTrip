using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000537 RID: 1335
	public class ObjectTable : IFlatbufferObject
	{
		// Token: 0x17001256 RID: 4694
		// (get) Token: 0x0600449E RID: 17566 RVA: 0x000DD490 File Offset: 0x000DB890
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600449F RID: 17567 RVA: 0x000DD49D File Offset: 0x000DB89D
		public static ObjectTable GetRootAsObjectTable(ByteBuffer _bb)
		{
			return ObjectTable.GetRootAsObjectTable(_bb, new ObjectTable());
		}

		// Token: 0x060044A0 RID: 17568 RVA: 0x000DD4AA File Offset: 0x000DB8AA
		public static ObjectTable GetRootAsObjectTable(ByteBuffer _bb, ObjectTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060044A1 RID: 17569 RVA: 0x000DD4C6 File Offset: 0x000DB8C6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060044A2 RID: 17570 RVA: 0x000DD4E0 File Offset: 0x000DB8E0
		public ObjectTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001257 RID: 4695
		// (get) Token: 0x060044A3 RID: 17571 RVA: 0x000DD4EC File Offset: 0x000DB8EC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1694884891 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001258 RID: 4696
		// (get) Token: 0x060044A4 RID: 17572 RVA: 0x000DD538 File Offset: 0x000DB938
		public UnionCell Zscale
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001259 RID: 4697
		// (get) Token: 0x060044A5 RID: 17573 RVA: 0x000DD590 File Offset: 0x000DB990
		public UnionCell PVPZscale
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700125A RID: 4698
		// (get) Token: 0x060044A6 RID: 17574 RVA: 0x000DD5E8 File Offset: 0x000DB9E8
		public UnionCell Scale
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700125B RID: 4699
		// (get) Token: 0x060044A7 RID: 17575 RVA: 0x000DD640 File Offset: 0x000DBA40
		public UnionCell PVPScale
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700125C RID: 4700
		// (get) Token: 0x060044A8 RID: 17576 RVA: 0x000DD698 File Offset: 0x000DBA98
		public int IsTouchGround
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1694884891 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700125D RID: 4701
		// (get) Token: 0x060044A9 RID: 17577 RVA: 0x000DD6E4 File Offset: 0x000DBAE4
		public int ShadowScaleX
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1694884891 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700125E RID: 4702
		// (get) Token: 0x060044AA RID: 17578 RVA: 0x000DD730 File Offset: 0x000DBB30
		public int ShadowScaleZ
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1694884891 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700125F RID: 4703
		// (get) Token: 0x060044AB RID: 17579 RVA: 0x000DD77C File Offset: 0x000DBB7C
		public UnionCell Duration
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17001260 RID: 4704
		// (get) Token: 0x060044AC RID: 17580 RVA: 0x000DD7D4 File Offset: 0x000DBBD4
		public int GenRune
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1694884891 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001261 RID: 4705
		// (get) Token: 0x060044AD RID: 17581 RVA: 0x000DD820 File Offset: 0x000DBC20
		public int ClearRune
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1694884891 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001262 RID: 4706
		// (get) Token: 0x060044AE RID: 17582 RVA: 0x000DD86C File Offset: 0x000DBC6C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060044AF RID: 17583 RVA: 0x000DD8AF File Offset: 0x000DBCAF
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17001263 RID: 4707
		// (get) Token: 0x060044B0 RID: 17584 RVA: 0x000DD8C0 File Offset: 0x000DBCC0
		public bool UseOwnerPos
		{
			get
			{
				int num = this.__p.__offset(28);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17001264 RID: 4708
		// (get) Token: 0x060044B1 RID: 17585 RVA: 0x000DD90C File Offset: 0x000DBD0C
		public bool IsRemoveByAirWall
		{
			get
			{
				int num = this.__p.__offset(30);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17001265 RID: 4709
		// (get) Token: 0x060044B2 RID: 17586 RVA: 0x000DD958 File Offset: 0x000DBD58
		public bool UseOffset
		{
			get
			{
				int num = this.__p.__offset(32);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060044B3 RID: 17587 RVA: 0x000DD9A4 File Offset: 0x000DBDA4
		public static Offset<ObjectTable> CreateObjectTable(FlatBufferBuilder builder, int ID = 0, Offset<UnionCell> ZscaleOffset = default(Offset<UnionCell>), Offset<UnionCell> PVPZscaleOffset = default(Offset<UnionCell>), Offset<UnionCell> ScaleOffset = default(Offset<UnionCell>), Offset<UnionCell> PVPScaleOffset = default(Offset<UnionCell>), int IsTouchGround = 0, int ShadowScaleX = 0, int ShadowScaleZ = 0, Offset<UnionCell> DurationOffset = default(Offset<UnionCell>), int GenRune = 0, int ClearRune = 0, StringOffset NameOffset = default(StringOffset), bool UseOwnerPos = false, bool IsRemoveByAirWall = false, bool UseOffset = false)
		{
			builder.StartObject(15);
			ObjectTable.AddName(builder, NameOffset);
			ObjectTable.AddClearRune(builder, ClearRune);
			ObjectTable.AddGenRune(builder, GenRune);
			ObjectTable.AddDuration(builder, DurationOffset);
			ObjectTable.AddShadowScaleZ(builder, ShadowScaleZ);
			ObjectTable.AddShadowScaleX(builder, ShadowScaleX);
			ObjectTable.AddIsTouchGround(builder, IsTouchGround);
			ObjectTable.AddPVPScale(builder, PVPScaleOffset);
			ObjectTable.AddScale(builder, ScaleOffset);
			ObjectTable.AddPVPZscale(builder, PVPZscaleOffset);
			ObjectTable.AddZscale(builder, ZscaleOffset);
			ObjectTable.AddID(builder, ID);
			ObjectTable.AddUseOffset(builder, UseOffset);
			ObjectTable.AddIsRemoveByAirWall(builder, IsRemoveByAirWall);
			ObjectTable.AddUseOwnerPos(builder, UseOwnerPos);
			return ObjectTable.EndObjectTable(builder);
		}

		// Token: 0x060044B4 RID: 17588 RVA: 0x000DDA34 File Offset: 0x000DBE34
		public static void StartObjectTable(FlatBufferBuilder builder)
		{
			builder.StartObject(15);
		}

		// Token: 0x060044B5 RID: 17589 RVA: 0x000DDA3E File Offset: 0x000DBE3E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060044B6 RID: 17590 RVA: 0x000DDA49 File Offset: 0x000DBE49
		public static void AddZscale(FlatBufferBuilder builder, Offset<UnionCell> ZscaleOffset)
		{
			builder.AddOffset(1, ZscaleOffset.Value, 0);
		}

		// Token: 0x060044B7 RID: 17591 RVA: 0x000DDA5A File Offset: 0x000DBE5A
		public static void AddPVPZscale(FlatBufferBuilder builder, Offset<UnionCell> PVPZscaleOffset)
		{
			builder.AddOffset(2, PVPZscaleOffset.Value, 0);
		}

		// Token: 0x060044B8 RID: 17592 RVA: 0x000DDA6B File Offset: 0x000DBE6B
		public static void AddScale(FlatBufferBuilder builder, Offset<UnionCell> ScaleOffset)
		{
			builder.AddOffset(3, ScaleOffset.Value, 0);
		}

		// Token: 0x060044B9 RID: 17593 RVA: 0x000DDA7C File Offset: 0x000DBE7C
		public static void AddPVPScale(FlatBufferBuilder builder, Offset<UnionCell> PVPScaleOffset)
		{
			builder.AddOffset(4, PVPScaleOffset.Value, 0);
		}

		// Token: 0x060044BA RID: 17594 RVA: 0x000DDA8D File Offset: 0x000DBE8D
		public static void AddIsTouchGround(FlatBufferBuilder builder, int IsTouchGround)
		{
			builder.AddInt(5, IsTouchGround, 0);
		}

		// Token: 0x060044BB RID: 17595 RVA: 0x000DDA98 File Offset: 0x000DBE98
		public static void AddShadowScaleX(FlatBufferBuilder builder, int ShadowScaleX)
		{
			builder.AddInt(6, ShadowScaleX, 0);
		}

		// Token: 0x060044BC RID: 17596 RVA: 0x000DDAA3 File Offset: 0x000DBEA3
		public static void AddShadowScaleZ(FlatBufferBuilder builder, int ShadowScaleZ)
		{
			builder.AddInt(7, ShadowScaleZ, 0);
		}

		// Token: 0x060044BD RID: 17597 RVA: 0x000DDAAE File Offset: 0x000DBEAE
		public static void AddDuration(FlatBufferBuilder builder, Offset<UnionCell> DurationOffset)
		{
			builder.AddOffset(8, DurationOffset.Value, 0);
		}

		// Token: 0x060044BE RID: 17598 RVA: 0x000DDABF File Offset: 0x000DBEBF
		public static void AddGenRune(FlatBufferBuilder builder, int GenRune)
		{
			builder.AddInt(9, GenRune, 0);
		}

		// Token: 0x060044BF RID: 17599 RVA: 0x000DDACB File Offset: 0x000DBECB
		public static void AddClearRune(FlatBufferBuilder builder, int ClearRune)
		{
			builder.AddInt(10, ClearRune, 0);
		}

		// Token: 0x060044C0 RID: 17600 RVA: 0x000DDAD7 File Offset: 0x000DBED7
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(11, NameOffset.Value, 0);
		}

		// Token: 0x060044C1 RID: 17601 RVA: 0x000DDAE9 File Offset: 0x000DBEE9
		public static void AddUseOwnerPos(FlatBufferBuilder builder, bool UseOwnerPos)
		{
			builder.AddBool(12, UseOwnerPos, false);
		}

		// Token: 0x060044C2 RID: 17602 RVA: 0x000DDAF5 File Offset: 0x000DBEF5
		public static void AddIsRemoveByAirWall(FlatBufferBuilder builder, bool IsRemoveByAirWall)
		{
			builder.AddBool(13, IsRemoveByAirWall, false);
		}

		// Token: 0x060044C3 RID: 17603 RVA: 0x000DDB01 File Offset: 0x000DBF01
		public static void AddUseOffset(FlatBufferBuilder builder, bool UseOffset)
		{
			builder.AddBool(14, UseOffset, false);
		}

		// Token: 0x060044C4 RID: 17604 RVA: 0x000DDB10 File Offset: 0x000DBF10
		public static Offset<ObjectTable> EndObjectTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ObjectTable>(value);
		}

		// Token: 0x060044C5 RID: 17605 RVA: 0x000DDB2A File Offset: 0x000DBF2A
		public static void FinishObjectTableBuffer(FlatBufferBuilder builder, Offset<ObjectTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001981 RID: 6529
		private Table __p = new Table();

		// Token: 0x02000538 RID: 1336
		public enum eCrypt
		{
			// Token: 0x04001983 RID: 6531
			code = 1694884891
		}
	}
}
