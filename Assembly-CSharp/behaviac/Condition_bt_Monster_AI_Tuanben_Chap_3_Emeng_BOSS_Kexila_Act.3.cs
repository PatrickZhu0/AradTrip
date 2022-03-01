using System;

namespace behaviac
{
	// Token: 0x0200383C RID: 14396
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node16 : Condition
	{
		// Token: 0x0601585E RID: 88158 RVA: 0x0067EE2A File Offset: 0x0067D22A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node16()
		{
			this.opl_p0 = 0.14f;
		}

		// Token: 0x0601585F RID: 88159 RVA: 0x0067EE40 File Offset: 0x0067D240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F224 RID: 61988
		private float opl_p0;
	}
}
