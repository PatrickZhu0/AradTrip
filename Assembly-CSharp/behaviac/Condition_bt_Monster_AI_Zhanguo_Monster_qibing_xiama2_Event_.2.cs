using System;

namespace behaviac
{
	// Token: 0x02003EE8 RID: 16104
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama2_Event_node1 : Condition
	{
		// Token: 0x0601654A RID: 91466 RVA: 0x006C1909 File Offset: 0x006BFD09
		public Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama2_Event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x0601654B RID: 91467 RVA: 0x006C192C File Offset: 0x006BFD2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD77 RID: 64887
		private HMType opl_p0;

		// Token: 0x0400FD78 RID: 64888
		private BE_Operation opl_p1;

		// Token: 0x0400FD79 RID: 64889
		private float opl_p2;
	}
}
