using System;

namespace behaviac
{
	// Token: 0x02003926 RID: 14630
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node24 : Condition
	{
		// Token: 0x06015A27 RID: 88615 RVA: 0x006880FE File Offset: 0x006864FE
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node24()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x06015A28 RID: 88616 RVA: 0x00688114 File Offset: 0x00686514
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3B9 RID: 62393
		private float opl_p0;
	}
}
