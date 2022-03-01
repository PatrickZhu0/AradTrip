using System;

namespace behaviac
{
	// Token: 0x02002809 RID: 10249
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node98 : Condition
	{
		// Token: 0x06013951 RID: 80209 RVA: 0x005D64CB File Offset: 0x005D48CB
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node98()
		{
			this.opl_p0 = 3506;
		}

		// Token: 0x06013952 RID: 80210 RVA: 0x005D64E0 File Offset: 0x005D48E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3B0 RID: 54192
		private int opl_p0;
	}
}
