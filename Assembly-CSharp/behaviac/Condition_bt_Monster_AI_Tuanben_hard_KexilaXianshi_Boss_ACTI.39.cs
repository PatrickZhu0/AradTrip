using System;

namespace behaviac
{
	// Token: 0x02003C9B RID: 15515
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node52 : Condition
	{
		// Token: 0x060160DD RID: 90333 RVA: 0x006A9E05 File Offset: 0x006A8205
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node52()
		{
			this.opl_p0 = 21063;
		}

		// Token: 0x060160DE RID: 90334 RVA: 0x006A9E18 File Offset: 0x006A8218
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F97D RID: 63869
		private int opl_p0;
	}
}
