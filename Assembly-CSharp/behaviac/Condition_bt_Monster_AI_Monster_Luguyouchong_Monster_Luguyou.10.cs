using System;

namespace behaviac
{
	// Token: 0x020036D3 RID: 14035
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node8 : Condition
	{
		// Token: 0x060155BD RID: 87485 RVA: 0x006718C3 File Offset: 0x0066FCC3
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node8()
		{
			this.opl_p0 = 5431;
		}

		// Token: 0x060155BE RID: 87486 RVA: 0x006718D8 File Offset: 0x0066FCD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF90 RID: 61328
		private int opl_p0;
	}
}
