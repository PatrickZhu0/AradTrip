using System;

namespace behaviac
{
	// Token: 0x020038E3 RID: 14563
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node34 : Condition
	{
		// Token: 0x060159A3 RID: 88483 RVA: 0x0068570F File Offset: 0x00683B0F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node34()
		{
			this.opl_p0 = 21204;
		}

		// Token: 0x060159A4 RID: 88484 RVA: 0x00685724 File Offset: 0x00683B24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F351 RID: 62289
		private int opl_p0;
	}
}
