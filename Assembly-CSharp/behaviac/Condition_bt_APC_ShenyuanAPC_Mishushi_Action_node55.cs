using System;

namespace behaviac
{
	// Token: 0x02001E99 RID: 7833
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node55 : Condition
	{
		// Token: 0x060126DC RID: 75484 RVA: 0x005639DD File Offset: 0x00561DDD
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node55()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060126DD RID: 75485 RVA: 0x005639F0 File Offset: 0x00561DF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0CB RID: 49355
		private float opl_p0;
	}
}
