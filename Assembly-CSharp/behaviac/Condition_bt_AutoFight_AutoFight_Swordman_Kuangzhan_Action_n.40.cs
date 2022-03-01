using System;

namespace behaviac
{
	// Token: 0x02002979 RID: 10617
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node10 : Condition
	{
		// Token: 0x06013C27 RID: 80935 RVA: 0x005E82FE File Offset: 0x005E66FE
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node10()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013C28 RID: 80936 RVA: 0x005E8314 File Offset: 0x005E6714
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D68E RID: 54926
		private float opl_p0;
	}
}
