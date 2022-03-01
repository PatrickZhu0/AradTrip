using System;

namespace behaviac
{
	// Token: 0x02002671 RID: 9841
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node85 : Condition
	{
		// Token: 0x06013627 RID: 79399 RVA: 0x005C4AE6 File Offset: 0x005C2EE6
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node85()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013628 RID: 79400 RVA: 0x005C4B1C File Offset: 0x005C2F1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D079 RID: 53369
		private int opl_p0;

		// Token: 0x0400D07A RID: 53370
		private int opl_p1;

		// Token: 0x0400D07B RID: 53371
		private int opl_p2;

		// Token: 0x0400D07C RID: 53372
		private int opl_p3;
	}
}
