using System;

namespace behaviac
{
	// Token: 0x02001ED4 RID: 7892
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node34 : Condition
	{
		// Token: 0x0601274D RID: 75597 RVA: 0x005662BA File Offset: 0x005646BA
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node34()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601274E RID: 75598 RVA: 0x005662F0 File Offset: 0x005646F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C13E RID: 49470
		private int opl_p0;

		// Token: 0x0400C13F RID: 49471
		private int opl_p1;

		// Token: 0x0400C140 RID: 49472
		private int opl_p2;

		// Token: 0x0400C141 RID: 49473
		private int opl_p3;
	}
}
