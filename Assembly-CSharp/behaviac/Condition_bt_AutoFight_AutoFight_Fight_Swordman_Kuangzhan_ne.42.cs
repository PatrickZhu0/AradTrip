using System;

namespace behaviac
{
	// Token: 0x020023C9 RID: 9161
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node13 : Condition
	{
		// Token: 0x060130F8 RID: 78072 RVA: 0x005A56CF File Offset: 0x005A3ACF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node13()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060130F9 RID: 78073 RVA: 0x005A5704 File Offset: 0x005A3B04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB29 RID: 52009
		private int opl_p0;

		// Token: 0x0400CB2A RID: 52010
		private int opl_p1;

		// Token: 0x0400CB2B RID: 52011
		private int opl_p2;

		// Token: 0x0400CB2C RID: 52012
		private int opl_p3;
	}
}
