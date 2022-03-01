using System;

namespace behaviac
{
	// Token: 0x020040A9 RID: 16553
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node4 : Condition
	{
		// Token: 0x060168AB RID: 92331 RVA: 0x006D3689 File Offset: 0x006D1A89
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node4()
		{
			this.opl_p0 = 5092;
		}

		// Token: 0x060168AC RID: 92332 RVA: 0x006D369C File Offset: 0x006D1A9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100F3 RID: 65779
		private int opl_p0;
	}
}
