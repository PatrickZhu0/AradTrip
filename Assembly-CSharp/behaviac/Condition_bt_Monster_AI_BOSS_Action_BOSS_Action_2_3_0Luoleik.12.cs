using System;

namespace behaviac
{
	// Token: 0x02002F60 RID: 12128
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node21 : Condition
	{
		// Token: 0x0601478F RID: 83855 RVA: 0x00628EF7 File Offset: 0x006272F7
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node21()
		{
			this.opl_p0 = 5051;
		}

		// Token: 0x06014790 RID: 83856 RVA: 0x00628F0C File Offset: 0x0062730C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0FE RID: 57598
		private int opl_p0;
	}
}
