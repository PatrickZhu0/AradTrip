using System;

namespace behaviac
{
	// Token: 0x0200220E RID: 8718
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node30 : Condition
	{
		// Token: 0x06012DA6 RID: 77222 RVA: 0x0058CF7E File Offset: 0x0058B37E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node30()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012DA7 RID: 77223 RVA: 0x0058CFB4 File Offset: 0x0058B3B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C799 RID: 51097
		private int opl_p0;

		// Token: 0x0400C79A RID: 51098
		private int opl_p1;

		// Token: 0x0400C79B RID: 51099
		private int opl_p2;

		// Token: 0x0400C79C RID: 51100
		private int opl_p3;
	}
}
