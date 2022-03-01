using System;

namespace behaviac
{
	// Token: 0x0200310B RID: 12555
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node3 : Condition
	{
		// Token: 0x06014AC1 RID: 84673 RVA: 0x00639A02 File Offset: 0x00637E02
		public Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node3()
		{
			this.opl_p0 = 20721;
		}

		// Token: 0x06014AC2 RID: 84674 RVA: 0x00639A18 File Offset: 0x00637E18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E432 RID: 58418
		private int opl_p0;
	}
}
