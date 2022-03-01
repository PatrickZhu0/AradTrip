using System;

namespace behaviac
{
	// Token: 0x02002407 RID: 9223
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node60 : Condition
	{
		// Token: 0x0601316D RID: 78189 RVA: 0x005A872A File Offset: 0x005A6B2A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node60()
		{
			this.opl_p0 = 0.44f;
		}

		// Token: 0x0601316E RID: 78190 RVA: 0x005A8740 File Offset: 0x005A6B40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB99 RID: 52121
		private float opl_p0;
	}
}
