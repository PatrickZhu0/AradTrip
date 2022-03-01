using System;

namespace behaviac
{
	// Token: 0x020025EF RID: 9711
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node46 : Condition
	{
		// Token: 0x06013525 RID: 79141 RVA: 0x005BE2FE File Offset: 0x005BC6FE
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node46()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013526 RID: 79142 RVA: 0x005BE334 File Offset: 0x005BC734
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF6B RID: 53099
		private int opl_p0;

		// Token: 0x0400CF6C RID: 53100
		private int opl_p1;

		// Token: 0x0400CF6D RID: 53101
		private int opl_p2;

		// Token: 0x0400CF6E RID: 53102
		private int opl_p3;
	}
}
