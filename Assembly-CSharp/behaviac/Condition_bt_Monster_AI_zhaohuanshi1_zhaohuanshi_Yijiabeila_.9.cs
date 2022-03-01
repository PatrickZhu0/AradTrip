using System;

namespace behaviac
{
	// Token: 0x020040B1 RID: 16561
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node9 : Condition
	{
		// Token: 0x060168BB RID: 92347 RVA: 0x006D39F1 File Offset: 0x006D1DF1
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node9()
		{
			this.opl_p0 = 5093;
		}

		// Token: 0x060168BC RID: 92348 RVA: 0x006D3A04 File Offset: 0x006D1E04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010103 RID: 65795
		private int opl_p0;
	}
}
