using System;

namespace behaviac
{
	// Token: 0x02003200 RID: 12800
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node10 : Condition
	{
		// Token: 0x06014C8A RID: 85130 RVA: 0x00642E0E File Offset: 0x0064120E
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node10()
		{
			this.opl_p0 = 0.16f;
		}

		// Token: 0x06014C8B RID: 85131 RVA: 0x00642E24 File Offset: 0x00641224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5DD RID: 58845
		private float opl_p0;
	}
}
