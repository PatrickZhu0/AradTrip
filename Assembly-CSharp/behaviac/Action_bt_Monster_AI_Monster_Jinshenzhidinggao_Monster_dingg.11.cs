using System;

namespace behaviac
{
	// Token: 0x020036A6 RID: 13990
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node33 : Action
	{
		// Token: 0x06015568 RID: 87400 RVA: 0x0066F9EE File Offset: 0x0066DDEE
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node33()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521233;
		}

		// Token: 0x06015569 RID: 87401 RVA: 0x0066FA0F File Offset: 0x0066DE0F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF3A RID: 61242
		private BE_Target method_p0;

		// Token: 0x0400EF3B RID: 61243
		private int method_p1;
	}
}
