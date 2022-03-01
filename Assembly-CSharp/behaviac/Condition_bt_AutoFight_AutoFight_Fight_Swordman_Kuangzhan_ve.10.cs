using System;

namespace behaviac
{
	// Token: 0x0200241A RID: 9242
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node23 : Condition
	{
		// Token: 0x0601318F RID: 78223 RVA: 0x005A9DCA File Offset: 0x005A81CA
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node23()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013190 RID: 78224 RVA: 0x005A9E00 File Offset: 0x005A8200
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBB9 RID: 52153
		private int opl_p0;

		// Token: 0x0400CBBA RID: 52154
		private int opl_p1;

		// Token: 0x0400CBBB RID: 52155
		private int opl_p2;

		// Token: 0x0400CBBC RID: 52156
		private int opl_p3;
	}
}
