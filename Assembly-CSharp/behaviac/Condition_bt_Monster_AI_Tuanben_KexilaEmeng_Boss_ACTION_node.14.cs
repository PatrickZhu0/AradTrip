using System;

namespace behaviac
{
	// Token: 0x020039E3 RID: 14819
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node6 : Condition
	{
		// Token: 0x06015B96 RID: 88982 RVA: 0x0068F7BE File Offset: 0x0068DBBE
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node6()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06015B97 RID: 88983 RVA: 0x0068F7D0 File Offset: 0x0068DBD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 2;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4D8 RID: 62680
		private int opl_p0;
	}
}
