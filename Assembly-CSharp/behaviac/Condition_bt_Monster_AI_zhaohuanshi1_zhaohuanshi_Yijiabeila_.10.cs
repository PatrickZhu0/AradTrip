using System;

namespace behaviac
{
	// Token: 0x020040B3 RID: 16563
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node27 : Condition
	{
		// Token: 0x060168BF RID: 92351 RVA: 0x006D3AE2 File Offset: 0x006D1EE2
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node27()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060168C0 RID: 92352 RVA: 0x006D3AF8 File Offset: 0x006D1EF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010106 RID: 65798
		private float opl_p0;
	}
}
