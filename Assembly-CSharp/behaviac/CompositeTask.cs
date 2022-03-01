using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004851 RID: 18513
	public class CompositeTask : BranchTask
	{
		// Token: 0x0601A9FB RID: 109051 RVA: 0x005FBE6B File Offset: 0x005FA26B
		protected CompositeTask()
		{
			this.m_activeChildIndex = -1;
		}

		// Token: 0x0601A9FC RID: 109052 RVA: 0x005FBE8C File Offset: 0x005FA28C
		public override void traverse(bool childFirst, NodeHandler_t handler, Agent pAgent, object user_data)
		{
			if (childFirst)
			{
				for (int i = 0; i < this.m_children.Count; i++)
				{
					BehaviorTask behaviorTask = this.m_children[i];
					behaviorTask.traverse(childFirst, handler, pAgent, user_data);
				}
				handler(this, pAgent, user_data);
			}
			else if (handler(this, pAgent, user_data))
			{
				for (int j = 0; j < this.m_children.Count; j++)
				{
					BehaviorTask behaviorTask2 = this.m_children[j];
					behaviorTask2.traverse(childFirst, handler, pAgent, user_data);
				}
			}
		}

		// Token: 0x0601A9FD RID: 109053 RVA: 0x005FBF28 File Offset: 0x005FA328
		public override void Init(BehaviorNode node)
		{
			base.Init(node);
			if (!this.m_bIgnoreChildren)
			{
				int childrenCount = node.GetChildrenCount();
				for (int i = 0; i < childrenCount; i++)
				{
					BehaviorNode child = node.GetChild(i);
					BehaviorTask pBehavior = child.CreateAndInitTask();
					this.addChild(pBehavior);
				}
			}
		}

		// Token: 0x0601A9FE RID: 109054 RVA: 0x005FBF78 File Offset: 0x005FA378
		public override void copyto(BehaviorTask target)
		{
			base.copyto(target);
			CompositeTask compositeTask = target as CompositeTask;
			compositeTask.m_activeChildIndex = this.m_activeChildIndex;
			int count = this.m_children.Count;
			for (int i = 0; i < count; i++)
			{
				BehaviorTask behaviorTask = this.m_children[i];
				BehaviorTask target2 = compositeTask.m_children[i];
				behaviorTask.copyto(target2);
			}
		}

		// Token: 0x0601A9FF RID: 109055 RVA: 0x005FBFE0 File Offset: 0x005FA3E0
		public override void save(ISerializableNode node)
		{
			base.save(node);
		}

		// Token: 0x0601AA00 RID: 109056 RVA: 0x005FBFE9 File Offset: 0x005FA3E9
		public override void load(ISerializableNode node)
		{
			base.load(node);
		}

		// Token: 0x0601AA01 RID: 109057 RVA: 0x005FBFF2 File Offset: 0x005FA3F2
		protected override void addChild(BehaviorTask pBehavior)
		{
			pBehavior.SetParent(this);
			this.m_children.Add(pBehavior);
		}

		// Token: 0x0601AA02 RID: 109058 RVA: 0x005FC008 File Offset: 0x005FA408
		protected BehaviorTask GetChildById(int nodeId)
		{
			if (this.m_children != null && this.m_children.Count > 0)
			{
				for (int i = 0; i < this.m_children.Count; i++)
				{
					BehaviorTask behaviorTask = this.m_children[i];
					if (behaviorTask.GetId() == nodeId)
					{
						return behaviorTask;
					}
				}
			}
			return null;
		}

		// Token: 0x040129C3 RID: 76227
		protected bool m_bIgnoreChildren;

		// Token: 0x040129C4 RID: 76228
		protected List<BehaviorTask> m_children = new List<BehaviorTask>();

		// Token: 0x040129C5 RID: 76229
		protected int m_activeChildIndex = -1;

		// Token: 0x040129C6 RID: 76230
		protected const int InvalidChildIndex = -1;
	}
}
