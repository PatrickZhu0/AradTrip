using System;

namespace behaviac
{
	// Token: 0x02003207 RID: 12807
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node25 : Condition
	{
		// Token: 0x06014C98 RID: 85144 RVA: 0x006430CF File Offset: 0x006414CF
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node25()
		{
			this.opl_p0 = 21559;
		}

		// Token: 0x06014C99 RID: 85145 RVA: 0x006430E4 File Offset: 0x006414E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5E6 RID: 58854
		private int opl_p0;
	}
}
