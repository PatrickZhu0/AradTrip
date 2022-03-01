using System;

namespace behaviac
{
	// Token: 0x0200291B RID: 10523
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node11 : Condition
	{
		// Token: 0x06013B6C RID: 80748 RVA: 0x005E43F5 File Offset: 0x005E27F5
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node11()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013B6D RID: 80749 RVA: 0x005E4408 File Offset: 0x005E2808
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5D3 RID: 54739
		private float opl_p0;
	}
}
