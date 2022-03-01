using System;

namespace behaviac
{
	// Token: 0x02002FA3 RID: 12195
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node73 : Condition
	{
		// Token: 0x06014814 RID: 83988 RVA: 0x0062B227 File Offset: 0x00629627
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node73()
		{
			this.opl_p0 = 5546;
		}

		// Token: 0x06014815 RID: 83989 RVA: 0x0062B23C File Offset: 0x0062963C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E176 RID: 57718
		private int opl_p0;
	}
}
