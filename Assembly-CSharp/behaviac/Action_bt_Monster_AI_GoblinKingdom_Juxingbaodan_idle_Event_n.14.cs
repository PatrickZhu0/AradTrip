using System;

namespace behaviac
{
	// Token: 0x02003389 RID: 13193
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node28 : Action
	{
		// Token: 0x06014F6F RID: 85871 RVA: 0x00650CB6 File Offset: 0x0064F0B6
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521403;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F70 RID: 85872 RVA: 0x00650CEE File Offset: 0x0064F0EE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E842 RID: 59458
		private BE_Target method_p0;

		// Token: 0x0400E843 RID: 59459
		private int method_p1;

		// Token: 0x0400E844 RID: 59460
		private int method_p2;

		// Token: 0x0400E845 RID: 59461
		private int method_p3;

		// Token: 0x0400E846 RID: 59462
		private int method_p4;
	}
}
