using System;

namespace behaviac
{
	// Token: 0x020032D4 RID: 13012
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_Lousite_Event_node7 : Condition
	{
		// Token: 0x06014E19 RID: 85529 RVA: 0x0064A53E File Offset: 0x0064893E
		public Condition_bt_Monster_AI_GHFB_Lousite_Event_node7()
		{
			this.opl_p0 = 20173;
		}

		// Token: 0x06014E1A RID: 85530 RVA: 0x0064A554 File Offset: 0x00648954
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6F9 RID: 59129
		private int opl_p0;
	}
}
