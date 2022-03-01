using System;

namespace behaviac
{
	// Token: 0x0200294C RID: 10572
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node37 : Condition
	{
		// Token: 0x06013BCD RID: 80845 RVA: 0x005E6E6D File Offset: 0x005E526D
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node37()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06013BCE RID: 80846 RVA: 0x005E6E80 File Offset: 0x005E5280
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D634 RID: 54836
		private float opl_p0;
	}
}
