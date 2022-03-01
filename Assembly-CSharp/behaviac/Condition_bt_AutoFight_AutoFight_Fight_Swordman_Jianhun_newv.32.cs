using System;

namespace behaviac
{
	// Token: 0x020022D8 RID: 8920
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node17 : Condition
	{
		// Token: 0x06012F2B RID: 77611 RVA: 0x0059856F File Offset: 0x0059696F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node17()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012F2C RID: 77612 RVA: 0x005985A4 File Offset: 0x005969A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C940 RID: 51520
		private int opl_p0;

		// Token: 0x0400C941 RID: 51521
		private int opl_p1;

		// Token: 0x0400C942 RID: 51522
		private int opl_p2;

		// Token: 0x0400C943 RID: 51523
		private int opl_p3;
	}
}
