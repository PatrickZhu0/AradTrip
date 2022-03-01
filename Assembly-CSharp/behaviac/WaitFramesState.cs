using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048B5 RID: 18613
	public class WaitFramesState : State
	{
		// Token: 0x0601AC2D RID: 109613 RVA: 0x0083C228 File Offset: 0x0083A628
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Frames")
				{
					int num = property_t.value.IndexOf('(');
					if (num == -1)
					{
						this.m_frames = AgentMeta.ParseProperty(property_t.value, null);
					}
					else
					{
						this.m_frames = AgentMeta.ParseMethod(property_t.value);
					}
				}
			}
		}

		// Token: 0x0601AC2E RID: 109614 RVA: 0x0083C2B3 File Offset: 0x0083A6B3
		protected virtual int GetFrames(Agent pAgent)
		{
			if (this.m_frames != null)
			{
				return ((CInstanceMember<int>)this.m_frames).GetValue(pAgent);
			}
			return 0;
		}

		// Token: 0x0601AC2F RID: 109615 RVA: 0x0083C2D4 File Offset: 0x0083A6D4
		protected override BehaviorTask createTask()
		{
			return new WaitFramesState.WaitFramesStateTask();
		}

		// Token: 0x04012A24 RID: 76324
		protected IInstanceMember m_frames;

		// Token: 0x020048B6 RID: 18614
		private class WaitFramesStateTask : State.StateTask
		{
			// Token: 0x0601AC31 RID: 109617 RVA: 0x0083C2F0 File Offset: 0x0083A6F0
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				WaitFramesState.WaitFramesStateTask waitFramesStateTask = (WaitFramesState.WaitFramesStateTask)target;
				waitFramesStateTask.m_start = this.m_start;
				waitFramesStateTask.m_frames = this.m_frames;
			}

			// Token: 0x0601AC32 RID: 109618 RVA: 0x0083C324 File Offset: 0x0083A724
			public override void save(ISerializableNode node)
			{
				base.save(node);
				CSerializationID attrId = new CSerializationID("start");
				node.setAttr<int>(attrId, this.m_start);
				CSerializationID attrId2 = new CSerializationID("frames");
				node.setAttr<int>(attrId2, this.m_frames);
			}

			// Token: 0x0601AC33 RID: 109619 RVA: 0x0083C36A File Offset: 0x0083A76A
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AC34 RID: 109620 RVA: 0x0083C373 File Offset: 0x0083A773
			protected override bool onenter(Agent pAgent)
			{
				this.m_nextStateId = -1;
				this.m_start = Workspace.Instance.FrameSinceStartup;
				this.m_frames = this.GetFrames(pAgent);
				return this.m_frames >= 0;
			}

			// Token: 0x0601AC35 RID: 109621 RVA: 0x0083C3A5 File Offset: 0x0083A7A5
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AC36 RID: 109622 RVA: 0x0083C3A8 File Offset: 0x0083A7A8
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				WaitFramesState waitFramesState = (WaitFramesState)this.m_node;
				if (Workspace.Instance.FrameSinceStartup - this.m_start + 1 >= this.m_frames)
				{
					waitFramesState.Update(pAgent, out this.m_nextStateId);
					return EBTStatus.BT_SUCCESS;
				}
				return EBTStatus.BT_RUNNING;
			}

			// Token: 0x0601AC37 RID: 109623 RVA: 0x0083C3F0 File Offset: 0x0083A7F0
			private int GetFrames(Agent pAgent)
			{
				WaitFramesState waitFramesState = (WaitFramesState)base.GetNode();
				return (waitFramesState == null) ? 0 : waitFramesState.GetFrames(pAgent);
			}

			// Token: 0x04012A25 RID: 76325
			private int m_start;

			// Token: 0x04012A26 RID: 76326
			private int m_frames;
		}
	}
}
