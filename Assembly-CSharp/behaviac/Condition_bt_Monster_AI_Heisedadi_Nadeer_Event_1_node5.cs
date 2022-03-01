using System;

namespace behaviac
{
	// Token: 0x020034EB RID: 13547
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node5 : Condition
	{
		// Token: 0x06015219 RID: 86553 RVA: 0x0065E5E9 File Offset: 0x0065C9E9
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node5()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521746;
		}

		// Token: 0x0601521A RID: 86554 RVA: 0x0065E60C File Offset: 0x0065CA0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB32 RID: 60210
		private BE_Target opl_p0;

		// Token: 0x0400EB33 RID: 60211
		private BE_Equal opl_p1;

		// Token: 0x0400EB34 RID: 60212
		private int opl_p2;
	}
}
