using System;

namespace behaviac
{
	// Token: 0x020036CA RID: 14026
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node8 : Condition
	{
		// Token: 0x060155AC RID: 87468 RVA: 0x006712AB File Offset: 0x0066F6AB
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node8()
		{
			this.opl_p0 = 5433;
		}

		// Token: 0x060155AD RID: 87469 RVA: 0x006712C0 File Offset: 0x0066F6C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF7F RID: 61311
		private int opl_p0;
	}
}
