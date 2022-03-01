using System;

namespace behaviac
{
	// Token: 0x02002093 RID: 8339
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node13 : Condition
	{
		// Token: 0x06012ABE RID: 76478 RVA: 0x0057AFB3 File Offset: 0x005793B3
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012ABF RID: 76479 RVA: 0x0057AFE8 File Offset: 0x005793E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4B0 RID: 50352
		private int opl_p0;

		// Token: 0x0400C4B1 RID: 50353
		private int opl_p1;

		// Token: 0x0400C4B2 RID: 50354
		private int opl_p2;

		// Token: 0x0400C4B3 RID: 50355
		private int opl_p3;
	}
}
