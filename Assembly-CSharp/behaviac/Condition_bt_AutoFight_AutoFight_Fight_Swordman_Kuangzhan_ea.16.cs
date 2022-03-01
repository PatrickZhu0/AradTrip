using System;

namespace behaviac
{
	// Token: 0x0200231C RID: 8988
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node37 : Condition
	{
		// Token: 0x06012FAB RID: 77739 RVA: 0x0059C656 File Offset: 0x0059AA56
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node37()
		{
			this.opl_p0 = 0.43f;
		}

		// Token: 0x06012FAC RID: 77740 RVA: 0x0059C66C File Offset: 0x0059AA6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9C1 RID: 51649
		private float opl_p0;
	}
}
