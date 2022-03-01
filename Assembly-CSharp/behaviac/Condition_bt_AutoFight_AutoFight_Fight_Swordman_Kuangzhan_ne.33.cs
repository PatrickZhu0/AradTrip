using System;

namespace behaviac
{
	// Token: 0x020023BD RID: 9149
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node24 : Condition
	{
		// Token: 0x060130E0 RID: 78048 RVA: 0x005A51B3 File Offset: 0x005A35B3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node24()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060130E1 RID: 78049 RVA: 0x005A51E8 File Offset: 0x005A35E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB11 RID: 51985
		private int opl_p0;

		// Token: 0x0400CB12 RID: 51986
		private int opl_p1;

		// Token: 0x0400CB13 RID: 51987
		private int opl_p2;

		// Token: 0x0400CB14 RID: 51988
		private int opl_p3;
	}
}
