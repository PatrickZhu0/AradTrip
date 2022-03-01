using System;

namespace behaviac
{
	// Token: 0x02003CAD RID: 15533
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node60 : Condition
	{
		// Token: 0x06016101 RID: 90369 RVA: 0x006AA5DD File Offset: 0x006A89DD
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node60()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x06016102 RID: 90370 RVA: 0x006AA5F0 File Offset: 0x006A89F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9A9 RID: 63913
		private int opl_p0;
	}
}
