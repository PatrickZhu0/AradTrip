using System;

namespace behaviac
{
	// Token: 0x02003E9A RID: 16026
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node28 : Condition
	{
		// Token: 0x060164B4 RID: 91316 RVA: 0x006BDC6D File Offset: 0x006BC06D
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node28()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060164B5 RID: 91317 RVA: 0x006BDC80 File Offset: 0x006BC080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCEC RID: 64748
		private float opl_p0;
	}
}
