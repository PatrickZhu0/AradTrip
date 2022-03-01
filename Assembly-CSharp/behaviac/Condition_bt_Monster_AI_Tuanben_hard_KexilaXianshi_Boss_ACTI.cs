using System;

namespace behaviac
{
	// Token: 0x02003C69 RID: 15465
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node83 : Condition
	{
		// Token: 0x06016079 RID: 90233 RVA: 0x006A88FA File Offset: 0x006A6CFA
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node83()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x0601607A RID: 90234 RVA: 0x006A891C File Offset: 0x006A6D1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8FB RID: 63739
		private HMType opl_p0;

		// Token: 0x0400F8FC RID: 63740
		private BE_Operation opl_p1;

		// Token: 0x0400F8FD RID: 63741
		private float opl_p2;
	}
}
