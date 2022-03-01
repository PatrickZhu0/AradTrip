using System;

namespace behaviac
{
	// Token: 0x0200211B RID: 8475
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node33 : Condition
	{
		// Token: 0x06012BC9 RID: 76745 RVA: 0x00581493 File Offset: 0x0057F893
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012BCA RID: 76746 RVA: 0x005814C8 File Offset: 0x0057F8C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5BB RID: 50619
		private int opl_p0;

		// Token: 0x0400C5BC RID: 50620
		private int opl_p1;

		// Token: 0x0400C5BD RID: 50621
		private int opl_p2;

		// Token: 0x0400C5BE RID: 50622
		private int opl_p3;
	}
}
