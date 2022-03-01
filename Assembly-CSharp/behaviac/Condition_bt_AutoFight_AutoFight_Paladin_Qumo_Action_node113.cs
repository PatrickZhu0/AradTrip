using System;

namespace behaviac
{
	// Token: 0x0200280D RID: 10253
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node113 : Condition
	{
		// Token: 0x06013959 RID: 80217 RVA: 0x005D667F File Offset: 0x005D4A7F
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node113()
		{
			this.opl_p0 = 3510;
		}

		// Token: 0x0601395A RID: 80218 RVA: 0x005D6694 File Offset: 0x005D4A94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3B8 RID: 54200
		private int opl_p0;
	}
}
