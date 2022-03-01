using System;

namespace behaviac
{
	// Token: 0x02002F4E RID: 12110
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node20 : Condition
	{
		// Token: 0x0601476C RID: 83820 RVA: 0x00628295 File Offset: 0x00626695
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node20()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601476D RID: 83821 RVA: 0x006282A8 File Offset: 0x006266A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0DD RID: 57565
		private float opl_p0;
	}
}
