using System;

namespace behaviac
{
	// Token: 0x02002107 RID: 8455
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node8 : Condition
	{
		// Token: 0x06012BA1 RID: 76705 RVA: 0x00580B27 File Offset: 0x0057EF27
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node8()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012BA2 RID: 76706 RVA: 0x00580B5C File Offset: 0x0057EF5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C593 RID: 50579
		private int opl_p0;

		// Token: 0x0400C594 RID: 50580
		private int opl_p1;

		// Token: 0x0400C595 RID: 50581
		private int opl_p2;

		// Token: 0x0400C596 RID: 50582
		private int opl_p3;
	}
}
