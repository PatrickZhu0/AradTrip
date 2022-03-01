using System;

namespace behaviac
{
	// Token: 0x0200258B RID: 9611
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node46 : Condition
	{
		// Token: 0x0601345E RID: 78942 RVA: 0x005BA95B File Offset: 0x005B8D5B
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node46()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601345F RID: 78943 RVA: 0x005BA990 File Offset: 0x005B8D90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE86 RID: 52870
		private int opl_p0;

		// Token: 0x0400CE87 RID: 52871
		private int opl_p1;

		// Token: 0x0400CE88 RID: 52872
		private int opl_p2;

		// Token: 0x0400CE89 RID: 52873
		private int opl_p3;
	}
}
