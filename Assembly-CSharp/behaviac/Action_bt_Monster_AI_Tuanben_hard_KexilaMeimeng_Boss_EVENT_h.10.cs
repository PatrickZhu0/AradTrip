using System;

namespace behaviac
{
	// Token: 0x02003C61 RID: 15457
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node45 : Action
	{
		// Token: 0x0601606A RID: 90218 RVA: 0x006A8092 File Offset: 0x006A6492
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node45()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
		}

		// Token: 0x0601606B RID: 90219 RVA: 0x006A80B3 File Offset: 0x006A64B3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8EB RID: 63723
		private BE_Target method_p0;

		// Token: 0x0400F8EC RID: 63724
		private int method_p1;
	}
}
