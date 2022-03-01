using System;

namespace behaviac
{
	// Token: 0x020020AF RID: 8367
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node18 : Condition
	{
		// Token: 0x06012AF5 RID: 76533 RVA: 0x0057C4BF File Offset: 0x0057A8BF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012AF6 RID: 76534 RVA: 0x0057C4F4 File Offset: 0x0057A8F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4E7 RID: 50407
		private int opl_p0;

		// Token: 0x0400C4E8 RID: 50408
		private int opl_p1;

		// Token: 0x0400C4E9 RID: 50409
		private int opl_p2;

		// Token: 0x0400C4EA RID: 50410
		private int opl_p3;
	}
}
