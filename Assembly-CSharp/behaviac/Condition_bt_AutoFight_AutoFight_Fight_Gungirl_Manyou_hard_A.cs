using System;

namespace behaviac
{
	// Token: 0x02002012 RID: 8210
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node2 : Condition
	{
		// Token: 0x060129BF RID: 76223 RVA: 0x005750D2 File Offset: 0x005734D2
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node2()
		{
			this.opl_p0 = 0.63f;
		}

		// Token: 0x060129C0 RID: 76224 RVA: 0x005750E8 File Offset: 0x005734E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3B2 RID: 50098
		private float opl_p0;
	}
}
