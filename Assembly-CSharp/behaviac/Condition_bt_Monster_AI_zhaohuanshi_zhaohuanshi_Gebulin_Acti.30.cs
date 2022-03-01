using System;

namespace behaviac
{
	// Token: 0x02003FB3 RID: 16307
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node52 : Condition
	{
		// Token: 0x060166D0 RID: 91856 RVA: 0x006C86AD File Offset: 0x006C6AAD
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node52()
		{
			this.opl_p0 = 5112;
		}

		// Token: 0x060166D1 RID: 91857 RVA: 0x006C86C0 File Offset: 0x006C6AC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF24 RID: 65316
		private int opl_p0;
	}
}
