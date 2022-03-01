using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004898 RID: 18584
	public class DecoratorFrames : DecoratorNode
	{
		// Token: 0x0601AB87 RID: 109447 RVA: 0x0083AD18 File Offset: 0x00839118
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

		// Token: 0x0601AB88 RID: 109448 RVA: 0x0083ADA3 File Offset: 0x008391A3
		protected virtual int GetFrames(Agent pAgent)
		{
			if (this.m_frames != null)
			{
				return ((CInstanceMember<int>)this.m_frames).GetValue(pAgent);
			}
			return 0;
		}

		// Token: 0x0601AB89 RID: 109449 RVA: 0x0083ADC4 File Offset: 0x008391C4
		protected override BehaviorTask createTask()
		{
			return new DecoratorFrames.DecoratorFramesTask();
		}

		// Token: 0x04012A05 RID: 76293
		protected IInstanceMember m_frames;

		// Token: 0x02004899 RID: 18585
		private class DecoratorFramesTask : DecoratorTask
		{
			// Token: 0x0601AB8B RID: 109451 RVA: 0x0083ADE0 File Offset: 0x008391E0
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				DecoratorFrames.DecoratorFramesTask decoratorFramesTask = (DecoratorFrames.DecoratorFramesTask)target;
				decoratorFramesTask.m_start = this.m_start;
				decoratorFramesTask.m_frames = this.m_frames;
			}

			// Token: 0x0601AB8C RID: 109452 RVA: 0x0083AE14 File Offset: 0x00839214
			public override void save(ISerializableNode node)
			{
				base.save(node);
				CSerializationID attrId = new CSerializationID("start");
				node.setAttr<int>(attrId, this.m_start);
				CSerializationID attrId2 = new CSerializationID("frames");
				node.setAttr<int>(attrId2, this.m_frames);
			}

			// Token: 0x0601AB8D RID: 109453 RVA: 0x0083AE5A File Offset: 0x0083925A
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB8E RID: 109454 RVA: 0x0083AE63 File Offset: 0x00839263
			protected override bool onenter(Agent pAgent)
			{
				base.onenter(pAgent);
				this.m_start = Workspace.Instance.FrameSinceStartup;
				this.m_frames = this.GetFrames(pAgent);
				return this.m_frames >= 0;
			}

			// Token: 0x0601AB8F RID: 109455 RVA: 0x0083AE96 File Offset: 0x00839296
			protected override EBTStatus decorate(EBTStatus status)
			{
				if (Workspace.Instance.FrameSinceStartup - this.m_start + 1 >= this.m_frames)
				{
					return EBTStatus.BT_SUCCESS;
				}
				return EBTStatus.BT_RUNNING;
			}

			// Token: 0x0601AB90 RID: 109456 RVA: 0x0083AEBC File Offset: 0x008392BC
			private int GetFrames(Agent pAgent)
			{
				DecoratorFrames decoratorFrames = (DecoratorFrames)base.GetNode();
				return (decoratorFrames == null) ? 0 : decoratorFrames.GetFrames(pAgent);
			}

			// Token: 0x04012A06 RID: 76294
			private int m_start;

			// Token: 0x04012A07 RID: 76295
			private int m_frames;
		}
	}
}
