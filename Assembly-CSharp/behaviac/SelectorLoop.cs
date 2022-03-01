using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004873 RID: 18547
	public class SelectorLoop : BehaviorNode
	{
		// Token: 0x0601AAC0 RID: 109248 RVA: 0x00839E98 File Offset: 0x00838298
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "ResetChildren")
				{
					this.m_bResetChildren = (property_t.value == "true");
					break;
				}
			}
		}

		// Token: 0x0601AAC1 RID: 109249 RVA: 0x00839EFF File Offset: 0x008382FF
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is SelectorLoop && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AAC2 RID: 109250 RVA: 0x00839F1B File Offset: 0x0083831B
		public override bool IsManagingChildrenAsSubTrees()
		{
			return true;
		}

		// Token: 0x0601AAC3 RID: 109251 RVA: 0x00839F20 File Offset: 0x00838320
		protected override BehaviorTask createTask()
		{
			return new SelectorLoop.SelectorLoopTask();
		}

		// Token: 0x040129F9 RID: 76281
		protected bool m_bResetChildren;

		// Token: 0x02004874 RID: 18548
		public class SelectorLoopTask : CompositeTask
		{
			// Token: 0x0601AAC5 RID: 109253 RVA: 0x00839F3C File Offset: 0x0083833C
			protected override void addChild(BehaviorTask pBehavior)
			{
				base.addChild(pBehavior);
			}

			// Token: 0x0601AAC6 RID: 109254 RVA: 0x00839F48 File Offset: 0x00838348
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				SelectorLoop.SelectorLoopTask selectorLoopTask = (SelectorLoop.SelectorLoopTask)target;
				selectorLoopTask.m_activeChildIndex = this.m_activeChildIndex;
			}

			// Token: 0x0601AAC7 RID: 109255 RVA: 0x00839F70 File Offset: 0x00838370
			public override void save(ISerializableNode node)
			{
				base.save(node);
				CSerializationID attrId = new CSerializationID("activeChild");
				node.setAttr<int>(attrId, this.m_activeChildIndex);
			}

			// Token: 0x0601AAC8 RID: 109256 RVA: 0x00839F9D File Offset: 0x0083839D
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AAC9 RID: 109257 RVA: 0x00839FA6 File Offset: 0x008383A6
			protected override bool onenter(Agent pAgent)
			{
				this.m_activeChildIndex = -1;
				return base.onenter(pAgent);
			}

			// Token: 0x0601AACA RID: 109258 RVA: 0x00839FB6 File Offset: 0x008383B6
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AACB RID: 109259 RVA: 0x00839FC0 File Offset: 0x008383C0
			protected override EBTStatus update_current(Agent pAgent, EBTStatus childStatus)
			{
				return this.update(pAgent, childStatus);
			}

			// Token: 0x0601AACC RID: 109260 RVA: 0x00839FD8 File Offset: 0x008383D8
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				int num = -1;
				if (childStatus != EBTStatus.BT_RUNNING)
				{
					if (childStatus == EBTStatus.BT_SUCCESS)
					{
						return EBTStatus.BT_SUCCESS;
					}
					if (childStatus == EBTStatus.BT_FAILURE)
					{
						num = this.m_activeChildIndex;
					}
				}
				int num2 = -1;
				for (int i = num + 1; i < this.m_children.Count; i++)
				{
					WithPreconditionTask withPreconditionTask = (WithPreconditionTask)this.m_children[i];
					BehaviorTask preconditionNode = withPreconditionTask.PreconditionNode;
					EBTStatus ebtstatus = preconditionNode.exec(pAgent);
					if (ebtstatus == EBTStatus.BT_SUCCESS)
					{
						num2 = i;
						break;
					}
				}
				if (num2 != -1)
				{
					if (this.m_activeChildIndex != -1)
					{
						bool flag = this.m_activeChildIndex != num2;
						if (!flag)
						{
							SelectorLoop selectorLoop = (SelectorLoop)base.GetNode();
							if (selectorLoop != null)
							{
								flag = selectorLoop.m_bResetChildren;
							}
						}
						if (flag)
						{
							WithPreconditionTask withPreconditionTask2 = (WithPreconditionTask)this.m_children[this.m_activeChildIndex];
							withPreconditionTask2.abort(pAgent);
						}
					}
					int j = num2;
					while (j < this.m_children.Count)
					{
						WithPreconditionTask withPreconditionTask3 = (WithPreconditionTask)this.m_children[j];
						if (j <= num2)
						{
							goto IL_128;
						}
						BehaviorTask preconditionNode2 = withPreconditionTask3.PreconditionNode;
						EBTStatus ebtstatus2 = preconditionNode2.exec(pAgent);
						if (ebtstatus2 == EBTStatus.BT_SUCCESS)
						{
							goto IL_128;
						}
						IL_171:
						j++;
						continue;
						IL_128:
						BehaviorTask actionNode = withPreconditionTask3.ActionNode;
						EBTStatus ebtstatus3 = actionNode.exec(pAgent);
						if (ebtstatus3 == EBTStatus.BT_RUNNING)
						{
							this.m_activeChildIndex = j;
							withPreconditionTask3.m_status = EBTStatus.BT_RUNNING;
						}
						else
						{
							withPreconditionTask3.m_status = ebtstatus3;
							if (ebtstatus3 == EBTStatus.BT_FAILURE)
							{
								goto IL_171;
							}
						}
						return ebtstatus3;
					}
				}
				return EBTStatus.BT_FAILURE;
			}
		}
	}
}
