using System;

namespace behaviac
{
	// Token: 0x02003435 RID: 13365
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node17 : Action
	{
		// Token: 0x060150B8 RID: 86200 RVA: 0x00657140 File Offset: 0x00655540
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = BE_Equal.Equal;
			this.method_p2 = BE_State.IDLEE;
		}

		// Token: 0x060150B9 RID: 86201 RVA: 0x00657164 File Offset: 0x00655564
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CheckState(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E98A RID: 59786
		private BE_Target method_p0;

		// Token: 0x0400E98B RID: 59787
		private BE_Equal method_p1;

		// Token: 0x0400E98C RID: 59788
		private BE_State method_p2;
	}
}
