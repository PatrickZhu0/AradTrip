using System;

namespace behaviac
{
	// Token: 0x020036A1 RID: 13985
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node14 : Action
	{
		// Token: 0x0601555E RID: 87390 RVA: 0x0066F87F File Offset: 0x0066DC7F
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521232;
		}

		// Token: 0x0601555F RID: 87391 RVA: 0x0066F8A0 File Offset: 0x0066DCA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF2E RID: 61230
		private BE_Target method_p0;

		// Token: 0x0400EF2F RID: 61231
		private int method_p1;
	}
}
