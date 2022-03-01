using System;

namespace behaviac
{
	// Token: 0x02002D78 RID: 11640
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node31 : Condition
	{
		// Token: 0x060143D2 RID: 82898 RVA: 0x0061451B File Offset: 0x0061291B
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node31()
		{
			this.opl_p0 = 21606;
		}

		// Token: 0x060143D3 RID: 82899 RVA: 0x00614530 File Offset: 0x00612930
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDA1 RID: 56737
		private int opl_p0;
	}
}
