using System;

namespace behaviac
{
	// Token: 0x020032D2 RID: 13010
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_Lousite_Event_node17 : Condition
	{
		// Token: 0x06014E15 RID: 85525 RVA: 0x0064A44C File Offset: 0x0064884C
		public Condition_bt_Monster_AI_GHFB_Lousite_Event_node17()
		{
			this.opl_p0 = 20176;
		}

		// Token: 0x06014E16 RID: 85526 RVA: 0x0064A460 File Offset: 0x00648860
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6F6 RID: 59126
		private int opl_p0;
	}
}
