using System;

namespace behaviac
{
	// Token: 0x02002C22 RID: 11298
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node30 : Condition
	{
		// Token: 0x06014143 RID: 82243 RVA: 0x006064CF File Offset: 0x006048CF
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node30()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06014144 RID: 82244 RVA: 0x006064E0 File Offset: 0x006048E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 40000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB16 RID: 56086
		private int opl_p0;
	}
}
