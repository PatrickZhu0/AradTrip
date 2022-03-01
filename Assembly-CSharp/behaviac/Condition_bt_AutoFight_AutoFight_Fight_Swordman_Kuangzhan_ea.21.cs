using System;

namespace behaviac
{
	// Token: 0x02002322 RID: 8994
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node43 : Condition
	{
		// Token: 0x06012FB7 RID: 77751 RVA: 0x0059C8B3 File Offset: 0x0059ACB3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node43()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012FB8 RID: 77752 RVA: 0x0059C8E8 File Offset: 0x0059ACE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9CD RID: 51661
		private int opl_p0;

		// Token: 0x0400C9CE RID: 51662
		private int opl_p1;

		// Token: 0x0400C9CF RID: 51663
		private int opl_p2;

		// Token: 0x0400C9D0 RID: 51664
		private int opl_p3;
	}
}
