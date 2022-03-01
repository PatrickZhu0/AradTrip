using System;

namespace behaviac
{
	// Token: 0x020034DE RID: 13534
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node20 : Condition
	{
		// Token: 0x06015201 RID: 86529 RVA: 0x0065DAAE File Offset: 0x0065BEAE
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node20()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521773;
		}

		// Token: 0x06015202 RID: 86530 RVA: 0x0065DAD0 File Offset: 0x0065BED0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB17 RID: 60183
		private BE_Target opl_p0;

		// Token: 0x0400EB18 RID: 60184
		private BE_Equal opl_p1;

		// Token: 0x0400EB19 RID: 60185
		private int opl_p2;
	}
}
