using System;

namespace behaviac
{
	// Token: 0x02002213 RID: 8723
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node36 : Condition
	{
		// Token: 0x06012DB0 RID: 77232 RVA: 0x0058D580 File Offset: 0x0058B980
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node36()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012DB1 RID: 77233 RVA: 0x0058D5B4 File Offset: 0x0058B9B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7A4 RID: 51108
		private int opl_p0;

		// Token: 0x0400C7A5 RID: 51109
		private int opl_p1;

		// Token: 0x0400C7A6 RID: 51110
		private int opl_p2;

		// Token: 0x0400C7A7 RID: 51111
		private int opl_p3;
	}
}
