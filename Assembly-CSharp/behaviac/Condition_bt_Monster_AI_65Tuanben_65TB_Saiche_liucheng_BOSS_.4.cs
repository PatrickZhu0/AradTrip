using System;

namespace behaviac
{
	// Token: 0x02002BD8 RID: 11224
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node44 : Condition
	{
		// Token: 0x060140AF RID: 82095 RVA: 0x00604F8D File Offset: 0x0060338D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node44()
		{
			this.opl_p0 = 21834;
		}

		// Token: 0x060140B0 RID: 82096 RVA: 0x00604FA0 File Offset: 0x006033A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA98 RID: 55960
		private int opl_p0;
	}
}
