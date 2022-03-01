using System;

namespace behaviac
{
	// Token: 0x0200210B RID: 8459
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node13 : Condition
	{
		// Token: 0x06012BA9 RID: 76713 RVA: 0x00580CC3 File Offset: 0x0057F0C3
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012BAA RID: 76714 RVA: 0x00580CF8 File Offset: 0x0057F0F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C59B RID: 50587
		private int opl_p0;

		// Token: 0x0400C59C RID: 50588
		private int opl_p1;

		// Token: 0x0400C59D RID: 50589
		private int opl_p2;

		// Token: 0x0400C59E RID: 50590
		private int opl_p3;
	}
}
