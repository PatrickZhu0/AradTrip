using System;

namespace behaviac
{
	// Token: 0x02002791 RID: 10129
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node48 : Condition
	{
		// Token: 0x06013862 RID: 79970 RVA: 0x005D246B File Offset: 0x005D086B
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node48()
		{
			this.opl_p0 = 3714;
		}

		// Token: 0x06013863 RID: 79971 RVA: 0x005D2480 File Offset: 0x005D0880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2C2 RID: 53954
		private int opl_p0;
	}
}
