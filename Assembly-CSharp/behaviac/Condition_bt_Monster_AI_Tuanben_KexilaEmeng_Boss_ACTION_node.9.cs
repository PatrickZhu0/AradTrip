using System;

namespace behaviac
{
	// Token: 0x020039DC RID: 14812
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node26 : Condition
	{
		// Token: 0x06015B88 RID: 88968 RVA: 0x0068F4EB File Offset: 0x0068D8EB
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node26()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015B89 RID: 88969 RVA: 0x0068F4FC File Offset: 0x0068D8FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4CD RID: 62669
		private int opl_p0;
	}
}
