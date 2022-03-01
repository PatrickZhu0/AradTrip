using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003A5 RID: 933
	public class DungeonModelTable : IFlatbufferObject
	{
		// Token: 0x17000929 RID: 2345
		// (get) Token: 0x060028BA RID: 10426 RVA: 0x0009AB00 File Offset: 0x00098F00
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060028BB RID: 10427 RVA: 0x0009AB0D File Offset: 0x00098F0D
		public static DungeonModelTable GetRootAsDungeonModelTable(ByteBuffer _bb)
		{
			return DungeonModelTable.GetRootAsDungeonModelTable(_bb, new DungeonModelTable());
		}

		// Token: 0x060028BC RID: 10428 RVA: 0x0009AB1A File Offset: 0x00098F1A
		public static DungeonModelTable GetRootAsDungeonModelTable(ByteBuffer _bb, DungeonModelTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060028BD RID: 10429 RVA: 0x0009AB36 File Offset: 0x00098F36
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x0009AB50 File Offset: 0x00098F50
		public DungeonModelTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700092A RID: 2346
		// (get) Token: 0x060028BF RID: 10431 RVA: 0x0009AB5C File Offset: 0x00098F5C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (63793921 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700092B RID: 2347
		// (get) Token: 0x060028C0 RID: 10432 RVA: 0x0009ABA8 File Offset: 0x00098FA8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060028C1 RID: 10433 RVA: 0x0009ABEA File Offset: 0x00098FEA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700092C RID: 2348
		// (get) Token: 0x060028C2 RID: 10434 RVA: 0x0009ABF8 File Offset: 0x00098FF8
		public DungeonModelTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (DungeonModelTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700092D RID: 2349
		// (get) Token: 0x060028C3 RID: 10435 RVA: 0x0009AC3C File Offset: 0x0009903C
		public int Level
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (63793921 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700092E RID: 2350
		// (get) Token: 0x060028C4 RID: 10436 RVA: 0x0009AC88 File Offset: 0x00099088
		public int mapID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (63793921 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060028C5 RID: 10437 RVA: 0x0009ACD4 File Offset: 0x000990D4
		public int DropShowArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (63793921 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700092F RID: 2351
		// (get) Token: 0x060028C6 RID: 10438 RVA: 0x0009AD24 File Offset: 0x00099124
		public int DropShowLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060028C7 RID: 10439 RVA: 0x0009AD57 File Offset: 0x00099157
		public ArraySegment<byte>? GetDropShowBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000930 RID: 2352
		// (get) Token: 0x060028C8 RID: 10440 RVA: 0x0009AD66 File Offset: 0x00099166
		public FlatBufferArray<int> DropShow
		{
			get
			{
				if (this.DropShowValue == null)
				{
					this.DropShowValue = new FlatBufferArray<int>(new Func<int, int>(this.DropShowArray), this.DropShowLength);
				}
				return this.DropShowValue;
			}
		}

		// Token: 0x060028C9 RID: 10441 RVA: 0x0009AD98 File Offset: 0x00099198
		public int CostItemArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (63793921 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000931 RID: 2353
		// (get) Token: 0x060028CA RID: 10442 RVA: 0x0009ADE8 File Offset: 0x000991E8
		public int CostItemLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060028CB RID: 10443 RVA: 0x0009AE1B File Offset: 0x0009921B
		public ArraySegment<byte>? GetCostItemBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000932 RID: 2354
		// (get) Token: 0x060028CC RID: 10444 RVA: 0x0009AE2A File Offset: 0x0009922A
		public FlatBufferArray<int> CostItem
		{
			get
			{
				if (this.CostItemValue == null)
				{
					this.CostItemValue = new FlatBufferArray<int>(new Func<int, int>(this.CostItemArray), this.CostItemLength);
				}
				return this.CostItemValue;
			}
		}

		// Token: 0x17000933 RID: 2355
		// (get) Token: 0x060028CD RID: 10445 RVA: 0x0009AE5C File Offset: 0x0009925C
		public int IsShowSpriteConsume
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (63793921 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000934 RID: 2356
		// (get) Token: 0x060028CE RID: 10446 RVA: 0x0009AEA8 File Offset: 0x000992A8
		public int IsShowTab
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (63793921 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060028CF RID: 10447 RVA: 0x0009AEF4 File Offset: 0x000992F4
		public static Offset<DungeonModelTable> CreateDungeonModelTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), DungeonModelTable.eType Type = DungeonModelTable.eType.Type_None, int Level = 0, int mapID = 0, VectorOffset DropShowOffset = default(VectorOffset), VectorOffset CostItemOffset = default(VectorOffset), int IsShowSpriteConsume = 0, int IsShowTab = 0)
		{
			builder.StartObject(9);
			DungeonModelTable.AddIsShowTab(builder, IsShowTab);
			DungeonModelTable.AddIsShowSpriteConsume(builder, IsShowSpriteConsume);
			DungeonModelTable.AddCostItem(builder, CostItemOffset);
			DungeonModelTable.AddDropShow(builder, DropShowOffset);
			DungeonModelTable.AddMapID(builder, mapID);
			DungeonModelTable.AddLevel(builder, Level);
			DungeonModelTable.AddType(builder, Type);
			DungeonModelTable.AddName(builder, NameOffset);
			DungeonModelTable.AddID(builder, ID);
			return DungeonModelTable.EndDungeonModelTable(builder);
		}

		// Token: 0x060028D0 RID: 10448 RVA: 0x0009AF54 File Offset: 0x00099354
		public static void StartDungeonModelTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x060028D1 RID: 10449 RVA: 0x0009AF5E File Offset: 0x0009935E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060028D2 RID: 10450 RVA: 0x0009AF69 File Offset: 0x00099369
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060028D3 RID: 10451 RVA: 0x0009AF7A File Offset: 0x0009937A
		public static void AddType(FlatBufferBuilder builder, DungeonModelTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x060028D4 RID: 10452 RVA: 0x0009AF85 File Offset: 0x00099385
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(3, Level, 0);
		}

		// Token: 0x060028D5 RID: 10453 RVA: 0x0009AF90 File Offset: 0x00099390
		public static void AddMapID(FlatBufferBuilder builder, int mapID)
		{
			builder.AddInt(4, mapID, 0);
		}

		// Token: 0x060028D6 RID: 10454 RVA: 0x0009AF9B File Offset: 0x0009939B
		public static void AddDropShow(FlatBufferBuilder builder, VectorOffset DropShowOffset)
		{
			builder.AddOffset(5, DropShowOffset.Value, 0);
		}

		// Token: 0x060028D7 RID: 10455 RVA: 0x0009AFAC File Offset: 0x000993AC
		public static VectorOffset CreateDropShowVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060028D8 RID: 10456 RVA: 0x0009AFE9 File Offset: 0x000993E9
		public static void StartDropShowVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060028D9 RID: 10457 RVA: 0x0009AFF4 File Offset: 0x000993F4
		public static void AddCostItem(FlatBufferBuilder builder, VectorOffset CostItemOffset)
		{
			builder.AddOffset(6, CostItemOffset.Value, 0);
		}

		// Token: 0x060028DA RID: 10458 RVA: 0x0009B008 File Offset: 0x00099408
		public static VectorOffset CreateCostItemVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060028DB RID: 10459 RVA: 0x0009B045 File Offset: 0x00099445
		public static void StartCostItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060028DC RID: 10460 RVA: 0x0009B050 File Offset: 0x00099450
		public static void AddIsShowSpriteConsume(FlatBufferBuilder builder, int IsShowSpriteConsume)
		{
			builder.AddInt(7, IsShowSpriteConsume, 0);
		}

		// Token: 0x060028DD RID: 10461 RVA: 0x0009B05B File Offset: 0x0009945B
		public static void AddIsShowTab(FlatBufferBuilder builder, int IsShowTab)
		{
			builder.AddInt(8, IsShowTab, 0);
		}

		// Token: 0x060028DE RID: 10462 RVA: 0x0009B068 File Offset: 0x00099468
		public static Offset<DungeonModelTable> EndDungeonModelTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonModelTable>(value);
		}

		// Token: 0x060028DF RID: 10463 RVA: 0x0009B082 File Offset: 0x00099482
		public static void FinishDungeonModelTableBuffer(FlatBufferBuilder builder, Offset<DungeonModelTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011EE RID: 4590
		private Table __p = new Table();

		// Token: 0x040011EF RID: 4591
		private FlatBufferArray<int> DropShowValue;

		// Token: 0x040011F0 RID: 4592
		private FlatBufferArray<int> CostItemValue;

		// Token: 0x020003A6 RID: 934
		public enum eType
		{
			// Token: 0x040011F2 RID: 4594
			Type_None,
			// Token: 0x040011F3 RID: 4595
			DeepModel,
			// Token: 0x040011F4 RID: 4596
			AncientModel,
			// Token: 0x040011F5 RID: 4597
			WeekHellModel,
			// Token: 0x040011F6 RID: 4598
			VoidCrackModel,
			// Token: 0x040011F7 RID: 4599
			TeamDuplicationModel
		}

		// Token: 0x020003A7 RID: 935
		public enum eCrypt
		{
			// Token: 0x040011F9 RID: 4601
			code = 63793921
		}
	}
}
