using System;

namespace behaviac
{
	// Token: 0x02002056 RID: 8278
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node37 : Condition
	{
		// Token: 0x06012A46 RID: 76358 RVA: 0x00577B92 File Offset: 0x00575F92
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node37()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06012A47 RID: 76359 RVA: 0x00577BA8 File Offset: 0x00575FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C439 RID: 50233
		private float opl_p0;
	}
}
