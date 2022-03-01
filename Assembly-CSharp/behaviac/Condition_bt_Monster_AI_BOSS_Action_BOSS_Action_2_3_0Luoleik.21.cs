using System;

namespace behaviac
{
	// Token: 0x02002F6C RID: 12140
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node36 : Condition
	{
		// Token: 0x060147A7 RID: 83879 RVA: 0x00629413 File Offset: 0x00627813
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node36()
		{
			this.opl_p0 = 5051;
		}

		// Token: 0x060147A8 RID: 83880 RVA: 0x00629428 File Offset: 0x00627828
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E116 RID: 57622
		private int opl_p0;
	}
}
