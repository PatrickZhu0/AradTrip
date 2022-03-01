using System;

namespace behaviac
{
	// Token: 0x02002D38 RID: 11576
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3 : Condition
	{
		// Token: 0x06014355 RID: 82773 RVA: 0x0061234C File Offset: 0x0061074C
		public Condition_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521973;
		}

		// Token: 0x06014356 RID: 82774 RVA: 0x00612370 File Offset: 0x00610770
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD1A RID: 56602
		private BE_Target opl_p0;

		// Token: 0x0400DD1B RID: 56603
		private BE_Equal opl_p1;

		// Token: 0x0400DD1C RID: 56604
		private int opl_p2;
	}
}
