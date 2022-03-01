using System;

namespace behaviac
{
	// Token: 0x02003A5E RID: 14942
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node47 : Condition
	{
		// Token: 0x06015C85 RID: 89221 RVA: 0x00694119 File Offset: 0x00692519
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node47()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x06015C86 RID: 89222 RVA: 0x0069412C File Offset: 0x0069252C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5B4 RID: 62900
		private int opl_p0;
	}
}
