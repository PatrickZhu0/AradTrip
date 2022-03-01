using System;

namespace behaviac
{
	// Token: 0x020039DB RID: 14811
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node37 : Condition
	{
		// Token: 0x06015B86 RID: 88966 RVA: 0x0068F4A6 File Offset: 0x0068D8A6
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node37()
		{
			this.opl_p0 = 2;
		}

		// Token: 0x06015B87 RID: 88967 RVA: 0x0068F4B8 File Offset: 0x0068D8B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4CC RID: 62668
		private int opl_p0;
	}
}
