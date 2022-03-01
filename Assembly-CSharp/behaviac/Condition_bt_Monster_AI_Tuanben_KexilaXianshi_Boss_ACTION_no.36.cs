using System;

namespace behaviac
{
	// Token: 0x02003A65 RID: 14949
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node48 : Condition
	{
		// Token: 0x06015C93 RID: 89235 RVA: 0x00694451 File Offset: 0x00692851
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node48()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x06015C94 RID: 89236 RVA: 0x00694464 File Offset: 0x00692864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5C5 RID: 62917
		private int opl_p0;
	}
}
