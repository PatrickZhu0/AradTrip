using System;

namespace behaviac
{
	// Token: 0x02002486 RID: 9350
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node6 : Condition
	{
		// Token: 0x06013259 RID: 78425 RVA: 0x005AEC36 File Offset: 0x005AD036
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601325A RID: 78426 RVA: 0x005AEC4C File Offset: 0x005AD04C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC74 RID: 52340
		private float opl_p0;
	}
}
