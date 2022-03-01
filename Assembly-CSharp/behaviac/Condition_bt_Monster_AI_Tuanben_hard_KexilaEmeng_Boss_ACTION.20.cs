using System;

namespace behaviac
{
	// Token: 0x02003BA6 RID: 15270
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node6 : Condition
	{
		// Token: 0x06015EFC RID: 89852 RVA: 0x006A08FE File Offset: 0x0069ECFE
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node6()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06015EFD RID: 89853 RVA: 0x006A0910 File Offset: 0x0069ED10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 2;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7A3 RID: 63395
		private int opl_p0;
	}
}
