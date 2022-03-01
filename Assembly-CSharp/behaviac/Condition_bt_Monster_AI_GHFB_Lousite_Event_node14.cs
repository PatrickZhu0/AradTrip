using System;

namespace behaviac
{
	// Token: 0x020032CF RID: 13007
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_Lousite_Event_node14 : Condition
	{
		// Token: 0x06014E0F RID: 85519 RVA: 0x0064A2EC File Offset: 0x006486EC
		public Condition_bt_Monster_AI_GHFB_Lousite_Event_node14()
		{
			this.opl_p0 = 20180;
		}

		// Token: 0x06014E10 RID: 85520 RVA: 0x0064A300 File Offset: 0x00648700
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6F2 RID: 59122
		private int opl_p0;
	}
}
