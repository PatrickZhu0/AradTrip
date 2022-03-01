using System;

namespace behaviac
{
	// Token: 0x02003104 RID: 12548
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Gangban_Shu_Event_node5 : Condition
	{
		// Token: 0x06014AB4 RID: 84660 RVA: 0x00639663 File Offset: 0x00637A63
		public Condition_bt_Monster_AI_Chapter10_Gangban_Shu_Event_node5()
		{
			this.opl_p0 = 20723;
		}

		// Token: 0x06014AB5 RID: 84661 RVA: 0x00639678 File Offset: 0x00637A78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E428 RID: 58408
		private int opl_p0;
	}
}
