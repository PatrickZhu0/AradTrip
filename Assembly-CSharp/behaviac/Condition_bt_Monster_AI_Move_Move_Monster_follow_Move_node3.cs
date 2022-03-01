using System;

namespace behaviac
{
	// Token: 0x020036F0 RID: 14064
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node3 : Condition
	{
		// Token: 0x060155F2 RID: 87538 RVA: 0x00672C3A File Offset: 0x0067103A
		public Condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node3()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x060155F3 RID: 87539 RVA: 0x00672C50 File Offset: 0x00671050
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFC1 RID: 61377
		private float opl_p0;
	}
}
