using System;

namespace behaviac
{
	// Token: 0x02002F5B RID: 12123
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node15 : Condition
	{
		// Token: 0x06014785 RID: 83845 RVA: 0x00628CFD File Offset: 0x006270FD
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node15()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014786 RID: 83846 RVA: 0x00628D10 File Offset: 0x00627110
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0F5 RID: 57589
		private float opl_p0;
	}
}
