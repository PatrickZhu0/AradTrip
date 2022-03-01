using System;

namespace behaviac
{
	// Token: 0x020035C2 RID: 13762
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node12 : Condition
	{
		// Token: 0x060153AF RID: 86959 RVA: 0x00666261 File Offset: 0x00664661
		public Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node12()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x060153B0 RID: 86960 RVA: 0x00666284 File Offset: 0x00664684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED72 RID: 60786
		private HMType opl_p0;

		// Token: 0x0400ED73 RID: 60787
		private BE_Operation opl_p1;

		// Token: 0x0400ED74 RID: 60788
		private float opl_p2;
	}
}
