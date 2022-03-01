using System;

namespace behaviac
{
	// Token: 0x020033B2 RID: 13234
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node12 : Condition
	{
		// Token: 0x06014FBD RID: 85949 RVA: 0x0065283F File Offset: 0x00650C3F
		public Condition_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node12()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014FBE RID: 85950 RVA: 0x00652860 File Offset: 0x00650C60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E89C RID: 59548
		private HMType opl_p0;

		// Token: 0x0400E89D RID: 59549
		private BE_Operation opl_p1;

		// Token: 0x0400E89E RID: 59550
		private float opl_p2;
	}
}
