using System;

namespace behaviac
{
	// Token: 0x020033B5 RID: 13237
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node15 : Condition
	{
		// Token: 0x06014FC3 RID: 85955 RVA: 0x00652967 File Offset: 0x00650D67
		public Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node15()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014FC4 RID: 85956 RVA: 0x00652988 File Offset: 0x00650D88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8A7 RID: 59559
		private HMType opl_p0;

		// Token: 0x0400E8A8 RID: 59560
		private BE_Operation opl_p1;

		// Token: 0x0400E8A9 RID: 59561
		private float opl_p2;
	}
}
