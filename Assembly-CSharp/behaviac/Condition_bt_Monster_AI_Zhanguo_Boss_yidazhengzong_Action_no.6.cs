using System;

namespace behaviac
{
	// Token: 0x02003E7D RID: 15997
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node10 : Condition
	{
		// Token: 0x0601647B RID: 91259 RVA: 0x006BC98D File Offset: 0x006BAD8D
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node10()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601647C RID: 91260 RVA: 0x006BC9A0 File Offset: 0x006BADA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCB4 RID: 64692
		private float opl_p0;
	}
}
