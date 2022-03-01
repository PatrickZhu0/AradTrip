using System;

namespace behaviac
{
	// Token: 0x020028F2 RID: 10482
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node11 : Condition
	{
		// Token: 0x06013B1B RID: 80667 RVA: 0x005E25B5 File Offset: 0x005E09B5
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node11()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013B1C RID: 80668 RVA: 0x005E25C8 File Offset: 0x005E09C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D57F RID: 54655
		private float opl_p0;
	}
}
