using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003CB RID: 971
	public class EqualPvPEuqipTable : IFlatbufferObject
	{
		// Token: 0x17000A29 RID: 2601
		// (get) Token: 0x06002BA0 RID: 11168 RVA: 0x000A2094 File Offset: 0x000A0494
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002BA1 RID: 11169 RVA: 0x000A20A1 File Offset: 0x000A04A1
		public static EqualPvPEuqipTable GetRootAsEqualPvPEuqipTable(ByteBuffer _bb)
		{
			return EqualPvPEuqipTable.GetRootAsEqualPvPEuqipTable(_bb, new EqualPvPEuqipTable());
		}

		// Token: 0x06002BA2 RID: 11170 RVA: 0x000A20AE File Offset: 0x000A04AE
		public static EqualPvPEuqipTable GetRootAsEqualPvPEuqipTable(ByteBuffer _bb, EqualPvPEuqipTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002BA3 RID: 11171 RVA: 0x000A20CA File Offset: 0x000A04CA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002BA4 RID: 11172 RVA: 0x000A20E4 File Offset: 0x000A04E4
		public EqualPvPEuqipTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A2A RID: 2602
		// (get) Token: 0x06002BA5 RID: 11173 RVA: 0x000A20F0 File Offset: 0x000A04F0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (615822232 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A2B RID: 2603
		// (get) Token: 0x06002BA6 RID: 11174 RVA: 0x000A213C File Offset: 0x000A053C
		public int Occu
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (615822232 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A2C RID: 2604
		// (get) Token: 0x06002BA7 RID: 11175 RVA: 0x000A2188 File Offset: 0x000A0588
		public EqualPvPEuqipTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (EqualPvPEuqipTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A2D RID: 2605
		// (get) Token: 0x06002BA8 RID: 11176 RVA: 0x000A21CC File Offset: 0x000A05CC
		public string EquipName
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002BA9 RID: 11177 RVA: 0x000A220F File Offset: 0x000A060F
		public ArraySegment<byte>? GetEquipNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000A2E RID: 2606
		// (get) Token: 0x06002BAA RID: 11178 RVA: 0x000A2220 File Offset: 0x000A0620
		public int EquipID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (615822232 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A2F RID: 2607
		// (get) Token: 0x06002BAB RID: 11179 RVA: 0x000A226C File Offset: 0x000A066C
		public int StrengthenLv
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (615822232 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A30 RID: 2608
		// (get) Token: 0x06002BAC RID: 11180 RVA: 0x000A22B8 File Offset: 0x000A06B8
		public EqualPvPEuqipTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(16);
				return (EqualPvPEuqipTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002BAD RID: 11181 RVA: 0x000A22FC File Offset: 0x000A06FC
		public static Offset<EqualPvPEuqipTable> CreateEqualPvPEuqipTable(FlatBufferBuilder builder, int ID = 0, int Occu = 0, EqualPvPEuqipTable.eSubType SubType = EqualPvPEuqipTable.eSubType.ST_NONE, StringOffset EquipNameOffset = default(StringOffset), int EquipID = 0, int StrengthenLv = 0, EqualPvPEuqipTable.eType Type = EqualPvPEuqipTable.eType.Type_None)
		{
			builder.StartObject(7);
			EqualPvPEuqipTable.AddType(builder, Type);
			EqualPvPEuqipTable.AddStrengthenLv(builder, StrengthenLv);
			EqualPvPEuqipTable.AddEquipID(builder, EquipID);
			EqualPvPEuqipTable.AddEquipName(builder, EquipNameOffset);
			EqualPvPEuqipTable.AddSubType(builder, SubType);
			EqualPvPEuqipTable.AddOccu(builder, Occu);
			EqualPvPEuqipTable.AddID(builder, ID);
			return EqualPvPEuqipTable.EndEqualPvPEuqipTable(builder);
		}

		// Token: 0x06002BAE RID: 11182 RVA: 0x000A234B File Offset: 0x000A074B
		public static void StartEqualPvPEuqipTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06002BAF RID: 11183 RVA: 0x000A2354 File Offset: 0x000A0754
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002BB0 RID: 11184 RVA: 0x000A235F File Offset: 0x000A075F
		public static void AddOccu(FlatBufferBuilder builder, int Occu)
		{
			builder.AddInt(1, Occu, 0);
		}

		// Token: 0x06002BB1 RID: 11185 RVA: 0x000A236A File Offset: 0x000A076A
		public static void AddSubType(FlatBufferBuilder builder, EqualPvPEuqipTable.eSubType SubType)
		{
			builder.AddInt(2, (int)SubType, 0);
		}

		// Token: 0x06002BB2 RID: 11186 RVA: 0x000A2375 File Offset: 0x000A0775
		public static void AddEquipName(FlatBufferBuilder builder, StringOffset EquipNameOffset)
		{
			builder.AddOffset(3, EquipNameOffset.Value, 0);
		}

		// Token: 0x06002BB3 RID: 11187 RVA: 0x000A2386 File Offset: 0x000A0786
		public static void AddEquipID(FlatBufferBuilder builder, int EquipID)
		{
			builder.AddInt(4, EquipID, 0);
		}

		// Token: 0x06002BB4 RID: 11188 RVA: 0x000A2391 File Offset: 0x000A0791
		public static void AddStrengthenLv(FlatBufferBuilder builder, int StrengthenLv)
		{
			builder.AddInt(5, StrengthenLv, 0);
		}

		// Token: 0x06002BB5 RID: 11189 RVA: 0x000A239C File Offset: 0x000A079C
		public static void AddType(FlatBufferBuilder builder, EqualPvPEuqipTable.eType Type)
		{
			builder.AddInt(6, (int)Type, 0);
		}

		// Token: 0x06002BB6 RID: 11190 RVA: 0x000A23A8 File Offset: 0x000A07A8
		public static Offset<EqualPvPEuqipTable> EndEqualPvPEuqipTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EqualPvPEuqipTable>(value);
		}

		// Token: 0x06002BB7 RID: 11191 RVA: 0x000A23C2 File Offset: 0x000A07C2
		public static void FinishEqualPvPEuqipTableBuffer(FlatBufferBuilder builder, Offset<EqualPvPEuqipTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040012A6 RID: 4774
		private Table __p = new Table();

		// Token: 0x020003CC RID: 972
		public enum eSubType
		{
			// Token: 0x040012A8 RID: 4776
			ST_NONE,
			// Token: 0x040012A9 RID: 4777
			WEAPON,
			// Token: 0x040012AA RID: 4778
			HEAD,
			// Token: 0x040012AB RID: 4779
			CHEST,
			// Token: 0x040012AC RID: 4780
			BELT,
			// Token: 0x040012AD RID: 4781
			LEG,
			// Token: 0x040012AE RID: 4782
			BOOT,
			// Token: 0x040012AF RID: 4783
			RING,
			// Token: 0x040012B0 RID: 4784
			NECKLASE,
			// Token: 0x040012B1 RID: 4785
			BRACELET,
			// Token: 0x040012B2 RID: 4786
			TITLE,
			// Token: 0x040012B3 RID: 4787
			FASHION_HAIR,
			// Token: 0x040012B4 RID: 4788
			FASHION_HEAD,
			// Token: 0x040012B5 RID: 4789
			FASHION_SASH,
			// Token: 0x040012B6 RID: 4790
			FASHION_CHEST,
			// Token: 0x040012B7 RID: 4791
			FASHION_LEG,
			// Token: 0x040012B8 RID: 4792
			FASHION_EPAULET,
			// Token: 0x040012B9 RID: 4793
			GOLD,
			// Token: 0x040012BA RID: 4794
			POINT,
			// Token: 0x040012BB RID: 4795
			EXP,
			// Token: 0x040012BC RID: 4796
			DRUG,
			// Token: 0x040012BD RID: 4797
			WARRIOR_SOUL = 22,
			// Token: 0x040012BE RID: 4798
			DUEL_COIN,
			// Token: 0x040012BF RID: 4799
			MATERIAL_JINGPO,
			// Token: 0x040012C0 RID: 4800
			EnchantmentsCard,
			// Token: 0x040012C1 RID: 4801
			ResurrectionCcurrency,
			// Token: 0x040012C2 RID: 4802
			BindGOLD,
			// Token: 0x040012C3 RID: 4803
			BindPOINT,
			// Token: 0x040012C4 RID: 4804
			GiftPackage,
			// Token: 0x040012C5 RID: 4805
			GuildContri,
			// Token: 0x040012C6 RID: 4806
			SP,
			// Token: 0x040012C7 RID: 4807
			EnergyStone,
			// Token: 0x040012C8 RID: 4808
			Coupon,
			// Token: 0x040012C9 RID: 4809
			MonthCard,
			// Token: 0x040012CA RID: 4810
			Jar,
			// Token: 0x040012CB RID: 4811
			GiftBox,
			// Token: 0x040012CC RID: 4812
			FatigueDrug,
			// Token: 0x040012CD RID: 4813
			Drawing,
			// Token: 0x040012CE RID: 4814
			Fragment,
			// Token: 0x040012CF RID: 4815
			VipExp,
			// Token: 0x040012D0 RID: 4816
			ExperiencePill,
			// Token: 0x040012D1 RID: 4817
			GoldJarPoint,
			// Token: 0x040012D2 RID: 4818
			MagicJarPoint,
			// Token: 0x040012D3 RID: 4819
			PetEgg,
			// Token: 0x040012D4 RID: 4820
			ST_FASHION_COMPOSER,
			// Token: 0x040012D5 RID: 4821
			MoneyManageCard,
			// Token: 0x040012D6 RID: 4822
			Hp = 50,
			// Token: 0x040012D7 RID: 4823
			Mp,
			// Token: 0x040012D8 RID: 4824
			HpMp,
			// Token: 0x040012D9 RID: 4825
			ChangeName,
			// Token: 0x040012DA RID: 4826
			Bead,
			// Token: 0x040012DB RID: 4827
			MagicBox,
			// Token: 0x040012DC RID: 4828
			MagicHammer,
			// Token: 0x040012DD RID: 4829
			Param,
			// Token: 0x040012DE RID: 4830
			ST_JAR_GIFT,
			// Token: 0x040012DF RID: 4831
			ChargeActivityScore = 60,
			// Token: 0x040012E0 RID: 4832
			ST_ADD_VIP_POINT,
			// Token: 0x040012E1 RID: 4833
			AttributeDrug,
			// Token: 0x040012E2 RID: 4834
			ST_APPOINTMENT_COIN = 70,
			// Token: 0x040012E3 RID: 4835
			LOTTERY_COIN,
			// Token: 0x040012E4 RID: 4836
			Perfect_washing,
			// Token: 0x040012E5 RID: 4837
			ST_CONSUME_JAR_GIFT,
			// Token: 0x040012E6 RID: 4838
			ST_MASTER_ACADEMIC_VALUE = 78,
			// Token: 0x040012E7 RID: 4839
			ST_MASTER_GOODTEACH_VALUE,
			// Token: 0x040012E8 RID: 4840
			ST_RETURN_TOKEN,
			// Token: 0x040012E9 RID: 4841
			FASHION_WEAPON,
			// Token: 0x040012EA RID: 4842
			ST_CHANGE_FASHION_ACTIVE_TICKET,
			// Token: 0x040012EB RID: 4843
			ST_DRESS_INTEGRAL_VALUE,
			// Token: 0x040012EC RID: 4844
			ST_WEAPON_LEASE_TICKET,
			// Token: 0x040012ED RID: 4845
			ST_PEARL_HAMMER = 89,
			// Token: 0x040012EE RID: 4846
			ST_DIAMOND_HAMMER
		}

		// Token: 0x020003CD RID: 973
		public enum eType
		{
			// Token: 0x040012F0 RID: 4848
			Type_None,
			// Token: 0x040012F1 RID: 4849
			EQUIP,
			// Token: 0x040012F2 RID: 4850
			EXPENDABLE,
			// Token: 0x040012F3 RID: 4851
			MATERIAL,
			// Token: 0x040012F4 RID: 4852
			TASK,
			// Token: 0x040012F5 RID: 4853
			FASHION,
			// Token: 0x040012F6 RID: 4854
			INCOME,
			// Token: 0x040012F7 RID: 4855
			ENERGY,
			// Token: 0x040012F8 RID: 4856
			FUCKTITTLE,
			// Token: 0x040012F9 RID: 4857
			VirtualPack,
			// Token: 0x040012FA RID: 4858
			PET,
			// Token: 0x040012FB RID: 4859
			HEAD_FRAME = 12
		}

		// Token: 0x020003CE RID: 974
		public enum eCrypt
		{
			// Token: 0x040012FD RID: 4861
			code = 615822232
		}
	}
}
