using System;

namespace behaviac
{
	// Token: 0x02002F46 RID: 12102
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node10 : Condition
	{
		// Token: 0x0601475C RID: 83804 RVA: 0x00627F2D File Offset: 0x0062632D
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node10()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601475D RID: 83805 RVA: 0x00627F40 File Offset: 0x00626340
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0CD RID: 57549
		private float opl_p0;
	}
}
