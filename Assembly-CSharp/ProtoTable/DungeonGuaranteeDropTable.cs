using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200039D RID: 925
	public class DungeonGuaranteeDropTable : IFlatbufferObject
	{
		// Token: 0x17000904 RID: 2308
		// (get) Token: 0x06002840 RID: 10304 RVA: 0x000999C4 File Offset: 0x00097DC4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002841 RID: 10305 RVA: 0x000999D1 File Offset: 0x00097DD1
		public static DungeonGuaranteeDropTable GetRootAsDungeonGuaranteeDropTable(ByteBuffer _bb)
		{
			return DungeonGuaranteeDropTable.GetRootAsDungeonGuaranteeDropTable(_bb, new DungeonGuaranteeDropTable());
		}

		// Token: 0x06002842 RID: 10306 RVA: 0x000999DE File Offset: 0x00097DDE
		public static DungeonGuaranteeDropTable GetRootAsDungeonGuaranteeDropTable(ByteBuffer _bb, DungeonGuaranteeDropTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002843 RID: 10307 RVA: 0x000999FA File Offset: 0x00097DFA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002844 RID: 10308 RVA: 0x00099A14 File Offset: 0x00097E14
		public DungeonGuaranteeDropTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000905 RID: 2309
		// (get) Token: 0x06002845 RID: 10309 RVA: 0x00099A20 File Offset: 0x00097E20
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-677951575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000906 RID: 2310
		// (get) Token: 0x06002846 RID: 10310 RVA: 0x00099A6C File Offset: 0x00097E6C
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-677951575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000907 RID: 2311
		// (get) Token: 0x06002847 RID: 10311 RVA: 0x00099AB8 File Offset: 0x00097EB8
		public int MinTimes
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-677951575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000908 RID: 2312
		// (get) Token: 0x06002848 RID: 10312 RVA: 0x00099B04 File Offset: 0x00097F04
		public int MaxTimes
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-677951575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x06002849 RID: 10313 RVA: 0x00099B50 File Offset: 0x00097F50
		public int DropSet
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-677951575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700090A RID: 2314
		// (get) Token: 0x0600284A RID: 10314 RVA: 0x00099B9C File Offset: 0x00097F9C
		public int ResetType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-677951575 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x0600284B RID: 10315 RVA: 0x00099BE8 File Offset: 0x00097FE8
		public string VipLevelLimit
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600284C RID: 10316 RVA: 0x00099C2B File Offset: 0x0009802B
		public ArraySegment<byte>? GetVipLevelLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x0600284D RID: 10317 RVA: 0x00099C3C File Offset: 0x0009803C
		public static Offset<DungeonGuaranteeDropTable> CreateDungeonGuaranteeDropTable(FlatBufferBuilder builder, int ID = 0, int DungeonID = 0, int MinTimes = 0, int MaxTimes = 0, int DropSet = 0, int ResetType = 0, StringOffset VipLevelLimitOffset = default(StringOffset))
		{
			builder.StartObject(7);
			DungeonGuaranteeDropTable.AddVipLevelLimit(builder, VipLevelLimitOffset);
			DungeonGuaranteeDropTable.AddResetType(builder, ResetType);
			DungeonGuaranteeDropTable.AddDropSet(builder, DropSet);
			DungeonGuaranteeDropTable.AddMaxTimes(builder, MaxTimes);
			DungeonGuaranteeDropTable.AddMinTimes(builder, MinTimes);
			DungeonGuaranteeDropTable.AddDungeonID(builder, DungeonID);
			DungeonGuaranteeDropTable.AddID(builder, ID);
			return DungeonGuaranteeDropTable.EndDungeonGuaranteeDropTable(builder);
		}

		// Token: 0x0600284E RID: 10318 RVA: 0x00099C8B File Offset: 0x0009808B
		public static void StartDungeonGuaranteeDropTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0600284F RID: 10319 RVA: 0x00099C94 File Offset: 0x00098094
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002850 RID: 10320 RVA: 0x00099C9F File Offset: 0x0009809F
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(1, DungeonID, 0);
		}

		// Token: 0x06002851 RID: 10321 RVA: 0x00099CAA File Offset: 0x000980AA
		public static void AddMinTimes(FlatBufferBuilder builder, int MinTimes)
		{
			builder.AddInt(2, MinTimes, 0);
		}

		// Token: 0x06002852 RID: 10322 RVA: 0x00099CB5 File Offset: 0x000980B5
		public static void AddMaxTimes(FlatBufferBuilder builder, int MaxTimes)
		{
			builder.AddInt(3, MaxTimes, 0);
		}

		// Token: 0x06002853 RID: 10323 RVA: 0x00099CC0 File Offset: 0x000980C0
		public static void AddDropSet(FlatBufferBuilder builder, int DropSet)
		{
			builder.AddInt(4, DropSet, 0);
		}

		// Token: 0x06002854 RID: 10324 RVA: 0x00099CCB File Offset: 0x000980CB
		public static void AddResetType(FlatBufferBuilder builder, int ResetType)
		{
			builder.AddInt(5, ResetType, 0);
		}

		// Token: 0x06002855 RID: 10325 RVA: 0x00099CD6 File Offset: 0x000980D6
		public static void AddVipLevelLimit(FlatBufferBuilder builder, StringOffset VipLevelLimitOffset)
		{
			builder.AddOffset(6, VipLevelLimitOffset.Value, 0);
		}

		// Token: 0x06002856 RID: 10326 RVA: 0x00099CE8 File Offset: 0x000980E8
		public static Offset<DungeonGuaranteeDropTable> EndDungeonGuaranteeDropTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonGuaranteeDropTable>(value);
		}

		// Token: 0x06002857 RID: 10327 RVA: 0x00099D02 File Offset: 0x00098102
		public static void FinishDungeonGuaranteeDropTableBuffer(FlatBufferBuilder builder, Offset<DungeonGuaranteeDropTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011DD RID: 4573
		private Table __p = new Table();

		// Token: 0x0200039E RID: 926
		public enum eCrypt
		{
			// Token: 0x040011DF RID: 4575
			code = -677951575
		}
	}
}
