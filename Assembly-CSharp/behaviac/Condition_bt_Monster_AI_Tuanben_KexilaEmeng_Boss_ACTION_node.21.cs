using System;

namespace behaviac
{
	// Token: 0x020039F2 RID: 14834
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node23 : Condition
	{
		// Token: 0x06015BB4 RID: 89012 RVA: 0x0068FD71 File Offset: 0x0068E171
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node23()
		{
			this.opl_p0 = 21058;
		}

		// Token: 0x06015BB5 RID: 89013 RVA: 0x0068FD84 File Offset: 0x0068E184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4EB RID: 62699
		private int opl_p0;
	}
}
