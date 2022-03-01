using System;

namespace behaviac
{
	// Token: 0x0200265A RID: 9818
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node21 : Condition
	{
		// Token: 0x060135F9 RID: 79353 RVA: 0x005C40EA File Offset: 0x005C24EA
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node21()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060135FA RID: 79354 RVA: 0x005C4120 File Offset: 0x005C2520
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D048 RID: 53320
		private int opl_p0;

		// Token: 0x0400D049 RID: 53321
		private int opl_p1;

		// Token: 0x0400D04A RID: 53322
		private int opl_p2;

		// Token: 0x0400D04B RID: 53323
		private int opl_p3;
	}
}
