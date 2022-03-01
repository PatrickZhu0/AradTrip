using System;

namespace behaviac
{
	// Token: 0x02003E95 RID: 16021
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node12 : Condition
	{
		// Token: 0x060164AA RID: 91306 RVA: 0x006BDB11 File Offset: 0x006BBF11
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node12()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060164AB RID: 91307 RVA: 0x006BDB24 File Offset: 0x006BBF24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCE4 RID: 64740
		private float opl_p0;
	}
}
