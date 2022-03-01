using System;

namespace behaviac
{
	// Token: 0x02003E9F RID: 16031
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Event_node1 : Condition
	{
		// Token: 0x060164BD RID: 91325 RVA: 0x006BE3C1 File Offset: 0x006BC7C1
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060164BE RID: 91326 RVA: 0x006BE3E4 File Offset: 0x006BC7E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCF0 RID: 64752
		private HMType opl_p0;

		// Token: 0x0400FCF1 RID: 64753
		private BE_Operation opl_p1;

		// Token: 0x0400FCF2 RID: 64754
		private float opl_p2;
	}
}
