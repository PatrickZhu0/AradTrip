using System;

namespace behaviac
{
	// Token: 0x02003EA5 RID: 16037
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node20 : Condition
	{
		// Token: 0x060164C8 RID: 91336 RVA: 0x006BE70D File Offset: 0x006BCB0D
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node20()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060164C9 RID: 91337 RVA: 0x006BE720 File Offset: 0x006BCB20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCFB RID: 64763
		private float opl_p0;
	}
}
