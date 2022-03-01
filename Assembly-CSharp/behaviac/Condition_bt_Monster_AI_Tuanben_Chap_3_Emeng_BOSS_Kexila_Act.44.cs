using System;

namespace behaviac
{
	// Token: 0x0200387C RID: 14460
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node56 : Condition
	{
		// Token: 0x060158DC RID: 88284 RVA: 0x00681527 File Offset: 0x0067F927
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node56()
		{
			this.opl_p0 = 21214;
		}

		// Token: 0x060158DD RID: 88285 RVA: 0x0068153C File Offset: 0x0067F93C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F27B RID: 62075
		private int opl_p0;
	}
}
