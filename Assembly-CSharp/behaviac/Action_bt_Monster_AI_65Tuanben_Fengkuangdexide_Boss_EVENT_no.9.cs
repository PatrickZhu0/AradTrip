using System;

namespace behaviac
{
	// Token: 0x02002F02 RID: 12034
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node7 : Action
	{
		// Token: 0x060146DC RID: 83676 RVA: 0x00624F21 File Offset: 0x00623321
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 92;
			this.method_p2 = 5000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060146DD RID: 83677 RVA: 0x00624F58 File Offset: 0x00623358
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E054 RID: 57428
		private BE_Target method_p0;

		// Token: 0x0400E055 RID: 57429
		private int method_p1;

		// Token: 0x0400E056 RID: 57430
		private int method_p2;

		// Token: 0x0400E057 RID: 57431
		private int method_p3;

		// Token: 0x0400E058 RID: 57432
		private int method_p4;
	}
}
