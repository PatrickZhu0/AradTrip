using System;

namespace behaviac
{
	// Token: 0x02002932 RID: 10546
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node30 : Condition
	{
		// Token: 0x06013B9A RID: 80794 RVA: 0x005E5037 File Offset: 0x005E3437
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node30()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06013B9B RID: 80795 RVA: 0x005E506C File Offset: 0x005E346C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5FF RID: 54783
		private int opl_p0;

		// Token: 0x0400D600 RID: 54784
		private int opl_p1;

		// Token: 0x0400D601 RID: 54785
		private int opl_p2;

		// Token: 0x0400D602 RID: 54786
		private int opl_p3;
	}
}
