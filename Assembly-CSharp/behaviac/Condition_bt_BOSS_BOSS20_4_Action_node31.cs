using System;

namespace behaviac
{
	// Token: 0x020029E8 RID: 10728
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node31 : Condition
	{
		// Token: 0x06013D03 RID: 81155 RVA: 0x005EE249 File Offset: 0x005EC649
		public Condition_bt_BOSS_BOSS20_4_Action_node31()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013D04 RID: 81156 RVA: 0x005EE25C File Offset: 0x005EC65C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D778 RID: 55160
		private float opl_p0;
	}
}
