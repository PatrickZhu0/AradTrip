using System;

namespace behaviac
{
	// Token: 0x020039DE RID: 14814
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node27 : Condition
	{
		// Token: 0x06015B8C RID: 88972 RVA: 0x0068F576 File Offset: 0x0068D976
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node27()
		{
			this.opl_p0 = 21159;
		}

		// Token: 0x06015B8D RID: 88973 RVA: 0x0068F58C File Offset: 0x0068D98C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4CF RID: 62671
		private int opl_p0;
	}
}
