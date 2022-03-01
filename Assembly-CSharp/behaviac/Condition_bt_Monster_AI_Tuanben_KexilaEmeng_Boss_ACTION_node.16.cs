using System;

namespace behaviac
{
	// Token: 0x020039E6 RID: 14822
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node29 : Condition
	{
		// Token: 0x06015B9C RID: 88988 RVA: 0x0068F8FA File Offset: 0x0068DCFA
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node29()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06015B9D RID: 88989 RVA: 0x0068F91C File Offset: 0x0068DD1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4DC RID: 62684
		private HMType opl_p0;

		// Token: 0x0400F4DD RID: 62685
		private BE_Operation opl_p1;

		// Token: 0x0400F4DE RID: 62686
		private float opl_p2;
	}
}
