using System;

namespace behaviac
{
	// Token: 0x0200390B RID: 14603
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node80 : Condition
	{
		// Token: 0x060159F1 RID: 88561 RVA: 0x00687592 File Offset: 0x00685992
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node80()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060159F2 RID: 88562 RVA: 0x006875A8 File Offset: 0x006859A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F38B RID: 62347
		private float opl_p0;
	}
}
