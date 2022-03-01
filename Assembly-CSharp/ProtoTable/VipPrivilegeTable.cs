using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000618 RID: 1560
	public class VipPrivilegeTable : IFlatbufferObject
	{
		// Token: 0x170017BF RID: 6079
		// (get) Token: 0x06005481 RID: 21633 RVA: 0x00102F44 File Offset: 0x00101344
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005482 RID: 21634 RVA: 0x00102F51 File Offset: 0x00101351
		public static VipPrivilegeTable GetRootAsVipPrivilegeTable(ByteBuffer _bb)
		{
			return VipPrivilegeTable.GetRootAsVipPrivilegeTable(_bb, new VipPrivilegeTable());
		}

		// Token: 0x06005483 RID: 21635 RVA: 0x00102F5E File Offset: 0x0010135E
		public static VipPrivilegeTable GetRootAsVipPrivilegeTable(ByteBuffer _bb, VipPrivilegeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005484 RID: 21636 RVA: 0x00102F7A File Offset: 0x0010137A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005485 RID: 21637 RVA: 0x00102F94 File Offset: 0x00101394
		public VipPrivilegeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170017C0 RID: 6080
		// (get) Token: 0x06005486 RID: 21638 RVA: 0x00102FA0 File Offset: 0x001013A0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017C1 RID: 6081
		// (get) Token: 0x06005487 RID: 21639 RVA: 0x00102FEC File Offset: 0x001013EC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005488 RID: 21640 RVA: 0x0010302E File Offset: 0x0010142E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170017C2 RID: 6082
		// (get) Token: 0x06005489 RID: 21641 RVA: 0x0010303C File Offset: 0x0010143C
		public VipPrivilegeTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (VipPrivilegeTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017C3 RID: 6083
		// (get) Token: 0x0600548A RID: 21642 RVA: 0x00103080 File Offset: 0x00101480
		public string Description
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600548B RID: 21643 RVA: 0x001030C3 File Offset: 0x001014C3
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170017C4 RID: 6084
		// (get) Token: 0x0600548C RID: 21644 RVA: 0x001030D4 File Offset: 0x001014D4
		public VipPrivilegeTable.eDataType DataType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (VipPrivilegeTable.eDataType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017C5 RID: 6085
		// (get) Token: 0x0600548D RID: 21645 RVA: 0x00103118 File Offset: 0x00101518
		public int VIP0
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017C6 RID: 6086
		// (get) Token: 0x0600548E RID: 21646 RVA: 0x00103164 File Offset: 0x00101564
		public int VIP1
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017C7 RID: 6087
		// (get) Token: 0x0600548F RID: 21647 RVA: 0x001031B0 File Offset: 0x001015B0
		public int VIP2
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017C8 RID: 6088
		// (get) Token: 0x06005490 RID: 21648 RVA: 0x001031FC File Offset: 0x001015FC
		public int VIP3
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017C9 RID: 6089
		// (get) Token: 0x06005491 RID: 21649 RVA: 0x00103248 File Offset: 0x00101648
		public int VIP4
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017CA RID: 6090
		// (get) Token: 0x06005492 RID: 21650 RVA: 0x00103294 File Offset: 0x00101694
		public int VIP5
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017CB RID: 6091
		// (get) Token: 0x06005493 RID: 21651 RVA: 0x001032E0 File Offset: 0x001016E0
		public int VIP6
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017CC RID: 6092
		// (get) Token: 0x06005494 RID: 21652 RVA: 0x0010332C File Offset: 0x0010172C
		public int VIP7
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017CD RID: 6093
		// (get) Token: 0x06005495 RID: 21653 RVA: 0x00103378 File Offset: 0x00101778
		public int VIP8
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017CE RID: 6094
		// (get) Token: 0x06005496 RID: 21654 RVA: 0x001033C4 File Offset: 0x001017C4
		public int VIP9
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017CF RID: 6095
		// (get) Token: 0x06005497 RID: 21655 RVA: 0x00103410 File Offset: 0x00101810
		public int VIP10
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017D0 RID: 6096
		// (get) Token: 0x06005498 RID: 21656 RVA: 0x0010345C File Offset: 0x0010185C
		public int VIP11
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017D1 RID: 6097
		// (get) Token: 0x06005499 RID: 21657 RVA: 0x001034A8 File Offset: 0x001018A8
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600549A RID: 21658 RVA: 0x001034EB File Offset: 0x001018EB
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170017D2 RID: 6098
		// (get) Token: 0x0600549B RID: 21659 RVA: 0x001034FC File Offset: 0x001018FC
		public string VIPDisplay
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600549C RID: 21660 RVA: 0x0010353F File Offset: 0x0010193F
		public ArraySegment<byte>? GetVIPDisplayBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170017D3 RID: 6099
		// (get) Token: 0x0600549D RID: 21661 RVA: 0x00103550 File Offset: 0x00101950
		public int DisplayIndex
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-623361718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600549E RID: 21662 RVA: 0x0010359C File Offset: 0x0010199C
		public static Offset<VipPrivilegeTable> CreateVipPrivilegeTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), VipPrivilegeTable.eType Type = VipPrivilegeTable.eType.None, StringOffset DescriptionOffset = default(StringOffset), VipPrivilegeTable.eDataType DataType = VipPrivilegeTable.eDataType.DataType_None, int VIP0 = 0, int VIP1 = 0, int VIP2 = 0, int VIP3 = 0, int VIP4 = 0, int VIP5 = 0, int VIP6 = 0, int VIP7 = 0, int VIP8 = 0, int VIP9 = 0, int VIP10 = 0, int VIP11 = 0, StringOffset IconPathOffset = default(StringOffset), StringOffset VIPDisplayOffset = default(StringOffset), int DisplayIndex = 0)
		{
			builder.StartObject(20);
			VipPrivilegeTable.AddDisplayIndex(builder, DisplayIndex);
			VipPrivilegeTable.AddVIPDisplay(builder, VIPDisplayOffset);
			VipPrivilegeTable.AddIconPath(builder, IconPathOffset);
			VipPrivilegeTable.AddVIP11(builder, VIP11);
			VipPrivilegeTable.AddVIP10(builder, VIP10);
			VipPrivilegeTable.AddVIP9(builder, VIP9);
			VipPrivilegeTable.AddVIP8(builder, VIP8);
			VipPrivilegeTable.AddVIP7(builder, VIP7);
			VipPrivilegeTable.AddVIP6(builder, VIP6);
			VipPrivilegeTable.AddVIP5(builder, VIP5);
			VipPrivilegeTable.AddVIP4(builder, VIP4);
			VipPrivilegeTable.AddVIP3(builder, VIP3);
			VipPrivilegeTable.AddVIP2(builder, VIP2);
			VipPrivilegeTable.AddVIP1(builder, VIP1);
			VipPrivilegeTable.AddVIP0(builder, VIP0);
			VipPrivilegeTable.AddDataType(builder, DataType);
			VipPrivilegeTable.AddDescription(builder, DescriptionOffset);
			VipPrivilegeTable.AddType(builder, Type);
			VipPrivilegeTable.AddName(builder, NameOffset);
			VipPrivilegeTable.AddID(builder, ID);
			return VipPrivilegeTable.EndVipPrivilegeTable(builder);
		}

		// Token: 0x0600549F RID: 21663 RVA: 0x00103654 File Offset: 0x00101A54
		public static void StartVipPrivilegeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(20);
		}

		// Token: 0x060054A0 RID: 21664 RVA: 0x0010365E File Offset: 0x00101A5E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060054A1 RID: 21665 RVA: 0x00103669 File Offset: 0x00101A69
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060054A2 RID: 21666 RVA: 0x0010367A File Offset: 0x00101A7A
		public static void AddType(FlatBufferBuilder builder, VipPrivilegeTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x060054A3 RID: 21667 RVA: 0x00103685 File Offset: 0x00101A85
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(3, DescriptionOffset.Value, 0);
		}

		// Token: 0x060054A4 RID: 21668 RVA: 0x00103696 File Offset: 0x00101A96
		public static void AddDataType(FlatBufferBuilder builder, VipPrivilegeTable.eDataType DataType)
		{
			builder.AddInt(4, (int)DataType, 0);
		}

		// Token: 0x060054A5 RID: 21669 RVA: 0x001036A1 File Offset: 0x00101AA1
		public static void AddVIP0(FlatBufferBuilder builder, int VIP0)
		{
			builder.AddInt(5, VIP0, 0);
		}

		// Token: 0x060054A6 RID: 21670 RVA: 0x001036AC File Offset: 0x00101AAC
		public static void AddVIP1(FlatBufferBuilder builder, int VIP1)
		{
			builder.AddInt(6, VIP1, 0);
		}

		// Token: 0x060054A7 RID: 21671 RVA: 0x001036B7 File Offset: 0x00101AB7
		public static void AddVIP2(FlatBufferBuilder builder, int VIP2)
		{
			builder.AddInt(7, VIP2, 0);
		}

		// Token: 0x060054A8 RID: 21672 RVA: 0x001036C2 File Offset: 0x00101AC2
		public static void AddVIP3(FlatBufferBuilder builder, int VIP3)
		{
			builder.AddInt(8, VIP3, 0);
		}

		// Token: 0x060054A9 RID: 21673 RVA: 0x001036CD File Offset: 0x00101ACD
		public static void AddVIP4(FlatBufferBuilder builder, int VIP4)
		{
			builder.AddInt(9, VIP4, 0);
		}

		// Token: 0x060054AA RID: 21674 RVA: 0x001036D9 File Offset: 0x00101AD9
		public static void AddVIP5(FlatBufferBuilder builder, int VIP5)
		{
			builder.AddInt(10, VIP5, 0);
		}

		// Token: 0x060054AB RID: 21675 RVA: 0x001036E5 File Offset: 0x00101AE5
		public static void AddVIP6(FlatBufferBuilder builder, int VIP6)
		{
			builder.AddInt(11, VIP6, 0);
		}

		// Token: 0x060054AC RID: 21676 RVA: 0x001036F1 File Offset: 0x00101AF1
		public static void AddVIP7(FlatBufferBuilder builder, int VIP7)
		{
			builder.AddInt(12, VIP7, 0);
		}

		// Token: 0x060054AD RID: 21677 RVA: 0x001036FD File Offset: 0x00101AFD
		public static void AddVIP8(FlatBufferBuilder builder, int VIP8)
		{
			builder.AddInt(13, VIP8, 0);
		}

		// Token: 0x060054AE RID: 21678 RVA: 0x00103709 File Offset: 0x00101B09
		public static void AddVIP9(FlatBufferBuilder builder, int VIP9)
		{
			builder.AddInt(14, VIP9, 0);
		}

		// Token: 0x060054AF RID: 21679 RVA: 0x00103715 File Offset: 0x00101B15
		public static void AddVIP10(FlatBufferBuilder builder, int VIP10)
		{
			builder.AddInt(15, VIP10, 0);
		}

		// Token: 0x060054B0 RID: 21680 RVA: 0x00103721 File Offset: 0x00101B21
		public static void AddVIP11(FlatBufferBuilder builder, int VIP11)
		{
			builder.AddInt(16, VIP11, 0);
		}

		// Token: 0x060054B1 RID: 21681 RVA: 0x0010372D File Offset: 0x00101B2D
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(17, IconPathOffset.Value, 0);
		}

		// Token: 0x060054B2 RID: 21682 RVA: 0x0010373F File Offset: 0x00101B3F
		public static void AddVIPDisplay(FlatBufferBuilder builder, StringOffset VIPDisplayOffset)
		{
			builder.AddOffset(18, VIPDisplayOffset.Value, 0);
		}

		// Token: 0x060054B3 RID: 21683 RVA: 0x00103751 File Offset: 0x00101B51
		public static void AddDisplayIndex(FlatBufferBuilder builder, int DisplayIndex)
		{
			builder.AddInt(19, DisplayIndex, 0);
		}

		// Token: 0x060054B4 RID: 21684 RVA: 0x00103760 File Offset: 0x00101B60
		public static Offset<VipPrivilegeTable> EndVipPrivilegeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<VipPrivilegeTable>(value);
		}

		// Token: 0x060054B5 RID: 21685 RVA: 0x0010377A File Offset: 0x00101B7A
		public static void FinishVipPrivilegeTableBuffer(FlatBufferBuilder builder, Offset<VipPrivilegeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E72 RID: 7794
		private Table __p = new Table();

		// Token: 0x02000619 RID: 1561
		public enum eType
		{
			// Token: 0x04001E74 RID: 7796
			None,
			// Token: 0x04001E75 RID: 7797
			DUNGEON_EXP,
			// Token: 0x04001E76 RID: 7798
			FREE_REVIVE,
			// Token: 0x04001E77 RID: 7799
			DUNGEON_DROP_GOLD,
			// Token: 0x04001E78 RID: 7800
			PK_MONEY_LIMIT,
			// Token: 0x04001E79 RID: 7801
			GOLDBOX_FREEOPEN_NUM,
			// Token: 0x04001E7A RID: 7802
			BLACKMARKET_NOBILITY_GOODS,
			// Token: 0x04001E7B RID: 7803
			WARRIOR_TOWER_REBEGIN_NUM,
			// Token: 0x04001E7C RID: 7804
			MAGIC_VEIN_NUM,
			// Token: 0x04001E7D RID: 7805
			MYSTERIOUS_SHOP_REFRESH_NUM,
			// Token: 0x04001E7E RID: 7806
			GUILD_TICKET_DONATE_DAILY,
			// Token: 0x04001E7F RID: 7807
			OFFLINE_FIND_FATIGUE_LIMIT,
			// Token: 0x04001E80 RID: 7808
			GUILD_LUXURY_WORSHIP,
			// Token: 0x04001E81 RID: 7809
			PERFECT_FIND,
			// Token: 0x04001E82 RID: 7810
			SIGN_IN_DOUBLE,
			// Token: 0x04001E83 RID: 7811
			FATIGUE_DRUG_USE_NUM,
			// Token: 0x04001E84 RID: 7812
			GUILD_PRIVATECOST_REDPACKET,
			// Token: 0x04001E85 RID: 7813
			TEAM_BOSS_NUM,
			// Token: 0x04001E86 RID: 7814
			AUTO_EATING,
			// Token: 0x04001E87 RID: 7815
			WORLD_CHAT_FREE_TIMES,
			// Token: 0x04001E88 RID: 7816
			AUTION_VIP_COMMISSION_PRIVILEGE,
			// Token: 0x04001E89 RID: 7817
			BACKPACK_VIP_TITLE,
			// Token: 0x04001E8A RID: 7818
			BACKPACK_VIP_FASHION,
			// Token: 0x04001E8B RID: 7819
			CREDIT_POINT_MONTH_GET_NUM = 24,
			// Token: 0x04001E8C RID: 7820
			CREDIT_POINT_OWN_NUM,
			// Token: 0x04001E8D RID: 7821
			CREDIT_POINT_MONTH_CONVERSION_NUM
		}

		// Token: 0x0200061A RID: 1562
		public enum eDataType
		{
			// Token: 0x04001E8F RID: 7823
			DataType_None,
			// Token: 0x04001E90 RID: 7824
			INT,
			// Token: 0x04001E91 RID: 7825
			FLOAT
		}

		// Token: 0x0200061B RID: 1563
		public enum eCrypt
		{
			// Token: 0x04001E93 RID: 7827
			code = -623361718
		}
	}
}
