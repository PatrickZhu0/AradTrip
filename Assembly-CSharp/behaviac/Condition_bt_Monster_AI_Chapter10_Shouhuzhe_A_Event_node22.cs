using System;

namespace behaviac
{
	// Token: 0x02003131 RID: 12593
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node22 : Condition
	{
		// Token: 0x06014B07 RID: 84743 RVA: 0x0063AC1F File Offset: 0x0063901F
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node22()
		{
			this.opl_p0 = 20620;
		}

		// Token: 0x06014B08 RID: 84744 RVA: 0x0063AC34 File Offset: 0x00639034
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E47A RID: 58490
		private int opl_p0;
	}
}
