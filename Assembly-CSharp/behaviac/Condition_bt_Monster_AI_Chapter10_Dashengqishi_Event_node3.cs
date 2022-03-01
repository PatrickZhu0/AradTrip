using System;

namespace behaviac
{
	// Token: 0x020030E9 RID: 12521
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3 : Condition
	{
		// Token: 0x06014A85 RID: 84613 RVA: 0x006386BB File Offset: 0x00636ABB
		public Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node3()
		{
			this.opl_p0 = 20705;
		}

		// Token: 0x06014A86 RID: 84614 RVA: 0x006386D0 File Offset: 0x00636AD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3F5 RID: 58357
		private int opl_p0;
	}
}
