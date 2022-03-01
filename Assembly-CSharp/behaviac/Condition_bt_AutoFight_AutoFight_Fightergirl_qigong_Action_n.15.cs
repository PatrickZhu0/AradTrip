using System;

namespace behaviac
{
	// Token: 0x02001F05 RID: 7941
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node74 : Condition
	{
		// Token: 0x060127AE RID: 75694 RVA: 0x0056820B File Offset: 0x0056660B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node74()
		{
			this.opl_p0 = 3111;
		}

		// Token: 0x060127AF RID: 75695 RVA: 0x00568220 File Offset: 0x00566620
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1A4 RID: 49572
		private int opl_p0;
	}
}
