using System;

namespace behaviac
{
	// Token: 0x020034D4 RID: 13524
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node6 : Condition
	{
		// Token: 0x060151ED RID: 86509 RVA: 0x0065D621 File Offset: 0x0065BA21
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node6()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060151EE RID: 86510 RVA: 0x0065D634 File Offset: 0x0065BA34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB00 RID: 60160
		private float opl_p0;
	}
}
