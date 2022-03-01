using System;

namespace behaviac
{
	// Token: 0x02003C71 RID: 15473
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node8 : Action
	{
		// Token: 0x06016089 RID: 90249 RVA: 0x006A8C2E File Offset: 0x006A702E
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570108;
			this.method_p2 = 12000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601608A RID: 90250 RVA: 0x006A8C69 File Offset: 0x006A7069
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F910 RID: 63760
		private BE_Target method_p0;

		// Token: 0x0400F911 RID: 63761
		private int method_p1;

		// Token: 0x0400F912 RID: 63762
		private int method_p2;

		// Token: 0x0400F913 RID: 63763
		private int method_p3;

		// Token: 0x0400F914 RID: 63764
		private int method_p4;
	}
}
