using System;

namespace behaviac
{
	// Token: 0x0200245C RID: 9308
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node16 : Condition
	{
		// Token: 0x0601320A RID: 78346 RVA: 0x005AD09A File Offset: 0x005AB49A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node16()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601320B RID: 78347 RVA: 0x005AD0D0 File Offset: 0x005AB4D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC2F RID: 52271
		private int opl_p0;

		// Token: 0x0400CC30 RID: 52272
		private int opl_p1;

		// Token: 0x0400CC31 RID: 52273
		private int opl_p2;

		// Token: 0x0400CC32 RID: 52274
		private int opl_p3;
	}
}
