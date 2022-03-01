using System;

namespace behaviac
{
	// Token: 0x0200269C RID: 9884
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node45 : Condition
	{
		// Token: 0x0601367C RID: 79484 RVA: 0x005C702E File Offset: 0x005C542E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node45()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601367D RID: 79485 RVA: 0x005C7064 File Offset: 0x005C5464
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0CF RID: 53455
		private int opl_p0;

		// Token: 0x0400D0D0 RID: 53456
		private int opl_p1;

		// Token: 0x0400D0D1 RID: 53457
		private int opl_p2;

		// Token: 0x0400D0D2 RID: 53458
		private int opl_p3;
	}
}
