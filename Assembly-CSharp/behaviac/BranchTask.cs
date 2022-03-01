using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004850 RID: 18512
	public abstract class BranchTask : BehaviorTask
	{
		// Token: 0x0601A9EF RID: 109039 RVA: 0x0055035C File Offset: 0x0054E75C
		public override void Clear()
		{
			base.Clear();
			this.m_currentTask = null;
		}

		// Token: 0x0601A9F0 RID: 109040 RVA: 0x0055036B File Offset: 0x0054E76B
		protected override bool onenter(Agent pAgent)
		{
			return true;
		}

		// Token: 0x0601A9F1 RID: 109041 RVA: 0x0055036E File Offset: 0x0054E76E
		protected override void onexit(Agent pAgent, EBTStatus status)
		{
		}

		// Token: 0x0601A9F2 RID: 109042 RVA: 0x00550370 File Offset: 0x0054E770
		public override void onreset(Agent pAgent)
		{
		}

		// Token: 0x0601A9F3 RID: 109043 RVA: 0x00550374 File Offset: 0x0054E774
		private bool oneventCurrentNode(Agent pAgent, string eventName, Dictionary<uint, IInstantiatedVariable> eventParams)
		{
			if (this.m_currentTask != null)
			{
				EBTStatus status = this.m_currentTask.GetStatus();
				bool flag = this.m_currentTask.onevent(pAgent, eventName, eventParams);
				if (flag && this.m_currentTask != null)
				{
					BranchTask parent = this.m_currentTask.GetParent();
					while (parent != null && parent != this)
					{
						flag = parent.onevent(pAgent, eventName, eventParams);
						if (!flag)
						{
							return false;
						}
						parent = parent.GetParent();
					}
				}
				return flag;
			}
			return false;
		}

		// Token: 0x0601A9F4 RID: 109044 RVA: 0x005503F4 File Offset: 0x0054E7F4
		public override bool onevent(Agent pAgent, string eventName, Dictionary<uint, IInstantiatedVariable> eventParams)
		{
			if (this.m_node.HasEvents())
			{
				bool flag = true;
				if (this.m_currentTask != null)
				{
					flag = this.oneventCurrentNode(pAgent, eventName, eventParams);
				}
				if (flag)
				{
					flag = base.onevent(pAgent, eventName, eventParams);
				}
				return flag;
			}
			return true;
		}

		// Token: 0x0601A9F5 RID: 109045 RVA: 0x0055043C File Offset: 0x0054E83C
		private EBTStatus execCurrentTask(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus ebtstatus = this.m_currentTask.exec(pAgent, childStatus);
			if (ebtstatus != EBTStatus.BT_RUNNING)
			{
				BranchTask parent = this.m_currentTask.GetParent();
				this.m_currentTask = null;
				while (parent != null)
				{
					if (parent == this)
					{
						ebtstatus = parent.update(pAgent, ebtstatus);
					}
					else
					{
						ebtstatus = parent.exec(pAgent, ebtstatus);
					}
					if (ebtstatus == EBTStatus.BT_RUNNING)
					{
						return EBTStatus.BT_RUNNING;
					}
					if (parent == this)
					{
						break;
					}
					parent = parent.GetParent();
				}
			}
			return ebtstatus;
		}

		// Token: 0x0601A9F6 RID: 109046 RVA: 0x005504B8 File Offset: 0x0054E8B8
		protected override EBTStatus update_current(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result;
			if (this.m_currentTask != null)
			{
				result = this.execCurrentTask(pAgent, childStatus);
			}
			else
			{
				result = this.update(pAgent, childStatus);
			}
			return result;
		}

		// Token: 0x0601A9F7 RID: 109047 RVA: 0x005504EC File Offset: 0x0054E8EC
		protected EBTStatus resume_branch(Agent pAgent, EBTStatus status)
		{
			BranchTask branchTask;
			if (this.m_currentTask.GetNode().IsManagingChildrenAsSubTrees())
			{
				branchTask = (BranchTask)this.m_currentTask;
			}
			else
			{
				branchTask = this.m_currentTask.GetParent();
			}
			this.m_currentTask = null;
			if (branchTask != null)
			{
				return branchTask.exec(pAgent, status);
			}
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0601A9F8 RID: 109048
		protected abstract void addChild(BehaviorTask pBehavior);

		// Token: 0x0601A9F9 RID: 109049 RVA: 0x00550546 File Offset: 0x0054E946
		public override BehaviorTask GetCurrentTask()
		{
			return this.m_currentTask;
		}

		// Token: 0x0601A9FA RID: 109050 RVA: 0x0055054E File Offset: 0x0054E94E
		public override void SetCurrentTask(BehaviorTask task)
		{
			if (task != null)
			{
				if (this.m_currentTask == null)
				{
					this.m_currentTask = task;
					task.SetHasManagingParent(true);
				}
			}
			else if (this.m_status != EBTStatus.BT_RUNNING)
			{
				this.m_currentTask = task;
			}
		}

		// Token: 0x040129C2 RID: 76226
		private BehaviorTask m_currentTask;
	}
}
