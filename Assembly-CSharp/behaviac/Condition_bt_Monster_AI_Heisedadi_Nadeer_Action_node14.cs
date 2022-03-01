using System;

namespace behaviac
{
	// Token: 0x020034DC RID: 13532
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node14 : Condition
	{
		// Token: 0x060151FD RID: 86525 RVA: 0x0065D9BD File Offset: 0x0065BDBD
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node14()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060151FE RID: 86526 RVA: 0x0065D9D0 File Offset: 0x0065BDD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB14 RID: 60180
		private float opl_p0;
	}
}
