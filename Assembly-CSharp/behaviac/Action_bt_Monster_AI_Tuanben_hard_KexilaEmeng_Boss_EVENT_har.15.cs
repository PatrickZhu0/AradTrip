using System;

namespace behaviac
{
	// Token: 0x02003BDE RID: 15326
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node57 : Action
	{
		// Token: 0x06015F69 RID: 89961 RVA: 0x006A2DA3 File Offset: 0x006A11A3
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node57()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 91;
			this.method_p2 = 100000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015F6A RID: 89962 RVA: 0x006A2DDB File Offset: 0x006A11DB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F805 RID: 63493
		private BE_Target method_p0;

		// Token: 0x0400F806 RID: 63494
		private int method_p1;

		// Token: 0x0400F807 RID: 63495
		private int method_p2;

		// Token: 0x0400F808 RID: 63496
		private int method_p3;

		// Token: 0x0400F809 RID: 63497
		private int method_p4;
	}
}
