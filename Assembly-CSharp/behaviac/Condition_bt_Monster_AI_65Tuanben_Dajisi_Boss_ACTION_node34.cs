using System;

namespace behaviac
{
	// Token: 0x02002D7C RID: 11644
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node34 : Condition
	{
		// Token: 0x060143DA RID: 82906 RVA: 0x006146CF File Offset: 0x00612ACF
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node34()
		{
			this.opl_p0 = 21607;
		}

		// Token: 0x060143DB RID: 82907 RVA: 0x006146E4 File Offset: 0x00612AE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDAA RID: 56746
		private int opl_p0;
	}
}
