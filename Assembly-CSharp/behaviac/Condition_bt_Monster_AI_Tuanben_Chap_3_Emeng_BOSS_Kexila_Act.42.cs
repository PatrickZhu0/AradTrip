using System;

namespace behaviac
{
	// Token: 0x02003879 RID: 14457
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node55 : Condition
	{
		// Token: 0x060158D6 RID: 88278 RVA: 0x006813EB File Offset: 0x0067F7EB
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node55()
		{
			this.opl_p0 = 21214;
		}

		// Token: 0x060158D7 RID: 88279 RVA: 0x00681400 File Offset: 0x0067F800
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F277 RID: 62071
		private int opl_p0;
	}
}
