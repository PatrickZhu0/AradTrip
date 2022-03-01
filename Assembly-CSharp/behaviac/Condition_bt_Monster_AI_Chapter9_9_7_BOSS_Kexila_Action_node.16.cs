using System;

namespace behaviac
{
	// Token: 0x02003211 RID: 12817
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node54 : Condition
	{
		// Token: 0x06014CAC RID: 85164 RVA: 0x006434E3 File Offset: 0x006418E3
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node54()
		{
			this.opl_p0 = 21559;
		}

		// Token: 0x06014CAD RID: 85165 RVA: 0x006434F8 File Offset: 0x006418F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5F5 RID: 58869
		private int opl_p0;
	}
}
