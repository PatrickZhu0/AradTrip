using System;

namespace behaviac
{
	// Token: 0x0200312C RID: 12588
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node17 : Condition
	{
		// Token: 0x06014AFD RID: 84733 RVA: 0x0063AA2F File Offset: 0x00638E2F
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node17()
		{
			this.opl_p0 = 20618;
		}

		// Token: 0x06014AFE RID: 84734 RVA: 0x0063AA44 File Offset: 0x00638E44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E471 RID: 58481
		private int opl_p0;
	}
}
