using System;

namespace behaviac
{
	// Token: 0x02001EB4 RID: 7860
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node32 : Condition
	{
		// Token: 0x06012710 RID: 75536 RVA: 0x00564CBF File Offset: 0x005630BF
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node32()
		{
			this.opl_p0 = 9703;
		}

		// Token: 0x06012711 RID: 75537 RVA: 0x00564CD4 File Offset: 0x005630D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0FE RID: 49406
		private int opl_p0;
	}
}
