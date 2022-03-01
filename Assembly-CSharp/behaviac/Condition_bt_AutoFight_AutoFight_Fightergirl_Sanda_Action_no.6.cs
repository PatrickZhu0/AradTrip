using System;

namespace behaviac
{
	// Token: 0x02001F2B RID: 7979
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node22 : Condition
	{
		// Token: 0x060127F9 RID: 75769 RVA: 0x0056A26B File Offset: 0x0056866B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node22()
		{
			this.opl_p0 = 3202;
		}

		// Token: 0x060127FA RID: 75770 RVA: 0x0056A280 File Offset: 0x00568680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1F1 RID: 49649
		private int opl_p0;
	}
}
