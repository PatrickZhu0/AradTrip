using System;

namespace behaviac
{
	// Token: 0x02002BEB RID: 11243
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node7 : Condition
	{
		// Token: 0x060140D5 RID: 82133 RVA: 0x006054F5 File Offset: 0x006038F5
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522200;
		}

		// Token: 0x060140D6 RID: 82134 RVA: 0x00605518 File Offset: 0x00603918
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAB4 RID: 55988
		private BE_Target opl_p0;

		// Token: 0x0400DAB5 RID: 55989
		private BE_Equal opl_p1;

		// Token: 0x0400DAB6 RID: 55990
		private int opl_p2;
	}
}
