using System;

namespace behaviac
{
	// Token: 0x020035F5 RID: 13813
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7 : Condition
	{
		// Token: 0x06015410 RID: 87056 RVA: 0x0066830E File Offset: 0x0066670E
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06015411 RID: 87057 RVA: 0x00668330 File Offset: 0x00666730
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDC7 RID: 60871
		private HMType opl_p0;

		// Token: 0x0400EDC8 RID: 60872
		private BE_Operation opl_p1;

		// Token: 0x0400EDC9 RID: 60873
		private float opl_p2;
	}
}
