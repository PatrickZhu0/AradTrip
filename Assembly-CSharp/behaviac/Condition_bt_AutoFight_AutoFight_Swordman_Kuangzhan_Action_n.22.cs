using System;

namespace behaviac
{
	// Token: 0x02002960 RID: 10592
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node73 : Condition
	{
		// Token: 0x06013BF5 RID: 80885 RVA: 0x005E7787 File Offset: 0x005E5B87
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node73()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06013BF6 RID: 80886 RVA: 0x005E779C File Offset: 0x005E5B9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D65C RID: 54876
		private float opl_p0;
	}
}
