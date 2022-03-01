using System;

namespace behaviac
{
	// Token: 0x0200358F RID: 13711
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node6 : Condition
	{
		// Token: 0x0601534F RID: 86863 RVA: 0x006644C1 File Offset: 0x006628C1
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node6()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06015350 RID: 86864 RVA: 0x006644E4 File Offset: 0x006628E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED13 RID: 60691
		private HMType opl_p0;

		// Token: 0x0400ED14 RID: 60692
		private BE_Operation opl_p1;

		// Token: 0x0400ED15 RID: 60693
		private float opl_p2;
	}
}
