using System;

namespace behaviac
{
	// Token: 0x0200295B RID: 10587
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node5 : Condition
	{
		// Token: 0x06013BEB RID: 80875 RVA: 0x005E7516 File Offset: 0x005E5916
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013BEC RID: 80876 RVA: 0x005E754C File Offset: 0x005E594C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D650 RID: 54864
		private int opl_p0;

		// Token: 0x0400D651 RID: 54865
		private int opl_p1;

		// Token: 0x0400D652 RID: 54866
		private int opl_p2;

		// Token: 0x0400D653 RID: 54867
		private int opl_p3;
	}
}
