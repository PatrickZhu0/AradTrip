using System;

namespace behaviac
{
	// Token: 0x02002482 RID: 9346
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node19 : Condition
	{
		// Token: 0x06013251 RID: 78417 RVA: 0x005AEAB5 File Offset: 0x005ACEB5
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node19()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013252 RID: 78418 RVA: 0x005AEAC8 File Offset: 0x005ACEC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC6D RID: 52333
		private float opl_p0;
	}
}
