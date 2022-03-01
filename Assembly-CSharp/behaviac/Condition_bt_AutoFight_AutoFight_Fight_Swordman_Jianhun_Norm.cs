using System;

namespace behaviac
{
	// Token: 0x020022EA RID: 8938
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node52 : Condition
	{
		// Token: 0x06012F4D RID: 77645 RVA: 0x0059A26D File Offset: 0x0059866D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node52()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012F4E RID: 77646 RVA: 0x0059A280 File Offset: 0x00598680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C95C RID: 51548
		private float opl_p0;
	}
}
