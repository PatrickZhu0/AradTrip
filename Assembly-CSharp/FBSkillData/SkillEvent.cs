using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B28 RID: 19240
	public sealed class SkillEvent : Table
	{
		// Token: 0x0601C1EE RID: 115182 RVA: 0x00892DEE File Offset: 0x008911EE
		public static SkillEvent GetRootAsSkillEvent(ByteBuffer _bb)
		{
			return SkillEvent.GetRootAsSkillEvent(_bb, new SkillEvent());
		}

		// Token: 0x0601C1EF RID: 115183 RVA: 0x00892DFB File Offset: 0x008911FB
		public static SkillEvent GetRootAsSkillEvent(ByteBuffer _bb, SkillEvent obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C1F0 RID: 115184 RVA: 0x00892E17 File Offset: 0x00891217
		public SkillEvent __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026EC RID: 9964
		// (get) Token: 0x0601C1F1 RID: 115185 RVA: 0x00892E28 File Offset: 0x00891228
		public int EventType
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026ED RID: 9965
		// (get) Token: 0x0601C1F2 RID: 115186 RVA: 0x00892E5C File Offset: 0x0089125C
		public int EventAction
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026EE RID: 9966
		// (get) Token: 0x0601C1F3 RID: 115187 RVA: 0x00892E90 File Offset: 0x00891290
		public string Paramter
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026EF RID: 9967
		// (get) Token: 0x0601C1F4 RID: 115188 RVA: 0x00892EC0 File Offset: 0x008912C0
		public int WorkPhase
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C1F5 RID: 115189 RVA: 0x00892EF5 File Offset: 0x008912F5
		public static Offset<SkillEvent> CreateSkillEvent(FlatBufferBuilder builder, int eventType = 0, int eventAction = 0, StringOffset paramter = default(StringOffset), int workPhase = 0)
		{
			builder.StartObject(4);
			SkillEvent.AddWorkPhase(builder, workPhase);
			SkillEvent.AddParamter(builder, paramter);
			SkillEvent.AddEventAction(builder, eventAction);
			SkillEvent.AddEventType(builder, eventType);
			return SkillEvent.EndSkillEvent(builder);
		}

		// Token: 0x0601C1F6 RID: 115190 RVA: 0x00892F21 File Offset: 0x00891321
		public static void StartSkillEvent(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0601C1F7 RID: 115191 RVA: 0x00892F2A File Offset: 0x0089132A
		public static void AddEventType(FlatBufferBuilder builder, int eventType)
		{
			builder.AddInt(0, eventType, 0);
		}

		// Token: 0x0601C1F8 RID: 115192 RVA: 0x00892F35 File Offset: 0x00891335
		public static void AddEventAction(FlatBufferBuilder builder, int eventAction)
		{
			builder.AddInt(1, eventAction, 0);
		}

		// Token: 0x0601C1F9 RID: 115193 RVA: 0x00892F40 File Offset: 0x00891340
		public static void AddParamter(FlatBufferBuilder builder, StringOffset paramterOffset)
		{
			builder.AddOffset(2, paramterOffset.Value, 0);
		}

		// Token: 0x0601C1FA RID: 115194 RVA: 0x00892F51 File Offset: 0x00891351
		public static void AddWorkPhase(FlatBufferBuilder builder, int workPhase)
		{
			builder.AddInt(3, workPhase, 0);
		}

		// Token: 0x0601C1FB RID: 115195 RVA: 0x00892F5C File Offset: 0x0089135C
		public static Offset<SkillEvent> EndSkillEvent(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SkillEvent>(value);
		}
	}
}
