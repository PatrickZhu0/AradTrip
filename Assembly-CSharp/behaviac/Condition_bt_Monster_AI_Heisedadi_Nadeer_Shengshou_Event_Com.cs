using System;

namespace behaviac
{
	// Token: 0x02003544 RID: 13636
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node0 : Condition
	{
		// Token: 0x060152C9 RID: 86729 RVA: 0x00661C56 File Offset: 0x00660056
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node0()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521768;
		}

		// Token: 0x060152CA RID: 86730 RVA: 0x00661C78 File Offset: 0x00660078
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC7C RID: 60540
		private BE_Target opl_p0;

		// Token: 0x0400EC7D RID: 60541
		private BE_Equal opl_p1;

		// Token: 0x0400EC7E RID: 60542
		private int opl_p2;
	}
}
