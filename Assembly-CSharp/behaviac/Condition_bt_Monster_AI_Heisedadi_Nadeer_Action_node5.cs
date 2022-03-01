using System;

namespace behaviac
{
	// Token: 0x020034D1 RID: 13521
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node5 : Condition
	{
		// Token: 0x060151E7 RID: 86503 RVA: 0x0065D4B5 File Offset: 0x0065B8B5
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060151E8 RID: 86504 RVA: 0x0065D4C8 File Offset: 0x0065B8C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAF9 RID: 60153
		private float opl_p0;
	}
}
