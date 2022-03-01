using System;

namespace behaviac
{
	// Token: 0x020034BD RID: 13501
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node45 : Condition
	{
		// Token: 0x060151C0 RID: 86464 RVA: 0x0065C3B2 File Offset: 0x0065A7B2
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node45()
		{
			this.opl_p0 = 6204;
		}

		// Token: 0x060151C1 RID: 86465 RVA: 0x0065C3C8 File Offset: 0x0065A7C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EACA RID: 60106
		private int opl_p0;
	}
}
