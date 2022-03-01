using System;

namespace behaviac
{
	// Token: 0x02004880 RID: 18560
	internal class AndTask : Sequence.SequenceTask
	{
		// Token: 0x0601AB14 RID: 109332 RVA: 0x0083A674 File Offset: 0x00838A74
		public override void copyto(BehaviorTask target)
		{
			base.copyto(target);
		}

		// Token: 0x0601AB15 RID: 109333 RVA: 0x0083A67D File Offset: 0x00838A7D
		public override void save(ISerializableNode node)
		{
			base.save(node);
		}

		// Token: 0x0601AB16 RID: 109334 RVA: 0x0083A686 File Offset: 0x00838A86
		public override void load(ISerializableNode node)
		{
			base.load(node);
		}

		// Token: 0x0601AB17 RID: 109335 RVA: 0x0083A690 File Offset: 0x00838A90
		protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
		{
			for (int i = 0; i < this.m_children.Count; i++)
			{
				BehaviorTask behaviorTask = this.m_children[i];
				EBTStatus ebtstatus = behaviorTask.exec(pAgent);
				if (ebtstatus == EBTStatus.BT_FAILURE)
				{
					return ebtstatus;
				}
			}
			return EBTStatus.BT_SUCCESS;
		}
	}
}
