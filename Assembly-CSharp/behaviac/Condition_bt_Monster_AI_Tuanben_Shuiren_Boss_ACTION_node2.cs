using System;

namespace behaviac
{
	// Token: 0x02003B61 RID: 15201
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node2 : Condition
	{
		// Token: 0x06015E77 RID: 89719 RVA: 0x0069DD2F File Offset: 0x0069C12F
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node2()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06015E78 RID: 89720 RVA: 0x0069DD40 File Offset: 0x0069C140
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 5;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F740 RID: 63296
		private int opl_p0;
	}
}
