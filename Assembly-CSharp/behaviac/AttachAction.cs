using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200483B RID: 18491
	public class AttachAction : BehaviorNode
	{
		// Token: 0x0601A949 RID: 108873 RVA: 0x00837C84 File Offset: 0x00836084
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			this.m_ActionConfig.load(properties);
		}

		// Token: 0x0601A94A RID: 108874 RVA: 0x00837C9C File Offset: 0x0083609C
		public override bool Evaluate(Agent pAgent)
		{
			bool flag = this.m_ActionConfig.Execute(pAgent);
			if (!flag)
			{
				EBTStatus childStatus = EBTStatus.BT_INVALID;
				flag = (EBTStatus.BT_SUCCESS == this.update_impl(pAgent, childStatus));
			}
			return flag;
		}

		// Token: 0x0601A94B RID: 108875 RVA: 0x00837CCC File Offset: 0x008360CC
		public virtual bool Evaluate(Agent pAgent, EBTStatus status)
		{
			bool flag = this.m_ActionConfig.Execute(pAgent);
			if (!flag)
			{
				EBTStatus childStatus = EBTStatus.BT_INVALID;
				flag = (EBTStatus.BT_SUCCESS == this.update_impl(pAgent, childStatus));
			}
			return flag;
		}

		// Token: 0x0601A94C RID: 108876 RVA: 0x00837CFB File Offset: 0x008360FB
		protected override BehaviorTask createTask()
		{
			return null;
		}

		// Token: 0x04012958 RID: 76120
		protected AttachAction.ActionConfig m_ActionConfig;

		// Token: 0x0200483C RID: 18492
		public class ActionConfig
		{
			// Token: 0x0601A94D RID: 108877 RVA: 0x00837CFE File Offset: 0x008360FE
			protected ActionConfig()
			{
			}

			// Token: 0x0601A94E RID: 108878 RVA: 0x00837D08 File Offset: 0x00836108
			public virtual bool load(List<property_t> properties)
			{
				for (int i = 0; i < properties.Count; i++)
				{
					property_t property_t = properties[i];
					if (property_t.name == "Opl")
					{
						if (StringUtils.IsValidString(property_t.value))
						{
							int num = property_t.value.IndexOf('(');
							if (num == -1)
							{
								this.m_opl = AgentMeta.ParseProperty(property_t.value, null);
							}
							else
							{
								this.m_opl = AgentMeta.ParseMethod(property_t.value);
							}
						}
					}
					else if (property_t.name == "Opr1")
					{
						if (StringUtils.IsValidString(property_t.value))
						{
							int num2 = property_t.value.IndexOf('(');
							if (num2 == -1)
							{
								this.m_opr1 = AgentMeta.ParseProperty(property_t.value, null);
							}
							else
							{
								this.m_opr1 = AgentMeta.ParseMethod(property_t.value);
							}
						}
					}
					else if (property_t.name == "Operator")
					{
						this.m_operator = OperationUtils.ParseOperatorType(property_t.value);
					}
					else if (property_t.name == "Opr2" && StringUtils.IsValidString(property_t.value))
					{
						int num3 = property_t.value.IndexOf('(');
						if (num3 == -1)
						{
							this.m_opr2 = AgentMeta.ParseProperty(property_t.value, null);
						}
						else
						{
							this.m_opr2 = AgentMeta.ParseMethod(property_t.value);
						}
					}
				}
				return this.m_opl != null;
			}

			// Token: 0x0601A94F RID: 108879 RVA: 0x00837EB0 File Offset: 0x008362B0
			public bool Execute(Agent pAgent)
			{
				bool result = false;
				if (this.m_operator == EOperatorType.E_INVALID)
				{
					if (this.m_opl != null)
					{
						IMethod method = this.m_opl as IMethod;
						if (method != null)
						{
							method.Run(pAgent);
							result = true;
						}
					}
				}
				else if (this.m_operator == EOperatorType.E_ASSIGN)
				{
					if (this.m_opl != null)
					{
						this.m_opl.SetValue(pAgent, this.m_opr2);
						result = true;
					}
				}
				else if (this.m_operator >= EOperatorType.E_ADD && this.m_operator <= EOperatorType.E_DIV)
				{
					if (this.m_opl != null)
					{
						this.m_opl.Compute(pAgent, this.m_opr1, this.m_opr2, this.m_operator);
						result = true;
					}
				}
				else if (this.m_operator >= EOperatorType.E_EQUAL && this.m_operator <= EOperatorType.E_LESSEQUAL && this.m_opl != null)
				{
					result = this.m_opl.Compare(pAgent, this.m_opr2, this.m_operator);
				}
				return result;
			}

			// Token: 0x04012959 RID: 76121
			protected IInstanceMember m_opl;

			// Token: 0x0401295A RID: 76122
			protected IInstanceMember m_opr1;

			// Token: 0x0401295B RID: 76123
			protected IInstanceMember m_opr2;

			// Token: 0x0401295C RID: 76124
			public EOperatorType m_operator;
		}
	}
}
