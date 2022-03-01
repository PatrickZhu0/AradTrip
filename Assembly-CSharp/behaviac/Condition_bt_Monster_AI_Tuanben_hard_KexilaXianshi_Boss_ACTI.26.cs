using System;

namespace behaviac
{
	// Token: 0x02003C89 RID: 15497
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node46 : Condition
	{
		// Token: 0x060160B9 RID: 90297 RVA: 0x006A95C9 File Offset: 0x006A79C9
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node46()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x060160BA RID: 90298 RVA: 0x006A95DC File Offset: 0x006A79DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F951 RID: 63825
		private int opl_p0;
	}
}
