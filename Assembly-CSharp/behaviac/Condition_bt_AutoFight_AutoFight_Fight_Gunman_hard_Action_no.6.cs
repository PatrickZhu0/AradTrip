using System;

namespace behaviac
{
	// Token: 0x020020F3 RID: 8435
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node13 : Condition
	{
		// Token: 0x06012B7A RID: 76666 RVA: 0x0057FAB3 File Offset: 0x0057DEB3
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B7B RID: 76667 RVA: 0x0057FAE8 File Offset: 0x0057DEE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C56C RID: 50540
		private int opl_p0;

		// Token: 0x0400C56D RID: 50541
		private int opl_p1;

		// Token: 0x0400C56E RID: 50542
		private int opl_p2;

		// Token: 0x0400C56F RID: 50543
		private int opl_p3;
	}
}
