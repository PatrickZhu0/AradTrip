using System;

namespace behaviac
{
	// Token: 0x02002BD1 RID: 11217
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node51 : Condition
	{
		// Token: 0x060140A1 RID: 82081 RVA: 0x00604DD1 File Offset: 0x006031D1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node51()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060140A2 RID: 82082 RVA: 0x00604DE0 File Offset: 0x006031E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 8000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA92 RID: 55954
		private int opl_p0;
	}
}
