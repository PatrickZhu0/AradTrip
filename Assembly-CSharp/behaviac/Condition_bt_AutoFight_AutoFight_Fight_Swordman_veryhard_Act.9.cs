using System;

namespace behaviac
{
	// Token: 0x02002463 RID: 9315
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node8 : Condition
	{
		// Token: 0x06013216 RID: 78358 RVA: 0x005AD2E8 File Offset: 0x005AB6E8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node8()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x06013217 RID: 78359 RVA: 0x005AD2FC File Offset: 0x005AB6FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC3B RID: 52283
		private float opl_p0;
	}
}
