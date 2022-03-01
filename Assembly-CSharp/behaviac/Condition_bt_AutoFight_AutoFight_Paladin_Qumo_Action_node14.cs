using System;

namespace behaviac
{
	// Token: 0x020027BD RID: 10173
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node14 : Condition
	{
		// Token: 0x060138B9 RID: 80057 RVA: 0x005D446F File Offset: 0x005D286F
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node14()
		{
			this.opl_p0 = 3617;
		}

		// Token: 0x060138BA RID: 80058 RVA: 0x005D4484 File Offset: 0x005D2884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D318 RID: 54040
		private int opl_p0;
	}
}
