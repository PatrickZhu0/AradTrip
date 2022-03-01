using System;

namespace behaviac
{
	// Token: 0x02003141 RID: 12609
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node17 : Condition
	{
		// Token: 0x06014B25 RID: 84773 RVA: 0x0063B713 File Offset: 0x00639B13
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node17()
		{
			this.opl_p0 = 20618;
		}

		// Token: 0x06014B26 RID: 84774 RVA: 0x0063B728 File Offset: 0x00639B28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E49F RID: 58527
		private int opl_p0;
	}
}
