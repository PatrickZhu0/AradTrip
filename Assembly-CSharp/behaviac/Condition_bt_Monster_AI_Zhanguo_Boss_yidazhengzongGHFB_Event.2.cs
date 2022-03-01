using System;

namespace behaviac
{
	// Token: 0x02003E72 RID: 15986
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzongGHFB_Event_node1 : Condition
	{
		// Token: 0x06016466 RID: 91238 RVA: 0x006BC3F9 File Offset: 0x006BA7F9
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzongGHFB_Event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06016467 RID: 91239 RVA: 0x006BC41C File Offset: 0x006BA81C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC9E RID: 64670
		private HMType opl_p0;

		// Token: 0x0400FC9F RID: 64671
		private BE_Operation opl_p1;

		// Token: 0x0400FCA0 RID: 64672
		private float opl_p2;
	}
}
