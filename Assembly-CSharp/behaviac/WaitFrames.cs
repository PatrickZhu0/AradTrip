using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004863 RID: 18531
	public class WaitFrames : BehaviorNode
	{
		// Token: 0x0601AA74 RID: 109172 RVA: 0x00839448 File Offset: 0x00837848
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

		// Token: 0x0601AA75 RID: 109173 RVA: 0x008394D3 File Offset: 0x008378D3
		protected virtual int GetFrames(Agent pAgent)
		{
			if (this.m_frames != null)
			{
				return ((CInstanceMember<int>)this.m_frames).GetValue(pAgent);
			}
			return 0;
		}

		// Token: 0x0601AA76 RID: 109174 RVA: 0x008394F4 File Offset: 0x008378F4
		protected override BehaviorTask createTask()
		{
			return new WaitFrames.WaitFramesTask();
		}

		// Token: 0x040129DE RID: 76254
		private IInstanceMember m_frames;

		// Token: 0x02004864 RID: 18532
		private class WaitFramesTask : LeafTask
		{
			// Token: 0x0601AA78 RID: 109176 RVA: 0x00839510 File Offset: 0x00837910
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				WaitFrames.WaitFramesTask waitFramesTask = (WaitFrames.WaitFramesTask)target;
				waitFramesTask.m_start = this.m_start;
				waitFramesTask.m_frames = this.m_frames;
			}

			// Token: 0x0601AA79 RID: 109177 RVA: 0x00839544 File Offset: 0x00837944
			public override void save(ISerializableNode node)
			{
				base.save(node);
				CSerializationID attrId = new CSerializationID("start");
				node.setAttr<int>(attrId, this.m_start);
				CSerializationID attrId2 = new CSerializationID("frames");
				node.setAttr<int>(attrId2, this.m_frames);
			}

			// Token: 0x0601AA7A RID: 109178 RVA: 0x0083958A File Offset: 0x0083798A
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AA7B RID: 109179 RVA: 0x00839593 File Offset: 0x00837993
			protected override bool onenter(Agent pAgent)
			{
				this.m_start = Workspace.Instance.FrameSinceStartup;
				this.m_frames = this.GetFrames(pAgent);
				return this.m_frames >= 0;
			}

			// Token: 0x0601AA7C RID: 109180 RVA: 0x008395BE File Offset: 0x008379BE
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AA7D RID: 109181 RVA: 0x008395C0 File Offset: 0x008379C0
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				if (Workspace.Instance.FrameSinceStartup - this.m_start + 1 >= this.m_frames)
				{
					return EBTStatus.BT_SUCCESS;
				}
				return EBTStatus.BT_RUNNING;
			}

			// Token: 0x0601AA7E RID: 109182 RVA: 0x008395E4 File Offset: 0x008379E4
			private int GetFrames(Agent pAgent)
			{
				WaitFrames waitFrames = (WaitFrames)base.GetNode();
				return (waitFrames == null) ? 0 : waitFrames.GetFrames(pAgent);
			}

			// Token: 0x040129DF RID: 76255
			private int m_start;

			// Token: 0x040129E0 RID: 76256
			private int m_frames;
		}
	}
}
