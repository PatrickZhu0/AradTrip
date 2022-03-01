using System;

namespace behaviac
{
	// Token: 0x02003F8F RID: 16271
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node7 : Condition
	{
		// Token: 0x06016688 RID: 91784 RVA: 0x006C7759 File Offset: 0x006C5B59
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node7()
		{
			this.opl_p0 = 5109;
		}

		// Token: 0x06016689 RID: 91785 RVA: 0x006C776C File Offset: 0x006C5B6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEDC RID: 65244
		private int opl_p0;
	}
}
