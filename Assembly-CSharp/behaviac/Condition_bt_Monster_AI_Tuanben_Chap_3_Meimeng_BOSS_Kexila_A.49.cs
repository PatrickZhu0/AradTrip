using System;

namespace behaviac
{
	// Token: 0x0200391A RID: 14618
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node16 : Condition
	{
		// Token: 0x06015A0F RID: 88591 RVA: 0x00687C0F File Offset: 0x0068600F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node16()
		{
			this.opl_p0 = 0.14f;
		}

		// Token: 0x06015A10 RID: 88592 RVA: 0x00687C24 File Offset: 0x00686024
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3A9 RID: 62377
		private float opl_p0;
	}
}
