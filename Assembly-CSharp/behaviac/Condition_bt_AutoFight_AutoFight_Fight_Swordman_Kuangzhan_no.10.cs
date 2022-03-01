using System;

namespace behaviac
{
	// Token: 0x020023EA RID: 9194
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node23 : Condition
	{
		// Token: 0x06013135 RID: 78133 RVA: 0x005A7AFE File Offset: 0x005A5EFE
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013136 RID: 78134 RVA: 0x005A7B34 File Offset: 0x005A5F34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB60 RID: 52064
		private int opl_p0;

		// Token: 0x0400CB61 RID: 52065
		private int opl_p1;

		// Token: 0x0400CB62 RID: 52066
		private int opl_p2;

		// Token: 0x0400CB63 RID: 52067
		private int opl_p3;
	}
}
