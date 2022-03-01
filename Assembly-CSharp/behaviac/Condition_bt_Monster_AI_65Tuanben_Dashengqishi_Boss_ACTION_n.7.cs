using System;

namespace behaviac
{
	// Token: 0x02002D91 RID: 11665
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node42 : Condition
	{
		// Token: 0x06014403 RID: 82947 RVA: 0x006158A2 File Offset: 0x00613CA2
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node42()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06014404 RID: 82948 RVA: 0x006158B4 File Offset: 0x00613CB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDCD RID: 56781
		private int opl_p0;
	}
}
