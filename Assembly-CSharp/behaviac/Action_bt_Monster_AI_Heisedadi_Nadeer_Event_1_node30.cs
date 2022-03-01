using System;

namespace behaviac
{
	// Token: 0x020034FB RID: 13563
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node30 : Action
	{
		// Token: 0x06015239 RID: 86585 RVA: 0x0065EB73 File Offset: 0x0065CF73
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521792;
		}

		// Token: 0x0601523A RID: 86586 RVA: 0x0065EB94 File Offset: 0x0065CF94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB6A RID: 60266
		private BE_Target method_p0;

		// Token: 0x0400EB6B RID: 60267
		private int method_p1;
	}
}
