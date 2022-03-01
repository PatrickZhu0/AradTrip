using System;

namespace behaviac
{
	// Token: 0x02003E79 RID: 15993
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node6 : Condition
	{
		// Token: 0x06016473 RID: 91251 RVA: 0x006BC7D8 File Offset: 0x006BABD8
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node6()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016474 RID: 91252 RVA: 0x006BC7EC File Offset: 0x006BABEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCAC RID: 64684
		private float opl_p0;
	}
}
