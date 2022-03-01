using System;

namespace behaviac
{
	// Token: 0x02002987 RID: 10631
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node29 : Condition
	{
		// Token: 0x06013C42 RID: 80962 RVA: 0x005E9B8A File Offset: 0x005E7F8A
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node29()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013C43 RID: 80963 RVA: 0x005E9BA0 File Offset: 0x005E7FA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6AA RID: 54954
		private float opl_p0;
	}
}
