using System;

namespace behaviac
{
	// Token: 0x02003B9E RID: 15262
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node26 : Condition
	{
		// Token: 0x06015EEC RID: 89836 RVA: 0x006A05E7 File Offset: 0x0069E9E7
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node26()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015EED RID: 89837 RVA: 0x006A05F8 File Offset: 0x0069E9F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F797 RID: 63383
		private int opl_p0;
	}
}
