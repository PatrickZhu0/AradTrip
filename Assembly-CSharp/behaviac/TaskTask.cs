using System;

namespace behaviac
{
	// Token: 0x020048BA RID: 18618
	internal class TaskTask : Sequence.SequenceTask
	{
		// Token: 0x0601AC4E RID: 109646 RVA: 0x0083C723 File Offset: 0x0083AB23
		public override void copyto(BehaviorTask target)
		{
			base.copyto(target);
		}

		// Token: 0x0601AC4F RID: 109647 RVA: 0x0083C72C File Offset: 0x0083AB2C
		public override void Init(BehaviorNode node)
		{
			Task task = (Task)node;
			if (task.IsHTN)
			{
				this.m_bIgnoreChildren = true;
			}
			base.Init(node);
		}

		// Token: 0x0601AC50 RID: 109648 RVA: 0x0083C759 File Offset: 0x0083AB59
		protected override void addChild(BehaviorTask pBehavior)
		{
			base.addChild(pBehavior);
		}

		// Token: 0x0601AC51 RID: 109649 RVA: 0x0083C762 File Offset: 0x0083AB62
		protected override bool onenter(Agent pAgent)
		{
			this.m_activeChildIndex = -1;
			return base.onenter(pAgent);
		}

		// Token: 0x0601AC52 RID: 109650 RVA: 0x0083C772 File Offset: 0x0083AB72
		protected override void onexit(Agent pAgent, EBTStatus s)
		{
			base.onexit(pAgent, s);
		}

		// Token: 0x0601AC53 RID: 109651 RVA: 0x0083C77C File Offset: 0x0083AB7C
		protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = childStatus;
			if (childStatus == EBTStatus.BT_RUNNING)
			{
				Task task = (Task)base.GetNode();
				if (!task.IsHTN)
				{
					BehaviorTask behaviorTask = this.m_children[0];
					result = behaviorTask.exec(pAgent);
				}
			}
			return result;
		}
	}
}
