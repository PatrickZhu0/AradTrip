using System;

namespace behaviac
{
	// Token: 0x020033AC RID: 13228
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node6 : Condition
	{
		// Token: 0x06014FB1 RID: 85937 RVA: 0x00652690 File Offset: 0x00650A90
		public Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node6()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06014FB2 RID: 85938 RVA: 0x006526B4 File Offset: 0x00650AB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E88E RID: 59534
		private HMType opl_p0;

		// Token: 0x0400E88F RID: 59535
		private BE_Operation opl_p1;

		// Token: 0x0400E890 RID: 59536
		private float opl_p2;
	}
}
