using System;

namespace behaviac
{
	// Token: 0x020020EF RID: 8431
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node8 : Condition
	{
		// Token: 0x06012B72 RID: 76658 RVA: 0x0057F917 File Offset: 0x0057DD17
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B73 RID: 76659 RVA: 0x0057F94C File Offset: 0x0057DD4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C564 RID: 50532
		private int opl_p0;

		// Token: 0x0400C565 RID: 50533
		private int opl_p1;

		// Token: 0x0400C566 RID: 50534
		private int opl_p2;

		// Token: 0x0400C567 RID: 50535
		private int opl_p3;
	}
}
