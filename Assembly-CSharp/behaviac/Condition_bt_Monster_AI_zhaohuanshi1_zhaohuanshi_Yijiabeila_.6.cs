using System;

namespace behaviac
{
	// Token: 0x020040AD RID: 16557
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node24 : Condition
	{
		// Token: 0x060168B3 RID: 92339 RVA: 0x006D383D File Offset: 0x006D1C3D
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node24()
		{
			this.opl_p0 = 5094;
		}

		// Token: 0x060168B4 RID: 92340 RVA: 0x006D3850 File Offset: 0x006D1C50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100FB RID: 65787
		private int opl_p0;
	}
}
