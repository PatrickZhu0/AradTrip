using System;

namespace behaviac
{
	// Token: 0x02004862 RID: 18530
	internal class WaitforSignalTask : SingeChildTask
	{
		// Token: 0x0601AA6D RID: 109165 RVA: 0x00839364 File Offset: 0x00837764
		public WaitforSignalTask()
		{
			this.m_bTriggered = false;
		}

		// Token: 0x0601AA6E RID: 109166 RVA: 0x00839374 File Offset: 0x00837774
		public override void copyto(BehaviorTask target)
		{
			base.copyto(target);
			WaitforSignalTask waitforSignalTask = (WaitforSignalTask)target;
			waitforSignalTask.m_bTriggered = this.m_bTriggered;
		}

		// Token: 0x0601AA6F RID: 109167 RVA: 0x0083939C File Offset: 0x0083779C
		public override void save(ISerializableNode node)
		{
			base.save(node);
			CSerializationID attrId = new CSerializationID("triggered");
			node.setAttr<bool>(attrId, this.m_bTriggered);
		}

		// Token: 0x0601AA70 RID: 109168 RVA: 0x008393C9 File Offset: 0x008377C9
		protected override bool onenter(Agent pAgent)
		{
			this.m_bTriggered = false;
			return true;
		}

		// Token: 0x0601AA71 RID: 109169 RVA: 0x008393D3 File Offset: 0x008377D3
		protected override void onexit(Agent pAgent, EBTStatus s)
		{
			base.onexit(pAgent, s);
		}

		// Token: 0x0601AA72 RID: 109170 RVA: 0x008393E0 File Offset: 0x008377E0
		protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
		{
			if (childStatus != EBTStatus.BT_RUNNING)
			{
				return childStatus;
			}
			if (!this.m_bTriggered)
			{
				WaitforSignal waitforSignal = this.m_node as WaitforSignal;
				this.m_bTriggered = waitforSignal.CheckIfSignaled(pAgent);
			}
			if (!this.m_bTriggered)
			{
				return EBTStatus.BT_RUNNING;
			}
			if (this.m_root == null)
			{
				return EBTStatus.BT_SUCCESS;
			}
			return base.update(pAgent, childStatus);
		}

		// Token: 0x040129DD RID: 76253
		private bool m_bTriggered;
	}
}
