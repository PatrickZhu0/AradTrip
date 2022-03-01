using System;

namespace behaviac
{
	// Token: 0x0200297B RID: 10619
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node15 : Condition
	{
		// Token: 0x06013C2B RID: 80939 RVA: 0x005E83A7 File Offset: 0x005E67A7
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node15()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013C2C RID: 80940 RVA: 0x005E83DC File Offset: 0x005E67DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D692 RID: 54930
		private int opl_p0;

		// Token: 0x0400D693 RID: 54931
		private int opl_p1;

		// Token: 0x0400D694 RID: 54932
		private int opl_p2;

		// Token: 0x0400D695 RID: 54933
		private int opl_p3;
	}
}
