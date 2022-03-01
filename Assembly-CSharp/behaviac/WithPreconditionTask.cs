using System;

namespace behaviac
{
	// Token: 0x0200487E RID: 18558
	internal class WithPreconditionTask : Sequence.SequenceTask
	{
		// Token: 0x0601AB04 RID: 109316 RVA: 0x0083A550 File Offset: 0x00838950
		protected override void addChild(BehaviorTask pBehavior)
		{
			base.addChild(pBehavior);
		}

		// Token: 0x0601AB05 RID: 109317 RVA: 0x0083A559 File Offset: 0x00838959
		public override void copyto(BehaviorTask target)
		{
			base.copyto(target);
		}

		// Token: 0x0601AB06 RID: 109318 RVA: 0x0083A562 File Offset: 0x00838962
		public override void save(ISerializableNode node)
		{
			base.save(node);
		}

		// Token: 0x0601AB07 RID: 109319 RVA: 0x0083A56B File Offset: 0x0083896B
		public override void load(ISerializableNode node)
		{
			base.load(node);
		}

		// Token: 0x0601AB08 RID: 109320 RVA: 0x0083A574 File Offset: 0x00838974
		protected override bool onenter(Agent pAgent)
		{
			BehaviorTask parent = base.GetParent();
			return true;
		}

		// Token: 0x0601AB09 RID: 109321 RVA: 0x0083A58C File Offset: 0x0083898C
		protected override void onexit(Agent pAgent, EBTStatus s)
		{
			BehaviorTask parent = base.GetParent();
		}

		// Token: 0x17002298 RID: 8856
		// (get) Token: 0x0601AB0A RID: 109322 RVA: 0x0083A5A0 File Offset: 0x008389A0
		public BehaviorTask PreconditionNode
		{
			get
			{
				return this.m_children[0];
			}
		}

		// Token: 0x17002299 RID: 8857
		// (get) Token: 0x0601AB0B RID: 109323 RVA: 0x0083A5AE File Offset: 0x008389AE
		public BehaviorTask ActionNode
		{
			get
			{
				return this.m_children[1];
			}
		}

		// Token: 0x0601AB0C RID: 109324 RVA: 0x0083A5BC File Offset: 0x008389BC
		protected override EBTStatus update_current(Agent pAgent, EBTStatus childStatus)
		{
			return this.update(pAgent, childStatus);
		}

		// Token: 0x0601AB0D RID: 109325 RVA: 0x0083A5C8 File Offset: 0x008389C8
		protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
		{
			BehaviorTask parent = base.GetParent();
			return EBTStatus.BT_RUNNING;
		}
	}
}
