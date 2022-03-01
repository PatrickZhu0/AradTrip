using System;

namespace behaviac
{
	// Token: 0x020026C5 RID: 9925
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node36 : Condition
	{
		// Token: 0x060136CD RID: 79565 RVA: 0x005C8F3A File Offset: 0x005C733A
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node36()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060136CE RID: 79566 RVA: 0x005C8F70 File Offset: 0x005C7370
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D123 RID: 53539
		private int opl_p0;

		// Token: 0x0400D124 RID: 53540
		private int opl_p1;

		// Token: 0x0400D125 RID: 53541
		private int opl_p2;

		// Token: 0x0400D126 RID: 53542
		private int opl_p3;
	}
}
