using System;

namespace behaviac
{
	// Token: 0x020034C4 RID: 13508
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node47 : Condition
	{
		// Token: 0x060151CE RID: 86478 RVA: 0x0065C5F5 File Offset: 0x0065A9F5
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node47()
		{
			this.opl_p0 = 6204;
		}

		// Token: 0x060151CF RID: 86479 RVA: 0x0065C608 File Offset: 0x0065AA08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EADA RID: 60122
		private int opl_p0;
	}
}
