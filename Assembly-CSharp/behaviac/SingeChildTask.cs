using System;

namespace behaviac
{
	// Token: 0x02004852 RID: 18514
	public class SingeChildTask : BranchTask
	{
		// Token: 0x0601AA03 RID: 109059 RVA: 0x00550587 File Offset: 0x0054E987
		protected SingeChildTask()
		{
			this.m_root = null;
		}

		// Token: 0x0601AA04 RID: 109060 RVA: 0x00550598 File Offset: 0x0054E998
		public override void traverse(bool childFirst, NodeHandler_t handler, Agent pAgent, object user_data)
		{
			if (childFirst)
			{
				if (this.m_root != null)
				{
					this.m_root.traverse(childFirst, handler, pAgent, user_data);
				}
				handler(this, pAgent, user_data);
			}
			else if (handler(this, pAgent, user_data) && this.m_root != null)
			{
				this.m_root.traverse(childFirst, handler, pAgent, user_data);
			}
		}

		// Token: 0x0601AA05 RID: 109061 RVA: 0x00550600 File Offset: 0x0054EA00
		public override void Init(BehaviorNode node)
		{
			base.Init(node);
			if (node.GetChildrenCount() == 1)
			{
				BehaviorNode child = node.GetChild(0);
				if (child != null)
				{
					BehaviorTask pBehavior = child.CreateAndInitTask();
					this.addChild(pBehavior);
				}
			}
		}

		// Token: 0x0601AA06 RID: 109062 RVA: 0x00550644 File Offset: 0x0054EA44
		public override void copyto(BehaviorTask target)
		{
			base.copyto(target);
			SingeChildTask singeChildTask = target as SingeChildTask;
			if (this.m_root != null && singeChildTask != null)
			{
				if (singeChildTask.m_root == null)
				{
					BehaviorNode node = this.m_root.GetNode();
					if (node != null)
					{
						singeChildTask.m_root = node.CreateAndInitTask();
					}
				}
				if (singeChildTask.m_root != null)
				{
					this.m_root.copyto(singeChildTask.m_root);
				}
			}
		}

		// Token: 0x0601AA07 RID: 109063 RVA: 0x005506B5 File Offset: 0x0054EAB5
		public override void save(ISerializableNode node)
		{
			base.save(node);
			if (this.m_root != null)
			{
			}
		}

		// Token: 0x0601AA08 RID: 109064 RVA: 0x005506C9 File Offset: 0x0054EAC9
		public override void load(ISerializableNode node)
		{
			base.load(node);
		}

		// Token: 0x0601AA09 RID: 109065 RVA: 0x005506D4 File Offset: 0x0054EAD4
		protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
		{
			if (this.m_root != null)
			{
				return this.m_root.exec(pAgent, childStatus);
			}
			return EBTStatus.BT_FAILURE;
		}

		// Token: 0x0601AA0A RID: 109066 RVA: 0x005506FD File Offset: 0x0054EAFD
		protected override void addChild(BehaviorTask pBehavior)
		{
			pBehavior.SetParent(this);
			this.m_root = pBehavior;
		}

		// Token: 0x040129C7 RID: 76231
		protected BehaviorTask m_root;
	}
}
