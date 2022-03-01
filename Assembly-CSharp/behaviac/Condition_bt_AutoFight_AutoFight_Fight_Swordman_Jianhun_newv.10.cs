using System;

namespace behaviac
{
	// Token: 0x020022BB RID: 8891
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node3 : Condition
	{
		// Token: 0x06012EF1 RID: 77553 RVA: 0x00596546 File Offset: 0x00594946
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node3()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3500;
			this.opl_p3 = 3500;
		}

		// Token: 0x06012EF2 RID: 77554 RVA: 0x0059657C File Offset: 0x0059497C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C903 RID: 51459
		private int opl_p0;

		// Token: 0x0400C904 RID: 51460
		private int opl_p1;

		// Token: 0x0400C905 RID: 51461
		private int opl_p2;

		// Token: 0x0400C906 RID: 51462
		private int opl_p3;
	}
}
