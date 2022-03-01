using System;

namespace behaviac
{
	// Token: 0x02003B1D RID: 15133
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node8 : Condition
	{
		// Token: 0x06015DF2 RID: 89586 RVA: 0x0069BD99 File Offset: 0x0069A199
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node8()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x06015DF3 RID: 89587 RVA: 0x0069BDBC File Offset: 0x0069A1BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6D7 RID: 63191
		private HMType opl_p0;

		// Token: 0x0400F6D8 RID: 63192
		private BE_Operation opl_p1;

		// Token: 0x0400F6D9 RID: 63193
		private float opl_p2;
	}
}
