using System;

namespace behaviac
{
	// Token: 0x02003CEA RID: 15594
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node108 : Condition
	{
		// Token: 0x06016175 RID: 90485 RVA: 0x006ACE52 File Offset: 0x006AB252
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node108()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06016176 RID: 90486 RVA: 0x006ACE64 File Offset: 0x006AB264
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 4;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA1A RID: 64026
		private int opl_p0;
	}
}
