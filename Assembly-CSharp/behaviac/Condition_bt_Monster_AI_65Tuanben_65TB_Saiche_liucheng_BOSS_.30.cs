using System;

namespace behaviac
{
	// Token: 0x02002C26 RID: 11302
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node32 : Condition
	{
		// Token: 0x0601414B RID: 82251 RVA: 0x006065CB File Offset: 0x006049CB
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node32()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x0601414C RID: 82252 RVA: 0x006065DC File Offset: 0x006049DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 75000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB1C RID: 56092
		private int opl_p0;
	}
}
