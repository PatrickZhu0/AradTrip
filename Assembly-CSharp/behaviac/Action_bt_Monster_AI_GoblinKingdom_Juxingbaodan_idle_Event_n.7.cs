using System;

namespace behaviac
{
	// Token: 0x0200337F RID: 13183
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node22 : Action
	{
		// Token: 0x06014F5B RID: 85851 RVA: 0x0065094A File Offset: 0x0064ED4A
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521403;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F5C RID: 85852 RVA: 0x00650982 File Offset: 0x0064ED82
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E826 RID: 59430
		private BE_Target method_p0;

		// Token: 0x0400E827 RID: 59431
		private int method_p1;

		// Token: 0x0400E828 RID: 59432
		private int method_p2;

		// Token: 0x0400E829 RID: 59433
		private int method_p3;

		// Token: 0x0400E82A RID: 59434
		private int method_p4;
	}
}
