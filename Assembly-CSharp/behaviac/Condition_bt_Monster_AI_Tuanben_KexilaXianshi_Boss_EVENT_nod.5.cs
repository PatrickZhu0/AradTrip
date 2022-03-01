using System;

namespace behaviac
{
	// Token: 0x02003A94 RID: 14996
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node99 : Condition
	{
		// Token: 0x06015CEC RID: 89324 RVA: 0x00696C51 File Offset: 0x00695051
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node99()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015CED RID: 89325 RVA: 0x00696C60 File Offset: 0x00695060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F623 RID: 63011
		private int opl_p0;
	}
}
