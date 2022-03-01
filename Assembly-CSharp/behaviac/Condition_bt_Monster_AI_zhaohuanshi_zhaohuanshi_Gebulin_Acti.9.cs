using System;

namespace behaviac
{
	// Token: 0x02003F97 RID: 16279
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node17 : Condition
	{
		// Token: 0x06016698 RID: 91800 RVA: 0x006C7AC1 File Offset: 0x006C5EC1
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node17()
		{
			this.opl_p0 = 5111;
		}

		// Token: 0x06016699 RID: 91801 RVA: 0x006C7AD4 File Offset: 0x006C5ED4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEEC RID: 65260
		private int opl_p0;
	}
}
