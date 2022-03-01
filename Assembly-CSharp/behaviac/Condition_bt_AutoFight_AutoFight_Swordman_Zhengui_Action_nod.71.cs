using System;

namespace behaviac
{
	// Token: 0x020029D9 RID: 10713
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node80 : Condition
	{
		// Token: 0x06013CE6 RID: 81126 RVA: 0x005EBF92 File Offset: 0x005EA392
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node80()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013CE7 RID: 81127 RVA: 0x005EBFA8 File Offset: 0x005EA3A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D757 RID: 55127
		private float opl_p0;
	}
}
