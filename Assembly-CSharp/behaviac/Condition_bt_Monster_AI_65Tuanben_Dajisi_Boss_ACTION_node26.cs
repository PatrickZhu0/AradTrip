using System;

namespace behaviac
{
	// Token: 0x02002D71 RID: 11633
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node26 : Condition
	{
		// Token: 0x060143C4 RID: 82884 RVA: 0x00614247 File Offset: 0x00612647
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node26()
		{
			this.opl_p0 = 21605;
		}

		// Token: 0x060143C5 RID: 82885 RVA: 0x0061425C File Offset: 0x0061265C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD8F RID: 56719
		private int opl_p0;
	}
}
