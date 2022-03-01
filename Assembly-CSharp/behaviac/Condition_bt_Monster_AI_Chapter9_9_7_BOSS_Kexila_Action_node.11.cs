using System;

namespace behaviac
{
	// Token: 0x0200320A RID: 12810
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node36 : Condition
	{
		// Token: 0x06014C9E RID: 85150 RVA: 0x00643223 File Offset: 0x00641623
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node36()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06014C9F RID: 85151 RVA: 0x00643238 File Offset: 0x00641638
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5EC RID: 58860
		private float opl_p0;
	}
}
