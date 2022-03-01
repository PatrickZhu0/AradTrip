using System;

namespace behaviac
{
	// Token: 0x0200234D RID: 9037
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node38 : Condition
	{
		// Token: 0x06013007 RID: 77831 RVA: 0x0059E96B File Offset: 0x0059CD6B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013008 RID: 77832 RVA: 0x0059E9A0 File Offset: 0x0059CDA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA1B RID: 51739
		private int opl_p0;

		// Token: 0x0400CA1C RID: 51740
		private int opl_p1;

		// Token: 0x0400CA1D RID: 51741
		private int opl_p2;

		// Token: 0x0400CA1E RID: 51742
		private int opl_p3;
	}
}
