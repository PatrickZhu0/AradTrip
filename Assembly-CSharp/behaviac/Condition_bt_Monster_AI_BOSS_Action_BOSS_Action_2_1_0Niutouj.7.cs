using System;

namespace behaviac
{
	// Token: 0x02002F49 RID: 12105
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node14 : Condition
	{
		// Token: 0x06014762 RID: 83810 RVA: 0x00628066 File Offset: 0x00626466
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node14()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014763 RID: 83811 RVA: 0x0062809C File Offset: 0x0062649C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0D1 RID: 57553
		private int opl_p0;

		// Token: 0x0400E0D2 RID: 57554
		private int opl_p1;

		// Token: 0x0400E0D3 RID: 57555
		private int opl_p2;

		// Token: 0x0400E0D4 RID: 57556
		private int opl_p3;
	}
}
