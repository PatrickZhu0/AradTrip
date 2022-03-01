using System;

namespace behaviac
{
	// Token: 0x02003B62 RID: 15202
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node20 : Condition
	{
		// Token: 0x06015E79 RID: 89721 RVA: 0x0069DD73 File Offset: 0x0069C173
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node20()
		{
			this.opl_p0 = 2;
		}

		// Token: 0x06015E7A RID: 89722 RVA: 0x0069DD84 File Offset: 0x0069C184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 7;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F741 RID: 63297
		private int opl_p0;
	}
}
