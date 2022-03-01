using System;

namespace behaviac
{
	// Token: 0x020036F2 RID: 14066
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node5 : Condition
	{
		// Token: 0x060155F6 RID: 87542 RVA: 0x00672CAD File Offset: 0x006710AD
		public Condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060155F7 RID: 87543 RVA: 0x00672CC0 File Offset: 0x006710C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFC3 RID: 61379
		private float opl_p0;
	}
}
