using System;

namespace behaviac
{
	// Token: 0x02002F9E RID: 12190
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node72 : Condition
	{
		// Token: 0x0601480A RID: 83978 RVA: 0x0062B02B File Offset: 0x0062942B
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node72()
		{
			this.opl_p0 = 5548;
		}

		// Token: 0x0601480B RID: 83979 RVA: 0x0062B040 File Offset: 0x00629440
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E16D RID: 57709
		private int opl_p0;
	}
}
