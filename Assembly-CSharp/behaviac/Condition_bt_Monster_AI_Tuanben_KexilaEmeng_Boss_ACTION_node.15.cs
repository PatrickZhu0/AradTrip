using System;

namespace behaviac
{
	// Token: 0x020039E4 RID: 14820
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node7 : Condition
	{
		// Token: 0x06015B98 RID: 88984 RVA: 0x0068F806 File Offset: 0x0068DC06
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node7()
		{
			this.opl_p0 = 21073;
		}

		// Token: 0x06015B99 RID: 88985 RVA: 0x0068F81C File Offset: 0x0068DC1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4D9 RID: 62681
		private int opl_p0;
	}
}
