using System;

namespace behaviac
{
	// Token: 0x02002123 RID: 8483
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node43 : Condition
	{
		// Token: 0x06012BD9 RID: 76761 RVA: 0x005818D7 File Offset: 0x0057FCD7
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012BDA RID: 76762 RVA: 0x0058190C File Offset: 0x0057FD0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5CB RID: 50635
		private int opl_p0;

		// Token: 0x0400C5CC RID: 50636
		private int opl_p1;

		// Token: 0x0400C5CD RID: 50637
		private int opl_p2;

		// Token: 0x0400C5CE RID: 50638
		private int opl_p3;
	}
}
