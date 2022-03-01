using System;

namespace behaviac
{
	// Token: 0x020038FA RID: 14586
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node62 : Condition
	{
		// Token: 0x060159D1 RID: 88529 RVA: 0x00686077 File Offset: 0x00684477
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node62()
		{
			this.opl_p0 = 21204;
		}

		// Token: 0x060159D2 RID: 88530 RVA: 0x0068608C File Offset: 0x0068448C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F375 RID: 62325
		private int opl_p0;
	}
}
