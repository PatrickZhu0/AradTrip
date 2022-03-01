using System;

namespace behaviac
{
	// Token: 0x02003BA3 RID: 15267
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node58 : Condition
	{
		// Token: 0x06015EF6 RID: 89846 RVA: 0x006A07AB File Offset: 0x0069EBAB
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node58()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06015EF7 RID: 89847 RVA: 0x006A07CC File Offset: 0x0069EBCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F79D RID: 63389
		private HMType opl_p0;

		// Token: 0x0400F79E RID: 63390
		private BE_Operation opl_p1;

		// Token: 0x0400F79F RID: 63391
		private float opl_p2;
	}
}
