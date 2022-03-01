using System;

namespace behaviac
{
	// Token: 0x02002F9D RID: 12189
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node50 : Condition
	{
		// Token: 0x06014808 RID: 83976 RVA: 0x0062AFE5 File Offset: 0x006293E5
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node50()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014809 RID: 83977 RVA: 0x0062AFF8 File Offset: 0x006293F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E16C RID: 57708
		private float opl_p0;
	}
}
