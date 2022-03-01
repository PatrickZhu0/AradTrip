using System;

namespace behaviac
{
	// Token: 0x0200295C RID: 10588
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node11 : Condition
	{
		// Token: 0x06013BED RID: 80877 RVA: 0x005E7591 File Offset: 0x005E5991
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node11()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013BEE RID: 80878 RVA: 0x005E75A4 File Offset: 0x005E59A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D654 RID: 54868
		private float opl_p0;
	}
}
