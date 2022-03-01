using System;

namespace behaviac
{
	// Token: 0x02002317 RID: 8983
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node30 : Condition
	{
		// Token: 0x06012FA2 RID: 77730 RVA: 0x0059C496 File Offset: 0x0059A896
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node30()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012FA3 RID: 77731 RVA: 0x0059C4C8 File Offset: 0x0059A8C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9B9 RID: 51641
		private int opl_p0;

		// Token: 0x0400C9BA RID: 51642
		private int opl_p1;

		// Token: 0x0400C9BB RID: 51643
		private int opl_p2;

		// Token: 0x0400C9BC RID: 51644
		private int opl_p3;
	}
}
