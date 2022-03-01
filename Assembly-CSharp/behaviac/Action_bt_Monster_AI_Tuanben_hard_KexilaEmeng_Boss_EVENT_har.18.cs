using System;

namespace behaviac
{
	// Token: 0x02003BE2 RID: 15330
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node78 : Action
	{
		// Token: 0x06015F71 RID: 89969 RVA: 0x006A2EC2 File Offset: 0x006A12C2
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node78()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06015F72 RID: 89970 RVA: 0x006A2ED8 File Offset: 0x006A12D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F80F RID: 63503
		private int method_p0;
	}
}
