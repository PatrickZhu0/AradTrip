using System;

namespace behaviac
{
	// Token: 0x020029D6 RID: 10710
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node133 : Condition
	{
		// Token: 0x06013CE0 RID: 81120 RVA: 0x005EBE59 File Offset: 0x005EA259
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node133()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013CE1 RID: 81121 RVA: 0x005EBE6C File Offset: 0x005EA26C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D753 RID: 55123
		private float opl_p0;
	}
}
