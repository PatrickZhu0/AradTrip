using System;

namespace behaviac
{
	// Token: 0x020035C3 RID: 13763
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node13 : Condition
	{
		// Token: 0x060153B1 RID: 86961 RVA: 0x006662C3 File Offset: 0x006646C3
		public Condition_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node13()
		{
			this.opl_p0 = 5038;
		}

		// Token: 0x060153B2 RID: 86962 RVA: 0x006662D8 File Offset: 0x006646D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED75 RID: 60789
		private int opl_p0;
	}
}
