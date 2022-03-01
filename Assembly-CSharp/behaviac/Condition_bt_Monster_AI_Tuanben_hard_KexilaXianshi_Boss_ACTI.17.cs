using System;

namespace behaviac
{
	// Token: 0x02003C7C RID: 15484
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node58 : Condition
	{
		// Token: 0x0601609F RID: 90271 RVA: 0x006A908B File Offset: 0x006A748B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node58()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x060160A0 RID: 90272 RVA: 0x006A90AC File Offset: 0x006A74AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F930 RID: 63792
		private HMType opl_p0;

		// Token: 0x0400F931 RID: 63793
		private BE_Operation opl_p1;

		// Token: 0x0400F932 RID: 63794
		private float opl_p2;
	}
}
