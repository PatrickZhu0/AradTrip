using System;

namespace behaviac
{
	// Token: 0x0200390F RID: 14607
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node85 : Condition
	{
		// Token: 0x060159F9 RID: 88569 RVA: 0x00687717 File Offset: 0x00685B17
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node85()
		{
			this.opl_p0 = 21203;
		}

		// Token: 0x060159FA RID: 88570 RVA: 0x0068772C File Offset: 0x00685B2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F390 RID: 62352
		private int opl_p0;
	}
}
