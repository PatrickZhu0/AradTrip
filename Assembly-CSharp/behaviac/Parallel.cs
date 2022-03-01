using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200486D RID: 18541
	public class Parallel : BehaviorNode
	{
		// Token: 0x0601AA96 RID: 109206 RVA: 0x005FBACD File Offset: 0x005F9ECD
		public Parallel()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_NONE;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}

		// Token: 0x0601AA97 RID: 109207 RVA: 0x005FBAF4 File Offset: 0x005F9EF4
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "FailurePolicy")
				{
					if (property_t.value == "FAIL_ON_ONE")
					{
						this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
					}
					else if (property_t.value == "FAIL_ON_ALL")
					{
						this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
					}
				}
				else if (property_t.name == "SuccessPolicy")
				{
					if (property_t.value == "SUCCEED_ON_ONE")
					{
						this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ONE;
					}
					else if (property_t.value == "SUCCEED_ON_ALL")
					{
						this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
					}
				}
				else if (property_t.name == "ExitPolicy")
				{
					if (property_t.value == "EXIT_NONE")
					{
						this.m_exitPolicy = EXIT_POLICY.EXIT_NONE;
					}
					else if (property_t.value == "EXIT_ABORT_RUNNINGSIBLINGS")
					{
						this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
					}
				}
				else if (property_t.name == "ChildFinishPolicy")
				{
					if (property_t.value == "CHILDFINISH_ONCE")
					{
						this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_ONCE;
					}
					else if (property_t.value == "CHILDFINISH_LOOP")
					{
						this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
					}
				}
			}
		}

		// Token: 0x0601AA98 RID: 109208 RVA: 0x005FBCA5 File Offset: 0x005FA0A5
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Parallel && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AA99 RID: 109209 RVA: 0x005FBCC1 File Offset: 0x005FA0C1
		public override bool IsManagingChildrenAsSubTrees()
		{
			return true;
		}

		// Token: 0x0601AA9A RID: 109210 RVA: 0x005FBCC4 File Offset: 0x005FA0C4
		private void SetPolicy(FAILURE_POLICY failPolicy, SUCCESS_POLICY successPolicy, EXIT_POLICY exitPolicty)
		{
			this.m_failPolicy = failPolicy;
			this.m_succeedPolicy = successPolicy;
			this.m_exitPolicy = exitPolicty;
		}

		// Token: 0x0601AA9B RID: 109211 RVA: 0x005FBCDC File Offset: 0x005FA0DC
		protected override BehaviorTask createTask()
		{
			return new Parallel.ParallelTask();
		}

		// Token: 0x0601AA9C RID: 109212 RVA: 0x005FBCF0 File Offset: 0x005FA0F0
		public EBTStatus ParallelUpdate(Agent pAgent, List<BehaviorTask> children)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = true;
			bool flag5 = true;
			bool flag6 = this.m_childFinishPolicy == CHILDFINISH_POLICY.CHILDFINISH_LOOP;
			for (int i = 0; i < children.Count; i++)
			{
				BehaviorTask behaviorTask = children[i];
				EBTStatus status = behaviorTask.GetStatus();
				if (flag6 || status == EBTStatus.BT_RUNNING || status == EBTStatus.BT_INVALID)
				{
					EBTStatus ebtstatus = behaviorTask.exec(pAgent);
					if (ebtstatus == EBTStatus.BT_FAILURE)
					{
						flag2 = true;
						flag5 = false;
					}
					else if (ebtstatus == EBTStatus.BT_SUCCESS)
					{
						flag = true;
						flag4 = false;
					}
					else if (ebtstatus == EBTStatus.BT_RUNNING)
					{
						flag3 = true;
						flag4 = false;
						flag5 = false;
					}
				}
				else if (status == EBTStatus.BT_SUCCESS)
				{
					flag = true;
					flag4 = false;
				}
				else
				{
					flag2 = true;
					flag5 = false;
				}
			}
			EBTStatus ebtstatus2 = (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_RUNNING;
			if ((this.m_failPolicy == FAILURE_POLICY.FAIL_ON_ALL && flag4) || (this.m_failPolicy == FAILURE_POLICY.FAIL_ON_ONE && flag2))
			{
				ebtstatus2 = EBTStatus.BT_FAILURE;
			}
			else if ((this.m_succeedPolicy == SUCCESS_POLICY.SUCCEED_ON_ALL && flag5) || (this.m_succeedPolicy == SUCCESS_POLICY.SUCCEED_ON_ONE && flag))
			{
				ebtstatus2 = EBTStatus.BT_SUCCESS;
			}
			if (this.m_exitPolicy == EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS && (ebtstatus2 == EBTStatus.BT_FAILURE || ebtstatus2 == EBTStatus.BT_SUCCESS))
			{
				for (int j = 0; j < children.Count; j++)
				{
					BehaviorTask behaviorTask2 = children[j];
					EBTStatus status2 = behaviorTask2.GetStatus();
					if (status2 == EBTStatus.BT_RUNNING)
					{
						behaviorTask2.abort(pAgent);
					}
				}
			}
			return ebtstatus2;
		}

		// Token: 0x040129EF RID: 76271
		protected FAILURE_POLICY m_failPolicy;

		// Token: 0x040129F0 RID: 76272
		protected SUCCESS_POLICY m_succeedPolicy;

		// Token: 0x040129F1 RID: 76273
		protected EXIT_POLICY m_exitPolicy;

		// Token: 0x040129F2 RID: 76274
		protected CHILDFINISH_POLICY m_childFinishPolicy;

		// Token: 0x0200486E RID: 18542
		private class ParallelTask : CompositeTask
		{
			// Token: 0x0601AA9E RID: 109214 RVA: 0x005FC071 File Offset: 0x005FA471
			protected override bool onenter(Agent pAgent)
			{
				return true;
			}

			// Token: 0x0601AA9F RID: 109215 RVA: 0x005FC074 File Offset: 0x005FA474
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AAA0 RID: 109216 RVA: 0x005FC080 File Offset: 0x005FA480
			protected override EBTStatus update_current(Agent pAgent, EBTStatus childStatus)
			{
				return this.update(pAgent, childStatus);
			}

			// Token: 0x0601AAA1 RID: 109217 RVA: 0x005FC098 File Offset: 0x005FA498
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				Parallel parallel = (Parallel)base.GetNode();
				return parallel.ParallelUpdate(pAgent, this.m_children);
			}
		}
	}
}
