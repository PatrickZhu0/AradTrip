using System;

namespace behaviac
{
	// Token: 0x020029C6 RID: 10694
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node94 : Condition
	{
		// Token: 0x06013CC0 RID: 81088 RVA: 0x005EB6EA File Offset: 0x005E9AEA
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node94()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013CC1 RID: 81089 RVA: 0x005EB700 File Offset: 0x005E9B00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D72E RID: 55086
		private float opl_p0;
	}
}
