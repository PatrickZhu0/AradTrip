using System;

namespace behaviac
{
	// Token: 0x02002819 RID: 10265
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node58 : Condition
	{
		// Token: 0x06013970 RID: 80240 RVA: 0x005D879F File Offset: 0x005D6B9F
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node58()
		{
			this.opl_p0 = 3709;
		}

		// Token: 0x06013971 RID: 80241 RVA: 0x005D87B4 File Offset: 0x005D6BB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3CD RID: 54221
		private int opl_p0;
	}
}
