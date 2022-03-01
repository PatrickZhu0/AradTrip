using System;

namespace behaviac
{
	// Token: 0x020029C2 RID: 10690
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node54 : Condition
	{
		// Token: 0x06013CB8 RID: 81080 RVA: 0x005EB536 File Offset: 0x005E9936
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node54()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013CB9 RID: 81081 RVA: 0x005EB54C File Offset: 0x005E994C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D726 RID: 55078
		private float opl_p0;
	}
}
