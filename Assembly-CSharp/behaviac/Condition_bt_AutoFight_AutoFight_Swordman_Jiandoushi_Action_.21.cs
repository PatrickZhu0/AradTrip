using System;

namespace behaviac
{
	// Token: 0x020028FE RID: 10494
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node19 : Condition
	{
		// Token: 0x06013B33 RID: 80691 RVA: 0x005E2AD1 File Offset: 0x005E0ED1
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node19()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013B34 RID: 80692 RVA: 0x005E2AE4 File Offset: 0x005E0EE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D597 RID: 54679
		private float opl_p0;
	}
}
