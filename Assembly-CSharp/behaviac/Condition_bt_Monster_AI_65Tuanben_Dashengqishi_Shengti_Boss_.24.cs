using System;

namespace behaviac
{
	// Token: 0x02002DF2 RID: 11762
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node64 : Condition
	{
		// Token: 0x060144C1 RID: 83137 RVA: 0x0061903E File Offset: 0x0061743E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node64()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570290;
		}

		// Token: 0x060144C2 RID: 83138 RVA: 0x00619060 File Offset: 0x00617460
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE7B RID: 56955
		private BE_Target opl_p0;

		// Token: 0x0400DE7C RID: 56956
		private BE_Equal opl_p1;

		// Token: 0x0400DE7D RID: 56957
		private int opl_p2;
	}
}
