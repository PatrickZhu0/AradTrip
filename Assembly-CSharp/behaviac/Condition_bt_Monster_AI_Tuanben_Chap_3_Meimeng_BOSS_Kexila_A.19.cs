using System;

namespace behaviac
{
	// Token: 0x020038ED RID: 14573
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node40 : Condition
	{
		// Token: 0x060159B7 RID: 88503 RVA: 0x00685B3E File Offset: 0x00683F3E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node40()
		{
			this.opl_p0 = 0.11f;
		}

		// Token: 0x060159B8 RID: 88504 RVA: 0x00685B54 File Offset: 0x00683F54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F364 RID: 62308
		private float opl_p0;
	}
}
