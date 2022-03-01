using System;

namespace behaviac
{
	// Token: 0x02003C90 RID: 15504
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node47 : Condition
	{
		// Token: 0x060160C7 RID: 90311 RVA: 0x006A9901 File Offset: 0x006A7D01
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node47()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x060160C8 RID: 90312 RVA: 0x006A9914 File Offset: 0x006A7D14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F962 RID: 63842
		private int opl_p0;
	}
}
