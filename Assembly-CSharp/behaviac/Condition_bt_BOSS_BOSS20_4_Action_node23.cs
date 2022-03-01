using System;

namespace behaviac
{
	// Token: 0x020029F3 RID: 10739
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node23 : Condition
	{
		// Token: 0x06013D19 RID: 81177 RVA: 0x005EE6EA File Offset: 0x005ECAEA
		public Condition_bt_BOSS_BOSS20_4_Action_node23()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06013D1A RID: 81178 RVA: 0x005EE720 File Offset: 0x005ECB20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D78C RID: 55180
		private int opl_p0;

		// Token: 0x0400D78D RID: 55181
		private int opl_p1;

		// Token: 0x0400D78E RID: 55182
		private int opl_p2;

		// Token: 0x0400D78F RID: 55183
		private int opl_p3;
	}
}
