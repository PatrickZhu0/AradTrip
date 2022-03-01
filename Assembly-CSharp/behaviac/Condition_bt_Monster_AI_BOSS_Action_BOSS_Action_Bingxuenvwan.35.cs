using System;

namespace behaviac
{
	// Token: 0x02002F99 RID: 12185
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node71 : Condition
	{
		// Token: 0x06014800 RID: 83968 RVA: 0x0062AE2F File Offset: 0x0062922F
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node71()
		{
			this.opl_p0 = 5547;
		}

		// Token: 0x06014801 RID: 83969 RVA: 0x0062AE44 File Offset: 0x00629244
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E164 RID: 57700
		private int opl_p0;
	}
}
