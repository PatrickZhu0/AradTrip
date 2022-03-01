using System;

namespace behaviac
{
	// Token: 0x02003146 RID: 12614
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node22 : Condition
	{
		// Token: 0x06014B2F RID: 84783 RVA: 0x0063B903 File Offset: 0x00639D03
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node22()
		{
			this.opl_p0 = 20620;
		}

		// Token: 0x06014B30 RID: 84784 RVA: 0x0063B918 File Offset: 0x00639D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4A8 RID: 58536
		private int opl_p0;
	}
}
