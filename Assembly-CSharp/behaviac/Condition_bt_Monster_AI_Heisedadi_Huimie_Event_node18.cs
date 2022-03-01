using System;

namespace behaviac
{
	// Token: 0x0200343A RID: 13370
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node18 : Condition
	{
		// Token: 0x060150C2 RID: 86210 RVA: 0x006572D0 File Offset: 0x006556D0
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node18()
		{
			this.opl_p0 = 30960011;
		}

		// Token: 0x060150C3 RID: 86211 RVA: 0x006572E4 File Offset: 0x006556E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E993 RID: 59795
		private int opl_p0;
	}
}
