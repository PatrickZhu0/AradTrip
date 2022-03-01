using System;

namespace behaviac
{
	// Token: 0x0200240F RID: 9231
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node5 : Condition
	{
		// Token: 0x0601317B RID: 78203 RVA: 0x005A98DA File Offset: 0x005A7CDA
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601317C RID: 78204 RVA: 0x005A9910 File Offset: 0x005A7D10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBA6 RID: 52134
		private int opl_p0;

		// Token: 0x0400CBA7 RID: 52135
		private int opl_p1;

		// Token: 0x0400CBA8 RID: 52136
		private int opl_p2;

		// Token: 0x0400CBA9 RID: 52137
		private int opl_p3;
	}
}
