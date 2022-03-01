using System;

namespace behaviac
{
	// Token: 0x02002BDB RID: 11227
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node36 : Condition
	{
		// Token: 0x060140B5 RID: 82101 RVA: 0x00605090 File Offset: 0x00603490
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node36()
		{
			this.opl_p0 = 21835;
		}

		// Token: 0x060140B6 RID: 82102 RVA: 0x006050A4 File Offset: 0x006034A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA9B RID: 55963
		private int opl_p0;
	}
}
