using System;

namespace behaviac
{
	// Token: 0x02002865 RID: 10341
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node113 : Condition
	{
		// Token: 0x06013A08 RID: 80392 RVA: 0x005DA79B File Offset: 0x005D8B9B
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node113()
		{
			this.opl_p0 = 3510;
		}

		// Token: 0x06013A09 RID: 80393 RVA: 0x005DA7B0 File Offset: 0x005D8BB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D461 RID: 54369
		private int opl_p0;
	}
}
