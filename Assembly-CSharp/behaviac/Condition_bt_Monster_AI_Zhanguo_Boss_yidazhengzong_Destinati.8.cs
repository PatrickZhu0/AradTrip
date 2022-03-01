using System;

namespace behaviac
{
	// Token: 0x02003E97 RID: 16023
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node7 : Condition
	{
		// Token: 0x060164AE RID: 91310 RVA: 0x006BDB81 File Offset: 0x006BBF81
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node7()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060164AF RID: 91311 RVA: 0x006BDB94 File Offset: 0x006BBF94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCE6 RID: 64742
		private float opl_p0;
	}
}
