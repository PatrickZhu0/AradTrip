using System;

namespace behaviac
{
	// Token: 0x02002D6E RID: 11630
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node38 : Condition
	{
		// Token: 0x060143BE RID: 82878 RVA: 0x00614127 File Offset: 0x00612527
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node38()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570280;
		}

		// Token: 0x060143BF RID: 82879 RVA: 0x00614148 File Offset: 0x00612548
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD86 RID: 56710
		private BE_Target opl_p0;

		// Token: 0x0400DD87 RID: 56711
		private BE_Equal opl_p1;

		// Token: 0x0400DD88 RID: 56712
		private int opl_p2;
	}
}
