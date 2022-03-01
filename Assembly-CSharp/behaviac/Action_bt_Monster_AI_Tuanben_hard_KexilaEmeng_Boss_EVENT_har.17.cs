using System;

namespace behaviac
{
	// Token: 0x02003BE1 RID: 15329
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node59 : Action
	{
		// Token: 0x06015F6F RID: 89967 RVA: 0x006A2E8A File Offset: 0x006A128A
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node59()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 91;
		}

		// Token: 0x06015F70 RID: 89968 RVA: 0x006A2EA8 File Offset: 0x006A12A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F80D RID: 63501
		private BE_Target method_p0;

		// Token: 0x0400F80E RID: 63502
		private int method_p1;
	}
}
