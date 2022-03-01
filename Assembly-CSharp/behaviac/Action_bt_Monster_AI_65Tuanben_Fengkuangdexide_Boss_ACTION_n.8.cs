using System;

namespace behaviac
{
	// Token: 0x02002ECD RID: 11981
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node51 : Action
	{
		// Token: 0x06014674 RID: 83572 RVA: 0x00622802 File Offset: 0x00620C02
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node51()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570297;
			this.method_p2 = 15300;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06014675 RID: 83573 RVA: 0x0062283C File Offset: 0x00620C3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFDE RID: 57310
		private BE_Target method_p0;

		// Token: 0x0400DFDF RID: 57311
		private int method_p1;

		// Token: 0x0400DFE0 RID: 57312
		private int method_p2;

		// Token: 0x0400DFE1 RID: 57313
		private int method_p3;

		// Token: 0x0400DFE2 RID: 57314
		private int method_p4;
	}
}
