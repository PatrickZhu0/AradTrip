using System;

namespace behaviac
{
	// Token: 0x02002C21 RID: 11297
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node10 : Condition
	{
		// Token: 0x06014141 RID: 82241 RVA: 0x0060648C File Offset: 0x0060488C
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node10()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06014142 RID: 82242 RVA: 0x0060649C File Offset: 0x0060489C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB15 RID: 56085
		private int opl_p0;
	}
}
