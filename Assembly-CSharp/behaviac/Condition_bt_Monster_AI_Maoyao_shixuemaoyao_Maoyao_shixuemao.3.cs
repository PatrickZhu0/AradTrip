using System;

namespace behaviac
{
	// Token: 0x020035BE RID: 13758
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node8 : Condition
	{
		// Token: 0x060153A7 RID: 86951 RVA: 0x0066610F File Offset: 0x0066450F
		public Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node8()
		{
			this.opl_p0 = 5038;
		}

		// Token: 0x060153A8 RID: 86952 RVA: 0x00666124 File Offset: 0x00664524
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED6F RID: 60783
		private int opl_p0;
	}
}
