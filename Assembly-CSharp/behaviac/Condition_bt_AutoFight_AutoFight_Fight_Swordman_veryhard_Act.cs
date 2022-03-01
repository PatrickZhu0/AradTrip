using System;

namespace behaviac
{
	// Token: 0x02002456 RID: 9302
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node5 : Condition
	{
		// Token: 0x060131FF RID: 78335 RVA: 0x005ACD70 File Offset: 0x005AB170
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013200 RID: 78336 RVA: 0x005ACDA4 File Offset: 0x005AB1A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC24 RID: 52260
		private int opl_p0;

		// Token: 0x0400CC25 RID: 52261
		private int opl_p1;

		// Token: 0x0400CC26 RID: 52262
		private int opl_p2;

		// Token: 0x0400CC27 RID: 52263
		private int opl_p3;
	}
}
