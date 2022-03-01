using System;

namespace behaviac
{
	// Token: 0x02003883 RID: 14467
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node17 : Condition
	{
		// Token: 0x060158EA RID: 88298 RVA: 0x0068179F File Offset: 0x0067FB9F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node17()
		{
			this.opl_p0 = 21228;
		}

		// Token: 0x060158EB RID: 88299 RVA: 0x006817B4 File Offset: 0x0067FBB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F286 RID: 62086
		private int opl_p0;
	}
}
