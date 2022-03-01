using System;

namespace behaviac
{
	// Token: 0x02003E7E RID: 15998
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node11 : Condition
	{
		// Token: 0x0601647D RID: 91261 RVA: 0x006BC9D3 File Offset: 0x006BADD3
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node11()
		{
			this.opl_p0 = 7284;
		}

		// Token: 0x0601647E RID: 91262 RVA: 0x006BC9E8 File Offset: 0x006BADE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCB5 RID: 64693
		private int opl_p0;
	}
}
