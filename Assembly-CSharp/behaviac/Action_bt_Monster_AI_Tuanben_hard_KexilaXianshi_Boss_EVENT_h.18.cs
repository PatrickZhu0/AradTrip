using System;

namespace behaviac
{
	// Token: 0x02003CD6 RID: 15574
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node6 : Action
	{
		// Token: 0x0601614E RID: 90446 RVA: 0x006AC9A7 File Offset: 0x006AADA7
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570144;
		}

		// Token: 0x0601614F RID: 90447 RVA: 0x006AC9C8 File Offset: 0x006AADC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA00 RID: 64000
		private BE_Target method_p0;

		// Token: 0x0400FA01 RID: 64001
		private int method_p1;
	}
}
