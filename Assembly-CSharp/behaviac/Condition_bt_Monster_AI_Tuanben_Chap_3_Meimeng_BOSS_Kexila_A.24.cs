using System;

namespace behaviac
{
	// Token: 0x020038F4 RID: 14580
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node50 : Condition
	{
		// Token: 0x060159C5 RID: 88517 RVA: 0x00685DFF File Offset: 0x006841FF
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node50()
		{
			this.opl_p0 = 21202;
		}

		// Token: 0x060159C6 RID: 88518 RVA: 0x00685E14 File Offset: 0x00684214
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F36D RID: 62317
		private int opl_p0;
	}
}
