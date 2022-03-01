using System;

namespace behaviac
{
	// Token: 0x02003B8A RID: 15242
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node57 : Condition
	{
		// Token: 0x06015EC4 RID: 89796 RVA: 0x0069FF6D File Offset: 0x0069E36D
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node57()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015EC5 RID: 89797 RVA: 0x0069FF7C File Offset: 0x0069E37C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F783 RID: 63363
		private int opl_p0;
	}
}
