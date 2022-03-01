using System;

namespace behaviac
{
	// Token: 0x02002461 RID: 9313
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node2 : Condition
	{
		// Token: 0x06013213 RID: 78355 RVA: 0x005AD25E File Offset: 0x005AB65E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node2()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013214 RID: 78356 RVA: 0x005AD294 File Offset: 0x005AB694
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC37 RID: 52279
		private int opl_p0;

		// Token: 0x0400CC38 RID: 52280
		private int opl_p1;

		// Token: 0x0400CC39 RID: 52281
		private int opl_p2;

		// Token: 0x0400CC3A RID: 52282
		private int opl_p3;
	}
}
