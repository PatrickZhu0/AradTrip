using System;

namespace behaviac
{
	// Token: 0x020034BE RID: 13502
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node44 : Condition
	{
		// Token: 0x060151C2 RID: 86466 RVA: 0x0065C3FE File Offset: 0x0065A7FE
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node44()
		{
			this.opl_p0 = 6204;
		}

		// Token: 0x060151C3 RID: 86467 RVA: 0x0065C414 File Offset: 0x0065A814
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EACB RID: 60107
		private int opl_p0;
	}
}
