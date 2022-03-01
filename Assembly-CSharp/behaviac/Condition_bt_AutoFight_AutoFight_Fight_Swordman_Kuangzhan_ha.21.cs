using System;

namespace behaviac
{
	// Token: 0x02002382 RID: 9090
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node43 : Condition
	{
		// Token: 0x0601306B RID: 77931 RVA: 0x005A0E4B File Offset: 0x0059F24B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node43()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601306C RID: 77932 RVA: 0x005A0E80 File Offset: 0x0059F280
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA7F RID: 51839
		private int opl_p0;

		// Token: 0x0400CA80 RID: 51840
		private int opl_p1;

		// Token: 0x0400CA81 RID: 51841
		private int opl_p2;

		// Token: 0x0400CA82 RID: 51842
		private int opl_p3;
	}
}
