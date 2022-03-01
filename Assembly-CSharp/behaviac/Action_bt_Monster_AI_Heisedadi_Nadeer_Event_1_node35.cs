using System;

namespace behaviac
{
	// Token: 0x020034F6 RID: 13558
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node35 : Action
	{
		// Token: 0x0601522F RID: 86575 RVA: 0x0065E9AE File Offset: 0x0065CDAE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521795;
		}

		// Token: 0x06015230 RID: 86576 RVA: 0x0065E9CF File Offset: 0x0065CDCF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB58 RID: 60248
		private BE_Target method_p0;

		// Token: 0x0400EB59 RID: 60249
		private int method_p1;
	}
}
