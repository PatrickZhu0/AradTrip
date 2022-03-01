using System;

namespace behaviac
{
	// Token: 0x02002969 RID: 10601
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node19 : Condition
	{
		// Token: 0x06013C07 RID: 80903 RVA: 0x005E7B41 File Offset: 0x005E5F41
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node19()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013C08 RID: 80904 RVA: 0x005E7B54 File Offset: 0x005E5F54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D66E RID: 54894
		private float opl_p0;
	}
}
