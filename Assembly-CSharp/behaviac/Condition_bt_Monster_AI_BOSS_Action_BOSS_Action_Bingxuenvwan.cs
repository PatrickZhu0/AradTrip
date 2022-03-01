using System;

namespace behaviac
{
	// Token: 0x02002F6F RID: 12143
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node3 : Condition
	{
		// Token: 0x060147AC RID: 83884 RVA: 0x00629DBE File Offset: 0x006281BE
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x060147AD RID: 83885 RVA: 0x00629DE0 File Offset: 0x006281E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E119 RID: 57625
		private HMType opl_p0;

		// Token: 0x0400E11A RID: 57626
		private BE_Operation opl_p1;

		// Token: 0x0400E11B RID: 57627
		private float opl_p2;
	}
}
