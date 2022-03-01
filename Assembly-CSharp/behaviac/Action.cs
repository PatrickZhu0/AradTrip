using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004855 RID: 18517
	public class Action : BehaviorNode
	{
		// Token: 0x0601AA23 RID: 109091 RVA: 0x00550874 File Offset: 0x0054EC74
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Method")
				{
					if (!string.IsNullOrEmpty(property_t.value))
					{
						this.m_method = AgentMeta.ParseMethod(property_t.value);
					}
				}
				else if (property_t.name == "ResultOption")
				{
					if (property_t.value == "BT_INVALID")
					{
						this.m_resultOption = EBTStatus.BT_INVALID;
					}
					else if (property_t.value == "BT_FAILURE")
					{
						this.m_resultOption = EBTStatus.BT_FAILURE;
					}
					else if (property_t.value == "BT_RUNNING")
					{
						this.m_resultOption = EBTStatus.BT_RUNNING;
					}
					else
					{
						this.m_resultOption = EBTStatus.BT_SUCCESS;
					}
				}
				else if (property_t.name == "ResultFunctor" && !string.IsNullOrEmpty(property_t.value))
				{
					this.m_resultFunctor = AgentMeta.ParseMethod(property_t.value);
				}
			}
		}

		// Token: 0x0601AA24 RID: 109092 RVA: 0x005509A8 File Offset: 0x0054EDA8
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Action && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AA25 RID: 109093 RVA: 0x005509C4 File Offset: 0x0054EDC4
		public EBTStatus Execute(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result;
			if (this.m_method != null)
			{
				if (this.m_resultOption != EBTStatus.BT_INVALID)
				{
					this.m_method.Run(pAgent);
					result = this.m_resultOption;
				}
				else if (this.m_resultFunctor != null)
				{
					IValue ivalue = this.m_resultFunctor.GetIValue(pAgent, this.m_method);
					result = ((TValue<EBTStatus>)ivalue).value;
				}
				else
				{
					IValue ivalue2 = this.m_method.GetIValue(pAgent);
					result = ((TValue<EBTStatus>)ivalue2).value;
				}
			}
			else
			{
				result = this.update_impl(pAgent, childStatus);
			}
			return result;
		}

		// Token: 0x0601AA26 RID: 109094 RVA: 0x00550A58 File Offset: 0x0054EE58
		protected override BehaviorTask createTask()
		{
			return new Action.ActionTask();
		}

		// Token: 0x040129CC RID: 76236
		protected IMethod m_method;

		// Token: 0x040129CD RID: 76237
		protected IMethod m_resultFunctor;

		// Token: 0x040129CE RID: 76238
		protected EBTStatus m_resultOption;

		// Token: 0x02004856 RID: 18518
		private class ActionTask : LeafTask
		{
			// Token: 0x0601AA28 RID: 109096 RVA: 0x00550A74 File Offset: 0x0054EE74
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AA29 RID: 109097 RVA: 0x00550A7D File Offset: 0x0054EE7D
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AA2A RID: 109098 RVA: 0x00550A86 File Offset: 0x0054EE86
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AA2B RID: 109099 RVA: 0x00550A8F File Offset: 0x0054EE8F
			protected override bool onenter(Agent pAgent)
			{
				return true;
			}

			// Token: 0x0601AA2C RID: 109100 RVA: 0x00550A92 File Offset: 0x0054EE92
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AA2D RID: 109101 RVA: 0x00550A94 File Offset: 0x0054EE94
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				Action action = (Action)base.GetNode();
				return action.Execute(pAgent, childStatus);
			}
		}
	}
}
