using System;

namespace behaviac
{
	// Token: 0x020034D8 RID: 13528
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node10 : Condition
	{
		// Token: 0x060151F5 RID: 86517 RVA: 0x0065D7F1 File Offset: 0x0065BBF1
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node10()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060151F6 RID: 86518 RVA: 0x0065D804 File Offset: 0x0065BC04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB0A RID: 60170
		private float opl_p0;
	}
}
