using System;

namespace behaviac
{
	// Token: 0x02003149 RID: 12617
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Yashouwang_Event_node2 : Condition
	{
		// Token: 0x06014B34 RID: 84788 RVA: 0x0063BFB3 File Offset: 0x0063A3B3
		public Condition_bt_Monster_AI_Chapter10_Yashouwang_Event_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014B35 RID: 84789 RVA: 0x0063BFD4 File Offset: 0x0063A3D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4AB RID: 58539
		private HMType opl_p0;

		// Token: 0x0400E4AC RID: 58540
		private BE_Operation opl_p1;

		// Token: 0x0400E4AD RID: 58541
		private float opl_p2;
	}
}
