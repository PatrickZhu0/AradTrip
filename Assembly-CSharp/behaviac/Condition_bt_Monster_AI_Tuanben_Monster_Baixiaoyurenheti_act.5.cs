using System;

namespace behaviac
{
	// Token: 0x02003AE9 RID: 15081
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node3 : Condition
	{
		// Token: 0x06015D90 RID: 89488 RVA: 0x00699FFA File Offset: 0x006983FA
		public Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node3()
		{
			this.opl_p0 = 21021;
		}

		// Token: 0x06015D91 RID: 89489 RVA: 0x0069A010 File Offset: 0x00698410
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F697 RID: 63127
		private int opl_p0;
	}
}
