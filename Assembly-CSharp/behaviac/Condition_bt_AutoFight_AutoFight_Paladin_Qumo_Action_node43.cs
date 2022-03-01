using System;

namespace behaviac
{
	// Token: 0x02002810 RID: 10256
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node43 : Condition
	{
		// Token: 0x0601395F RID: 80223 RVA: 0x005D6849 File Offset: 0x005D4C49
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node43()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013960 RID: 80224 RVA: 0x005D685C File Offset: 0x005D4C5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3BF RID: 54207
		private float opl_p0;
	}
}
