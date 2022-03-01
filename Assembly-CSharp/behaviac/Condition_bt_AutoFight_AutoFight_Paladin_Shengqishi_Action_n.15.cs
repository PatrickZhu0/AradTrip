using System;

namespace behaviac
{
	// Token: 0x02002825 RID: 10277
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node53 : Condition
	{
		// Token: 0x06013988 RID: 80264 RVA: 0x005D8C73 File Offset: 0x005D7073
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node53()
		{
			this.opl_p0 = 3704;
		}

		// Token: 0x06013989 RID: 80265 RVA: 0x005D8C88 File Offset: 0x005D7088
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3E2 RID: 54242
		private int opl_p0;
	}
}
