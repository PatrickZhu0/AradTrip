using System;

namespace behaviac
{
	// Token: 0x02002D83 RID: 11651
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node18 : Condition
	{
		// Token: 0x060143E8 RID: 82920 RVA: 0x006149F3 File Offset: 0x00612DF3
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node18()
		{
			this.opl_p0 = 21602;
		}

		// Token: 0x060143E9 RID: 82921 RVA: 0x00614A08 File Offset: 0x00612E08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDBA RID: 56762
		private int opl_p0;
	}
}
