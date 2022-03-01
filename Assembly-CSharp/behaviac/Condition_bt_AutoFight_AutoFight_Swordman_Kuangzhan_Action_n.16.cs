using System;

namespace behaviac
{
	// Token: 0x02002957 RID: 10583
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node52 : Condition
	{
		// Token: 0x06013BE3 RID: 80867 RVA: 0x005E7366 File Offset: 0x005E5766
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node52()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 100;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013BE4 RID: 80868 RVA: 0x005E7398 File Offset: 0x005E5798
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D648 RID: 54856
		private int opl_p0;

		// Token: 0x0400D649 RID: 54857
		private int opl_p1;

		// Token: 0x0400D64A RID: 54858
		private int opl_p2;

		// Token: 0x0400D64B RID: 54859
		private int opl_p3;
	}
}
