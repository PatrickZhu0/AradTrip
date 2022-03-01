using System;

namespace behaviac
{
	// Token: 0x020028EA RID: 10474
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node37 : Condition
	{
		// Token: 0x06013B0B RID: 80651 RVA: 0x005E224D File Offset: 0x005E064D
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node37()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013B0C RID: 80652 RVA: 0x005E2260 File Offset: 0x005E0660
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D56F RID: 54639
		private float opl_p0;
	}
}
