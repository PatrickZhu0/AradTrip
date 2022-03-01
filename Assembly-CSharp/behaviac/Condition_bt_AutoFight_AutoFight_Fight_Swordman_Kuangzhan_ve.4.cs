using System;

namespace behaviac
{
	// Token: 0x02002411 RID: 9233
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node11 : Condition
	{
		// Token: 0x0601317E RID: 78206 RVA: 0x005A9964 File Offset: 0x005A7D64
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node11()
		{
			this.opl_p0 = 0.78f;
		}

		// Token: 0x0601317F RID: 78207 RVA: 0x005A9978 File Offset: 0x005A7D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBAA RID: 52138
		private float opl_p0;
	}
}
