using System;

namespace behaviac
{
	// Token: 0x0200403C RID: 16444
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node12 : Condition
	{
		// Token: 0x060167D7 RID: 92119 RVA: 0x006CEAE9 File Offset: 0x006CCEE9
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node12()
		{
			this.opl_p0 = 5110;
		}

		// Token: 0x060167D8 RID: 92120 RVA: 0x006CEAFC File Offset: 0x006CCEFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010023 RID: 65571
		private int opl_p0;
	}
}
