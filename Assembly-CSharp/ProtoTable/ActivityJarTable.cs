using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200027E RID: 638
	public class ActivityJarTable : IFlatbufferObject
	{
		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x0600162B RID: 5675 RVA: 0x0006EC64 File Offset: 0x0006D064
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600162C RID: 5676 RVA: 0x0006EC71 File Offset: 0x0006D071
		public static ActivityJarTable GetRootAsActivityJarTable(ByteBuffer _bb)
		{
			return ActivityJarTable.GetRootAsActivityJarTable(_bb, new ActivityJarTable());
		}

		// Token: 0x0600162D RID: 5677 RVA: 0x0006EC7E File Offset: 0x0006D07E
		public static ActivityJarTable GetRootAsActivityJarTable(ByteBuffer _bb, ActivityJarTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600162E RID: 5678 RVA: 0x0006EC9A File Offset: 0x0006D09A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600162F RID: 5679 RVA: 0x0006ECB4 File Offset: 0x0006D0B4
		public ActivityJarTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06001630 RID: 5680 RVA: 0x0006ECC0 File Offset: 0x0006D0C0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (79917002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06001631 RID: 5681 RVA: 0x0006ED0C File Offset: 0x0006D10C
		public int JarID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (79917002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06001632 RID: 5682 RVA: 0x0006ED58 File Offset: 0x0006D158
		public string ActivityBG
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x0006ED9A File Offset: 0x0006D19A
		public ArraySegment<byte>? GetActivityBGBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06001634 RID: 5684 RVA: 0x0006EDA8 File Offset: 0x0006D1A8
		public string ActivityRule
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x0006EDEB File Offset: 0x0006D1EB
		public ArraySegment<byte>? GetActivityRuleBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x0006EDFA File Offset: 0x0006D1FA
		public static Offset<ActivityJarTable> CreateActivityJarTable(FlatBufferBuilder builder, int ID = 0, int JarID = 0, StringOffset ActivityBGOffset = default(StringOffset), StringOffset ActivityRuleOffset = default(StringOffset))
		{
			builder.StartObject(4);
			ActivityJarTable.AddActivityRule(builder, ActivityRuleOffset);
			ActivityJarTable.AddActivityBG(builder, ActivityBGOffset);
			ActivityJarTable.AddJarID(builder, JarID);
			ActivityJarTable.AddID(builder, ID);
			return ActivityJarTable.EndActivityJarTable(builder);
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x0006EE26 File Offset: 0x0006D226
		public static void StartActivityJarTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x0006EE2F File Offset: 0x0006D22F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x0006EE3A File Offset: 0x0006D23A
		public static void AddJarID(FlatBufferBuilder builder, int JarID)
		{
			builder.AddInt(1, JarID, 0);
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x0006EE45 File Offset: 0x0006D245
		public static void AddActivityBG(FlatBufferBuilder builder, StringOffset ActivityBGOffset)
		{
			builder.AddOffset(2, ActivityBGOffset.Value, 0);
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x0006EE56 File Offset: 0x0006D256
		public static void AddActivityRule(FlatBufferBuilder builder, StringOffset ActivityRuleOffset)
		{
			builder.AddOffset(3, ActivityRuleOffset.Value, 0);
		}

		// Token: 0x0600163C RID: 5692 RVA: 0x0006EE68 File Offset: 0x0006D268
		public static Offset<ActivityJarTable> EndActivityJarTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ActivityJarTable>(value);
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x0006EE82 File Offset: 0x0006D282
		public static void FinishActivityJarTableBuffer(FlatBufferBuilder builder, Offset<ActivityJarTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DA2 RID: 3490
		private Table __p = new Table();

		// Token: 0x0200027F RID: 639
		public enum eCrypt
		{
			// Token: 0x04000DA4 RID: 3492
			code = 79917002
		}
	}
}
