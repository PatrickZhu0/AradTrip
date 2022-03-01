using System;

namespace behaviac
{
	// Token: 0x02002653 RID: 9811
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node54 : Condition
	{
		// Token: 0x060135EB RID: 79339 RVA: 0x005C3DF3 File Offset: 0x005C21F3
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node54()
		{
			this.opl_p0 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p1 = 2;
		}

		// Token: 0x060135EC RID: 79340 RVA: 0x005C3E0C File Offset: 0x005C220C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckLastResult(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D03B RID: 53307
		private BE_Operation opl_p0;

		// Token: 0x0400D03C RID: 53308
		private int opl_p1;
	}
}
