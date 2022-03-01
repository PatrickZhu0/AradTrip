using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000546 RID: 1350
	public class PersonalTailorTriggerTable : IFlatbufferObject
	{
		// Token: 0x170012B7 RID: 4791
		// (get) Token: 0x060045B8 RID: 17848 RVA: 0x000DFE50 File Offset: 0x000DE250
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060045B9 RID: 17849 RVA: 0x000DFE5D File Offset: 0x000DE25D
		public static PersonalTailorTriggerTable GetRootAsPersonalTailorTriggerTable(ByteBuffer _bb)
		{
			return PersonalTailorTriggerTable.GetRootAsPersonalTailorTriggerTable(_bb, new PersonalTailorTriggerTable());
		}

		// Token: 0x060045BA RID: 17850 RVA: 0x000DFE6A File Offset: 0x000DE26A
		public static PersonalTailorTriggerTable GetRootAsPersonalTailorTriggerTable(ByteBuffer _bb, PersonalTailorTriggerTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060045BB RID: 17851 RVA: 0x000DFE86 File Offset: 0x000DE286
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060045BC RID: 17852 RVA: 0x000DFEA0 File Offset: 0x000DE2A0
		public PersonalTailorTriggerTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170012B8 RID: 4792
		// (get) Token: 0x060045BD RID: 17853 RVA: 0x000DFEAC File Offset: 0x000DE2AC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2059962389 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012B9 RID: 4793
		// (get) Token: 0x060045BE RID: 17854 RVA: 0x000DFEF8 File Offset: 0x000DE2F8
		public int SubCond
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-2059962389 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012BA RID: 4794
		// (get) Token: 0x060045BF RID: 17855 RVA: 0x000DFF44 File Offset: 0x000DE344
		public int ActivateGoodsId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2059962389 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012BB RID: 4795
		// (get) Token: 0x060045C0 RID: 17856 RVA: 0x000DFF90 File Offset: 0x000DE390
		public int ActivateSubType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2059962389 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012BC RID: 4796
		// (get) Token: 0x060045C1 RID: 17857 RVA: 0x000DFFDC File Offset: 0x000DE3DC
		public int PlayerLevelLimit
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-2059962389 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012BD RID: 4797
		// (get) Token: 0x060045C2 RID: 17858 RVA: 0x000E0028 File Offset: 0x000DE428
		public int LimitInterval
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-2059962389 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012BE RID: 4798
		// (get) Token: 0x060045C3 RID: 17859 RVA: 0x000E0074 File Offset: 0x000DE474
		public int RoleActivateTimesLimit
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-2059962389 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012BF RID: 4799
		// (get) Token: 0x060045C4 RID: 17860 RVA: 0x000E00C0 File Offset: 0x000DE4C0
		public string Describing
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060045C5 RID: 17861 RVA: 0x000E0103 File Offset: 0x000DE503
		public ArraySegment<byte>? GetDescribingBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170012C0 RID: 4800
		// (get) Token: 0x060045C6 RID: 17862 RVA: 0x000E0114 File Offset: 0x000DE514
		public string BgPath
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060045C7 RID: 17863 RVA: 0x000E0157 File Offset: 0x000DE557
		public ArraySegment<byte>? GetBgPathBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x170012C1 RID: 4801
		// (get) Token: 0x060045C8 RID: 17864 RVA: 0x000E0168 File Offset: 0x000DE568
		public int TypeID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-2059962389 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060045C9 RID: 17865 RVA: 0x000E01B4 File Offset: 0x000DE5B4
		public static Offset<PersonalTailorTriggerTable> CreatePersonalTailorTriggerTable(FlatBufferBuilder builder, int ID = 0, int SubCond = 0, int ActivateGoodsId = 0, int ActivateSubType = 0, int PlayerLevelLimit = 0, int LimitInterval = 0, int RoleActivateTimesLimit = 0, StringOffset DescribingOffset = default(StringOffset), StringOffset BgPathOffset = default(StringOffset), int TypeID = 0)
		{
			builder.StartObject(10);
			PersonalTailorTriggerTable.AddTypeID(builder, TypeID);
			PersonalTailorTriggerTable.AddBgPath(builder, BgPathOffset);
			PersonalTailorTriggerTable.AddDescribing(builder, DescribingOffset);
			PersonalTailorTriggerTable.AddRoleActivateTimesLimit(builder, RoleActivateTimesLimit);
			PersonalTailorTriggerTable.AddLimitInterval(builder, LimitInterval);
			PersonalTailorTriggerTable.AddPlayerLevelLimit(builder, PlayerLevelLimit);
			PersonalTailorTriggerTable.AddActivateSubType(builder, ActivateSubType);
			PersonalTailorTriggerTable.AddActivateGoodsId(builder, ActivateGoodsId);
			PersonalTailorTriggerTable.AddSubCond(builder, SubCond);
			PersonalTailorTriggerTable.AddID(builder, ID);
			return PersonalTailorTriggerTable.EndPersonalTailorTriggerTable(builder);
		}

		// Token: 0x060045CA RID: 17866 RVA: 0x000E021C File Offset: 0x000DE61C
		public static void StartPersonalTailorTriggerTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x060045CB RID: 17867 RVA: 0x000E0226 File Offset: 0x000DE626
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060045CC RID: 17868 RVA: 0x000E0231 File Offset: 0x000DE631
		public static void AddSubCond(FlatBufferBuilder builder, int SubCond)
		{
			builder.AddInt(1, SubCond, 0);
		}

		// Token: 0x060045CD RID: 17869 RVA: 0x000E023C File Offset: 0x000DE63C
		public static void AddActivateGoodsId(FlatBufferBuilder builder, int ActivateGoodsId)
		{
			builder.AddInt(2, ActivateGoodsId, 0);
		}

		// Token: 0x060045CE RID: 17870 RVA: 0x000E0247 File Offset: 0x000DE647
		public static void AddActivateSubType(FlatBufferBuilder builder, int ActivateSubType)
		{
			builder.AddInt(3, ActivateSubType, 0);
		}

		// Token: 0x060045CF RID: 17871 RVA: 0x000E0252 File Offset: 0x000DE652
		public static void AddPlayerLevelLimit(FlatBufferBuilder builder, int PlayerLevelLimit)
		{
			builder.AddInt(4, PlayerLevelLimit, 0);
		}

		// Token: 0x060045D0 RID: 17872 RVA: 0x000E025D File Offset: 0x000DE65D
		public static void AddLimitInterval(FlatBufferBuilder builder, int LimitInterval)
		{
			builder.AddInt(5, LimitInterval, 0);
		}

		// Token: 0x060045D1 RID: 17873 RVA: 0x000E0268 File Offset: 0x000DE668
		public static void AddRoleActivateTimesLimit(FlatBufferBuilder builder, int RoleActivateTimesLimit)
		{
			builder.AddInt(6, RoleActivateTimesLimit, 0);
		}

		// Token: 0x060045D2 RID: 17874 RVA: 0x000E0273 File Offset: 0x000DE673
		public static void AddDescribing(FlatBufferBuilder builder, StringOffset DescribingOffset)
		{
			builder.AddOffset(7, DescribingOffset.Value, 0);
		}

		// Token: 0x060045D3 RID: 17875 RVA: 0x000E0284 File Offset: 0x000DE684
		public static void AddBgPath(FlatBufferBuilder builder, StringOffset BgPathOffset)
		{
			builder.AddOffset(8, BgPathOffset.Value, 0);
		}

		// Token: 0x060045D4 RID: 17876 RVA: 0x000E0295 File Offset: 0x000DE695
		public static void AddTypeID(FlatBufferBuilder builder, int TypeID)
		{
			builder.AddInt(9, TypeID, 0);
		}

		// Token: 0x060045D5 RID: 17877 RVA: 0x000E02A4 File Offset: 0x000DE6A4
		public static Offset<PersonalTailorTriggerTable> EndPersonalTailorTriggerTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PersonalTailorTriggerTable>(value);
		}

		// Token: 0x060045D6 RID: 17878 RVA: 0x000E02BE File Offset: 0x000DE6BE
		public static void FinishPersonalTailorTriggerTableBuffer(FlatBufferBuilder builder, Offset<PersonalTailorTriggerTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040019F0 RID: 6640
		private Table __p = new Table();

		// Token: 0x02000547 RID: 1351
		public enum eCrypt
		{
			// Token: 0x040019F2 RID: 6642
			code = -2059962389
		}
	}
}
