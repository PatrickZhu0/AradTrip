using System;

namespace behaviac
{
	// Token: 0x020023F5 RID: 9205
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node38 : Condition
	{
		// Token: 0x06013149 RID: 78153 RVA: 0x005A7F27 File Offset: 0x005A6327
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601314A RID: 78154 RVA: 0x005A7F5C File Offset: 0x005A635C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB71 RID: 52081
		private int opl_p0;

		// Token: 0x0400CB72 RID: 52082
		private int opl_p1;

		// Token: 0x0400CB73 RID: 52083
		private int opl_p2;

		// Token: 0x0400CB74 RID: 52084
		private int opl_p3;
	}
}
