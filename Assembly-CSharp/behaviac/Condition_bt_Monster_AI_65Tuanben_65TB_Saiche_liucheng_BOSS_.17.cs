using System;

namespace behaviac
{
	// Token: 0x02002BFD RID: 11261
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node81 : Condition
	{
		// Token: 0x060140F9 RID: 82169 RVA: 0x00605A15 File Offset: 0x00603E15
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node81()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522200;
		}

		// Token: 0x060140FA RID: 82170 RVA: 0x00605A38 File Offset: 0x00603E38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAD6 RID: 56022
		private BE_Target opl_p0;

		// Token: 0x0400DAD7 RID: 56023
		private BE_Equal opl_p1;

		// Token: 0x0400DAD8 RID: 56024
		private int opl_p2;
	}
}
