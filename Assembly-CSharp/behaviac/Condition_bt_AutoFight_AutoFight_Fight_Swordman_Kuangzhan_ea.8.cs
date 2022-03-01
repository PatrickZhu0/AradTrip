using System;

namespace behaviac
{
	// Token: 0x0200230F RID: 8975
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node19 : Condition
	{
		// Token: 0x06012F93 RID: 77715 RVA: 0x0059C13C File Offset: 0x0059A53C
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node19()
		{
			this.opl_p0 = 0.42f;
		}

		// Token: 0x06012F94 RID: 77716 RVA: 0x0059C150 File Offset: 0x0059A550
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9AD RID: 51629
		private float opl_p0;
	}
}
