using System;

namespace behaviac
{
	// Token: 0x02003545 RID: 13637
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3 : Action
	{
		// Token: 0x060152CB RID: 86731 RVA: 0x00661CB7 File Offset: 0x006600B7
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521736;
		}

		// Token: 0x060152CC RID: 86732 RVA: 0x00661CD8 File Offset: 0x006600D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC7F RID: 60543
		private BE_Target method_p0;

		// Token: 0x0400EC80 RID: 60544
		private int method_p1;
	}
}
