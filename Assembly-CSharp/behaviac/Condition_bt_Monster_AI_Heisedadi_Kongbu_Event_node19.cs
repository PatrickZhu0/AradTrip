using System;

namespace behaviac
{
	// Token: 0x020034B8 RID: 13496
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node19 : Condition
	{
		// Token: 0x060151B6 RID: 86454 RVA: 0x0065C20A File Offset: 0x0065A60A
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node19()
		{
			this.opl_p0 = 6206;
		}

		// Token: 0x060151B7 RID: 86455 RVA: 0x0065C220 File Offset: 0x0065A620
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EABF RID: 60095
		private int opl_p0;
	}
}
