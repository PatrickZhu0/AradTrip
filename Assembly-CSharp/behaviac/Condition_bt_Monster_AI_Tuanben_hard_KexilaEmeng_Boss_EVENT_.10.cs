using System;

namespace behaviac
{
	// Token: 0x02003BDC RID: 15324
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node69 : Condition
	{
		// Token: 0x06015F65 RID: 89957 RVA: 0x006A2D01 File Offset: 0x006A1101
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node69()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015F66 RID: 89958 RVA: 0x006A2D10 File Offset: 0x006A1110
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F801 RID: 63489
		private int opl_p0;
	}
}
