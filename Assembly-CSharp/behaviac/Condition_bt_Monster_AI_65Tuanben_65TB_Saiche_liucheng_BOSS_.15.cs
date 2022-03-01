using System;

namespace behaviac
{
	// Token: 0x02002BF7 RID: 11255
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node71 : Condition
	{
		// Token: 0x060140ED RID: 82157 RVA: 0x006058B5 File Offset: 0x00603CB5
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node71()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x060140EE RID: 82158 RVA: 0x006058C4 File Offset: 0x00603CC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 15000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DACE RID: 56014
		private int opl_p0;
	}
}
