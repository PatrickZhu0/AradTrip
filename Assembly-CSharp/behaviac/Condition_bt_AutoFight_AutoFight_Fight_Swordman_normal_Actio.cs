using System;

namespace behaviac
{
	// Token: 0x02002439 RID: 9273
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node5 : Condition
	{
		// Token: 0x060131C9 RID: 78281 RVA: 0x005AB817 File Offset: 0x005A9C17
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060131CA RID: 78282 RVA: 0x005AB84C File Offset: 0x005A9C4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBF2 RID: 52210
		private int opl_p0;

		// Token: 0x0400CBF3 RID: 52211
		private int opl_p1;

		// Token: 0x0400CBF4 RID: 52212
		private int opl_p2;

		// Token: 0x0400CBF5 RID: 52213
		private int opl_p3;
	}
}
