using System;

namespace behaviac
{
	// Token: 0x02002828 RID: 10280
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node72 : Condition
	{
		// Token: 0x0601398E RID: 80270 RVA: 0x005D8DC7 File Offset: 0x005D71C7
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node72()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601398F RID: 80271 RVA: 0x005D8DDC File Offset: 0x005D71DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3E8 RID: 54248
		private float opl_p0;
	}
}
