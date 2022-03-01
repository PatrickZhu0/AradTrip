using System;

namespace behaviac
{
	// Token: 0x02003942 RID: 14658
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node62 : Condition
	{
		// Token: 0x06015A5F RID: 88671 RVA: 0x00688CB3 File Offset: 0x006870B3
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node62()
		{
			this.opl_p0 = 21460;
		}

		// Token: 0x06015A60 RID: 88672 RVA: 0x00688CC8 File Offset: 0x006870C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3EA RID: 62442
		private int opl_p0;
	}
}
