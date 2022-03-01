using System;

namespace behaviac
{
	// Token: 0x020034CA RID: 13514
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node36 : Condition
	{
		// Token: 0x060151DA RID: 86490 RVA: 0x0065C7E2 File Offset: 0x0065ABE2
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node36()
		{
			this.opl_p0 = 6208;
		}

		// Token: 0x060151DB RID: 86491 RVA: 0x0065C7F8 File Offset: 0x0065ABF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAE9 RID: 60137
		private int opl_p0;
	}
}
