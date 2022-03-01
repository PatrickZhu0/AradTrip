using System;

namespace behaviac
{
	// Token: 0x02003B31 RID: 15153
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node26 : Condition
	{
		// Token: 0x06015E1A RID: 89626 RVA: 0x0069C4A1 File Offset: 0x0069A8A1
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node26()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06015E1B RID: 89627 RVA: 0x0069C4C4 File Offset: 0x0069A8C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6FA RID: 63226
		private HMType opl_p0;

		// Token: 0x0400F6FB RID: 63227
		private BE_Operation opl_p1;

		// Token: 0x0400F6FC RID: 63228
		private float opl_p2;
	}
}
