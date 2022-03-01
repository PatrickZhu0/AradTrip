using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048AE RID: 18606
	public class StartCondition : Precondition
	{
		// Token: 0x1700229C RID: 8860
		// (get) Token: 0x0601ABFC RID: 109564 RVA: 0x0083B755 File Offset: 0x00839B55
		// (set) Token: 0x0601ABFD RID: 109565 RVA: 0x0083B75D File Offset: 0x00839B5D
		public int TargetStateId
		{
			get
			{
				return this.m_targetId;
			}
			set
			{
				this.m_targetId = value;
			}
		}

		// Token: 0x0601ABFE RID: 109566 RVA: 0x0083B768 File Offset: 0x00839B68
		public override void ApplyEffects(Agent pAgent, Effector.EPhase phase)
		{
			for (int i = 0; i < this.m_effectors.Count; i++)
			{
				Effector.EffectorConfig effectorConfig = this.m_effectors[i];
				effectorConfig.Execute(pAgent);
			}
		}

		// Token: 0x0601ABFF RID: 109567 RVA: 0x0083B7A6 File Offset: 0x00839BA6
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is StartCondition && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AC00 RID: 109568 RVA: 0x0083B7C2 File Offset: 0x00839BC2
		public int TargetNodeId()
		{
			return this.m_targetId;
		}

		// Token: 0x0601AC01 RID: 109569 RVA: 0x0083B7CA File Offset: 0x00839BCA
		protected override BehaviorTask createTask()
		{
			return null;
		}

		// Token: 0x0601AC02 RID: 109570 RVA: 0x0083B7D0 File Offset: 0x00839BD0
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			if (this.m_loadAttachment)
			{
				Effector.EffectorConfig effectorConfig = new Effector.EffectorConfig();
				if (effectorConfig.load(properties))
				{
					this.m_effectors.Add(effectorConfig);
				}
				return;
			}
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "TargetFSMNodeId")
				{
					this.m_targetId = Convert.ToInt32(property_t.value);
				}
			}
		}

		// Token: 0x04012A19 RID: 76313
		protected List<Effector.EffectorConfig> m_effectors = new List<Effector.EffectorConfig>();

		// Token: 0x04012A1A RID: 76314
		protected int m_targetId = -1;
	}
}
