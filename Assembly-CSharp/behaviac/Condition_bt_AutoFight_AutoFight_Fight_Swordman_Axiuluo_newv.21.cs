using System;

namespace behaviac
{
	// Token: 0x0200221D RID: 8733
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node53 : Condition
	{
		// Token: 0x06012DC4 RID: 77252 RVA: 0x0058E06B File Offset: 0x0058C46B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node53()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012DC5 RID: 77253 RVA: 0x0058E0A0 File Offset: 0x0058C4A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7BA RID: 51130
		private int opl_p0;

		// Token: 0x0400C7BB RID: 51131
		private int opl_p1;

		// Token: 0x0400C7BC RID: 51132
		private int opl_p2;

		// Token: 0x0400C7BD RID: 51133
		private int opl_p3;
	}
}
