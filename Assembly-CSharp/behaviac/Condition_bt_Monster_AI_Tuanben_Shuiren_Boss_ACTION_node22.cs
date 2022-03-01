using System;

namespace behaviac
{
	// Token: 0x02003B60 RID: 15200
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node22 : Condition
	{
		// Token: 0x06015E75 RID: 89717 RVA: 0x0069DCEB File Offset: 0x0069C0EB
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node22()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015E76 RID: 89718 RVA: 0x0069DCFC File Offset: 0x0069C0FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F73F RID: 63295
		private int opl_p0;
	}
}
