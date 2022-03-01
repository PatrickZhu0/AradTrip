using System;

namespace behaviac
{
	// Token: 0x02003D8D RID: 15757
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node23 : Condition
	{
		// Token: 0x060162AF RID: 90799 RVA: 0x006B3319 File Offset: 0x006B1719
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node23()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.2f;
		}

		// Token: 0x060162B0 RID: 90800 RVA: 0x006B333C File Offset: 0x006B173C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB00 RID: 64256
		private HMType opl_p0;

		// Token: 0x0400FB01 RID: 64257
		private BE_Operation opl_p1;

		// Token: 0x0400FB02 RID: 64258
		private float opl_p2;
	}
}
