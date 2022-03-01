using System;

namespace behaviac
{
	// Token: 0x0200253A RID: 9530
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node36 : Condition
	{
		// Token: 0x060133BD RID: 78781 RVA: 0x005B6C17 File Offset: 0x005B5017
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node36()
		{
			this.opl_p0 = 2605;
		}

		// Token: 0x060133BE RID: 78782 RVA: 0x005B6C2C File Offset: 0x005B502C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDE4 RID: 52708
		private int opl_p0;
	}
}
