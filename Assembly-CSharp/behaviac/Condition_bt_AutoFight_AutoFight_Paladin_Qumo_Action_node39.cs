using System;

namespace behaviac
{
	// Token: 0x020027D5 RID: 10197
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node39 : Condition
	{
		// Token: 0x060138E9 RID: 80105 RVA: 0x005D4EA7 File Offset: 0x005D32A7
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node39()
		{
			this.opl_p0 = 3606;
		}

		// Token: 0x060138EA RID: 80106 RVA: 0x005D4EBC File Offset: 0x005D32BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D348 RID: 54088
		private int opl_p0;
	}
}
