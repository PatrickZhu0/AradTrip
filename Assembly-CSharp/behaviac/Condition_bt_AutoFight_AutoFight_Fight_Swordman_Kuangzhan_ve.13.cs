using System;

namespace behaviac
{
	// Token: 0x0200241F RID: 9247
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node30 : Condition
	{
		// Token: 0x06013198 RID: 78232 RVA: 0x005A9FEA File Offset: 0x005A83EA
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node30()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013199 RID: 78233 RVA: 0x005AA01C File Offset: 0x005A841C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBC1 RID: 52161
		private int opl_p0;

		// Token: 0x0400CBC2 RID: 52162
		private int opl_p1;

		// Token: 0x0400CBC3 RID: 52163
		private int opl_p2;

		// Token: 0x0400CBC4 RID: 52164
		private int opl_p3;
	}
}
