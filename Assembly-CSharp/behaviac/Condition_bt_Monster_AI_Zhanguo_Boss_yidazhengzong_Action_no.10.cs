using System;

namespace behaviac
{
	// Token: 0x02003E82 RID: 16002
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node0 : Condition
	{
		// Token: 0x06016485 RID: 91269 RVA: 0x006BCBE3 File Offset: 0x006BAFE3
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node0()
		{
			this.opl_p0 = 7285;
		}

		// Token: 0x06016486 RID: 91270 RVA: 0x006BCBF8 File Offset: 0x006BAFF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCBD RID: 64701
		private int opl_p0;
	}
}
