using System;

namespace behaviac
{
	// Token: 0x020034E4 RID: 13540
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node26 : Condition
	{
		// Token: 0x0601520D RID: 86541 RVA: 0x0065DD55 File Offset: 0x0065C155
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node26()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601520E RID: 86542 RVA: 0x0065DD68 File Offset: 0x0065C168
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB28 RID: 60200
		private float opl_p0;
	}
}
