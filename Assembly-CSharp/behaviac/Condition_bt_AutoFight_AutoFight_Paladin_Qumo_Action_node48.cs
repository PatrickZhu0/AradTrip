using System;

namespace behaviac
{
	// Token: 0x020027E9 RID: 10217
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node48 : Condition
	{
		// Token: 0x06013911 RID: 80145 RVA: 0x005D572B File Offset: 0x005D3B2B
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node48()
		{
			this.opl_p0 = 3609;
		}

		// Token: 0x06013912 RID: 80146 RVA: 0x005D5740 File Offset: 0x005D3B40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D370 RID: 54128
		private int opl_p0;
	}
}
