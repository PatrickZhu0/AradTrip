using System;

namespace behaviac
{
	// Token: 0x02003E89 RID: 16009
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node31 : Condition
	{
		// Token: 0x06016493 RID: 91283 RVA: 0x006BCFBD File Offset: 0x006BB3BD
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node31()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06016494 RID: 91284 RVA: 0x006BCFD0 File Offset: 0x006BB3D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCCC RID: 64716
		private float opl_p0;
	}
}
