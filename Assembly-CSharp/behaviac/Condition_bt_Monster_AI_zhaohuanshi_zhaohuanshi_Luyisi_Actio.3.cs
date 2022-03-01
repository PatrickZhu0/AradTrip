using System;

namespace behaviac
{
	// Token: 0x02003FCF RID: 16335
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node10 : Condition
	{
		// Token: 0x06016706 RID: 91910 RVA: 0x006CA415 File Offset: 0x006C8815
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node10()
		{
			this.opl_p0 = 5022;
		}

		// Token: 0x06016707 RID: 91911 RVA: 0x006CA428 File Offset: 0x006C8828
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF59 RID: 65369
		private int opl_p0;
	}
}
