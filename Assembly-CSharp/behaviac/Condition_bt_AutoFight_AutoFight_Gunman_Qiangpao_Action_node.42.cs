using System;

namespace behaviac
{
	// Token: 0x02002675 RID: 9845
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node42 : Condition
	{
		// Token: 0x0601362F RID: 79407 RVA: 0x005C4C9E File Offset: 0x005C309E
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node42()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013630 RID: 79408 RVA: 0x005C4CD4 File Offset: 0x005C30D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D081 RID: 53377
		private int opl_p0;

		// Token: 0x0400D082 RID: 53378
		private int opl_p1;

		// Token: 0x0400D083 RID: 53379
		private int opl_p2;

		// Token: 0x0400D084 RID: 53380
		private int opl_p3;
	}
}
