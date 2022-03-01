using System;

namespace behaviac
{
	// Token: 0x02002F5A RID: 12122
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node14 : Condition
	{
		// Token: 0x06014783 RID: 83843 RVA: 0x00628C82 File Offset: 0x00627082
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node14()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014784 RID: 83844 RVA: 0x00628CB8 File Offset: 0x006270B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0F1 RID: 57585
		private int opl_p0;

		// Token: 0x0400E0F2 RID: 57586
		private int opl_p1;

		// Token: 0x0400E0F3 RID: 57587
		private int opl_p2;

		// Token: 0x0400E0F4 RID: 57588
		private int opl_p3;
	}
}
