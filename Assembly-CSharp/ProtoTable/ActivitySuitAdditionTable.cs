using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000284 RID: 644
	public class ActivitySuitAdditionTable : IFlatbufferObject
	{
		// Token: 0x1700031A RID: 794
		// (get) Token: 0x060016A4 RID: 5796 RVA: 0x0006FD7C File Offset: 0x0006E17C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060016A5 RID: 5797 RVA: 0x0006FD89 File Offset: 0x0006E189
		public static ActivitySuitAdditionTable GetRootAsActivitySuitAdditionTable(ByteBuffer _bb)
		{
			return ActivitySuitAdditionTable.GetRootAsActivitySuitAdditionTable(_bb, new ActivitySuitAdditionTable());
		}

		// Token: 0x060016A6 RID: 5798 RVA: 0x0006FD96 File Offset: 0x0006E196
		public static ActivitySuitAdditionTable GetRootAsActivitySuitAdditionTable(ByteBuffer _bb, ActivitySuitAdditionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060016A7 RID: 5799 RVA: 0x0006FDB2 File Offset: 0x0006E1B2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060016A8 RID: 5800 RVA: 0x0006FDCC File Offset: 0x0006E1CC
		public ActivitySuitAdditionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x060016A9 RID: 5801 RVA: 0x0006FDD8 File Offset: 0x0006E1D8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-872320888 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x060016AA RID: 5802 RVA: 0x0006FE24 File Offset: 0x0006E224
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-872320888 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060016AB RID: 5803 RVA: 0x0006FE70 File Offset: 0x0006E270
		public int EquipListArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-872320888 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x060016AC RID: 5804 RVA: 0x0006FEBC File Offset: 0x0006E2BC
		public int EquipListLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060016AD RID: 5805 RVA: 0x0006FEEE File Offset: 0x0006E2EE
		public ArraySegment<byte>? GetEquipListBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x060016AE RID: 5806 RVA: 0x0006FEFC File Offset: 0x0006E2FC
		public FlatBufferArray<int> EquipList
		{
			get
			{
				if (this.EquipListValue == null)
				{
					this.EquipListValue = new FlatBufferArray<int>(new Func<int, int>(this.EquipListArray), this.EquipListLength);
				}
				return this.EquipListValue;
			}
		}

		// Token: 0x060016AF RID: 5807 RVA: 0x0006FF2C File Offset: 0x0006E32C
		public int ActivityListArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-872320888 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x0006FF7C File Offset: 0x0006E37C
		public int ActivityListLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060016B1 RID: 5809 RVA: 0x0006FFAF File Offset: 0x0006E3AF
		public ArraySegment<byte>? GetActivityListBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x060016B2 RID: 5810 RVA: 0x0006FFBE File Offset: 0x0006E3BE
		public FlatBufferArray<int> ActivityList
		{
			get
			{
				if (this.ActivityListValue == null)
				{
					this.ActivityListValue = new FlatBufferArray<int>(new Func<int, int>(this.ActivityListArray), this.ActivityListLength);
				}
				return this.ActivityListValue;
			}
		}

		// Token: 0x060016B3 RID: 5811 RVA: 0x0006FFF0 File Offset: 0x0006E3F0
		public int DoubleDropItemArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-872320888 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x060016B4 RID: 5812 RVA: 0x00070040 File Offset: 0x0006E440
		public int DoubleDropItemLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060016B5 RID: 5813 RVA: 0x00070073 File Offset: 0x0006E473
		public ArraySegment<byte>? GetDoubleDropItemBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x060016B6 RID: 5814 RVA: 0x00070082 File Offset: 0x0006E482
		public FlatBufferArray<int> DoubleDropItem
		{
			get
			{
				if (this.DoubleDropItemValue == null)
				{
					this.DoubleDropItemValue = new FlatBufferArray<int>(new Func<int, int>(this.DoubleDropItemArray), this.DoubleDropItemLength);
				}
				return this.DoubleDropItemValue;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x060016B7 RID: 5815 RVA: 0x000700B4 File Offset: 0x0006E4B4
		public int DoubleDropRate
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-872320888 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x060016B8 RID: 5816 RVA: 0x00070100 File Offset: 0x0006E500
		public int MonsterRate1
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-872320888 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x060016B9 RID: 5817 RVA: 0x0007014C File Offset: 0x0006E54C
		public int MonsterRate2
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-872320888 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x060016BA RID: 5818 RVA: 0x00070198 File Offset: 0x0006E598
		public int MonsterRate3
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-872320888 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060016BB RID: 5819 RVA: 0x000701E4 File Offset: 0x0006E5E4
		public static Offset<ActivitySuitAdditionTable> CreateActivitySuitAdditionTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, VectorOffset EquipListOffset = default(VectorOffset), VectorOffset ActivityListOffset = default(VectorOffset), VectorOffset DoubleDropItemOffset = default(VectorOffset), int DoubleDropRate = 0, int MonsterRate1 = 0, int MonsterRate2 = 0, int MonsterRate3 = 0)
		{
			builder.StartObject(9);
			ActivitySuitAdditionTable.AddMonsterRate3(builder, MonsterRate3);
			ActivitySuitAdditionTable.AddMonsterRate2(builder, MonsterRate2);
			ActivitySuitAdditionTable.AddMonsterRate1(builder, MonsterRate1);
			ActivitySuitAdditionTable.AddDoubleDropRate(builder, DoubleDropRate);
			ActivitySuitAdditionTable.AddDoubleDropItem(builder, DoubleDropItemOffset);
			ActivitySuitAdditionTable.AddActivityList(builder, ActivityListOffset);
			ActivitySuitAdditionTable.AddEquipList(builder, EquipListOffset);
			ActivitySuitAdditionTable.AddType(builder, Type);
			ActivitySuitAdditionTable.AddID(builder, ID);
			return ActivitySuitAdditionTable.EndActivitySuitAdditionTable(builder);
		}

		// Token: 0x060016BC RID: 5820 RVA: 0x00070244 File Offset: 0x0006E644
		public static void StartActivitySuitAdditionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x060016BD RID: 5821 RVA: 0x0007024E File Offset: 0x0006E64E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060016BE RID: 5822 RVA: 0x00070259 File Offset: 0x0006E659
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x00070264 File Offset: 0x0006E664
		public static void AddEquipList(FlatBufferBuilder builder, VectorOffset EquipListOffset)
		{
			builder.AddOffset(2, EquipListOffset.Value, 0);
		}

		// Token: 0x060016C0 RID: 5824 RVA: 0x00070278 File Offset: 0x0006E678
		public static VectorOffset CreateEquipListVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060016C1 RID: 5825 RVA: 0x000702B5 File Offset: 0x0006E6B5
		public static void StartEquipListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060016C2 RID: 5826 RVA: 0x000702C0 File Offset: 0x0006E6C0
		public static void AddActivityList(FlatBufferBuilder builder, VectorOffset ActivityListOffset)
		{
			builder.AddOffset(3, ActivityListOffset.Value, 0);
		}

		// Token: 0x060016C3 RID: 5827 RVA: 0x000702D4 File Offset: 0x0006E6D4
		public static VectorOffset CreateActivityListVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060016C4 RID: 5828 RVA: 0x00070311 File Offset: 0x0006E711
		public static void StartActivityListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060016C5 RID: 5829 RVA: 0x0007031C File Offset: 0x0006E71C
		public static void AddDoubleDropItem(FlatBufferBuilder builder, VectorOffset DoubleDropItemOffset)
		{
			builder.AddOffset(4, DoubleDropItemOffset.Value, 0);
		}

		// Token: 0x060016C6 RID: 5830 RVA: 0x00070330 File Offset: 0x0006E730
		public static VectorOffset CreateDoubleDropItemVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060016C7 RID: 5831 RVA: 0x0007036D File Offset: 0x0006E76D
		public static void StartDoubleDropItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060016C8 RID: 5832 RVA: 0x00070378 File Offset: 0x0006E778
		public static void AddDoubleDropRate(FlatBufferBuilder builder, int DoubleDropRate)
		{
			builder.AddInt(5, DoubleDropRate, 0);
		}

		// Token: 0x060016C9 RID: 5833 RVA: 0x00070383 File Offset: 0x0006E783
		public static void AddMonsterRate1(FlatBufferBuilder builder, int MonsterRate1)
		{
			builder.AddInt(6, MonsterRate1, 0);
		}

		// Token: 0x060016CA RID: 5834 RVA: 0x0007038E File Offset: 0x0006E78E
		public static void AddMonsterRate2(FlatBufferBuilder builder, int MonsterRate2)
		{
			builder.AddInt(7, MonsterRate2, 0);
		}

		// Token: 0x060016CB RID: 5835 RVA: 0x00070399 File Offset: 0x0006E799
		public static void AddMonsterRate3(FlatBufferBuilder builder, int MonsterRate3)
		{
			builder.AddInt(8, MonsterRate3, 0);
		}

		// Token: 0x060016CC RID: 5836 RVA: 0x000703A4 File Offset: 0x0006E7A4
		public static Offset<ActivitySuitAdditionTable> EndActivitySuitAdditionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ActivitySuitAdditionTable>(value);
		}

		// Token: 0x060016CD RID: 5837 RVA: 0x000703BE File Offset: 0x0006E7BE
		public static void FinishActivitySuitAdditionTableBuffer(FlatBufferBuilder builder, Offset<ActivitySuitAdditionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DB2 RID: 3506
		private Table __p = new Table();

		// Token: 0x04000DB3 RID: 3507
		private FlatBufferArray<int> EquipListValue;

		// Token: 0x04000DB4 RID: 3508
		private FlatBufferArray<int> ActivityListValue;

		// Token: 0x04000DB5 RID: 3509
		private FlatBufferArray<int> DoubleDropItemValue;

		// Token: 0x02000285 RID: 645
		public enum eCrypt
		{
			// Token: 0x04000DB7 RID: 3511
			code = -872320888
		}
	}
}
