using System;

namespace behaviac
{
	// Token: 0x02003E85 RID: 16005
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node19 : Condition
	{
		// Token: 0x0601648B RID: 91275 RVA: 0x006BCD51 File Offset: 0x006BB151
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node19()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601648C RID: 91276 RVA: 0x006BCD64 File Offset: 0x006BB164
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCC4 RID: 64708
		private float opl_p0;
	}
}
