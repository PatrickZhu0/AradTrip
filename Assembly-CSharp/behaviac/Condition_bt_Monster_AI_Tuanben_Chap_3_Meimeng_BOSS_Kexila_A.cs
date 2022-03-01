using System;

namespace behaviac
{
	// Token: 0x020038D2 RID: 14546
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node3 : Condition
	{
		// Token: 0x06015981 RID: 88449 RVA: 0x00685039 File Offset: 0x00683439
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06015982 RID: 88450 RVA: 0x0068505C File Offset: 0x0068345C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F339 RID: 62265
		private HMType opl_p0;

		// Token: 0x0400F33A RID: 62266
		private BE_Operation opl_p1;

		// Token: 0x0400F33B RID: 62267
		private float opl_p2;
	}
}
