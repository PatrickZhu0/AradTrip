using System;

namespace behaviac
{
	// Token: 0x02003AE7 RID: 15079
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node12 : Condition
	{
		// Token: 0x06015D8C RID: 89484 RVA: 0x00699F07 File Offset: 0x00698307
		public Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node12()
		{
			this.opl_p0 = 21302;
		}

		// Token: 0x06015D8D RID: 89485 RVA: 0x00699F1C File Offset: 0x0069831C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F694 RID: 63124
		private int opl_p0;
	}
}
