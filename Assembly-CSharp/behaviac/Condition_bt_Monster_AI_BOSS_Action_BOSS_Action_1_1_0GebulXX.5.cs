using System;

namespace behaviac
{
	// Token: 0x02002F39 RID: 12089
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node10 : Condition
	{
		// Token: 0x06014743 RID: 83779 RVA: 0x006275F1 File Offset: 0x006259F1
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node10()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014744 RID: 83780 RVA: 0x00627604 File Offset: 0x00625A04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0B5 RID: 57525
		private float opl_p0;
	}
}
