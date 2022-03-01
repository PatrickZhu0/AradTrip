using System;

namespace behaviac
{
	// Token: 0x02001F1E RID: 7966
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node50 : Condition
	{
		// Token: 0x060127E0 RID: 75744 RVA: 0x00568E1F File Offset: 0x0056721F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node50()
		{
			this.opl_p0 = 3009;
		}

		// Token: 0x060127E1 RID: 75745 RVA: 0x00568E34 File Offset: 0x00567234
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1D9 RID: 49625
		private int opl_p0;
	}
}
