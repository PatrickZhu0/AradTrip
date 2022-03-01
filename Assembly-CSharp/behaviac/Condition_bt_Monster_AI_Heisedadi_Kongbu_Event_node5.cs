using System;

namespace behaviac
{
	// Token: 0x020034AE RID: 13486
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node5 : Condition
	{
		// Token: 0x060151A2 RID: 86434 RVA: 0x0065BEE5 File Offset: 0x0065A2E5
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node5()
		{
			this.opl_p0 = 6206;
		}

		// Token: 0x060151A3 RID: 86435 RVA: 0x0065BEF8 File Offset: 0x0065A2F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAA4 RID: 60068
		private int opl_p0;
	}
}
