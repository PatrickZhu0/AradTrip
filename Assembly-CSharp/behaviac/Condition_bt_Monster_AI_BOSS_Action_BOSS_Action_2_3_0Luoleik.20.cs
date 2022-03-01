using System;

namespace behaviac
{
	// Token: 0x02002F6B RID: 12139
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node35 : Condition
	{
		// Token: 0x060147A5 RID: 83877 RVA: 0x006293CD File Offset: 0x006277CD
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node35()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060147A6 RID: 83878 RVA: 0x006293E0 File Offset: 0x006277E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E115 RID: 57621
		private float opl_p0;
	}
}
