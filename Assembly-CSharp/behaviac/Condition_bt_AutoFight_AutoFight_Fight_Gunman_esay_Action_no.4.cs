using System;

namespace behaviac
{
	// Token: 0x020020BF RID: 8383
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node8 : Condition
	{
		// Token: 0x06012B14 RID: 76564 RVA: 0x0057D397 File Offset: 0x0057B797
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B15 RID: 76565 RVA: 0x0057D3CC File Offset: 0x0057B7CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C506 RID: 50438
		private int opl_p0;

		// Token: 0x0400C507 RID: 50439
		private int opl_p1;

		// Token: 0x0400C508 RID: 50440
		private int opl_p2;

		// Token: 0x0400C509 RID: 50441
		private int opl_p3;
	}
}
