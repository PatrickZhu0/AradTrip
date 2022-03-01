using System;

namespace behaviac
{
	// Token: 0x02003856 RID: 14422
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node33 : Condition
	{
		// Token: 0x06015892 RID: 88210 RVA: 0x0067F853 File Offset: 0x0067DC53
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node33()
		{
			this.opl_p0 = 21229;
		}

		// Token: 0x06015893 RID: 88211 RVA: 0x0067F868 File Offset: 0x0067DC68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F248 RID: 62024
		private int opl_p0;
	}
}
