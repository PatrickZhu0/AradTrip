using System;

namespace behaviac
{
	// Token: 0x020032CC RID: 13004
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_Lousite_Event_node6 : Condition
	{
		// Token: 0x06014E09 RID: 85513 RVA: 0x0064A18C File Offset: 0x0064858C
		public Condition_bt_Monster_AI_GHFB_Lousite_Event_node6()
		{
			this.opl_p0 = 20181;
		}

		// Token: 0x06014E0A RID: 85514 RVA: 0x0064A1A0 File Offset: 0x006485A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6EE RID: 59118
		private int opl_p0;
	}
}
