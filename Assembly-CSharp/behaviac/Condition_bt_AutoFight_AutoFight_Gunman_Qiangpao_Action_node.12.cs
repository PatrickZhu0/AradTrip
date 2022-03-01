using System;

namespace behaviac
{
	// Token: 0x0200264D RID: 9805
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node19 : Condition
	{
		// Token: 0x060135DF RID: 79327 RVA: 0x005C3B96 File Offset: 0x005C1F96
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node19()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060135E0 RID: 79328 RVA: 0x005C3BCC File Offset: 0x005C1FCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D02E RID: 53294
		private int opl_p0;

		// Token: 0x0400D02F RID: 53295
		private int opl_p1;

		// Token: 0x0400D030 RID: 53296
		private int opl_p2;

		// Token: 0x0400D031 RID: 53297
		private int opl_p3;
	}
}
