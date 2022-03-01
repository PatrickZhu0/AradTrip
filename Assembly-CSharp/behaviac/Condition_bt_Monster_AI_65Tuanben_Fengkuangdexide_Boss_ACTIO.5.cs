using System;

namespace behaviac
{
	// Token: 0x02002EB1 RID: 11953
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node28 : Condition
	{
		// Token: 0x0601463C RID: 83516 RVA: 0x00621EBD File Offset: 0x006202BD
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node28()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x0601463D RID: 83517 RVA: 0x00621EE0 File Offset: 0x006202E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFB0 RID: 57264
		private HMType opl_p0;

		// Token: 0x0400DFB1 RID: 57265
		private BE_Operation opl_p1;

		// Token: 0x0400DFB2 RID: 57266
		private float opl_p2;
	}
}
