using System;

namespace behaviac
{
	// Token: 0x02001E6F RID: 7791
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node2 : Condition
	{
		// Token: 0x0601268A RID: 75402 RVA: 0x00561B93 File Offset: 0x0055FF93
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node2()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601268B RID: 75403 RVA: 0x00561BA8 File Offset: 0x0055FFA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C074 RID: 49268
		private float opl_p0;
	}
}
