using System;

namespace behaviac
{
	// Token: 0x0200393E RID: 14654
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node52 : Condition
	{
		// Token: 0x06015A57 RID: 88663 RVA: 0x00688B2E File Offset: 0x00686F2E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node52()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06015A58 RID: 88664 RVA: 0x00688B44 File Offset: 0x00686F44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3E5 RID: 62437
		private float opl_p0;
	}
}
