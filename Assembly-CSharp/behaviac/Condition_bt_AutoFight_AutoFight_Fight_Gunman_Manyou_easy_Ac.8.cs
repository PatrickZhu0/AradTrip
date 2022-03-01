using System;

namespace behaviac
{
	// Token: 0x0200210F RID: 8463
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node18 : Condition
	{
		// Token: 0x06012BB1 RID: 76721 RVA: 0x00580F0F File Offset: 0x0057F30F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012BB2 RID: 76722 RVA: 0x00580F44 File Offset: 0x0057F344
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5A3 RID: 50595
		private int opl_p0;

		// Token: 0x0400C5A4 RID: 50596
		private int opl_p1;

		// Token: 0x0400C5A5 RID: 50597
		private int opl_p2;

		// Token: 0x0400C5A6 RID: 50598
		private int opl_p3;
	}
}
