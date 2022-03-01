using System;

namespace behaviac
{
	// Token: 0x02002F84 RID: 12164
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node25 : Condition
	{
		// Token: 0x060147D6 RID: 83926 RVA: 0x0062A5F9 File Offset: 0x006289F9
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node25()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060147D7 RID: 83927 RVA: 0x0062A60C File Offset: 0x00628A0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E13F RID: 57663
		private float opl_p0;
	}
}
