using System;

namespace behaviac
{
	// Token: 0x02001F0D RID: 7949
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node25 : Condition
	{
		// Token: 0x060127BE RID: 75710 RVA: 0x0056856F File Offset: 0x0056696F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node25()
		{
			this.opl_p0 = 3120;
		}

		// Token: 0x060127BF RID: 75711 RVA: 0x00568584 File Offset: 0x00566984
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1B4 RID: 49588
		private int opl_p0;
	}
}
