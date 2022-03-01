using System;

namespace behaviac
{
	// Token: 0x0200392E RID: 14638
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node30 : Condition
	{
		// Token: 0x06015A37 RID: 88631 RVA: 0x00688489 File Offset: 0x00686889
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node30()
		{
			this.opl_p0 = 21205;
		}

		// Token: 0x06015A38 RID: 88632 RVA: 0x0068849C File Offset: 0x0068689C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3CA RID: 62410
		private int opl_p0;
	}
}
