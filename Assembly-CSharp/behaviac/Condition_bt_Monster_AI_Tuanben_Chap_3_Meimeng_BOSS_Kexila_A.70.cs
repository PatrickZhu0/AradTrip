using System;

namespace behaviac
{
	// Token: 0x02003939 RID: 14649
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node46 : Condition
	{
		// Token: 0x06015A4D RID: 88653 RVA: 0x006888FF File Offset: 0x00686CFF
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node46()
		{
			this.opl_p0 = 21457;
		}

		// Token: 0x06015A4E RID: 88654 RVA: 0x00688914 File Offset: 0x00686D14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3DE RID: 62430
		private int opl_p0;
	}
}
