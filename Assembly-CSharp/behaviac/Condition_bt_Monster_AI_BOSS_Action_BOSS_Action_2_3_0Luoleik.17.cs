using System;

namespace behaviac
{
	// Token: 0x02002F67 RID: 12135
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node30 : Condition
	{
		// Token: 0x0601479D RID: 83869 RVA: 0x00629219 File Offset: 0x00627619
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node30()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601479E RID: 83870 RVA: 0x0062922C File Offset: 0x0062762C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E10D RID: 57613
		private float opl_p0;
	}
}
