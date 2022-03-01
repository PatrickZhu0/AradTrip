using System;

namespace behaviac
{
	// Token: 0x02003C59 RID: 15449
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node37 : Action
	{
		// Token: 0x0601605A RID: 90202 RVA: 0x006A7E23 File Offset: 0x006A6223
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570212;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601605B RID: 90203 RVA: 0x006A7E5A File Offset: 0x006A625A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8D4 RID: 63700
		private BE_Target method_p0;

		// Token: 0x0400F8D5 RID: 63701
		private int method_p1;

		// Token: 0x0400F8D6 RID: 63702
		private int method_p2;

		// Token: 0x0400F8D7 RID: 63703
		private int method_p3;

		// Token: 0x0400F8D8 RID: 63704
		private int method_p4;
	}
}
