using System;

namespace behaviac
{
	// Token: 0x020034CD RID: 13517
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node34 : Condition
	{
		// Token: 0x060151E0 RID: 86496 RVA: 0x0065C8F1 File Offset: 0x0065ACF1
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node34()
		{
			this.opl_p0 = 6208;
		}

		// Token: 0x060151E1 RID: 86497 RVA: 0x0065C904 File Offset: 0x0065AD04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAF2 RID: 60146
		private int opl_p0;
	}
}
