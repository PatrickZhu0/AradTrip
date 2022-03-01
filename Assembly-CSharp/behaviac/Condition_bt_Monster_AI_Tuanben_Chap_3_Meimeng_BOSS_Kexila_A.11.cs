using System;

namespace behaviac
{
	// Token: 0x020038E0 RID: 14560
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node25 : Condition
	{
		// Token: 0x0601599D RID: 88477 RVA: 0x006855D3 File Offset: 0x006839D3
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node25()
		{
			this.opl_p0 = 21203;
		}

		// Token: 0x0601599E RID: 88478 RVA: 0x006855E8 File Offset: 0x006839E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F34D RID: 62285
		private int opl_p0;
	}
}
