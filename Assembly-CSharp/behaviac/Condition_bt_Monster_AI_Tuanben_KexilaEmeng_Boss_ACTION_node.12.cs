using System;

namespace behaviac
{
	// Token: 0x020039E0 RID: 14816
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node58 : Condition
	{
		// Token: 0x06015B90 RID: 88976 RVA: 0x0068F66A File Offset: 0x0068DA6A
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node58()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06015B91 RID: 88977 RVA: 0x0068F68C File Offset: 0x0068DA8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4D2 RID: 62674
		private HMType opl_p0;

		// Token: 0x0400F4D3 RID: 62675
		private BE_Operation opl_p1;

		// Token: 0x0400F4D4 RID: 62676
		private float opl_p2;
	}
}
