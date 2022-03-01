using System;

namespace behaviac
{
	// Token: 0x020025FD RID: 9725
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node13 : Condition
	{
		// Token: 0x06013540 RID: 79168 RVA: 0x005C0389 File Offset: 0x005BE789
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node13()
		{
			this.opl_p0 = 1106;
		}

		// Token: 0x06013541 RID: 79169 RVA: 0x005C039C File Offset: 0x005BE79C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF8D RID: 53133
		private int opl_p0;
	}
}
