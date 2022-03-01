using System;

namespace behaviac
{
	// Token: 0x02003BAA RID: 15274
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node35 : Condition
	{
		// Token: 0x06015F04 RID: 89860 RVA: 0x006A0A9B File Offset: 0x0069EE9B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node35()
		{
			this.opl_p0 = 21076;
		}

		// Token: 0x06015F05 RID: 89861 RVA: 0x006A0AB0 File Offset: 0x0069EEB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7AA RID: 63402
		private int opl_p0;
	}
}
