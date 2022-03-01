using System;

namespace behaviac
{
	// Token: 0x02003B52 RID: 15186
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node57 : Condition
	{
		// Token: 0x06015E59 RID: 89689 RVA: 0x0069D883 File Offset: 0x0069BC83
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node57()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015E5A RID: 89690 RVA: 0x0069D894 File Offset: 0x0069BC94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 2;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F727 RID: 63271
		private int opl_p0;
	}
}
