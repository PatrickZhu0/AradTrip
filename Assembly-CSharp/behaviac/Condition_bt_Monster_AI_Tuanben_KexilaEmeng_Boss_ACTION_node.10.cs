using System;

namespace behaviac
{
	// Token: 0x020039DD RID: 14813
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node5 : Condition
	{
		// Token: 0x06015B8A RID: 88970 RVA: 0x0068F52F File Offset: 0x0068D92F
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node5()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06015B8B RID: 88971 RVA: 0x0068F540 File Offset: 0x0068D940
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4CE RID: 62670
		private int opl_p0;
	}
}
