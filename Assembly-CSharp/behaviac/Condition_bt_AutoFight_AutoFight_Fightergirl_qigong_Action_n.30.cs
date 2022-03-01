using System;

namespace behaviac
{
	// Token: 0x02001F19 RID: 7961
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node57 : Condition
	{
		// Token: 0x060127D6 RID: 75734 RVA: 0x00568C0F File Offset: 0x0056700F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node57()
		{
			this.opl_p0 = 3112;
		}

		// Token: 0x060127D7 RID: 75735 RVA: 0x00568C24 File Offset: 0x00567024
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1CE RID: 49614
		private int opl_p0;
	}
}
