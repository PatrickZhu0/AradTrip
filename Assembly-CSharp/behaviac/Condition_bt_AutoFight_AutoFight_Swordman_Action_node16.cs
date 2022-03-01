using System;

namespace behaviac
{
	// Token: 0x02002880 RID: 10368
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node16 : Condition
	{
		// Token: 0x06013A3D RID: 80445 RVA: 0x005DCE6A File Offset: 0x005DB26A
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node16()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013A3E RID: 80446 RVA: 0x005DCE9C File Offset: 0x005DB29C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D496 RID: 54422
		private int opl_p0;

		// Token: 0x0400D497 RID: 54423
		private int opl_p1;

		// Token: 0x0400D498 RID: 54424
		private int opl_p2;

		// Token: 0x0400D499 RID: 54425
		private int opl_p3;
	}
}
