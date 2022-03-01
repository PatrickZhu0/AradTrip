using System;

namespace behaviac
{
	// Token: 0x02002F3C RID: 12092
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node14 : Condition
	{
		// Token: 0x06014749 RID: 83785 RVA: 0x0062772A File Offset: 0x00625B2A
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node14()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601474A RID: 83786 RVA: 0x00627760 File Offset: 0x00625B60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0B9 RID: 57529
		private int opl_p0;

		// Token: 0x0400E0BA RID: 57530
		private int opl_p1;

		// Token: 0x0400E0BB RID: 57531
		private int opl_p2;

		// Token: 0x0400E0BC RID: 57532
		private int opl_p3;
	}
}
