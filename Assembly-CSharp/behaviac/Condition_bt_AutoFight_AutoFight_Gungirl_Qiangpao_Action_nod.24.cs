using System;

namespace behaviac
{
	// Token: 0x02002532 RID: 9522
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node32 : Condition
	{
		// Token: 0x060133AD RID: 78765 RVA: 0x005B68A7 File Offset: 0x005B4CA7
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node32()
		{
			this.opl_p0 = 2603;
		}

		// Token: 0x060133AE RID: 78766 RVA: 0x005B68BC File Offset: 0x005B4CBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDD4 RID: 52692
		private int opl_p0;
	}
}
