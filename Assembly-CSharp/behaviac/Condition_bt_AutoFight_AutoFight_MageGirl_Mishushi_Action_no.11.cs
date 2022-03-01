using System;

namespace behaviac
{
	// Token: 0x020026BD RID: 9917
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node54 : Condition
	{
		// Token: 0x060136BD RID: 79549 RVA: 0x005C8BD2 File Offset: 0x005C6FD2
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node54()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060136BE RID: 79550 RVA: 0x005C8C08 File Offset: 0x005C7008
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D113 RID: 53523
		private int opl_p0;

		// Token: 0x0400D114 RID: 53524
		private int opl_p1;

		// Token: 0x0400D115 RID: 53525
		private int opl_p2;

		// Token: 0x0400D116 RID: 53526
		private int opl_p3;
	}
}
