using System;

namespace behaviac
{
	// Token: 0x02002830 RID: 10288
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node4 : Condition
	{
		// Token: 0x0601399E RID: 80286 RVA: 0x005D9131 File Offset: 0x005D7531
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node4()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601399F RID: 80287 RVA: 0x005D9144 File Offset: 0x005D7544
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3F8 RID: 54264
		private float opl_p0;
	}
}
