using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048AA RID: 18602
	internal class AlwaysTransition : Transition
	{
		// Token: 0x1700229A RID: 8858
		// (get) Token: 0x0601ABE6 RID: 109542 RVA: 0x0083B896 File Offset: 0x00839C96
		// (set) Token: 0x0601ABE7 RID: 109543 RVA: 0x0083B89E File Offset: 0x00839C9E
		public AlwaysTransition.ETransitionPhase TransitionPhase
		{
			get
			{
				return this.m_transitionPhase;
			}
			set
			{
				this.m_transitionPhase = value;
			}
		}

		// Token: 0x0601ABE8 RID: 109544 RVA: 0x0083B8A8 File Offset: 0x00839CA8
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "TransitionPhase")
				{
					if (property_t.value == "ETP_Exit")
					{
						this.m_transitionPhase = AlwaysTransition.ETransitionPhase.ETP_Exit;
					}
					else if (property_t.value == "ETP_Success")
					{
						this.m_transitionPhase = AlwaysTransition.ETransitionPhase.ETP_Success;
					}
					else if (property_t.value == "ETP_Failure")
					{
						this.m_transitionPhase = AlwaysTransition.ETransitionPhase.ETP_Failure;
					}
					else if (property_t.value == "ETP_Always")
					{
						this.m_transitionPhase = AlwaysTransition.ETransitionPhase.ETP_Always;
					}
				}
			}
		}

		// Token: 0x0601ABE9 RID: 109545 RVA: 0x0083B97B File Offset: 0x00839D7B
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is AlwaysTransition && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601ABEA RID: 109546 RVA: 0x0083B997 File Offset: 0x00839D97
		protected override BehaviorTask createTask()
		{
			return null;
		}

		// Token: 0x0601ABEB RID: 109547 RVA: 0x0083B99C File Offset: 0x00839D9C
		public override bool Evaluate(Agent pAgent, EBTStatus status)
		{
			return this.m_transitionPhase == AlwaysTransition.ETransitionPhase.ETP_Always || (status == EBTStatus.BT_SUCCESS && (this.m_transitionPhase == AlwaysTransition.ETransitionPhase.ETP_Success || this.m_transitionPhase == AlwaysTransition.ETransitionPhase.ETP_Exit)) || (status == EBTStatus.BT_FAILURE && (this.m_transitionPhase == AlwaysTransition.ETransitionPhase.ETP_Failure || this.m_transitionPhase == AlwaysTransition.ETransitionPhase.ETP_Exit));
		}

		// Token: 0x04012A11 RID: 76305
		protected AlwaysTransition.ETransitionPhase m_transitionPhase;

		// Token: 0x020048AB RID: 18603
		public enum ETransitionPhase
		{
			// Token: 0x04012A13 RID: 76307
			ETP_Always,
			// Token: 0x04012A14 RID: 76308
			ETP_Success,
			// Token: 0x04012A15 RID: 76309
			ETP_Failure,
			// Token: 0x04012A16 RID: 76310
			ETP_Exit
		}
	}
}
