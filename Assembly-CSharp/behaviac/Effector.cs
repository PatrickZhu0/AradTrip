using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200483D RID: 18493
	public class Effector : AttachAction
	{
		// Token: 0x0601A950 RID: 108880 RVA: 0x00837FAB File Offset: 0x008363AB
		public Effector()
		{
			this.m_ActionConfig = new Effector.EffectorConfig();
		}

		// Token: 0x1700228F RID: 8847
		// (get) Token: 0x0601A951 RID: 108881 RVA: 0x00837FBE File Offset: 0x008363BE
		// (set) Token: 0x0601A952 RID: 108882 RVA: 0x00837FD0 File Offset: 0x008363D0
		public Effector.EPhase Phase
		{
			get
			{
				return ((Effector.EffectorConfig)this.m_ActionConfig).m_phase;
			}
			set
			{
				((Effector.EffectorConfig)this.m_ActionConfig).m_phase = value;
			}
		}

		// Token: 0x0601A953 RID: 108883 RVA: 0x00837FE3 File Offset: 0x008363E3
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Effector && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0200483E RID: 18494
		public enum EPhase
		{
			// Token: 0x0401295E RID: 76126
			E_SUCCESS,
			// Token: 0x0401295F RID: 76127
			E_FAILURE,
			// Token: 0x04012960 RID: 76128
			E_BOTH
		}

		// Token: 0x0200483F RID: 18495
		public class EffectorConfig : AttachAction.ActionConfig
		{
			// Token: 0x0601A955 RID: 108885 RVA: 0x00838008 File Offset: 0x00836408
			public override bool load(List<property_t> properties)
			{
				bool result = base.load(properties);
				try
				{
					for (int i = 0; i < properties.Count; i++)
					{
						property_t property_t = properties[i];
						if (property_t.name == "Phase")
						{
							if (property_t.value == "Success")
							{
								this.m_phase = Effector.EPhase.E_SUCCESS;
							}
							else if (property_t.value == "Failure")
							{
								this.m_phase = Effector.EPhase.E_FAILURE;
							}
							else if (property_t.value == "Both")
							{
								this.m_phase = Effector.EPhase.E_BOTH;
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

			// Token: 0x04012961 RID: 76129
			public Effector.EPhase m_phase;
		}
	}
}
