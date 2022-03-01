using System;

namespace behaviac
{
	// Token: 0x02003A15 RID: 14869
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node17 : Condition
	{
		// Token: 0x06015BF5 RID: 89077 RVA: 0x00691A75 File Offset: 0x0068FE75
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node17()
		{
			this.opl_p0 = 21407;
		}

		// Token: 0x06015BF6 RID: 89078 RVA: 0x00691A88 File Offset: 0x0068FE88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F510 RID: 62736
		private int opl_p0;
	}
}
