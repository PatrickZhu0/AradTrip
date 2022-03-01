using System;

namespace behaviac
{
	// Token: 0x02001F4C RID: 8012
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node38 : Condition
	{
		// Token: 0x0601283B RID: 75835 RVA: 0x0056B0CF File Offset: 0x005694CF
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node38()
		{
			this.opl_p0 = 3204;
		}

		// Token: 0x0601283C RID: 75836 RVA: 0x0056B0E4 File Offset: 0x005694E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C234 RID: 49716
		private int opl_p0;
	}
}
