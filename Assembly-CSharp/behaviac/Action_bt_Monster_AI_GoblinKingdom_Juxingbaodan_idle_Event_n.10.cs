using System;

namespace behaviac
{
	// Token: 0x02003384 RID: 13188
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node24 : Action
	{
		// Token: 0x06014F65 RID: 85861 RVA: 0x00650B1C File Offset: 0x0064EF1C
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521400;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F66 RID: 85862 RVA: 0x00650B54 File Offset: 0x0064EF54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E831 RID: 59441
		private BE_Target method_p0;

		// Token: 0x0400E832 RID: 59442
		private int method_p1;

		// Token: 0x0400E833 RID: 59443
		private int method_p2;

		// Token: 0x0400E834 RID: 59444
		private int method_p3;

		// Token: 0x0400E835 RID: 59445
		private int method_p4;
	}
}
