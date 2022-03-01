using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005E5 RID: 1509
	public class TalkTable : IFlatbufferObject
	{
		// Token: 0x17001603 RID: 5635
		// (get) Token: 0x06004FE4 RID: 20452 RVA: 0x000F77BC File Offset: 0x000F5BBC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004FE5 RID: 20453 RVA: 0x000F77C9 File Offset: 0x000F5BC9
		public static TalkTable GetRootAsTalkTable(ByteBuffer _bb)
		{
			return TalkTable.GetRootAsTalkTable(_bb, new TalkTable());
		}

		// Token: 0x06004FE6 RID: 20454 RVA: 0x000F77D6 File Offset: 0x000F5BD6
		public static TalkTable GetRootAsTalkTable(ByteBuffer _bb, TalkTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004FE7 RID: 20455 RVA: 0x000F77F2 File Offset: 0x000F5BF2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004FE8 RID: 20456 RVA: 0x000F780C File Offset: 0x000F5C0C
		public TalkTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001604 RID: 5636
		// (get) Token: 0x06004FE9 RID: 20457 RVA: 0x000F7818 File Offset: 0x000F5C18
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (182457828 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001605 RID: 5637
		// (get) Token: 0x06004FEA RID: 20458 RVA: 0x000F7864 File Offset: 0x000F5C64
		public string ObjectName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004FEB RID: 20459 RVA: 0x000F78A6 File Offset: 0x000F5CA6
		public ArraySegment<byte>? GetObjectNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001606 RID: 5638
		// (get) Token: 0x06004FEC RID: 20460 RVA: 0x000F78B4 File Offset: 0x000F5CB4
		public int NpcID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (182457828 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001607 RID: 5639
		// (get) Token: 0x06004FED RID: 20461 RVA: 0x000F7900 File Offset: 0x000F5D00
		public string TalkText
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004FEE RID: 20462 RVA: 0x000F7943 File Offset: 0x000F5D43
		public ArraySegment<byte>? GetTalkTextBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001608 RID: 5640
		// (get) Token: 0x06004FEF RID: 20463 RVA: 0x000F7954 File Offset: 0x000F5D54
		public int NextID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (182457828 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001609 RID: 5641
		// (get) Token: 0x06004FF0 RID: 20464 RVA: 0x000F79A0 File Offset: 0x000F5DA0
		public int MissionID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (182457828 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700160A RID: 5642
		// (get) Token: 0x06004FF1 RID: 20465 RVA: 0x000F79EC File Offset: 0x000F5DEC
		public int TakeFinish
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (182457828 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700160B RID: 5643
		// (get) Token: 0x06004FF2 RID: 20466 RVA: 0x000F7A38 File Offset: 0x000F5E38
		public string FrameClassName
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004FF3 RID: 20467 RVA: 0x000F7A7B File Offset: 0x000F5E7B
		public ArraySegment<byte>? GetFrameClassNameBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x1700160C RID: 5644
		// (get) Token: 0x06004FF4 RID: 20468 RVA: 0x000F7A8C File Offset: 0x000F5E8C
		public string AttachClassName
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004FF5 RID: 20469 RVA: 0x000F7ACF File Offset: 0x000F5ECF
		public ArraySegment<byte>? GetAttachClassNameBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x06004FF6 RID: 20470 RVA: 0x000F7AE0 File Offset: 0x000F5EE0
		public static Offset<TalkTable> CreateTalkTable(FlatBufferBuilder builder, int ID = 0, StringOffset ObjectNameOffset = default(StringOffset), int NpcID = 0, StringOffset TalkTextOffset = default(StringOffset), int NextID = 0, int MissionID = 0, int TakeFinish = 0, StringOffset FrameClassNameOffset = default(StringOffset), StringOffset AttachClassNameOffset = default(StringOffset))
		{
			builder.StartObject(9);
			TalkTable.AddAttachClassName(builder, AttachClassNameOffset);
			TalkTable.AddFrameClassName(builder, FrameClassNameOffset);
			TalkTable.AddTakeFinish(builder, TakeFinish);
			TalkTable.AddMissionID(builder, MissionID);
			TalkTable.AddNextID(builder, NextID);
			TalkTable.AddTalkText(builder, TalkTextOffset);
			TalkTable.AddNpcID(builder, NpcID);
			TalkTable.AddObjectName(builder, ObjectNameOffset);
			TalkTable.AddID(builder, ID);
			return TalkTable.EndTalkTable(builder);
		}

		// Token: 0x06004FF7 RID: 20471 RVA: 0x000F7B40 File Offset: 0x000F5F40
		public static void StartTalkTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06004FF8 RID: 20472 RVA: 0x000F7B4A File Offset: 0x000F5F4A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004FF9 RID: 20473 RVA: 0x000F7B55 File Offset: 0x000F5F55
		public static void AddObjectName(FlatBufferBuilder builder, StringOffset ObjectNameOffset)
		{
			builder.AddOffset(1, ObjectNameOffset.Value, 0);
		}

		// Token: 0x06004FFA RID: 20474 RVA: 0x000F7B66 File Offset: 0x000F5F66
		public static void AddNpcID(FlatBufferBuilder builder, int NpcID)
		{
			builder.AddInt(2, NpcID, 0);
		}

		// Token: 0x06004FFB RID: 20475 RVA: 0x000F7B71 File Offset: 0x000F5F71
		public static void AddTalkText(FlatBufferBuilder builder, StringOffset TalkTextOffset)
		{
			builder.AddOffset(3, TalkTextOffset.Value, 0);
		}

		// Token: 0x06004FFC RID: 20476 RVA: 0x000F7B82 File Offset: 0x000F5F82
		public static void AddNextID(FlatBufferBuilder builder, int NextID)
		{
			builder.AddInt(4, NextID, 0);
		}

		// Token: 0x06004FFD RID: 20477 RVA: 0x000F7B8D File Offset: 0x000F5F8D
		public static void AddMissionID(FlatBufferBuilder builder, int MissionID)
		{
			builder.AddInt(5, MissionID, 0);
		}

		// Token: 0x06004FFE RID: 20478 RVA: 0x000F7B98 File Offset: 0x000F5F98
		public static void AddTakeFinish(FlatBufferBuilder builder, int TakeFinish)
		{
			builder.AddInt(6, TakeFinish, 0);
		}

		// Token: 0x06004FFF RID: 20479 RVA: 0x000F7BA3 File Offset: 0x000F5FA3
		public static void AddFrameClassName(FlatBufferBuilder builder, StringOffset FrameClassNameOffset)
		{
			builder.AddOffset(7, FrameClassNameOffset.Value, 0);
		}

		// Token: 0x06005000 RID: 20480 RVA: 0x000F7BB4 File Offset: 0x000F5FB4
		public static void AddAttachClassName(FlatBufferBuilder builder, StringOffset AttachClassNameOffset)
		{
			builder.AddOffset(8, AttachClassNameOffset.Value, 0);
		}

		// Token: 0x06005001 RID: 20481 RVA: 0x000F7BC8 File Offset: 0x000F5FC8
		public static Offset<TalkTable> EndTalkTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TalkTable>(value);
		}

		// Token: 0x06005002 RID: 20482 RVA: 0x000F7BE2 File Offset: 0x000F5FE2
		public static void FinishTalkTableBuffer(FlatBufferBuilder builder, Offset<TalkTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DD5 RID: 7637
		private Table __p = new Table();

		// Token: 0x020005E6 RID: 1510
		public enum eCrypt
		{
			// Token: 0x04001DD7 RID: 7639
			code = 182457828
		}
	}
}
