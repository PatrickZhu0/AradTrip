using System;

namespace behaviac
{
	// Token: 0x020039D8 RID: 14808
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node31 : Condition
	{
		// Token: 0x06015B80 RID: 88960 RVA: 0x0068F371 File Offset: 0x0068D771
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node31()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015B81 RID: 88961 RVA: 0x0068F380 File Offset: 0x0068D780
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4C8 RID: 62664
		private int opl_p0;
	}
}
