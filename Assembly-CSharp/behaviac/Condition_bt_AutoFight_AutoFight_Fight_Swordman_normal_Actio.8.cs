using System;

namespace behaviac
{
	// Token: 0x02002444 RID: 9284
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node2 : Condition
	{
		// Token: 0x060131DD RID: 78301 RVA: 0x005ABD06 File Offset: 0x005AA106
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node2()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060131DE RID: 78302 RVA: 0x005ABD3C File Offset: 0x005AA13C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC05 RID: 52229
		private int opl_p0;

		// Token: 0x0400CC06 RID: 52230
		private int opl_p1;

		// Token: 0x0400CC07 RID: 52231
		private int opl_p2;

		// Token: 0x0400CC08 RID: 52232
		private int opl_p3;
	}
}
