using System;

namespace behaviac
{
	// Token: 0x02003FBB RID: 16315
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node62 : Condition
	{
		// Token: 0x060166E0 RID: 91872 RVA: 0x006C8A15 File Offset: 0x006C6E15
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node62()
		{
			this.opl_p0 = 5110;
		}

		// Token: 0x060166E1 RID: 91873 RVA: 0x006C8A28 File Offset: 0x006C6E28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF34 RID: 65332
		private int opl_p0;
	}
}
