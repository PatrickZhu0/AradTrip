using System;

namespace behaviac
{
	// Token: 0x02003B8B RID: 15243
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node50 : Condition
	{
		// Token: 0x06015EC6 RID: 89798 RVA: 0x0069FFAF File Offset: 0x0069E3AF
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node50()
		{
			this.opl_p0 = 21069;
		}

		// Token: 0x06015EC7 RID: 89799 RVA: 0x0069FFC4 File Offset: 0x0069E3C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F784 RID: 63364
		private int opl_p0;
	}
}
