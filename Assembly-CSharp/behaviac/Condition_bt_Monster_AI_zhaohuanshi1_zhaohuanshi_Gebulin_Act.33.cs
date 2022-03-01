using System;

namespace behaviac
{
	// Token: 0x02004060 RID: 16480
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node57 : Condition
	{
		// Token: 0x0601681F RID: 92191 RVA: 0x006CFA3D File Offset: 0x006CDE3D
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node57()
		{
			this.opl_p0 = 5111;
		}

		// Token: 0x06016820 RID: 92192 RVA: 0x006CFA50 File Offset: 0x006CDE50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401006B RID: 65643
		private int opl_p0;
	}
}
