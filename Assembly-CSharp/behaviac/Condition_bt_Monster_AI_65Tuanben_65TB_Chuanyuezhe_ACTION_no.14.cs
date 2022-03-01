using System;

namespace behaviac
{
	// Token: 0x02002B50 RID: 11088
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node22 : Condition
	{
		// Token: 0x06013FAE RID: 81838 RVA: 0x005FF855 File Offset: 0x005FDC55
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node22()
		{
			this.opl_p0 = 21852;
		}

		// Token: 0x06013FAF RID: 81839 RVA: 0x005FF868 File Offset: 0x005FDC68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9CE RID: 55758
		private int opl_p0;
	}
}
