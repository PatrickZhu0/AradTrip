using System;

namespace behaviac
{
	// Token: 0x0200248A RID: 9354
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3 : Condition
	{
		// Token: 0x06013261 RID: 78433 RVA: 0x005AEDB9 File Offset: 0x005AD1B9
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013262 RID: 78434 RVA: 0x005AEDCC File Offset: 0x005AD1CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC7B RID: 52347
		private float opl_p0;
	}
}
