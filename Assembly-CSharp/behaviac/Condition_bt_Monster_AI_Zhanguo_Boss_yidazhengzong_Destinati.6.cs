using System;

namespace behaviac
{
	// Token: 0x02003E93 RID: 16019
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node24 : Condition
	{
		// Token: 0x060164A6 RID: 91302 RVA: 0x006BDAA0 File Offset: 0x006BBEA0
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node24()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060164A7 RID: 91303 RVA: 0x006BDAB4 File Offset: 0x006BBEB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCE2 RID: 64738
		private float opl_p0;
	}
}
