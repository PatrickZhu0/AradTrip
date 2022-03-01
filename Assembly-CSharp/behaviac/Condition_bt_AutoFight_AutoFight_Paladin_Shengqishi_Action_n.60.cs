using System;

namespace behaviac
{
	// Token: 0x02002861 RID: 10337
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node98 : Condition
	{
		// Token: 0x06013A00 RID: 80384 RVA: 0x005DA5E7 File Offset: 0x005D89E7
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node98()
		{
			this.opl_p0 = 3506;
		}

		// Token: 0x06013A01 RID: 80385 RVA: 0x005DA5FC File Offset: 0x005D89FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D459 RID: 54361
		private int opl_p0;
	}
}
