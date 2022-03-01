using System;

namespace behaviac
{
	// Token: 0x02003C94 RID: 15508
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node51 : Condition
	{
		// Token: 0x060160CF RID: 90319 RVA: 0x006A9ACD File Offset: 0x006A7ECD
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node51()
		{
			this.opl_p0 = 21062;
		}

		// Token: 0x060160D0 RID: 90320 RVA: 0x006A9AE0 File Offset: 0x006A7EE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F96C RID: 63852
		private int opl_p0;
	}
}
