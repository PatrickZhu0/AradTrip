using System;

namespace behaviac
{
	// Token: 0x020036A5 RID: 13989
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node28 : Action
	{
		// Token: 0x06015566 RID: 87398 RVA: 0x0066F9B3 File Offset: 0x0066DDB3
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521232;
		}

		// Token: 0x06015567 RID: 87399 RVA: 0x0066F9D4 File Offset: 0x0066DDD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF38 RID: 61240
		private BE_Target method_p0;

		// Token: 0x0400EF39 RID: 61241
		private int method_p1;
	}
}
