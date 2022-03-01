using System;

namespace behaviac
{
	// Token: 0x02002F68 RID: 12136
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node31 : Condition
	{
		// Token: 0x0601479F RID: 83871 RVA: 0x0062925F File Offset: 0x0062765F
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node31()
		{
			this.opl_p0 = 5050;
		}

		// Token: 0x060147A0 RID: 83872 RVA: 0x00629274 File Offset: 0x00627674
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E10E RID: 57614
		private int opl_p0;
	}
}
