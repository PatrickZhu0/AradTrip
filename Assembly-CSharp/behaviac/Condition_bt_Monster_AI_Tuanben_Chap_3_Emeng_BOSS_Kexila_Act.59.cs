using System;

namespace behaviac
{
	// Token: 0x02003894 RID: 14484
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node58 : Condition
	{
		// Token: 0x0601590C RID: 88332 RVA: 0x00681E5B File Offset: 0x0068025B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node58()
		{
			this.opl_p0 = 21214;
		}

		// Token: 0x0601590D RID: 88333 RVA: 0x00681E70 File Offset: 0x00680270
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F29E RID: 62110
		private int opl_p0;
	}
}
