using System;

namespace behaviac
{
	// Token: 0x02002458 RID: 9304
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node11 : Condition
	{
		// Token: 0x06013202 RID: 78338 RVA: 0x005ACDF8 File Offset: 0x005AB1F8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node11()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013203 RID: 78339 RVA: 0x005ACE0C File Offset: 0x005AB20C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC28 RID: 52264
		private float opl_p0;
	}
}
