using System;

namespace behaviac
{
	// Token: 0x02003BEA RID: 15338
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node15 : Condition
	{
		// Token: 0x06015F81 RID: 89985 RVA: 0x006A30D7 File Offset: 0x006A14D7
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node15()
		{
			this.opl_p0 = 21159;
		}

		// Token: 0x06015F82 RID: 89986 RVA: 0x006A30EC File Offset: 0x006A14EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F81B RID: 63515
		private int opl_p0;
	}
}
