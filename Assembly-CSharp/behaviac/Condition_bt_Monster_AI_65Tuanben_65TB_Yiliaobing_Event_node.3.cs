using System;

namespace behaviac
{
	// Token: 0x02002D23 RID: 11555
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2 : Condition
	{
		// Token: 0x06014331 RID: 82737 RVA: 0x006116D2 File Offset: 0x0060FAD2
		public Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 96;
		}

		// Token: 0x06014332 RID: 82738 RVA: 0x006116F0 File Offset: 0x0060FAF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCE9 RID: 56553
		private BE_Target opl_p0;

		// Token: 0x0400DCEA RID: 56554
		private BE_Equal opl_p1;

		// Token: 0x0400DCEB RID: 56555
		private int opl_p2;
	}
}
