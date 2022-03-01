using System;

namespace behaviac
{
	// Token: 0x02003A6C RID: 14956
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node49 : Condition
	{
		// Token: 0x06015CA1 RID: 89249 RVA: 0x00694789 File Offset: 0x00692B89
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node49()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x06015CA2 RID: 89250 RVA: 0x0069479C File Offset: 0x00692B9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5D6 RID: 62934
		private int opl_p0;
	}
}
