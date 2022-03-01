using System;

namespace behaviac
{
	// Token: 0x02003606 RID: 13830
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node28 : Condition
	{
		// Token: 0x06015432 RID: 87090 RVA: 0x00668A3E File Offset: 0x00666E3E
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node28()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x06015433 RID: 87091 RVA: 0x00668A60 File Offset: 0x00666E60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDEA RID: 60906
		private HMType opl_p0;

		// Token: 0x0400EDEB RID: 60907
		private BE_Operation opl_p1;

		// Token: 0x0400EDEC RID: 60908
		private float opl_p2;
	}
}
