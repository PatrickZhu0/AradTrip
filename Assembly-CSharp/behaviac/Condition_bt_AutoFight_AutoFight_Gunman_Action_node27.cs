using System;

namespace behaviac
{
	// Token: 0x0200257B RID: 9595
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node27 : Condition
	{
		// Token: 0x0601343E RID: 78910 RVA: 0x005BA1CF File Offset: 0x005B85CF
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node27()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1700;
			this.opl_p3 = 1700;
		}

		// Token: 0x0601343F RID: 78911 RVA: 0x005BA204 File Offset: 0x005B8604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE66 RID: 52838
		private int opl_p0;

		// Token: 0x0400CE67 RID: 52839
		private int opl_p1;

		// Token: 0x0400CE68 RID: 52840
		private int opl_p2;

		// Token: 0x0400CE69 RID: 52841
		private int opl_p3;
	}
}
