using System;

namespace behaviac
{
	// Token: 0x020020FB RID: 8443
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node23 : Condition
	{
		// Token: 0x06012B8A RID: 76682 RVA: 0x0057FF4B File Offset: 0x0057E34B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012B8B RID: 76683 RVA: 0x0057FF80 File Offset: 0x0057E380
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C57C RID: 50556
		private int opl_p0;

		// Token: 0x0400C57D RID: 50557
		private int opl_p1;

		// Token: 0x0400C57E RID: 50558
		private int opl_p2;

		// Token: 0x0400C57F RID: 50559
		private int opl_p3;
	}
}
