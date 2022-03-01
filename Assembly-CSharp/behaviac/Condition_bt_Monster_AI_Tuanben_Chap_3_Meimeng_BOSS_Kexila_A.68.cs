using System;

namespace behaviac
{
	// Token: 0x02003936 RID: 14646
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node42 : Condition
	{
		// Token: 0x06015A47 RID: 88647 RVA: 0x006887C3 File Offset: 0x00686BC3
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node42()
		{
			this.opl_p0 = 21208;
		}

		// Token: 0x06015A48 RID: 88648 RVA: 0x006887D8 File Offset: 0x00686BD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3DA RID: 62426
		private int opl_p0;
	}
}
