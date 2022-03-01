using System;

namespace behaviac
{
	// Token: 0x02003AD8 RID: 15064
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node29 : Condition
	{
		// Token: 0x06015D6F RID: 89455 RVA: 0x00698E0F File Offset: 0x0069720F
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node29()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015D70 RID: 89456 RVA: 0x00698E24 File Offset: 0x00697224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F67E RID: 63102
		private float opl_p0;
	}
}
