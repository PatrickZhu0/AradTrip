using System;

namespace behaviac
{
	// Token: 0x02003A54 RID: 14932
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node45 : Condition
	{
		// Token: 0x06015C71 RID: 89201 RVA: 0x00693C75 File Offset: 0x00692075
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node45()
		{
			this.opl_p0 = 21060;
		}

		// Token: 0x06015C72 RID: 89202 RVA: 0x00693C88 File Offset: 0x00692088
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F59C RID: 62876
		private int opl_p0;
	}
}
