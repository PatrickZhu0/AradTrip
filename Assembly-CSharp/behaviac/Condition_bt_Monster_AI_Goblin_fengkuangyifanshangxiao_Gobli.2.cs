using System;

namespace behaviac
{
	// Token: 0x020033B1 RID: 13233
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node11 : Condition
	{
		// Token: 0x06014FBB RID: 85947 RVA: 0x006527DF File Offset: 0x00650BDF
		public Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node11()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06014FBC RID: 85948 RVA: 0x00652800 File Offset: 0x00650C00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E899 RID: 59545
		private HMType opl_p0;

		// Token: 0x0400E89A RID: 59546
		private BE_Operation opl_p1;

		// Token: 0x0400E89B RID: 59547
		private float opl_p2;
	}
}
