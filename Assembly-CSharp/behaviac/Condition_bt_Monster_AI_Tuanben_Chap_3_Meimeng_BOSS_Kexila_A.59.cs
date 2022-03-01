using System;

namespace behaviac
{
	// Token: 0x02003929 RID: 14633
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node28 : Condition
	{
		// Token: 0x06015A2D RID: 88621 RVA: 0x0068823A File Offset: 0x0068663A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015A2E RID: 88622 RVA: 0x00688250 File Offset: 0x00686650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3BD RID: 62397
		private float opl_p0;
	}
}
