using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004841 RID: 18497
	public class Precondition : AttachAction
	{
		// Token: 0x0601A95E RID: 108894 RVA: 0x008382BC File Offset: 0x008366BC
		public Precondition()
		{
			this.m_ActionConfig = new Precondition.PreconditionConfig();
		}

		// Token: 0x17002290 RID: 8848
		// (get) Token: 0x0601A95F RID: 108895 RVA: 0x008382CF File Offset: 0x008366CF
		// (set) Token: 0x0601A960 RID: 108896 RVA: 0x008382E1 File Offset: 0x008366E1
		public Precondition.EPhase Phase
		{
			get
			{
				return ((Precondition.PreconditionConfig)this.m_ActionConfig).m_phase;
			}
			set
			{
				((Precondition.PreconditionConfig)this.m_ActionConfig).m_phase = value;
			}
		}

		// Token: 0x17002291 RID: 8849
		// (get) Token: 0x0601A961 RID: 108897 RVA: 0x008382F4 File Offset: 0x008366F4
		// (set) Token: 0x0601A962 RID: 108898 RVA: 0x00838306 File Offset: 0x00836706
		public bool IsAnd
		{
			get
			{
				return ((Precondition.PreconditionConfig)this.m_ActionConfig).m_bAnd;
			}
			set
			{
				((Precondition.PreconditionConfig)this.m_ActionConfig).m_bAnd = value;
			}
		}

		// Token: 0x0601A963 RID: 108899 RVA: 0x00838319 File Offset: 0x00836719
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Precondition && base.IsValid(pAgent, pTask);
		}

		// Token: 0x02004842 RID: 18498
		public enum EPhase
		{
			// Token: 0x04012968 RID: 76136
			E_ENTER,
			// Token: 0x04012969 RID: 76137
			E_UPDATE,
			// Token: 0x0401296A RID: 76138
			E_BOTH
		}

		// Token: 0x02004843 RID: 18499
		public class PreconditionConfig : AttachAction.ActionConfig
		{
			// Token: 0x0601A965 RID: 108901 RVA: 0x00838340 File Offset: 0x00836740
			public override bool load(List<property_t> properties)
			{
				bool result = base.load(properties);
				try
				{
					for (int i = 0; i < properties.Count; i++)
					{
						property_t property_t = properties[i];
						if (property_t.name == "BinaryOperator")
						{
							if (property_t.value == "Or")
							{
								this.m_bAnd = false;
							}
							else if (property_t.value == "And")
							{
								this.m_bAnd = true;
							}
						}
						else if (property_t.name == "Phase")
						{
							if (property_t.value == "Enter")
							{
								this.m_phase = Precondition.EPhase.E_ENTER;
							}
							else if (property_t.value == "Update")
							{
								this.m_phase = Precondition.EPhase.E_UPDATE;
							}
							else if (property_t.value == "Both")
							{
								this.m_phase = Precondition.EPhase.E_BOTH;
							}
							break;
						}
					}
				}
				catch (Exception ex)
				{
					result = false;
				}
				return result;
			}

			// Token: 0x0401296B RID: 76139
			public Precondition.EPhase m_phase;

			// Token: 0x0401296C RID: 76140
			public bool m_bAnd;
		}
	}
}
