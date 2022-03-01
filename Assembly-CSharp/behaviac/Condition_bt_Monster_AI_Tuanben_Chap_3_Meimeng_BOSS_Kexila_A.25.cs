using System;

namespace behaviac
{
	// Token: 0x020038F6 RID: 14582
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node52 : Condition
	{
		// Token: 0x060159C9 RID: 88521 RVA: 0x00685EF2 File Offset: 0x006842F2
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node52()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060159CA RID: 88522 RVA: 0x00685F08 File Offset: 0x00684308
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F370 RID: 62320
		private float opl_p0;
	}
}
