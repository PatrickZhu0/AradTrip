using System;

namespace behaviac
{
	// Token: 0x02002577 RID: 9591
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node21 : Condition
	{
		// Token: 0x06013436 RID: 78902 RVA: 0x005BA01B File Offset: 0x005B841B
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node21()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013437 RID: 78903 RVA: 0x005BA050 File Offset: 0x005B8450
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE5E RID: 52830
		private int opl_p0;

		// Token: 0x0400CE5F RID: 52831
		private int opl_p1;

		// Token: 0x0400CE60 RID: 52832
		private int opl_p2;

		// Token: 0x0400CE61 RID: 52833
		private int opl_p3;
	}
}
