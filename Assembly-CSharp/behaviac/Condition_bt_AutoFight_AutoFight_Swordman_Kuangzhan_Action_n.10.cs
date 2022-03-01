using System;

namespace behaviac
{
	// Token: 0x0200294F RID: 10575
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node32 : Condition
	{
		// Token: 0x06013BD3 RID: 80851 RVA: 0x005E6FA6 File Offset: 0x005E53A6
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node32()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013BD4 RID: 80852 RVA: 0x005E6FD8 File Offset: 0x005E53D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D638 RID: 54840
		private int opl_p0;

		// Token: 0x0400D639 RID: 54841
		private int opl_p1;

		// Token: 0x0400D63A RID: 54842
		private int opl_p2;

		// Token: 0x0400D63B RID: 54843
		private int opl_p3;
	}
}
