using System;

namespace behaviac
{
	// Token: 0x02002F8D RID: 12173
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node34 : Condition
	{
		// Token: 0x060147E8 RID: 83944 RVA: 0x0062A976 File Offset: 0x00628D76
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node34()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060147E9 RID: 83945 RVA: 0x0062A9AC File Offset: 0x00628DAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E14D RID: 57677
		private int opl_p0;

		// Token: 0x0400E14E RID: 57678
		private int opl_p1;

		// Token: 0x0400E14F RID: 57679
		private int opl_p2;

		// Token: 0x0400E150 RID: 57680
		private int opl_p3;
	}
}
