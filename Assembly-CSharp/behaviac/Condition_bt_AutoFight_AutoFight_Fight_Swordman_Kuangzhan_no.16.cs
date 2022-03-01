using System;

namespace behaviac
{
	// Token: 0x020023F4 RID: 9204
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node37 : Condition
	{
		// Token: 0x06013147 RID: 78151 RVA: 0x005A7EDE File Offset: 0x005A62DE
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node37()
		{
			this.opl_p0 = 0.52f;
		}

		// Token: 0x06013148 RID: 78152 RVA: 0x005A7EF4 File Offset: 0x005A62F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB70 RID: 52080
		private float opl_p0;
	}
}
