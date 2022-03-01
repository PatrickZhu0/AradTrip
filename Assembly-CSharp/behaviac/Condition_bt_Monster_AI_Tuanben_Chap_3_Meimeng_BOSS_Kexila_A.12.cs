using System;

namespace behaviac
{
	// Token: 0x020038E2 RID: 14562
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node28 : Condition
	{
		// Token: 0x060159A1 RID: 88481 RVA: 0x006856C6 File Offset: 0x00683AC6
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060159A2 RID: 88482 RVA: 0x006856DC File Offset: 0x00683ADC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F350 RID: 62288
		private float opl_p0;
	}
}
