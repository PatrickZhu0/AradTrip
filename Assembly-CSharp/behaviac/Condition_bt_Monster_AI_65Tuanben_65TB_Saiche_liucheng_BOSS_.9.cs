using System;

namespace behaviac
{
	// Token: 0x02002BE5 RID: 11237
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node4 : Condition
	{
		// Token: 0x060140C9 RID: 82121 RVA: 0x00605395 File Offset: 0x00603795
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node4()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x060140CA RID: 82122 RVA: 0x006053A4 File Offset: 0x006037A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 15000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAAC RID: 55980
		private int opl_p0;
	}
}
