using System;

namespace behaviac
{
	// Token: 0x02003C9E RID: 15518
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node49 : Condition
	{
		// Token: 0x060160E3 RID: 90339 RVA: 0x006A9F71 File Offset: 0x006A8371
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node49()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x060160E4 RID: 90340 RVA: 0x006A9F84 File Offset: 0x006A8384
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F984 RID: 63876
		private int opl_p0;
	}
}
