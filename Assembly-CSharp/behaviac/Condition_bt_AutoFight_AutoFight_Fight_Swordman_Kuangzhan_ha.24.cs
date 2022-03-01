using System;

namespace behaviac
{
	// Token: 0x02002386 RID: 9094
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node49 : Condition
	{
		// Token: 0x06013073 RID: 77939 RVA: 0x005A105B File Offset: 0x0059F45B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node49()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013074 RID: 77940 RVA: 0x005A1090 File Offset: 0x0059F490
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA87 RID: 51847
		private int opl_p0;

		// Token: 0x0400CA88 RID: 51848
		private int opl_p1;

		// Token: 0x0400CA89 RID: 51849
		private int opl_p2;

		// Token: 0x0400CA8A RID: 51850
		private int opl_p3;
	}
}
