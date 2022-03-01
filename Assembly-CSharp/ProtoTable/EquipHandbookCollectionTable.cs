using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003E3 RID: 995
	public class EquipHandbookCollectionTable : IFlatbufferObject
	{
		// Token: 0x17000AD1 RID: 2769
		// (get) Token: 0x06002D82 RID: 11650 RVA: 0x000A6AB4 File Offset: 0x000A4EB4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002D83 RID: 11651 RVA: 0x000A6AC1 File Offset: 0x000A4EC1
		public static EquipHandbookCollectionTable GetRootAsEquipHandbookCollectionTable(ByteBuffer _bb)
		{
			return EquipHandbookCollectionTable.GetRootAsEquipHandbookCollectionTable(_bb, new EquipHandbookCollectionTable());
		}

		// Token: 0x06002D84 RID: 11652 RVA: 0x000A6ACE File Offset: 0x000A4ECE
		public static EquipHandbookCollectionTable GetRootAsEquipHandbookCollectionTable(ByteBuffer _bb, EquipHandbookCollectionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002D85 RID: 11653 RVA: 0x000A6AEA File Offset: 0x000A4EEA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002D86 RID: 11654 RVA: 0x000A6B04 File Offset: 0x000A4F04
		public EquipHandbookCollectionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000AD2 RID: 2770
		// (get) Token: 0x06002D87 RID: 11655 RVA: 0x000A6B10 File Offset: 0x000A4F10
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1484894878 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AD3 RID: 2771
		// (get) Token: 0x06002D88 RID: 11656 RVA: 0x000A6B5C File Offset: 0x000A4F5C
		public int EquipHandbookContentID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1484894878 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AD4 RID: 2772
		// (get) Token: 0x06002D89 RID: 11657 RVA: 0x000A6BA8 File Offset: 0x000A4FA8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002D8A RID: 11658 RVA: 0x000A6BEA File Offset: 0x000A4FEA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000AD5 RID: 2773
		// (get) Token: 0x06002D8B RID: 11659 RVA: 0x000A6BF8 File Offset: 0x000A4FF8
		public int SortOrder
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1484894878 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AD6 RID: 2774
		// (get) Token: 0x06002D8C RID: 11660 RVA: 0x000A6C44 File Offset: 0x000A5044
		public int Level
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1484894878 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AD7 RID: 2775
		// (get) Token: 0x06002D8D RID: 11661 RVA: 0x000A6C90 File Offset: 0x000A5090
		public EquipHandbookCollectionTable.eOccopationLimitType OccopationLimitType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (EquipHandbookCollectionTable.eOccopationLimitType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002D8E RID: 11662 RVA: 0x000A6CD4 File Offset: 0x000A50D4
		public int OccopationLimitArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (1484894878 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000AD8 RID: 2776
		// (get) Token: 0x06002D8F RID: 11663 RVA: 0x000A6D24 File Offset: 0x000A5124
		public int OccopationLimitLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002D90 RID: 11664 RVA: 0x000A6D57 File Offset: 0x000A5157
		public ArraySegment<byte>? GetOccopationLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000AD9 RID: 2777
		// (get) Token: 0x06002D91 RID: 11665 RVA: 0x000A6D66 File Offset: 0x000A5166
		public FlatBufferArray<int> OccopationLimit
		{
			get
			{
				if (this.OccopationLimitValue == null)
				{
					this.OccopationLimitValue = new FlatBufferArray<int>(new Func<int, int>(this.OccopationLimitArray), this.OccopationLimitLength);
				}
				return this.OccopationLimitValue;
			}
		}

		// Token: 0x17000ADA RID: 2778
		// (get) Token: 0x06002D92 RID: 11666 RVA: 0x000A6D98 File Offset: 0x000A5198
		public EquipHandbookCollectionTable.eScreenType ScreenType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (EquipHandbookCollectionTable.eScreenType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000ADB RID: 2779
		// (get) Token: 0x06002D93 RID: 11667 RVA: 0x000A6DDC File Offset: 0x000A51DC
		public EquipHandbookCollectionTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(20);
				return (EquipHandbookCollectionTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000ADC RID: 2780
		// (get) Token: 0x06002D94 RID: 11668 RVA: 0x000A6E20 File Offset: 0x000A5220
		public int EquipSuitID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1484894878 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002D95 RID: 11669 RVA: 0x000A6E6C File Offset: 0x000A526C
		public int CustomEquipIDsArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (1484894878 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000ADD RID: 2781
		// (get) Token: 0x06002D96 RID: 11670 RVA: 0x000A6EBC File Offset: 0x000A52BC
		public int CustomEquipIDsLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002D97 RID: 11671 RVA: 0x000A6EEF File Offset: 0x000A52EF
		public ArraySegment<byte>? GetCustomEquipIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000ADE RID: 2782
		// (get) Token: 0x06002D98 RID: 11672 RVA: 0x000A6EFE File Offset: 0x000A52FE
		public FlatBufferArray<int> CustomEquipIDs
		{
			get
			{
				if (this.CustomEquipIDsValue == null)
				{
					this.CustomEquipIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.CustomEquipIDsArray), this.CustomEquipIDsLength);
				}
				return this.CustomEquipIDsValue;
			}
		}

		// Token: 0x06002D99 RID: 11673 RVA: 0x000A6F30 File Offset: 0x000A5330
		public static Offset<EquipHandbookCollectionTable> CreateEquipHandbookCollectionTable(FlatBufferBuilder builder, int ID = 0, int EquipHandbookContentID = 0, StringOffset NameOffset = default(StringOffset), int SortOrder = 0, int Level = 0, EquipHandbookCollectionTable.eOccopationLimitType OccopationLimitType = EquipHandbookCollectionTable.eOccopationLimitType.eAccordingAttachedItem, VectorOffset OccopationLimitOffset = default(VectorOffset), EquipHandbookCollectionTable.eScreenType ScreenType = EquipHandbookCollectionTable.eScreenType.eNull, EquipHandbookCollectionTable.eType Type = EquipHandbookCollectionTable.eType.eCustom, int EquipSuitID = 0, VectorOffset CustomEquipIDsOffset = default(VectorOffset))
		{
			builder.StartObject(11);
			EquipHandbookCollectionTable.AddCustomEquipIDs(builder, CustomEquipIDsOffset);
			EquipHandbookCollectionTable.AddEquipSuitID(builder, EquipSuitID);
			EquipHandbookCollectionTable.AddType(builder, Type);
			EquipHandbookCollectionTable.AddScreenType(builder, ScreenType);
			EquipHandbookCollectionTable.AddOccopationLimit(builder, OccopationLimitOffset);
			EquipHandbookCollectionTable.AddOccopationLimitType(builder, OccopationLimitType);
			EquipHandbookCollectionTable.AddLevel(builder, Level);
			EquipHandbookCollectionTable.AddSortOrder(builder, SortOrder);
			EquipHandbookCollectionTable.AddName(builder, NameOffset);
			EquipHandbookCollectionTable.AddEquipHandbookContentID(builder, EquipHandbookContentID);
			EquipHandbookCollectionTable.AddID(builder, ID);
			return EquipHandbookCollectionTable.EndEquipHandbookCollectionTable(builder);
		}

		// Token: 0x06002D9A RID: 11674 RVA: 0x000A6FA0 File Offset: 0x000A53A0
		public static void StartEquipHandbookCollectionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x06002D9B RID: 11675 RVA: 0x000A6FAA File Offset: 0x000A53AA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002D9C RID: 11676 RVA: 0x000A6FB5 File Offset: 0x000A53B5
		public static void AddEquipHandbookContentID(FlatBufferBuilder builder, int EquipHandbookContentID)
		{
			builder.AddInt(1, EquipHandbookContentID, 0);
		}

		// Token: 0x06002D9D RID: 11677 RVA: 0x000A6FC0 File Offset: 0x000A53C0
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x06002D9E RID: 11678 RVA: 0x000A6FD1 File Offset: 0x000A53D1
		public static void AddSortOrder(FlatBufferBuilder builder, int SortOrder)
		{
			builder.AddInt(3, SortOrder, 0);
		}

		// Token: 0x06002D9F RID: 11679 RVA: 0x000A6FDC File Offset: 0x000A53DC
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(4, Level, 0);
		}

		// Token: 0x06002DA0 RID: 11680 RVA: 0x000A6FE7 File Offset: 0x000A53E7
		public static void AddOccopationLimitType(FlatBufferBuilder builder, EquipHandbookCollectionTable.eOccopationLimitType OccopationLimitType)
		{
			builder.AddInt(5, (int)OccopationLimitType, 0);
		}

		// Token: 0x06002DA1 RID: 11681 RVA: 0x000A6FF2 File Offset: 0x000A53F2
		public static void AddOccopationLimit(FlatBufferBuilder builder, VectorOffset OccopationLimitOffset)
		{
			builder.AddOffset(6, OccopationLimitOffset.Value, 0);
		}

		// Token: 0x06002DA2 RID: 11682 RVA: 0x000A7004 File Offset: 0x000A5404
		public static VectorOffset CreateOccopationLimitVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002DA3 RID: 11683 RVA: 0x000A7041 File Offset: 0x000A5441
		public static void StartOccopationLimitVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002DA4 RID: 11684 RVA: 0x000A704C File Offset: 0x000A544C
		public static void AddScreenType(FlatBufferBuilder builder, EquipHandbookCollectionTable.eScreenType ScreenType)
		{
			builder.AddInt(7, (int)ScreenType, 0);
		}

		// Token: 0x06002DA5 RID: 11685 RVA: 0x000A7057 File Offset: 0x000A5457
		public static void AddType(FlatBufferBuilder builder, EquipHandbookCollectionTable.eType Type)
		{
			builder.AddInt(8, (int)Type, 0);
		}

		// Token: 0x06002DA6 RID: 11686 RVA: 0x000A7062 File Offset: 0x000A5462
		public static void AddEquipSuitID(FlatBufferBuilder builder, int EquipSuitID)
		{
			builder.AddInt(9, EquipSuitID, 0);
		}

		// Token: 0x06002DA7 RID: 11687 RVA: 0x000A706E File Offset: 0x000A546E
		public static void AddCustomEquipIDs(FlatBufferBuilder builder, VectorOffset CustomEquipIDsOffset)
		{
			builder.AddOffset(10, CustomEquipIDsOffset.Value, 0);
		}

		// Token: 0x06002DA8 RID: 11688 RVA: 0x000A7080 File Offset: 0x000A5480
		public static VectorOffset CreateCustomEquipIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002DA9 RID: 11689 RVA: 0x000A70BD File Offset: 0x000A54BD
		public static void StartCustomEquipIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002DAA RID: 11690 RVA: 0x000A70C8 File Offset: 0x000A54C8
		public static Offset<EquipHandbookCollectionTable> EndEquipHandbookCollectionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipHandbookCollectionTable>(value);
		}

		// Token: 0x06002DAB RID: 11691 RVA: 0x000A70E2 File Offset: 0x000A54E2
		public static void FinishEquipHandbookCollectionTableBuffer(FlatBufferBuilder builder, Offset<EquipHandbookCollectionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001342 RID: 4930
		private Table __p = new Table();

		// Token: 0x04001343 RID: 4931
		private FlatBufferArray<int> OccopationLimitValue;

		// Token: 0x04001344 RID: 4932
		private FlatBufferArray<int> CustomEquipIDsValue;

		// Token: 0x020003E4 RID: 996
		public enum eOccopationLimitType
		{
			// Token: 0x04001346 RID: 4934
			eAccordingAttachedItem,
			// Token: 0x04001347 RID: 4935
			eAccordingOccuptionLimit
		}

		// Token: 0x020003E5 RID: 997
		public enum eScreenType
		{
			// Token: 0x04001349 RID: 4937
			eNull,
			// Token: 0x0400134A RID: 4938
			eWeapon,
			// Token: 0x0400134B RID: 4939
			eArmor,
			// Token: 0x0400134C RID: 4940
			eJewelry
		}

		// Token: 0x020003E6 RID: 998
		public enum eType
		{
			// Token: 0x0400134E RID: 4942
			eCustom,
			// Token: 0x0400134F RID: 4943
			eEquipSuit
		}

		// Token: 0x020003E7 RID: 999
		public enum eCrypt
		{
			// Token: 0x04001351 RID: 4945
			code = 1484894878
		}
	}
}
