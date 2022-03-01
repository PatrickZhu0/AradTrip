using System;

namespace behaviac
{
	// Token: 0x02002CB7 RID: 11447
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node16 : Action
	{
		// Token: 0x06014263 RID: 82531 RVA: 0x0060D0CF File Offset: 0x0060B4CF
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522110;
		}

		// Token: 0x06014264 RID: 82532 RVA: 0x0060D0F0 File Offset: 0x0060B4F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC1C RID: 56348
		private BE_Target method_p0;

		// Token: 0x0400DC1D RID: 56349
		private int method_p1;
	}
}
