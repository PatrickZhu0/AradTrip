using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000286 RID: 646
	public class ActivitySystemConfig : IFlatbufferObject
	{
		// Token: 0x17000327 RID: 807
		// (get) Token: 0x060016CF RID: 5839 RVA: 0x000703E0 File Offset: 0x0006E7E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060016D0 RID: 5840 RVA: 0x000703ED File Offset: 0x0006E7ED
		public static ActivitySystemConfig GetRootAsActivitySystemConfig(ByteBuffer _bb)
		{
			return ActivitySystemConfig.GetRootAsActivitySystemConfig(_bb, new ActivitySystemConfig());
		}

		// Token: 0x060016D1 RID: 5841 RVA: 0x000703FA File Offset: 0x0006E7FA
		public static ActivitySystemConfig GetRootAsActivitySystemConfig(ByteBuffer _bb, ActivitySystemConfig obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060016D2 RID: 5842 RVA: 0x00070416 File Offset: 0x0006E816
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060016D3 RID: 5843 RVA: 0x00070430 File Offset: 0x0006E830
		public ActivitySystemConfig __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x060016D4 RID: 5844 RVA: 0x0007043C File Offset: 0x0006E83C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (379250962 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x060016D5 RID: 5845 RVA: 0x00070488 File Offset: 0x0006E888
		public ActivitySystemConfig.eActivitySystem ActivitySystem
		{
			get
			{
				int num = this.__p.__offset(6);
				return (ActivitySystemConfig.eActivitySystem)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x060016D6 RID: 5846 RVA: 0x000704CC File Offset: 0x0006E8CC
		public string OpActivities
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060016D7 RID: 5847 RVA: 0x0007050E File Offset: 0x0006E90E
		public ArraySegment<byte>? GetOpActivitiesBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x060016D8 RID: 5848 RVA: 0x0007051C File Offset: 0x0006E91C
		public string MallItems
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060016D9 RID: 5849 RVA: 0x0007055F File Offset: 0x0006E95F
		public ArraySegment<byte>? GetMallItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x060016DA RID: 5850 RVA: 0x00070570 File Offset: 0x0006E970
		public string Activities
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060016DB RID: 5851 RVA: 0x000705B3 File Offset: 0x0006E9B3
		public ArraySegment<byte>? GetActivitiesBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x060016DC RID: 5852 RVA: 0x000705C4 File Offset: 0x0006E9C4
		public string PushInfos
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060016DD RID: 5853 RVA: 0x00070607 File Offset: 0x0006EA07
		public ArraySegment<byte>? GetPushInfosBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x060016DE RID: 5854 RVA: 0x00070618 File Offset: 0x0006EA18
		public int IsClose
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (379250962 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x060016DF RID: 5855 RVA: 0x00070664 File Offset: 0x0006EA64
		public int ReturnActId
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (379250962 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060016E0 RID: 5856 RVA: 0x000706B0 File Offset: 0x0006EAB0
		public static Offset<ActivitySystemConfig> CreateActivitySystemConfig(FlatBufferBuilder builder, int ID = 0, ActivitySystemConfig.eActivitySystem ActivitySystem = ActivitySystemConfig.eActivitySystem.ACTEM_NONE, StringOffset OpActivitiesOffset = default(StringOffset), StringOffset MallItemsOffset = default(StringOffset), StringOffset ActivitiesOffset = default(StringOffset), StringOffset PushInfosOffset = default(StringOffset), int IsClose = 0, int ReturnActId = 0)
		{
			builder.StartObject(8);
			ActivitySystemConfig.AddReturnActId(builder, ReturnActId);
			ActivitySystemConfig.AddIsClose(builder, IsClose);
			ActivitySystemConfig.AddPushInfos(builder, PushInfosOffset);
			ActivitySystemConfig.AddActivities(builder, ActivitiesOffset);
			ActivitySystemConfig.AddMallItems(builder, MallItemsOffset);
			ActivitySystemConfig.AddOpActivities(builder, OpActivitiesOffset);
			ActivitySystemConfig.AddActivitySystem(builder, ActivitySystem);
			ActivitySystemConfig.AddID(builder, ID);
			return ActivitySystemConfig.EndActivitySystemConfig(builder);
		}

		// Token: 0x060016E1 RID: 5857 RVA: 0x00070707 File Offset: 0x0006EB07
		public static void StartActivitySystemConfig(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x060016E2 RID: 5858 RVA: 0x00070710 File Offset: 0x0006EB10
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060016E3 RID: 5859 RVA: 0x0007071B File Offset: 0x0006EB1B
		public static void AddActivitySystem(FlatBufferBuilder builder, ActivitySystemConfig.eActivitySystem ActivitySystem)
		{
			builder.AddInt(1, (int)ActivitySystem, 0);
		}

		// Token: 0x060016E4 RID: 5860 RVA: 0x00070726 File Offset: 0x0006EB26
		public static void AddOpActivities(FlatBufferBuilder builder, StringOffset OpActivitiesOffset)
		{
			builder.AddOffset(2, OpActivitiesOffset.Value, 0);
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x00070737 File Offset: 0x0006EB37
		public static void AddMallItems(FlatBufferBuilder builder, StringOffset MallItemsOffset)
		{
			builder.AddOffset(3, MallItemsOffset.Value, 0);
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x00070748 File Offset: 0x0006EB48
		public static void AddActivities(FlatBufferBuilder builder, StringOffset ActivitiesOffset)
		{
			builder.AddOffset(4, ActivitiesOffset.Value, 0);
		}

		// Token: 0x060016E7 RID: 5863 RVA: 0x00070759 File Offset: 0x0006EB59
		public static void AddPushInfos(FlatBufferBuilder builder, StringOffset PushInfosOffset)
		{
			builder.AddOffset(5, PushInfosOffset.Value, 0);
		}

		// Token: 0x060016E8 RID: 5864 RVA: 0x0007076A File Offset: 0x0006EB6A
		public static void AddIsClose(FlatBufferBuilder builder, int IsClose)
		{
			builder.AddInt(6, IsClose, 0);
		}

		// Token: 0x060016E9 RID: 5865 RVA: 0x00070775 File Offset: 0x0006EB75
		public static void AddReturnActId(FlatBufferBuilder builder, int ReturnActId)
		{
			builder.AddInt(7, ReturnActId, 0);
		}

		// Token: 0x060016EA RID: 5866 RVA: 0x00070780 File Offset: 0x0006EB80
		public static Offset<ActivitySystemConfig> EndActivitySystemConfig(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ActivitySystemConfig>(value);
		}

		// Token: 0x060016EB RID: 5867 RVA: 0x0007079A File Offset: 0x0006EB9A
		public static void FinishActivitySystemConfigBuffer(FlatBufferBuilder builder, Offset<ActivitySystemConfig> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DB8 RID: 3512
		private Table __p = new Table();

		// Token: 0x02000287 RID: 647
		public enum eActivitySystem
		{
			// Token: 0x04000DBA RID: 3514
			ACTEM_NONE,
			// Token: 0x04000DBB RID: 3515
			ACTEM_VETERAN_RETURN
		}

		// Token: 0x02000288 RID: 648
		public enum eCrypt
		{
			// Token: 0x04000DBD RID: 3517
			code = 379250962
		}
	}
}
