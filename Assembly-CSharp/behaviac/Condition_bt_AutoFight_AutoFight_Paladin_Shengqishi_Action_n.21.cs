using System;

namespace behaviac
{
	// Token: 0x0200282D RID: 10285
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node20 : Condition
	{
		// Token: 0x06013998 RID: 80280 RVA: 0x005D8FC3 File Offset: 0x005D73C3
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node20()
		{
			this.opl_p0 = 3710;
		}

		// Token: 0x06013999 RID: 80281 RVA: 0x005D8FD8 File Offset: 0x005D73D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3F1 RID: 54257
		private int opl_p0;
	}
}
