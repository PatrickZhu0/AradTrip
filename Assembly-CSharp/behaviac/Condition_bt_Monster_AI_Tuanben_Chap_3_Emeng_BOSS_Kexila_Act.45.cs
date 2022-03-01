using System;

namespace behaviac
{
	// Token: 0x0200387E RID: 14462
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node32 : Condition
	{
		// Token: 0x060158E0 RID: 88288 RVA: 0x0068161A File Offset: 0x0067FA1A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node32()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060158E1 RID: 88289 RVA: 0x00681630 File Offset: 0x0067FA30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F27E RID: 62078
		private float opl_p0;
	}
}
