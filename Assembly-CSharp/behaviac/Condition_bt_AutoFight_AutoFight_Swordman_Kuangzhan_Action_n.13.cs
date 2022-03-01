using System;

namespace behaviac
{
	// Token: 0x02002953 RID: 10579
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node43 : Condition
	{
		// Token: 0x06013BDB RID: 80859 RVA: 0x005E7156 File Offset: 0x005E5556
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node43()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013BDC RID: 80860 RVA: 0x005E718C File Offset: 0x005E558C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D640 RID: 54848
		private int opl_p0;

		// Token: 0x0400D641 RID: 54849
		private int opl_p1;

		// Token: 0x0400D642 RID: 54850
		private int opl_p2;

		// Token: 0x0400D643 RID: 54851
		private int opl_p3;
	}
}
