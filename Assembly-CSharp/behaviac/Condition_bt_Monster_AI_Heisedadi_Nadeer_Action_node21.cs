using System;

namespace behaviac
{
	// Token: 0x020034DA RID: 13530
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node21 : Condition
	{
		// Token: 0x060151F9 RID: 86521 RVA: 0x0065D8E2 File Offset: 0x0065BCE2
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node21()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521773;
		}

		// Token: 0x060151FA RID: 86522 RVA: 0x0065D904 File Offset: 0x0065BD04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB0D RID: 60173
		private BE_Target opl_p0;

		// Token: 0x0400EB0E RID: 60174
		private BE_Equal opl_p1;

		// Token: 0x0400EB0F RID: 60175
		private int opl_p2;
	}
}
