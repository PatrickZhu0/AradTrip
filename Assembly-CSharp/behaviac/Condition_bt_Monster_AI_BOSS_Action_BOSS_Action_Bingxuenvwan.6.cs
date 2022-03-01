using System;

namespace behaviac
{
	// Token: 0x02002F75 RID: 12149
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node8 : Condition
	{
		// Token: 0x060147B8 RID: 83896 RVA: 0x0062A01D File Offset: 0x0062841D
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node8()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060147B9 RID: 83897 RVA: 0x0062A030 File Offset: 0x00628430
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E125 RID: 57637
		private float opl_p0;
	}
}
