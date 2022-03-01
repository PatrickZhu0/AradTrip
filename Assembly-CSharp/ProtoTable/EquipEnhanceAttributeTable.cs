using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003DB RID: 987
	public class EquipEnhanceAttributeTable : IFlatbufferObject
	{
		// Token: 0x17000AA5 RID: 2725
		// (get) Token: 0x06002CF2 RID: 11506 RVA: 0x000A55F4 File Offset: 0x000A39F4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002CF3 RID: 11507 RVA: 0x000A5601 File Offset: 0x000A3A01
		public static EquipEnhanceAttributeTable GetRootAsEquipEnhanceAttributeTable(ByteBuffer _bb)
		{
			return EquipEnhanceAttributeTable.GetRootAsEquipEnhanceAttributeTable(_bb, new EquipEnhanceAttributeTable());
		}

		// Token: 0x06002CF4 RID: 11508 RVA: 0x000A560E File Offset: 0x000A3A0E
		public static EquipEnhanceAttributeTable GetRootAsEquipEnhanceAttributeTable(ByteBuffer _bb, EquipEnhanceAttributeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002CF5 RID: 11509 RVA: 0x000A562A File Offset: 0x000A3A2A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002CF6 RID: 11510 RVA: 0x000A5644 File Offset: 0x000A3A44
		public EquipEnhanceAttributeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000AA6 RID: 2726
		// (get) Token: 0x06002CF7 RID: 11511 RVA: 0x000A5650 File Offset: 0x000A3A50
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-845456548 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AA7 RID: 2727
		// (get) Token: 0x06002CF8 RID: 11512 RVA: 0x000A569C File Offset: 0x000A3A9C
		public int Quality
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-845456548 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AA8 RID: 2728
		// (get) Token: 0x06002CF9 RID: 11513 RVA: 0x000A56E8 File Offset: 0x000A3AE8
		public int EnhanceLevel
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-845456548 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AA9 RID: 2729
		// (get) Token: 0x06002CFA RID: 11514 RVA: 0x000A5734 File Offset: 0x000A3B34
		public int Level
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-845456548 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AAA RID: 2730
		// (get) Token: 0x06002CFB RID: 11515 RVA: 0x000A5780 File Offset: 0x000A3B80
		public int EnhanceAttribute
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-845456548 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AAB RID: 2731
		// (get) Token: 0x06002CFC RID: 11516 RVA: 0x000A57CC File Offset: 0x000A3BCC
		public int EnhanceAttributePVP
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-845456548 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AAC RID: 2732
		// (get) Token: 0x06002CFD RID: 11517 RVA: 0x000A5818 File Offset: 0x000A3C18
		public int eqScore
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-845456548 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002CFE RID: 11518 RVA: 0x000A5864 File Offset: 0x000A3C64
		public static Offset<EquipEnhanceAttributeTable> CreateEquipEnhanceAttributeTable(FlatBufferBuilder builder, int ID = 0, int Quality = 0, int EnhanceLevel = 0, int Level = 0, int EnhanceAttribute = 0, int EnhanceAttributePVP = 0, int eqScore = 0)
		{
			builder.StartObject(7);
			EquipEnhanceAttributeTable.AddEqScore(builder, eqScore);
			EquipEnhanceAttributeTable.AddEnhanceAttributePVP(builder, EnhanceAttributePVP);
			EquipEnhanceAttributeTable.AddEnhanceAttribute(builder, EnhanceAttribute);
			EquipEnhanceAttributeTable.AddLevel(builder, Level);
			EquipEnhanceAttributeTable.AddEnhanceLevel(builder, EnhanceLevel);
			EquipEnhanceAttributeTable.AddQuality(builder, Quality);
			EquipEnhanceAttributeTable.AddID(builder, ID);
			return EquipEnhanceAttributeTable.EndEquipEnhanceAttributeTable(builder);
		}

		// Token: 0x06002CFF RID: 11519 RVA: 0x000A58B3 File Offset: 0x000A3CB3
		public static void StartEquipEnhanceAttributeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06002D00 RID: 11520 RVA: 0x000A58BC File Offset: 0x000A3CBC
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002D01 RID: 11521 RVA: 0x000A58C7 File Offset: 0x000A3CC7
		public static void AddQuality(FlatBufferBuilder builder, int Quality)
		{
			builder.AddInt(1, Quality, 0);
		}

		// Token: 0x06002D02 RID: 11522 RVA: 0x000A58D2 File Offset: 0x000A3CD2
		public static void AddEnhanceLevel(FlatBufferBuilder builder, int EnhanceLevel)
		{
			builder.AddInt(2, EnhanceLevel, 0);
		}

		// Token: 0x06002D03 RID: 11523 RVA: 0x000A58DD File Offset: 0x000A3CDD
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(3, Level, 0);
		}

		// Token: 0x06002D04 RID: 11524 RVA: 0x000A58E8 File Offset: 0x000A3CE8
		public static void AddEnhanceAttribute(FlatBufferBuilder builder, int EnhanceAttribute)
		{
			builder.AddInt(4, EnhanceAttribute, 0);
		}

		// Token: 0x06002D05 RID: 11525 RVA: 0x000A58F3 File Offset: 0x000A3CF3
		public static void AddEnhanceAttributePVP(FlatBufferBuilder builder, int EnhanceAttributePVP)
		{
			builder.AddInt(5, EnhanceAttributePVP, 0);
		}

		// Token: 0x06002D06 RID: 11526 RVA: 0x000A58FE File Offset: 0x000A3CFE
		public static void AddEqScore(FlatBufferBuilder builder, int eqScore)
		{
			builder.AddInt(6, eqScore, 0);
		}

		// Token: 0x06002D07 RID: 11527 RVA: 0x000A590C File Offset: 0x000A3D0C
		public static Offset<EquipEnhanceAttributeTable> EndEquipEnhanceAttributeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipEnhanceAttributeTable>(value);
		}

		// Token: 0x06002D08 RID: 11528 RVA: 0x000A5926 File Offset: 0x000A3D26
		public static void FinishEquipEnhanceAttributeTableBuffer(FlatBufferBuilder builder, Offset<EquipEnhanceAttributeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400132F RID: 4911
		private Table __p = new Table();

		// Token: 0x020003DC RID: 988
		public enum eCrypt
		{
			// Token: 0x04001331 RID: 4913
			code = -845456548
		}
	}
}
