using System;

namespace behaviac
{
	// Token: 0x02002643 RID: 9795
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node17 : Condition
	{
		// Token: 0x060135CB RID: 79307 RVA: 0x005C379A File Offset: 0x005C1B9A
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node17()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060135CC RID: 79308 RVA: 0x005C37D0 File Offset: 0x005C1BD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D019 RID: 53273
		private int opl_p0;

		// Token: 0x0400D01A RID: 53274
		private int opl_p1;

		// Token: 0x0400D01B RID: 53275
		private int opl_p2;

		// Token: 0x0400D01C RID: 53276
		private int opl_p3;
	}
}
