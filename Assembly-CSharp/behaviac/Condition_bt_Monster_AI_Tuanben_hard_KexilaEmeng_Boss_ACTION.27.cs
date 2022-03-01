using System;

namespace behaviac
{
	// Token: 0x02003BB3 RID: 15283
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node20 : Condition
	{
		// Token: 0x06015F16 RID: 89878 RVA: 0x006A0DEE File Offset: 0x0069F1EE
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node20()
		{
			this.opl_p0 = 21071;
		}

		// Token: 0x06015F17 RID: 89879 RVA: 0x006A0E04 File Offset: 0x0069F204
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7B4 RID: 63412
		private int opl_p0;
	}
}
