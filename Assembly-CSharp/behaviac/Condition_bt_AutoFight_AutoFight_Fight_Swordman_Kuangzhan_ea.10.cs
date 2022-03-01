using System;

namespace behaviac
{
	// Token: 0x02002312 RID: 8978
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node23 : Condition
	{
		// Token: 0x06012F99 RID: 77721 RVA: 0x0059C276 File Offset: 0x0059A676
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012F9A RID: 77722 RVA: 0x0059C2AC File Offset: 0x0059A6AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9B1 RID: 51633
		private int opl_p0;

		// Token: 0x0400C9B2 RID: 51634
		private int opl_p1;

		// Token: 0x0400C9B3 RID: 51635
		private int opl_p2;

		// Token: 0x0400C9B4 RID: 51636
		private int opl_p3;
	}
}
