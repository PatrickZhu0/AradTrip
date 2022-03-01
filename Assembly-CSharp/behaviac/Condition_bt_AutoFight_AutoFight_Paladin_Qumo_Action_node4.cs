using System;

namespace behaviac
{
	// Token: 0x020027B5 RID: 10165
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node4 : Condition
	{
		// Token: 0x060138A9 RID: 80041 RVA: 0x005D4107 File Offset: 0x005D2507
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node4()
		{
			this.opl_p0 = 3607;
		}

		// Token: 0x060138AA RID: 80042 RVA: 0x005D411C File Offset: 0x005D251C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D308 RID: 54024
		private int opl_p0;
	}
}
