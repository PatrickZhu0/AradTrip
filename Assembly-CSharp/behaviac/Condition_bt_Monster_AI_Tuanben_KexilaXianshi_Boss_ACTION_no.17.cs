using System;

namespace behaviac
{
	// Token: 0x02003A4A RID: 14922
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node58 : Condition
	{
		// Token: 0x06015C5D RID: 89181 RVA: 0x006938A3 File Offset: 0x00691CA3
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node58()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06015C5E RID: 89182 RVA: 0x006938C4 File Offset: 0x00691CC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F582 RID: 62850
		private HMType opl_p0;

		// Token: 0x0400F583 RID: 62851
		private BE_Operation opl_p1;

		// Token: 0x0400F584 RID: 62852
		private float opl_p2;
	}
}
