using System;

namespace behaviac
{
	// Token: 0x0200338B RID: 13195
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node15 : Condition
	{
		// Token: 0x06014F73 RID: 85875 RVA: 0x00650D51 File Offset: 0x0064F151
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node15()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x06014F74 RID: 85876 RVA: 0x00650D74 File Offset: 0x0064F174
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E847 RID: 59463
		private HMType opl_p0;

		// Token: 0x0400E848 RID: 59464
		private BE_Operation opl_p1;

		// Token: 0x0400E849 RID: 59465
		private float opl_p2;
	}
}
