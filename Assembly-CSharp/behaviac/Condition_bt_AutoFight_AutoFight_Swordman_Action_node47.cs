using System;

namespace behaviac
{
	// Token: 0x02002876 RID: 10358
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node47 : Condition
	{
		// Token: 0x06013A29 RID: 80425 RVA: 0x005DC9B5 File Offset: 0x005DADB5
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node47()
		{
			this.opl_p0 = 1911;
		}

		// Token: 0x06013A2A RID: 80426 RVA: 0x005DC9C8 File Offset: 0x005DADC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D483 RID: 54403
		private int opl_p0;
	}
}
