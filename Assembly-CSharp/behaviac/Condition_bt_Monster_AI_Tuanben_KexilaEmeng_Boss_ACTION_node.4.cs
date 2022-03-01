using System;

namespace behaviac
{
	// Token: 0x020039D4 RID: 14804
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node85 : Condition
	{
		// Token: 0x06015B78 RID: 88952 RVA: 0x0068F203 File Offset: 0x0068D603
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node85()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015B79 RID: 88953 RVA: 0x0068F214 File Offset: 0x0068D614
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4C2 RID: 62658
		private int opl_p0;
	}
}
