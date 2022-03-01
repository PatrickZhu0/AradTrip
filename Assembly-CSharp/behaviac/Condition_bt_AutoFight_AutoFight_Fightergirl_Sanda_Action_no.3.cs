using System;

namespace behaviac
{
	// Token: 0x02001F27 RID: 7975
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node7 : Condition
	{
		// Token: 0x060127F1 RID: 75761 RVA: 0x0056A0CF File Offset: 0x005684CF
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node7()
		{
			this.opl_p0 = 3209;
		}

		// Token: 0x060127F2 RID: 75762 RVA: 0x0056A0E4 File Offset: 0x005684E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1EA RID: 49642
		private int opl_p0;
	}
}
