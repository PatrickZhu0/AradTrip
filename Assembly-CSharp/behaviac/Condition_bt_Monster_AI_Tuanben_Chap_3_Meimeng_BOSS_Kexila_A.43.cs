using System;

namespace behaviac
{
	// Token: 0x02003912 RID: 14610
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node89 : Condition
	{
		// Token: 0x060159FF RID: 88575 RVA: 0x00687853 File Offset: 0x00685C53
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node89()
		{
			this.opl_p0 = 21204;
		}

		// Token: 0x06015A00 RID: 88576 RVA: 0x00687868 File Offset: 0x00685C68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F394 RID: 62356
		private int opl_p0;
	}
}
