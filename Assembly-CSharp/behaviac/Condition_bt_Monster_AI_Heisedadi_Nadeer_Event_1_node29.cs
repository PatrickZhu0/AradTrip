using System;

namespace behaviac
{
	// Token: 0x020034FA RID: 13562
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node29 : Condition
	{
		// Token: 0x06015237 RID: 86583 RVA: 0x0065EB11 File Offset: 0x0065CF11
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node29()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521748;
		}

		// Token: 0x06015238 RID: 86584 RVA: 0x0065EB34 File Offset: 0x0065CF34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB67 RID: 60263
		private BE_Target opl_p0;

		// Token: 0x0400EB68 RID: 60264
		private BE_Equal opl_p1;

		// Token: 0x0400EB69 RID: 60265
		private int opl_p2;
	}
}
