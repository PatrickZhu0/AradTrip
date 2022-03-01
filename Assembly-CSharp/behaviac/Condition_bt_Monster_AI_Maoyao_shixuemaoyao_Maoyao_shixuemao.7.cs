using System;

namespace behaviac
{
	// Token: 0x020035C6 RID: 13766
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node16 : Condition
	{
		// Token: 0x060153B7 RID: 86967 RVA: 0x006663DE File Offset: 0x006647DE
		public Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node16()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.2f;
		}

		// Token: 0x060153B8 RID: 86968 RVA: 0x00666400 File Offset: 0x00664800
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED78 RID: 60792
		private HMType opl_p0;

		// Token: 0x0400ED79 RID: 60793
		private BE_Operation opl_p1;

		// Token: 0x0400ED7A RID: 60794
		private float opl_p2;
	}
}
