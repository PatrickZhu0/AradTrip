using System;

namespace behaviac
{
	// Token: 0x02002968 RID: 10600
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node17 : Condition
	{
		// Token: 0x06013C05 RID: 80901 RVA: 0x005E7AC6 File Offset: 0x005E5EC6
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node17()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013C06 RID: 80902 RVA: 0x005E7AFC File Offset: 0x005E5EFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D66A RID: 54890
		private int opl_p0;

		// Token: 0x0400D66B RID: 54891
		private int opl_p1;

		// Token: 0x0400D66C RID: 54892
		private int opl_p2;

		// Token: 0x0400D66D RID: 54893
		private int opl_p3;
	}
}
