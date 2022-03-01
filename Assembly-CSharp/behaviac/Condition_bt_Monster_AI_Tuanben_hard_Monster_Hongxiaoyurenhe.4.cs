using System;

namespace behaviac
{
	// Token: 0x02003D18 RID: 15640
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node12 : Condition
	{
		// Token: 0x060161CC RID: 90572 RVA: 0x006AF433 File Offset: 0x006AD833
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node12()
		{
			this.opl_p0 = 21301;
		}

		// Token: 0x060161CD RID: 90573 RVA: 0x006AF448 File Offset: 0x006AD848
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA51 RID: 64081
		private int opl_p0;
	}
}
