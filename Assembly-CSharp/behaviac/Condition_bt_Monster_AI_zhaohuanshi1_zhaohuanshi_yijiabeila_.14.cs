using System;

namespace behaviac
{
	// Token: 0x020040BA RID: 16570
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node8 : Condition
	{
		// Token: 0x060168CC RID: 92364 RVA: 0x006D41D7 File Offset: 0x006D25D7
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node8()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060168CD RID: 92365 RVA: 0x006D41EC File Offset: 0x006D25EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010113 RID: 65811
		private float opl_p0;
	}
}
