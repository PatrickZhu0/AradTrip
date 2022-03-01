using System;

namespace behaviac
{
	// Token: 0x02003EFA RID: 16122
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama_Event_node2 : Condition
	{
		// Token: 0x0601656B RID: 91499 RVA: 0x006C225D File Offset: 0x006C065D
		public Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama_Event_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x0601656C RID: 91500 RVA: 0x006C2280 File Offset: 0x006C0680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD89 RID: 64905
		private HMType opl_p0;

		// Token: 0x0400FD8A RID: 64906
		private BE_Operation opl_p1;

		// Token: 0x0400FD8B RID: 64907
		private float opl_p2;
	}
}
