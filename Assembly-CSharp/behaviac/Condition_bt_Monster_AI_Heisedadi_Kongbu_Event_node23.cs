using System;

namespace behaviac
{
	// Token: 0x020034BC RID: 13500
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node23 : Condition
	{
		// Token: 0x060151BE RID: 86462 RVA: 0x0065C369 File Offset: 0x0065A769
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node23()
		{
			this.opl_p0 = 6206;
		}

		// Token: 0x060151BF RID: 86463 RVA: 0x0065C37C File Offset: 0x0065A77C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAC9 RID: 60105
		private int opl_p0;
	}
}
