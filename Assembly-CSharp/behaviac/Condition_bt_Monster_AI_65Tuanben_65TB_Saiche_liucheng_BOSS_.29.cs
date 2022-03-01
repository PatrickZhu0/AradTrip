using System;

namespace behaviac
{
	// Token: 0x02002C25 RID: 11301
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node35 : Condition
	{
		// Token: 0x06014149 RID: 82249 RVA: 0x00606588 File Offset: 0x00604988
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node35()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x0601414A RID: 82250 RVA: 0x00606598 File Offset: 0x00604998
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 2;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB1B RID: 56091
		private int opl_p0;
	}
}
