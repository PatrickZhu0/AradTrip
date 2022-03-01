using System;

namespace behaviac
{
	// Token: 0x020034B9 RID: 13497
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node30 : Condition
	{
		// Token: 0x060151B8 RID: 86456 RVA: 0x0065C256 File Offset: 0x0065A656
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node30()
		{
			this.opl_p0 = 6204;
		}

		// Token: 0x060151B9 RID: 86457 RVA: 0x0065C26C File Offset: 0x0065A66C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAC0 RID: 60096
		private int opl_p0;
	}
}
