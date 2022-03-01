using System;

namespace behaviac
{
	// Token: 0x0200340F RID: 13327
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node41 : Condition
	{
		// Token: 0x0601506F RID: 86127 RVA: 0x00655B85 File Offset: 0x00653F85
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node41()
		{
			this.opl_p0 = 6218;
		}

		// Token: 0x06015070 RID: 86128 RVA: 0x00655B98 File Offset: 0x00653F98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E948 RID: 59720
		private int opl_p0;
	}
}
