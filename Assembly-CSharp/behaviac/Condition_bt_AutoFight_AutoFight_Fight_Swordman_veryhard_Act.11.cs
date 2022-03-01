using System;

namespace behaviac
{
	// Token: 0x02002466 RID: 9318
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node37 : Condition
	{
		// Token: 0x0601321C RID: 78364 RVA: 0x005AD47E File Offset: 0x005AB87E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node37()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601321D RID: 78365 RVA: 0x005AD494 File Offset: 0x005AB894
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC3F RID: 52287
		private float opl_p0;
	}
}
