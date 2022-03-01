using System;

namespace behaviac
{
	// Token: 0x02002BD5 RID: 11221
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node39 : Condition
	{
		// Token: 0x060140A9 RID: 82089 RVA: 0x00604E88 File Offset: 0x00603288
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node39()
		{
			this.opl_p0 = 21833;
		}

		// Token: 0x060140AA RID: 82090 RVA: 0x00604E9C File Offset: 0x0060329C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA95 RID: 55957
		private int opl_p0;
	}
}
