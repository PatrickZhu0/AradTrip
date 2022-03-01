using System;

namespace behaviac
{
	// Token: 0x0200256F RID: 9583
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node13 : Condition
	{
		// Token: 0x06013426 RID: 78886 RVA: 0x005B9C46 File Offset: 0x005B8046
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013427 RID: 78887 RVA: 0x005B9C7C File Offset: 0x005B807C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE4D RID: 52813
		private int opl_p0;

		// Token: 0x0400CE4E RID: 52814
		private int opl_p1;

		// Token: 0x0400CE4F RID: 52815
		private int opl_p2;

		// Token: 0x0400CE50 RID: 52816
		private int opl_p3;
	}
}
