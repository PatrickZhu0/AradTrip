using System;

namespace behaviac
{
	// Token: 0x02002EFB RID: 12027
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node2 : Action
	{
		// Token: 0x060146CE RID: 83662 RVA: 0x00624CD6 File Offset: 0x006230D6
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570296;
			this.method_p2 = 100;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060146CF RID: 83663 RVA: 0x00624D0D File Offset: 0x0062310D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E03F RID: 57407
		private BE_Target method_p0;

		// Token: 0x0400E040 RID: 57408
		private int method_p1;

		// Token: 0x0400E041 RID: 57409
		private int method_p2;

		// Token: 0x0400E042 RID: 57410
		private int method_p3;

		// Token: 0x0400E043 RID: 57411
		private int method_p4;
	}
}
