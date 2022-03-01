using System;

namespace behaviac
{
	// Token: 0x02002EC1 RID: 11969
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node84 : Condition
	{
		// Token: 0x0601465C RID: 83548 RVA: 0x0062243F File Offset: 0x0062083F
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node84()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570312;
		}

		// Token: 0x0601465D RID: 83549 RVA: 0x00622460 File Offset: 0x00620860
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFCB RID: 57291
		private BE_Target opl_p0;

		// Token: 0x0400DFCC RID: 57292
		private BE_Equal opl_p1;

		// Token: 0x0400DFCD RID: 57293
		private int opl_p2;
	}
}
