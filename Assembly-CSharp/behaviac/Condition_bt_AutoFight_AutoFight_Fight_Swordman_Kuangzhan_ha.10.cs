using System;

namespace behaviac
{
	// Token: 0x02002372 RID: 9074
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node23 : Condition
	{
		// Token: 0x0601304D RID: 77901 RVA: 0x005A080E File Offset: 0x0059EC0E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601304E RID: 77902 RVA: 0x005A0844 File Offset: 0x0059EC44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA63 RID: 51811
		private int opl_p0;

		// Token: 0x0400CA64 RID: 51812
		private int opl_p1;

		// Token: 0x0400CA65 RID: 51813
		private int opl_p2;

		// Token: 0x0400CA66 RID: 51814
		private int opl_p3;
	}
}
