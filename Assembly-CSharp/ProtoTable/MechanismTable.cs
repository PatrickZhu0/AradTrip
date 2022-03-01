using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004FE RID: 1278
	public class MechanismTable : IFlatbufferObject
	{
		// Token: 0x17001136 RID: 4406
		// (get) Token: 0x0600413B RID: 16699 RVA: 0x000D54E4 File Offset: 0x000D38E4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600413C RID: 16700 RVA: 0x000D54F1 File Offset: 0x000D38F1
		public static MechanismTable GetRootAsMechanismTable(ByteBuffer _bb)
		{
			return MechanismTable.GetRootAsMechanismTable(_bb, new MechanismTable());
		}

		// Token: 0x0600413D RID: 16701 RVA: 0x000D54FE File Offset: 0x000D38FE
		public static MechanismTable GetRootAsMechanismTable(ByteBuffer _bb, MechanismTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600413E RID: 16702 RVA: 0x000D551A File Offset: 0x000D391A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600413F RID: 16703 RVA: 0x000D5534 File Offset: 0x000D3934
		public MechanismTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001137 RID: 4407
		// (get) Token: 0x06004140 RID: 16704 RVA: 0x000D5540 File Offset: 0x000D3940
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1599982151 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001138 RID: 4408
		// (get) Token: 0x06004141 RID: 16705 RVA: 0x000D558C File Offset: 0x000D398C
		public string Description
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004142 RID: 16706 RVA: 0x000D55CE File Offset: 0x000D39CE
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001139 RID: 4409
		// (get) Token: 0x06004143 RID: 16707 RVA: 0x000D55DC File Offset: 0x000D39DC
		public int Index
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1599982151 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700113A RID: 4410
		// (get) Token: 0x06004144 RID: 16708 RVA: 0x000D5628 File Offset: 0x000D3A28
		public int RemoveFlag
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1599982151 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700113B RID: 4411
		// (get) Token: 0x06004145 RID: 16709 RVA: 0x000D5674 File Offset: 0x000D3A74
		public string StringDescriptionA
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004146 RID: 16710 RVA: 0x000D56B7 File Offset: 0x000D3AB7
		public ArraySegment<byte>? GetStringDescriptionABytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x06004147 RID: 16711 RVA: 0x000D56C8 File Offset: 0x000D3AC8
		public string StringValueAArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700113C RID: 4412
		// (get) Token: 0x06004148 RID: 16712 RVA: 0x000D5710 File Offset: 0x000D3B10
		public int StringValueALength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700113D RID: 4413
		// (get) Token: 0x06004149 RID: 16713 RVA: 0x000D5743 File Offset: 0x000D3B43
		public FlatBufferArray<string> StringValueA
		{
			get
			{
				if (this.StringValueAValue == null)
				{
					this.StringValueAValue = new FlatBufferArray<string>(new Func<int, string>(this.StringValueAArray), this.StringValueALength);
				}
				return this.StringValueAValue;
			}
		}

		// Token: 0x1700113E RID: 4414
		// (get) Token: 0x0600414A RID: 16714 RVA: 0x000D5774 File Offset: 0x000D3B74
		public string DescriptionA
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600414B RID: 16715 RVA: 0x000D57B7 File Offset: 0x000D3BB7
		public ArraySegment<byte>? GetDescriptionABytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x0600414C RID: 16716 RVA: 0x000D57C8 File Offset: 0x000D3BC8
		public UnionCell ValueAArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700113F RID: 4415
		// (get) Token: 0x0600414D RID: 16717 RVA: 0x000D5824 File Offset: 0x000D3C24
		public int ValueALength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001140 RID: 4416
		// (get) Token: 0x0600414E RID: 16718 RVA: 0x000D5857 File Offset: 0x000D3C57
		public FlatBufferArray<UnionCell> ValueA
		{
			get
			{
				if (this.ValueAValue == null)
				{
					this.ValueAValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueAArray), this.ValueALength);
				}
				return this.ValueAValue;
			}
		}

		// Token: 0x17001141 RID: 4417
		// (get) Token: 0x0600414F RID: 16719 RVA: 0x000D5888 File Offset: 0x000D3C88
		public string DescriptionB
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004150 RID: 16720 RVA: 0x000D58CB File Offset: 0x000D3CCB
		public ArraySegment<byte>? GetDescriptionBBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x06004151 RID: 16721 RVA: 0x000D58DC File Offset: 0x000D3CDC
		public UnionCell ValueBArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17001142 RID: 4418
		// (get) Token: 0x06004152 RID: 16722 RVA: 0x000D5938 File Offset: 0x000D3D38
		public int ValueBLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001143 RID: 4419
		// (get) Token: 0x06004153 RID: 16723 RVA: 0x000D596B File Offset: 0x000D3D6B
		public FlatBufferArray<UnionCell> ValueB
		{
			get
			{
				if (this.ValueBValue == null)
				{
					this.ValueBValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueBArray), this.ValueBLength);
				}
				return this.ValueBValue;
			}
		}

		// Token: 0x17001144 RID: 4420
		// (get) Token: 0x06004154 RID: 16724 RVA: 0x000D599C File Offset: 0x000D3D9C
		public string DescriptionC
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004155 RID: 16725 RVA: 0x000D59DF File Offset: 0x000D3DDF
		public ArraySegment<byte>? GetDescriptionCBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x06004156 RID: 16726 RVA: 0x000D59F0 File Offset: 0x000D3DF0
		public UnionCell ValueCArray(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17001145 RID: 4421
		// (get) Token: 0x06004157 RID: 16727 RVA: 0x000D5A4C File Offset: 0x000D3E4C
		public int ValueCLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001146 RID: 4422
		// (get) Token: 0x06004158 RID: 16728 RVA: 0x000D5A7F File Offset: 0x000D3E7F
		public FlatBufferArray<UnionCell> ValueC
		{
			get
			{
				if (this.ValueCValue == null)
				{
					this.ValueCValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueCArray), this.ValueCLength);
				}
				return this.ValueCValue;
			}
		}

		// Token: 0x17001147 RID: 4423
		// (get) Token: 0x06004159 RID: 16729 RVA: 0x000D5AB0 File Offset: 0x000D3EB0
		public string DescriptionD
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600415A RID: 16730 RVA: 0x000D5AF3 File Offset: 0x000D3EF3
		public ArraySegment<byte>? GetDescriptionDBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x0600415B RID: 16731 RVA: 0x000D5B04 File Offset: 0x000D3F04
		public UnionCell ValueDArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17001148 RID: 4424
		// (get) Token: 0x0600415C RID: 16732 RVA: 0x000D5B60 File Offset: 0x000D3F60
		public int ValueDLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001149 RID: 4425
		// (get) Token: 0x0600415D RID: 16733 RVA: 0x000D5B93 File Offset: 0x000D3F93
		public FlatBufferArray<UnionCell> ValueD
		{
			get
			{
				if (this.ValueDValue == null)
				{
					this.ValueDValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueDArray), this.ValueDLength);
				}
				return this.ValueDValue;
			}
		}

		// Token: 0x1700114A RID: 4426
		// (get) Token: 0x0600415E RID: 16734 RVA: 0x000D5BC4 File Offset: 0x000D3FC4
		public string DescriptionE
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600415F RID: 16735 RVA: 0x000D5C07 File Offset: 0x000D4007
		public ArraySegment<byte>? GetDescriptionEBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x06004160 RID: 16736 RVA: 0x000D5C18 File Offset: 0x000D4018
		public UnionCell ValueEArray(int j)
		{
			int num = this.__p.__offset(34);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700114B RID: 4427
		// (get) Token: 0x06004161 RID: 16737 RVA: 0x000D5C74 File Offset: 0x000D4074
		public int ValueELength
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700114C RID: 4428
		// (get) Token: 0x06004162 RID: 16738 RVA: 0x000D5CA7 File Offset: 0x000D40A7
		public FlatBufferArray<UnionCell> ValueE
		{
			get
			{
				if (this.ValueEValue == null)
				{
					this.ValueEValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueEArray), this.ValueELength);
				}
				return this.ValueEValue;
			}
		}

		// Token: 0x1700114D RID: 4429
		// (get) Token: 0x06004163 RID: 16739 RVA: 0x000D5CD8 File Offset: 0x000D40D8
		public string DescriptionF
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004164 RID: 16740 RVA: 0x000D5D1B File Offset: 0x000D411B
		public ArraySegment<byte>? GetDescriptionFBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x06004165 RID: 16741 RVA: 0x000D5D2C File Offset: 0x000D412C
		public UnionCell ValueFArray(int j)
		{
			int num = this.__p.__offset(38);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700114E RID: 4430
		// (get) Token: 0x06004166 RID: 16742 RVA: 0x000D5D88 File Offset: 0x000D4188
		public int ValueFLength
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700114F RID: 4431
		// (get) Token: 0x06004167 RID: 16743 RVA: 0x000D5DBB File Offset: 0x000D41BB
		public FlatBufferArray<UnionCell> ValueF
		{
			get
			{
				if (this.ValueFValue == null)
				{
					this.ValueFValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueFArray), this.ValueFLength);
				}
				return this.ValueFValue;
			}
		}

		// Token: 0x17001150 RID: 4432
		// (get) Token: 0x06004168 RID: 16744 RVA: 0x000D5DEC File Offset: 0x000D41EC
		public string DescriptionG
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004169 RID: 16745 RVA: 0x000D5E2F File Offset: 0x000D422F
		public ArraySegment<byte>? GetDescriptionGBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x0600416A RID: 16746 RVA: 0x000D5E40 File Offset: 0x000D4240
		public UnionCell ValueGArray(int j)
		{
			int num = this.__p.__offset(42);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17001151 RID: 4433
		// (get) Token: 0x0600416B RID: 16747 RVA: 0x000D5E9C File Offset: 0x000D429C
		public int ValueGLength
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001152 RID: 4434
		// (get) Token: 0x0600416C RID: 16748 RVA: 0x000D5ECF File Offset: 0x000D42CF
		public FlatBufferArray<UnionCell> ValueG
		{
			get
			{
				if (this.ValueGValue == null)
				{
					this.ValueGValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueGArray), this.ValueGLength);
				}
				return this.ValueGValue;
			}
		}

		// Token: 0x17001153 RID: 4435
		// (get) Token: 0x0600416D RID: 16749 RVA: 0x000D5F00 File Offset: 0x000D4300
		public string DescriptionH
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600416E RID: 16750 RVA: 0x000D5F43 File Offset: 0x000D4343
		public ArraySegment<byte>? GetDescriptionHBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x0600416F RID: 16751 RVA: 0x000D5F54 File Offset: 0x000D4354
		public UnionCell ValueHArray(int j)
		{
			int num = this.__p.__offset(46);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17001154 RID: 4436
		// (get) Token: 0x06004170 RID: 16752 RVA: 0x000D5FB0 File Offset: 0x000D43B0
		public int ValueHLength
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001155 RID: 4437
		// (get) Token: 0x06004171 RID: 16753 RVA: 0x000D5FE3 File Offset: 0x000D43E3
		public FlatBufferArray<UnionCell> ValueH
		{
			get
			{
				if (this.ValueHValue == null)
				{
					this.ValueHValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueHArray), this.ValueHLength);
				}
				return this.ValueHValue;
			}
		}

		// Token: 0x06004172 RID: 16754 RVA: 0x000D6014 File Offset: 0x000D4414
		public static Offset<MechanismTable> CreateMechanismTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescriptionOffset = default(StringOffset), int Index = 0, int RemoveFlag = 0, StringOffset StringDescriptionAOffset = default(StringOffset), VectorOffset StringValueAOffset = default(VectorOffset), StringOffset DescriptionAOffset = default(StringOffset), VectorOffset ValueAOffset = default(VectorOffset), StringOffset DescriptionBOffset = default(StringOffset), VectorOffset ValueBOffset = default(VectorOffset), StringOffset DescriptionCOffset = default(StringOffset), VectorOffset ValueCOffset = default(VectorOffset), StringOffset DescriptionDOffset = default(StringOffset), VectorOffset ValueDOffset = default(VectorOffset), StringOffset DescriptionEOffset = default(StringOffset), VectorOffset ValueEOffset = default(VectorOffset), StringOffset DescriptionFOffset = default(StringOffset), VectorOffset ValueFOffset = default(VectorOffset), StringOffset DescriptionGOffset = default(StringOffset), VectorOffset ValueGOffset = default(VectorOffset), StringOffset DescriptionHOffset = default(StringOffset), VectorOffset ValueHOffset = default(VectorOffset))
		{
			builder.StartObject(22);
			MechanismTable.AddValueH(builder, ValueHOffset);
			MechanismTable.AddDescriptionH(builder, DescriptionHOffset);
			MechanismTable.AddValueG(builder, ValueGOffset);
			MechanismTable.AddDescriptionG(builder, DescriptionGOffset);
			MechanismTable.AddValueF(builder, ValueFOffset);
			MechanismTable.AddDescriptionF(builder, DescriptionFOffset);
			MechanismTable.AddValueE(builder, ValueEOffset);
			MechanismTable.AddDescriptionE(builder, DescriptionEOffset);
			MechanismTable.AddValueD(builder, ValueDOffset);
			MechanismTable.AddDescriptionD(builder, DescriptionDOffset);
			MechanismTable.AddValueC(builder, ValueCOffset);
			MechanismTable.AddDescriptionC(builder, DescriptionCOffset);
			MechanismTable.AddValueB(builder, ValueBOffset);
			MechanismTable.AddDescriptionB(builder, DescriptionBOffset);
			MechanismTable.AddValueA(builder, ValueAOffset);
			MechanismTable.AddDescriptionA(builder, DescriptionAOffset);
			MechanismTable.AddStringValueA(builder, StringValueAOffset);
			MechanismTable.AddStringDescriptionA(builder, StringDescriptionAOffset);
			MechanismTable.AddRemoveFlag(builder, RemoveFlag);
			MechanismTable.AddIndex(builder, Index);
			MechanismTable.AddDescription(builder, DescriptionOffset);
			MechanismTable.AddID(builder, ID);
			return MechanismTable.EndMechanismTable(builder);
		}

		// Token: 0x06004173 RID: 16755 RVA: 0x000D60DC File Offset: 0x000D44DC
		public static void StartMechanismTable(FlatBufferBuilder builder)
		{
			builder.StartObject(22);
		}

		// Token: 0x06004174 RID: 16756 RVA: 0x000D60E6 File Offset: 0x000D44E6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004175 RID: 16757 RVA: 0x000D60F1 File Offset: 0x000D44F1
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(1, DescriptionOffset.Value, 0);
		}

		// Token: 0x06004176 RID: 16758 RVA: 0x000D6102 File Offset: 0x000D4502
		public static void AddIndex(FlatBufferBuilder builder, int Index)
		{
			builder.AddInt(2, Index, 0);
		}

		// Token: 0x06004177 RID: 16759 RVA: 0x000D610D File Offset: 0x000D450D
		public static void AddRemoveFlag(FlatBufferBuilder builder, int RemoveFlag)
		{
			builder.AddInt(3, RemoveFlag, 0);
		}

		// Token: 0x06004178 RID: 16760 RVA: 0x000D6118 File Offset: 0x000D4518
		public static void AddStringDescriptionA(FlatBufferBuilder builder, StringOffset StringDescriptionAOffset)
		{
			builder.AddOffset(4, StringDescriptionAOffset.Value, 0);
		}

		// Token: 0x06004179 RID: 16761 RVA: 0x000D6129 File Offset: 0x000D4529
		public static void AddStringValueA(FlatBufferBuilder builder, VectorOffset StringValueAOffset)
		{
			builder.AddOffset(5, StringValueAOffset.Value, 0);
		}

		// Token: 0x0600417A RID: 16762 RVA: 0x000D613C File Offset: 0x000D453C
		public static VectorOffset CreateStringValueAVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600417B RID: 16763 RVA: 0x000D6182 File Offset: 0x000D4582
		public static void StartStringValueAVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600417C RID: 16764 RVA: 0x000D618D File Offset: 0x000D458D
		public static void AddDescriptionA(FlatBufferBuilder builder, StringOffset DescriptionAOffset)
		{
			builder.AddOffset(6, DescriptionAOffset.Value, 0);
		}

		// Token: 0x0600417D RID: 16765 RVA: 0x000D619E File Offset: 0x000D459E
		public static void AddValueA(FlatBufferBuilder builder, VectorOffset ValueAOffset)
		{
			builder.AddOffset(7, ValueAOffset.Value, 0);
		}

		// Token: 0x0600417E RID: 16766 RVA: 0x000D61B0 File Offset: 0x000D45B0
		public static VectorOffset CreateValueAVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600417F RID: 16767 RVA: 0x000D61F6 File Offset: 0x000D45F6
		public static void StartValueAVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004180 RID: 16768 RVA: 0x000D6201 File Offset: 0x000D4601
		public static void AddDescriptionB(FlatBufferBuilder builder, StringOffset DescriptionBOffset)
		{
			builder.AddOffset(8, DescriptionBOffset.Value, 0);
		}

		// Token: 0x06004181 RID: 16769 RVA: 0x000D6212 File Offset: 0x000D4612
		public static void AddValueB(FlatBufferBuilder builder, VectorOffset ValueBOffset)
		{
			builder.AddOffset(9, ValueBOffset.Value, 0);
		}

		// Token: 0x06004182 RID: 16770 RVA: 0x000D6224 File Offset: 0x000D4624
		public static VectorOffset CreateValueBVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004183 RID: 16771 RVA: 0x000D626A File Offset: 0x000D466A
		public static void StartValueBVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004184 RID: 16772 RVA: 0x000D6275 File Offset: 0x000D4675
		public static void AddDescriptionC(FlatBufferBuilder builder, StringOffset DescriptionCOffset)
		{
			builder.AddOffset(10, DescriptionCOffset.Value, 0);
		}

		// Token: 0x06004185 RID: 16773 RVA: 0x000D6287 File Offset: 0x000D4687
		public static void AddValueC(FlatBufferBuilder builder, VectorOffset ValueCOffset)
		{
			builder.AddOffset(11, ValueCOffset.Value, 0);
		}

		// Token: 0x06004186 RID: 16774 RVA: 0x000D629C File Offset: 0x000D469C
		public static VectorOffset CreateValueCVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004187 RID: 16775 RVA: 0x000D62E2 File Offset: 0x000D46E2
		public static void StartValueCVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004188 RID: 16776 RVA: 0x000D62ED File Offset: 0x000D46ED
		public static void AddDescriptionD(FlatBufferBuilder builder, StringOffset DescriptionDOffset)
		{
			builder.AddOffset(12, DescriptionDOffset.Value, 0);
		}

		// Token: 0x06004189 RID: 16777 RVA: 0x000D62FF File Offset: 0x000D46FF
		public static void AddValueD(FlatBufferBuilder builder, VectorOffset ValueDOffset)
		{
			builder.AddOffset(13, ValueDOffset.Value, 0);
		}

		// Token: 0x0600418A RID: 16778 RVA: 0x000D6314 File Offset: 0x000D4714
		public static VectorOffset CreateValueDVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600418B RID: 16779 RVA: 0x000D635A File Offset: 0x000D475A
		public static void StartValueDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600418C RID: 16780 RVA: 0x000D6365 File Offset: 0x000D4765
		public static void AddDescriptionE(FlatBufferBuilder builder, StringOffset DescriptionEOffset)
		{
			builder.AddOffset(14, DescriptionEOffset.Value, 0);
		}

		// Token: 0x0600418D RID: 16781 RVA: 0x000D6377 File Offset: 0x000D4777
		public static void AddValueE(FlatBufferBuilder builder, VectorOffset ValueEOffset)
		{
			builder.AddOffset(15, ValueEOffset.Value, 0);
		}

		// Token: 0x0600418E RID: 16782 RVA: 0x000D638C File Offset: 0x000D478C
		public static VectorOffset CreateValueEVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600418F RID: 16783 RVA: 0x000D63D2 File Offset: 0x000D47D2
		public static void StartValueEVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004190 RID: 16784 RVA: 0x000D63DD File Offset: 0x000D47DD
		public static void AddDescriptionF(FlatBufferBuilder builder, StringOffset DescriptionFOffset)
		{
			builder.AddOffset(16, DescriptionFOffset.Value, 0);
		}

		// Token: 0x06004191 RID: 16785 RVA: 0x000D63EF File Offset: 0x000D47EF
		public static void AddValueF(FlatBufferBuilder builder, VectorOffset ValueFOffset)
		{
			builder.AddOffset(17, ValueFOffset.Value, 0);
		}

		// Token: 0x06004192 RID: 16786 RVA: 0x000D6404 File Offset: 0x000D4804
		public static VectorOffset CreateValueFVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004193 RID: 16787 RVA: 0x000D644A File Offset: 0x000D484A
		public static void StartValueFVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004194 RID: 16788 RVA: 0x000D6455 File Offset: 0x000D4855
		public static void AddDescriptionG(FlatBufferBuilder builder, StringOffset DescriptionGOffset)
		{
			builder.AddOffset(18, DescriptionGOffset.Value, 0);
		}

		// Token: 0x06004195 RID: 16789 RVA: 0x000D6467 File Offset: 0x000D4867
		public static void AddValueG(FlatBufferBuilder builder, VectorOffset ValueGOffset)
		{
			builder.AddOffset(19, ValueGOffset.Value, 0);
		}

		// Token: 0x06004196 RID: 16790 RVA: 0x000D647C File Offset: 0x000D487C
		public static VectorOffset CreateValueGVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004197 RID: 16791 RVA: 0x000D64C2 File Offset: 0x000D48C2
		public static void StartValueGVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004198 RID: 16792 RVA: 0x000D64CD File Offset: 0x000D48CD
		public static void AddDescriptionH(FlatBufferBuilder builder, StringOffset DescriptionHOffset)
		{
			builder.AddOffset(20, DescriptionHOffset.Value, 0);
		}

		// Token: 0x06004199 RID: 16793 RVA: 0x000D64DF File Offset: 0x000D48DF
		public static void AddValueH(FlatBufferBuilder builder, VectorOffset ValueHOffset)
		{
			builder.AddOffset(21, ValueHOffset.Value, 0);
		}

		// Token: 0x0600419A RID: 16794 RVA: 0x000D64F4 File Offset: 0x000D48F4
		public static VectorOffset CreateValueHVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600419B RID: 16795 RVA: 0x000D653A File Offset: 0x000D493A
		public static void StartValueHVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600419C RID: 16796 RVA: 0x000D6548 File Offset: 0x000D4948
		public static Offset<MechanismTable> EndMechanismTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MechanismTable>(value);
		}

		// Token: 0x0600419D RID: 16797 RVA: 0x000D6562 File Offset: 0x000D4962
		public static void FinishMechanismTableBuffer(FlatBufferBuilder builder, Offset<MechanismTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001870 RID: 6256
		private Table __p = new Table();

		// Token: 0x04001871 RID: 6257
		private FlatBufferArray<string> StringValueAValue;

		// Token: 0x04001872 RID: 6258
		private FlatBufferArray<UnionCell> ValueAValue;

		// Token: 0x04001873 RID: 6259
		private FlatBufferArray<UnionCell> ValueBValue;

		// Token: 0x04001874 RID: 6260
		private FlatBufferArray<UnionCell> ValueCValue;

		// Token: 0x04001875 RID: 6261
		private FlatBufferArray<UnionCell> ValueDValue;

		// Token: 0x04001876 RID: 6262
		private FlatBufferArray<UnionCell> ValueEValue;

		// Token: 0x04001877 RID: 6263
		private FlatBufferArray<UnionCell> ValueFValue;

		// Token: 0x04001878 RID: 6264
		private FlatBufferArray<UnionCell> ValueGValue;

		// Token: 0x04001879 RID: 6265
		private FlatBufferArray<UnionCell> ValueHValue;

		// Token: 0x020004FF RID: 1279
		public enum eCrypt
		{
			// Token: 0x0400187B RID: 6267
			code = -1599982151
		}
	}
}
