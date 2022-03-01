using System;

namespace behaviac
{
	// Token: 0x02002699 RID: 9881
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node22 : Condition
	{
		// Token: 0x06013676 RID: 79478 RVA: 0x005C6EF5 File Offset: 0x005C52F5
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node22()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013677 RID: 79479 RVA: 0x005C6F08 File Offset: 0x005C5308
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0CB RID: 53451
		private float opl_p0;
	}
}
