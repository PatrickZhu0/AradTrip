using System;

namespace behaviac
{
	// Token: 0x02003FD7 RID: 16343
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node19 : Condition
	{
		// Token: 0x06016716 RID: 91926 RVA: 0x006CA77D File Offset: 0x006C8B7D
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node19()
		{
			this.opl_p0 = 5353;
		}

		// Token: 0x06016717 RID: 91927 RVA: 0x006CA790 File Offset: 0x006C8B90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF69 RID: 65385
		private int opl_p0;
	}
}
