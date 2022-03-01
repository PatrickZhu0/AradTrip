using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000539 RID: 1337
	public class OneKeyWearTable : IFlatbufferObject
	{
		// Token: 0x17001266 RID: 4710
		// (get) Token: 0x060044C7 RID: 17607 RVA: 0x000DDB4C File Offset: 0x000DBF4C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060044C8 RID: 17608 RVA: 0x000DDB59 File Offset: 0x000DBF59
		public static OneKeyWearTable GetRootAsOneKeyWearTable(ByteBuffer _bb)
		{
			return OneKeyWearTable.GetRootAsOneKeyWearTable(_bb, new OneKeyWearTable());
		}

		// Token: 0x060044C9 RID: 17609 RVA: 0x000DDB66 File Offset: 0x000DBF66
		public static OneKeyWearTable GetRootAsOneKeyWearTable(ByteBuffer _bb, OneKeyWearTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060044CA RID: 17610 RVA: 0x000DDB82 File Offset: 0x000DBF82
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060044CB RID: 17611 RVA: 0x000DDB9C File Offset: 0x000DBF9C
		public OneKeyWearTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001267 RID: 4711
		// (get) Token: 0x060044CC RID: 17612 RVA: 0x000DDBA8 File Offset: 0x000DBFA8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1060501672 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001268 RID: 4712
		// (get) Token: 0x060044CD RID: 17613 RVA: 0x000DDBF4 File Offset: 0x000DBFF4
		public int Job
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1060501672 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001269 RID: 4713
		// (get) Token: 0x060044CE RID: 17614 RVA: 0x000DDC40 File Offset: 0x000DC040
		public string JobName
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060044CF RID: 17615 RVA: 0x000DDC82 File Offset: 0x000DC082
		public ArraySegment<byte>? GetJobNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700126A RID: 4714
		// (get) Token: 0x060044D0 RID: 17616 RVA: 0x000DDC90 File Offset: 0x000DC090
		public string Name
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060044D1 RID: 17617 RVA: 0x000DDCD3 File Offset: 0x000DC0D3
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x060044D2 RID: 17618 RVA: 0x000DDCE4 File Offset: 0x000DC0E4
		public UnionCell EquipListArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700126B RID: 4715
		// (get) Token: 0x060044D3 RID: 17619 RVA: 0x000DDD40 File Offset: 0x000DC140
		public int EquipListLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700126C RID: 4716
		// (get) Token: 0x060044D4 RID: 17620 RVA: 0x000DDD73 File Offset: 0x000DC173
		public FlatBufferArray<UnionCell> EquipList
		{
			get
			{
				if (this.EquipListValue == null)
				{
					this.EquipListValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.EquipListArray), this.EquipListLength);
				}
				return this.EquipListValue;
			}
		}

		// Token: 0x060044D5 RID: 17621 RVA: 0x000DDDA4 File Offset: 0x000DC1A4
		public UnionCell FashionListArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700126D RID: 4717
		// (get) Token: 0x060044D6 RID: 17622 RVA: 0x000DDE00 File Offset: 0x000DC200
		public int FashionListLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700126E RID: 4718
		// (get) Token: 0x060044D7 RID: 17623 RVA: 0x000DDE33 File Offset: 0x000DC233
		public FlatBufferArray<UnionCell> FashionList
		{
			get
			{
				if (this.FashionListValue == null)
				{
					this.FashionListValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.FashionListArray), this.FashionListLength);
				}
				return this.FashionListValue;
			}
		}

		// Token: 0x1700126F RID: 4719
		// (get) Token: 0x060044D8 RID: 17624 RVA: 0x000DDE64 File Offset: 0x000DC264
		public OneKeyWearTable.eEquipType EquipType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (OneKeyWearTable.eEquipType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001270 RID: 4720
		// (get) Token: 0x060044D9 RID: 17625 RVA: 0x000DDEA8 File Offset: 0x000DC2A8
		public OneKeyWearTable.eEnhanceType EnhanceType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (OneKeyWearTable.eEnhanceType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060044DA RID: 17626 RVA: 0x000DDEEC File Offset: 0x000DC2EC
		public static Offset<OneKeyWearTable> CreateOneKeyWearTable(FlatBufferBuilder builder, int ID = 0, int Job = 0, StringOffset JobNameOffset = default(StringOffset), StringOffset NameOffset = default(StringOffset), VectorOffset EquipListOffset = default(VectorOffset), VectorOffset FashionListOffset = default(VectorOffset), OneKeyWearTable.eEquipType EquipType = OneKeyWearTable.eEquipType.EQUIP_NORMAL, OneKeyWearTable.eEnhanceType EnhanceType = OneKeyWearTable.eEnhanceType.ENHANCE_INVALID)
		{
			builder.StartObject(8);
			OneKeyWearTable.AddEnhanceType(builder, EnhanceType);
			OneKeyWearTable.AddEquipType(builder, EquipType);
			OneKeyWearTable.AddFashionList(builder, FashionListOffset);
			OneKeyWearTable.AddEquipList(builder, EquipListOffset);
			OneKeyWearTable.AddName(builder, NameOffset);
			OneKeyWearTable.AddJobName(builder, JobNameOffset);
			OneKeyWearTable.AddJob(builder, Job);
			OneKeyWearTable.AddID(builder, ID);
			return OneKeyWearTable.EndOneKeyWearTable(builder);
		}

		// Token: 0x060044DB RID: 17627 RVA: 0x000DDF43 File Offset: 0x000DC343
		public static void StartOneKeyWearTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x060044DC RID: 17628 RVA: 0x000DDF4C File Offset: 0x000DC34C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060044DD RID: 17629 RVA: 0x000DDF57 File Offset: 0x000DC357
		public static void AddJob(FlatBufferBuilder builder, int Job)
		{
			builder.AddInt(1, Job, 0);
		}

		// Token: 0x060044DE RID: 17630 RVA: 0x000DDF62 File Offset: 0x000DC362
		public static void AddJobName(FlatBufferBuilder builder, StringOffset JobNameOffset)
		{
			builder.AddOffset(2, JobNameOffset.Value, 0);
		}

		// Token: 0x060044DF RID: 17631 RVA: 0x000DDF73 File Offset: 0x000DC373
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(3, NameOffset.Value, 0);
		}

		// Token: 0x060044E0 RID: 17632 RVA: 0x000DDF84 File Offset: 0x000DC384
		public static void AddEquipList(FlatBufferBuilder builder, VectorOffset EquipListOffset)
		{
			builder.AddOffset(4, EquipListOffset.Value, 0);
		}

		// Token: 0x060044E1 RID: 17633 RVA: 0x000DDF98 File Offset: 0x000DC398
		public static VectorOffset CreateEquipListVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060044E2 RID: 17634 RVA: 0x000DDFDE File Offset: 0x000DC3DE
		public static void StartEquipListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060044E3 RID: 17635 RVA: 0x000DDFE9 File Offset: 0x000DC3E9
		public static void AddFashionList(FlatBufferBuilder builder, VectorOffset FashionListOffset)
		{
			builder.AddOffset(5, FashionListOffset.Value, 0);
		}

		// Token: 0x060044E4 RID: 17636 RVA: 0x000DDFFC File Offset: 0x000DC3FC
		public static VectorOffset CreateFashionListVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060044E5 RID: 17637 RVA: 0x000DE042 File Offset: 0x000DC442
		public static void StartFashionListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060044E6 RID: 17638 RVA: 0x000DE04D File Offset: 0x000DC44D
		public static void AddEquipType(FlatBufferBuilder builder, OneKeyWearTable.eEquipType EquipType)
		{
			builder.AddInt(6, (int)EquipType, 0);
		}

		// Token: 0x060044E7 RID: 17639 RVA: 0x000DE058 File Offset: 0x000DC458
		public static void AddEnhanceType(FlatBufferBuilder builder, OneKeyWearTable.eEnhanceType EnhanceType)
		{
			builder.AddInt(7, (int)EnhanceType, 0);
		}

		// Token: 0x060044E8 RID: 17640 RVA: 0x000DE064 File Offset: 0x000DC464
		public static Offset<OneKeyWearTable> EndOneKeyWearTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<OneKeyWearTable>(value);
		}

		// Token: 0x060044E9 RID: 17641 RVA: 0x000DE07E File Offset: 0x000DC47E
		public static void FinishOneKeyWearTableBuffer(FlatBufferBuilder builder, Offset<OneKeyWearTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001984 RID: 6532
		private Table __p = new Table();

		// Token: 0x04001985 RID: 6533
		private FlatBufferArray<UnionCell> EquipListValue;

		// Token: 0x04001986 RID: 6534
		private FlatBufferArray<UnionCell> FashionListValue;

		// Token: 0x0200053A RID: 1338
		public enum eEquipType
		{
			// Token: 0x04001988 RID: 6536
			EQUIP_NORMAL,
			// Token: 0x04001989 RID: 6537
			EQUIP_HAVE_SMELL,
			// Token: 0x0400198A RID: 6538
			EQUIP_RED
		}

		// Token: 0x0200053B RID: 1339
		public enum eEnhanceType
		{
			// Token: 0x0400198C RID: 6540
			ENHANCE_INVALID,
			// Token: 0x0400198D RID: 6541
			ENHANCE_STRENTH,
			// Token: 0x0400198E RID: 6542
			ENHANCE_INTELLECT,
			// Token: 0x0400198F RID: 6543
			ENHANCE_STAMINA,
			// Token: 0x04001990 RID: 6544
			ENHANCE_SPIRIT
		}

		// Token: 0x0200053C RID: 1340
		public enum eCrypt
		{
			// Token: 0x04001992 RID: 6546
			code = -1060501672
		}
	}
}
