using System;

namespace behaviac
{
	// Token: 0x02002C1B RID: 11291
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node18 : Condition
	{
		// Token: 0x06014135 RID: 82229 RVA: 0x006062E7 File Offset: 0x006046E7
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node18()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06014136 RID: 82230 RVA: 0x006062F8 File Offset: 0x006046F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB05 RID: 56069
		private int opl_p0;
	}
}
