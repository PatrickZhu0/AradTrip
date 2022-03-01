using System;

namespace behaviac
{
	// Token: 0x02003D98 RID: 15768
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node1 : Condition
	{
		// Token: 0x060162C3 RID: 90819 RVA: 0x006B4169 File Offset: 0x006B2569
		public Condition_bt_Monster_AI_Tuanben_hard_Xianfeng_Event_hard_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x060162C4 RID: 90820 RVA: 0x006B418C File Offset: 0x006B258C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB11 RID: 64273
		private HMType opl_p0;

		// Token: 0x0400FB12 RID: 64274
		private BE_Operation opl_p1;

		// Token: 0x0400FB13 RID: 64275
		private float opl_p2;
	}
}
