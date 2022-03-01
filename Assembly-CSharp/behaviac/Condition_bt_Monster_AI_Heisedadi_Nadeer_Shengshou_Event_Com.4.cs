using System;

namespace behaviac
{
	// Token: 0x0200354A RID: 13642
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node11 : Condition
	{
		// Token: 0x060152D5 RID: 86741 RVA: 0x00661E2A File Offset: 0x0066022A
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node11()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521771;
		}

		// Token: 0x060152D6 RID: 86742 RVA: 0x00661E4C File Offset: 0x0066024C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC8B RID: 60555
		private BE_Target opl_p0;

		// Token: 0x0400EC8C RID: 60556
		private BE_Equal opl_p1;

		// Token: 0x0400EC8D RID: 60557
		private int opl_p2;
	}
}
