using System;

namespace behaviac
{
	// Token: 0x0200227F RID: 8831
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node8 : Condition
	{
		// Token: 0x06012E80 RID: 77440 RVA: 0x00593B50 File Offset: 0x00591F50
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node8()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012E81 RID: 77441 RVA: 0x00593B64 File Offset: 0x00591F64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C88D RID: 51341
		private float opl_p0;
	}
}
