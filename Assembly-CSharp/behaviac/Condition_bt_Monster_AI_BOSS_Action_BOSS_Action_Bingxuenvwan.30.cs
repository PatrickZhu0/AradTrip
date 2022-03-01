using System;

namespace behaviac
{
	// Token: 0x02002F93 RID: 12179
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node40 : Condition
	{
		// Token: 0x060147F4 RID: 83956 RVA: 0x0062ABED File Offset: 0x00628FED
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node40()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060147F5 RID: 83957 RVA: 0x0062AC00 File Offset: 0x00629000
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E15A RID: 57690
		private float opl_p0;
	}
}
