using System;

namespace behaviac
{
	// Token: 0x02003E81 RID: 16001
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node14 : Condition
	{
		// Token: 0x06016483 RID: 91267 RVA: 0x006BCB9D File Offset: 0x006BAF9D
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node14()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06016484 RID: 91268 RVA: 0x006BCBB0 File Offset: 0x006BAFB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCBC RID: 64700
		private float opl_p0;
	}
}
