using System;

namespace behaviac
{
	// Token: 0x02003C3C RID: 15420
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node35 : Condition
	{
		// Token: 0x06016022 RID: 90146 RVA: 0x006A699A File Offset: 0x006A4D9A
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node35()
		{
			this.opl_p0 = 21066;
		}

		// Token: 0x06016023 RID: 90147 RVA: 0x006A69B0 File Offset: 0x006A4DB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F899 RID: 63641
		private int opl_p0;
	}
}
