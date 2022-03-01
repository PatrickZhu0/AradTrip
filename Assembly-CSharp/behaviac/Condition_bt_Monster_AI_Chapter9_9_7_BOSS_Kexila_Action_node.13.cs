using System;

namespace behaviac
{
	// Token: 0x0200320D RID: 12813
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node40 : Condition
	{
		// Token: 0x06014CA4 RID: 85156 RVA: 0x0064335E File Offset: 0x0064175E
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node40()
		{
			this.opl_p0 = 0.11f;
		}

		// Token: 0x06014CA5 RID: 85157 RVA: 0x00643374 File Offset: 0x00641774
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5F0 RID: 58864
		private float opl_p0;
	}
}
