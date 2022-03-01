using System;

namespace behaviac
{
	// Token: 0x02003D52 RID: 15698
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node9 : Condition
	{
		// Token: 0x0601623A RID: 90682 RVA: 0x006B0E62 File Offset: 0x006AF262
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node9()
		{
			this.opl_p0 = 2;
		}

		// Token: 0x0601623B RID: 90683 RVA: 0x006B0E74 File Offset: 0x006AF274
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 7;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA9B RID: 64155
		private int opl_p0;
	}
}
