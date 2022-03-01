using System;

namespace behaviac
{
	// Token: 0x020033B8 RID: 13240
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node18 : Condition
	{
		// Token: 0x06014FC9 RID: 85961 RVA: 0x00652A68 File Offset: 0x00650E68
		public Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node18()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014FCA RID: 85962 RVA: 0x00652A8C File Offset: 0x00650E8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8B1 RID: 59569
		private HMType opl_p0;

		// Token: 0x0400E8B2 RID: 59570
		private BE_Operation opl_p1;

		// Token: 0x0400E8B3 RID: 59571
		private float opl_p2;
	}
}
