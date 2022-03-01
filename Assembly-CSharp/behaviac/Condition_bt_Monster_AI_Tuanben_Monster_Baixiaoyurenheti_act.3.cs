using System;

namespace behaviac
{
	// Token: 0x02003AE6 RID: 15078
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node11 : Condition
	{
		// Token: 0x06015D8A RID: 89482 RVA: 0x00699EC1 File Offset: 0x006982C1
		public Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node11()
		{
			this.opl_p0 = 21302;
		}

		// Token: 0x06015D8B RID: 89483 RVA: 0x00699ED4 File Offset: 0x006982D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F693 RID: 63123
		private int opl_p0;
	}
}
