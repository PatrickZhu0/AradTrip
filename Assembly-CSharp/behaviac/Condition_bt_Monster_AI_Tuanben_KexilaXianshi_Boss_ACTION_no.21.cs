using System;

namespace behaviac
{
	// Token: 0x02003A50 RID: 14928
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node4 : Condition
	{
		// Token: 0x06015C69 RID: 89193 RVA: 0x00693AA7 File Offset: 0x00691EA7
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node4()
		{
			this.opl_p0 = 21054;
		}

		// Token: 0x06015C6A RID: 89194 RVA: 0x00693ABC File Offset: 0x00691EBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F592 RID: 62866
		private int opl_p0;
	}
}
