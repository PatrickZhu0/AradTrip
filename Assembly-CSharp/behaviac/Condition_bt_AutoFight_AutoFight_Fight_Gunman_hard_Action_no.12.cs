using System;

namespace behaviac
{
	// Token: 0x020020FF RID: 8447
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node28 : Condition
	{
		// Token: 0x06012B92 RID: 76690 RVA: 0x005800E7 File Offset: 0x0057E4E7
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node28()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B93 RID: 76691 RVA: 0x0058011C File Offset: 0x0057E51C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C584 RID: 50564
		private int opl_p0;

		// Token: 0x0400C585 RID: 50565
		private int opl_p1;

		// Token: 0x0400C586 RID: 50566
		private int opl_p2;

		// Token: 0x0400C587 RID: 50567
		private int opl_p3;
	}
}
