using System;

namespace behaviac
{
	// Token: 0x0200315E RID: 12638
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node3 : Condition
	{
		// Token: 0x06014B59 RID: 84825 RVA: 0x0063CA8A File Offset: 0x0063AE8A
		public Condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node3()
		{
			this.opl_p0 = 20435;
		}

		// Token: 0x06014B5A RID: 84826 RVA: 0x0063CAA0 File Offset: 0x0063AEA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4D1 RID: 58577
		private int opl_p0;
	}
}
