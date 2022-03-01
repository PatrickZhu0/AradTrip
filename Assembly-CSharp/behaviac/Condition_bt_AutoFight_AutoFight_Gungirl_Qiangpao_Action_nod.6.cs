using System;

namespace behaviac
{
	// Token: 0x0200251A RID: 9498
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node48 : Condition
	{
		// Token: 0x0601337D RID: 78717 RVA: 0x005B5E1F File Offset: 0x005B421F
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node48()
		{
			this.opl_p0 = 2602;
		}

		// Token: 0x0601337E RID: 78718 RVA: 0x005B5E34 File Offset: 0x005B4234
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDA0 RID: 52640
		private int opl_p0;
	}
}
