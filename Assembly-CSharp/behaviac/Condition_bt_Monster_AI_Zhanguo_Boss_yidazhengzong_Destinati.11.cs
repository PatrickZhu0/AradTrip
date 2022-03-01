using System;

namespace behaviac
{
	// Token: 0x02003E9C RID: 16028
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node15 : Condition
	{
		// Token: 0x060164B8 RID: 91320 RVA: 0x006BDCDD File Offset: 0x006BC0DD
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node15()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060164B9 RID: 91321 RVA: 0x006BDCF0 File Offset: 0x006BC0F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCEE RID: 64750
		private float opl_p0;
	}
}
