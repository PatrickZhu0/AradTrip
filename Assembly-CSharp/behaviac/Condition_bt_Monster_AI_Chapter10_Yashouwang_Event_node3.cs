using System;

namespace behaviac
{
	// Token: 0x0200314B RID: 12619
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Yashouwang_Event_node3 : Condition
	{
		// Token: 0x06014B38 RID: 84792 RVA: 0x0063C073 File Offset: 0x0063A473
		public Condition_bt_Monster_AI_Chapter10_Yashouwang_Event_node3()
		{
			this.opl_p0 = 20680;
		}

		// Token: 0x06014B39 RID: 84793 RVA: 0x0063C088 File Offset: 0x0063A488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4B1 RID: 58545
		private int opl_p0;
	}
}
